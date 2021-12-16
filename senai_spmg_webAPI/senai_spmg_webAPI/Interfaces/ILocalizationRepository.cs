using senai_spmg_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmg_webAPI.Interfaces
{
    interface ILocalizationRepository
    {
        List<Localization> ReadAll();

        void Create(Localization newLocalization);
    }
}
