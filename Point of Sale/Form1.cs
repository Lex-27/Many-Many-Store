using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_of_Sale
{
    public partial class LoginForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }


        //used to close the application
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                usernameErrorLabel.Text = "* This is Required!";
            }
            else if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordErrorLabel.Text = "* This is Required!";
            }
            else if (usernameTextBox.Text == "user" && passwordTextBox.Text == "admin")
            {
                if (MessageBox.Show("Welcome!", "Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Hide();
                    var userForm = new UserForm();
                    userForm.ShowDialog();
                    this.Close();
                }

            }
            else 
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                usernameErrorLabel.Text = "* This is Required!";
            }
            else 
            {
                usernameErrorLabel.Text = "";
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordErrorLabel.Text = "* This is Required!";
            }
            else
            {
                passwordErrorLabel.Text = "";
            }
        }
    }
}
