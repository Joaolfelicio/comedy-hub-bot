using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NineGagMemeService : INineGagMemeService
    {
        readonly INineGagGateway _nineGagGateway;
        public NineGagMemeService(INineGagGateway nineGagGateway)
        {
            _nineGagGateway = nineGagGateway;
        }

        public MemeModel GetNineGagMeme()
        {
            _nineGagGateway.GetMeme();
        }
    }
}
