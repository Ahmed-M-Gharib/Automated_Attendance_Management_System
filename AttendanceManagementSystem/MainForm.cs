using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace AttendanceManagementSystem
{
    public partial class MainForm : Form
    {
        // Constructor
        public MainForm()
        {
            InitializeComponent();

            // After the designer code is initialized, set up our custom components
            SetupStudentVerificationPanel();
            SetupAttendanceRecordingPanel();
            SetupReportsPanel();
            SetupMenuStrip();
            SetupStatusStrip();
        }

        // Add your custom method implementations after this point
        // These will NOT be called by the designer

        #region Custom Setup Methods

        private void SetupMenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Location = new Point(0, 0);
            menuStrip.Size = new Size(800, 24);
            menuStrip.Name = "menuStrip";

            // File menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            fileMenu.DropDownItems.Add("New Session", null, (s, e) => MessageBox.Show("New Session"));
            fileMenu.DropDownItems.Add("Exit", null, (s, e) => this.Close());

            // Management menu
            ToolStripMenuItem managementMenu = new ToolStripMenuItem("Management");
            managementMenu.DropDownItems.Add("Student Management", null, (s, e) => MessageBox.Show("Student Management"));
            managementMenu.DropDownItems.Add("Course Management", null, (s, e) => MessageBox.Show("Course Management"));
            managementMenu.DropDownItems.Add("Generate Reports", null, (s, e) => MessageBox.Show("Generate Reports"));

            // Tools menu
            ToolStripMenuItem toolsMenu = new ToolStripMenuItem("Tools");
            toolsMenu.DropDownItems.Add("Settings", null, (s, e) => MessageBox.Show("Settings"));
            toolsMenu.DropDownItems.Add("Biometric Device Setup", null, (s, e) => MessageBox.Show("Biometric Device Setup"));

            // Help menu
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Help");
            helpMenu.DropDownItems.Add("User Manual", null, (s, e) => MessageBox.Show("User Manual"));
            helpMenu.DropDownItems.Add("About", null, (s, e) => MessageBox.Show("About"));

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(managementMenu);
            menuStrip.Items.Add(toolsMenu);
            menuStrip.Items.Add(helpMenu);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void SetupStatusStrip()
        {
            StatusStrip statusStrip = new StatusStrip();
            statusStrip.Location = new Point(0, this.Height - 22);
            statusStrip.Name = "statusStrip";
            statusStrip.Dock = DockStyle.Bottom;

            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel("Ready");
            ToolStripStatusLabel timeLabel = new ToolStripStatusLabel();

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                timeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            timer.Start();

            statusStrip.Items.Add(statusLabel);
            statusStrip.Items.Add(new ToolStripStatusLabel(""));
            statusStrip.Items.Add(timeLabel);

            this.Controls.Add(statusStrip);
        }

        private void SetupStudentVerificationPanel()
        {
            // Create panel for student verification
            Panel verificationPanel = new Panel();
            verificationPanel.Location = new Point(20, 40);
            verificationPanel.Size = new Size(350, 220);
            verificationPanel.BorderStyle = BorderStyle.FixedSingle;
            verificationPanel.Name = "verificationPanel";

            // Add groupbox header
            GroupBox verificationGroup = new GroupBox();
            verificationGroup.Text = "Student Verification";
            verificationGroup.Location = new Point(0, 0);
            verificationGroup.Size = new Size(350, 220);
            verificationGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Student ID label & textbox
            Label lblStudentId = new Label();
            lblStudentId.Text = "Student ID:";
            lblStudentId.Location = new Point(20, 40);
            lblStudentId.Size = new Size(100, 23);
            lblStudentId.Font = new Font("Segoe UI", 9F);

            TextBox txtStudentId = new TextBox();
            txtStudentId.Location = new Point(150, 40);
            txtStudentId.Size = new Size(180, 23);
            txtStudentId.Name = "txtStudentId";

            // Biometric verification
            Label lblBiometric = new Label();
            lblBiometric.Text = "Biometric Data:";
            lblBiometric.Location = new Point(20, 80);
            lblBiometric.Size = new Size(100, 23);
            lblBiometric.Font = new Font("Segoe UI", 9F);

            Button btnScan = new Button();
            btnScan.Text = "Scan Fingerprint";
            btnScan.Location = new Point(150, 80);
            btnScan.Size = new Size(180, 30);
            btnScan.BackColor = Color.LightBlue;

            // Generated code
            Label lblCode = new Label();
            lblCode.Text = "Generated Code:";
            lblCode.Location = new Point(20, 120);
            lblCode.Size = new Size(100, 23);
            lblCode.Font = new Font("Segoe UI", 9F);

            TextBox txtCode = new TextBox();
            txtCode.Location = new Point(150, 120);
            txtCode.Size = new Size(180, 23);
            txtCode.ReadOnly = true;
            txtCode.BackColor = Color.LightGray;

            // Verify button
            Button btnVerify = new Button();
            btnVerify.Text = "Verify & Generate Code";
            btnVerify.Location = new Point(90, 160);
            btnVerify.Size = new Size(180, 40);
            btnVerify.BackColor = Color.ForestGreen;
            btnVerify.ForeColor = Color.White;
            btnVerify.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVerify.Click += (s, e) => {
                txtCode.Text = "ABCD" + DateTime.Now.ToString("yyMMddHHmm");
                MessageBox.Show("Student verified successfully! Code generated.");
            };

            // Add controls to the group
            verificationGroup.Controls.Add(lblStudentId);
            verificationGroup.Controls.Add(txtStudentId);
            verificationGroup.Controls.Add(lblBiometric);
            verificationGroup.Controls.Add(btnScan);
            verificationGroup.Controls.Add(lblCode);
            verificationGroup.Controls.Add(txtCode);
            verificationGroup.Controls.Add(btnVerify);

            // Add group to panel
            verificationPanel.Controls.Add(verificationGroup);

            // Add panel to form
            this.Controls.Add(verificationPanel);
        }

        private void SetupAttendanceRecordingPanel()
        {
            // Create panel for attendance recording
            Panel attendancePanel = new Panel();
            attendancePanel.Location = new Point(390, 40);
            attendancePanel.Size = new Size(380, 220);
            attendancePanel.BorderStyle = BorderStyle.FixedSingle;
            attendancePanel.Name = "attendancePanel";

            // Add groupbox header
            GroupBox attendanceGroup = new GroupBox();
            attendanceGroup.Text = "Record Attendance";
            attendanceGroup.Location = new Point(0, 0);
            attendanceGroup.Size = new Size(380, 220);
            attendanceGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Course selection
            Label lblCourse = new Label();
            lblCourse.Text = "Select Course:";
            lblCourse.Location = new Point(20, 40);
            lblCourse.Size = new Size(100, 23);
            lblCourse.Font = new Font("Segoe UI", 9F);

            ComboBox cmbCourse = new ComboBox();
            cmbCourse.Location = new Point(150, 40);
            cmbCourse.Size = new Size(210, 23);
            cmbCourse.Items.AddRange(new object[] { "CS101 - Introduction to Programming",
                                                  "CS202 - Data Structures",
                                                  "CS303 - Database Systems" });

            // Code input
            Label lblAttendCode = new Label();
            lblAttendCode.Text = "Attendance Code:";
            lblAttendCode.Location = new Point(20, 80);
            lblAttendCode.Size = new Size(120, 23);
            lblAttendCode.Font = new Font("Segoe UI", 9F);

            TextBox txtAttendCode = new TextBox();
            txtAttendCode.Location = new Point(150, 80);
            txtAttendCode.Size = new Size(210, 23);

            // Location verification
            Label lblLocation = new Label();
            lblLocation.Text = "Location Status:";
            lblLocation.Location = new Point(20, 120);
            lblLocation.Size = new Size(120, 23);
            lblLocation.Font = new Font("Segoe UI", 9F);

            Label lblLocationStatus = new Label();
            lblLocationStatus.Text = "Pending Verification...";
            lblLocationStatus.Location = new Point(150, 120);
            lblLocationStatus.Size = new Size(210, 23);
            lblLocationStatus.ForeColor = Color.Orange;
            lblLocationStatus.Font = new Font("Segoe UI", 9F);

            // Submit button
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit Attendance";
            btnSubmit.Location = new Point(100, 160);
            btnSubmit.Size = new Size(180, 40);
            btnSubmit.BackColor = Color.RoyalBlue;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.Click += (s, e) => {
                lblLocationStatus.Text = "Verified (University Campus)";
                lblLocationStatus.ForeColor = Color.Green;
                MessageBox.Show("Attendance recorded successfully!");
            };

            // Add controls to the group
            attendanceGroup.Controls.Add(lblCourse);
            attendanceGroup.Controls.Add(cmbCourse);
            attendanceGroup.Controls.Add(lblAttendCode);
            attendanceGroup.Controls.Add(txtAttendCode);
            attendanceGroup.Controls.Add(lblLocation);
            attendanceGroup.Controls.Add(lblLocationStatus);
            attendanceGroup.Controls.Add(btnSubmit);

            // Add group to panel
            attendancePanel.Controls.Add(attendanceGroup);

            // Add panel to form
            this.Controls.Add(attendancePanel);
        }

        private void SetupReportsPanel()
        {
            // Create panel for attendance reports
            Panel reportsPanel = new Panel();
            reportsPanel.Location = new Point(20, 280);
            reportsPanel.Size = new Size(750, 250);
            reportsPanel.BorderStyle = BorderStyle.FixedSingle;
            reportsPanel.Name = "reportsPanel";

            // Add groupbox header
            GroupBox reportsGroup = new GroupBox();
            reportsGroup.Text = "Attendance Reports";
            reportsGroup.Location = new Point(0, 0);
            reportsGroup.Size = new Size(750, 250);
            reportsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Data grid for attendance records
            DataGridView dgvAttendance = new DataGridView();
            dgvAttendance.Location = new Point(20, 30);
            dgvAttendance.Size = new Size(710, 170);
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.ReadOnly = true;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add columns
            dgvAttendance.Columns.Add("StudentID", "Student ID");
            dgvAttendance.Columns.Add("Name", "Student Name");
            dgvAttendance.Columns.Add("Course", "Course");
            dgvAttendance.Columns.Add("Date", "Date");
            dgvAttendance.Columns.Add("Time", "Time");
            dgvAttendance.Columns.Add("Status", "Status");

            // Add sample data
            dgvAttendance.Rows.Add("S12345", "Ahmed Mohamed", "CS101", "2025-05-08", "09:15 AM", "Present");
            dgvAttendance.Rows.Add("S12346", "Sara Ahmed", "CS101", "2025-05-08", "09:18 AM", "Present");
            dgvAttendance.Rows.Add("S12347", "Mohamed Ali", "CS101", "2025-05-08", "---", "Absent");

            // Export button
            Button btnExport = new Button();
            btnExport.Text = "Export Report";
            btnExport.Location = new Point(550, 210);
            btnExport.Size = new Size(180, 30);
            btnExport.BackColor = Color.DarkOrange;
            btnExport.ForeColor = Color.White;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Click += (s, e) => {
                MessageBox.Show("Report exported successfully!");
            };

            // Filter controls
            Label lblFilter = new Label();
            lblFilter.Text = "Filter by Course:";
            lblFilter.Location = new Point(20, 215);
            lblFilter.Size = new Size(100, 23);
            lblFilter.Font = new Font("Segoe UI", 9F);

            ComboBox cmbFilter = new ComboBox();
            cmbFilter.Location = new Point(120, 210);
            cmbFilter.Size = new Size(200, 23);
            cmbFilter.Items.AddRange(new object[] { "All Courses",
                                                  "CS101 - Introduction to Programming",
                                                  "CS202 - Data Structures",
                                                  "CS303 - Database Systems" });
            cmbFilter.SelectedIndex = 0;

            Button btnApplyFilter = new Button();
            btnApplyFilter.Text = "Apply";
            btnApplyFilter.Location = new Point(330, 210);
            btnApplyFilter.Size = new Size(80, 28);
            btnApplyFilter.BackColor = Color.LightGray;

            // Add controls to the group
            reportsGroup.Controls.Add(dgvAttendance);
            reportsGroup.Controls.Add(btnExport);
            reportsGroup.Controls.Add(lblFilter);
            reportsGroup.Controls.Add(cmbFilter);
            reportsGroup.Controls.Add(btnApplyFilter);

            // Add group to panel
            reportsPanel.Controls.Add(reportsGroup);

            // Add panel to form
            this.Controls.Add(reportsPanel);
        }

        #endregion
    }
}