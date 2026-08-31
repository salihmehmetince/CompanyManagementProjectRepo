using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLMeetingHasCompanyOwner
    {
        DALMeetingHasCompanyOwner dalMeetingHasCompanyOwner =
            new DALMeetingHasCompanyOwner();

        DALMeeting dalMeeting =
            new DALMeeting();

        DALCompanyOwner dalCompanyOwner =
            new DALCompanyOwner();

        public List<MeetingHasCompanyOwner>
            MeetingHasCompanyOwnerList()
        {
            return dalMeetingHasCompanyOwner
                .MeetingHasCompanyOwnerList();
        }

        public MeetingHasCompanyOwner
            MeetingHasCompanyOwnerGetById(
                int meetingHasCompanyOwnerId)
        {
            if (!Validation.IntControl(
                meetingHasCompanyOwnerId,
                1,
                int.MaxValue))
                return null;

            return dalMeetingHasCompanyOwner
                .MeetingHasCompanyOwnerGetById(
                    meetingHasCompanyOwnerId);
        }

        public bool MeetingHasCompanyOwnerAdd(
            MeetingHasCompanyOwner meetingHasCompanyOwner)
        {
            if (meetingHasCompanyOwner == null)
                return false;

            if (!Validation.IntControl(
                meetingHasCompanyOwner.MeetingId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                meetingHasCompanyOwner.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            var meeting =
                dalMeeting
                    .MeetingGetById(
                        meetingHasCompanyOwner.MeetingId);

            if (meeting == null)
                return false;

            var companyOwner =
                dalCompanyOwner
                    .CompanyOwnerGetById(
                        meetingHasCompanyOwner.CompanyOwnerId);

            if (companyOwner == null)
                return false;

            return dalMeetingHasCompanyOwner
                .MeetingHasCompanyOwnerAdd(
                    meetingHasCompanyOwner);
        }

        public bool MeetingHasCompanyOwnerUpdate(
            MeetingHasCompanyOwner meetingHasCompanyOwner)
        {
            if (meetingHasCompanyOwner == null)
                return false;

            if (!Validation.IntControl(
                meetingHasCompanyOwner.MeetingHasCompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                meetingHasCompanyOwner.MeetingId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                meetingHasCompanyOwner.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            var existingMeetingHasCompanyOwner =
                dalMeetingHasCompanyOwner
                    .MeetingHasCompanyOwnerGetById(
                        meetingHasCompanyOwner
                            .MeetingHasCompanyOwnerId);

            if (existingMeetingHasCompanyOwner == null)
                return false;

            var meeting =
                dalMeeting
                    .MeetingGetById(
                        meetingHasCompanyOwner.MeetingId);

            if (meeting == null)
                return false;

            var companyOwner =
                dalCompanyOwner
                    .CompanyOwnerGetById(
                        meetingHasCompanyOwner.CompanyOwnerId);

            if (companyOwner == null)
                return false;

            return dalMeetingHasCompanyOwner
                .MeetingHasCompanyOwnerUpdate(
                    meetingHasCompanyOwner);
        }

        public bool MeetingHasCompanyOwnerDelete(
            int meetingHasCompanyOwnerId)
        {
            if (!Validation.IntControl(
                meetingHasCompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            var existingMeetingHasCompanyOwner =
                dalMeetingHasCompanyOwner
                    .MeetingHasCompanyOwnerGetById(
                        meetingHasCompanyOwnerId);

            if (existingMeetingHasCompanyOwner == null)
                return false;

            return dalMeetingHasCompanyOwner
                .MeetingHasCompanyOwnerDelete(
                    meetingHasCompanyOwnerId);
        }
    }
}
