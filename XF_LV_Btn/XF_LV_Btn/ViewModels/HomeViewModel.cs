using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_LV_Btn.Models;
using XF_LV_Btn.Views;

namespace XF_LV_Btn.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        //Properties for list to hold a list of friends.
        private ObservableCollection<FriendModel> _friendList = new ObservableCollection<FriendModel>();
        public ObservableCollection<FriendModel> FriendList
        {
            get
            { return _friendList; }
            set
            {
                _friendList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This is the constructor.
        /// </summary>
        public HomeViewModel()
        {
            PopulateList();
            ListenForMessage();
        }

        /// <summary>
        /// This method listens for messages sent from the view.
        /// </summary>
        private void ListenForMessage()
        {
            MessagingCenter.Subscribe<HomePage, FriendModel>(this, "AcceptMessage", (sender, arg) => {
                FriendModel fm = arg;
                MessageToUser = "You accepted : " + fm.Name + " request to be your friend!";
                SendMessageToUser();
                ApproveRequest(fm);
            });

            MessagingCenter.Subscribe<HomePage, FriendModel>(this, "DenyMessage", (sender, arg) => {
                FriendModel fm = arg;
                MessageToUser = "You denied : " + fm.Name + " request to be your friend. :(";
                SendMessageToUser();
                DenyRequest(fm);
            });
        }

        /// <summary>
        /// In this method we could do several things when we approve a request, but for now this only calls a method
        /// to remove choosen item from the list.
        /// </summary>
        private void ApproveRequest(FriendModel fm)
        {
            FriendList = RemoveFromList(fm);
        }

        /// <summary>
        /// In this method we could do several things when we deny a request, but for now this only calls a method
        /// to remove choosen item from the list.
        /// </summary>
        private void DenyRequest(FriendModel fm)
        {
            FriendList = RemoveFromList(fm);
        }

        /// <summary>
        /// This method just removes an item from the list.
        /// </summary>
        private ObservableCollection<FriendModel> RemoveFromList(FriendModel fm)
        {
            foreach (var item in _friendList)
            {
                if (item.Name == fm.Name)
                {
                    _friendList.Remove(item);
                    break; 
                }
            }

            ObservableCollection<FriendModel> templist = new ObservableCollection<FriendModel >();
            templist = _friendList;
            return templist;
        }

        /// <summary>
        /// Populate the list with some mock values.
        /// </summary>
        private void PopulateList()
        {
            FriendList.Add(new FriendModel
            {
                Name = "Name 1"           
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 2"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 3"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 4"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 5"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 6"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 7"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 8"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 9"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 10"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 11"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 12"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 13"
            });

            FriendList.Add(new FriendModel
            {
                Name = "Name 14"
            });
        }
    }
}
