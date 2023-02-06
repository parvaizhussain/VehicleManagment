
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Create
{
    public class Create_Airport_CommandsValidator : AbstractValidator<Create_Airport_Commands>
    {
        public Create_Airport_CommandsValidator()
        {
           
        }
    }
}
