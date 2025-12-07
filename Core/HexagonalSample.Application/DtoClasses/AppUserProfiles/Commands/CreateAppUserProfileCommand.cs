using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands
{
    public class CreateAppUserProfileCommand : IRequest<AppUserProfileCommandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }

}
