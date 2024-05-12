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
    public partial class SetCoordinates : UserControl
    {
        String nameOfMobileUnitToSetCoordinates;

        public SetCoordinates(String nameOfMobileUnitReceived)
        {
            InitializeComponent();
            nameOfMobileUnitToSetCoordinates = nameOfMobileUnitReceived;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                Services.SetCoordinatesToMobile(nameOfMobileUnitToSetCoordinates, Convert.ToDouble(longitudeTextBox.Text),
                Convert.ToDouble(latitudeTextBox.Text));
                this.Controls.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese las coordenadas correctamente. Deben estar con separador decimal y un máximo de 5 decimales",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
