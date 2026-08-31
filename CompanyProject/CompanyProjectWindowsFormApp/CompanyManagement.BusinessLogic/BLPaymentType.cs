using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLPaymentType
    {
        DALPaymentType dalPaymentType =
            new DALPaymentType();

        public List<PaymentType> PaymentTypeList()
        {
            return dalPaymentType.PaymentTypeList();
        }

        public PaymentType PaymentTypeGetById(
            int paymentTypeId)
        {
            if (!Validation.IntControl(
                paymentTypeId,
                1,
                int.MaxValue))
                return null;

            return dalPaymentType
                .PaymentTypeGetById(paymentTypeId);
        }

        public bool PaymentTypeAdd(
            PaymentType paymentType)
        {
            if (paymentType == null)
                return false;

            if (!Validation.StringControl(
                paymentType.PaymentTypeName,
                1,
                50))
                return false;

            return dalPaymentType
                .PaymentTypeAdd(paymentType);
        }

        public bool PaymentTypeUpdate(
            PaymentType paymentType)
        {
            if (paymentType == null)
                return false;

            if (!Validation.IntControl(
                paymentType.PaymentTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                paymentType.PaymentTypeName,
                1,
                50))
                return false;

            var existingPaymentType =
                dalPaymentType
                    .PaymentTypeGetById(
                        paymentType.PaymentTypeId);

            if (existingPaymentType == null)
                return false;

            return dalPaymentType
                .PaymentTypeUpdate(paymentType);
        }

        public bool PaymentTypeDelete(
            int paymentTypeId)
        {
            if (!Validation.IntControl(
                paymentTypeId,
                1,
                int.MaxValue))
                return false;

            var existingPaymentType =
                dalPaymentType
                    .PaymentTypeGetById(paymentTypeId);

            if (existingPaymentType == null)
                return false;

            return dalPaymentType
                .PaymentTypeDelete(paymentTypeId);
        }
    }
}
