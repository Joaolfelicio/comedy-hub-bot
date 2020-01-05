using ComedyHub.Model.Meme.NineGagMeme;
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
