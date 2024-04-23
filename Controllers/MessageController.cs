using MgqsPollApp.Dtos;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MgqsPollApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<MessageDto>>> CreateMessage(CreateMessageRequestModel model)
        {
            var response = await _messageService.CreateCategoryAsync(model);

            if (!response.Status)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<ICollection<MessageDto>>>> GetMessages()
        {
            var response = await _messageService.GetCategoriesAsync();

            if (!response.Status)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<MessageDto>>> GetMessage(string id)
        {
            var response = await _messageService.GetCategoryAsync(id);

            if (!response.Status)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}