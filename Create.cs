using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireCard
{
    public partial class Create : Form
    {
        Form1 form;
        public Create()
        {
            InitializeComponent();
        }

        public Create(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            directionBox.SelectedIndex = 0;
            typeBox.SelectedIndex = 0;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Create_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<string> directions = new List<string>();
            for (int i = 0; i < directionBox.Items.Count; i++)
            {
                directions.Add(directionBox.Items[i].ToString());
            }
            int sum = directionBox.SelectedIndex + 4;
            if (sum > directions.Count - 1)
            {
                Map.Direction = new string[] {
                    directionBox.SelectedItem.ToString(),
                    directionBox.Items[sum - directionBox.Items.Count].ToString()
                };
            }
            else
            {
                Map.Direction = new string[] {
                    directionBox.SelectedItem.ToString(),
                    directionBox.Items[sum].ToString()
                };
            }
            switch (typeBox.SelectedItem.ToString())
            {
                case "Перше":
                    Map.typeSoilders = TypeSoilders.first;
                    break;
                case "Друге":
                    Map.typeSoilders = TypeSoilders.second;
                    break;
                case "Третє":
                    Map.typeSoilders = TypeSoilders.third;
                    break;
            }
        }
        private void discardButton_Click(object sender, EventArgs e)
        {
            directionBox.SelectedIndex = 0;
            typeBox.SelectedIndex = 0;
        }
    }
}
