using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
using Sommnistrazioni.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.Distinte
{
    public class DistinteDataService : IDistinteDataService
    {
        public DistinteDataService(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;

            _listDistinte = new List<DistintaBrowsed>();
            var distintaBrowsed1 = DistintaBrowsed.Of("CodDistinta1", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed2 = DistintaBrowsed.Of("CodDistinta2", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed3 = DistintaBrowsed.Of("CodDistinta3", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed4 = DistintaBrowsed.Of("CodDistinta4", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed5 = DistintaBrowsed.Of("CodDistinta5", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed6 = DistintaBrowsed.Of("CodDistinta6", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed7 = DistintaBrowsed.Of("CodDistinta7", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed8 = DistintaBrowsed.Of("CodDistinta8", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed9 = DistintaBrowsed.Of("CodDistinta9", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed10 = DistintaBrowsed.Of("CodDistinta10", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);
            var distintaBrowsed11 = DistintaBrowsed.Of("CodDistinta11", Somministrazioni.Common.Enums.StatoDistinta.Pianificata);

            _listDistinte.Add(distintaBrowsed1);
            _listDistinte.Add(distintaBrowsed2);
            _listDistinte.Add(distintaBrowsed3);
            _listDistinte.Add(distintaBrowsed4);
            _listDistinte.Add(distintaBrowsed5);
            _listDistinte.Add(distintaBrowsed6);
            _listDistinte.Add(distintaBrowsed7);
            _listDistinte.Add(distintaBrowsed8);
            _listDistinte.Add(distintaBrowsed9);
            _listDistinte.Add(distintaBrowsed10);
            _listDistinte.Add(distintaBrowsed11);
        }

        public IList<DistintaBrowsed> BrowserDistinta(DistintaFilter filter)
        {
            CheckBrowserDistintaParameters(filter);

            var offset = (filter.CurrentPageNumb - 1) * filter.PageSize + 1;
            var startIndex = offset - 1;

            int ItemCount = filter.PageSize;
            if (_listDistinte.Count - startIndex < filter.PageSize)
            {
                ItemCount = filter.PageSize - startIndex + 1;
            }

            return _listDistinte.ToImmutableList().GetRange(startIndex, ItemCount);
        }

        public int CountDistinte(DistintaFilter filter)
        {
            CheckCountDistinteParameters(filter);

            return _listDistinte.Count;
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;
        readonly IList<DistintaBrowsed> _listDistinte;

        static void CheckConstructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }

        static void CheckBrowserDistintaParameters(DistintaFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filter));
            }
        }

        static void CheckCountDistinteParameters(DistintaFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filter));
            }
        }
    }
}
