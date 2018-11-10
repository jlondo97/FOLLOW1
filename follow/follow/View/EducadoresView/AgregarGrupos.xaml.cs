using System;
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

        public  string codigo_Grupo()
        {
            var posibles = "";
            Random obj = new Random();
            string sCadena = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = sCadena.Length;
            char cletra;
            int nlongitud = 6;
            string sNuevacadena = string.Empty;
            for (int i = 0; i < nlongitud; i++)
            {
                cletra =  posibles[obj.Next(nlongitud)];
                sNuevacadena += cletra.ToString();
            }
            return sNuevacadena;
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