using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public bool IsEqual(Auto ObjectToCompare)
        {
            if (ObjectToCompare.Rendszam == this.Rendszam
                && ObjectToCompare.Marka == this.Marka
                && ObjectToCompare.Modell == this.Modell
                && ObjectToCompare.GyartasiEv == this.GyartasiEv
                && ObjectToCompare.ForgalmiErvenyesseg == this.ForgalmiErvenyesseg
                && ObjectToCompare.Vetelar == this.Vetelar
                && ObjectToCompare.KmAllas == this.KmAllas
                && ObjectToCompare.Hengerurtartalom == this.Hengerurtartalom
                && ObjectToCompare.Tomeg == this.Tomeg
                && ObjectToCompare.Teljesitmeny == this.Teljesitmeny
                )
            { return true; }

            return false;
        }
    }
}
