using Microsoft.AspNetCore.Mvc;
using ProFlow.Core.BLL.Interfaces;
using ProFlow.Core.Common.DTOs.CardDto;
using ProFlow.Core.Common.DTOs.ChecklistDto;
using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.Entities.HelperEntities;

namespace ProFlow.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardsController(ICardService cardService) 
        { 
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<ActionResult<Card>> CreateNewCard()
        {
            return Ok(await _cardService.CreateCardAsync());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCard([FromBody] DeleteInfo cardDeleteInfo)
        {
            await _cardService.DeleteCardByIdAsync(cardDeleteInfo);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Card>>> GetAll()
        {
            return Ok(await _cardService.GetAllCardsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<Card>>> GetCardById([FromRoute] string id)
        {
            return Ok(await _cardService.GetCardByIdAsync(id));
        }

        [HttpPut]
        public async Task<ActionResult<Card>> UpdateCard([FromBody] CardUpdateDto cardUpdateDto)
        {
            return Ok(await _cardService.UpdateCardAsync(cardUpdateDto));
        }

        [HttpPut("checklists")]
        public async Task<ActionResult> UpdateCheckList([FromBody] ChecklistUpdateDto checklistUpdateDto)
        {
            await _cardService.UpdateCardChecklistAsync(checklistUpdateDto);
            return Ok();
        }

        [HttpPost("{cardId}/checklists")]
        public async Task<ActionResult> CreateCheckList([FromRoute] string cardId)
        {
            return Ok(await _cardService.CreateCardChecklistAsync(cardId));
        }

        [HttpDelete("{cardId}/checklists")]
        public async Task<ActionResult> DeleteCheckList([FromRoute] string cardId, [FromBody] DeleteInfo cardDeleteInfo)
        {
            await _cardService.DeleteCardChecklistByIdAsync(cardId, cardDeleteInfo);
            return Ok();
        }
    }
}
