using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUsers.Commands
{
    public class CreateAppUserCommand : IRequest<AppUserCommandResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
