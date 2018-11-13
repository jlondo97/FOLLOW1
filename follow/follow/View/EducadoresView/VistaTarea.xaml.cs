﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.Infrastructure;

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

            info.Text ="NOMBRE TAREA:   "+ tareaClick;
            FechaInicio.ItemsSource = AccesoDatosTarea.ObtenerFechaInicio(tareaClick);
            FechaEntrega.ItemsSource = AccesoDatosTarea.ObtenerFechaFin(tareaClick);
            Descripcion.ItemsSource = AccesoDatosTarea.ObtenerDescripcion(tareaClick);

            //ListaTareas.ItemsSource = AccesoDatosTarea.ObtenerTareas(tareaClick);

            
            
          
            
        

        }
	}
}