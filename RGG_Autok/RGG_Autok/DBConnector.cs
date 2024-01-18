using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RGG_Autok
{
    public class DBConnector
    {
        private const string MYSQL_URL = "localhost";
        private const string MYSQL_USER = "root";
        private const string MYSQL_PASSWD = "";
        private const string MYSQL_DB = "tagdij";
        private const string MYSQL_CONNECTIONSTRING = "server=" + MYSQL_URL + ";User Id="+MYSQL_USER+ ";Password="+MYSQL_PASSWD+";Initial catalog="+MYSQL_DB;
        private MySqlConnection sqlConnection;

        public DBConnector()
        {
            sqlConnection = new MySqlConnection(MYSQL_CONNECTIONSTRING);
            sqlConnection.Open();
        }

        public List<Auto> AutokLekerdezese()
        {
            List<Auto> autok = new List<Auto>();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM auto", sqlConnection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        autok.Add(new Auto
                        {
                            Rendszam = reader.GetString(0),
                            Marka = reader.GetString(1),
                            Modell = reader.GetString(2),
                            GyartasiEv = reader.GetInt32(3),
                            ForgalmiErvenyesseg = reader.GetDateTime(4),
                            Vetelar = reader.GetInt32(5),
                            KmAllas = reader.GetInt32(6),
                            Hengerurtartalom = reader.GetInt32(7),
                            Tomeg = reader.GetInt32(8),
                            Teljesitmeny = reader.GetInt32(9)
                        });
                    }
                }
            }
            return autok;
        }

        public bool AutoHozzadasa(Auto ujauto)
        {
            string hozzadas_string = $"INSERT INTO `auto`(`rendszam`, `marka`, `modell`, `gyartasiev`, `forgalmiErvenyesseg`, `vetelar`, `kmallas`, `hengerűrtartalom`, `tomeg`, `teljesitmeny`) VALUES ('','','','','','','','','','')";
            MySqlCommand command = new MySqlCommand(hozzadas_string, sqlConnection);

            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool TagFrissitese(int Azon, Tag tag)
        //{
        //    if (Azon != tag.Azon)
        //    {
        //        return false;
        //    }
        //    string update_string = $"UPDATE `ugyfel` SET `nev`='{tag.Nev}',`szulev`='{tag.Szulev}',`irszam`='{tag.Irszam}',`orsz`='{tag.Orsz}' WHERE `azon`={Azon}";
        //    MySqlCommand command = new MySqlCommand(update_string, sqlConnection);

        //    if (command.ExecuteNonQuery() > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public bool TagTorlese(int Azon)
        //{
        //    string update_string = $"DELETE FROM `ugyfel` WHERE `azon`={Azon}";
        //    MySqlCommand command = new MySqlCommand(update_string, sqlConnection);

        //    if (command.ExecuteNonQuery() > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
}
