using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects;
using Bookcrossing.Data.Entities;

namespace Bookcrossing.Application.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<HistoryOfIssuingBooks, HistoryDto>();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<User, UserDto>();
           

        }
    }
}
