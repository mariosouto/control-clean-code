namespace UI.UserControls
{
    partial class EmergencyCallManagement
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
            this.addEmergencyButton = new System.Windows.Forms.Button();
            this.setEmergencyCallAsSolveButton = new System.Windows.Forms.Button();
            this.emergencyCallListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.activeEmergencyCallsRadioButton = new System.Windows.Forms.RadioButton();
            this.solvedRadioButton = new System.Windows.Forms.RadioButton();
            this.filterEmergencyCallGroupBox = new System.Windows.Forms.GroupBox();
            this.viewInfoButton = new System.Windows.Forms.Button();
            this.filterEmergencyCallGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addEmergencyButton
            // 
            this.addEmergencyButton.Location = new System.Drawing.Point(266, 31);
            this.addEmergencyButton.Name = "addEmergencyButton";
            this.addEmergencyButton.Size = new System.Drawing.Size(104, 43);
            this.addEmergencyButton.TabIndex = 0;
            this.addEmergencyButton.Text = "Agregar llamada de emergencia";
            this.addEmergencyButton.UseVisualStyleBackColor = true;
            this.addEmergencyButton.Click += new System.EventHandler(this.AddEmergencyButton_Click);
            // 
            // setEmergencyCallAsSolveButton
            // 
            this.setEmergencyCallAsSolveButton.Location = new System.Drawing.Point(266, 129);
            this.setEmergencyCallAsSolveButton.Name = "setEmergencyCallAsSolveButton";
            this.setEmergencyCallAsSolveButton.Size = new System.Drawing.Size(104, 43);
            this.setEmergencyCallAsSolveButton.TabIndex = 1;
            this.setEmergencyCallAsSolveButton.Text = "Marcar como resuelta";
            this.setEmergencyCallAsSolveButton.UseVisualStyleBackColor = true;
            this.setEmergencyCallAsSolveButton.Click += new System.EventHandler(this.setEmergencyCallAsSolveButton_Click);
            // 
            // emergencyCallListBox
            // 
            this.emergencyCallListBox.FormattingEnabled = true;
            this.emergencyCallListBox.Location = new System.Drawing.Point(49, 25);
            this.emergencyCallListBox.Name = "emergencyCallListBox";
            this.emergencyCallListBox.Size = new System.Drawing.Size(188, 147);
            this.emergencyCallListBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(352, 251);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 40);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Volver a la pantalla principal";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(397, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(317, 199);
            this.panel.TabIndex = 5;
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
            // filterEmergencyCallGroupBox
            // 
            this.filterEmergencyCallGroupBox.Controls.Add(this.activeEmergencyCallsRadioButton);
            this.filterEmergencyCallGroupBox.Controls.Add(this.solvedRadioButton);
            this.filterEmergencyCallGroupBox.Location = new System.Drawing.Point(49, 178);
            this.filterEmergencyCallGroupBox.Name = "filterEmergencyCallGroupBox";
            this.filterEmergencyCallGroupBox.Size = new System.Drawing.Size(188, 46);
            this.filterEmergencyCallGroupBox.TabIndex = 8;
            this.filterEmergencyCallGroupBox.TabStop = false;
            // 
            // viewInfoButton
            // 
            this.viewInfoButton.Location = new System.Drawing.Point(266, 80);
            this.viewInfoButton.Name = "viewInfoButton";
            this.viewInfoButton.Size = new System.Drawing.Size(104, 43);
            this.viewInfoButton.TabIndex = 9;
            this.viewInfoButton.Text = "Ver datos";
            this.viewInfoButton.UseVisualStyleBackColor = true;
            this.viewInfoButton.Click += new System.EventHandler(this.viewInfoButton_Click);
            // 
            // EmergencyCallManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewInfoButton);
            this.Controls.Add(this.filterEmergencyCallGroupBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.emergencyCallListBox);
            this.Controls.Add(this.setEmergencyCallAsSolveButton);
            this.Controls.Add(this.addEmergencyButton);
            this.Name = "EmergencyCallManagement";
            this.Size = new System.Drawing.Size(789, 294);
            this.filterEmergencyCallGroupBox.ResumeLayout(false);
            this.filterEmergencyCallGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addEmergencyButton;
        private System.Windows.Forms.Button setEmergencyCallAsSolveButton;
        private System.Windows.Forms.ListBox emergencyCallListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RadioButton activeEmergencyCallsRadioButton;
        private System.Windows.Forms.RadioButton solvedRadioButton;
        private System.Windows.Forms.GroupBox filterEmergencyCallGroupBox;
        private System.Windows.Forms.Button viewInfoButton;
    }
}
