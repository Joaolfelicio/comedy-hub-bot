using ComedyHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    public interface INineGagGateway
    {
        MemeModel GetMeme();
    }
}
