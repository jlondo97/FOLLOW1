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
	public partial class TareaEstudiante : ContentPage
	{
		public TareaEstudiante (string grupo)
		{
            
			InitializeComponent ();
            ListaTareas.ItemsSource = AccesoDatosTarea.ObtenerTareas(grupo);
		}
	}
}