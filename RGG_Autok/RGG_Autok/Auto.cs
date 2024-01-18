using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGG_Autok
{
    public class Auto
    {
        public string Rendszam {  get; set; }
        public string Marka { get; set; }
        public string Modell { get; set; }
        public int GyartasiEv { get; set; }
        public DateTime ForgalmiErvenyesseg {  get; set; }
        public int Vetelar {  get; set; }
        public int KmAllas {  get; set; }
        public int Hengerurtartalom {  get; set; }
        public int Tomeg {  get; set; }
        public int Teljesitmeny {  get; set; }
    }
}
