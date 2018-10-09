using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoPiloto.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        public override Task InitializeAsync(object[] args)
        {
            Navigation.InitMD();
            return Task.CompletedTask;
        }
    }
}
