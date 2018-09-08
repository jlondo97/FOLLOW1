

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
            this.Email = "jlondo97@eafit.edu.co";
            this.Contraseña = "1234";
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

            if (this.Email != "jlondo97@eafit.edu.co" || this.Contraseña != "1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Login Error",
                    "Usuario o contraseña incorrecto",
                    "ok");
                this.Contraseña = string.Empty;
                return;
            }
            this.email = string.Empty;
            this.contraseña = string.Empty;

            MainViewModel.GetInstance().Seleccion = new SeleccionUsuarioViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SeleccionUsuarioPage());
            

        }

        public ICommand IsRegistrar
        {
            get;
            set;
        }

        #endregion
    }


}
