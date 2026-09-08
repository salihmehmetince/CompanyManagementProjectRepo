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

        public bool MeetingAdd(
            Meeting meeting,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Meetings.Add(meeting);

                    context.SaveChanges();

                    foreach (int companyOwnerId in companyOwnerIds)
                    {
                        context.MeetingHasCompanyOwners.Add(
                            new MeetingHasCompanyOwner
                            {
                                MeetingId = meeting.MeetingId,
                                CompanyOwnerId = companyOwnerId
                            });
                    }

                    foreach (int employeeId in employeeIds)
                    {
                        context.MeetingHasEmployees.Add(
                            new MeetingHasEmployee
                            {
                                MeetingId = meeting.MeetingId,
                                EmployeeId = employeeId
                            });
                    }

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }

        public bool MeetingUpdate(
            Meeting meeting,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingMeeting =
                        context.Meetings
                            .FirstOrDefault(x =>
                                x.MeetingId == meeting.MeetingId);

                    if (existingMeeting == null)
                        return false;

                    existingMeeting.MeetingPlot =
                        meeting.MeetingPlot;

                    existingMeeting.MeetingDetail =
                        meeting.MeetingDetail;

                    existingMeeting.MeetingPlace =
                        meeting.MeetingPlace;

                    existingMeeting.MeetingDate =
                        meeting.MeetingDate;

                    var companyOwnerRelations =
                        context.MeetingHasCompanyOwners
                            .Where(x =>
                                x.MeetingId == meeting.MeetingId)
                            .ToList();

                    if (companyOwnerRelations.Any())
                    {
                        context.MeetingHasCompanyOwners
                            .RemoveRange(companyOwnerRelations);
                    }

                    var employeeRelations =
                        context.MeetingHasEmployees
                            .Where(x =>
                                x.MeetingId == meeting.MeetingId)
                            .ToList();

                    if (employeeRelations.Any())
                    {
                        context.MeetingHasEmployees
                            .RemoveRange(employeeRelations);
                    }

                    foreach (int companyOwnerId in companyOwnerIds)
                    {
                        context.MeetingHasCompanyOwners.Add(
                            new MeetingHasCompanyOwner
                            {
                                MeetingId = meeting.MeetingId,
                                CompanyOwnerId = companyOwnerId
                            });
                    }

                    foreach (int employeeId in employeeIds)
                    {
                        context.MeetingHasEmployees.Add(
                            new MeetingHasEmployee
                            {
                                MeetingId = meeting.MeetingId,
                                EmployeeId = employeeId
                            });
                    }

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }

        public bool MeetingDelete(int meetingId)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var meeting = context.Meetings
                        .FirstOrDefault(x => x.MeetingId == meetingId);

                    if (meeting == null)
                        return false;

                    var companyOwnerRelations =
                        context.MeetingHasCompanyOwners
                            .Where(x => x.MeetingId == meetingId)
                            .ToList();

                    if (companyOwnerRelations.Any())
                    {
                        context.MeetingHasCompanyOwners
                            .RemoveRange(companyOwnerRelations);
                    }

                    var employeeRelations =
                        context.MeetingHasEmployees
                            .Where(x => x.MeetingId == meetingId)
                            .ToList();

                    if (employeeRelations.Any())
                    {
                        context.MeetingHasEmployees
                            .RemoveRange(employeeRelations);
                    }

                    context.Meetings.Remove(meeting);

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
    }
}