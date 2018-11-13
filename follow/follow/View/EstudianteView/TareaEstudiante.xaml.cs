using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.Infrastructure;
using follow.View.EducadoresView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EstudianteView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TareaEstudiante : ContentPage
	{
        string TareaClick;

        public TareaEstudiante (string grupo)
		{
            
			InitializeComponent ();
            ListaTareas.ItemsSource = AccesoDatosTarea.ObtenerTareas(grupo);
		}

        private void ListaTareas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }


            var tarea = e.SelectedItem as Tarea;

            TareaClick = tarea.Nombre;


            Application.Current.MainPage.Navigation.PushAsync(new TareaInfo(TareaClick));
        }
    }
}