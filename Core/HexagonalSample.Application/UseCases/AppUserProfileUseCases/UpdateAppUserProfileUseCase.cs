using AutoMapper;
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
    public class UpdateAppUserProfileUseCase : IUpdateAppUserProfileUseCase
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAppUserProfileUseCase(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileCommandResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AppUserProfileCommandResult> ExecuteAsync(UpdateAppUserProfileCommand command)
        {
            var profile = await _repository.GetByIdAsync(command.Id);
            if (profile == null)
                throw new NotFoundException("Profile not found");

            _mapper.Map(command, profile);
            profile.UpdatedDate = DateTime.Now;
            profile.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(profile);

            return new AppUserProfileCommandResult
            {
                Id = profile.Id,
                Message = "Profile updated successfully"
            };
        }
    }

}
