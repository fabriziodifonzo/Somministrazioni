using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Data.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService
{
    public abstract class DataServiceBase
    {
        protected DataServiceBase(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator;
            _dbContextScopeFactory = new DbContextScopeFactory();
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

        /// <summary>
        /// This method give back a comoumn length.
        /// </summary>
        public int GetMaxLength<T>(Expression<Func<T, string>> column)
        {
            int result = 0;
            using (var context = new SomministrazioneDbContext())
            {
                var entType = typeof(T);
                var columnName = ((MemberExpression)column.Body).Member.Name;

                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                var test = objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace);

                if (test == null)
                {
                    return 0;
                }

                var q = test
                    .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                    .SelectMany(meta => ((System.Data.Entity.Core.Metadata.Edm.EntityType)meta).Properties
                    .Where(p => p.Name == columnName && p.TypeUsage.EdmType.Name == "String"));

                var queryResult = q.Where(p =>
                {
                    var match = p.DeclaringType.Name == entType.Name;
                    if (!match)
                        match = entType.Name == p.DeclaringType.Name;

                    return match;

                })
                    .Select(sel => sel.TypeUsage.Facets["MaxLength"].Value)
                    .ToList();

                if (queryResult.Any())
                    result = Convert.ToInt32(queryResult.First());

                return result;
            }

        }

        protected readonly IDbContextScopeFactory _dbContextScopeFactory;
        protected readonly IAmbientDbContextLocator _ambientDbContextLocator;
    }
}
