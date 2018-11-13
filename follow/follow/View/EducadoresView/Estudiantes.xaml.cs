using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using follow.View.EducadoresView;
using follow.Infrastructure;



namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Estudiantes : ContentPage
    {
        string grup;
        public Estudiantes(string Grupo)
        {
            InitializeComponent();
            grup = Grupo;

            ListEstudiantes.ItemsSource = AccesoDatosGrupo.ObtenerEstudiantes(grup);

        }

        void Tap_libro(object sender, EventArgs args)
        {

         // Application.Current.MainPage.Navigation.PushAsync(new VistaTareasEducador(" "));

        }
    }
}
