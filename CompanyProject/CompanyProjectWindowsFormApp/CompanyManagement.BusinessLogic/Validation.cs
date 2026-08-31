using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public static class Validation
    {
        public static bool StringControl(
            string value,
            int minLength,
            int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length < minLength ||
                value.Length > maxLength)
                return false;

            return true;
        }

        public static bool IntControl(
            int value,
            int minValue,
            int maxValue)
        {
            if (value < minValue ||
                value > maxValue)
                return false;

            return true;
        }

        public static bool DecimalControl(
            decimal value,
            decimal minValue,
            decimal maxValue)
        {
            if (value < minValue ||
                value > maxValue)
                return false;

            return true;
        }

        public static bool DateTimeControl(
            DateTime value,
            bool allowNull)
        {
            if (value == default(DateTime))
            {
                if (allowNull)
                    return true;

                return false;
            }

            return true;
        }

        public static bool BirthDateControl(
            DateTime value,
            bool allowNull)
        {
            if (value == default(DateTime))
            {
                if (allowNull)
                    return true;

                return false;
            }

            if (value.Year < 1900 ||
                value > DateTime.Now)
                return false;

            return true;
        }

        public static bool EmailControl(
            string email,
            bool allowNull)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                if (allowNull)
                    return true;

                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return false;

            return true;
        }

        public static bool TelephoneControl(
            string telephone,
            bool allowNull)
        {
            if (string.IsNullOrWhiteSpace(telephone))
            {
                if (allowNull)
                    return true;

                return false;
            }

            if (telephone.Length < 10 ||
                telephone.Length > 15)
                return false;

            foreach (char character in telephone)
            {
                if (!char.IsDigit(character) &&
                    character != '+')
                    return false;
            }

            return true;
        }
    }
}
