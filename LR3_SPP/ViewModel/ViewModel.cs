using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LR3_SPP
{
     public class ViewModel : INotifyPropertyChanged
     {
          public event PropertyChangedEventHandler PropertyChanged;

          public void OnPropertyChanged([CallerMemberName]string prop = "")
          {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
          }

     }
               
}
