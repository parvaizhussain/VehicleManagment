
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Create
{
    public class Create_Receipt_CommandsValidator : AbstractValidator<Create_Receipt_Commands>
    {
        public Create_Receipt_CommandsValidator()
        {
           
        }
    }
}
