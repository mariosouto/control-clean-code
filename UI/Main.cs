using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Domain.Services;
using UI.UserControls;
using UI.UserControls.Statistics;

namespace UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            controlPanel.Controls.Clear();
            Home homeScreen = new Home();
            controlPanel.Controls.Add(homeScreen);
            comboBoxAssignMode.Text = "Por defecto";
            Services.SetAssignMode(EmergencyCall.AssignModes.Default);
        }

        private void mobileUnitManagementbutton_Click(object sender, EventArgs e)
        {
            MobileUnitManagement window = new MobileUnitManagement();
            controlPanel.Controls.Clear();
            controlPanel.Controls.Add(window);
        }

        private void emergencyCallManagementButton_Click(object sender, EventArgs e)
        {
            EmergencyCallManagement window = new EmergencyCallManagement();
            controlPanel.Controls.Clear();
            controlPanel.Controls.Add(window);
            
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            ViewStatistics window = new ViewStatistics(labelAssignMode, comboBoxAssignMode);
            controlPanel.Controls.Clear();
            controlPanel.Controls.Add(window);
        }

        private void addTestDataButton_Click(object sender, EventArgs e)
        {
            Utilities.AddTestData();
            MessageBox.Show("Datos de prueba cargados con éxito.", "Datos de prueba", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBoxAssignMode.Text = "Por defecto";
            Services.SetAssignMode(EmergencyCall.AssignModes.Default);
            controlPanel.Controls.Clear();
            Home homeScreen = new Home();
            controlPanel.Controls.Add(homeScreen);
        }

        private void comboBoxAssignMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAssignMode.Text == "Por defecto")
                Services.SetAssignMode(EmergencyCall.AssignModes.Default);
            if (comboBoxAssignMode.Text == "Tiempo de espera")
                Services.SetAssignMode(EmergencyCall.AssignModes.WaitTime);
            if (comboBoxAssignMode.Text == "Cantidad de casos atendidos")
                Services.SetAssignMode(EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
        }


    }
}
