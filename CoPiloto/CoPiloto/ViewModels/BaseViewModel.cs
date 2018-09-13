using CoPiloto.Services.Navigation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoPiloto.ViewModels
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        public static CultureInfo culture = new CultureInfo("pt-BR");

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public async Task DisplayAlert(string title, string message, string cancel = "Ok") =>
          await Application.Current.MainPage.DisplayAlert(title, message, cancel);

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel) =>
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

        public virtual Task InitializeAsync(object[] args) => Task.FromResult(true);

        protected NavigationService Navigation => NavigationService.Current;

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                    MyChangeCanExecute();
            }
        }

        protected virtual void MyChangeCanExecute() { }

        public bool IsBusyStatus() => !IsBusy;


        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

    }
}
