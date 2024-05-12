using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Domain.Services;

namespace UI.UserControls.Statistics
{
    public partial class ViewStatistics : UserControl
    {
        private Label labelToHideAndThenShow;
        private ComboBox comoBoxToHideAndThenShow;

        public ViewStatistics(Label oneLabel, ComboBox oneCombobox)
        {
            InitializeComponent();
            labelToHideAndThenShow = oneLabel;
            comoBoxToHideAndThenShow = oneCombobox;
            labelToHideAndThenShow.Hide();
            comoBoxToHideAndThenShow.Hide();
            comboBoxAssignModeStatistics.Text = "Todos los modos";
            this.refreshListOfMobileUnits();
            mobileUnitsListBox.SetSelected(0, true);
            refreshStatistics();
        }

        private void refreshListOfMobileUnits()
        {
            mobileUnitsListBox.Items.Clear();
            try
            {
                MobileUnit[] mobiles = Services.GetMobileUnits();
                mobileUnitsListBox.Items.Add("Todos los moviles");
                mobileUnitsListBox.Items.AddRange(Services.GetNamesOfMobileUnits());
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            labelToHideAndThenShow.Show();
            comoBoxToHideAndThenShow.Show();
            Home backToHome = new Home();
            this.Controls.Add(backToHome);
        }

        private void refreshStatistics()
        {
            TimeSpan averageAssignationTime = new TimeSpan();
            TimeSpan averageSolvedTime = new TimeSpan();
            TimeSpan averageTotalSolvedTime = new TimeSpan();
            if (mobileUnitsListBox.SelectedIndex == 0 && comboBoxAssignModeStatistics.Text == "Todos los modos")
            {
                averageAssignationTime = Domain.Services.ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls());
                averageSolvedTime = Domain.Services.ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls());
                averageTotalSolvedTime = Domain.Services.ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls());
            }
            else
            {
                if (mobileUnitsListBox.SelectedIndex != 0 && comboBoxAssignModeStatistics.Text == "Todos los modos")
                {
                    averageAssignationTime = Domain.Services.ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.None, mobileUnitsListBox.Text);
                    averageSolvedTime = Domain.Services.ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.None, mobileUnitsListBox.Text);
                    averageTotalSolvedTime = Domain.Services.ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.None, mobileUnitsListBox.Text);
                }
                if (comboBoxAssignModeStatistics.Text != "Todos los modos")
                {
                    EmergencyCall.AssignModes oneMode = EmergencyCall.AssignModes.None;
                    switch (comboBoxAssignModeStatistics.Text)
                    {
                        case "Por defecto":
                            oneMode = EmergencyCall.AssignModes.Default;
                            break;
                        case "Tiempo de espera":
                            oneMode = EmergencyCall.AssignModes.WaitTime;
                            break;
                        case "Cantidad de casos atendidos":
                            oneMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
                            break;
                    }
                    if (mobileUnitsListBox.SelectedIndex == 0)
                    {
                        averageAssignationTime = Domain.Services.ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls(), oneMode);
                        averageSolvedTime = Domain.Services.ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls(), oneMode);
                        averageTotalSolvedTime = Domain.Services.ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls(), oneMode);
                    }
                    else
                    {
                        averageAssignationTime = Domain.Services.ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls(), oneMode, mobileUnitsListBox.Text);
                        averageSolvedTime = Domain.Services.ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls(), oneMode, mobileUnitsListBox.Text);
                        averageTotalSolvedTime = Domain.Services.ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls(), oneMode, mobileUnitsListBox.Text);
                    }
                }
            }
            labelShowAverageAssignamentTime.Text = Utilities.printTimeSpan(averageAssignationTime);
            labelShowAverageSolvedTime.Text = Utilities.printTimeSpan(averageSolvedTime);
            labelShowAverageTotalSolvedTime.Text = Utilities.printTimeSpan(averageTotalSolvedTime);
        }

        private void mobileUnitsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                refreshStatistics();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxAssignModeStatistics_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                refreshStatistics();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
