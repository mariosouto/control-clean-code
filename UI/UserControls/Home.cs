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

namespace UI.UserControls
{
    public partial class Home : UserControl
    {

        private enum showMobileUnits { ALL, AVAILABLES, NOT_AVAILABLES };
        bool showEmergencyCallsSolved;

        public Home()
        {
            InitializeComponent();
            mobileUnitsListBox.ResetText();
            this.refreshListOfMobileUnits(showMobileUnits.ALL);
            showMobileUnitscomboBox.Text = "Todos los móviles";
            this.refreshListOfEmergencyCalls();
            this.activeEmergencyCallsRadioButton.Select();
            this.showEmergencyCallsSolved = false;
            this.resolveEmergencyCallOfMobileButton.Hide();
        }

        public void refreshListOfEmergencyCalls()
        {
            try
            {
                emergencyCallListBox.Items.Clear();
                EmergencyCall[] allEmergencyCalls = Services.GetArrayOfEmergencyCalls();
                List<EmergencyCall> listOfEmergencyCallToShow = new List<EmergencyCall>();
                foreach (var emergencyCall in allEmergencyCalls)
                {
                    if (emergencyCall.Solved == showEmergencyCallsSolved)
                    {
                        listOfEmergencyCallToShow.Add(emergencyCall);
                    }
                }
                emergencyCallListBox.Items.AddRange(listOfEmergencyCallToShow.ToArray());
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void refreshListOfMobileUnits(showMobileUnits filter)
        {
            try
            {
                mobileUnitsListBox.Items.Clear();
                MobileUnit[] mobiles = Services.GetMobileUnits();
                if (filter != showMobileUnits.ALL)
                {
                    List<String> nameOfMobilesToShow = new List<String>();
                    if (filter == showMobileUnits.AVAILABLES)
                    {
                        foreach (var mobile in mobiles)
                        {
                            if (mobile.Available)
                            {
                                nameOfMobilesToShow.Add(mobile.Name);
                            }
                        }
                    }
                    if (filter == showMobileUnits.NOT_AVAILABLES)
                    {
                        foreach (var mobile in mobiles)
                        {
                            if (!mobile.Available)
                            {
                                nameOfMobilesToShow.Add(mobile.Name);
                            }
                        }
                    }
                    mobileUnitsListBox.Items.AddRange(nameOfMobilesToShow.ToArray());
                }
                else
                {
                    mobileUnitsListBox.Items.AddRange(Services.GetNamesOfMobileUnits());
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showMobileUnitscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (showMobileUnitscomboBox.Text == "Todos los móviles")
            {
                this.resolveEmergencyCallOfMobileButton.Hide();
                refreshListOfMobileUnits(showMobileUnits.ALL);
            }
            if (showMobileUnitscomboBox.Text == "Solo disponibles")
            {
                this.resolveEmergencyCallOfMobileButton.Hide();
                refreshListOfMobileUnits(showMobileUnits.AVAILABLES);
            }
            if (showMobileUnitscomboBox.Text == "No disponibles")
            {
                refreshListOfMobileUnits(showMobileUnits.NOT_AVAILABLES);
                this.resolveEmergencyCallOfMobileButton.Show();
            }
        }

        private void activeEmergencyCallsRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (activeEmergencyCallsRadioButton.Checked)
            {
                this.showEmergencyCallsSolved = false;
            }
            if (solvedRadioButton.Checked)
            {
                this.showEmergencyCallsSolved = true;
            }
            refreshListOfEmergencyCalls();
        }

        private void viewInfoMobileUnitButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Utilities.printAllInfoMobileUnit(Services.GetMobileUnit((String)mobileUnitsListBox.SelectedItem).Name),
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un movil.",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void viewInfoEmergencyCallButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Utilities.printAllInfoEmergencyCall(((EmergencyCall)emergencyCallListBox.SelectedItem).Id),
                     "Llamada de Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar una llamada.",
                     "Llamada de Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resolveEmergencyCallOfMobileButton_Click(object sender, EventArgs e)
        {
            try
            {
                MobileUnit mobileSelected = Services.GetMobileUnit((String)mobileUnitsListBox.SelectedItem);
                int idEmergencyCallToSolve = Services.GetEmergencyCallUnsolvedAssignedToUnit(mobileSelected.Name).Id;
                Services.EmergencyCallSolved(idEmergencyCallToSolve);
                MessageBox.Show(Services.GetEmergencyCall(idEmergencyCallToSolve) + " ha sido marcada como resuelta y el movil "
                    + mobileSelected.Name + " esta disponible.", "Llamada de Emergencia resuelta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.refreshListOfEmergencyCalls();
                this.refreshListOfMobileUnits(showMobileUnits.NOT_AVAILABLES);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un movil.",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

