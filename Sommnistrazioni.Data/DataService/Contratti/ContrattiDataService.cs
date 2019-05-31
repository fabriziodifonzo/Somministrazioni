using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
using Sommnistrazioni.Data.DataService.Contratti;
using Sommnistrazioni.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.Distinte
{
    public class ContrattiDataService : IContrattiDataService
    {
        public ContrattiDataService(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;

            _listContratti = new List<ContrattoBrowsed>();
            var contrattoBrowsed1 = ContrattoBrowsed.Of("CodDistinta1");
            var contrattoBrowsed2 = ContrattoBrowsed.Of("CodDistinta2");
            var contrattoBrowsed3 = ContrattoBrowsed.Of("CodDistinta3");
            var contrattoBrowsed4 = ContrattoBrowsed.Of("CodDistinta4");
            var contrattoBrowsed5 = ContrattoBrowsed.Of("CodDistinta5");
            var contrattoBrowsed6 = ContrattoBrowsed.Of("CodDistinta6");
            var contrattoBrowsed7 = ContrattoBrowsed.Of("CodDistinta7");
            var contrattoBrowsed8 = ContrattoBrowsed.Of("CodDistinta8");
            var contrattoBrowsed9 = ContrattoBrowsed.Of("CodDistinta9");
            var contrattoBrowsed10 = ContrattoBrowsed.Of("CodDistinta10");
            var contrattoBrowsed11 = ContrattoBrowsed.Of("CodDistinta11");

            _listContratti.Add(contrattoBrowsed1);
            _listContratti.Add(contrattoBrowsed2);
            _listContratti.Add(contrattoBrowsed3);
            _listContratti.Add(contrattoBrowsed4);
            _listContratti.Add(contrattoBrowsed5);
            _listContratti.Add(contrattoBrowsed6);
            _listContratti.Add(contrattoBrowsed7);
            _listContratti.Add(contrattoBrowsed8);
            _listContratti.Add(contrattoBrowsed9);
            _listContratti.Add(contrattoBrowsed10);
            _listContratti.Add(contrattoBrowsed11);
        }

        public IList<ContrattoBrowsed> BrowseContratti(ContrattoFilter filtroRicerca)
        {
            CheckBrowserDistintaParameters(filtroRicerca);

            var offset = (filtroRicerca.CurrentPageNumb - 1) * filtroRicerca.PageSize + 1;
            var startIndex = offset - 1;

            int ItemCount = filtroRicerca.PageSize;
            if (_listContratti.Count - startIndex < filtroRicerca.PageSize)
            {
                ItemCount = filtroRicerca.PageSize - startIndex + 1;
            }

            return _listContratti.ToImmutableList().GetRange(startIndex, ItemCount);
        }

        public int CountDistinte(ContrattoFilter filtroRicerca)
        {
            CheckCountDistinteParameters(filtroRicerca);

            return _listContratti.Count;
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;
        readonly IList<ContrattoBrowsed> _listContratti;

        static void CheckConstructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }

        static void CheckBrowserDistintaParameters(ContrattoFilter filtroRicerca)
        {
            if (filtroRicerca == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filtroRicerca));
            }
        }

        static void CheckCountDistinteParameters(ContrattoFilter filtroRicerca)
        {
            if (filtroRicerca == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filtroRicerca));
            }
        }
    }
}
