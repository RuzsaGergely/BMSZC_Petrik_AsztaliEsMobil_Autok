using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGG_Autok
{
    public partial class AddCarForm : Form
    {
        private DBConnector DBConnectorClass { get; set; }

        public AddCarForm()
        {
            InitializeComponent();
            DBConnectorClass = new DBConnector();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnectorClass.AutoTorlese(tb_licensetodelete.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Auto newAuto = new Auto();

            newAuto.Marka = tb_uj_marka.Text;
            newAuto.Vetelar = int.Parse(tb_uj_vetelar.Text);
            newAuto.Hengerurtartalom = int.Parse(tb_uj_hengerurtartalom.Text);
            newAuto.ForgalmiErvenyesseg = dtp_uj_forgalmi.Value;
            newAuto.Rendszam = tb_uj_rendszam.Text;
            newAuto.GyartasiEv = int.Parse(tb_uj_gyartasiev.Text);
            newAuto.KmAllas = int.Parse(tb_uj_kmallas.Text);
            newAuto.Teljesitmeny = int.Parse(tb_uj_teljesitmeny.Text);
            newAuto.Tomeg = int.Parse(tb_uj_tomeg.Text);
            newAuto.Modell = tb_uj_modell.Text;

            DBConnectorClass.AutoHozzadasa(newAuto);
        }
    }
}
