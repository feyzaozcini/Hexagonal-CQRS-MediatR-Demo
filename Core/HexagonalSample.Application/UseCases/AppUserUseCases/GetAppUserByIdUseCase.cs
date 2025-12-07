using AutoMapper;
using HexagonalSample.Application.DtoClasses.AppUsers.Queries;
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
    public class GetAppUserByIdUseCase : IGetAppUserByIdUseCase
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAppUserByIdUseCase(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAppUserQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetAppUserQueryResult> ExecuteAsync(GetAppUserByIdQuery query)
        {
            var user = await _repository.GetByIdAsync(query.Id);
            if (user == null)
                throw new NotFoundException("User not found");

            return _mapper.Map<GetAppUserQueryResult>(user);
        }
    }

}
