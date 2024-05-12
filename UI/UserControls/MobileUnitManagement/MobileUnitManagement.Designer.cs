namespace UI.UserControls
{
    partial class MobileUnitManagement
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
            this.button1 = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.setCoordinatesButton = new System.Windows.Forms.Button();
            this.backToHomeButton = new System.Windows.Forms.Button();
            this.mobileUnitsListBox = new System.Windows.Forms.ListBox();
            this.viewInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addMobileUnit_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(319, 132);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(106, 35);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Eliminar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(319, 80);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(106, 35);
            this.modifyButton.TabIndex = 2;
            this.modifyButton.Text = "Modificar";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyMobileUnitButton_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Location = new System.Drawing.Point(478, 29);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(255, 193);
            this.ControlPanel.TabIndex = 3;
            // 
            // setCoordinatesButton
            // 
            this.setCoordinatesButton.Location = new System.Drawing.Point(319, 187);
            this.setCoordinatesButton.Name = "setCoordinatesButton";
            this.setCoordinatesButton.Size = new System.Drawing.Size(106, 35);
            this.setCoordinatesButton.TabIndex = 4;
            this.setCoordinatesButton.Text = "Ingresar coordenadas";
            this.setCoordinatesButton.UseVisualStyleBackColor = true;
            this.setCoordinatesButton.Click += new System.EventHandler(this.setCoordinatesButton_Click);
            // 
            // backToHomeButton
            // 
            this.backToHomeButton.Location = new System.Drawing.Point(352, 251);
            this.backToHomeButton.Name = "backToHomeButton";
            this.backToHomeButton.Size = new System.Drawing.Size(96, 40);
            this.backToHomeButton.TabIndex = 5;
            this.backToHomeButton.Text = "Volver a la pantalla principal";
            this.backToHomeButton.UseVisualStyleBackColor = true;
            this.backToHomeButton.Click += new System.EventHandler(this.backToHomeButton_Click);
            // 
            // mobileUnitsListBox
            // 
            this.mobileUnitsListBox.FormattingEnabled = true;
            this.mobileUnitsListBox.Location = new System.Drawing.Point(72, 29);
            this.mobileUnitsListBox.Name = "mobileUnitsListBox";
            this.mobileUnitsListBox.Size = new System.Drawing.Size(194, 186);
            this.mobileUnitsListBox.TabIndex = 6;
            // 
            // viewInfoButton
            // 
            this.viewInfoButton.Location = new System.Drawing.Point(130, 221);
            this.viewInfoButton.Name = "viewInfoButton";
            this.viewInfoButton.Size = new System.Drawing.Size(70, 21);
            this.viewInfoButton.TabIndex = 10;
            this.viewInfoButton.Text = "Ver datos";
            this.viewInfoButton.UseVisualStyleBackColor = true;
            this.viewInfoButton.Click += new System.EventHandler(this.viewInfoButton_Click);
            // 
            // MobileUnitManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewInfoButton);
            this.Controls.Add(this.mobileUnitsListBox);
            this.Controls.Add(this.backToHomeButton);
            this.Controls.Add(this.setCoordinatesButton);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.button1);
            this.Name = "MobileUnitManagement";
            this.Size = new System.Drawing.Size(789, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button setCoordinatesButton;
        private System.Windows.Forms.Button backToHomeButton;
        private System.Windows.Forms.ListBox mobileUnitsListBox;
        private System.Windows.Forms.Button viewInfoButton;
    }
}
