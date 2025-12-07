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
    public class RemoveAppUserUseCase : IRemoveAppUserUseCase
    {
        private readonly IAppUserRepository _repository;

        public RemoveAppUserUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<AppUserCommandResult> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AppUserCommandResult> ExecuteAsync(RemoveAppUserCommand command)
        {
            var user = await _repository.GetByIdAsync(command.Id);
            if (user == null)
                throw new NotFoundException("User not found");

            await _repository.RemoveAsync(user);

            return new AppUserCommandResult
            {
                Id = user.Id,
                Message = "User deleted successfully"
            };
        }
    }

}
