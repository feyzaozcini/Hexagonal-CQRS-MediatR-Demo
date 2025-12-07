using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUsers.Commands
{
    public class RemoveAppUserCommand : IRequest<AppUserCommandResult>
    {
        public int Id { get; set; }
        public RemoveAppUserCommand(int id) => Id = id;
    }

}
