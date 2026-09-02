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
    public partial class FrmMainForm : Form
    {
        private User user;
        private bool menuVisible = true;
        private bool definitionsCreated = false;
        private bool definitionsVisible = false;
        private Panel PnlDefinitions;

        public FrmMainForm(User user)
        {
            this.user = user;
            InitializeComponent();
            SetUserInformation(user);
            CreateDashBoardButton();
            CreateMenu(user);
            setIcon();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private void SetUserInformation(User user)
        {
            LblUserName.Text = user.Username;
            BLUserRole blUserRole = new BLUserRole();

            UserRole userRole = blUserRole.UserRoleGetById(user.UserRoleId);

            if (userRole != null)
                LblUserRole.Text = userRole.UserRoleName;
        }

        private void CreateDashBoardButton()
        {
            Button btnDashboard = new Button();

            btnDashboard.Name = "BtnDashboard";
            btnDashboard.Text = "Dashboard";
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.Height = 50;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.BackColor = Color.FromArgb(15, 23, 42);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;

            PnlMenu.Controls.Add(btnDashboard);
            btnDashboard.BringToFront();
            btnDashboard.Click += BtnDashboard_Click;
            PnlMenuButtons.BringToFront();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            SetDashBoardVisibility();
        }

        private void SetDashBoardVisibility()
        {
            menuVisible = !menuVisible;
            PnlMenuButtons.Visible = menuVisible;
        }

        private void CreateMenu(User user)
        {
            switch (user.UserRoleId)
            {
                case 1:
                    CreateAdminMenu();
                    break;

                case 2:
                    CreateCompanyOwnerMenu();
                    break;

                case 3:
                    CreateEmployeeMenu();
                    break;
            }
        }

        private void CreateAdminMenu()
        {
            CreateCompaniesButton();
            CreateCompanyOwnersButton();
            CreateEmployeesButton();
            CreateMeetingsButton();
            CreateTasksButton();
            CreateProductsOrServicesButton();
            CreateCustomersButton();
            CreatePaymentsButton();
            CreateUsersButton();
            CreateDefinitionsButton();

        }

        private void CreateCompanyOwnerMenu()
        {

        }

        private void CreateEmployeeMenu()
        {

        }

        private void CreateCompaniesButton()
        {
            Button btnCompanies = new Button();

            btnCompanies.Name = "BtnCompanies";
            btnCompanies.Text = "Companies";
            btnCompanies.Dock = DockStyle.Top;
            btnCompanies.Height = 50;
            btnCompanies.FlatStyle = FlatStyle.Flat;
            btnCompanies.BackColor = Color.FromArgb(15, 23, 42);
            btnCompanies.ForeColor = Color.White;
            btnCompanies.Font = new Font("Segoe UI", 10F);
            btnCompanies.TextAlign = ContentAlignment.MiddleLeft;
            btnCompanies.Padding = new Padding(20, 0, 0, 0);
            btnCompanies.Cursor = Cursors.Hand;
            btnCompanies.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnCompanies);
            btnCompanies.BringToFront();
            btnCompanies.Click += BtnCompanies_Click;
        }

        private void CreateCompanyOwnersButton()
        {
            Button btnCompanyOwners = new Button();

            btnCompanyOwners.Name = "BtnCompanyOwners";
            btnCompanyOwners.Text = "Company Owners";
            btnCompanyOwners.Dock = DockStyle.Top;
            btnCompanyOwners.Height = 50;
            btnCompanyOwners.FlatStyle = FlatStyle.Flat;
            btnCompanyOwners.BackColor = Color.FromArgb(15, 23, 42);
            btnCompanyOwners.ForeColor = Color.White;
            btnCompanyOwners.Font = new Font("Segoe UI", 10F);
            btnCompanyOwners.TextAlign = ContentAlignment.MiddleLeft;
            btnCompanyOwners.Padding = new Padding(20, 0, 0, 0);
            btnCompanyOwners.Cursor = Cursors.Hand;
            btnCompanyOwners.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnCompanyOwners);
            btnCompanyOwners.BringToFront();
            btnCompanyOwners.Click += BtnCompanyOwners_Click;
        }

        private void CreateEmployeesButton()
        {
            Button btnEmployees = new Button();

            btnEmployees.Name = "BtnEmployees";
            btnEmployees.Text = "Employees";
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.Height = 50;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.BackColor = Color.FromArgb(15, 23, 42);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Font = new Font("Segoe UI", 10F);
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.Padding = new Padding(20, 0, 0, 0);
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnEmployees);
            btnEmployees.BringToFront();
            btnEmployees.Click += BtnEmployees_Click;
        }

        private void CreateMeetingsButton()
        {
            Button btnMeetings = new Button();

            btnMeetings.Name = "BtnMeetings";
            btnMeetings.Text = "Meetings";
            btnMeetings.Dock = DockStyle.Top;
            btnMeetings.Height = 50;
            btnMeetings.FlatStyle = FlatStyle.Flat;
            btnMeetings.BackColor = Color.FromArgb(15, 23, 42);
            btnMeetings.ForeColor = Color.White;
            btnMeetings.Font = new Font("Segoe UI", 10F);
            btnMeetings.TextAlign = ContentAlignment.MiddleLeft;
            btnMeetings.Padding = new Padding(20, 0, 0, 0);
            btnMeetings.Cursor = Cursors.Hand;
            btnMeetings.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnMeetings);
            btnMeetings.BringToFront();
            btnMeetings.Click += BtnMeetings_Click;
        }

        private void CreateTasksButton()
        {
            Button btnTasks = new Button();

            btnTasks.Name = "BtnTasks";
            btnTasks.Text = "Tasks";
            btnTasks.Dock = DockStyle.Top;
            btnTasks.Height = 50;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.BackColor = Color.FromArgb(15, 23, 42);
            btnTasks.ForeColor = Color.White;
            btnTasks.Font = new Font("Segoe UI", 10F);
            btnTasks.TextAlign = ContentAlignment.MiddleLeft;
            btnTasks.Padding = new Padding(20, 0, 0, 0);
            btnTasks.Cursor = Cursors.Hand;
            btnTasks.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnTasks);
            btnTasks.BringToFront();
            btnTasks.Click += BtnTasks_Click;
        }
        private void CreateProductsOrServicesButton()
        {
            Button btnProductsOrServices = new Button();

            btnProductsOrServices.Name = "BtnProductsOrServices";
            btnProductsOrServices.Text = "Products / Services";
            btnProductsOrServices.Dock = DockStyle.Top;
            btnProductsOrServices.Height = 50;
            btnProductsOrServices.FlatStyle = FlatStyle.Flat;
            btnProductsOrServices.BackColor = Color.FromArgb(15, 23, 42);
            btnProductsOrServices.ForeColor = Color.White;
            btnProductsOrServices.Font = new Font("Segoe UI", 10F);
            btnProductsOrServices.TextAlign = ContentAlignment.MiddleLeft;
            btnProductsOrServices.Padding = new Padding(20, 0, 0, 0);
            btnProductsOrServices.Cursor = Cursors.Hand;
            btnProductsOrServices.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnProductsOrServices);
            btnProductsOrServices.BringToFront();
            btnProductsOrServices.Click += BtnProductsOrServices_Click;
        }

        private void CreateCustomersButton()
        {
            Button btnCustomers = new Button();

            btnCustomers.Name = "BtnCustomers";
            btnCustomers.Text = "Customers";
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.Height = 50;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.BackColor = Color.FromArgb(15, 23, 42);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Font = new Font("Segoe UI", 10F);
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Padding = new Padding(20, 0, 0, 0);
            btnCustomers.Cursor = Cursors.Hand;
            btnCustomers.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnCustomers);
            btnCustomers.BringToFront();
            btnCustomers.Click += BtnCustomers_Click;
        }

        private void CreatePaymentsButton()
        {
            Button btnPayments = new Button();

            btnPayments.Name = "BtnPayments";
            btnPayments.Text = "Payments";
            btnPayments.Dock = DockStyle.Top;
            btnPayments.Height = 50;
            btnPayments.FlatStyle = FlatStyle.Flat;
            btnPayments.BackColor = Color.FromArgb(15, 23, 42);
            btnPayments.ForeColor = Color.White;
            btnPayments.Font = new Font("Segoe UI", 10F);
            btnPayments.TextAlign = ContentAlignment.MiddleLeft;
            btnPayments.Padding = new Padding(20, 0, 0, 0);
            btnPayments.Cursor = Cursors.Hand;
            btnPayments.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnPayments);
            btnPayments.BringToFront();
            btnPayments.Click += BtnPayments_Click;
        }

        private void CreateUsersButton()
        {
            Button btnUsers = new Button();

            btnUsers.Name = "BtnUsers";
            btnUsers.Text = "Users";
            btnUsers.Dock = DockStyle.Top;
            btnUsers.Height = 50;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.BackColor = Color.FromArgb(15, 23, 42);
            btnUsers.ForeColor = Color.White;
            btnUsers.Font = new Font("Segoe UI", 10F);
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.Padding = new Padding(20, 0, 0, 0);
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnUsers);
            btnUsers.BringToFront();
            btnUsers.Click += BtnUsers_Click;
        }

        private void CreateDefinitionsButton()
        {
            Button btnDefinitions = new Button();

            btnDefinitions.Name = "BtnDefinitions";
            btnDefinitions.Text = "Definitions";
            btnDefinitions.Dock = DockStyle.Top;
            btnDefinitions.Height = 50;
            btnDefinitions.FlatStyle = FlatStyle.Flat;
            btnDefinitions.BackColor = Color.FromArgb(15, 23, 42);
            btnDefinitions.ForeColor = Color.White;
            btnDefinitions.Font = new Font("Segoe UI", 10F);
            btnDefinitions.TextAlign = ContentAlignment.MiddleLeft;
            btnDefinitions.Padding = new Padding(20, 0, 0, 0);
            btnDefinitions.Cursor = Cursors.Hand;
            btnDefinitions.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnDefinitions);
            btnDefinitions.BringToFront();
            btnDefinitions.Click += BtnDefinitions_Click;
            CreateDefinitionsPanel();
        }

        private void CreateDefinitionsPanel()
        {
            PnlDefinitions = new Panel();

            PnlDefinitions.Name = "PnlDefinitions";
            PnlDefinitions.Dock = DockStyle.Top;
            PnlDefinitions.AutoSize = true;
            PnlDefinitions.BackColor = Color.FromArgb(30, 41, 59);
            PnlDefinitions.Visible = false;

            PnlMenuButtons.Controls.Add(PnlDefinitions);
            PnlDefinitions.BringToFront();
        }
        private void BtnCompanies_Click(object sender, EventArgs e)
        {
            FrmCompaniesForm frmCompanies = new FrmCompaniesForm();
            frmCompanies.ShowDialog();
        }

        private void BtnCompanyOwners_Click(object sender, EventArgs e)
        {

        }
        private void BtnEmployees_Click(object sender, EventArgs e)
        {

        }

        private void BtnMeetings_Click(object sender, EventArgs e)
        {

        }

        private void BtnTasks_Click(object sender, EventArgs e)
        {

        }

        private void BtnProductsOrServices_Click(object sender, EventArgs e)
        {

        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {

        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {

        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {

        }

        private void BtnDefinitions_Click(object sender, EventArgs e)
        {
    if (!definitionsCreated)
    {

        CreateCompanyTypesButton();
        CreateDepartmentTypesButton();
        CreateProfessionTypesButton();
        CreateProductOrServiceTypesButton();
        CreatePaymentTypesButton();

        definitionsCreated = true;
        definitionsVisible = true;

        PnlDefinitions.Visible = true;
    }
    else
    {
        definitionsVisible = !definitionsVisible;
        PnlDefinitions.Visible = definitionsVisible;
    }

        }

        private void CreateCompanyTypesButton()
        {
            Button btnCompanyTypes = new Button();

            btnCompanyTypes.Name = "BtnCompanyTypes";
            btnCompanyTypes.Text = "Company Types";
            btnCompanyTypes.Dock = DockStyle.Top;
            btnCompanyTypes.Height = 45;
            btnCompanyTypes.FlatStyle = FlatStyle.Flat;
            btnCompanyTypes.BackColor = Color.FromArgb(30, 41, 59);
            btnCompanyTypes.ForeColor = Color.White;
            btnCompanyTypes.Font = new Font("Segoe UI", 9F);
            btnCompanyTypes.TextAlign = ContentAlignment.MiddleLeft;
            btnCompanyTypes.Padding = new Padding(35, 0, 0, 0);
            btnCompanyTypes.Cursor = Cursors.Hand;
            btnCompanyTypes.FlatAppearance.BorderSize = 0;

            PnlDefinitions.Controls.Add(btnCompanyTypes);
            btnCompanyTypes.BringToFront();
            btnCompanyTypes.Click += BtnCompanyTypes_Click;
        }

        private void CreateDepartmentTypesButton()
        {
            Button btnDepartmentTypes = new Button();

            btnDepartmentTypes.Name = "BtnDepartmentTypes";
            btnDepartmentTypes.Text = "Department Types";
            btnDepartmentTypes.Dock = DockStyle.Top;
            btnDepartmentTypes.Height = 45;
            btnDepartmentTypes.FlatStyle = FlatStyle.Flat;
            btnDepartmentTypes.BackColor = Color.FromArgb(30, 41, 59);
            btnDepartmentTypes.ForeColor = Color.White;
            btnDepartmentTypes.Font = new Font("Segoe UI", 9F);
            btnDepartmentTypes.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartmentTypes.Padding = new Padding(40, 0, 0, 0);
            btnDepartmentTypes.Cursor = Cursors.Hand;
            btnDepartmentTypes.FlatAppearance.BorderSize = 0;

            PnlDefinitions.Controls.Add(btnDepartmentTypes);
            btnDepartmentTypes.BringToFront();
            btnDepartmentTypes.Click += BtnDepartmentTypes_Click;
        }

        private void CreateProfessionTypesButton()
        {
            Button btnProfessionTypes = new Button();

            btnProfessionTypes.Name = "BtnProfessionTypes";
            btnProfessionTypes.Text = "Profession Types";
            btnProfessionTypes.Dock = DockStyle.Top;
            btnProfessionTypes.Height = 45;
            btnProfessionTypes.FlatStyle = FlatStyle.Flat;
            btnProfessionTypes.BackColor = Color.FromArgb(30, 41, 59);
            btnProfessionTypes.ForeColor = Color.White;
            btnProfessionTypes.Font = new Font("Segoe UI", 9F);
            btnProfessionTypes.TextAlign = ContentAlignment.MiddleLeft;
            btnProfessionTypes.Padding = new Padding(40, 0, 0, 0);
            btnProfessionTypes.Cursor = Cursors.Hand;
            btnProfessionTypes.FlatAppearance.BorderSize = 0;

            PnlDefinitions.Controls.Add(btnProfessionTypes);
            btnProfessionTypes.BringToFront();
            btnProfessionTypes.Click += BtnProfessionTypes_Click;
        }

        private void CreateProductOrServiceTypesButton()
        {
            Button btnProductOrServiceTypes = new Button();

            btnProductOrServiceTypes.Name = "BtnProductOrServiceTypes";
            btnProductOrServiceTypes.Text = "Product / Service Types";
            btnProductOrServiceTypes.Dock = DockStyle.Top;
            btnProductOrServiceTypes.Height = 45;
            btnProductOrServiceTypes.FlatStyle = FlatStyle.Flat;
            btnProductOrServiceTypes.BackColor = Color.FromArgb(30, 41, 59);
            btnProductOrServiceTypes.ForeColor = Color.White;
            btnProductOrServiceTypes.Font = new Font("Segoe UI", 9F);
            btnProductOrServiceTypes.TextAlign = ContentAlignment.MiddleLeft;
            btnProductOrServiceTypes.Padding = new Padding(40, 0, 0, 0);
            btnProductOrServiceTypes.Cursor = Cursors.Hand;
            btnProductOrServiceTypes.FlatAppearance.BorderSize = 0;

            PnlDefinitions.Controls.Add(btnProductOrServiceTypes);
            btnProductOrServiceTypes.BringToFront();
            btnProductOrServiceTypes.Click += BtnProductOrServiceTypes_Click;
        }

        private void CreatePaymentTypesButton()
        {
            Button btnPaymentTypes = new Button();

            btnPaymentTypes.Name = "BtnPaymentTypes";
            btnPaymentTypes.Text = "Payment Types";
            btnPaymentTypes.Dock = DockStyle.Top;
            btnPaymentTypes.Height = 45;
            btnPaymentTypes.FlatStyle = FlatStyle.Flat;
            btnPaymentTypes.BackColor = Color.FromArgb(30, 41, 59);
            btnPaymentTypes.ForeColor = Color.White;
            btnPaymentTypes.Font = new Font("Segoe UI", 9F);
            btnPaymentTypes.TextAlign = ContentAlignment.MiddleLeft;
            btnPaymentTypes.Padding = new Padding(40, 0, 0, 0);
            btnPaymentTypes.Cursor = Cursors.Hand;
            btnPaymentTypes.FlatAppearance.BorderSize = 0;

            PnlDefinitions.Controls.Add(btnPaymentTypes);
            btnPaymentTypes.BringToFront();
            btnPaymentTypes.BringToFront();

            btnPaymentTypes.Click += BtnPaymentTypes_Click;
        }
        private void BtnCompanyTypes_Click(object sender, EventArgs e)
        {

        }

        private void BtnDepartmentTypes_Click(object sender, EventArgs e)
        {

        }

        private void BtnProfessionTypes_Click(object sender, EventArgs e)
        {

        }

        private void BtnProductOrServiceTypes_Click(object sender, EventArgs e)
        {

        }

        private void BtnPaymentTypes_Click(object sender, EventArgs e)
        {

        }
    }


}
