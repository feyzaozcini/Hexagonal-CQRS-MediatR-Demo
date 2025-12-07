using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands
{
    public class RemoveAppUserProfileCommand : IRequest<AppUserProfileCommandResult>
    {
        public int Id { get; set; }
        public RemoveAppUserProfileCommand(int id) => Id = id;
    }

}
