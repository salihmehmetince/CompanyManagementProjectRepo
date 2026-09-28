using CompanyManagement.BusinessLogic;
using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmMeetingsForm : Form
    {

        private BLMeeting blMeeting = new BLMeeting();

        private User user;
        private List<int> selectedCompanyIds;

        public FrmMeetingsForm(
            User user,
            List<int> selectedCompanyIds)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListMeetings();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

                
        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
        }

        private void ListMeetings()
        {
            List<Meeting> meetings =
                blMeeting
                    .MeetingList()
                    .Where(x =>
                        x.MeetingHasCompanyOwners != null &&
                        x.MeetingHasCompanyOwners.Any(y =>
                            y.CompanyOwner != null &&
                            y.CompanyOwner.CompanyOwnerHasCompanies != null &&
                            y.CompanyOwner.CompanyOwnerHasCompanies.Any(z =>
                                selectedCompanyIds.Contains(
                                    z.CompanyId))))
                    .ToList();

            var meetingList =
                meetings.Select(x => new
                {
                    x.MeetingId,
                    x.MeetingPlot,
                    x.MeetingPlace,
                    x.MeetingDate
                }).ToList();

            DgvMeetings.DataSource =
                meetingList;

            LblRecordCount.Text =
                meetings.Count +
                " meetings";
        }

        private Meeting GetSelectedMeeting()
        {
            if (DgvMeetings.CurrentRow == null)
                return null;

            int meetingId = Convert.ToInt32(
                DgvMeetings.CurrentRow.Cells["MeetingId"].Value
            );

            return blMeeting.MeetingGetById(meetingId);
        }

        private void SearchMeetings()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<Meeting> meetings =
                blMeeting
                    .MeetingList()
                    .Where(x =>
                        x.MeetingHasCompanyOwners != null &&
                        x.MeetingHasCompanyOwners.Any(y =>
                            y.CompanyOwner != null &&
                            y.CompanyOwner.CompanyOwnerHasCompanies != null &&
                            y.CompanyOwner.CompanyOwnerHasCompanies.Any(z =>
                                selectedCompanyIds.Contains(
                                    z.CompanyId))))
                    .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                meetings = meetings
                    .Where(x =>
                        x.MeetingPlot.ToLower().Contains(searchText) ||
                        x.MeetingPlace.ToLower().Contains(searchText) ||
                        (x.MeetingDetail != null &&
                         x.MeetingDetail.ToLower().Contains(searchText)) ||
                        x.MeetingDate
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var meetingList =
                meetings.Select(x => new
                {
                    x.MeetingId,
                    x.MeetingPlot,
                    x.MeetingPlace,
                    x.MeetingDate
                }).ToList();

            DgvMeetings.DataSource =
                meetingList;

            LblRecordCount.Text =
                meetings.Count +
                " meetings";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchMeetings();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
                    FrmMeetingAddEditForm frm =
            new FrmMeetingAddEditForm(
                    user,
                    selectedCompanyIds);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListMeetings();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Meeting meeting = GetSelectedMeeting();

            if (meeting == null)
            {
                MessageBox.Show(
                    "Please select a meeting.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmMeetingAddEditForm frm =
                new FrmMeetingAddEditForm(
                    user,
                    selectedCompanyIds
                    ,meeting);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListMeetings();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Meeting meeting = GetSelectedMeeting();

            if (meeting == null)
            {
                MessageBox.Show(
                    "Please select a meeting.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this meeting?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blMeeting.MeetingDelete(meeting.MeetingId))
            {
                MessageBox.Show(
                    "Meeting could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Meeting deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListMeetings();
        }
    }
}
