using Application.Dtos.MediatR;
using Application.Exceptions.EntityNotFound;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, OperationResult<Dog>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetDogByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<OperationResult<Dog>> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Dog wantedDog = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;
                if (wantedDog == null)
                {
                    throw new EntityNotFoundException("Dog", request.Id);
                }
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
