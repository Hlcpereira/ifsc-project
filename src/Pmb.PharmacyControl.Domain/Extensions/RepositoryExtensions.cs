
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

using Pmb.PharmacyControl.CrossCutting.Utilities.Paging;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Contracts.Specs;

namespace Pmb.PharmacyControl.Domain.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<T> ListAsNoTracking<T>(this IRepository<T> repository, ISpec<T> spec)
            where T : class =>
            repository.ListAsNoTracking(where: spec.Predicate, includes: spec.Includes);

        public static IQueryable<T> ListAsNoTracking<T>(this IRepository<T> repository, ISpec<T> spec, IPagination pagination)
            where T : class =>
            repository.ListAsNoTracking(spec.Predicate, pagination, includes: spec.Includes);

        public static IQueryable<T> List<T>(this IRepository<T> repository, ISpec<T> spec)
            where T : class =>
            repository.List(where: spec.Predicate, includes: spec.Includes);

        public static IQueryable<T> List<T>(this IRepository<T> repository, ISpec<T> spec, IPagination pagination)
            where T : class =>
            repository.List(spec.Predicate, pagination, includes: spec.Includes);
        
        public static Task<T> FindAsNoTrackingAsync<T>(this IRepository<T> repository, ISpec<T> spec)
            where T : class =>
            repository.ListAsNoTracking(where: spec.Predicate, includes: spec.Includes).FirstOrDefaultAsync();

        public static Task<T> FindAsync<T>(this IRepository<T> repository, ISpec<T> spec)
            where T : class =>
            repository.List(where: spec.Predicate, includes: spec.Includes).FirstOrDefaultAsync();

        public static async Task<PagedList<V>> ViewModelPagedListAsNoTrackingAsync<T, V>(
            this IRepository<T> repository,
            ISpec<T> spec,
            IPagination pagination,
            Func<IQueryable<T>, IQueryable<V>> ToVm)
            where T : class
            where V : class
        {
            var total = await repository.CountAsync(spec.Predicate);

            var listAsNoTracking = repository.ListAsNoTracking(where: spec.Predicate, pagination: pagination, includes: spec.Includes);

            var items = ToVm(listAsNoTracking)?.ToList();
            return new PagedList<V>(items, total, pagination.PageSize);
        }
    }
}
