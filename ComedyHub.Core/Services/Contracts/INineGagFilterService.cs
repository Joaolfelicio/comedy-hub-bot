using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface INineGagFilterService
    {
        Post NineGagFilter(NineGagModel nineGag);
    }
}
