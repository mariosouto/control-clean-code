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
    public partial class AddMobileUnit : UserControl
    {
        private bool modifying;
        private String nameOfMobileUnitModifying;
        private MobileUnitManagement panel;

        public AddMobileUnit(MobileUnitManagement panelMobileUnitManagement)
        {
            modifying = false;
            InitializeComponent();
            panel = panelMobileUnitManagement;
        }

        public AddMobileUnit(String nameOfMobileUnit, MobileUnitManagement panelMobileUnitManagement)
        {
            InitializeComponent();
            panel = panelMobileUnitManagement;
            modifying = true;
            nameOfMobileUnitModifying = nameOfMobileUnit;
            try
            {
                nameTextBox.Text = Services.GetMobileUnit(nameOfMobileUnit).Name;
                plateTextBox.Text = Services.GetMobileUnit(nameOfMobileUnit).Plate;
                descriptionTextBox.Text = Services.GetMobileUnit(nameOfMobileUnit).Description;
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
        }

        private void addMobileUnitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (modifying)
                {
                    Services.ModifyMobileUnitByName(nameOfMobileUnitModifying, nameTextBox.Text, plateTextBox.Text, descriptionTextBox.Text);
                }
                else
                {
                    Services.AddMobileUnit(nameTextBox.Text, plateTextBox.Text, descriptionTextBox.Text);
                }
                panel.refreshListOfMobileUnits();
                this.Controls.Clear();
            }
            catch(InvalidPlateException)
            {
                MessageBox.Show("La matricula es incorrecta. El formato correcto son tres letras y cuatro numeros, ej: ASA2345",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidAddMobileUnitException)
            {
                MessageBox.Show("Ya existe un movil con ese nombre",
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
