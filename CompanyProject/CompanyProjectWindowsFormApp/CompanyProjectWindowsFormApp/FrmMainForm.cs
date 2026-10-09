using CompanyManagement.BusinessLogic;
using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using CompanyProjectWindowsFormApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmMainForm : Form
    {
        private User user;
        private List<int> selectedCompanyIds;
        private bool menuVisible = true;
        private bool definitionsCreated = false;
        private bool definitionsVisible = false;
        private Panel PnlDefinitions;
        private bool isClosing = false;


        private BLCompany blCompany = new BLCompany();
        private BLEmployee blEmployee = new BLEmployee();
        private BLCustomer blCustomer = new BLCustomer();
        private BLProductOrService blProductOrService =
            new BLProductOrService();

        private BLCustomerBuysCompanyHasProductOrService
            blCustomerBuysCompanyHasProductOrService =
            new BLCustomerBuysCompanyHasProductOrService();

        private BLEmployeeHasCompanyHasDepartmentType blEmployeeHasCompanyHasDepartmentType = new BLEmployeeHasCompanyHasDepartmentType();

        BLCompanyHasProductOrService blCompanyHasProductOrService =
    new BLCompanyHasProductOrService();

        private BLTask blTask = new BLTask();
        private BLMeeting blMeeting = new BLMeeting();
        public FrmMainForm(User user, List<int> selectedCompanyIds)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

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
            CreateCompanyDeparmentsButton();
            CreateEmployeesButton();
            CreateEmployeeBonusButton();
            CreateMeetingsButton();
            CreateTasksButton();
            CreateProductsOrServicesButton();
            CreateCustomersButton();
            CreateCompanyInventorysButton();
            CreatePaymentsButton();
            CreateUsersButton();
            CreateDefinitionsButton();
            CreateAdminDashboard();
        }

        private void CreateCompanyOwnerMenu()
        {
            CreateCompaniesButton();
            CreateCompanyDeparmentsButton();
            CreateEmployeesButton();
            CreateEmployeeBonusButton();
            CreateMeetingsButton();
            CreateTasksButton();
            CreateProductsOrServicesButton();
            CreateCustomersButton();
            CreateCompanyInventorysButton();
            CreatePaymentsButton();
            CreateCompanyOwnerDashboard();
        }

        private void CreateEmployeeMenu()
        {
            CreateMeetingsButton();
            CreateTasksButton();
            CreateProductsOrServicesButton();
            CreateCustomersButton();
            CreateCompanyInventorysButton();
            CreatePaymentsButton();
            CreateEmployeeDashboard();
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
        private void CreateCompanyDeparmentsButton()
        {
            Button btnCompanyDepartments = new Button();

            btnCompanyDepartments.Name = "BtnCompanyDepartments";
            btnCompanyDepartments.Text = "Company Departments";
            btnCompanyDepartments.Dock = DockStyle.Top;
            btnCompanyDepartments.Height = 50;
            btnCompanyDepartments.FlatStyle = FlatStyle.Flat;
            btnCompanyDepartments.BackColor = Color.FromArgb(15, 23, 42);
            btnCompanyDepartments.ForeColor = Color.White;
            btnCompanyDepartments.Font = new Font("Segoe UI", 10F);
            btnCompanyDepartments.TextAlign = ContentAlignment.MiddleLeft;
            btnCompanyDepartments.Padding = new Padding(20, 0, 0, 0);
            btnCompanyDepartments.Cursor = Cursors.Hand;
            btnCompanyDepartments.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnCompanyDepartments);
            btnCompanyDepartments.BringToFront();
            btnCompanyDepartments.Click += BtnCompanyDepartments_Click;
        }

        private void CreateEmployeeBonusButton()
        {
            Button btnEmployeeBonuses = new Button();

            btnEmployeeBonuses.Name = "btnEmployeeBonuses";
            btnEmployeeBonuses.Text = "Employee Bonuses";
            btnEmployeeBonuses.Dock = DockStyle.Top;
            btnEmployeeBonuses.Height = 50;
            btnEmployeeBonuses.FlatStyle = FlatStyle.Flat;
            btnEmployeeBonuses.BackColor = Color.FromArgb(15, 23, 42);
            btnEmployeeBonuses.ForeColor = Color.White;
            btnEmployeeBonuses.Font = new Font("Segoe UI", 10F);
            btnEmployeeBonuses.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployeeBonuses.Padding = new Padding(20, 0, 0, 0);
            btnEmployeeBonuses.Cursor = Cursors.Hand;
            btnEmployeeBonuses.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnEmployeeBonuses);
            btnEmployeeBonuses.BringToFront();
            btnEmployeeBonuses.Click += btnEmployeeBonuses_Click;
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

        private void CreateCompanyInventorysButton()
        {
            Button btnCompanyInventory = new Button();

            btnCompanyInventory.Name = "BtnCompanyInventory";
            btnCompanyInventory.Text = "Inventory";
            btnCompanyInventory.Dock = DockStyle.Top;
            btnCompanyInventory.Height = 50;
            btnCompanyInventory.FlatStyle = FlatStyle.Flat;
            btnCompanyInventory.BackColor = Color.FromArgb(15, 23, 42);
            btnCompanyInventory.ForeColor = Color.White;
            btnCompanyInventory.Font = new Font("Segoe UI", 10F);
            btnCompanyInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnCompanyInventory.Padding = new Padding(20, 0, 0, 0);
            btnCompanyInventory.Cursor = Cursors.Hand;
            btnCompanyInventory.FlatAppearance.BorderSize = 0;

            PnlMenuButtons.Controls.Add(btnCompanyInventory);
            btnCompanyInventory.BringToFront();
            btnCompanyInventory.Click += BtnCompanyInventories_Click;
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
            FrmCompanyOwnersForm frmCompanyOwnersForm = new FrmCompanyOwnersForm();
            frmCompanyOwnersForm.ShowDialog();
        }
        private void BtnCompanyDepartments_Click(object sender, EventArgs e)
        {
            FrmCompanyDepartmentsForm frmCompanyDepartmentsForm =
                new FrmCompanyDepartmentsForm(
                    user,
                    selectedCompanyIds);

            frmCompanyDepartmentsForm.ShowDialog();
        }
        private void btnEmployeeBonuses_Click(object sender, EventArgs e)
        {
            FrmEmployeeBonusesForm frmEmployeeBonusesForm = new FrmEmployeeBonusesForm(
                    user,
                    selectedCompanyIds);
            frmEmployeeBonusesForm.ShowDialog();
        }
        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            FrmEmployeesForm frmEmployeesForm = new FrmEmployeesForm(
                    user,
                    selectedCompanyIds);
            frmEmployeesForm.ShowDialog();
        }

        private void BtnMeetings_Click(object sender, EventArgs e)
        {
            FrmMeetingsForm frmMeetingsForm = new FrmMeetingsForm(
                    user,
                    selectedCompanyIds);
            frmMeetingsForm.ShowDialog();
        }

        private void BtnTasks_Click(object sender, EventArgs e)
        {
            FrmTaskForm frmTaskForm = new FrmTaskForm(
                    user,
                    selectedCompanyIds);
            frmTaskForm.ShowDialog();
        }

        private void BtnProductsOrServices_Click(object sender, EventArgs e)
        {
            FrmProductOrServiceForm frmProductOrServiceForm = new FrmProductOrServiceForm();
            frmProductOrServiceForm.ShowDialog();
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomerForm frmCustomerForm = new FrmCustomerForm(
                    user,
                    selectedCompanyIds);
            frmCustomerForm.ShowDialog();
        }

        private void BtnCompanyInventories_Click(object sender, EventArgs e)
        {
            FrmCompanyInventoryForm frmCompanyInventoryForm = new FrmCompanyInventoryForm(
                    user,
                    selectedCompanyIds);
            frmCompanyInventoryForm.ShowDialog();
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            FrmPaymentForm frmPaymentForm = new FrmPaymentForm(
                    user,
                    selectedCompanyIds);
            frmPaymentForm.ShowDialog();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            FrmUserForm frmUserForm = new FrmUserForm();
            frmUserForm.ShowDialog();
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
            FrmCompanyTypesForm form = new FrmCompanyTypesForm();
            form.ShowDialog();
        }

        private void BtnDepartmentTypes_Click(object sender, EventArgs e)
        {
            FrmDepartmentTypesForm form = new FrmDepartmentTypesForm();
            form.ShowDialog();
        }

        private void BtnProfessionTypes_Click(object sender, EventArgs e)
        {
            FrmProfessionTypesForm form = new FrmProfessionTypesForm();
            form.ShowDialog();
        }

        private void BtnProductOrServiceTypes_Click(object sender, EventArgs e)
        {
            FrmProductOrServiceTypeForm form = new FrmProductOrServiceTypeForm();
            form.ShowDialog();
        }

        private void BtnPaymentTypes_Click(object sender, EventArgs e)
        {
            FrmPaymentTypeForm frmPaymentTypeForm = new FrmPaymentTypeForm();
            frmPaymentTypeForm.ShowDialog();
        }

        private void FrmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing)
                return;

            if (MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isClosing = true;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void CreateAdminDashboard()
        {
            //six flpgauges
            PnlContent.Controls.Clear();

            PnlContent.BackColor =
                Color.FromArgb(15, 23, 42);

            Panel pnlDashboardHeader =
                new Panel();

            pnlDashboardHeader.Dock =
                DockStyle.Top;

            pnlDashboardHeader.Height =
                80;

            pnlDashboardHeader.BackColor =
                Color.FromArgb(15, 23, 42);

            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Dashboard";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(30, 15);

            pnlDashboardHeader.Controls.Add(
                lblTitle);

            Label lblDescription =
                new Label();

            lblDescription.Text =
                "Company management overview";

            lblDescription.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Regular);

            lblDescription.ForeColor =
                Color.FromArgb(148, 163, 184);

            lblDescription.AutoSize =
                true;

            lblDescription.Location =
                new Point(32, 50);

            pnlDashboardHeader.Controls.Add(
                lblDescription);

            PnlContent.Controls.Add(
                pnlDashboardHeader);


            FlowLayoutPanel flpGauges =
                new FlowLayoutPanel();

            flpGauges.Dock =
                DockStyle.Top;

            flpGauges.Height =
                360;

            flpGauges.Padding =
                new Padding(25, 10, 25, 10);

            flpGauges.BackColor =
                Color.FromArgb(15, 23, 42);

            flpGauges.WrapContents =
                true;

            flpGauges.AutoScroll =
                false;

            flpGauges.FlowDirection =
                FlowDirection.LeftToRight;


            int companyCount = blCompany
    .CompanyList()
    .Count(x => selectedCompanyIds.Contains(x.CompanyId));

            List<EmployeeHasCompanyHasDepartmentType>
    employeeCompanyDepartments =
    blEmployeeHasCompanyHasDepartmentType
        .EmployeeHasCompanyHasDepartmentTypeList();

            int employeeCount = employeeCompanyDepartments
                .Count(x =>
                    x.CompanyHasDepartmentType != null &&
                    x.CompanyHasDepartmentType.Company != null &&
                    selectedCompanyIds.Contains(
                        x.CompanyHasDepartmentType.CompanyId));

            int customerCount =
                blCustomer
                    .CustomerList()
                    .Count(x =>
                        x.CompanyHasCustomers.Any(y =>
                            selectedCompanyIds.Contains(
                                y.CompanyId)));

            int productOrServiceCount =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceList()
                    .Count(x =>
                        selectedCompanyIds.Contains(x.CompanyId));

            List<CustomerBuysCompanyHasProductOrService> payments =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceList()
                    .Where(x =>
                        x.CompanyHasProductOrService != null &&
                        selectedCompanyIds.Contains(
                            x.CompanyHasProductOrService.CompanyId))
                    .ToList();

            int salesCount = payments.Count;

            decimal totalRevenue =
                payments.Sum(x =>
                    x.CompanyHasProductOrService
                        .CompanyHasProductOrServicePrice *
                    x.CustomerBuysCompanyHasProductOrServiceQuantity);


            flpGauges.Controls.Add(
                CreateGauge(
                    "Companies",
                    companyCount,
                    100));

            flpGauges.Controls.Add(
                CreateGauge(
                    "Employees",
                    employeeCount,
                    10000));

            flpGauges.Controls.Add(
                CreateGauge(
                    "Customers",
                    customerCount,
                    20000));

            flpGauges.Controls.Add(
                CreateGauge(
                    "Products / Services",
                    productOrServiceCount,
                    2000));

            flpGauges.Controls.Add(
                CreateGauge(
                    "Sales",
                    salesCount,
                    50000));

            flpGauges.Controls.Add(
                CreateGauge(
                    "Revenue",
                    totalRevenue,
                    2000000));


            PnlContent.Controls.Add(
                flpGauges);

            //some summary charts
            Panel pnlSalesOverview =
            CreateSalesOverviewPanel(payments, 20, 460);

            PnlContent.Controls.Add(
                pnlSalesOverview);

            Panel pnlTopProducts =
                CreateTopProductsPanel(payments, 20, 780);

            PnlContent.Controls.Add(
                pnlTopProducts);

            Panel pnlSalesByCompany =
                CreateSalesByCompanyPanel(payments);

            PnlContent.Controls.Add(
                pnlSalesByCompany);

            Panel pnlRecentSales =
                CreateRecentSalesPanel(payments, 20, 1420);

            PnlContent.Controls.Add(
                pnlRecentSales);

            Panel pnlLowStock =
                CreateLowStockPanel(20, 1790);

            PnlContent.Controls.Add(
                pnlLowStock);
        }

        private Control CreateGauge(
    string title,
    decimal value,
    decimal maximum)
        {
            DashboardGaugeControl gauge =
                new DashboardGaugeControl(
                    title,
                    value,
                    maximum);

            gauge.Margin =
                new Padding(10);

            return gauge;
        }

        private Panel CreateSalesOverviewPanel(
            List<CustomerBuysCompanyHasProductOrService> payments,
            int positionX,
            int positionY)
        {
            Panel pnlSalesOverview =
                new Panel();

            pnlSalesOverview.Location =
                new Point(positionX, positionY);

            pnlSalesOverview.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    300);

            pnlSalesOverview.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlSalesOverview.BackColor =
                Color.FromArgb(30, 41, 59);


            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Sales Overview";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlSalesOverview.Controls.Add(
                lblTitle);


            Chart chartSales =
                new Chart();

            chartSales.Location =
                new Point(20, 55);

            chartSales.Size =
                new Size(
                    pnlSalesOverview.Width - 40,
                    220);

            chartSales.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            chartSales.BackColor =
                Color.FromArgb(30, 41, 59);


            ChartArea chartArea =
                new ChartArea();

            chartArea.BackColor =
                Color.FromArgb(30, 41, 59);

            chartArea.AxisX.LabelStyle.ForeColor =
                Color.FromArgb(203, 213, 225);

            chartArea.AxisY.LabelStyle.ForeColor =
                Color.FromArgb(203, 213, 225);

            chartArea.AxisX.MajorGrid.LineColor =
                Color.FromArgb(71, 85, 105);

            chartArea.AxisY.MajorGrid.LineColor =
                Color.FromArgb(71, 85, 105);

            chartSales.ChartAreas.Add(
                chartArea);


            Series series =
                new Series();

            series.Name =
                "Revenue";

            series.ChartType =
                SeriesChartType.Line;

            series.BorderWidth =
                3;

            series.Color =
                Color.FromArgb(37, 99, 235);


            for (int month = 1; month <= 12; month++)
            {
                decimal monthlyRevenue =
                    payments
                        .Where(x =>
                            x.CustomerBuysCompanyHasProductOrServiceDate.Year ==
                                DateTime.Now.Year &&
                            x.CustomerBuysCompanyHasProductOrServiceDate.Month ==
                                month)
                        .Sum(x =>
                            x.CompanyHasProductOrService
                                .CompanyHasProductOrServicePrice *
                            x.CustomerBuysCompanyHasProductOrServiceQuantity);

                series.Points.AddXY(
                    new DateTime(
                        DateTime.Now.Year,
                        month,
                        1).ToString("MMM"),
                    monthlyRevenue);
            }

            chartSales.Series.Add(
                series);

            pnlSalesOverview.Controls.Add(
                chartSales);

            return pnlSalesOverview;
        }
        private Panel CreateTopProductsPanel(
            List<CustomerBuysCompanyHasProductOrService> payments,
            int positionX,
            int positionY)
        {
            Panel pnlTopProducts =
                new Panel();

            pnlTopProducts.Location =
                new Point(positionX, positionY);

            pnlTopProducts.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    300);

            pnlTopProducts.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlTopProducts.BackColor =
                Color.FromArgb(30, 41, 59);


            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Top Products / Services";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlTopProducts.Controls.Add(
                lblTitle);


            Chart chartTopProducts =
                new Chart();

            chartTopProducts.Location =
                new Point(20, 55);

            chartTopProducts.Size =
                new Size(
                    pnlTopProducts.Width - 40,
                    220);

            chartTopProducts.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            chartTopProducts.BackColor =
                Color.FromArgb(30, 41, 59);


            ChartArea chartArea =
                new ChartArea();

            chartArea.BackColor =
                Color.FromArgb(30, 41, 59);

            chartArea.AxisX.LabelStyle.ForeColor =
                Color.FromArgb(203, 213, 225);

            chartArea.AxisY.LabelStyle.ForeColor =
                Color.FromArgb(203, 213, 225);

            chartArea.AxisX.MajorGrid.LineColor =
                Color.FromArgb(71, 85, 105);

            chartArea.AxisY.MajorGrid.LineColor =
                Color.FromArgb(71, 85, 105);

            chartTopProducts.ChartAreas.Add(
                chartArea);


            Series series =
                new Series();

            series.Name =
                "Sales";

            series.ChartType =
                SeriesChartType.Column;

            series.BorderWidth =
                2;

            series.Color =
                Color.FromArgb(37, 99, 235);


            var topProducts =
                payments
                    .GroupBy(x =>
                        x.CompanyHasProductOrService
                            .ProductOrService)
                    .Select(x => new
                    {
                        ProductOrService =
                            x.Key.ProductOrServiceName,

                        Quantity =
                            x.Sum(y =>
                                y.CustomerBuysCompanyHasProductOrServiceQuantity)
                    })
                    .OrderByDescending(x => x.Quantity)
                    .Take(50)
                    .ToList();


            foreach (var product in topProducts)
            {
                series.Points.AddXY(
                    product.ProductOrService,
                    product.Quantity);
            }


            chartTopProducts.Series.Add(
                series);

            pnlTopProducts.Controls.Add(
                chartTopProducts);

            return pnlTopProducts;
        }


        private Panel CreateSalesByCompanyPanel(
    List<CustomerBuysCompanyHasProductOrService> payments)
        {
            Panel pnlSalesByCompany =
                new Panel();

            pnlSalesByCompany.Location =
                new Point(20, 1100);

            pnlSalesByCompany.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    300);

            pnlSalesByCompany.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlSalesByCompany.BackColor =
                Color.FromArgb(30, 41, 59);

            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Sales by Company";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlSalesByCompany.Controls.Add(
                lblTitle);

            Chart chartSalesByCompany =
                new Chart();

            chartSalesByCompany.Location =
                new Point(20, 55);

            chartSalesByCompany.Size =
                new Size(
                    pnlSalesByCompany.Width - 40,
                    220);

            chartSalesByCompany.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            chartSalesByCompany.BackColor =
                Color.FromArgb(30, 41, 59);

            ChartArea chartArea =
                new ChartArea();

            chartArea.BackColor =
                Color.FromArgb(30, 41, 59);

            chartArea.AxisX.LabelStyle.ForeColor =
                Color.FromArgb(203, 213, 225);

            chartArea.AxisY.LabelStyle.ForeColor =
                Color.FromArgb(203, 213, 225);

            chartArea.AxisX.MajorGrid.LineColor =
                Color.FromArgb(71, 85, 105);

            chartArea.AxisY.MajorGrid.LineColor =
                Color.FromArgb(71, 85, 105);

            chartSalesByCompany.ChartAreas.Add(
                chartArea);

            Series series =
                new Series();

            series.Name =
                "Revenue";

            series.ChartType =
                SeriesChartType.Column;

            series.BorderWidth =
                2;

            series.Color =
                Color.FromArgb(37, 99, 235);

            var salesByCompany =
    payments
        .GroupBy(x =>
            x.CompanyHasProductOrService.Company)
        .Select(x => new
        {
            CompanyName =
                x.Key.CompanyName,

            Revenue =
                x.Sum(y =>
                    y.CompanyHasProductOrService
                        .CompanyHasProductOrServicePrice *
                    y.CustomerBuysCompanyHasProductOrServiceQuantity)
        })
        .OrderByDescending(x =>
            x.Revenue)
        .ToList();

            foreach (var company in salesByCompany)
            {
                series.Points.AddXY(
                    company.CompanyName,
                    company.Revenue);
            }

            chartSalesByCompany.Series.Add(
                series);

            pnlSalesByCompany.Controls.Add(
                chartSalesByCompany);

            return pnlSalesByCompany;
        }

        private Panel CreateRecentSalesPanel(
            List<CustomerBuysCompanyHasProductOrService> payments,
            int positionX,
            int positionY)
        {
            Panel pnlRecentSales =
                new Panel();

            pnlRecentSales.Location =
                new Point(positionX, positionY);

            pnlRecentSales.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    350);

            pnlRecentSales.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlRecentSales.BackColor =
                Color.FromArgb(30, 41, 59);


            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Recent Sales";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlRecentSales.Controls.Add(
                lblTitle);


            DataGridView dgvRecentSales =
                new DataGridView();

            dgvRecentSales.Location =
                new Point(20, 55);

            dgvRecentSales.Size =
                new Size(
                    pnlRecentSales.Width - 40,
                    270);

            dgvRecentSales.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvRecentSales.BackgroundColor =
                Color.FromArgb(248, 250, 252);

            dgvRecentSales.BorderStyle =
                BorderStyle.None;

            dgvRecentSales.AllowUserToAddRows =
                false;

            dgvRecentSales.AllowUserToDeleteRows =
                false;

            dgvRecentSales.ReadOnly =
                true;

            dgvRecentSales.RowHeadersVisible =
                false;

            dgvRecentSales.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecentSales.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRecentSales.MultiSelect =
                false;

            dgvRecentSales.EnableHeadersVisualStyles =
                false;

            dgvRecentSales.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(71, 85, 105),

                    ForeColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            9,
                            FontStyle.Bold)
                };

            dgvRecentSales.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(248, 250, 252),

                    ForeColor =
                        Color.FromArgb(15, 23, 42),

                    SelectionBackColor =
                        Color.FromArgb(219, 234, 254),

                    SelectionForeColor =
                        Color.FromArgb(15, 23, 42),

                    Font =
                        new Font(
                            "Segoe UI",
                            9)
                };


            dgvRecentSales.Columns.Add(
                "Customer",
                "Customer");

            dgvRecentSales.Columns.Add(
                "Company",
                "Company");

            dgvRecentSales.Columns.Add(
                "ProductOrService",
                "Product / Service");

            dgvRecentSales.Columns.Add(
                "Quantity",
                "Quantity");

            dgvRecentSales.Columns.Add(
                "PaymentType",
                "Payment Type");

            dgvRecentSales.Columns.Add(
                "Date",
                "Date");

            dgvRecentSales.Columns.Add(
                "Revenue",
                "Revenue");


            var recentSales =
                payments
                    .OrderByDescending(x =>
                        x.CustomerBuysCompanyHasProductOrServiceDate)
                    .Take(10)
                    .ToList();


            foreach (var sale in recentSales)
            {
                decimal revenue =
                    sale.CompanyHasProductOrService
                        .CompanyHasProductOrServicePrice *
                    sale.CustomerBuysCompanyHasProductOrServiceQuantity;

                dgvRecentSales.Rows.Add(
                    sale.Customer.CustomerName +
                    " " +
                    sale.Customer.CustomerSurname,

                    sale.CompanyHasProductOrService
                        .Company.CompanyName,

                    sale.CompanyHasProductOrService
                        .ProductOrService.ProductOrServiceName,

                    sale.CustomerBuysCompanyHasProductOrServiceQuantity,

                    sale.PaymentType.PaymentTypeName,

                    sale.CustomerBuysCompanyHasProductOrServiceDate
                        .ToString("dd.MM.yyyy"),

                    revenue.ToString("N2"));
            }


            pnlRecentSales.Controls.Add(
                dgvRecentSales);

            return pnlRecentSales;
        }

        private Panel CreateLowStockPanel(
            int positionX,
            int positionY)
        {
            Panel pnlLowStock =
                new Panel();

            pnlLowStock.Location =
                new Point(positionX, positionY);

            pnlLowStock.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    350);

            pnlLowStock.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlLowStock.BackColor =
                Color.FromArgb(30, 41, 59);


            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Low Stock";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlLowStock.Controls.Add(
                lblTitle);


            DataGridView dgvLowStock =
                new DataGridView();

            dgvLowStock.Location =
                new Point(20, 55);

            dgvLowStock.Size =
                new Size(
                    pnlLowStock.Width - 40,
                    270);

            dgvLowStock.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvLowStock.BackgroundColor =
                Color.FromArgb(248, 250, 252);

            dgvLowStock.BorderStyle =
                BorderStyle.None;

            dgvLowStock.AllowUserToAddRows =
                false;

            dgvLowStock.AllowUserToDeleteRows =
                false;

            dgvLowStock.ReadOnly =
                true;

            dgvLowStock.RowHeadersVisible =
                false;

            dgvLowStock.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLowStock.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLowStock.MultiSelect =
                false;

            dgvLowStock.EnableHeadersVisualStyles =
                false;

            dgvLowStock.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(71, 85, 105),

                    ForeColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            9,
                            FontStyle.Bold)
                };

            dgvLowStock.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(248, 250, 252),

                    ForeColor =
                        Color.FromArgb(15, 23, 42),

                    SelectionBackColor =
                        Color.FromArgb(219, 234, 254),

                    SelectionForeColor =
                        Color.FromArgb(15, 23, 42),

                    Font =
                        new Font(
                            "Segoe UI",
                            9)
                };


            dgvLowStock.Columns.Add(
                "Company",
                "Company");

            dgvLowStock.Columns.Add(
                "ProductOrService",
                "Product / Service");

            dgvLowStock.Columns.Add(
                "Quantity",
                "Quantity");


            List<CompanyHasProductOrService> companyProducts =
                new BLCompanyHasProductOrService()
                    .CompanyHasProductOrServiceList();

            var lowStock =
                companyProducts
                    .Where(x =>
                        selectedCompanyIds.Contains(x.CompanyId) &&
                        x.CompanyHasProductOrServiceQuantity <= 10)
                    .OrderBy(x =>
                        x.CompanyHasProductOrServiceQuantity)
                    .Take(10)
                    .ToList();


            foreach (var item in lowStock)
            {
                dgvLowStock.Rows.Add(
                    item.Company.CompanyName,

                    item.ProductOrService
                        .ProductOrServiceName,

                    item.CompanyHasProductOrServiceQuantity);
            }


            pnlLowStock.Controls.Add(
                dgvLowStock);

            return pnlLowStock;
        }
        private void CreateCompanyOwnerDashboard()
        {
            List<Meeting> meetings =
                blMeeting
                    .MeetingList();

            List<CompanyManagement.Entity.Task> tasks =
                blTask
                    .TaskList();

            List<CustomerBuysCompanyHasProductOrService> payments =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceList()
                    .Where(x =>
                        x.CompanyHasProductOrService != null &&
                        selectedCompanyIds.Contains(
                            x.CompanyHasProductOrService.CompanyId))
                    .ToList();


            Panel pnlUpcomingMeetings =
                CreateUpcomingMeetingsPanel(meetings);

            PnlContent.Controls.Add(
                pnlUpcomingMeetings);


            Panel pnlPendingTasks =
                CreatePendingTasksPanel(tasks);

            PnlContent.Controls.Add(
                pnlPendingTasks);


            Panel pnlSalesOverview =
                CreateSalesOverviewPanel(payments, 20, 760);

            PnlContent.Controls.Add(
                pnlSalesOverview);


            Panel pnlTopProducts =
                CreateTopProductsPanel(payments, 20, 1130);

            PnlContent.Controls.Add(
                pnlTopProducts);

            Panel pnlRecentSales =
    CreateRecentSalesPanel(payments, 20, 1420);

            PnlContent.Controls.Add(
                pnlRecentSales);

            Panel pnlLowStock =
                CreateLowStockPanel(20, 1790);

            PnlContent.Controls.Add(
                pnlLowStock);
        }
        private void CreateEmployeeDashboard()
        {
            List<Meeting> meetings =
            blMeeting
                .MeetingList();

            List<CompanyManagement.Entity.Task> tasks =
                blTask
                    .TaskList();


            Panel pnlUpcomingMeetings =
                CreateUpcomingMeetingsEmployeePanel(meetings);

            PnlContent.Controls.Add(
                pnlUpcomingMeetings);


            Panel pnlPendingTasks =
                CreatePendingTasksEmployeePanel(tasks);

            PnlContent.Controls.Add(
                pnlPendingTasks);

        }

        private Panel CreateUpcomingMeetingsPanel(
    List<Meeting> meetings)
        {
            Panel pnlUpcomingMeetings =
                new Panel();

            pnlUpcomingMeetings.Location =
                new Point(20, 20);

            pnlUpcomingMeetings.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    350);

            pnlUpcomingMeetings.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlUpcomingMeetings.BackColor =
                Color.FromArgb(30, 41, 59);


            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Upcoming Meetings";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlUpcomingMeetings.Controls.Add(
                lblTitle);


            DataGridView dgvMeetings =
                new DataGridView();

            dgvMeetings.Location =
                new Point(20, 55);

            dgvMeetings.Size =
                new Size(
                    pnlUpcomingMeetings.Width - 40,
                    270);

            dgvMeetings.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvMeetings.BackgroundColor =
                Color.FromArgb(248, 250, 252);

            dgvMeetings.BorderStyle =
                BorderStyle.None;

            dgvMeetings.AllowUserToAddRows =
                false;

            dgvMeetings.AllowUserToDeleteRows =
                false;

            dgvMeetings.ReadOnly =
                true;

            dgvMeetings.RowHeadersVisible =
                false;

            dgvMeetings.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMeetings.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMeetings.MultiSelect =
                false;

            dgvMeetings.EnableHeadersVisualStyles =
                false;

            dgvMeetings.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(71, 85, 105),

                    ForeColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            9,
                            FontStyle.Bold)
                };

            dgvMeetings.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(248, 250, 252),

                    ForeColor =
                        Color.FromArgb(15, 23, 42),

                    SelectionBackColor =
                        Color.FromArgb(219, 234, 254),

                    SelectionForeColor =
                        Color.FromArgb(15, 23, 42),

                    Font =
                        new Font(
                            "Segoe UI",
                            9)
                };


            dgvMeetings.Columns.Add(
                "Plot",
                "Meeting");

            dgvMeetings.Columns.Add(
                "Place",
                "Place");

            dgvMeetings.Columns.Add(
                "Date",
                "Date");


            var upcomingMeetings =
                meetings
                    .Where(x =>
                        x.MeetingDate >= DateTime.Now &&
                        x.MeetingHasCompanyOwners.Any(y =>
                            y.CompanyOwner != null &&
                            y.CompanyOwner.UserId == user.UserId &&
                            y.CompanyOwner.CompanyOwnerHasCompanies.Any(z =>
                                selectedCompanyIds.Contains(z.CompanyId))))
                    .OrderBy(x =>
                        x.MeetingDate)
                    .Take(10)
                    .ToList();


            foreach (var meeting in upcomingMeetings)
            {
                dgvMeetings.Rows.Add(
                    meeting.MeetingPlot,

                    meeting.MeetingPlace,

                    meeting.MeetingDate
                        .ToString("dd.MM.yyyy HH:mm"));
            }


            pnlUpcomingMeetings.Controls.Add(
                dgvMeetings);

            return pnlUpcomingMeetings;
        }

        private Panel CreatePendingTasksPanel(
    List<CompanyManagement.Entity.Task> tasks)
        {
            Panel pnlPendingTasks =
                new Panel();

            pnlPendingTasks.Location =
                new Point(20, 390);

            pnlPendingTasks.Size =
                new Size(
                    PnlContent.ClientSize.Width - 40,
                    350);

            pnlPendingTasks.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlPendingTasks.BackColor =
                Color.FromArgb(30, 41, 59);


            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Pending Tasks";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(20, 15);

            pnlPendingTasks.Controls.Add(
                lblTitle);


            DataGridView dgvTasks =
                new DataGridView();

            dgvTasks.Location =
                new Point(20, 55);

            dgvTasks.Size =
                new Size(
                    pnlPendingTasks.Width - 40,
                    270);

            dgvTasks.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvTasks.BackgroundColor =
                Color.FromArgb(248, 250, 252);

            dgvTasks.BorderStyle =
                BorderStyle.None;

            dgvTasks.AllowUserToAddRows =
                false;

            dgvTasks.AllowUserToDeleteRows =
                false;

            dgvTasks.ReadOnly =
                true;

            dgvTasks.RowHeadersVisible =
                false;

            dgvTasks.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTasks.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTasks.MultiSelect =
                false;

            dgvTasks.EnableHeadersVisualStyles =
                false;

            dgvTasks.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(71, 85, 105),

                    ForeColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            9,
                            FontStyle.Bold)
                };

            dgvTasks.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(248, 250, 252),

                    ForeColor =
                        Color.FromArgb(15, 23, 42),

                    SelectionBackColor =
                        Color.FromArgb(219, 234, 254),

                    SelectionForeColor =
                        Color.FromArgb(15, 23, 42),

                    Font =
                        new Font(
                            "Segoe UI",
                            9)
                };


            dgvTasks.Columns.Add(
                "Task",
                "Task");

            dgvTasks.Columns.Add(
                "BeginningDate",
                "Beginning Date");

            dgvTasks.Columns.Add(
                "Status",
                "Status");


            var pendingTasks =
                tasks
                    .Where(x =>
                        !x.IsCompleted &&
                        x.TaskHasCompanyOwners.Any(y =>
                            y.CompanyOwner != null &&
                            y.CompanyOwner.UserId == user.UserId &&
                            y.CompanyOwner.CompanyOwnerHasCompanies.Any(z =>
                                selectedCompanyIds.Contains(z.CompanyId))))
                    .OrderBy(x =>
                        x.TaskBeginningDate)
                    .Take(10)
                    .ToList();


            foreach (var task in pendingTasks)
            {
                dgvTasks.Rows.Add(
                    task.TaskName,

                    task.TaskBeginningDate
                        .ToString("dd.MM.yyyy HH:mm"),

                    "Pending");
            }


            pnlPendingTasks.Controls.Add(
                dgvTasks);

            return pnlPendingTasks;
        }

        private void DrawDashboardIcon(
            Graphics graphics,
            Rectangle bounds,
            string type,
            Color color)
        {
            graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = 20;
            int x = bounds.X + (bounds.Width - size) / 2;
            int y = bounds.Y + (bounds.Height - size) / 2;

            using (SolidBrush brush = new SolidBrush(color))
            using (Pen pen = new Pen(color, 2))
            using (SolidBrush white = new SolidBrush(Color.White))
            using (Pen whitePen = new Pen(Color.White, 2))
            {
                if (type == "skull")
                {
                    graphics.FillEllipse(brush, x + 3, y, 14, 13);
                    graphics.FillRectangle(brush, x + 5, y + 9, 10, 7);

                    graphics.FillEllipse(white, x + 5, y + 5, 4, 4);
                    graphics.FillEllipse(white, x + 11, y + 5, 4, 4);

                    graphics.FillPolygon(white, new Point[]
                    {
                new Point(x + 10, y + 10),
                new Point(x + 8, y + 13),
                new Point(x + 12, y + 13)
                    });

                    graphics.DrawLine(pen, x + 7, y + 14, x + 7, y + 18);
                    graphics.DrawLine(pen, x + 10, y + 14, x + 10, y + 18);
                    graphics.DrawLine(pen, x + 13, y + 14, x + 13, y + 18);
                }
                else if (type == "warning")
                {
                    graphics.FillPolygon(brush, new Point[]
                    {
                new Point(x + 10, y),
                new Point(x + 20, y + 18),
                new Point(x, y + 18)
                    });

                    graphics.DrawLine(whitePen, x + 10, y + 5, x + 10, y + 11);
                    graphics.FillEllipse(white, x + 9, y + 13, 2, 2);
                }
                else if (type == "calendar")
                {
                    graphics.DrawRectangle(pen, x + 2, y + 3, 16, 15);
                    graphics.DrawLine(pen, x + 2, y + 7, x + 18, y + 7);
                    graphics.DrawLine(pen, x + 6, y, x + 6, y + 5);
                    graphics.DrawLine(pen, x + 14, y, x + 14, y + 5);
                    graphics.FillRectangle(brush, x + 5, y + 10, 3, 3);
                    graphics.FillRectangle(brush, x + 11, y + 10, 3, 3);
                }
                else if (type == "check")
                {
                    graphics.FillEllipse(brush, x, y, 20, 20);

                    graphics.DrawLines(whitePen, new Point[]
                    {
                new Point(x + 4, y + 10),
                new Point(x + 8, y + 14),
                new Point(x + 16, y + 6)
                    });
                }
                else if (type == "clock")
                {
                    graphics.DrawEllipse(pen, x + 1, y + 1, 18, 18);
                    graphics.DrawLine(pen, x + 10, y + 4, x + 10, y + 10);
                    graphics.DrawLine(pen, x + 10, y + 10, x + 14, y + 12);
                }
                else if (type == "alarm")
                {
                    graphics.DrawArc(pen, x + 3, y + 4, 14, 14, 180, 180);
                    graphics.DrawLine(pen, x + 3, y + 11, x + 3, y + 15);
                    graphics.DrawLine(pen, x + 17, y + 11, x + 17, y + 15);
                    graphics.DrawLine(pen, x + 3, y + 15, x + 17, y + 15);
                    graphics.DrawLine(pen, x + 5, y + 3, x + 2, y);
                    graphics.DrawLine(pen, x + 15, y + 3, x + 18, y);
                    graphics.DrawLine(pen, x + 7, y + 19, x + 5, y + 20);
                    graphics.DrawLine(pen, x + 13, y + 19, x + 15, y + 20);
                }
                else if (type == "star")
                {
                    graphics.FillPolygon(brush, new Point[]
                    {
                new Point(x + 10, y),
                new Point(x + 13, y + 7),
                new Point(x + 20, y + 7),
                new Point(x + 15, y + 12),
                new Point(x + 17, y + 20),
                new Point(x + 10, y + 16),
                new Point(x + 3, y + 20),
                new Point(x + 5, y + 12),
                new Point(x, y + 7),
                new Point(x + 7, y + 7)
                    });
                }
                else if (type == "target")
                {
                    graphics.DrawEllipse(pen, x + 1, y + 1, 18, 18);
                    graphics.DrawEllipse(pen, x + 5, y + 5, 10, 10);
                    graphics.FillEllipse(brush, x + 8, y + 8, 4, 4);
                }
                else if (type == "lightning")
                {
                    graphics.FillPolygon(brush, new Point[]
                    {
                new Point(x + 12, y),
                new Point(x + 4, y + 11),
                new Point(x + 9, y + 11),
                new Point(x + 7, y + 20),
                new Point(x + 17, y + 7),
                new Point(x + 12, y + 7)
                    });
                }
                else if (type == "info")
                {
                    graphics.FillEllipse(brush, x, y, 20, 20);
                    graphics.FillEllipse(white, x + 9, y + 4, 2, 2);
                    graphics.FillRectangle(white, x + 9, y + 8, 2, 8);
                }
                else if (type == "flag")
                {
                    graphics.DrawLine(pen, x + 4, y, x + 4, y + 20);
                    graphics.DrawLines(pen, new Point[]
                    {
                new Point(x + 5, y + 2),
                new Point(x + 17, y + 4),
                new Point(x + 12, y + 9),
                new Point(x + 5, y + 7)
                    });
                }
                else if (type == "shield")
                {
                    graphics.FillPolygon(brush, new Point[]
                    {
                new Point(x + 10, y),
                new Point(x + 19, y + 4),
                new Point(x + 17, y + 13),
                new Point(x + 10, y + 20),
                new Point(x + 3, y + 13),
                new Point(x + 1, y + 4)
                    });

                    graphics.DrawLines(whitePen, new Point[]
                    {
                new Point(x + 5, y + 10),
                new Point(x + 9, y + 13),
                new Point(x + 15, y + 6)
                    });
                }
                else if (type == "person")
                {
                    graphics.FillEllipse(brush, x + 6, y, 8, 8);
                    graphics.FillPie(brush, x + 2, y + 9, 16, 13, 180, 180);
                }
                else if (type == "document")
                {
                    graphics.DrawRectangle(pen, x + 3, y + 1, 14, 18);
                    graphics.DrawLine(pen, x + 6, y + 6, x + 14, y + 6);
                    graphics.DrawLine(pen, x + 6, y + 10, x + 14, y + 10);
                    graphics.DrawLine(pen, x + 6, y + 14, x + 12, y + 14);
                }
                else if (type == "pause")
                {
                    graphics.FillRectangle(brush, x + 4, y + 2, 4, 16);
                    graphics.FillRectangle(brush, x + 12, y + 2, 4, 16);
                }
                else if (type == "progress")
                {
                    graphics.DrawEllipse(pen, x + 1, y + 1, 18, 18);
                    graphics.DrawArc(pen, x + 1, y + 1, 18, 18, -90, 230);
                }
            }
        }

        private Panel CreateUpcomingMeetingsEmployeePanel(List<Meeting> meetings)
        {
            Panel pnl = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(PnlContent.ClientSize.Width - 40, 350),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Panel accent = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(6, 350),
                BackColor = Color.FromArgb(59, 130, 246)
            };
            pnl.Controls.Add(accent);

            Label title = new Label
            {
                Text = "Upcoming Meetings",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 64, 175),
                AutoSize = true,
                Location = new Point(20, 12)
            };
            pnl.Controls.Add(title);

            Label subtitle = new Label
            {
                Text = "Your schedule and time remaining",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(22, 40)
            };
            pnl.Controls.Add(subtitle);

            DataGridView dgv = new DataGridView
            {
                Location = new Point(20, 68),
                Size = new Size(pnl.Width - 40, 257),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                EnableHeadersVisualStyles = false,
                RowTemplate = { Height = 36 },
                GridColor = Color.FromArgb(226, 232, 240)
            };

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(219, 234, 254),
                ForeColor = Color.FromArgb(30, 64, 175),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Padding = new Padding(5)
            };

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(219, 234, 254),
                SelectionForeColor = Color.FromArgb(30, 41, 59),
                Font = new Font("Segoe UI", 9),
                Padding = new Padding(5)
            };

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252)
            };

            dgv.Columns.Add("Indicator", "");
            dgv.Columns.Add("Plot", "Meeting");
            dgv.Columns.Add("Place", "Place");
            dgv.Columns.Add("Date", "Date");
            dgv.Columns.Add("DaysLeft", "Days Left");
            dgv.Columns.Add("Timeline", "Timeline");

            dgv.Columns["Indicator"].FillWeight = 9;
            dgv.Columns["Plot"].FillWeight = 31;
            dgv.Columns["Place"].FillWeight = 22;
            dgv.Columns["Date"].FillWeight = 25;
            dgv.Columns["DaysLeft"].FillWeight = 16;
            dgv.Columns["Timeline"].FillWeight = 22;

            var upcomingMeetings =
                meetings
                    .Where(x =>
                        x.MeetingDate >= DateTime.Now &&
                        x.MeetingHasEmployees.Any(y =>
                            y.Employee != null &&
                            y.Employee.UserId == user.UserId))
                    .OrderBy(x => x.MeetingDate)
                    .Take(10)
                    .ToList();

            foreach (var meeting in upcomingMeetings)
            {
                double days = (meeting.MeetingDate - DateTime.Now).TotalDays;

                string indicator;
                Color color;

                if (days <= 1)
                {
                    indicator = "alarm";
                    color = Color.FromArgb(220, 38, 38);
                }
                else if (days <= 3)
                {
                    indicator = "clock";
                    color = Color.FromArgb(234, 88, 12);
                }
                else if (days <= 5)
                {
                    indicator = "calendar";
                    color = Color.FromArgb(202, 138, 4);
                }
                else
                {
                    indicator = "star";
                    color = Color.FromArgb(22, 163, 74);
                }

                int row = dgv.Rows.Add(
                    indicator,
                    meeting.MeetingPlot,
                    meeting.MeetingPlace,
                    meeting.MeetingDate.ToString("dd.MM.yyyy HH:mm"),
                    Math.Ceiling(days),
                    Math.Min(days, 10));

                dgv.Rows[row].Cells["Indicator"].Style.ForeColor = color;
                dgv.Rows[row].Cells["DaysLeft"].Style.ForeColor = color;
                dgv.Rows[row].Cells["DaysLeft"].Style.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);
            }

            dgv.CellPainting += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == dgv.Columns["Indicator"].Index)
                {
                    e.PaintBackground(e.CellBounds, true);

                    string type = Convert.ToString(
                        dgv.Rows[e.RowIndex].Cells["Indicator"].Value);

                    Color color = dgv.Rows[e.RowIndex]
                        .Cells["DaysLeft"].Style.ForeColor;

                    DrawDashboardIcon(e.Graphics, e.CellBounds, type, color);

                    e.Handled = true;
                }
                else if (e.ColumnIndex == dgv.Columns["Timeline"].Index)
                {
                    e.PaintBackground(e.CellBounds, true);

                    double value = Convert.ToDouble(
                        dgv.Rows[e.RowIndex].Cells["Timeline"].Value);

                    Rectangle area = e.CellBounds;
                    area.Inflate(-7, -13);

                    using (SolidBrush background =
                           new SolidBrush(Color.FromArgb(226, 232, 240)))
                    {
                        e.Graphics.FillRectangle(background, area);
                    }

                    int width = (int)(area.Width * Math.Min(value / 10.0, 1.0));

                    Color color = value <= 1
                        ? Color.FromArgb(220, 38, 38)
                        : value <= 3
                            ? Color.FromArgb(234, 88, 12)
                            : value <= 5
                                ? Color.FromArgb(202, 138, 4)
                                : Color.FromArgb(22, 163, 74);

                    using (SolidBrush fill = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(
                            fill,
                            area.X,
                            area.Y,
                            Math.Max(0, width),
                            area.Height);
                    }

                    e.Handled = true;
                }
            };

            pnl.Controls.Add(dgv);
            return pnl;
        }

        private Panel CreatePendingTasksEmployeePanel(
    List<CompanyManagement.Entity.Task> tasks)
        {
            Panel pnl = new Panel
            {
                Location = new Point(20, 390),
                Size = new Size(PnlContent.ClientSize.Width - 40, 350),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Panel accent = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(6, 350),
                BackColor = Color.FromArgb(16, 185, 129)
            };
            pnl.Controls.Add(accent);

            Label title = new Label
            {
                Text = "Pending Tasks",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(6, 95, 70),
                AutoSize = true,
                Location = new Point(20, 12)
            };
            pnl.Controls.Add(title);

            Label subtitle = new Label
            {
                Text = "Your assigned work and priority",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(22, 40)
            };
            pnl.Controls.Add(subtitle);

            DataGridView dgv = new DataGridView
            {
                Location = new Point(20, 68),
                Size = new Size(pnl.Width - 40, 257),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                EnableHeadersVisualStyles = false,
                RowTemplate = { Height = 36 },
                GridColor = Color.FromArgb(226, 232, 240)
            };

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(209, 250, 229),
                ForeColor = Color.FromArgb(6, 95, 70),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Padding = new Padding(5)
            };

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(209, 250, 229),
                SelectionForeColor = Color.FromArgb(30, 41, 59),
                Font = new Font("Segoe UI", 9),
                Padding = new Padding(5)
            };

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252)
            };

            dgv.Columns.Add("Indicator", "");
            dgv.Columns.Add("Task", "Task");
            dgv.Columns.Add("BeginningDate", "Beginning Date");
            dgv.Columns.Add("Status", "Status");
            dgv.Columns.Add("Age", "Days Since Start");
            dgv.Columns.Add("Timeline", "Priority");

            dgv.Columns["Indicator"].FillWeight = 9;
            dgv.Columns["Task"].FillWeight = 34;
            dgv.Columns["BeginningDate"].FillWeight = 25;
            dgv.Columns["Status"].FillWeight = 16;
            dgv.Columns["Age"].FillWeight = 20;
            dgv.Columns["Timeline"].FillWeight = 22;

            var pendingTasks =
                tasks
                    .Where(x =>
                        !x.IsCompleted &&
                        x.TaskHasEmployees.Any(y =>
                            y.Employee != null &&
                            y.Employee.UserId == user.UserId))
                    .OrderBy(x => x.TaskBeginningDate)
                    .Take(10)
                    .ToList();

            foreach (var task in pendingTasks)
            {
                double days = Math.Max(
                    0,
                    (DateTime.Now - task.TaskBeginningDate).TotalDays);

                string indicator;
                string priority;
                Color color;

                if (days >= 5)
                {
                    indicator = "skull";
                    priority = "High";
                    color = Color.FromArgb(220, 38, 38);
                }
                else if (days >= 3)
                {
                    indicator = "warning";
                    priority = "Medium";
                    color = Color.FromArgb(234, 88, 12);
                }
                else
                {
                    indicator = "check";
                    priority = "Normal";
                    color = Color.FromArgb(22, 163, 74);
                }

                int row = dgv.Rows.Add(
                    indicator,
                    task.TaskName,
                    task.TaskBeginningDate.ToString("dd.MM.yyyy HH:mm"),
                    "Pending",
                    Math.Floor(days),
                    priority);

                dgv.Rows[row].Cells["Indicator"].Style.ForeColor = color;
                dgv.Rows[row].Cells["Age"].Style.ForeColor = color;
                dgv.Rows[row].Cells["Age"].Style.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);
                dgv.Rows[row].Cells["Timeline"].Style.ForeColor = color;
                dgv.Rows[row].Cells["Timeline"].Style.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);
                dgv.Rows[row].Cells["Status"].Style.ForeColor =
                    Color.FromArgb(180, 83, 9);
            }

            dgv.CellPainting += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == dgv.Columns["Indicator"].Index)
                {
                    e.PaintBackground(e.CellBounds, true);

                    string type = Convert.ToString(
                        dgv.Rows[e.RowIndex].Cells["Indicator"].Value);

                    Color color = dgv.Rows[e.RowIndex]
                        .Cells["Age"].Style.ForeColor;

                    DrawDashboardIcon(e.Graphics, e.CellBounds, type, color);

                    e.Handled = true;
                }
                else if (e.ColumnIndex == dgv.Columns["Timeline"].Index)
                {
                    e.PaintBackground(e.CellBounds, true);

                    double days = Convert.ToDouble(
                        dgv.Rows[e.RowIndex].Cells["Age"].Value);

                    Rectangle area = e.CellBounds;
                    area.Inflate(-7, -13);

                    using (SolidBrush background =
                           new SolidBrush(Color.FromArgb(226, 232, 240)))
                    {
                        e.Graphics.FillRectangle(background, area);
                    }

                    int width = (int)(
                        area.Width * Math.Min(days / 5.0, 1.0));

                    Color color = days >= 5
                        ? Color.FromArgb(220, 38, 38)
                        : days >= 3
                            ? Color.FromArgb(234, 88, 12)
                            : Color.FromArgb(22, 163, 74);

                    using (SolidBrush fill = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(
                            fill,
                            area.X,
                            area.Y,
                            Math.Max(0, width),
                            area.Height);
                    }

                    e.Handled = true;
                }
            };

            pnl.Controls.Add(dgv);
            return pnl;
        }

    }


}
