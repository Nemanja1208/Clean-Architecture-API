using Application.Dtos.MediatR;
using Application.Exceptions.EntityNotFound;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, OperationResult<Dog>>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly ILogger<GetDogByIdQueryHandler> _logger;

        public GetDogByIdQueryHandler(MockDatabase mockDatabase, ILogger<GetDogByIdQueryHandler> logger)
        {
            _mockDatabase = mockDatabase;
            _logger = logger;
        }

        public Task<OperationResult<Dog>> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Handling GetDogByIdQuery");

                Dog wantedDog = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

                if (wantedDog == null)
                {
                    _logger.LogError($"Dog with Id {request.Id} not found");
                    throw new EntityNotFoundException("Dog", request.Id);
                }

                _logger.LogInformation($"Dog with Id {request.Id} found");

                return Task.FromResult(new OperationResult<Dog>
                {
                    IsSuccess = true,
                    Result = wantedDog,
                });
            }
            catch (EntityNotFoundException ex)
            {
                return Task.FromResult(new OperationResult<Dog>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }

        }
    }
}
