namespace RailWay
{
  partial class PassengerForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.PassengerTabControl = new System.Windows.Forms.TabControl();
      this.MyTicketsTab = new System.Windows.Forms.TabPage();
      this.myTicketsDataGridView = new System.Windows.Forms.DataGridView();
      this.BuyTicketTab = new System.Windows.Forms.TabPage();
      this.PlacesLabel = new System.Windows.Forms.Label();
      this.placesDataGridView = new System.Windows.Forms.DataGridView();
      this.freeSeatsCheckBox = new System.Windows.Forms.CheckBox();
      this.depDtCheckBox = new System.Windows.Forms.CheckBox();
      this.arStCheckBox = new System.Windows.Forms.CheckBox();
      this.departureDatePicker = new System.Windows.Forms.DateTimePicker();
      this.label6 = new System.Windows.Forms.Label();
      this.arrivalStationComboBox = new System.Windows.Forms.ComboBox();
      this.departureStationComboBox = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.allRoutesDataGridView = new System.Windows.Forms.DataGridView();
      this.pasNameLabel = new System.Windows.Forms.Label();
      this.refreshBtn = new System.Windows.Forms.Button();
      this.backBtn = new System.Windows.Forms.Button();
      this.PassengerTabControl.SuspendLayout();
      this.MyTicketsTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.myTicketsDataGridView)).BeginInit();
      this.BuyTicketTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.placesDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.allRoutesDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // PassengerTabControl
      // 
      this.PassengerTabControl.Controls.Add(this.MyTicketsTab);
      this.PassengerTabControl.Controls.Add(this.BuyTicketTab);
      this.PassengerTabControl.Location = new System.Drawing.Point(12, 32);
      this.PassengerTabControl.Name = "PassengerTabControl";
      this.PassengerTabControl.SelectedIndex = 0;
      this.PassengerTabControl.Size = new System.Drawing.Size(850, 317);
      this.PassengerTabControl.TabIndex = 0;
      // 
      // MyTicketsTab
      // 
      this.MyTicketsTab.Controls.Add(this.myTicketsDataGridView);
      this.MyTicketsTab.Location = new System.Drawing.Point(4, 22);
      this.MyTicketsTab.Name = "MyTicketsTab";
      this.MyTicketsTab.Padding = new System.Windows.Forms.Padding(3);
      this.MyTicketsTab.Size = new System.Drawing.Size(842, 291);
      this.MyTicketsTab.TabIndex = 0;
      this.MyTicketsTab.Text = "My tickets";
      this.MyTicketsTab.UseVisualStyleBackColor = true;
      // 
      // myTicketsDataGridView
      // 
      this.myTicketsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.myTicketsDataGridView.Location = new System.Drawing.Point(6, 6);
      this.myTicketsDataGridView.Name = "myTicketsDataGridView";
      this.myTicketsDataGridView.Size = new System.Drawing.Size(830, 279);
      this.myTicketsDataGridView.TabIndex = 0;
      this.myTicketsDataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.myTicketsDataGridView_RowHeaderMouseClick);
      // 
      // BuyTicketTab
      // 
      this.BuyTicketTab.Controls.Add(this.PlacesLabel);
      this.BuyTicketTab.Controls.Add(this.placesDataGridView);
      this.BuyTicketTab.Controls.Add(this.freeSeatsCheckBox);
      this.BuyTicketTab.Controls.Add(this.depDtCheckBox);
      this.BuyTicketTab.Controls.Add(this.arStCheckBox);
      this.BuyTicketTab.Controls.Add(this.departureDatePicker);
      this.BuyTicketTab.Controls.Add(this.label6);
      this.BuyTicketTab.Controls.Add(this.arrivalStationComboBox);
      this.BuyTicketTab.Controls.Add(this.departureStationComboBox);
      this.BuyTicketTab.Controls.Add(this.label3);
      this.BuyTicketTab.Controls.Add(this.label2);
      this.BuyTicketTab.Controls.Add(this.label1);
      this.BuyTicketTab.Controls.Add(this.allRoutesDataGridView);
      this.BuyTicketTab.Location = new System.Drawing.Point(4, 22);
      this.BuyTicketTab.Name = "BuyTicketTab";
      this.BuyTicketTab.Padding = new System.Windows.Forms.Padding(3);
      this.BuyTicketTab.Size = new System.Drawing.Size(842, 291);
      this.BuyTicketTab.TabIndex = 1;
      this.BuyTicketTab.Text = "Routes";
      this.BuyTicketTab.UseVisualStyleBackColor = true;
      // 
      // PlacesLabel
      // 
      this.PlacesLabel.AutoSize = true;
      this.PlacesLabel.Location = new System.Drawing.Point(673, 3);
      this.PlacesLabel.Name = "PlacesLabel";
      this.PlacesLabel.Size = new System.Drawing.Size(39, 13);
      this.PlacesLabel.TabIndex = 34;
      this.PlacesLabel.Text = "Places";
      // 
      // placesDataGridView
      // 
      this.placesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.placesDataGridView.Location = new System.Drawing.Point(546, 23);
      this.placesDataGridView.Name = "placesDataGridView";
      this.placesDataGridView.Size = new System.Drawing.Size(290, 156);
      this.placesDataGridView.TabIndex = 33;
      this.placesDataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.placesDataGridView_RowHeaderMouseClick);
      // 
      // freeSeatsCheckBox
      // 
      this.freeSeatsCheckBox.AutoSize = true;
      this.freeSeatsCheckBox.Location = new System.Drawing.Point(351, 215);
      this.freeSeatsCheckBox.Name = "freeSeatsCheckBox";
      this.freeSeatsCheckBox.Size = new System.Drawing.Size(72, 17);
      this.freeSeatsCheckBox.TabIndex = 32;
      this.freeSeatsCheckBox.Text = "free seats";
      this.freeSeatsCheckBox.UseVisualStyleBackColor = true;
      this.freeSeatsCheckBox.CheckedChanged += new System.EventHandler(this.freeSeatsCheckBox_CheckedChanged);
      // 
      // depDtCheckBox
      // 
      this.depDtCheckBox.AutoSize = true;
      this.depDtCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.depDtCheckBox.Location = new System.Drawing.Point(299, 253);
      this.depDtCheckBox.Name = "depDtCheckBox";
      this.depDtCheckBox.Size = new System.Drawing.Size(15, 14);
      this.depDtCheckBox.TabIndex = 30;
      this.depDtCheckBox.UseVisualStyleBackColor = true;
      this.depDtCheckBox.CheckedChanged += new System.EventHandler(this.depDtCheckBox_CheckedChanged);
      // 
      // arStCheckBox
      // 
      this.arStCheckBox.AutoSize = true;
      this.arStCheckBox.Location = new System.Drawing.Point(299, 215);
      this.arStCheckBox.Name = "arStCheckBox";
      this.arStCheckBox.Size = new System.Drawing.Size(15, 14);
      this.arStCheckBox.TabIndex = 29;
      this.arStCheckBox.UseVisualStyleBackColor = true;
      this.arStCheckBox.CheckedChanged += new System.EventHandler(this.arStCheckBox_CheckedChanged);
      // 
      // departureDatePicker
      // 
      this.departureDatePicker.CustomFormat = "yyyy/dd/MM";
      this.departureDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.departureDatePicker.Location = new System.Drawing.Point(188, 253);
      this.departureDatePicker.Name = "departureDatePicker";
      this.departureDatePicker.Size = new System.Drawing.Size(105, 20);
      this.departureDatePicker.TabIndex = 25;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(203, 237);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(76, 13);
      this.label6.TabIndex = 22;
      this.label6.Text = "departure date";
      // 
      // arrivalStationComboBox
      // 
      this.arrivalStationComboBox.FormattingEnabled = true;
      this.arrivalStationComboBox.Location = new System.Drawing.Point(161, 213);
      this.arrivalStationComboBox.Name = "arrivalStationComboBox";
      this.arrivalStationComboBox.Size = new System.Drawing.Size(132, 21);
      this.arrivalStationComboBox.TabIndex = 13;
      // 
      // departureStationComboBox
      // 
      this.departureStationComboBox.FormattingEnabled = true;
      this.departureStationComboBox.Location = new System.Drawing.Point(24, 212);
      this.departureStationComboBox.Name = "departureStationComboBox";
      this.departureStationComboBox.Size = new System.Drawing.Size(132, 21);
      this.departureStationComboBox.TabIndex = 12;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(203, 197);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "arrival station";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(49, 197);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "departure station";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(243, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Routes";
      // 
      // allRoutesDataGridView
      // 
      this.allRoutesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.allRoutesDataGridView.Location = new System.Drawing.Point(6, 23);
      this.allRoutesDataGridView.Name = "allRoutesDataGridView";
      this.allRoutesDataGridView.Size = new System.Drawing.Size(534, 156);
      this.allRoutesDataGridView.TabIndex = 0;
      this.allRoutesDataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.allRoutesDataGridView_RowHeaderMouseClick);
      // 
      // pasNameLabel
      // 
      this.pasNameLabel.AutoSize = true;
      this.pasNameLabel.Location = new System.Drawing.Point(19, 9);
      this.pasNameLabel.Name = "pasNameLabel";
      this.pasNameLabel.Size = new System.Drawing.Size(33, 13);
      this.pasNameLabel.TabIndex = 1;
      this.pasNameLabel.Text = "name";
      // 
      // refreshBtn
      // 
      this.refreshBtn.Location = new System.Drawing.Point(64, 4);
      this.refreshBtn.Name = "refreshBtn";
      this.refreshBtn.Size = new System.Drawing.Size(75, 23);
      this.refreshBtn.TabIndex = 2;
      this.refreshBtn.Text = "Refresh";
      this.refreshBtn.UseVisualStyleBackColor = true;
      this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
      // 
      // backBtn
      // 
      this.backBtn.Location = new System.Drawing.Point(145, 4);
      this.backBtn.Name = "backBtn";
      this.backBtn.Size = new System.Drawing.Size(75, 23);
      this.backBtn.TabIndex = 3;
      this.backBtn.Text = "back";
      this.backBtn.UseVisualStyleBackColor = true;
      this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
      // 
      // PassengerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(874, 361);
      this.Controls.Add(this.backBtn);
      this.Controls.Add(this.refreshBtn);
      this.Controls.Add(this.pasNameLabel);
      this.Controls.Add(this.PassengerTabControl);
      this.Name = "PassengerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "PassengerForm";
      this.PassengerTabControl.ResumeLayout(false);
      this.MyTicketsTab.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.myTicketsDataGridView)).EndInit();
      this.BuyTicketTab.ResumeLayout(false);
      this.BuyTicketTab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.placesDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.allRoutesDataGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl PassengerTabControl;
    private System.Windows.Forms.TabPage MyTicketsTab;
    private System.Windows.Forms.TabPage BuyTicketTab;
    private System.Windows.Forms.DataGridView myTicketsDataGridView;
    private System.Windows.Forms.Label pasNameLabel;
    private System.Windows.Forms.DataGridView allRoutesDataGridView;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button refreshBtn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox arrivalStationComboBox;
    private System.Windows.Forms.ComboBox departureStationComboBox;
    private System.Windows.Forms.DateTimePicker departureDatePicker;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox depDtCheckBox;
    private System.Windows.Forms.CheckBox arStCheckBox;
    private System.Windows.Forms.CheckBox freeSeatsCheckBox;
    private System.Windows.Forms.Label PlacesLabel;
    private System.Windows.Forms.DataGridView placesDataGridView;
    private System.Windows.Forms.Button backBtn;
  }
}