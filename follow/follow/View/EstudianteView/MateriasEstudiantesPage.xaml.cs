﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EstudianteView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MateriasEstudiantesPage : ContentPage
	{
		public MateriasEstudiantesPage ()
		{
			InitializeComponent ();

            var TapPlus = new TapGestureRecognizer();
            TapPlus.Tapped += TapPlus_Tapped;
            Plus.GestureRecognizers.Add(TapPlus);
        }

        void TapPlus_Tapped(object sender, EventArgs args)
        {

            EnteredName.Text = string.Empty;           
            overlay.IsVisible = true;
            EnteredName.Focus();

        }

          void OnOKButtonClicked(object sender, System.EventArgs args)
        {
            overlay.IsVisible = false;
           // {
               // DisplayAlert("Error", "Debes Agregar Estudiante o Identificacion", "oky");

            //}

            //else
            //{
                DisplayAlert("Nuevo Curso Agregado","Tu curso Matematicas 11 fue agregado con exito", "oky");

              //  estudiantes.Add(new Estudiante { Nombre = EnteredName.Text, Id = Identificacion.Text });
            //}   


        }
 
        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }
    }
}