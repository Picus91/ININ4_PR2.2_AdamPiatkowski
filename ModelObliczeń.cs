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

        public event PropertyChangedEventHandler PropertyChanged;
        public string BuforIO {
            get => buforIO;
            set {
                buforIO = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforIO"));
            }
        }
        public string BuforDziałania { get; set; } = "Bufor działania";

        internal void DopiszCyfrę(string cyfra)
        {
            if (BuforIO == "0")
                BuforIO = cyfra;
            else
                BuforIO += cyfra;
        }

        internal void WstawPrzecinek()
        {
            if (buforIO.Contains(','))
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
        }
    }
}
