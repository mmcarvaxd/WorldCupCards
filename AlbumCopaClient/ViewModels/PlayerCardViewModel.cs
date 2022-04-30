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
using System.Windows;

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

        /// <summary>
        /// Busca as cartas de jogadores na API utilizando GET e exibe no datagrid.
        /// </summary>
        public async void GetPlayerCards()
        {
            try
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(UriPaths.PlayerCard);
                RestResponse response = await client.ExecuteGetAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var pcl = JsonConvert.DeserializeObject<List<PlayerCard>>(response.Content);
                    PlayerCardList = new BindingList<PlayerCard>(pcl);
                }
                else
                {
                    throw new Exception($"{response.StatusCode}");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao buscar os jogadores.\nException: {ex.Message}", "Erro");
            }
        }

        /// <summary>
        /// Deleta a carta de jogador na API utilizando DELETE.
        /// </summary>
        /// <param name="playerCardToDelete"></param>
        /// <returns></returns>
        public async Task<bool> DeletePlayerCard(PlayerCard playerCardToDelete)
        {
            try
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(UriPaths.DeletePlayerCard(playerCardToDelete.CardNumber));
                RestResponse response = await client.DeleteAsync(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"{response.StatusCode}");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao deletar o jogador.\nException: {ex.Message}", "Erro");
                return false;
            }
        }

    }
}
