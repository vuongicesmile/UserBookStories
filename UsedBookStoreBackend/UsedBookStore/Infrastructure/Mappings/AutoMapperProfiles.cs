using AutoMapper;
using UsedBookStore.DataAccess.DTOs;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.Infrastructure.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categories, CategoriesDTO>().ReverseMap();
            CreateMap<AddRequestCategories, Categories>().ReverseMap();
            CreateMap<UpdateCategoriesDTO, Categories>().ReverseMap();
            CreateMap<AddRequestWalksDto,Walk>().ReverseMap();
            CreateMap<WalkDto,Walk>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap(); 
            CreateMap<UpdateWalkDto, Walk>().ReverseMap();

            // xử lý auto mapper nếu userDTO và userDomian không giống nhau 
            /*một ví dụ về cách sử dụng AutoMapper để cấu hình quy tắc ánh xạ giữa hai đối tượng UserDTO và UserDomain, 
             * trong đó bạn muốn ánh xạ thuộc tính FullName của UserDTO sang thuộc tính Name của UserDomain.
             * ForMember cho phép chúng ta chỉ định rõ ràng ánh xạ cho một thuộc tính cụ thể,
             * 
            */
            //CreateMap<UserDTO, UserDomain>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
            //---------------------------------------------------
        }
    }

    //public class UserDTO
    //{
    //    public string FullName { get; set; }
    //}

    //public class UserDomain
    //{
    //    // nếu userDomain và userDto không giống nhau 
    //    // ví dụ là Name
    //    public string Name { get; set; }
    //}
}
