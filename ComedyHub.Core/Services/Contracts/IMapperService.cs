using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface IMapperService
    {
        MemeModel MapToMemeModel(MemeModel memeModel);
    }
}
