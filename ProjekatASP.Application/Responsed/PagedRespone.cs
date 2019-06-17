using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Responsed
{
    public class PagedRespone<T>
    {
        public int UkupnoPronadjeno { get; set; }
        public int BrojStrana { get; set; }
        public int TrenutnaStrana { get; set; }

        public IEnumerable<T> Data { get; set; }

    }
}
