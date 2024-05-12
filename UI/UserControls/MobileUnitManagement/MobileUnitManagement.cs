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
    public partial class MobileUnitManagement : UserControl
    {
        public MobileUnitManagement()
        {
            InitializeComponent();
            mobileUnitsListBox.ResetText();
            this.refreshListOfMobileUnits();
        }

        public void refreshListOfMobileUnits()
        {
            mobileUnitsListBox.Items.Clear();
            mobileUnitsListBox.Items.AddRange(Services.GetNamesOfMobileUnits());
        }

        private void addMobileUnit_Click(object sender, EventArgs e)
        {
            AddMobileUnit panelAddMobileUnit = new AddMobileUnit(this);
            ControlPanel.Controls.Clear();
            ControlPanel.Controls.Add(panelAddMobileUnit);

        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Services.DeleteMobileUnitByName(mobileUnitsListBox.GetItemText(mobileUnitsListBox.SelectedItem));
                refreshListOfMobileUnits();
                ControlPanel.Controls.Clear();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un movil.",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidDeleteMobileUnitException)
            {
                MessageBox.Show("No se puede eliminar un movil que ha sido asociada  a una llamada de emergencia.",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Perdida de conexión con la base de datos, verificar para poder seguir utilizando la aplicación.",
                   "Conexión Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void modifyMobileUnitButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMobileUnit window = new AddMobileUnit(mobileUnitsListBox.GetItemText(mobileUnitsListBox.SelectedItem), this);
                ControlPanel.Controls.Clear();
                ControlPanel.Controls.Add(window);
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

        private void setCoordinatesButton_Click(object sender, EventArgs e)
        {
            if (mobileUnitsListBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un movil",
                    "Unidad movil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SetCoordinates window = new SetCoordinates(mobileUnitsListBox.GetItemText(mobileUnitsListBox.SelectedItem));
                ControlPanel.Controls.Clear();
                ControlPanel.Controls.Add(window);
            }
        }

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Home backToHome = new Home();
            this.Controls.Add(backToHome);
        }

        private void viewInfoButton_Click(object sender, EventArgs e)
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
    }
}
