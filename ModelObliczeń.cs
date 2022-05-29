using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_ININ4_PR2._2_z3
{
    class ModelObliczeń : INotifyPropertyChanged
    {
        private string buforIO = "0";
        private double?
            lewyOperand = null,
            prawyOperand = null
            ;
        private string operacja = null;
        private bool flagaDziałania = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public string BuforIO {
            get => buforIO;
            set {
                buforIO = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforIO"));
            }
        }
        public string BuforDziałania { 
            get {
                //do korekty
                return $"{lewyOperand} {operacja} {prawyOperand}";
            } 
        }

        internal void DopiszCyfrę(string cyfra)
        {
            if (flagaDziałania)
            {
                flagaDziałania = false;
                BuforIO = cyfra;
            }
            else if (BuforIO == "0")
                BuforIO = cyfra;
            else
                BuforIO += cyfra;
        }
        internal void WstawPrzecinek()
        {
            if (flagaDziałania)
            {
                flagaDziałania = false;
                BuforIO = "0,";
            }
            else if (buforIO.Contains(','))
                ;
            else
                BuforIO += ",";
        }
        internal void ZmianaZnaku()
        {
            if (buforIO == "0")
                ;
            else if (buforIO[0] == '-')
                BuforIO = buforIO.Substring(1);
            else
                BuforIO = '-' + buforIO;
            flagaDziałania = false;
        }

        internal void KasujZnak()
        {
            buforIO = buforIO.Substring(0, buforIO.Length - 1);
            if (buforIO == "" || buforIO == "-" || buforIO == "-0")
                BuforIO = "0";
            else
                //BuforIO = buforIO;
                //albo po prostu:
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforIO"));
        }
        internal void ResetujWszystko()
        {
            ZerujIO();
            //do uzupełnienia
        }
        internal void ZerujIO()
        {
            BuforIO = "0";
        }


        internal void DziałanieDwuargumentowe(string operacja)
        {
            if(lewyOperand == null)
            {
                lewyOperand = double.Parse(buforIO);
                this.operacja = operacja;
                flagaDziałania = true;
            }
            else
            {
                prawyOperand = double.Parse(buforIO);
                WykonajZbuforowaneDziałanie();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));
        }

        private void WykonajZbuforowaneDziałanie()
        {
            if (operacja == "+")
                lewyOperand = lewyOperand + prawyOperand;

            BuforIO = lewyOperand.ToString();
            flagaDziałania = true;
        }
    }
}
