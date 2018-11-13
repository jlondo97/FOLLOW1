using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.Infrastructure;
using follow.View.EducadoresView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.TutoresView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Grupos : ContentPage
	{
        string grupoclick;
        string grup;
		public Grupos (string grupo)
		{
			InitializeComponent ();
            grup = grupo;
            Title.Text = "Grupos del estudiante: ";
            ListaGrupos.ItemsSource = AccesoDatosGrupo.ObtenerGruposEst(grup);
		}

        private void ListaGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }


            var grupo = e.SelectedItem as Grupo;

            grupoclick = grupo.Nombre;


            Application.Current.MainPage.Navigation.PushAsync(new ListaTareasTutorPage(grupoclick));
        }
    }
}