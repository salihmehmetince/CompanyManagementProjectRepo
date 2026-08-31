using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALMeetingHasEmployee
    {
        public List<MeetingHasEmployee> MeetingHasEmployeeList()
        {
            using (var context = new AppDbContext())
            {
                return context.MeetingHasEmployees
                    .Include(x => x.Meeting)
                    .Include(x => x.Employee)
                    .ToList();
            }
        }

        public MeetingHasEmployee MeetingHasEmployeeGetById(
            int meetingHasEmployeeId)
        {
            using (var context = new AppDbContext())
            {
                return context.MeetingHasEmployees
                    .Include(x => x.Meeting)
                    .Include(x => x.Employee)
                    .FirstOrDefault(x =>
                        x.MeetingHasEmployeeId == meetingHasEmployeeId);
            }
        }

        public bool MeetingHasEmployeeAdd(
            MeetingHasEmployee meetingHasEmployee)
        {
            using (var context = new AppDbContext())
            {
                context.MeetingHasEmployees.Add(meetingHasEmployee);

                return context.SaveChanges() > 0;
            }
        }

        public bool MeetingHasEmployeeUpdate(
            MeetingHasEmployee meetingHasEmployee)
        {
            using (var context = new AppDbContext())
            {
                context.MeetingHasEmployees.Update(meetingHasEmployee);

                return context.SaveChanges() > 0;
            }
        }

        public bool MeetingHasEmployeeDelete(int meetingHasEmployeeId)
        {
            using (var context = new AppDbContext())
            {
                var meetingHasEmployee =
                    context.MeetingHasEmployees
                        .FirstOrDefault(x =>
                            x.MeetingHasEmployeeId == meetingHasEmployeeId);

                if (meetingHasEmployee == null)
                    return false;

                context.MeetingHasEmployees.Remove(meetingHasEmployee);

                return context.SaveChanges() > 0;
            }
        }
    }
}