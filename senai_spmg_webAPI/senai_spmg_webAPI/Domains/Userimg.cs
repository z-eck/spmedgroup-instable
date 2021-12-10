using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Userimg
    {
        public int IdUserImg { get; set; }
        public int IdUser { get; set; }
        public byte[] BinaryNumber { get; set; }
        public string MimeType { get; set; }
        public string ArchiveName { get; set; }
        public DateTime? InclusionDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
