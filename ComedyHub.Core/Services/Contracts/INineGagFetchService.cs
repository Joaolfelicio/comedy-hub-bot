using ComedyHub.Model.Meme.NineGagMeme;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    public interface INineGagFetchService
    {
        Task<NineGagModel> GetNineGagModelMeme();
    }
}
