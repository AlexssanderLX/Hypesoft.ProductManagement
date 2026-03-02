using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hypesoft.Application.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public CreateCategoryCommand(string name)
        {
            Name = name; 
        }
    }
}
