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
	public partial class ListaTareasTutorPage : ContentPage
	{
        string TareaClick;
        string Grup;
        public ListaTareasTutorPage (string Grupotomado)
		{
			InitializeComponent ();
            grupotitle.Text = " Grupo : " + Grupotomado;
            Grup = Grupotomado;
            CodigoEnlace.ItemsSource = AccesoDatosGrupo.ObtenerCodigo(Grup);
            ListaTareas.ItemsSource = AccesoDatosTarea.ObtenerTareas(Grup);
        }

        private void ListaTareas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }


            var tarea = e.SelectedItem as Tarea;

            TareaClick = tarea.Nombre;


            Application.Current.MainPage.Navigation.PushAsync(new DescripcionTareaTutor(TareaClick));
        }
    }
}