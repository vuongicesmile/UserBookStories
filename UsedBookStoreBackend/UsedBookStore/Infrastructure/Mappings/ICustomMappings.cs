using AutoMapper;

namespace UsedBookStore.Infrastructure.Mappings
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
