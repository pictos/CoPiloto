using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoPiloto.Models
{
    public class ChartType
    {
        public string Type { get; set; }

        public ObservableCollection<Approach> Charts { get; set; }

        public bool IsVisible { get; set; }

        public int ChildrenRequest => Charts?.Count * 50 ?? 0;
    }
}
