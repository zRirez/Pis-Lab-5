using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test
{
    public class Comparer : IComparer
    {
        public int Compare(object x1, object y1)
        {
            Product x = (Product)x1;
            Product y = (Product)y1;

            if ((x.id == y.id) && (x.name == y.name) && (x.country == y.country) && (x.coust == y.coust))
                return 0;
            return 1;
        }
    }
}
