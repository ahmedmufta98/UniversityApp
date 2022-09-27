using MediatR;
using UniversityApp.Domain.Enums;

namespace UniversityApp.Domain.CQRS.Commands.BaseCommand
{
    public class BaseCommand<Tkey, Tmodel, Tdb> : IRequest<Tmodel>
    {
        public CommandType Command { get; set; }
        public Tkey? Id { get; set; }
        public Tmodel? ModelRequest { get; set; }

        public BaseCommand(CommandType command, Tkey? id, Tmodel? modelRequest = default)
        {
            Command = command;
            Id = id;
            ModelRequest = modelRequest;
        }
    }
}
