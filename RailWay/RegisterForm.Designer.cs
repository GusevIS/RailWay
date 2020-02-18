namespace RailWay
{
  partial class RegisterForm
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.passportTextBox = new System.Windows.Forms.TextBox();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.signInBtn = new System.Windows.Forms.Button();
      this.signUpBtn = new System.Windows.Forms.Button();
      this.employeeSignInBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // passportTextBox
      // 
      this.passportTextBox.Location = new System.Drawing.Point(86, 146);
      this.passportTextBox.Name = "passportTextBox";
      this.passportTextBox.Size = new System.Drawing.Size(100, 20);
      this.passportTextBox.TabIndex = 0;
      // 
      // nameTextBox
      // 
      this.nameTextBox.Location = new System.Drawing.Point(86, 97);
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.Size = new System.Drawing.Size(100, 20);
      this.nameTextBox.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(95, 81);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Enter your name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(88, 130);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(98, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Enter your passport";
      // 
      // signInBtn
      // 
      this.signInBtn.Location = new System.Drawing.Point(98, 172);
      this.signInBtn.Name = "signInBtn";
      this.signInBtn.Size = new System.Drawing.Size(75, 23);
      this.signInBtn.TabIndex = 4;
      this.signInBtn.Text = "SIGN IN";
      this.signInBtn.UseVisualStyleBackColor = true;
      this.signInBtn.Click += new System.EventHandler(this.signInBtn_Click);
      // 
      // signUpBtn
      // 
      this.signUpBtn.Location = new System.Drawing.Point(98, 201);
      this.signUpBtn.Name = "signUpBtn";
      this.signUpBtn.Size = new System.Drawing.Size(75, 23);
      this.signUpBtn.TabIndex = 5;
      this.signUpBtn.Text = "SIGN UP";
      this.signUpBtn.UseVisualStyleBackColor = true;
      this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
      // 
      // employeeSignInBtn
      // 
      this.employeeSignInBtn.Location = new System.Drawing.Point(98, 278);
      this.employeeSignInBtn.Name = "employeeSignInBtn";
      this.employeeSignInBtn.Size = new System.Drawing.Size(75, 43);
      this.employeeSignInBtn.TabIndex = 6;
      this.employeeSignInBtn.Text = "Sign in as employee";
      this.employeeSignInBtn.UseVisualStyleBackColor = true;
      this.employeeSignInBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.employeeSignIn_MouseClick);
      // 
      // RegisterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 361);
      this.Controls.Add(this.employeeSignInBtn);
      this.Controls.Add(this.signUpBtn);
      this.Controls.Add(this.signInBtn);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.nameTextBox);
      this.Controls.Add(this.passportTextBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "RegisterForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Registration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox passportTextBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button signInBtn;
    private System.Windows.Forms.Button signUpBtn;
    private System.Windows.Forms.Button employeeSignInBtn;
  }
}

