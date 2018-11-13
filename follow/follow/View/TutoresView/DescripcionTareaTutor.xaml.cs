using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.Infrastructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.TutoresView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DescripcionTareaTutor : ContentPage
	{
        string tareaClick;
		public DescripcionTareaTutor (string tarea)
		{
			InitializeComponent ();

            tareaClick = tarea;

            info.Text = "NOMBRE TAREA:   " + tareaClick;
            FechaInicio.ItemsSource = AccesoDatosTarea.ObtenerFechaInicio(tareaClick);
            FechaEntrega.ItemsSource = AccesoDatosTarea.ObtenerFechaFin(tareaClick);
            Descripcion.ItemsSource = AccesoDatosTarea.ObtenerDescripcion(tareaClick);

        }
    }
}