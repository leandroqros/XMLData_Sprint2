using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLData_Sprint2
{
    public partial class frmLinq : Form
    {
        public frmLinq()
        {
            InitializeComponent();
        }

        private void bntLoad_Click(object sender, EventArgs e)
        {
            string rutaNaves = "\\assets\\Info.xml";
            XElement docXML = XElement.Load(Application.StartupPath + rutaNaves);

            foreach (string nombre in docXML.Descendants("textOption"))
            {
                lview.Items.Add(nombre);
            }
        }
    }
}
