using CompanyManagement.BusinessLogic;
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
    public partial class FrmMeetingAddEditForm : Form
    {
        private BLMeeting blMeeting=new BLMeeting();
        private Meeting meeting;
        private BLMeetingHasCompanyOwner blMeetingHasCompanyOwner =new BLMeetingHasCompanyOwner();

        private BLMeetingHasEmployee blMeetingHasEmployee =
            new BLMeetingHasEmployee();

        private BLCompanyOwner blCompanyOwner =
            new BLCompanyOwner();

        private BLEmployee blEmployee =
            new BLEmployee();
        public FrmMeetingAddEditForm(Meeting meeting=null)
        {
            InitializeComponent();
            this.meeting=meeting;
            LoadCompanyOwners();
            LoadEmployees();
            SetButtonsBorder();
            if (meeting != null) 
            {
                LoadMeeting();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadMeeting()
        {
            LblTitle.Text = "Edit Meeting";
            LblDescription.Text = "Update meeting information";

            TxtPlot.Text = meeting.MeetingPlot;
            TxtPlace.Text = meeting.MeetingPlace;
            DTPDate.Value = meeting.MeetingDate;
            RTBDetail.Text = meeting.MeetingDetail;

            var meetingCompanyOwners =
                blMeetingHasCompanyOwner
                    .MeetingHasCompanyOwnerList()
                    .Where(x => x.MeetingId == meeting.MeetingId)
                    .Select(x => x.CompanyOwnerId)
                    .ToList();

            for (int i = 0; i < CLBCompanyOwners.Items.Count; i++)
            {
                dynamic companyOwner = CLBCompanyOwners.Items[i];

                if (meetingCompanyOwners.Contains(
                    (int)companyOwner.CompanyOwnerId))
                {
                    CLBCompanyOwners.SetItemChecked(i, true);
                }
            }

            var meetingEmployees =
                blMeetingHasEmployee
                    .MeetingHasEmployeeList()
                    .Where(x => x.MeetingId == meeting.MeetingId)
                    .Select(x => x.EmployeeId)
                    .ToList();

            for (int i = 0; i < CLBEmployees.Items.Count; i++)
            {
                dynamic employee = CLBEmployees.Items[i];

                if (meetingEmployees.Contains(
                    (int)employee.EmployeeId))
                {
                    CLBEmployees.SetItemChecked(i, true);
                }
            }
        }
        private void LoadCompanyOwners()
        {
            var companyOwners =
                blCompanyOwner
                    .CompanyOwnerList()
                    .Select(x => new
                    {
                        x.CompanyOwnerId,
                        FullName =
                            x.CompanyOwnerName + " " +
                            x.CompanyOwnerSurname
                    })
                    .ToList();

            CLBCompanyOwners.DataSource = companyOwners;

            CLBCompanyOwners.DisplayMember = "FullName";
            CLBCompanyOwners.ValueMember = "CompanyOwnerId";
        }

        private void LoadEmployees()
        {
            var employees =
                blEmployee
                    .EmployeeList()
                    .Select(x => new
                    {
                        x.EmployeeId,
                        FullName =
                            x.EmployeeName + " " +
                            x.EmployeeSurname
                    })
                    .ToList();

            CLBEmployees.DataSource = employees;

            CLBEmployees.DisplayMember = "FullName";
            CLBEmployees.ValueMember = "EmployeeId";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Meeting meetingToSave;

            if (meeting == null)
            {
                meetingToSave = new Meeting();
            }
            else
            {
                meetingToSave = meeting;
            }

            meetingToSave.MeetingPlot =
                TxtPlot.Text.Trim();

            meetingToSave.MeetingPlace =
                TxtPlace.Text.Trim();

            meetingToSave.MeetingDetail =
                string.IsNullOrWhiteSpace(
                    RTBDetail.Text)
                    ? null
                    : RTBDetail.Text.Trim();

            meetingToSave.MeetingDate =
                DTPDate.Value;

            List<int> companyOwnerIds =
                CLBCompanyOwners.CheckedItems
                    .Cast<dynamic>()
                    .Select(x => (int)x.CompanyOwnerId)
                    .ToList();

            List<int> employeeIds =
                CLBEmployees.CheckedItems
                    .Cast<dynamic>()
                    .Select(x => (int)x.EmployeeId)
                    .ToList();

            bool result;

            if (meeting == null)
            {
                result = blMeeting.MeetingAdd(
                    meetingToSave,
                    companyOwnerIds,
                    employeeIds);
            }
            else
            {
                result = blMeeting.MeetingUpdate(
                    meetingToSave,
                    companyOwnerIds,
                    employeeIds);
            }

            if (!result)
            {
                MessageBox.Show(
                    "Meeting could not be saved.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                meeting == null
                    ? "Meeting added successfully."
                    : "Meeting updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
