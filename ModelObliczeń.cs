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
        public event PropertyChangedEventHandler PropertyChanged;
        public string BuforIO { get; set; } = "0";
        public string BuforDziałania { get; set; } = "Bufor działania";

    }
}
