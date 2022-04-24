using AlbumCopaClient.Core;
using AlbumCopaClient.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlbumCopaClient.ViewModels
{
    public class CreatePlayerCardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PlayerCard _playerCard;

        public PlayerCard PlayerCard
        {
            get { return _playerCard; }
            set
            {
                _playerCard = value;
                OnPropertyChanged();
            }
        }

        public CreatePlayerCardViewModel()
        {
            PlayerCard = new PlayerCard();
        }

        public async Task<bool> CreateNewPlayerCard()
        {
            try
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(UriPaths.PlayerCard);
                request.AddJsonBody(PlayerCard);
                RestResponse response = await client.ExecutePostAsync(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"{response.StatusCode}");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao buscar os jogadores.\nException: {ex.Message}", "Erro");
                return false;
            }
        }
    }
}
