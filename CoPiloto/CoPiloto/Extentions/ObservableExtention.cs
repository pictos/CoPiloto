using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoPiloto.Extentions
{
    static class ObservableExtention
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable array)
        {
            //if (array.GetType() != typeof(T))
            //    throw new Exception("Os tipos são diferentes!");

            foreach (T item in array)
                collection.Add(item);
        }
    }
}
