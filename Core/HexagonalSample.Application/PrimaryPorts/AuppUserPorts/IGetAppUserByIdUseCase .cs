using HexagonalSample.Application.DtoClasses.AppUsers.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AuppUserPorts
{
    public interface IGetAppUserByIdUseCase
    : IRequestHandler<GetAppUserByIdQuery, GetAppUserQueryResult>
    {
        Task<GetAppUserQueryResult> ExecuteAsync(GetAppUserByIdQuery query);
    }

}
