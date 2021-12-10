using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Clinic
    {
        public Clinic()
        {
            Medics = new HashSet<Medic>();
        }

        public byte IdClinic { get; set; }
        public string ClinicName { get; set; }
        public string Cnpj { get; set; }
        public string CorporateName { get; set; }
        public string ClinicAddress { get; set; }

        public virtual ICollection<Medic> Medics { get; set; }
    }
}
