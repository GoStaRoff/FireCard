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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        public Order(Map myMap)
        {
            InitializeComponent();
            orderText.Text = myMap.ToString();
        }
    }
}
