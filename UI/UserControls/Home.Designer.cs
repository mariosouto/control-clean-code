namespace UI.UserControls
{
    partial class Home
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
            this.mobileUnitsListBox = new System.Windows.Forms.ListBox();
            this.showMobileUnitscomboBox = new System.Windows.Forms.ComboBox();
            this.emergencyCallListBox = new System.Windows.Forms.ListBox();
            this.filterEmergencyCallGroupBox = new System.Windows.Forms.GroupBox();
            this.activeEmergencyCallsRadioButton = new System.Windows.Forms.RadioButton();
            this.solvedRadioButton = new System.Windows.Forms.RadioButton();
            this.mobilUnitslabel = new System.Windows.Forms.Label();
            this.emergencyCallLabel = new System.Windows.Forms.Label();
            this.viewMobileUnitInfoButton = new System.Windows.Forms.Button();
            this.viewInfoEmergencyCallButton = new System.Windows.Forms.Button();
            this.resolveEmergencyCallOfMobileButton = new System.Windows.Forms.Button();
            this.filterEmergencyCallGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobileUnitsListBox
            // 
            this.mobileUnitsListBox.FormattingEnabled = true;
            this.mobileUnitsListBox.Location = new System.Drawing.Point(154, 48);
            this.mobileUnitsListBox.Name = "mobileUnitsListBox";
            this.mobileUnitsListBox.Size = new System.Drawing.Size(194, 134);
            this.mobileUnitsListBox.TabIndex = 7;
            // 
            // showMobileUnitscomboBox
            // 
            this.showMobileUnitscomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showMobileUnitscomboBox.FormattingEnabled = true;
            this.showMobileUnitscomboBox.Items.AddRange(new object[] {
            "Todos los móviles",
            "Solo disponibles",
            "No disponibles"});
            this.showMobileUnitscomboBox.Location = new System.Drawing.Point(189, 188);
            this.showMobileUnitscomboBox.Name = "showMobileUnitscomboBox";
            this.showMobileUnitscomboBox.Size = new System.Drawing.Size(121, 21);
            this.showMobileUnitscomboBox.TabIndex = 9;
            this.showMobileUnitscomboBox.SelectedIndexChanged += new System.EventHandler(this.showMobileUnitscomboBox_SelectedIndexChanged);
            // 
            // emergencyCallListBox
            // 
            this.emergencyCallListBox.FormattingEnabled = true;
            this.emergencyCallListBox.Location = new System.Drawing.Point(420, 48);
            this.emergencyCallListBox.Name = "emergencyCallListBox";
            this.emergencyCallListBox.Size = new System.Drawing.Size(188, 134);
            this.emergencyCallListBox.TabIndex = 10;
            // 
            // filterEmergencyCallGroupBox
            // 
            this.filterEmergencyCallGroupBox.Controls.Add(this.activeEmergencyCallsRadioButton);
            this.filterEmergencyCallGroupBox.Controls.Add(this.solvedRadioButton);
            this.filterEmergencyCallGroupBox.Location = new System.Drawing.Point(420, 188);
            this.filterEmergencyCallGroupBox.Name = "filterEmergencyCallGroupBox";
            this.filterEmergencyCallGroupBox.Size = new System.Drawing.Size(188, 46);
            this.filterEmergencyCallGroupBox.TabIndex = 11;
            this.filterEmergencyCallGroupBox.TabStop = false;
            // 
            // activeEmergencyCallsRadioButton
            // 
            this.activeEmergencyCallsRadioButton.AutoSize = true;
            this.activeEmergencyCallsRadioButton.Location = new System.Drawing.Point(17, 18);
            this.activeEmergencyCallsRadioButton.Name = "activeEmergencyCallsRadioButton";
            this.activeEmergencyCallsRadioButton.Size = new System.Drawing.Size(60, 17);
            this.activeEmergencyCallsRadioButton.TabIndex = 6;
            this.activeEmergencyCallsRadioButton.TabStop = true;
            this.activeEmergencyCallsRadioButton.Text = "Activas";
            this.activeEmergencyCallsRadioButton.UseVisualStyleBackColor = true;
            this.activeEmergencyCallsRadioButton.CheckedChanged += new System.EventHandler(this.activeEmergencyCallsRadioButton_CheckedChanged);
            // 
            // solvedRadioButton
            // 
            this.solvedRadioButton.AutoSize = true;
            this.solvedRadioButton.Location = new System.Drawing.Point(106, 18);
            this.solvedRadioButton.Name = "solvedRadioButton";
            this.solvedRadioButton.Size = new System.Drawing.Size(72, 17);
            this.solvedRadioButton.TabIndex = 7;
            this.solvedRadioButton.TabStop = true;
            this.solvedRadioButton.Text = "Resueltas";
            this.solvedRadioButton.UseVisualStyleBackColor = true;
            // 
            // mobilUnitslabel
            // 
            this.mobilUnitslabel.AutoSize = true;
            this.mobilUnitslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobilUnitslabel.Location = new System.Drawing.Point(150, 21);
            this.mobilUnitslabel.Name = "mobilUnitslabel";
            this.mobilUnitslabel.Size = new System.Drawing.Size(164, 24);
            this.mobilUnitslabel.TabIndex = 12;
            this.mobilUnitslabel.Text = "Unidades Móviles:";
            // 
            // emergencyCallLabel
            // 
            this.emergencyCallLabel.AutoSize = true;
            this.emergencyCallLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emergencyCallLabel.Location = new System.Drawing.Point(416, 21);
            this.emergencyCallLabel.Name = "emergencyCallLabel";
            this.emergencyCallLabel.Size = new System.Drawing.Size(239, 24);
            this.emergencyCallLabel.TabIndex = 13;
            this.emergencyCallLabel.Text = "Llamadas de Emergencias:";
            // 
            // viewMobileUnitInfoButton
            // 
            this.viewMobileUnitInfoButton.Location = new System.Drawing.Point(212, 213);
            this.viewMobileUnitInfoButton.Name = "viewMobileUnitInfoButton";
            this.viewMobileUnitInfoButton.Size = new System.Drawing.Size(70, 21);
            this.viewMobileUnitInfoButton.TabIndex = 14;
            this.viewMobileUnitInfoButton.Text = "Ver datos";
            this.viewMobileUnitInfoButton.UseVisualStyleBackColor = true;
            this.viewMobileUnitInfoButton.Click += new System.EventHandler(this.viewInfoMobileUnitButton_Click);
            // 
            // viewInfoEmergencyCallButton
            // 
            this.viewInfoEmergencyCallButton.Location = new System.Drawing.Point(465, 240);
            this.viewInfoEmergencyCallButton.Name = "viewInfoEmergencyCallButton";
            this.viewInfoEmergencyCallButton.Size = new System.Drawing.Size(70, 21);
            this.viewInfoEmergencyCallButton.TabIndex = 15;
            this.viewInfoEmergencyCallButton.Text = "Ver datos";
            this.viewInfoEmergencyCallButton.UseVisualStyleBackColor = true;
            this.viewInfoEmergencyCallButton.Click += new System.EventHandler(this.viewInfoEmergencyCallButton_Click);
            // 
            // resolveEmergencyCallOfMobileButton
            // 
            this.resolveEmergencyCallOfMobileButton.Location = new System.Drawing.Point(212, 240);
            this.resolveEmergencyCallOfMobileButton.Name = "resolveEmergencyCallOfMobileButton";
            this.resolveEmergencyCallOfMobileButton.Size = new System.Drawing.Size(70, 21);
            this.resolveEmergencyCallOfMobileButton.TabIndex = 16;
            this.resolveEmergencyCallOfMobileButton.Text = "Resolver llamada asignada";
            this.resolveEmergencyCallOfMobileButton.UseVisualStyleBackColor = true;
            this.resolveEmergencyCallOfMobileButton.Click += new System.EventHandler(this.resolveEmergencyCallOfMobileButton_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resolveEmergencyCallOfMobileButton);
            this.Controls.Add(this.viewInfoEmergencyCallButton);
            this.Controls.Add(this.viewMobileUnitInfoButton);
            this.Controls.Add(this.emergencyCallLabel);
            this.Controls.Add(this.mobilUnitslabel);
            this.Controls.Add(this.filterEmergencyCallGroupBox);
            this.Controls.Add(this.emergencyCallListBox);
            this.Controls.Add(this.showMobileUnitscomboBox);
            this.Controls.Add(this.mobileUnitsListBox);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(789, 294);
            this.filterEmergencyCallGroupBox.ResumeLayout(false);
            this.filterEmergencyCallGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox mobileUnitsListBox;
        private System.Windows.Forms.ComboBox showMobileUnitscomboBox;
        private System.Windows.Forms.ListBox emergencyCallListBox;
        private System.Windows.Forms.GroupBox filterEmergencyCallGroupBox;
        private System.Windows.Forms.RadioButton activeEmergencyCallsRadioButton;
        private System.Windows.Forms.RadioButton solvedRadioButton;
        private System.Windows.Forms.Label mobilUnitslabel;
        private System.Windows.Forms.Label emergencyCallLabel;
        private System.Windows.Forms.Button viewMobileUnitInfoButton;
        private System.Windows.Forms.Button viewInfoEmergencyCallButton;
        private System.Windows.Forms.Button resolveEmergencyCallOfMobileButton;
    }
}
