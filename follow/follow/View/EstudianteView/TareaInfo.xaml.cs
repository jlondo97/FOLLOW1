using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using follow.Infrastructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EstudianteView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TareaInfo : ContentPage
	{
        string tareaClick;
		public TareaInfo (string tarea)
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