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

namespace Sommnistrazioni.Data.DataService.Contratti
{
    public class ContrattiDataService : IContrattiDataService
    {
        public ContrattiDataService(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;

            _listContratti = new List<ContrattoBrowsed>();
            var contrattoBrowsed1 = ContrattoBrowsed.Of("CodContratto1");
            var contrattoBrowsed2 = ContrattoBrowsed.Of("CodContratto2");
            var contrattoBrowsed3 = ContrattoBrowsed.Of("CodContratto3");
            var contrattoBrowsed4 = ContrattoBrowsed.Of("CodContratto4");
            var contrattoBrowsed5 = ContrattoBrowsed.Of("CodContratto5");
            var contrattoBrowsed6 = ContrattoBrowsed.Of("CodContratto6");
            var contrattoBrowsed7 = ContrattoBrowsed.Of("CodContratto7");
            var contrattoBrowsed8 = ContrattoBrowsed.Of("CodContratto8");
            var contrattoBrowsed9 = ContrattoBrowsed.Of("CodContratto9");
            var contrattoBrowsed10 = ContrattoBrowsed.Of("CodContratto10");
            var contrattoBrowsed11 = ContrattoBrowsed.Of("CodContratto11");

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
            CheckBrowserContrattoParameters(filtroRicerca);

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

        static void CheckBrowserContrattoParameters(ContrattoFilter filtroRicerca)
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
