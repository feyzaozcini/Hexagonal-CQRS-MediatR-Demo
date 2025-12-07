using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries;
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
    public class GetAppUserProfileByIdUseCase : IGetAppUserProfileByIdUseCase
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetAppUserProfileByIdUseCase(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAppUserProfileQueryResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetAppUserProfileQueryResult> ExecuteAsync(GetAppUserProfileByIdQuery query)
        {
            var profile = await _repository.GetByIdAsync(query.Id);
            if (profile == null)
                throw new NotFoundException("Profile not found");

            return _mapper.Map<GetAppUserProfileQueryResult>(profile);
        }
    }

}
