using HexagonalSample.Application.DtoClasses.AppUsers.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AuppUserPorts
{
    public interface IGetAppUserUseCase
    : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
    {
        Task<List<GetAppUserQueryResult>> ExecuteAsync(GetAppUserQuery query);
    }

}
