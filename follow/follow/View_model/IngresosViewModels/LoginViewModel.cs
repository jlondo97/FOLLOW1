

namespace follow.View_models.IngresosViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.ComponentModel;
    using View.IngresosView;
    using View_model.IngresosViewModel;
    using follow.View_model;
    using follow.Infrastructure;
    using System.Data.SqlClient;

    public class LoginViewModel : BaseViewModel
    {
        

        #region atributos
        private String contraseña;
        private String email;

        #endregion

        #region Propiedasdes(definiciones)

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                SetValue(ref this.email, value);
            }
        }
          
            

        public string Contraseña
        {
            get
            {
                return this.contraseña;
         
            }
            set
            {
                SetValue(ref this.contraseña, value);
                
            }
        }

        public bool IsRunning
        {
            get;
            set;
        }

        public bool IsRemember
        {
            get;
            set;
        }

        #region Contructor
        public LoginViewModel()
        {
            this.IsRemember = true;
        }
        #endregion

        #endregion

        #region Region bottones (commands)

        public ICommand IsEntrar
        {
            get
            {
                return new RelayCommand(Entrar);
            }

        }




        private async void Entrar()

        {
           if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error con el Email",
                    "Debes poner un Email -.-"
                    , "Aceppt");
                return;
            }

            if (string.IsNullOrEmpty(this.Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert("Error con la contraseña",
                    "Debes poner un Contraseña -.-"
                    , "Aceppt");
                return;
            }

           
            string conexion = Login(this.email, this.contraseña);
            
            this.email = "";
            this.contraseña = "";
            this.email = string.Empty;
            this.contraseña = string.Empty;
            if (conexion == "Failure")
            {
                await Application.Current.MainPage.DisplayAlert("Sorry :(",  "Hubo un error en la conexión", "ok");

            }
            else
            {
                if (conexion != "Bienvenido")
                {
                    await Application.Current.MainPage.DisplayAlert("Sorry :(", conexion, "ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("En hora buena ", conexion + " A Follow", "Aceptar");

                    MainViewModel.GetInstance().Seleccion = new SeleccionUsuarioViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new SeleccionUsuarioPage());
                }
            }

        }

        public static string Login(string email, string Pass)
        {
            try
            {
                SqlDataReader reader = Coneccion6.Select("UserPassword", "UserLogin","where Email = '" + email + "'" );
                string str = string.Empty;
                string Des = string.Empty;

                while (reader.Read())
                {
                    str = reader.GetString(0);
                }

                if (str == string.Empty)
                {
                    Des = "No existe cuenta";
                }
                if (str != string.Empty)
                {
                    if (Pass == str)
                    {
                        Des = "Bienvenido";
                    }
                    else
                    {
                        Des = "Contraseña no valida";
                    }
                }


                return Des;

            }
            catch (Exception e)
            {
                return "Failure";
                throw e;
            }
        }

        public ICommand IsRegistrar
        {
            get;
            set;
        }

        #endregion
    }


}
