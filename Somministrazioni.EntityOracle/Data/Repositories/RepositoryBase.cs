using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Data.Models.DBEntities;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckCostructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;
        }

        protected SomministrazioneDbContext DbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<SomministrazioneDbContext>();

                if (dbContext == null)
                {
                    throw new InvalidOperationException(String.Format(GenericConstants.ERRMSG_AMBIENTDBCONTEXT, typeof(SomministrazioneDbContext)));
                }

                return dbContext;
            }
        }

        static void CheckCostructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }

        protected readonly IAmbientDbContextLocator _ambientDbContextLocator;
    }
}
