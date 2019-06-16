using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain
{
    public class Slika : BaseEntity
    {
        public string Alt { get; set; }
        public string Putanja { get; set; }
        public int? VestId { get; set; }
        public Vest Vest { get; set; }

    }
}
