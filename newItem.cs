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
    public partial class newItem : Form
    {
        Form1 form;

        public newItem()
        {
            InitializeComponent();
        }

        public newItem(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double direction = 0;
            double highth = 0;
            if(itemDirection.Text.Length == 0 || itemName.Text.Length == 0 || itemHighth.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поля для вводу");
            }
            else
            {
                if (!double.TryParse(itemDirection.Text, out direction))
                {
                    MessageBox.Show("Введіть коректну відстань");
                }
                else if (!double.TryParse(itemHighth.Text, out highth))
                {
                    MessageBox.Show("Введіть коректну висоту");
                }

                else
                {
                    Thing.newItemDirection = direction;
                    Thing.newItemName = itemName.Text;
                    Thing.newItemHighth = highth;
                    form.Enabled = true;
                    Thing.idAdding = true;
                    this.Close();
                }
            }
        }
    }
}
