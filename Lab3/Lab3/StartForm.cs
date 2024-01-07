using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(xMeshSizeTextBox.Text) * Convert.ToInt32(yMeshSizeTextBox.Text) - 1 < Convert.ToInt32(numberOfPredatorsTextBox.Text) + Convert.ToInt32(numberOfVictimsTextBox.Text))
                MessageBox.Show("Занадто велика кількість хижаків і жертв для сітки " + xMeshSizeTextBox.Text + "x" + yMeshSizeTextBox.Text);
            else
            {
                if (Application.OpenForms["GameForm"] == null)
                    new GameForm(Convert.ToInt32(xMeshSizeTextBox.Text), Convert.ToInt32(yMeshSizeTextBox.Text), Convert.ToInt32(numberOfVictimsTextBox.Text),
                        Convert.ToInt32(victimsReproductionAgeTextBox.Text), Convert.ToInt32(victimsReproductionIntervalTextBox.Text), Convert.ToInt32(numberOfPredatorsTextBox.Text),
                        Convert.ToInt32(predatorsReproductionAgeTextBox.Text), Convert.ToInt32(predatorsReproductionIntervalTextBox.Text), Convert.ToInt32(predatorCanStarveTextBox.Text)).Show();
                else
                {
                    Application.OpenForms["GameForm"].Close();
                    new GameForm(Convert.ToInt32(xMeshSizeTextBox.Text), Convert.ToInt32(yMeshSizeTextBox.Text), Convert.ToInt32(numberOfVictimsTextBox.Text),
                        Convert.ToInt32(victimsReproductionAgeTextBox.Text), Convert.ToInt32(victimsReproductionIntervalTextBox.Text), Convert.ToInt32(numberOfPredatorsTextBox.Text),
                        Convert.ToInt32(predatorsReproductionAgeTextBox.Text), Convert.ToInt32(predatorsReproductionIntervalTextBox.Text), Convert.ToInt32(predatorCanStarveTextBox.Text)).Show();
                }
            }
        }
    }
}
