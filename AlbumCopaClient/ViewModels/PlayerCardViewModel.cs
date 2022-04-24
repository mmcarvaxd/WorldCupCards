using AlbumCopaClient.Core;
using AlbumCopaClient.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaClient.ViewModels
{
    public class PlayerCardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BindingList<PlayerCard> _playerCardList;

        public BindingList<PlayerCard> PlayerCardList
        {
            get { return _playerCardList; }
            set 
            { 
                _playerCardList = value;
                OnPropertyChanged();
            }
        }


        public PlayerCardViewModel()
        {

        }

        public Task InitUC()
        {
            GetPlayerCards();
            return Task.CompletedTask;
        }

        public async void GetPlayerCards()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(UriPaths.PlayerCard);
            RestResponse response = await client.ExecuteGetAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var pcl = JsonConvert.DeserializeObject<List<PlayerCard>>(response.Content);
                PlayerCardList = new BindingList<PlayerCard>(pcl);
            }
        }

    }
}
