using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands;
using HexagonalSample.Application.PrimaryPorts.AppUserProfilePorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AppUserProfileUseCases
{
    public class CreateAppUserProfileUseCase : ICreateAppUserProfileUseCase
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppUserProfileUseCase(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileCommandResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AppUserProfileCommandResult> ExecuteAsync(CreateAppUserProfileCommand command)
        {
            var profile = _mapper.Map<AppUserProfile>(command);
            profile.CreatedDate = DateTime.Now;
            profile.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(profile);

            return new AppUserProfileCommandResult
            {
                Id = profile.Id,
                Message = "Profile created successfully"
            };
        }
    }

}
