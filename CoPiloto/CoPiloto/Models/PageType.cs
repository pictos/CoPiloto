using System;
using System.Collections.Generic;
using System.Text;

namespace CoPiloto.Models
{
    public class PageType
    {
        public string Name   { get; set; }

        public ViewModelType TypePage { get; set; }
    }

    public enum ViewModelType
    {
        GetChartViewModel,
        UnitsViewModel,
        FPViewViewModel
    }
}
