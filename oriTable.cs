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
    public partial class oriTable : Form
    {
        public oriTable()
        {
            InitializeComponent();
        }

        public oriTable(Map map)
        {
            InitializeComponent();
            for (int i = 0; i < map.Things.Count; i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = map.Things[i].Name;
                dataGridView1.Rows[i].Cells[2].Value = map.Things[i].Direction;
                dataGridView1.Rows[i].Cells[3].Value = map.Things[i].Highth;
            }
        }
    }
}
