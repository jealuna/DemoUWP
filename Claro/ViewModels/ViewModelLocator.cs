using Claro.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary> 
    public class ViewModelLocator
    {
        public const string InicioKey = "Inicio";
        public const string DetalleKey = "Detalle";
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(InicioKey, typeof(Inicio));
            nav.Configure(DetalleKey, typeof(Detalle));
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<InicioViewModel>();
            SimpleIoc.Default.Register<DetalleViewmodel>(true);
        }

        public InicioViewModel Inicio
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InicioViewModel>();
            }
        }

        public DetalleViewmodel Detalle
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DetalleViewmodel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
