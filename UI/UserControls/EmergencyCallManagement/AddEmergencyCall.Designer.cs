namespace UI.UserControls
{
    partial class AddEmergencyCall
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.urgencyLevelLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.urgencyLevelComboBox = new System.Windows.Forms.ComboBox();
            this.aceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(21, 6);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(66, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Descripcion:";
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(21, 57);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(42, 13);
            this.latitudeLabel.TabIndex = 1;
            this.latitudeLabel.Text = "Latitud:";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(22, 90);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(51, 13);
            this.longitudeLabel.TabIndex = 2;
            this.longitudeLabel.Text = "Longitud:";
            // 
            // urgencyLevelLabel
            // 
            this.urgencyLevelLabel.AutoSize = true;
            this.urgencyLevelLabel.Location = new System.Drawing.Point(22, 117);
            this.urgencyLevelLabel.Name = "urgencyLevelLabel";
            this.urgencyLevelLabel.Size = new System.Drawing.Size(93, 13);
            this.urgencyLevelLabel.TabIndex = 3;
            this.urgencyLevelLabel.Text = "Nivel de urgencia:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(120, 6);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(162, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Location = new System.Drawing.Point(120, 57);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.Size = new System.Drawing.Size(162, 20);
            this.latitudeTextBox.TabIndex = 3;
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Location = new System.Drawing.Point(120, 87);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.Size = new System.Drawing.Size(162, 20);
            this.longitudeTextBox.TabIndex = 4;
            // 
            // urgencyLevelComboBox
            // 
            this.urgencyLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.urgencyLevelComboBox.FormattingEnabled = true;
            this.urgencyLevelComboBox.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.urgencyLevelComboBox.Location = new System.Drawing.Point(121, 114);
            this.urgencyLevelComboBox.Name = "urgencyLevelComboBox";
            this.urgencyLevelComboBox.Size = new System.Drawing.Size(161, 21);
            this.urgencyLevelComboBox.TabIndex = 5;
            // 
            // aceptButton
            // 
            this.aceptButton.Location = new System.Drawing.Point(68, 173);
            this.aceptButton.Name = "aceptButton";
            this.aceptButton.Size = new System.Drawing.Size(75, 23);
            this.aceptButton.TabIndex = 10;
            this.aceptButton.Text = "Aceptar";
            this.aceptButton.UseVisualStyleBackColor = true;
            this.aceptButton.Click += new System.EventHandler(this.aceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(161, 173);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(23, 152);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(40, 13);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "Fecha:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(121, 146);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(161, 20);
            this.dateTimePicker.TabIndex = 6;
            this.dateTimePicker.Value = new System.DateTime(2019, 5, 14, 12, 0, 0, 0);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(120, 32);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(162, 20);
            this.addressTextBox.TabIndex = 2;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(21, 32);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(55, 13);
            this.addressLabel.TabIndex = 14;
            this.addressLabel.Text = "Dirección:";
            // 
            // AddEmergencyCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.aceptButton);
            this.Controls.Add(this.urgencyLevelComboBox);
            this.Controls.Add(this.longitudeTextBox);
            this.Controls.Add(this.latitudeTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.urgencyLevelLabel);
            this.Controls.Add(this.longitudeLabel);
            this.Controls.Add(this.latitudeLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Name = "AddEmergencyCall";
            this.Size = new System.Drawing.Size(317, 199);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.Label urgencyLevelLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.ComboBox urgencyLevelComboBox;
        private System.Windows.Forms.Button aceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label addressLabel;
    }
}