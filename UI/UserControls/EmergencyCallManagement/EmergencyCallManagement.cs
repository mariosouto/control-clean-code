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
    public partial class EmergencyCallManagement : UserControl
    {
        bool showSolved;

        public EmergencyCallManagement()
        {
            InitializeComponent();
            this.refreshListOfEmergencyCalls();
            this.activeEmergencyCallsRadioButton.Select();
            this.showSolved = false;
            setEmergencyCallAsSolveButton.Show();
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
                    if (emergencyCall.Solved == showSolved)
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Home backToHome = new Home();
            this.Controls.Add(backToHome);
        }

        private void AddEmergencyButton_Click(object sender, EventArgs e)
        {
            AddEmergencyCall window = new AddEmergencyCall(this);
            panel.Controls.Clear();
            panel.Controls.Add(window);
        }

        private void viewInfoButton_Click(object sender, EventArgs e)
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

        private void setEmergencyCallAsSolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmergencyCall selected = (EmergencyCall)emergencyCallListBox.SelectedItem;
                Services.EmergencyCallSolved(selected.Id);
                MessageBox.Show(selected + " ha sido marcada como resuelta",
                    "Llamada de Emergencia resuelta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.refreshListOfEmergencyCalls();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar una llamada.",
                   "Llamada de emergencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void activeEmergencyCallsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (activeEmergencyCallsRadioButton.Checked)
            {
                this.showSolved = false;
                setEmergencyCallAsSolveButton.Show();
            }
            if (solvedRadioButton.Checked)
            {
                this.showSolved = true;
                setEmergencyCallAsSolveButton.Hide();
            }
            refreshListOfEmergencyCalls();
        }
    }
}
