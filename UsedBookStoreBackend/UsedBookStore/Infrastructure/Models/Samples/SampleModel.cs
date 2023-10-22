using AutoMapper;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.Infrastructure.Mappings;

namespace UsedBookStore.Infrastructure.Models.Samples
{
    public class SampleModel : ICustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Sample, SampleModel>();
            configuration.CreateMap<SampleModel, Sample>();
        }
    }
}
