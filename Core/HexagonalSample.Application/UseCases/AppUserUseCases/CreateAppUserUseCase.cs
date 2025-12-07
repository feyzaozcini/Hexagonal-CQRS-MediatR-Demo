using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUsers.Commands;
using HexagonalSample.Application.PrimaryPorts.AuppUserPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AppUserUseCases
{
    public class CreateAppUserUseCase : ICreateAppUserUseCase
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppUserUseCase(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserCommandResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AppUserCommandResult> ExecuteAsync(CreateAppUserCommand command)
        {
            AppUser user = _mapper.Map<AppUser>(command);
            user.CreatedDate = DateTime.Now;
            user.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(user);

            return new AppUserCommandResult
            {
                Id = user.Id,
                Message = "User created successfully"
            };
        }
    }

}
