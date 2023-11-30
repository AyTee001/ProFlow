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

        /// <summary>
        /// Creates a new card.
        /// </summary>
        /// <returns>The newly created card.</returns>
        [HttpPost]
        public async Task<ActionResult<Card>> CreateNewCard()
        {
            return Ok(await _cardService.CreateCardAsync());
        }

        /// <summary>
        /// Deletes a card by its ID.
        /// </summary>
        /// <param name="cardDeleteInfo">The card delete information data transfer object.</param>
        [HttpDelete]
        public async Task<ActionResult> DeleteCard([FromBody] DeleteInfo cardDeleteInfo)
        {
            await _cardService.DeleteCardByIdAsync(cardDeleteInfo);
            return NoContent();
        }

        /// <summary>
        /// Retrieves all cards.
        /// </summary>
        /// <returns>A collection of all cards.</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<Card>>> GetAll()
        {
            return Ok(await _cardService.GetAllCardsAsync());
        }

        /// <summary>
        /// Retrieves a card by its ID.
        /// </summary>
        /// <param name="id">The ID of the card to retrieve.</param>
        /// <returns>The requested card.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<Card>>> GetCardById([FromRoute] string id)
        {
            return Ok(await _cardService.GetCardByIdAsync(id));
        }

        /// <summary>
        /// Updates an existing card.
        /// </summary>
        /// <param name="cardUpdateDto">The card update data transfer object.</param>
        /// <returns>The updated card.</returns>
        [HttpPut]
        public async Task<ActionResult<Card>> UpdateCard([FromBody] CardUpdateDto cardUpdateDto)
        {
            return Ok(await _cardService.UpdateCardAsync(cardUpdateDto));
        }

        /// <summary>
        /// Updates the checklist for a card.
        /// </summary>
        /// <param name="checklistUpdateDto">The checklist update data transfer object.</param>
        [HttpPut("checklists")]
        public async Task<ActionResult> UpdateCheckList([FromBody] ChecklistUpdateDto checklistUpdateDto)
        {
            await _cardService.UpdateCardChecklistAsync(checklistUpdateDto);
            return Ok();
        }

        /// <summary>
        /// Creates a new checklist for the specified card.
        /// </summary>
        /// <param name="cardId">The ID of the card to create a checklist for.</param>
        /// <returns>The newly created checklist.</returns>
        [HttpPost("{cardId}/checklists")]
        public async Task<ActionResult> CreateCheckList([FromRoute] string cardId)
        {
            return Ok(await _cardService.CreateCardChecklistAsync(cardId));
        }

        /// <summary>
        /// Deletes a checklist from the specified card.
        /// </summary>
        /// <param name="cardId">The ID of the card containing the checklist to delete.</param>
        /// <param name="cardDeleteInfo">The checklist delete information data transfer object.</param>
        [HttpDelete("{cardId}/checklists")]
        public async Task<ActionResult> DeleteCheckList([FromRoute] string cardId, [FromBody] DeleteInfo cardDeleteInfo)
        {
            await _cardService.DeleteCardChecklistByIdAsync(cardId, cardDeleteInfo);
            return Ok();
        }
    }
}
