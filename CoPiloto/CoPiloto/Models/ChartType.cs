using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoPiloto.Models
{
    public class LocalChart
    {
        public string Uri { get; set; }

        public string ChartName { get; set; }

        public Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }
    }
}
