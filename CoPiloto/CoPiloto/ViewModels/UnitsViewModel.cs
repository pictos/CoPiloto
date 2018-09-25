using CoPiloto.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoPiloto.ViewModels
{
    public class UnitsViewModel : BaseViewModel
    {
        #region Properties

        private decimal uk;

        public decimal Uk
        {
            get { return uk; }
            set { SetProperty(ref uk, value); }
        }


        private decimal si;

        public decimal SI
        {
            get { return si; }
            set { SetProperty(ref si, value); }
        }

        #endregion


        public UnitsViewModel()
        {

        }


        public void Calculate(decimal myValue, bool isUk = true)
        {
            if (isUk)
               SI = ConvertersValues.VelocitySI(myValue);

            else
               Uk = ConvertersValues.VelocityUK(myValue);
        }
    }
}
