using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface INineGagMapperService
    {
        MemeModel NineGagModelToMeme(NineGagPost ngPost);
    }
}
