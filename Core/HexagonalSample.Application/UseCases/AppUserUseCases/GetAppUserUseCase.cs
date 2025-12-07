using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUsers.Queries;
using HexagonalSample.Application.PrimaryPorts.AuppUserPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AppUserUseCases
{
    public class GetAppUserUseCase : IGetAppUserUseCase
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAppUserUseCase(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetAppUserQueryResult>> ExecuteAsync(GetAppUserQuery query)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAppUserQueryResult>>(users);
        }
    }

}
