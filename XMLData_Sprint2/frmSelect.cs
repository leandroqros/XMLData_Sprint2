using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLData_Sprint2
{
    public partial class frmSelect : Form
    {
        public frmSelect()
        {
            InitializeComponent();
        }

        private void bntLinq_Click(object sender, EventArgs e)
        {
            frmLinq form = new frmLinq();
            form.Show();
        }

        private void bntXML_Click(object sender, EventArgs e)
        {
            frmXML form = new frmXML();
            form.Show();
        }
    }
}
