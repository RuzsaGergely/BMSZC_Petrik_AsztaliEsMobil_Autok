using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RGG_Autok
{
    public partial class DBManagementForm : Form
    {
        private BindingList<Auto> auto_binding = new BindingList<Auto>();
        private List<Auto> auto_source = new List<Auto>();
        private DBConnector DBConnector { get; set; }
        bool isEur = false;
        public DBManagementForm()
        {
            InitializeComponent();
            DBConnector = new DBConnector();
            GetSource();
            auto_binding.AllowNew = true;
        }

        private void GetSource()
        {
            auto_binding = new BindingList<Auto>(DBConnector.AutokLekerdezese());
            auto_source = new List<Auto>(DBConnector.AutokLekerdezese());
            dataGridView1.DataSource = auto_binding;
        }

        private void ValtozasokMentese()
        {
            int errors = 0;
            if (auto_source.Count > auto_binding.Count)
            {
                foreach (var item in auto_source)
                {
                    if (!auto_binding.Any(x => x.Rendszam == item.Rendszam))
                    {
                        bool returnvalue = DBConnector.AutoTorlese(item.Rendszam);
                        if (!returnvalue) errors++;
                    }
                }
            }
            for (int i = 0; i < auto_binding.Count; i++)
            {
                try
                {
                    if (!auto_binding[i].IsEqual(auto_source[i]))
                    {
                        bool returnvalue = DBConnector.AutoFrissitese(auto_source[i].Rendszam, auto_binding[i]);
                        if (!returnvalue) errors++;
                    }
                }
                catch { }
            }

            if (errors > 0)
            {
                MessageBox.Show("Nem minden lekérdezés futott le eredményesen! Hibás sorok száma: " + errors, "Hiba", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Minden lekérdezés eredményesen futott le!", "Siker", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValtozasokMentese();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCarForm form = new AddCarForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(isEur)
            {
                button1.Enabled = true;
                auto_binding = new BindingList<Auto>(DBConnector.AutokLekerdezese());
                dataGridView1.DataSource = auto_binding;
                isEur = false;

            } else
            {
                button1.Enabled = false;
                auto_binding = new BindingList<Auto>(DBConnector.AutokLekerdezese());
                foreach (var item in auto_binding)
                {
                    item.Vetelar = item.Vetelar * 383;
                }
                dataGridView1.DataSource = auto_binding;
                isEur = true;
            }

            
        }
    }
}
