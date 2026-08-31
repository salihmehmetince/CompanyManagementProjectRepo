using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALMeetingHasCompanyOwner
    {
        public List<MeetingHasCompanyOwner> MeetingHasCompanyOwnerList()
        {
            using (var context = new AppDbContext())
            {
                return context.MeetingHasCompanyOwners
                    .Include(x => x.Meeting)
                    .Include(x => x.CompanyOwner)
                    .ToList();
            }
        }

        public MeetingHasCompanyOwner MeetingHasCompanyOwnerGetById(
            int meetingHasCompanyOwnerId)
        {
            using (var context = new AppDbContext())
            {
                return context.MeetingHasCompanyOwners
                    .Include(x => x.Meeting)
                    .Include(x => x.CompanyOwner)
                    .FirstOrDefault(x =>
                        x.MeetingHasCompanyOwnerId == meetingHasCompanyOwnerId);
            }
        }

        public bool MeetingHasCompanyOwnerAdd(
            MeetingHasCompanyOwner meetingHasCompanyOwner)
        {
            using (var context = new AppDbContext())
            {
                context.MeetingHasCompanyOwners.Add(meetingHasCompanyOwner);

                return context.SaveChanges() > 0;
            }
        }

        public bool MeetingHasCompanyOwnerUpdate(
            MeetingHasCompanyOwner meetingHasCompanyOwner)
        {
            using (var context = new AppDbContext())
            {
                context.MeetingHasCompanyOwners.Update(meetingHasCompanyOwner);

                return context.SaveChanges() > 0;
            }
        }

        public bool MeetingHasCompanyOwnerDelete(
            int meetingHasCompanyOwnerId)
        {
            using (var context = new AppDbContext())
            {
                var meetingHasCompanyOwner =
                    context.MeetingHasCompanyOwners
                        .FirstOrDefault(x =>
                            x.MeetingHasCompanyOwnerId ==
                            meetingHasCompanyOwnerId);

                if (meetingHasCompanyOwner == null)
                    return false;

                context.MeetingHasCompanyOwners.Remove(meetingHasCompanyOwner);

                return context.SaveChanges() > 0;
            }
        }
    }
}