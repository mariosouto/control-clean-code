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
using Domain.Exceptions;
using Domain.Services;

namespace UI.UserControls
{
    public partial class AddEmergencyCall : UserControl
    {
        private EmergencyCallManagement currentPanel;

        public AddEmergencyCall(EmergencyCallManagement panel)
        {
            InitializeComponent();
            currentPanel = panel;
            this.dateTimePicker.Value = DateTime.Now;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
        }

        private void aceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                int urgencyLevel = 0;
                if (urgencyLevelComboBox.Text == "Alta")
                    urgencyLevel = EmergencyCall.HIGH;
                if (urgencyLevelComboBox.Text == "Media")
                    urgencyLevel = EmergencyCall.MEDIUM;
                if (urgencyLevelComboBox.Text == "Baja")
                    urgencyLevel = EmergencyCall.LOW;
                Services.AddEmergencyCallAndAssignItToMobile(new EmergencyCall(descriptionTextBox.Text,
                    addressTextBox.Text, new Domain.Location(Convert.ToDouble(longitudeTextBox.Text),
                    Convert.ToDouble(latitudeTextBox.Text)), urgencyLevel, dateTimePicker.Value));
                currentPanel.refreshListOfEmergencyCalls();
                this.Controls.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Revise los datos ingresados",
                   "Llamada de emergencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidLevelOfUrgencyException)
            {
                MessageBox.Show("Revise los datos ingresados",
                   "Llamada de emergencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidLatitudeException)
            {
                MessageBox.Show("La latitud es incorrecta. Debe estar entre -90 y 90 y no tener más de 5 decimales.",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidLongitudeException)
            {
                MessageBox.Show("La longitud es incorrecta. Debe estar entre -180 y 180 y no tener más de 5 decimales.",
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