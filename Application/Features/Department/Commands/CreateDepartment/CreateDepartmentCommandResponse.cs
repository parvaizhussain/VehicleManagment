using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Department.Commands.CreateDepartment
{
   public  class CreateDepartmentCommandResponse : BaseResponse
    {
        public CreateDepartmentCommandResponse() : base()
        {

        }

        public CreateDepartmentDto Department { get; set; }
    }
}
