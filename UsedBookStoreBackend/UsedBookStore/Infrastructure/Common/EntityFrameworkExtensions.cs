using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace UsedBookStore.Infrastructure.Common
{
    public static class EntityFrameworkExtensions
    {
        private static IMapper Mapper { get; set; }

        public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source)
        {
            return source.ProjectTo<TDestination>(Mapper.ConfigurationProvider);
        }

        public static TDestination MapTo<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public static IList<TDestination> MapToList<TDestination>(this object source)
        {
            return Mapper.Map<IList<TDestination>>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

        public static TDestination MapToList<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}
