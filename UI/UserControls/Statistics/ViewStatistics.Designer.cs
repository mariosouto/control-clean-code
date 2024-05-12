namespace UI.UserControls.Statistics
{
    partial class ViewStatistics
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
            this.backToHomeButton = new System.Windows.Forms.Button();
            this.mobilUnitslabel = new System.Windows.Forms.Label();
            this.mobileUnitsListBox = new System.Windows.Forms.ListBox();
            this.comboBoxAssignModeStatistics = new System.Windows.Forms.ComboBox();
            this.labelAssignMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAverageAssignmentTime = new System.Windows.Forms.Label();
            this.labelAverageSolvedTime = new System.Windows.Forms.Label();
            this.labelAverageTotalSolvedTime = new System.Windows.Forms.Label();
            this.labelShowAverageAssignamentTime = new System.Windows.Forms.Label();
            this.labelShowAverageSolvedTime = new System.Windows.Forms.Label();
            this.labelShowAverageTotalSolvedTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backToHomeButton
            // 
            this.backToHomeButton.Location = new System.Drawing.Point(352, 251);
            this.backToHomeButton.Name = "backToHomeButton";
            this.backToHomeButton.Size = new System.Drawing.Size(96, 40);
            this.backToHomeButton.TabIndex = 6;
            this.backToHomeButton.Text = "Volver a la pantalla principal";
            this.backToHomeButton.UseVisualStyleBackColor = true;
            this.backToHomeButton.Click += new System.EventHandler(this.backToHomeButton_Click);
            // 
            // mobilUnitslabel
            // 
            this.mobilUnitslabel.AutoSize = true;
            this.mobilUnitslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobilUnitslabel.Location = new System.Drawing.Point(114, 30);
            this.mobilUnitslabel.Name = "mobilUnitslabel";
            this.mobilUnitslabel.Size = new System.Drawing.Size(164, 24);
            this.mobilUnitslabel.TabIndex = 14;
            this.mobilUnitslabel.Text = "Unidades Móviles:";
            // 
            // mobileUnitsListBox
            // 
            this.mobileUnitsListBox.FormattingEnabled = true;
            this.mobileUnitsListBox.Location = new System.Drawing.Point(118, 57);
            this.mobileUnitsListBox.Name = "mobileUnitsListBox";
            this.mobileUnitsListBox.Size = new System.Drawing.Size(194, 134);
            this.mobileUnitsListBox.TabIndex = 13;
            this.mobileUnitsListBox.SelectedIndexChanged += new System.EventHandler(this.mobileUnitsListBox_SelectedIndexChanged);
            // 
            // comboBoxAssignModeStatistics
            // 
            this.comboBoxAssignModeStatistics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssignModeStatistics.FormattingEnabled = true;
            this.comboBoxAssignModeStatistics.Items.AddRange(new object[] {
            "Todos los modos",
            "Por defecto",
            "Tiempo de espera",
            "Cantidad de casos atendidos"});
            this.comboBoxAssignModeStatistics.Location = new System.Drawing.Point(188, 197);
            this.comboBoxAssignModeStatistics.Name = "comboBoxAssignModeStatistics";
            this.comboBoxAssignModeStatistics.Size = new System.Drawing.Size(165, 21);
            this.comboBoxAssignModeStatistics.TabIndex = 16;
            this.comboBoxAssignModeStatistics.SelectedValueChanged += new System.EventHandler(this.comboBoxAssignModeStatistics_SelectedValueChanged);
            // 
            // labelAssignMode
            // 
            this.labelAssignMode.AutoSize = true;
            this.labelAssignMode.Location = new System.Drawing.Point(76, 200);
            this.labelAssignMode.Name = "labelAssignMode";
            this.labelAssignMode.Size = new System.Drawing.Size(106, 13);
            this.labelAssignMode.TabIndex = 15;
            this.labelAssignMode.Text = "Modo de asignación:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // labelAverageAssignmentTime
            // 
            this.labelAverageAssignmentTime.AutoSize = true;
            this.labelAverageAssignmentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageAssignmentTime.Location = new System.Drawing.Point(414, 57);
            this.labelAverageAssignmentTime.Name = "labelAverageAssignmentTime";
            this.labelAverageAssignmentTime.Size = new System.Drawing.Size(241, 20);
            this.labelAverageAssignmentTime.TabIndex = 17;
            this.labelAverageAssignmentTime.Text = "Tiempo medio de asignación:";
            // 
            // labelAverageSolvedTime
            // 
            this.labelAverageSolvedTime.AutoSize = true;
            this.labelAverageSolvedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageSolvedTime.Location = new System.Drawing.Point(414, 104);
            this.labelAverageSolvedTime.Name = "labelAverageSolvedTime";
            this.labelAverageSolvedTime.Size = new System.Drawing.Size(237, 20);
            this.labelAverageSolvedTime.TabIndex = 18;
            this.labelAverageSolvedTime.Text = "Tiempo medio de resolución:";
            // 
            // labelAverageTotalSolvedTime
            // 
            this.labelAverageTotalSolvedTime.AutoSize = true;
            this.labelAverageTotalSolvedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageTotalSolvedTime.Location = new System.Drawing.Point(414, 151);
            this.labelAverageTotalSolvedTime.Name = "labelAverageTotalSolvedTime";
            this.labelAverageTotalSolvedTime.Size = new System.Drawing.Size(277, 20);
            this.labelAverageTotalSolvedTime.TabIndex = 19;
            this.labelAverageTotalSolvedTime.Text = "Tiempo medio total de asistencia:";
            // 
            // labelShowAverageAssignamentTime
            // 
            this.labelShowAverageAssignamentTime.AutoSize = true;
            this.labelShowAverageAssignamentTime.Location = new System.Drawing.Point(418, 84);
            this.labelShowAverageAssignamentTime.Name = "labelShowAverageAssignamentTime";
            this.labelShowAverageAssignamentTime.Size = new System.Drawing.Size(149, 13);
            this.labelShowAverageAssignamentTime.TabIndex = 20;
            this.labelShowAverageAssignamentTime.Text = "showAverageAssignmentTime";
            // 
            // labelShowAverageSolvedTime
            // 
            this.labelShowAverageSolvedTime.AutoSize = true;
            this.labelShowAverageSolvedTime.Location = new System.Drawing.Point(418, 131);
            this.labelShowAverageSolvedTime.Name = "labelShowAverageSolvedTime";
            this.labelShowAverageSolvedTime.Size = new System.Drawing.Size(128, 13);
            this.labelShowAverageSolvedTime.TabIndex = 21;
            this.labelShowAverageSolvedTime.Text = "showAverageSolvedTime";
            // 
            // labelShowAverageTotalSolvedTime
            // 
            this.labelShowAverageTotalSolvedTime.AutoSize = true;
            this.labelShowAverageTotalSolvedTime.Location = new System.Drawing.Point(418, 178);
            this.labelShowAverageTotalSolvedTime.Name = "labelShowAverageTotalSolvedTime";
            this.labelShowAverageTotalSolvedTime.Size = new System.Drawing.Size(112, 13);
            this.labelShowAverageTotalSolvedTime.TabIndex = 22;
            this.labelShowAverageTotalSolvedTime.Text = "showTotalSolvedTime";
            // 
            // ViewStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelShowAverageTotalSolvedTime);
            this.Controls.Add(this.labelShowAverageSolvedTime);
            this.Controls.Add(this.labelShowAverageAssignamentTime);
            this.Controls.Add(this.labelAverageTotalSolvedTime);
            this.Controls.Add(this.labelAverageSolvedTime);
            this.Controls.Add(this.labelAverageAssignmentTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAssignModeStatistics);
            this.Controls.Add(this.labelAssignMode);
            this.Controls.Add(this.mobilUnitslabel);
            this.Controls.Add(this.mobileUnitsListBox);
            this.Controls.Add(this.backToHomeButton);
            this.Name = "ViewStatistics";
            this.Size = new System.Drawing.Size(789, 294);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToHomeButton;
        private System.Windows.Forms.Label mobilUnitslabel;
        private System.Windows.Forms.ListBox mobileUnitsListBox;
        private System.Windows.Forms.ComboBox comboBoxAssignModeStatistics;
        private System.Windows.Forms.Label labelAssignMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAverageAssignmentTime;
        private System.Windows.Forms.Label labelAverageSolvedTime;
        private System.Windows.Forms.Label labelAverageTotalSolvedTime;
        private System.Windows.Forms.Label labelShowAverageAssignamentTime;
        private System.Windows.Forms.Label labelShowAverageSolvedTime;
        private System.Windows.Forms.Label labelShowAverageTotalSolvedTime;
    }
}
