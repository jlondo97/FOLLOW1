﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using follow.Infrastructure;


namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AgregarGrupos : ContentPage

    {
        string MateriaSelected;
        ObservableCollection<Grupo> grupo = new ObservableCollection<Grupo>();

        public AgregarGrupos(string Materia)
        {
            MateriaSelected = Materia;

            string codigo = codigo_Grupo();
            Codigo.Text = string.Format("Codigo para tu grupo es :" + codigo);


            InitializeComponent();
            ListaGrupos.ItemsSource = AccesoDatosGrupo.ObtenerGrupos();
           
            var TapPlus = new TapGestureRecognizer();
            TapPlus.Tapped += TapPlus_Tapped;
            Plus.GestureRecognizers.Add(TapPlus);
        }

          public string codigo_Grupo()
            {
                var longitud = 6;
                string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < longitud--)
                {
                    res.Append(caracteres[rnd.Next(caracteres.Length)]);
                }
                return res.ToString();
            }

            void TapPlus_Tapped(object sender, EventArgs args)
             {

            EnteredName.Text = string.Empty;
            overlay.IsVisible = true;
            EnteredName.Focus();

            

             }

        void OnOKButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
            Coneccion6 conn = new Coneccion6();

            if (string.IsNullOrEmpty(this.EnteredName.Text))
            {
                DisplayAlert("Error", "No pusiste un nombre :( ", "oky");

            }


            else
            {

                int resultado = AccesoDatosGrupo.IngresarGrupo(EnteredName.Text, MateriaSelected);


                if (resultado > 0)
                {

                    DisplayAlert("Nuevo grupo Agregado", "Tu Grupo" + EnteredName.Text + " fue agregado con exito", "oky");
                   

                   

                }
                else
                {
                    DisplayAlert("Error", "Hubo un error en tu creacion de Grupo, intentalo otra vez", "Aceptar");
                }


            }
        }

            void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }
    }
}