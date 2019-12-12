using Claro.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Claro.ViewModels
{
    public class InicioViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isLoading = false;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");

            }
        }
        private string _title;
        public string Title
        {

            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        private ObservableCollection<Pelicula> _peliculas;

        public ObservableCollection<Pelicula> Peliculas
        {
            get
            {
                return _peliculas;
            }
            set
            {
                _peliculas = value;
                RaisePropertyChanged("Peliculas");
            }
        }

        public RelayCommand<int> VerdetalleCommand { get; set; }
        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                if (value != _filter)
                {
                    _filter = value;
                    RaisePropertyChanged("Filter");
                }
            }
        }
        public InicioViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CargaCategoria(43864);
            VerdetalleCommand = new RelayCommand<int>(Verdetalle);
            Title = "Titulo";
        }

        private void Verdetalle(int IdPelicula)
        {
            Pelicula Detalle = Peliculas.First(x => x.id == IdPelicula);
            Messenger.Default.Send(Detalle);
            _navigationService.NavigateTo("Detalle", IdPelicula);   
        }

        private async void CargaCategoria(int Categoria)
        {
            try
            {
                Peliculas = await Services.Services.GetPeliculasCategoria(Categoria);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
