using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    public interface IFilterService
    {
        MemeModel FilterMemes(List<MemeModel> posts);
    }
}