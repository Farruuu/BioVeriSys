using NadraBioVeriSys.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadraBioVeriSys
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void biometricVerificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<Verification>().FirstOrDefault();
            if (form == null)
            {
                form = new Verification();
                form.MdiParent = this;
            }
            form.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<ChangePassword>().FirstOrDefault();
            if (form == null)
            {
                form = new ChangePassword();
                form.MdiParent = this;
            }
            form.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shared.loggedInUserID = 0;
            Shared.loggedInUserName = "";
            Shared.loggedInUserEmail = "";
            Shared.Access_token = "";
            frmLogin login = new frmLogin();
            this.Close();
            login.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
