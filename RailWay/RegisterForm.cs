using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailWay
{
  public partial class RegisterForm : Form
  {
    public DataBaseHandler DbHandler { get; set; }
    public RegisterForm(DataBaseHandler dbHandler)
    {
      this.DbHandler = dbHandler;
      InitializeComponent();
    }

    private void employeeSignIn_MouseClick(object sender, MouseEventArgs e)
    {
      this.Hide();
      EmployeeSignInForm employeeSignInForm = new EmployeeSignInForm(this, DbHandler);
      employeeSignInForm.Show();
    }

    private void signUpBtn_Click(object sender, EventArgs e)
    {
      string name = nameTextBox.Text.ToString();
      string passport = passportTextBox.Text.ToString();
      if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(passport))
        return;

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("registerNewPassenger", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter nameParameter = new SqlParameter
        {
          ParameterName = "@passenger_name",
          Value = name
        };

        SqlParameter passportParameter = new SqlParameter
        {
          ParameterName = "@passport",
          Value = passport
        };
        command.Parameters.Add(passportParameter);
        command.Parameters.Add(nameParameter);
        try
        {
          var result = command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          switch(ex.Number)
          {
            case 2627:
              MessageBox.Show("User with the same passport already exists!", "invalid passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              break;
          }
        }
      }
    }

    private void signInBtn_Click(object sender, EventArgs e)
    {
      string name = nameTextBox.Text.ToString();
      string passport = passportTextBox.Text.ToString();
      if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(passport))
        return;

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("dbo.passengerIsExists", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter nameParameter = new SqlParameter
        {
          ParameterName = "@passenger_name",
          Value = name
        };

        SqlParameter passportParameter = new SqlParameter
        {
          ParameterName = "@passport",
          Value = passport
        };
        command.Parameters.Add(passportParameter);
        command.Parameters.Add(nameParameter);
        command.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
        try
        {
          command.ExecuteNonQuery();
          bool passengerIsExists = (bool)command.Parameters["@return"].Value;
          if (passengerIsExists)
          {
            this.Hide();
            PassengerForm passengerForm = new PassengerForm(name, passport, DbHandler, this);
            passengerForm.Show();
          }
          else
          {
            MessageBox.Show("User is not exists!", "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }
  }
}
