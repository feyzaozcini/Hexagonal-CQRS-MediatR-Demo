using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUsers.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.AuppUserPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AppUserUseCases
{
    public class UpdateAppUserUseCase : IUpdateAppUserUseCase
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAppUserUseCase(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserCommandResult> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AppUserCommandResult> ExecuteAsync(UpdateAppUserCommand command)
        {
            var user = await _repository.GetByIdAsync(command.Id);
            if (user == null)
                throw new NotFoundException("User not found");

            _mapper.Map(command, user);
            user.UpdatedDate = DateTime.Now;
            user.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(user);

            return new AppUserCommandResult
            {
                Id = user.Id,
                Message = "User updated successfully"
            };
        }
    }

}
