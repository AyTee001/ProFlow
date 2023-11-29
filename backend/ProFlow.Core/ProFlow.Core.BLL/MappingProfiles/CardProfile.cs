using AutoMapper;
using ProFlow.Core.Common.DTOs.CardDto;
using ProFlow.Core.DAL.Entities;

namespace ProFlow.Core.BLL.MappingProfiles
{
    public class CardProfile : Profile
    {
        public CardProfile() 
        { 
            CreateMap<Card, FullCardDto>()
                .ForMember(dest => dest.Checklists, opt => opt.Ignore());
        }
    }
}
