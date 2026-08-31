using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLProfessionType
    {
        DALProfessionType dalProfessionType =
            new DALProfessionType();

        public List<ProfessionType> ProfessionTypeList()
        {
            return dalProfessionType
                .ProfessionTypeList();
        }

        public ProfessionType ProfessionTypeGetById(
            int professionTypeId)
        {
            if (!Validation.IntControl(
                professionTypeId,
                1,
                int.MaxValue))
                return null;

            return dalProfessionType
                .ProfessionTypeGetById(professionTypeId);
        }

        public bool ProfessionTypeAdd(
            ProfessionType professionType)
        {
            if (professionType == null)
                return false;

            if (!Validation.StringControl(
                professionType.ProfessionName,
                1,
                50))
                return false;

            return dalProfessionType
                .ProfessionTypeAdd(professionType);
        }

        public bool ProfessionTypeUpdate(
            ProfessionType professionType)
        {
            if (professionType == null)
                return false;

            if (!Validation.IntControl(
                professionType.ProfessionTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                professionType.ProfessionName,
                1,
                50))
                return false;

            var existingProfessionType =
                dalProfessionType
                    .ProfessionTypeGetById(
                        professionType.ProfessionTypeId);

            if (existingProfessionType == null)
                return false;

            return dalProfessionType
                .ProfessionTypeUpdate(professionType);
        }

        public bool ProfessionTypeDelete(
            int professionTypeId)
        {
            if (!Validation.IntControl(
                professionTypeId,
                1,
                int.MaxValue))
                return false;

            var existingProfessionType =
                dalProfessionType
                    .ProfessionTypeGetById(professionTypeId);

            if (existingProfessionType == null)
                return false;

            return dalProfessionType
                .ProfessionTypeDelete(professionTypeId);
        }
    }
}
