using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    public interface IFilterService
    {
        bool HasMemeAlreadyPosted(string memeTitle);
    }
}
