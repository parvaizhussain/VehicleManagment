﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
namespace Application.Contracts.Persistence
{
    public interface INetworkRepository : IAsyncRepository<Network>
    {
    }
}
