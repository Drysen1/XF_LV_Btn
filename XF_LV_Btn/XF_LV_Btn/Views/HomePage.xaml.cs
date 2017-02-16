using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XF_LV_Btn.Models;
using XF_LV_Btn.ViewModels;

namespace XF_LV_Btn.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }

        /// <summary>
        /// Click event for when a user clicks accept button.
        /// Uses messagingcenter to send to viewmodel.
        /// </summary>
        private void btnAccept_Clicked(object sender, EventArgs args)
        {
            var button = sender as Button;
            var fm = button.CommandParameter as FriendModel;

            MessagingCenter.Send<HomePage, FriendModel>(this, "AcceptMessage", fm);
        }

        /// <summary>
        /// Click event for when a user clicks deny button.
        /// Uses messagingcenter to send to viewmodel.
        /// </summary>
        private void btnDeny_Clicked(object sender, EventArgs args)
        {
            var button = sender as Button;
            var fm = button.CommandParameter as FriendModel;
            MessagingCenter.Send<HomePage, FriendModel>(this, "DenyMessage", fm);
        }

        /// <summary>
        /// Method listens for messages sent from the viewmodel
        /// </summary>
        private void ListenForMessage()
        {
            MessagingCenter.Subscribe<BaseViewModel, string>(this, "ViewModelMessage", (sender, arg) => {
                string message = arg;
                DisplayAlert("Message", message, "OK");
            });
        }

        /// <summary>
        /// If we have to unsubscribe from messages from the viewmodel this method takes care of it.
        /// </summary>
        private void UnSubscribeFromMessage()
        {
            MessagingCenter.Unsubscribe<BaseViewModel, string>(this, "ViewModelMessage");
        }

        /// <summary>
        /// Overriden OnAppearing, listens for messages.
        /// </summary>
        protected override void OnAppearing()
        {
            ListenForMessage();
        }

        /// <summary>
        /// Overriden OnDisapering, unsubscribes from messages.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UnSubscribeFromMessage();
        }
    }
}
