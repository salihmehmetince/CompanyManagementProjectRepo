using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALPaymentType
    {
        public List<PaymentType> PaymentTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.PaymentTypes
                    .Include(x => x.CustomerBuysCompanyHasProductOrServices)
                    .ToList();
            }
        }

        public PaymentType PaymentTypeGetById(int paymentTypeId)
        {
            using (var context = new AppDbContext())
            {
                return context.PaymentTypes
                    .Include(x => x.CustomerBuysCompanyHasProductOrServices)
                    .FirstOrDefault(x => x.PaymentTypeId == paymentTypeId);
            }
        }

        public bool PaymentTypeAdd(PaymentType paymentType)
        {
            using (var context = new AppDbContext())
            {
                context.PaymentTypes.Add(paymentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool PaymentTypeUpdate(PaymentType paymentType)
        {
            using (var context = new AppDbContext())
            {
                context.PaymentTypes.Update(paymentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool PaymentTypeDelete(int paymentTypeId)
        {
            using (var context = new AppDbContext())
            {
                var paymentType = context.PaymentTypes
                    .FirstOrDefault(x => x.PaymentTypeId == paymentTypeId);

                if (paymentType == null)
                    return false;

                context.PaymentTypes.Remove(paymentType);

                return context.SaveChanges() > 0;
            }
        }
    }
}