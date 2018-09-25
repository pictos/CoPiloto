using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CoPiloto.Helpers
{
    public class CustomCollection<T> : ObservableCollection<T>
    {
        public CustomCollection() { }

        public CustomCollection(IEnumerable items) : this()
        {
            foreach (T item in items)
                this.Add(item);
        }


        public void ReportItemChanged(T item)
        {
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, item, IndexOf(item));
            OnCollectionChanged(args);
        }
    }
}
