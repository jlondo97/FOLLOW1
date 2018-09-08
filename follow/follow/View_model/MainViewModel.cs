


namespace follow.View_model
{
    using follow.View_model.IngresosViewModel;
  

    class MainViewModel
    {
        #region ViewModels

        public View_models.IngresosViewModels.LoginViewModel Login
        {
            get;
            set;
        }

        public SeleccionUsuarioViewModel Seleccion

        {
            get;
            set;
        }        
        #endregion

        #region Constructors

        public MainViewModel()
        {
            Instace = this;
            this.Login = new View_models.IngresosViewModels.LoginViewModel();
        }
        #endregion

        #region singleton
        private static MainViewModel Instace;

        public static MainViewModel GetInstance()
        {
            if (Instace == null)
            {
                return new MainViewModel();
            }

            return Instace;
        }
        #endregion

    }
}
