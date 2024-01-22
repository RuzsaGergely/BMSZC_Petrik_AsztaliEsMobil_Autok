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
        private const string MYSQL_DB = "autok";
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
            string hozzadas_string = $"INSERT INTO `auto`(`rendszam`, `marka`, `modell`, `gyartasiev`, `forgalmiErvenyesseg`, `vetelar`, `kmallas`, `hengerűrtartalom`, `tomeg`, `teljesitmeny`) VALUES ('{ujauto.Rendszam}','{ujauto.Marka}','{ujauto.Modell}','{ujauto.GyartasiEv}','{ujauto.ForgalmiErvenyesseg.ToString("yyyy-MM-dd")}','{ujauto.Vetelar}','{ujauto.KmAllas}','{ujauto.Hengerurtartalom}','{ujauto.Tomeg}','{ujauto.Teljesitmeny}')";
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

        public bool AutoFrissitese(string rszam, Auto auto)
        {
            if (rszam != auto.Rendszam)
            {
                return false;
            }
            string update_string = $"UPDATE `auto` SET `rendszam`='{rszam}',`marka`='{auto.Marka}',`modell`='{auto.Modell}',`gyartasiev`='{auto.GyartasiEv}',`forgalmiErvenyesseg`='{auto.ForgalmiErvenyesseg:yyyy-MM-dd}',`vetelar`='{auto.Vetelar}',`kmallas`='{auto.KmAllas}',`hengerűrtartalom`='{auto.Hengerurtartalom}',`tomeg`='{auto.Tomeg}',`teljesitmeny`='{auto.Teljesitmeny}' WHERE `rendszam`='{rszam}'";
            MySqlCommand command = new MySqlCommand(update_string, sqlConnection);

            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AutoTorlese(string rszam)
        {
            string update_string = $"DELETE FROM `auto` WHERE `rendszam`='{rszam}'";
            MySqlCommand command = new MySqlCommand(update_string, sqlConnection);

            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
