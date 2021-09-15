using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using Bookcrossing.Data.Entities;

namespace Bookcrossing.Application.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Author, AuthorDeteilsDto>().ReverseMap();
            CreateMap<Author, AuthorLookUpDto>();
            CreateMap<AuthorCreationDto, Author>();

            CreateMap<HistoryOfIssuingBooks, HistoryDto>();

            CreateMap<Publisher, PublisherDeteilsDto>().ReverseMap();
            CreateMap<Publisher, PublisherLookUpDto>();

            CreateMap<User, UserDeteilsDto>();

            CreateMap<Book, BookDeteilsDto>().ReverseMap();
            CreateMap<Book, BookLookUpDto>().ForMember(c => c.Description,
                opt => opt.MapFrom(
                    x => x.Description.Length > 140 ? x.Description.Substring(0, 140) : x.Description));
        }
    }
}
