using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PagesXamarin.ViewModels
{
    public abstract class ViewModelBase : BindableBase, IDestructible, INavigationAware, IConfirmNavigation, IApplicationLifecycleAware, IPageLifecycleAware
    {

        //protected ICloudService _cloudService;
        //protected IExceptionService _exceptionService;
        protected INavigationService _navigationService;
        //protected IAuthenticationService _authenticationService;
        //protected IPageDialogService _pageDialogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WxsMobApp.ViewModels.ViewModelBase"/> class.
        /// </summary>
        /// <param name="pageDialogService">Page dialog service.</param>
        /// <param name="cloudService">Cloud service.</param>
        /// <param name="exceptionService">Exception service.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationService">Authentication service.</param>
        //public ViewModelBase(IPageDialogService pageDialogService, ICloudService cloudService, IExceptionService exceptionService, INavigationService navigationService, IAuthenticationService authenticationService)
        //{
        //    _pageDialogService = pageDialogService;
        //    _cloudService = cloudService;
        //    _exceptionService = exceptionService;
        //    _navigationService = navigationService;
        //    _authenticationService = authenticationService;

        //}



        /// <summary>
        /// Initializes a new instance of the <see cref="T:WxsMobApp.ViewModels.ViewModelBase"/> class.
        /// </summary>
        /// <param name="cloudService">Cloud service.</param>
        /// <param name="navigationService">Navigation service.</param>
        //public ViewModelBase(ICloudService cloudService, INavigationService navigationService)
        //{
        //    _cloudService = cloudService;
        //    _navigationService = navigationService;
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WxsMobApp.ViewModels.ViewModelBase"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ViewModelBase()
        {

        }

        protected Task _taskInit { get; set; }

        private bool _hasData;
        public bool HasData
        {
            get { return _hasData; }
            set { SetProperty(ref _hasData, value); }
        }

        string _pageTitle;
        public virtual string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        private string _subTitle;
        public string SubTitle
        {
            get { return _subTitle; }
            set { SetProperty(ref _subTitle, value); }
        }

        private bool _canLoadMore;
        public bool CanLoadMore
        {
            get { return _canLoadMore; }
            set { SetProperty(ref _canLoadMore, value); }
        }

        private string _headerText;
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }

        private string _footerText;
        public string FooterText
        {
            get { return _footerText; }
            set { SetProperty(ref _footerText, value); }
        }

        private bool _isBusy = false;
        public virtual bool IsBusy
        {
            get => _isBusy;
            set { SetProperty(ref _isBusy, value); }
        }


        public string Icon { get; set; }

        bool _isOffLine;
        public bool IsOffLine
        {
            get { return _isOffLine; }
            set
            {
                SetProperty(ref _isOffLine, value);

            }
        }

    

        bool _isPtBr;
   


        #region INavigationAware

        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        #endregion INavigationAware

        #region IDestructible

        public virtual void Destroy() { }

        #endregion IDestructible

        #region IConfirmNavigation

        public virtual bool CanNavigate(INavigationParameters parameters) => true;

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) =>
            Task.FromResult(CanNavigate(parameters));

        #endregion IConfirmNavigation

        #region IApplicationLifecycleAware

        public virtual void OnResume() { }

        public virtual void OnSleep() { }

        #endregion IApplicationLifecycleAware

        #region IPageLifecycleAware

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        #endregion IPageLifecycleAware

    }

}
