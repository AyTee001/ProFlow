using MongoDB.Bson;
using ProFlow.Core.Common.DTOs.CardDto;
using ProFlow.Core.Common.DTOs.ChecklistDto;
using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.Entities.HelperEntities;
using System.Linq.Expressions;

namespace ProFlow.Core.BLL.Interfaces
{
    public interface ICardService
    {
        Task<ICollection<FullCardDto>> GetAllCardsByFilterAsync(Expression<Func<Card, bool>> filter);
        Task<ICollection<FullCardDto>> GetAllCardsAsync();
        Task<FullCardDto> GetCardByIdAsync(string cardId);
        Task DeleteCardByIdAsync(DeleteInfo cardDeleteInfo);
        Task DeleteCardChecklistByIdAsync(DeleteInfo cardDeleteInfo);
        Task<FullCardDto> CreateCardAsync();
        Task<Checklist> CreateCardChecklistAsync(string cardId);
        Task UpdateCardChecklistAsync(ChecklistUpdateDto checklist);
        Task<FullCardDto> UpdateCardAsync(CardUpdateDto cardUpdateDto);
    }
}
