﻿using MediatR;
using System;

namespace Application.Features.AccessRights.Commands.UpdateAccessRights
{
    public class UpdateAccessRightsCommand : IRequest
    {
        public int AccessId { get; set; }
        public string AccessName { get; set; }
        public string NormalizedName { get; set; }
        public bool View { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Email { get; set; }
        public bool Download { get; set; }
        public bool Approve { get; set; }
        public bool Print { get; set; }
        public bool Scan { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
