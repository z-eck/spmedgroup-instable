using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Situation
    {
        public Situation()
        {
            Schedulings = new HashSet<Scheduling>();
        }

        public byte IdSituation { get; set; }
        public string SituationDescription { get; set; }

        public virtual ICollection<Scheduling> Schedulings { get; set; }
    }
}
