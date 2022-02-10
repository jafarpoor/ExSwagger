using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Model.Entites
{
    public class Link
    {
        public string URL { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
