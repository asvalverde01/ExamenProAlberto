using ExamenProAlberto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProAlberto.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private AV_Rootobject _selectedMovie;
        private List<AV_Rootobject> _moviesList;
        private string _apiKey = "76322bf3";
        private string _searchTerm;

        public AV_Rootobject SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public List<AV_Rootobject> MoviesList
        {
            get { return _moviesList; }
            set
            {
                _moviesList = value;
                OnPropertyChanged();
            }
        }

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var request = new HttpRequestMessage();
                    request.RequestUri = new Uri("https://www.omdbapi.com/?t=" + SearchTerm + "&apikey=" + _apiKey);
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");

                    var client = new HttpClient();
                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        String content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<AV_Rootobject>(content);
                        MoviesList = new List<AV_Rootobject> { result };
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
