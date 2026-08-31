using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALProfessionType
    {
        public List<ProfessionType> ProfessionTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.ProfessionTypes
                    .Include(x => x.Employees)
                    .ToList();
            }
        }

        public ProfessionType ProfessionTypeGetById(int professionTypeId)
        {
            using (var context = new AppDbContext())
            {
                return context.ProfessionTypes
                    .Include(x => x.Employees)
                    .FirstOrDefault(x =>
                        x.ProfessionTypeId == professionTypeId);
            }
        }

        public bool ProfessionTypeAdd(ProfessionType professionType)
        {
            using (var context = new AppDbContext())
            {
                context.ProfessionTypes.Add(professionType);

                return context.SaveChanges() > 0;
            }
        }

        public bool ProfessionTypeUpdate(ProfessionType professionType)
        {
            using (var context = new AppDbContext())
            {
                context.ProfessionTypes.Update(professionType);

                return context.SaveChanges() > 0;
            }
        }

        public bool ProfessionTypeDelete(int professionTypeId)
        {
            using (var context = new AppDbContext())
            {
                var professionType = context.ProfessionTypes
                    .FirstOrDefault(x =>
                        x.ProfessionTypeId == professionTypeId);

                if (professionType == null)
                    return false;

                context.ProfessionTypes.Remove(professionType);

                return context.SaveChanges() > 0;
            }
        }
    }
}