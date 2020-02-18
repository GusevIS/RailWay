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
  public partial class AccountantForm : Form
  { 
    public RegisterForm RegForm { get; set; }
    public DataBaseHandler DbHandler { get; set; }
 
    public AccountantForm(RegisterForm registerForm, DataBaseHandler dbHandler)
    {
      this.RegForm = registerForm;
      this.DbHandler = dbHandler;
      InitializeComponent();
      refreshData();
    }

    public void refreshData()
    {
      executeGetAllTrains();
      executeGetExistsStations();
      executeGetTotalSalary();
      executeGetAvgSalary();
      executeGetMinSalary();
      executeGetMaxSalary();
      executeGetUniquePosts();
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

        trNComboBox.DataSource = dataTable;
        trNComboBox.DisplayMember = "id";
        trNComboBox.ValueMember = "train_id";
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

        stNComboBox.DataSource = dataTable;
        stNComboBox.DisplayMember = "id";
        stNComboBox.ValueMember = "station";
      }
    }

    public void executeGetTotalSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getTotalSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@station", stCheckBox.Checked.ToString());
        command.Parameters.AddWithValue("@train", trCheckBox.Checked.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          totalSalarytextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetAvgSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAvgSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@station", stCheckBox.Checked.ToString());
        command.Parameters.AddWithValue("@train", trCheckBox.Checked.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          avgSalarytextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetMinSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getMinSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@station", stCheckBox.Checked.ToString());
        command.Parameters.AddWithValue("@train", trCheckBox.Checked.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          minSalarytextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetMaxSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getMaxSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@station", stCheckBox.Checked.ToString());
        command.Parameters.AddWithValue("@train", trCheckBox.Checked.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          maxSalarytextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetUniquePosts()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getUniquePosts", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        unComboBox.DataSource = dataTable;
        unComboBox.DisplayMember = "id";
        unComboBox.ValueMember = "post";
      }
    }

    public void executeGetPostTotalSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getPostTotalSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@post", unComboBox.Text.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          totalUnTextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetPostMaxSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getPostMaxSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@post", unComboBox.Text.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          maxUnTextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetPostMinSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getPostMinSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@post", unComboBox.Text.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          minUnTextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetPostAvgSalary()
    {
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getPostAvgSalary", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@post", unComboBox.Text.ToString());

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          avgUnTextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    public void executeGetSalaryExp()
    {
      string from = fromTextBox.Text.ToString();
      string to = toTextBox.Text.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getAvgExp", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        if (!String.IsNullOrEmpty(from) && String.IsNullOrEmpty(to))
          command.Parameters.AddWithValue("@expFrom", from);
        else
        if (String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
          command.Parameters.AddWithValue("@expTo", to);
        else
        if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
        {
          command.Parameters.AddWithValue("@expFrom", from);
          command.Parameters.AddWithValue("@expTo", to);
        }

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          avgPostSalaryTextBox.Text = reader["salary"].ToString();
        }
        reader.Close();
      }
    }

    private void refreshBtn_Click(object sender, EventArgs e)
    {
      refreshData();
    }

    private void trAddEmBtn_Click(object sender, EventArgs e)
    {
      string name = trNameTextBox.Text.ToString();
      string salary = trSalaryTextBox.Text.ToString();
      string exp = trExpTextBox.Text.ToString();
      string edu = trEdTextBox.Text.ToString();
      string post = trPostIdComboBox.Text.ToString();

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addTrainStaff", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@salary", salary);
        command.Parameters.AddWithValue("@exp", exp);
        command.Parameters.AddWithValue("@edu", edu);
        command.Parameters.AddWithValue("@post", post);
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

    private void trPostComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string post = trPostComboBox.Text.ToString();
      string train = trNComboBox.Text.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getTrPostsCount", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@post", post);
        command.Parameters.AddWithValue("@train_id", train);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        trPostIdComboBox.DataSource = dataTable;
        trPostIdComboBox.DisplayMember = "id";
        trPostIdComboBox.ValueMember = "#post";
      }
    }

    private void stAddEmBtn_Click(object sender, EventArgs e)
    {
      string name = stNameTextBox.Text.ToString();
      string salary = stSalaryTextBox.Text.ToString();
      string exp = stExpTextBox.Text.ToString();
      string edu = stEdTextBox.Text.ToString();
      string post = stPostIdComboBox.Text.ToString();

      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("addStationStaff", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@salary", salary);
        command.Parameters.AddWithValue("@exp", exp);
        command.Parameters.AddWithValue("@edu", edu);
        command.Parameters.AddWithValue("@post", post);
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

    private void stPostComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string post = stPostComboBox.Text.ToString();
      string station = stNComboBox.Text.ToString();
      using (SqlConnection connection = new SqlConnection(DbHandler.ConnectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("getStPostsCount", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@post", post);
        command.Parameters.AddWithValue("@station", station);

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = command;

        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);

        stPostIdComboBox.DataSource = dataTable;
        stPostIdComboBox.DisplayMember = "id";
        stPostIdComboBox.ValueMember = "#post";
      }
    }

    private void stCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      executeGetTotalSalary();
      executeGetAvgSalary();
      executeGetMinSalary();
      executeGetMaxSalary();
    }

    private void trCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      executeGetTotalSalary();
      executeGetAvgSalary();
      executeGetMinSalary();
      executeGetMaxSalary();
    }

    private void showPostBtn_Click(object sender, EventArgs e)
    {
      executeGetPostAvgSalary();
      executeGetPostTotalSalary();
      executeGetPostMinSalary();
      executeGetPostMaxSalary();
    }

    private void showBtn_Click(object sender, EventArgs e)
    {
      executeGetSalaryExp();
    }

    private void backBtn_Click(object sender, EventArgs e)
    {
      RegForm.Show();
      this.Close();
    }

    private void showTrEmpBtn_Click(object sender, EventArgs e)
    {
      string train = trNComboBox.Text.ToString();
      if (!String.IsNullOrEmpty(train))
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
          trPostComboBox.DataSource = dataTable;
          trPostComboBox.DisplayMember = "id";
          trPostComboBox.ValueMember = "post";


          SqlCommand command2 = new SqlCommand("getTrainStaff", connection);
          command2.CommandType = System.Data.CommandType.StoredProcedure;
          command2.Parameters.AddWithValue("@train_id", train);

          SqlDataAdapter dataAdapter2 = new SqlDataAdapter();
          dataAdapter2.SelectCommand = command2;

          DataTable dataTable2 = new DataTable();
          try
          {
            dataAdapter2.Fill(dataTable2);
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
          }
          trainStaffDataGridView.DataSource = dataTable2;
        }
      }
    }

    private void showStEmpBtn_Click(object sender, EventArgs e)
    {
      string station = stNComboBox.Text.ToString();
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

        stPostComboBox.DataSource = dataTable;
        stPostComboBox.DisplayMember = "id";
        stPostComboBox.ValueMember = "post";

        SqlCommand command2 = new SqlCommand("getStationStaff", connection);
        command2.CommandType = System.Data.CommandType.StoredProcedure;
        command2.Parameters.AddWithValue("@station", station);

        SqlDataAdapter dataAdapter2 = new SqlDataAdapter();
        dataAdapter2.SelectCommand = command2;

        DataTable dataTable2 = new DataTable();
        try
        {
          dataAdapter2.Fill(dataTable2);
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
        }
        stationStaffDataGridView.DataSource = dataTable2;
      //  stationStaffDataGridView.Columns[2].Visible = false;
      }
    }
  }
}
