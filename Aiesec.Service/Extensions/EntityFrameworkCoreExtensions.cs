using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;

namespace Aiesec.Service.Extensions
{
    public static class EntityFrameworkCoreExtensions
    {
        public static IOrderedQueryable<TEntity> OrderByAscDesc<TEntity, TProperty>(this IQueryable<TEntity> query,
            Expression<Func<TEntity, TProperty>> keySelector, string order)
        {
            if (order == "desc")
                return query.OrderByDescending(keySelector);
            return query.OrderBy(keySelector);
        }

        public static ModelStateDictionary AddModelErrors(this ModelStateDictionary dictionary, IEnumerable<IdentityError> identityErrors)
        {
            if (identityErrors == null)
                throw new ArgumentNullException(nameof(identityErrors));
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            foreach (var error in identityErrors)
            {
                dictionary.AddModelError(error.Code, error.Description);
            }
            return dictionary;
        }
    }
}