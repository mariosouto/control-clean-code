namespace UI
{
    partial class Main
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.mobileUnitManagementButton = new System.Windows.Forms.Button();
            this.EmergencyCallManagementButton = new System.Windows.Forms.Button();
            this.addTestDataButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.labelAssignMode = new System.Windows.Forms.Label();
            this.comboBoxAssignMode = new System.Windows.Forms.ComboBox();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de móviles";
            // 
            // controlPanel
            // 
            this.controlPanel.Location = new System.Drawing.Point(29, 97);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(789, 294);
            this.controlPanel.TabIndex = 1;
            // 
            // mobileUnitManagementButton
            // 
            this.mobileUnitManagementButton.Location = new System.Drawing.Point(85, 411);
            this.mobileUnitManagementButton.Name = "mobileUnitManagementButton";
            this.mobileUnitManagementButton.Size = new System.Drawing.Size(134, 43);
            this.mobileUnitManagementButton.TabIndex = 2;
            this.mobileUnitManagementButton.Text = "Manejo de Unidades Moviles";
            this.mobileUnitManagementButton.UseVisualStyleBackColor = true;
            this.mobileUnitManagementButton.Click += new System.EventHandler(this.mobileUnitManagementbutton_Click);
            // 
            // EmergencyCallManagementButton
            // 
            this.EmergencyCallManagementButton.Location = new System.Drawing.Point(250, 412);
            this.EmergencyCallManagementButton.Name = "EmergencyCallManagementButton";
            this.EmergencyCallManagementButton.Size = new System.Drawing.Size(134, 43);
            this.EmergencyCallManagementButton.TabIndex = 3;
            this.EmergencyCallManagementButton.Text = "Manejo de Llamadas de Emergencias";
            this.EmergencyCallManagementButton.UseVisualStyleBackColor = true;
            this.EmergencyCallManagementButton.Click += new System.EventHandler(this.emergencyCallManagementButton_Click);
            // 
            // addTestDataButton
            // 
            this.addTestDataButton.Location = new System.Drawing.Point(568, 411);
            this.addTestDataButton.Name = "addTestDataButton";
            this.addTestDataButton.Size = new System.Drawing.Size(134, 43);
            this.addTestDataButton.TabIndex = 4;
            this.addTestDataButton.Text = "Cargar datos de prueba";
            this.addTestDataButton.UseVisualStyleBackColor = true;
            this.addTestDataButton.Click += new System.EventHandler(this.addTestDataButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutButton.Location = new System.Drawing.Point(793, 409);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(25, 42);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "?";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // labelAssignMode
            // 
            this.labelAssignMode.AutoSize = true;
            this.labelAssignMode.Location = new System.Drawing.Point(266, 73);
            this.labelAssignMode.Name = "labelAssignMode";
            this.labelAssignMode.Size = new System.Drawing.Size(106, 13);
            this.labelAssignMode.TabIndex = 6;
            this.labelAssignMode.Text = "Modo de asignación:";
            // 
            // comboBoxAssignMode
            // 
            this.comboBoxAssignMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssignMode.FormattingEnabled = true;
            this.comboBoxAssignMode.Items.AddRange(new object[] {
            "Por defecto",
            "Tiempo de espera",
            "Cantidad de casos atendidos"});
            this.comboBoxAssignMode.Location = new System.Drawing.Point(378, 70);
            this.comboBoxAssignMode.Name = "comboBoxAssignMode";
            this.comboBoxAssignMode.Size = new System.Drawing.Size(165, 21);
            this.comboBoxAssignMode.TabIndex = 7;
            this.comboBoxAssignMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssignMode_SelectedIndexChanged);
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Location = new System.Drawing.Point(409, 412);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(134, 43);
            this.buttonStatistics.TabIndex = 8;
            this.buttonStatistics.Text = "Estadísticas";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 475);
            this.Controls.Add(this.buttonStatistics);
            this.Controls.Add(this.comboBoxAssignMode);
            this.Controls.Add(this.labelAssignMode);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.addTestDataButton);
            this.Controls.Add(this.EmergencyCallManagementButton);
            this.Controls.Add(this.mobileUnitManagementButton);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Gestión de móviles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button mobileUnitManagementButton;
        private System.Windows.Forms.Button EmergencyCallManagementButton;
        private System.Windows.Forms.Button addTestDataButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label labelAssignMode;
        private System.Windows.Forms.ComboBox comboBoxAssignMode;
        private System.Windows.Forms.Button buttonStatistics;
    }
}

