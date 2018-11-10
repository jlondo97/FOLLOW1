using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Estudiantes : ContentPage
    {
        public Estudiantes()
        {
            InitializeComponent();

            var TapProfile = new TapGestureRecognizer();
            TapProfile.Tapped += Tap_Profile;
            Tarea.GestureRecognizers.Add(TapProfile);

        }

        void Tap_Profile(object sender, EventArgs args)
        {

            Application.Current.MainPage.Navigation.PushAsync(new VistaTareasEducador());

        }
    }
}
