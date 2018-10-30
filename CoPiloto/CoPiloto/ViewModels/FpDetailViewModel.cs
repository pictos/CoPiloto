using System;
using System.Collections.Generic;
using System.Text;
using APIFP.Model;
using System.Threading.Tasks;

namespace CoPiloto.ViewModels
{
    sealed class FpDetailViewModel : BaseViewModel
    {
        #region Properties

        #endregion


        public override Task InitializeAsync(object[] args)
        {
            var fp = (GenerateResponseFP)args[0];

            Title = $"{fp.FromIcao} => {fp.ToIcao}";
            

            return base.InitializeAsync(args);
        }


    }
}
