using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries;
using HexagonalSample.Application.PrimaryPorts.AppUserProfilePorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AppUserProfileUseCases
{
    public class GetAppUserProfilesUseCase : IGetAppUserProfilesUseCase
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetAppUserProfilesUseCase(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfilesQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetAppUserProfileQueryResult>> ExecuteAsync(GetAppUserProfilesQuery query)
        {
            var profiles = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAppUserProfileQueryResult>>(profiles);
        }
    }

}
