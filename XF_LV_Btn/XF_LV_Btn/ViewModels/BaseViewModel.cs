using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_LV_Btn.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        
        private string _messageToUser;
        public string MessageToUser
        {
            get { return _messageToUser; }

            set
            {
                _messageToUser = value;
                OnPropertyChanged();
            }
        }

        public void SendMessageToUser()
        {
            MessagingCenter.Send<BaseViewModel, string>(this, "ViewModelMessage", MessageToUser);
        }

        //Implementaion of interface
        public event PropertyChangedEventHandler PropertyChanged;
        //Implementaion of interface
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
