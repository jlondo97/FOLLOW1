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
	public partial class VistaTarea : ContentPage
	{
        string tareaClick;
		public VistaTarea (string tarea)
		{
			InitializeComponent ();
            tareaClick = tarea;
            labeltarea.Text = "tarea: " + tareaClick;
		}
	}
}