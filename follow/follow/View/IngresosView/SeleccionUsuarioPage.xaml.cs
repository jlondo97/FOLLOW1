namespace follow.View.IngresosView
{ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
    using TutoresView;
    using EstudianteView;
    using EducadoresView;




	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class SeleccionUsuarioPage : ContentPage
	{
		public SeleccionUsuarioPage (string correo)
		{
			InitializeComponent ();
            Usuario.Text = string.Format("Bienvenid@" + correo);

            var TapTablero = new TapGestureRecognizer();
            TapTablero.Tapped += tapTablero_Tapped;
            Tablero.GestureRecognizers.Add(TapTablero);

            var TapLapiz = new TapGestureRecognizer();
            TapLapiz.Tapped += tapLapiz_Tapped;
            Lapiz.GestureRecognizers.Add(TapLapiz);

            var TapCasa = new TapGestureRecognizer();
            TapCasa.Tapped += tapCasa_Tapped;
            Casa.GestureRecognizers.Add(TapCasa); 

            #region eventos


            void tapTablero_Tapped(object sender, EventArgs arg)
            {
               
                Application.Current.MainPage.Navigation.PushAsync(new MateriasProfesPage(correo));
            }

            void tapLapiz_Tapped(object sender, EventArgs args)
            {
                Application.Current.MainPage.Navigation.PushAsync(new MateriasEstudiantesPage());
            }

           void tapCasa_Tapped(object sender, EventArgs args)
           {
            Application.Current.MainPage.Navigation.PushAsync(new AgregarHijo(correo));
            }

            #endregion
        }
    }
}