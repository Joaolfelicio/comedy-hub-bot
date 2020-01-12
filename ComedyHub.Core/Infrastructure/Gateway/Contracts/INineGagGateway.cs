using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    public interface INineGagGateway
    {
        Task<NineGagModel> GetMeme();
    }
}
