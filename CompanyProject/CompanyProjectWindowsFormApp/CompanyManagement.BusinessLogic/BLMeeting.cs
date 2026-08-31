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
            Meeting meeting)
        {
            if (meeting == null)
                return false;

            if (!Validation.StringControl(
                meeting.MeetingPlot,
                1,
                150))
                return false;

            if (!Validation.StringControl(
                meeting.MeetingDetail,
                0,
                1000))
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

            return dalMeeting
                .MeetingAdd(meeting);
        }

        public bool MeetingUpdate(
            Meeting meeting)
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
                meeting.MeetingDetail,
                0,
                1000))
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

            var existingMeeting =
                dalMeeting
                    .MeetingGetById(meeting.MeetingId);

            if (existingMeeting == null)
                return false;

            return dalMeeting
                .MeetingUpdate(meeting);
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
                    .MeetingGetById(meetingId);

            if (existingMeeting == null)
                return false;

            return dalMeeting
                .MeetingDelete(meetingId);
        }
    }
}
