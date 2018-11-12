using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.View.EducadoresView;
using follow.Infrastructure;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaTareasEducador : ContentPage
    {
       
        public VistaTareasEducador(String Grupotomado)
        {

            InitializeComponent();
            grupotitle.Text = Grupotomado;
            ListaGrupos.ItemsSource = AccesoDatosGrupo.ObtenerCodigo(Grupotomado);
          

            var TapProfile = new TapGestureRecognizer();
            TapProfile.Tapped += Tap_Profile;
            Profile.GestureRecognizers.Add(TapProfile);

            var tapPlus = new TapGestureRecognizer();
            tapPlus.Tapped += NuevaTarea;
            Plus.GestureRecognizers.Add(tapPlus);
                
            
            


        }

        void Tap_Profile(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Estudiantes());
        }

        void NuevaTarea (object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushAsync(new CrearTareas());
        }

                    
            
		}

       

    }
