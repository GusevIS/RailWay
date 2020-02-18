using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailWay
{
  public partial class PassengerForm : Form
  {
    public RegisterForm RegForm { get; set; }
    public string PassengerName { get; set; }
    public string PassengerPassport { get; set; }
    private DataBaseHandler DbHandler { get; set; }
    public PassengerForm(string name, string passport, DataBaseHandler dbHandler, RegisterForm registerForm)
    {
      this.PassengerName = name;
      this.PassengerPassport = passport;
      this.DbHandler = dbHandler;
      this.RegForm = registerForm;
      InitializeComponent();
      pasNameLabel.Text = PassengerName;
      refreshData();
    }

    public void executeGetAllRoutes()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getRoutesFreeSeats", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@show_free_seats", freeSeatsCheckBox.Checked.ToString());
        if (depDtCheckBox.Checked)
          command.Parameters.AddWithValue("@departure_date", departureDatePicker.Value.ToString());
        if (arStCheckBox.Checked)
        {
          command.Parameters.AddWithValue("@departure_station", departureStationComboBox.Text.ToString());
          command.Parameters.AddWithValue("@arrival_station", arrivalStationComboBox.Text.ToString());
        }

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        allRoutesDataGridView.DataSource = dataTable;
        allRoutesDataGridView.Columns[0].Visible = false;
        allRoutesDataGridView.Columns[2].Visible = false;
      }
    }

    public void executeGetExistsStations()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getExistsStations", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        SqlDataAdapter dataAdapter2 = new SqlDataAdapter();
        dataAdapter2.SelectCommand = command;

        DataTable dataTable2 = new DataTable();
        dataAdapter2.Fill(dataTable2);

        departureStationComboBox.DataSource = dataTable;
        departureStationComboBox.DisplayMember = "id";
        departureStationComboBox.ValueMember = "station";

        arrivalStationComboBox.DataSource = dataTable2;
        arrivalStationComboBox.DisplayMember = "id";
        arrivalStationComboBox.ValueMember = "station";
      }
    }

    public void executeMyTicketsQuery()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getPassengersTickets", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlParameter passportParameter = new SqlParameter
        {
          ParameterName = "@passport",
          Value = PassengerPassport
        };
        command.Parameters.Add(passportParameter);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
 
        myTicketsDataGridView.DataSource = dataSet.Tables[0];
      }
    }

    private void refreshBtn_Click(object sender, EventArgs e)
    {
      refreshData();
    }

    public void refreshData()
    {
      executeMyTicketsQuery();
      executeGetAllRoutes();
      executeGetExistsStations();
    }

    private void freeSeatsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      executeGetAllRoutes();
    }

    private void depDtCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      executeGetAllRoutes();
    }

    private void arStCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      executeGetAllRoutes();
    }

    private void allRoutesDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int index = allRoutesDataGridView.CurrentCell.RowIndex;
      string routePart = allRoutesDataGridView["route part ID", index].Value.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getPlaces", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@route_part_id", routePart);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        placesDataGridView.DataSource = dataTable;
      }
    }

    private void placesDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      DialogResult dialogResult = MessageBox.Show("Do you want to buy this ticket?", "buy the ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (dialogResult == DialogResult.Yes)
      {
        int index = placesDataGridView.CurrentCell.RowIndex;
        string ticket = placesDataGridView["#ticket", index].Value.ToString();

        using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
        {
          connection.Open();
          SqlCommand command = new SqlCommand("buyTicket", connection);
          command.CommandType = System.Data.CommandType.StoredProcedure;

          command.Parameters.AddWithValue("@ticket_id", ticket);
          command.Parameters.AddWithValue("@passport", PassengerPassport);

          try
          {
            var result = command.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Please, enter right data", "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }
      }
    }

    private void myTicketsDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      DialogResult dialogResult = MessageBox.Show("Do you want to hand over ticekt", "hand over ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (dialogResult == DialogResult.Yes)
      {
        int index = myTicketsDataGridView.CurrentCell.RowIndex;
        string ticket = myTicketsDataGridView["#ticket", index].Value.ToString();

        using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
        {
          connection.Open();
          SqlCommand command = new SqlCommand("handOverTicket", connection);
          command.CommandType = System.Data.CommandType.StoredProcedure;

          command.Parameters.AddWithValue("@ticket_id", ticket);

          try
          {
            var result = command.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Please, enter right data", "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }
      }
    }

    private void backBtn_Click(object sender, EventArgs e)
    {
      RegForm.Show();
      this.Close();
    }
  }
}
