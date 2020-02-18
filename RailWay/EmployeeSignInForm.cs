using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailWay
{
  public partial class EmployeeSignInForm : Form
  {
    private RegisterForm registerForm;
    DataBaseHandler DbHandler { get; set; }
    private const string dispatcherPassword = "DISPATCHER";
    private const string accountantPassword = "ACCOUNTANT";
    public EmployeeSignInForm(RegisterForm registerForm, DataBaseHandler dbHandler)
    {
      this.registerForm = registerForm;
      this.DbHandler = dbHandler;
      InitializeComponent();
    }

    private void EmployeeSignInForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void backBtn_MouseClick(object sender, MouseEventArgs e)
    {
      registerForm.Show();
    }

    private void signInBtn_Click(object sender, EventArgs e)
    {
      string password = signInTextBox.Text.ToString();
      switch(password)
      {
        case dispatcherPassword:
          DispatcherForm dispatcherForm = new DispatcherForm(registerForm, DbHandler);
          dispatcherForm.Show();
          this.Hide();
          break;
        case accountantPassword:
          AccountantForm accountantForm = new AccountantForm(registerForm, DbHandler);
          accountantForm.Show();
          this.Hide();
          break;
        default:
          MessageBox.Show("Invalid password!", "invalid password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
      }
    }
  }
}
