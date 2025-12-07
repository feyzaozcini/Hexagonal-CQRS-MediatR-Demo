using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUsers.Commands
{
    public class UpdateAppUserCommand : IRequest<AppUserCommandResult>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }

}
