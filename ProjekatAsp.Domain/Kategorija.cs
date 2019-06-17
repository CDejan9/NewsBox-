using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain 
{
    public class Kategorija : BaseEntity
    {
        public string Naziv { get; set; }
        public ICollection<Vest> Vests { get; set; }

        public Kategorija Where()
        {
            throw new NotImplementedException();
        }
    }

}
