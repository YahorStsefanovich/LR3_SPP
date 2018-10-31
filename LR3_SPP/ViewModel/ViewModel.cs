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

          public ViewModel()
          {
               loader = new DllLoader();
          }

          public DllDefinition Result
          {
               get
               {
                    return result;
               }

               set
               {
                    result = value;
                    OnPropertyChanged("Result");
               }
          }

          public event PropertyChangedEventHandler PropertyChanged;

          protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
          {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }

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
