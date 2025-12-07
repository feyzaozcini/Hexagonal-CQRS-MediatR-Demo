using HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.AppUserProfilePorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AppUserProfileUseCases
{
    public class RemoveAppUserProfileUseCase : IRemoveAppUserProfileUseCase
    {
        private readonly IAppUserProfileRepository _repository;

        public RemoveAppUserProfileUseCase(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<AppUserProfileCommandResult> Handle(RemoveAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AppUserProfileCommandResult> ExecuteAsync(RemoveAppUserProfileCommand command)
        {
            var profile = await _repository.GetByIdAsync(command.Id);
            if (profile == null)
                throw new NotFoundException("Profile not found");

            await _repository.RemoveAsync(profile);

            return new AppUserProfileCommandResult
            {
                Id = profile.Id,
                Message = "Profile deleted successfully"
            };
        }
    }

}
