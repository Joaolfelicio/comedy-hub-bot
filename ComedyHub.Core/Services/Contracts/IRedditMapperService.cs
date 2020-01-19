using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface IRedditMapperService
    {
        List<MemeModel> RedditModelToMemes(List<Post> redditPosts);
    }
}
