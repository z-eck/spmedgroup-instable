using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class SituationRepository : ISituationRepository
    {
        readonly SPMGContext context = new();
        public List<Situation> ReadAll()
        {
            return context.Situations
                .Select(s => new Situation
                {
                    IdSituation = s.IdSituation,
                    SituationDescription = s.SituationDescription,
                })
                .ToList();
        }

        public Situation SearchByID(int idSituation)
        {
            return context.Situations
                .Select(s => new Situation
                {
                    IdSituation = s.IdSituation,
                    SituationDescription = s.SituationDescription,
                })
                .FirstOrDefault(s => s.IdSituation == idSituation);
        }
    }
}
