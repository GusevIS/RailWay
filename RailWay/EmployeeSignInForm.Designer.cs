﻿namespace RailWay
{
  partial class EmployeeSignInForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.signInBtn = new System.Windows.Forms.Button();
      this.signInTextBox = new System.Windows.Forms.TextBox();
      this.backBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(101, 49);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(80, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter password";
      // 
      // signInBtn
      // 
      this.signInBtn.Location = new System.Drawing.Point(104, 91);
      this.signInBtn.Name = "signInBtn";
      this.signInBtn.Size = new System.Drawing.Size(75, 23);
      this.signInBtn.TabIndex = 1;
      this.signInBtn.Text = "Sign In";
      this.signInBtn.UseVisualStyleBackColor = true;
      this.signInBtn.Click += new System.EventHandler(this.signInBtn_Click);
      // 
      // signInTextBox
      // 
      this.signInTextBox.Location = new System.Drawing.Point(90, 65);
      this.signInTextBox.Name = "signInTextBox";
      this.signInTextBox.Size = new System.Drawing.Size(100, 20);
      this.signInTextBox.TabIndex = 2;
      // 
      // backBtn
      // 
      this.backBtn.Location = new System.Drawing.Point(104, 120);
      this.backBtn.Name = "backBtn";
      this.backBtn.Size = new System.Drawing.Size(75, 23);
      this.backBtn.TabIndex = 3;
      this.backBtn.Text = "Back";
      this.backBtn.UseVisualStyleBackColor = true;
      this.backBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backBtn_MouseClick);
      // 
      // EmployeeSignInForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 161);
      this.Controls.Add(this.backBtn);
      this.Controls.Add(this.signInTextBox);
      this.Controls.Add(this.signInBtn);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.Name = "EmployeeSignInForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "employee sign in";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeSignInForm_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button signInBtn;
    private System.Windows.Forms.TextBox signInTextBox;
    private System.Windows.Forms.Button backBtn;
  }
}