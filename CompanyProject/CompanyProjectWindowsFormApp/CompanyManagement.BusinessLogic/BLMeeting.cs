using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLMeeting
    {
        DALMeeting dalMeeting =
            new DALMeeting();

        BLCompanyOwner blCompanyOwner =
            new BLCompanyOwner();

        BLEmployee blEmployee =
            new BLEmployee();

        public List<Meeting> MeetingList()
        {
            return dalMeeting.MeetingList();
        }

        public Meeting MeetingGetById(
            int meetingId)
        {
            if (!Validation.IntControl(
                meetingId,
                1,
                int.MaxValue))
                return null;

            return dalMeeting
                .MeetingGetById(meetingId);
        }

        public bool MeetingAdd(
            Meeting meeting,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            if (meeting == null)
                return false;

            if (!Validation.StringControl(
                meeting.MeetingPlot,
                1,
                150))
                return false;

            if (!Validation.StringControl(
                meeting.MeetingPlace,
                1,
                200))
                return false;

            if (!Validation.DateTimeControl(
                meeting.MeetingDate,
                false))
                return false;

            if (companyOwnerIds == null)
                companyOwnerIds = new List<int>();

            if (employeeIds == null)
                employeeIds = new List<int>();

            companyOwnerIds =
                companyOwnerIds
                    .Distinct()
                    .ToList();

            employeeIds =
                employeeIds
                    .Distinct()
                    .ToList();

            if (companyOwnerIds.Count + employeeIds.Count < 2)
                return false;

            foreach (int companyOwnerId in companyOwnerIds)
            {
                if (!Validation.IntControl(
                    companyOwnerId,
                    1,
                    int.MaxValue))
                    return false;

                if (blCompanyOwner
                        .CompanyOwnerGetById(
                            companyOwnerId) == null)
                    return false;
            }

            foreach (int employeeId in employeeIds)
            {
                if (!Validation.IntControl(
                    employeeId,
                    1,
                    int.MaxValue))
                    return false;

                if (blEmployee
                        .EmployeeGetById(
                            employeeId) == null)
                    return false;
            }

            return dalMeeting.MeetingAdd(
                meeting,
                companyOwnerIds,
                employeeIds);
        }

        public bool MeetingUpdate(
            Meeting meeting,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            if (meeting == null)
                return false;

            if (!Validation.IntControl(
                meeting.MeetingId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                meeting.MeetingPlot,
                1,
                150))
                return false;

            if (!Validation.StringControl(
                meeting.MeetingPlace,
                1,
                200))
                return false;

            if (!Validation.DateTimeControl(
                meeting.MeetingDate,
                false))
                return false;

            if (companyOwnerIds == null)
                companyOwnerIds = new List<int>();

            if (employeeIds == null)
                employeeIds = new List<int>();

            companyOwnerIds =
                companyOwnerIds
                    .Distinct()
                    .ToList();

            employeeIds =
                employeeIds
                    .Distinct()
                    .ToList();
            if (companyOwnerIds.Count + employeeIds.Count < 2)
                return false;

            foreach (int companyOwnerId in companyOwnerIds)
            {
                if (!Validation.IntControl(
                    companyOwnerId,
                    1,
                    int.MaxValue))
                    return false;

                if (blCompanyOwner
                        .CompanyOwnerGetById(
                            companyOwnerId) == null)
                    return false;
            }

            foreach (int employeeId in employeeIds)
            {
                if (!Validation.IntControl(
                    employeeId,
                    1,
                    int.MaxValue))
                    return false;

                if (blEmployee
                        .EmployeeGetById(
                            employeeId) == null)
                    return false;
            }

            var existingMeeting =
                dalMeeting
                    .MeetingGetById(
                        meeting.MeetingId);

            if (existingMeeting == null)
                return false;

            return dalMeeting.MeetingUpdate(
                meeting,
                companyOwnerIds,
                employeeIds);
        }

        public bool MeetingDelete(
            int meetingId)
        {
            if (!Validation.IntControl(
                meetingId,
                1,
                int.MaxValue))
                return false;

            var existingMeeting =
                dalMeeting
                    .MeetingGetById(
                        meetingId);

            if (existingMeeting == null)
                return false;

            return dalMeeting
                .MeetingDelete(meetingId);
        }
    }
}