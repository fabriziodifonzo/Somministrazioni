using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Data.Models.DBEntities;

namespace Somministrazioni.Data.Reporitories.User
{
    public sealed class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public IList<Operatore> OperatoreByUsername(string userName)
        {
            ChekOperatoreByUsernameParameter(userName);

            var listOperatoriToReturn = new List<Operatore>();
            var operatore = DbContext.Operatori.Where(item => item.Isactive == GenericConstants.FLAG_ISACTIVESHORT && item.Username == userName).SingleOrDefault();
            if (operatore != null)
            {
                listOperatoriToReturn.Add(operatore);
            }

            return listOperatoriToReturn.ToImmutableList();
        }

        static void ChekOperatoreByUsernameParameter(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(userName));
            }
        }
    }
}
