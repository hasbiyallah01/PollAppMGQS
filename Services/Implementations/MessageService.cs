using MgqsPollApp.Dtos;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using MgqsPollApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MgqsPollApp.Services.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<BaseResponse<MessageDto>> CreateCategoryAsync(CreateMessageRequestModel model)
        {
            try
            {
                var message = new Message
                {
                    Sender = model.Sender,
                    Content = model.Content,
                    Timestamp = DateTime.Now,
                    UserId = model.UserId,
                    ChatRoomId = model.ChatRoomId
                };

                await _messageRepository.CreateAsync(message);

                var messageDto = new MessageDto
                {
                    Sender = message.Sender,
                    Content = message.Content
                };

                return new BaseResponse<MessageDto>
                {
                    Message = "Success",
                    Status = true,
                    Data = messageDto
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MessageDto>
                {
                    Message = ex.Message,
                    Status = false,
                    Data = null
                };
            }
        }

        public async Task<BaseResponse<ICollection<MessageDto>>> GetCategoriesAsync()
        {
            try
            {
                var messages = await _messageRepository.GetAll();

                var messageDtos = new List<MessageDto>();
                foreach (var message in messages)
                {
                    var messageDto = new MessageDto
                    {
                        Sender = message.Sender,
                        Content = message.Content
                    };
                    messageDtos.Add(messageDto);
                }

                return new BaseResponse<ICollection<MessageDto>>
                {
                    Message = "Success",
                    Status = true,
                    Data = messageDtos
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ICollection<MessageDto>>
                {
                    Message = ex.Message,
                    Status = false,
                    Data = null
                };
            }
        }

        public async Task<BaseResponse<MessageDto>> GetCategoryAsync(string id)
        {
            try
            {
                var message = await _messageRepository.Get(int.Parse(id));

                if (message == null)
                {
                    return new BaseResponse<MessageDto>
                    {
                        Message = "Message not found",
                        Status = false,
                        Data = null
                    };
                }

                var messageDto = new MessageDto
                {
                    Sender = message.Sender,
                    Content = message.Content
                };

                return new BaseResponse<MessageDto>
                {
                    Message = "Success",
                    Status = true,
                    Data = messageDto
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MessageDto>
                {
                    Message = ex.Message,
                    Status = false,
                    Data = null
                };
            }
        }
    }
}