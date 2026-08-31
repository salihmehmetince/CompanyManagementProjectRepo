using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLMeetingHasEmployee
    {
        DALMeetingHasEmployee dalMeetingHasEmployee =
            new DALMeetingHasEmployee();

        DALMeeting dalMeeting =
            new DALMeeting();

        DALEmployee dalEmployee =
            new DALEmployee();

        public List<MeetingHasEmployee>
            MeetingHasEmployeeList()
        {
            return dalMeetingHasEmployee
                .MeetingHasEmployeeList();
        }

        public MeetingHasEmployee
            MeetingHasEmployeeGetById(
                int meetingHasEmployeeId)
        {
            if (!Validation.IntControl(
                meetingHasEmployeeId,
                1,
                int.MaxValue))
                return null;

            return dalMeetingHasEmployee
                .MeetingHasEmployeeGetById(
                    meetingHasEmployeeId);
        }

        public bool MeetingHasEmployeeAdd(
            MeetingHasEmployee meetingHasEmployee)
        {
            if (meetingHasEmployee == null)
                return false;

            if (!Validation.IntControl(
                meetingHasEmployee.MeetingId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                meetingHasEmployee.EmployeeId,
                1,
                int.MaxValue))
                return false;

            var meeting =
                dalMeeting
                    .MeetingGetById(
                        meetingHasEmployee.MeetingId);

            if (meeting == null)
                return false;

            var employee =
                dalEmployee
                    .EmployeeGetById(
                        meetingHasEmployee.EmployeeId);

            if (employee == null)
                return false;

            return dalMeetingHasEmployee
                .MeetingHasEmployeeAdd(
                    meetingHasEmployee);
        }

        public bool MeetingHasEmployeeUpdate(
            MeetingHasEmployee meetingHasEmployee)
        {
            if (meetingHasEmployee == null)
                return false;

            if (!Validation.IntControl(
                meetingHasEmployee.MeetingHasEmployeeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                meetingHasEmployee.MeetingId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                meetingHasEmployee.EmployeeId,
                1,
                int.MaxValue))
                return false;

            var existingMeetingHasEmployee =
                dalMeetingHasEmployee
                    .MeetingHasEmployeeGetById(
                        meetingHasEmployee
                            .MeetingHasEmployeeId);

            if (existingMeetingHasEmployee == null)
                return false;

            var meeting =
                dalMeeting
                    .MeetingGetById(
                        meetingHasEmployee.MeetingId);

            if (meeting == null)
                return false;

            var employee =
                dalEmployee
                    .EmployeeGetById(
                        meetingHasEmployee.EmployeeId);

            if (employee == null)
                return false;

            return dalMeetingHasEmployee
                .MeetingHasEmployeeUpdate(
                    meetingHasEmployee);
        }

        public bool MeetingHasEmployeeDelete(
            int meetingHasEmployeeId)
        {
            if (!Validation.IntControl(
                meetingHasEmployeeId,
                1,
                int.MaxValue))
                return false;

            var existingMeetingHasEmployee =
                dalMeetingHasEmployee
                    .MeetingHasEmployeeGetById(
                        meetingHasEmployeeId);

            if (existingMeetingHasEmployee == null)
                return false;

            return dalMeetingHasEmployee
                .MeetingHasEmployeeDelete(
                    meetingHasEmployeeId);
        }
    }
}
