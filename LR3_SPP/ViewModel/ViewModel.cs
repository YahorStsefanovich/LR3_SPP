using AssemblyLibrary;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;

namespace LR3_SPP
{
     public class ViewModel : INotifyPropertyChanged
     {
          private DllDefinition result;
          private DllLoader loader;
          private RelayCommand openFileComand;

          public DllDefinition Result
          {
               get
               {
                    return result;
               }

               set
               {
                    result = value;
                    OnPropertyChanged();
               }
          }

          public ViewModel()
          {
               loader = new DllLoader();
          }

          public event PropertyChangedEventHandler PropertyChanged;

          public void OnPropertyChanged([CallerMemberName]string prop = "")
          {
               //? == Nullable<T>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
          }

          public NamespaceDefinition a = new NamespaceDefinition("AssemblyLibrary");

          public RelayCommand OpenFileComand
          {
               get
               {
                    //The ?? sets the default value to return if the result is null
                    return openFileComand ??
                        (openFileComand = new RelayCommand(obj =>
                        {
                             try
                             {
                                  OpenFileDialog openFileDialog = new OpenFileDialog();
                                  if (openFileDialog.ShowDialog() == DialogResult.OK)
                                  {
                                       Result = loader.Read(openFileDialog.FileName);
                                  }
                             }
                             catch (Exception ex)
                             {
                                  System.Windows.MessageBox.Show(ex.ToString());
                             }
                        }));
               }
          }
     }
               
}
