using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Infrastructure.NineGagModels.Models;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services
{
    public class NineGagMemeService : INineGagMemeService
    {
        readonly INineGagGateway _nineGagGateway;
        public NineGagMemeService(INineGagGateway nineGagGateway)
        {
            _nineGagGateway = nineGagGateway;
        }

        public async Task<NineGagModel> GetNineGagMeme()
        {
            return await _nineGagGateway.GetMeme();
        }
    }
}
