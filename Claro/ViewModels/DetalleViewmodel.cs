using Claro.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Claro.ViewModels
{
    public class DetalleViewmodel : ViewModelBase
    {
        private readonly INavigationService _navigationService;        
        private Pelicula _pelicula;
        public RelayCommand RegresaCommand { get; set; }
        public Pelicula Pelicula
        {

            get
            {
                return _pelicula;
            }
            set
            {
                if (value != _pelicula)
                {
                    _pelicula = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        public DetalleViewmodel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            RegresaCommand = new RelayCommand(Regresa);
            Messenger.Default.Register<Pelicula>(this, (action) => ReceiveMessage(action));
        }

        private void Regresa()
        {
            _navigationService.GoBack();
        }

        private void ReceiveMessage(Pelicula action)
        {
            Pelicula = action;
        }
    }
}
