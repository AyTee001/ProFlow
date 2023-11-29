using AutoMapper;
using MongoDB.Driver;
using ProFlow.Core.BLL.Interfaces;
using ProFlow.Core.BLL.Services.Base;
using ProFlow.Core.Common.DTOs.CardDto;
using ProFlow.Core.Common.DTOs.ChecklistDto;
using ProFlow.Core.Common.Exceptions;
using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.Entities.HelperEntities;
using ProFlow.Core.DAL.MongoDbData;
using ProFlow.Core.DAL.SqlServerData.Context;
using System.Linq.Expressions;

namespace ProFlow.Core.BLL.Services
{
    public class CardService : BaseService, ICardService
    {
        public CardService(ProFlowMongoDbContext mongoContext, ProFlowSqlContext sqlContext, IMapper mapper)
            : base(mongoContext, sqlContext, mapper) { }

        public async Task<FullCardDto> CreateCardAsync()
        {
            return _mapper.Map<FullCardDto>(await _mongoContext.Cards.AddAsync(new Card("New Card", "")));
        }

        public async Task DeleteCardByIdAsync(DeleteInfo cardDeleteInfo)
        {
            var card = await _mongoContext.Cards.GetById(cardDeleteInfo.Id!) ?? throw new NotFoundException();

            await _mongoContext.Cards.DeleteOneAsync(cardDeleteInfo);

            await _mongoContext.Checklists.DeleteManyNoConcurrencyControlAsync(cl => card.ChecklistIds.Contains(cl.Id!));
        }

        public async Task<ICollection<FullCardDto>> GetAllCardsByFilterAsync(Expression<Func<Card, bool>> filter)
        {
            var collection = await _mongoContext.Cards.GetAll(filter);
            var checklists = await _mongoContext.Checklists.GetAll();

            return collection.Select(x =>
                {
                    var res = _mapper.Map<FullCardDto>(x);

                    if (x.ChecklistIds != null && x.ChecklistIds.Any())
                    {
                        res.Checklists = checklists.Where(y => x.ChecklistIds.Contains(y.Id!)).ToList();
                    }
                    else
                    {
                        res.Checklists = new List<Checklist>();
                    }

                    return res;
                }).ToList();
        }

        public async Task<ICollection<FullCardDto>> GetAllCardsAsync()
        {
            var collection = await _mongoContext.Cards.GetAll();
            var checklists = await _mongoContext.Checklists.GetAll();

            return collection.Select(x =>
            {
                var res = _mapper.Map<FullCardDto>(x);

                if (x.ChecklistIds != null && x.ChecklistIds.Any())
                {
                    res.Checklists = checklists.Where(y => x.ChecklistIds.Contains(y.Id!)).ToList();
                }
                else
                {
                    res.Checklists = new List<Checklist>();
                }

                return res;
            }).ToList();

        }

        public async Task<FullCardDto> GetCardByIdAsync(string cardId)
        {
            var card = await _mongoContext.Cards.GetById(cardId) ?? throw new NotFoundException();

            var checklists = await _mongoContext.Checklists.GetAll(x => card.ChecklistIds.Contains(x.Id!));

            var fullCardDto = _mapper.Map<FullCardDto>(card);
            fullCardDto.Checklists = checklists.ToList();
            return fullCardDto;
        }

        public async Task<FullCardDto> UpdateCardAsync(CardUpdateDto cardUpdateDto)
        {
            var updateDef = Builders<Card>.Update
                .Set(r => r.Priority, cardUpdateDto.Priority)
                .Set(r => r.Title, cardUpdateDto.Title)
                .Set(r => r.StartAt, cardUpdateDto.StartAt)
                .Set(r => r.DeadlineAt, cardUpdateDto.DeadlineAt)
                .Set(r => r.Description, cardUpdateDto.Description)
                .Set(r => r.TagIds, cardUpdateDto.TagIds);

            var card = await _mongoContext.Cards.UpdateOneAsync(cardUpdateDto, updateDef);
            var checklists = await _mongoContext.Checklists.GetAll(x => card.ChecklistIds.Contains(x.Id!));

            var fullCardDto = _mapper.Map<FullCardDto>(card);
            fullCardDto.Checklists = checklists.ToList();
            return fullCardDto;
        }

        public async Task UpdateCardChecklistAsync(ChecklistUpdateDto checklistUpdateDto)
        {
            var updateDef = Builders<Checklist>.Update
                .Set(r => r.Title, checklistUpdateDto.Title)
                .Set(r => r.ListItems, checklistUpdateDto.ListItems);

            await _mongoContext.Checklists.UpdateOneAsync(checklistUpdateDto, updateDef);
        }

        public async Task DeleteCardChecklistByIdAsync(string cardId, DeleteInfo checklistDeleteInfo)
        {
            var card = await _mongoContext.Cards.GetById(cardId) ?? throw new NotFoundException();

            await _mongoContext.Checklists.DeleteOneAsync(checklistDeleteInfo);

            card.ChecklistIds.Remove(checklistDeleteInfo.Id!);

            await _mongoContext.Cards.UpdateOneAsync(card,
                Builders<Card>.Update
                .Set(r => r.ChecklistIds, card.ChecklistIds));
        }

        public async Task<Checklist> CreateCardChecklistAsync(string cardId)
        {
            var checklist = await _mongoContext.Checklists.AddAsync(new Checklist("New Checklist"));

            var updateDef = Builders<Card>.Update.Push(c => c.ChecklistIds, checklist.Id);

            var card = await _mongoContext.Cards.GetById(cardId) ?? throw new NotFoundException();

            try
            {
                await _mongoContext.Cards.UpdateOneAsync(card, updateDef);
            }
            catch
            {
                await DeleteCardChecklistByIdAsync(cardId, new DeleteInfo { Id = checklist.Id, Version = checklist.Version });
                throw;
            }

            return checklist;
        }
    }
}
