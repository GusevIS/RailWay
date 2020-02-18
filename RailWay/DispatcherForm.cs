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
  public partial class DispatcherForm : Form
  {
    public RegisterForm RegForm { get; set; }
    public double Distance { get; set; }
    public string RoutePart { get; set; }
    private string selectedDepartStation;
    public string SelectedDepartStation
    {
      get
      {
        return selectedDepartStation;
      }

      set
      {
        selectedDepartStation = value;
        departStationTextBox.Text = selectedDepartStation;
      }
    }
    private string selectedArrivalStation;
    public string SelectedArrivalStation
    {
      get
      {
        return selectedArrivalStation;
      }

      set
      {
        selectedArrivalStation = value;
        arrivalStationTextBox.Text = SelectedArrivalStation;
      }
    }
    private string train;
    public string Train
    {
      get
      {
        return train;
      }

      set
      {
        train = value;
        trainTextBox.Text = train;
      }
    }

    public DataBaseHandler DbHandler { get; set; }

    public DispatcherForm(RegisterForm registerForm, DataBaseHandler dbHandler)
    {
      this.RegForm = registerForm;
      this.DbHandler = dbHandler;
      InitializeComponent();
      refreshData();
    }

    public void executeGetAllExistsTrains()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAllExistsTrains", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        trainsDataGridView.DataSource = dataSet.Tables[0];
      }
    }

      public void executeGetAllExistsCarriages()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        string wearout = "0";
        if (allCarriagesRadioButton.Checked)
          wearout = "0";
        if (brokenCarriagesRadioButton.Checked)
          wearout = "40";
        connection.Open();
        SqlCommand command = new SqlCommand("getAllExistsCarriages", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@wearout", wearout);
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        carriagesDataGridView.DataSource = dataSet.Tables[0];
        carriagesComboBox.DataSource = dataSet.Tables[0];
        carriagesComboBox.DisplayMember = "id";
        carriagesComboBox.ValueMember = "#carriage";
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


        stationsDataGridView.DataSource = dataTable;

        trainStationComboBox.DataSource = dataTable;
        trainStationComboBox.DisplayMember = "id";
        trainStationComboBox.ValueMember = "station";

        chooseStComboBox.DataSource = dataTable;
        chooseStComboBox.DisplayMember = "id";
        chooseStComboBox.ValueMember = "station";

        carriageStationComboBox.DataSource = dataTable;
        carriageStationComboBox.DisplayMember = "id";
        carriageStationComboBox.ValueMember = "station";
      }
    }

    public void executeGetTrainTypes()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getExistsTrainTypes", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        trainTypeComboBox.DataSource = dataTable;
        trainTypeComboBox.DisplayMember = "id";
        trainTypeComboBox.ValueMember = "type";
      }
    }

    public void executeGetCarriageTypes()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getExistsCarriageTypes", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        carriageTypeComboBox.DataSource = dataTable;
        carriageTypeComboBox.DisplayMember = "id";
        carriageTypeComboBox.ValueMember = "type";
      }
    }

    public void executeGetAllRoutes()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAllRoutes", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        existsRoutesDataGridView.DataSource = dataTable;
      }
    }

    public void executeGetAvailableCarriage()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAvailableCarriage", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@departure_time", train);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        existsRoutesDataGridView.DataSource = dataTable;
      }
    }

    public void executeGetAllTrains()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAllTrains", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        chooseTrComboBox.DataSource = dataTable;
        chooseTrComboBox.DisplayMember = "id";
        chooseTrComboBox.ValueMember = "train_id";
      }
    }

    public void refreshData()
    {
      executeGetAllExistsTrains();
      executeGetAllExistsCarriages();
      executeGetExistsStations();
      executeGetTrainTypes();
      executeGetCarriageTypes();
      executeGetAllRoutes();
      executeGetAllTrains();
    }

    private void dispatcherTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void addTrainBtn_Click(object sender, EventArgs e)
    {
      string type = trainTypeComboBox.Text.ToString();
      string speed = speedTextBox.Text.ToString();
      string price = priceTextBox.Text.ToString();
      string station = trainStationComboBox.Text.ToString();

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addTrain", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter typeParameter = new SqlParameter
        {
          ParameterName = "@train_type",
          Value = type
        };

        SqlParameter speedParameter = new SqlParameter
        {
          ParameterName = "@speed",
          Value = speed
        };

        SqlParameter priceParameter = new SqlParameter
        {
          ParameterName = "@price",
          Value = price
        };

        SqlParameter stationParameter = new SqlParameter
        {
          ParameterName = "@station",
          Value = station
        };
        command.Parameters.Add(typeParameter);
        command.Parameters.Add(speedParameter);
        command.Parameters.Add(priceParameter);
        command.Parameters.Add(stationParameter);
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

    private void addCarriageBtn_Click(object sender, EventArgs e)
    {
      string wearout = wearoutTextBox.Text.ToString();
      string mileage = mileageTextBox.Text.ToString();
      string type = carriageTypeComboBox.Text.ToString();
      string station = carriageStationComboBox.Text.ToString();
      string price = repairPriceTextBox.Text.ToString();
      string placeCount = placesCountTextBox.Text.ToString();

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addCarriage", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter wearoutParameter = new SqlParameter
        {
          ParameterName = "@wearout",
          Value = wearout
        };

        SqlParameter mileageParameter = new SqlParameter
        {
          ParameterName = "@total_mileage",
          Value = mileage
        };

        SqlParameter typeParameter = new SqlParameter
        {
          ParameterName = "@carriage_type",
          Value = type
        };

        SqlParameter stationParameter = new SqlParameter
        {
          ParameterName = "@station_name",
          Value = station
        };

        SqlParameter priceParameter = new SqlParameter
        {
          ParameterName = "@repair_price",
          Value = price
        };

        SqlParameter placeCountParameter = new SqlParameter
        {
          ParameterName = "@place_count",
          Value = placeCount
        };

        command.Parameters.Add(wearoutParameter);
        command.Parameters.Add(mileageParameter);
        command.Parameters.Add(typeParameter);
        command.Parameters.Add(stationParameter);
        command.Parameters.Add(priceParameter);
        command.Parameters.Add(placeCountParameter);

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

    private void trainsDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int i = trainsDataGridView.CurrentRow.Index;
      string train_id = trainsDataGridView["#train", i].Value.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("removeTrain", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter idParameter = new SqlParameter
        {
          ParameterName = "@train_id",
          Value = train_id
        };

        command.Parameters.Add(idParameter);

        try
        {
          var result = command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
          MessageBox.Show("delete error", "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
    }

    private void carriagesDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int i = carriagesDataGridView.CurrentRow.Index;
      string carriage_id = carriagesDataGridView["#carriage", i].Value.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("removeCarriage", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter idParameter = new SqlParameter
        {
          ParameterName = "@carriage_id",
          Value = carriage_id
        };

        command.Parameters.Add(idParameter);

        try
        {
          var result = command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
          MessageBox.Show("delete error", "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
    }

    public void executeGetAvailableNeighourStations()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAvailableNeighourStations", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter stationParameter = new SqlParameter
        {
          ParameterName = "@station",
          Value = SelectedDepartStation
        };

        command.Parameters.Add(stationParameter);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        neighboursStationsDataGridView.DataSource = dataTable;
      }
    }

    public void executeGetAvailableTrains()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAvailableTrains", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter stationParameter = new SqlParameter
        {
          ParameterName = "@station",
          Value = SelectedDepartStation
        };

        command.Parameters.Add(stationParameter);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        availableTrainsDataGridView.DataSource = dataTable;
      }
    }

    private void stationsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int row = stationsDataGridView.CurrentCell.RowIndex;
      int column = stationsDataGridView.CurrentCell.ColumnIndex;
      SelectedDepartStation = stationsDataGridView[column, row].Value.ToString();
      executeGetAvailableNeighourStations();
      executeGetAvailableTrains();
    }

    private void neighboursStationsDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int row = neighboursStationsDataGridView.CurrentCell.RowIndex;
      SelectedArrivalStation = neighboursStationsDataGridView["arrival station", row].Value.ToString();
      Distance = Convert.ToDouble(neighboursStationsDataGridView["distance", row].Value.ToString());
    }

    private void availableTrainsDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int row = availableTrainsDataGridView.CurrentCell.RowIndex;
      double speed = Convert.ToDouble(availableTrainsDataGridView["speed", row].Value.ToString());
      Train = availableTrainsDataGridView["#train", row].Value.ToString();
      expectedTimeTextBox.Text = Convert.ToString(Math.Round((Distance / speed), 2));

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("dbo.getLastArrivalDateTrain", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@train_id", Train);
        
        command.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
        try
        {
          command.ExecuteNonQuery();
          string arrivalDate = command.Parameters["@return"].Value.ToString();
          lastArrivalDateTextBox.Text = arrivalDate;
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    private void createRoutePartBtn_Click(object sender, EventArgs e)
    {
      string train = Train.ToString();
      string arrivalStation = SelectedArrivalStation.ToString();
      string departureStation = selectedDepartStation.ToString();
      string arrival_date = Convert.ToString(arrivalDatePicker.Value.Date + arrivalTimePicker.Value.TimeOfDay);
      string departure_date = Convert.ToString(departureDatePicker.Value.Date + departureTimePicker.Value.TimeOfDay);
      string routeType;
      if (routeTypeCheckBox.Checked)
        routeType = "DEFAULT";
      else
        routeType = "WITHOUT PASSENGERS";

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addRoutePart", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@train_id", train);
        command.Parameters.AddWithValue("@arrival_station", arrivalStation);
        command.Parameters.AddWithValue("@departure_station", departureStation);
        command.Parameters.AddWithValue("@arrival_date", arrival_date);
        command.Parameters.AddWithValue("@departure_date", departure_date);
        command.Parameters.AddWithValue("@route_type", routeType);

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

    private void existsRoutesDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int row = existsRoutesDataGridView.CurrentCell.RowIndex;
      RoutePart = existsRoutesDataGridView["route part ID", row].Value.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAvailableCarriages", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@route_part_id", RoutePart);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        availableCarriagesDataGridView.DataSource = dataTable;
      }
    }

    private void availableCarriagesDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int row = availableCarriagesDataGridView.CurrentCell.RowIndex;
      string carriage = availableCarriagesDataGridView["#carriage", row].Value.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addCarriageRoute", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@carriage_id", carriage);
        command.Parameters.AddWithValue("@route_part_id", RoutePart);

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

    private void refreshBtn_Click(object sender, EventArgs e)
    {
      refreshData();
    }

    private void refreshBtn2_Click(object sender, EventArgs e)
    {
      refreshData();
    }

    private void carriagesDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {

    }

    private void addTrPostBtn_Click(object sender, EventArgs e)
    {
      string title = trPostTitleTextBox.Text.ToString();
      string exp = trExpTextBox.Text.ToString();
      string train = chooseTrComboBox.Text.ToString();

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addTrainPost", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@train_id", train);
        command.Parameters.AddWithValue("@title", title);
        command.Parameters.AddWithValue("@experience", exp);
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

    private void addStPostBtn_Click(object sender, EventArgs e)
    {
      string title = stPostTitleTextBox.Text.ToString();
      string exp = stExpTextBox.Text.ToString();
      string station = chooseStComboBox.Text.ToString();

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addStationPost", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@station", station);
        command.Parameters.AddWithValue("@title", title);
        command.Parameters.AddWithValue("@experience", exp);
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
    
    private void chooseTrComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      int train_id;
      string train = chooseTrComboBox.Text.ToString();
      if (!String.IsNullOrEmpty(train) && int.TryParse(train, out train_id))
      {
        using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
        {
          connection.Open();
          SqlCommand command = new SqlCommand("getTrainPosts", connection);
          command.CommandType = System.Data.CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@train_id", train);

          SqlDataAdapter dataAdapter = new SqlDataAdapter();
          dataAdapter.SelectCommand = command;

          DataTable dataTable = new DataTable();
          try
          {
            dataAdapter.Fill(dataTable);
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
          }
          trainPostsDataGridView.DataSource = dataTable;
          trainPostsDataGridView.Columns[0].Visible = false;
          trainPostsDataGridView.Columns[3].Visible = false;
        }
      }
    }

    private void chooseStComboBox_DropDown(object sender, EventArgs e)
    {
      string station = chooseStComboBox.Text.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getStationPosts", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@station", station);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        stationPostsDataGridView.DataSource = dataTable;
        stationPostsDataGridView.Columns[0].Visible = false;
        stationPostsDataGridView.Columns[3].Visible = false;
      }
    }

    private void backBtn_Click(object sender, EventArgs e)
    {
      RegForm.Show();
      this.Close();
    }

    private void routesRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if(routesRadioButton.Checked)
      {
        using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
        {
          connection.Open();
          SqlCommand command = new SqlCommand("getUsefulRoutes", connection);
          command.CommandType = System.Data.CommandType.StoredProcedure;

          SqlDataAdapter dataAdapter = new SqlDataAdapter();
          dataAdapter.SelectCommand = command;

          DataTable dataTable = new DataTable();
          dataAdapter.Fill(dataTable);

          statDataGridView.DataSource = dataTable;
        }
      }
    }

    private void runsRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (runsRadioButton.Checked)
      {

        using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
        {
          connection.Open();
          SqlCommand command = new SqlCommand("getUsefulRuns", connection);
          command.CommandType = System.Data.CommandType.StoredProcedure;

          SqlDataAdapter dataAdapter = new SqlDataAdapter();
          dataAdapter.SelectCommand = command;

          DataTable dataTable = new DataTable();
          dataAdapter.Fill(dataTable);

          statDataGridView.Refresh();
          statDataGridView.DataSource = dataTable;

        }
      }
    }

    private void usefulRoutesBtn_Click(object sender, EventArgs e)
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getUsefulRoutes", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        statDataGridView.DataSource = dataTable;
      }
    }

    private void usefulRunsBtn_Click(object sender, EventArgs e)
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getUsefulRuns", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        statDataGridView.Refresh();
        statDataGridView.DataSource = dataTable;
      }
    }

    private void repairBtn_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(expendedTextBox.Text.ToString()))
        return;

      int i = carriagesDataGridView.CurrentRow.Index;
      string carriage = carriagesComboBox.Text.ToString();

      DialogResult dialogResult = MessageBox.Show("Do you want to repair this carriage?", "repair carriage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (dialogResult == DialogResult.Yes)
      {
        using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
        {
          connection.Open();
          SqlCommand command = new SqlCommand("getLastArrivalDate", connection);
          command.CommandType = System.Data.CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@carriage_id", carriage);
          command.Parameters.Add("@return", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

          string arrivalDate = null;
          try
          {
            command.ExecuteNonQuery();
            arrivalDate = command.Parameters["@return"].Value.ToString();
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
          }

          SqlCommand repairCommand = new SqlCommand("repairCarriage", connection);
          repairCommand.CommandType = System.Data.CommandType.StoredProcedure;
          repairCommand.Parameters.AddWithValue("@carriage_id", carriage);
          repairCommand.Parameters.AddWithValue("@month", String.IsNullOrEmpty(arrivalDate) ? DateTime.Now.ToString("yyyy.dd.MM hh:mm:ss") : arrivalDate);
          repairCommand.Parameters.AddWithValue("@expended", expendedTextBox.Text.ToString());
          try
          {
            var repairResult = repairCommand.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Please, enter right data", "invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
          refreshData();
        }
      }
    }

    private void allCarriagesRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      executeGetAllExistsCarriages();
    }

    private void brokenCarriagesRadioButton_CheckedChanged(object sender, EventArgs e)
    {
      executeGetAllExistsCarriages();
    }
  }
}
