using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALMeeting
    {
        public List<Meeting> MeetingList()
        {
            using (var context = new AppDbContext())
            {
                return context.Meetings
                    .Include(x => x.MeetingHasCompanyOwners)
                    .Include(x => x.MeetingHasEmployees)
                    .ToList();
            }
        }

        public Meeting MeetingGetById(int meetingId)
        {
            using (var context = new AppDbContext())
            {
                return context.Meetings
                    .Include(x => x.MeetingHasCompanyOwners)
                    .Include(x => x.MeetingHasEmployees)
                    .FirstOrDefault(x => x.MeetingId == meetingId);
            }
        }

        public bool MeetingAdd(Meeting meeting)
        {
            using (var context = new AppDbContext())
            {
                context.Meetings.Add(meeting);

                return context.SaveChanges() > 0;
            }
        }

        public bool MeetingUpdate(Meeting meeting)
        {
            using (var context = new AppDbContext())
            {
                context.Meetings.Update(meeting);

                return context.SaveChanges() > 0;
            }
        }

        public bool MeetingDelete(int meetingId)
        {
            using (var context = new AppDbContext())
            {
                var meeting = context.Meetings
                    .FirstOrDefault(x => x.MeetingId == meetingId);

                if (meeting == null)
                    return false;

                context.Meetings.Remove(meeting);

                return context.SaveChanges() > 0;
            }
        }
    }
}