using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public static class PasswordHelper
    {
        public static string PasswordHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return null;

            using (var deriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(
                password,
                16,
                100000))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] hash = deriveBytes.GetBytes(32);

                return Convert.ToBase64String(salt) + "." +
                       Convert.ToBase64String(hash);
            }
        }

        public static bool PasswordVerify(
            string password,
            string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(passwordHash))
                return false;

            var parts = passwordHash.Split('.');

            if (parts.Length != 2)
                return false;

            byte[] salt;
            byte[] storedHash;

            try
            {
                salt = Convert.FromBase64String(parts[0]);
                storedHash = Convert.FromBase64String(parts[1]);
            }
            catch
            {
                return false;
            }

            using (var deriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(
                password,
                salt,
                100000))
            {
                byte[] hash = deriveBytes.GetBytes(32);

                if (hash.Length != storedHash.Length)
                    return false;

                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != storedHash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
