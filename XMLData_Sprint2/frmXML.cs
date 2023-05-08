using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace XMLData_Sprint2
{
    public partial class frmXML : Form
    {
        public frmXML()
        {
            InitializeComponent();
        }
        string rutaXML = "\\assets\\DataBank.xml";
        string rutaIMG = "\\assets\\planetes\\";
        XmlDocument xmlDoc = new XmlDocument();
        DataTable dt = new DataTable();

        private void frmXML_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            xmlDoc.Load(Application.StartupPath + rutaXML);

            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList hijos = root.ChildNodes;

            cbox1.Items.Add(" ");

            foreach (XmlNode hijo in hijos)
            {
                if (hijo.NodeType == XmlNodeType.Element)
                {
                    cbox1.Items.Add(hijo.Name);
                }
            }
        }

        private void cbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlNode affiliations = xmlDoc.SelectSingleNode("SpaceData/filiations");
            XmlNodeList regions = xmlDoc.SelectNodes("SpaceData/regions/Region/nameRegion");
            XmlNodeList planets = xmlDoc.SelectNodes("SpaceData/planets/planet/name");

            if (cbox1.SelectedIndex == 1)
            {
                cbox2.Items.Clear();

                GetItems(affiliations);
                cbox2.Items.RemoveAt(0);
            }
            else if (cbox1.SelectedIndex == 2)
            {
                cbox2.Items.Clear();

                GetItems(regions);
                cbox2.Items.RemoveAt(0);
            }
            else if (cbox1.SelectedIndex == 3)
            {
                cbox2.Items.Clear();

                GetItems(planets);
                cbox2.Items.RemoveAt(0);
            }
            else
            {
                cbox2.Items.Clear();
            }

        }
        public void GetItems(XmlNode name)
        {
            cbox2.Items.Add("");

            foreach (XmlNode node in name)
            {
                cbox2.Items.Add(node.InnerText);
            }
        }

        public void GetItems(XmlNodeList name)
        {
            cbox2.Items.Add("");

            foreach (XmlNode node in name)
            {
                cbox2.Items.Add(node.InnerText);
            }
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            string item = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Sector");
            dt.Columns.Add("Affiliation");
            dt.Columns.Add("Natives");

            XmlNodeList planetList;

            if (string.IsNullOrEmpty(cbox1.Text) || string.IsNullOrEmpty(cbox2.Text))
            {
                planetList = xmlDoc.SelectNodes("//planet");
            }
            else
            {
                if (cbox1.Text == "planets")
                {
                    item = "name";
                }
                if (cbox1.Text == "filiations")
                {
                    item = "filiation";
                }
                if (cbox1.Text == "regions")
                {
                    item = "sector";
                }

                planetList = xmlDoc.SelectNodes($"//planet[{item}[contains(.,'{cbox2.Text}')]]");
            }

            foreach (XmlNode planet in planetList)
            {
                DataRow row = dt.NewRow();
                row["Name"] = planet.SelectSingleNode("name").InnerText;
                row["Sector"] = planet.SelectSingleNode("sector").InnerText;
                row["Affiliation"] = planet.SelectSingleNode("filiation").InnerText;
                row["Natives"] = planet.SelectSingleNode("natives").InnerText;
                dt.Rows.Add(row);
            }

            dgvMain.DataSource = dt;
        }
        //{
        //    XmlNode nodoPlaneta = xmlDoc.SelectSingleNode("SpaceData/planets/planet");

        //    if ((cbox1.Text == "" && cbox2.Text == "") || (cbox1.Text != "" && cbox2.Text == ""))
        //    {
        //        GetItems(nodoPlaneta);
        //        cbox2.Items.RemoveAt(0);
        //    }
        //    else if (cbox1.SelectedIndex == 1)
        //    {
        //        cbox2.Items.Clear();
        //        XmlNodeList nodoFiliation = xmlDoc.SelectNodes("SpaceData/planets/planet/[name ='"+ nodoPlaneta + "']");

        //        GetItems(nodoFiliation);

        //        foreach (XElement planet in nodoFiliation.Value ("planet"))
        //        {
        //            DataRow row = dt.NewRow();
        //            row["Name"] = planet.Element("name").Value;
        //            row["Sector"] = planet.Element("sector").Value;
        //            row["Filiation"] = planet.Element("filiation").Value;
        //            row["Natives"] = planet.Element("natives").Value;
        //            dt.Rows.Add(row);
        //        }
        //    }

        //    //si nombre del texto
        //    //    nombre del campo = texto
        //    //if...

        //    //xmlnodelist = planes/nombre del campo / Contains valorCBX2

        //    //    and foreach que tengo abajo

        //    XDocument xdocs = XDocument.Load(Application.StartupPath + rutaXML);
        //    dgvMain.DataSource = dt;
        //    dt.Clear();
        //    dt.Columns.Clear();
        //    dt.Columns.Add("Name", typeof(string));
        //    dt.Columns.Add("Sector", typeof(string));
        //    dt.Columns.Add("Filiation", typeof(string));
        //    dt.Columns.Add("Natives", typeof(string));

        //    foreach (XElement planet in xdocs.Descendants("planet"))
        //    {
        //        DataRow row = dt.NewRow();
        //        row["Name"] = planet.Element("name").Value;
        //        row["Sector"] = planet.Element("sector").Value;
        //        row["Filiation"] = planet.Element("filiation").Value;
        //        row["Natives"] = planet.Element("natives").Value;
        //        dt.Rows.Add(row);
        //    }

        //    //if (cbox1.SelectedIndex == 1)
        //    //{
        //    //    dt.Clear();
        //    //    XmlNodeList nodes = xmlDoc.SelectNodes("//planets/planet[filiations ='" + cbox2.SelectedItem.ToString() + "']");

        //    //    foreach (XmlNode node in nodes)
        //    //    {
        //    //        DataRow row = dt.NewRow();
        //    //        row["Name"] = node.SelectSingleNode("name").InnerText;
        //    //        row["Sector"] = node.SelectSingleNode("sector");
        //    //        row["Filiation"] = node.SelectSingleNode("filiation");
        //    //        row["Natives"] = node.SelectSingleNode("natives");
        //    //        dt.Rows.Add(row);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    dt.Clear();

        //    //    XDocument xdoc = XDocument.Load(Application.StartupPath + rutaXML);

        //    //    foreach (XElement planet in xdoc.Descendants("planet"))
        //    //    {
        //    //        DataRow row = dt.NewRow();
        //    //        row["Name"] = planet.Element("name").Value;
        //    //        row["Sector"] = planet.Element("sector").Value;
        //    //        row["Filiation"] = planet.Element("filiation").Value;
        //    //        row["Natives"] = planet.Element("natives").Value;
        //    //        dt.Rows.Add(row);
        //    //    }
        //    //}
        //    dgvMain.DataSource = dt;
        //}

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Visible = true;
            string cPlaneta, cSector, cFiliation, cNatives;
            cPlaneta = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
            cSector = dgvMain.Rows[e.RowIndex].Cells[1].Value.ToString();
            cFiliation = dgvMain.Rows[e.RowIndex].Cells[2].Value.ToString();
            cNatives = dgvMain.Rows[e.RowIndex].Cells[3].Value.ToString();

            lblPlanet.Text = cPlaneta;
            lblSector.Text = cSector;
            lblFiliacion.Text = cFiliation;
            lblNativo.Text = cNatives;

            string imgRutaPNG = Application.StartupPath + rutaIMG + lblPlanet.Text + ".png";
            string imgRutaJPG = Application.StartupPath + rutaIMG + lblPlanet.Text + ".jpg";
            if (File.Exists(imgRutaPNG))
            {
                pictureBox2.ImageLocation = imgRutaPNG;
            }
            else if (File.Exists(imgRutaJPG))
            {
                pictureBox2.ImageLocation = imgRutaJPG;
            }
            else
            {
                groupBox1.Visible = false;
            }

            XmlNode planetNode = xmlDoc.SelectSingleNode("//planet[name='" + cPlaneta + "']");
            if (planetNode != null)
            {
                //lat long
                XmlNode longNode = planetNode.SelectSingleNode("situation/long");
                XmlNode latNode = planetNode.SelectSingleNode("situation/lat");
                lblLong.Text = longNode.InnerText;
                lblLat.Text = latNode.InnerText;

                //hyperspace
                listBox2.Items.Clear();
                XmlNodeList routeNodes = planetNode.SelectNodes("hyperspaceRoute/route");
                foreach (XmlNode routeNode in routeNodes)
                {
                    listBox2.Items.Add(routeNode.InnerText);
                }
            }
            else
            {
                groupBox1.Visible = false;
            }

        }
    }
}