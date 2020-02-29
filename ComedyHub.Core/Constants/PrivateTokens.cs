// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-08-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="PrivateTokens.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Auth
{
    /// <summary>
    /// Class AccessToken.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The access token for twitter
        /// </summary>
        public const string ACCESS_TOKEN_TWITTER = "1210631049639813120-kg2lgcRjVjwiOer4j4tM6USjsSXFai";
        /// <summary>
        /// The access token secret for twitter
        /// </summary>
        public const string ACCESS_TOKEN_SECRET_TWITTER = "I80WFSKoPZXzGhqhGuwMdklf0lDdgkMd9MjlpXaBrHCEX";
        /// <summary>
        /// The access token for telegram
        /// </summary>
        public const string ACCESS_TOKEN_TELEGRAM = "953451254:AAEx3nIxqqPFXyR_MgKVwLk6OL35tWAx0gQ";
    }

    /// <summary>
    /// Class ConsumerToken.
    /// </summary>
    public class ConsumerToken
    {
        /// <summary>
        /// The consumer key for twitter
        /// </summary>
        public const string CONSUMER_KEY_TWITTER = "FCCp80c3OxAmAjRxHI92yDOdT";
        /// <summary>
        /// The consumer secret for twitter
        /// </summary>
        public const string CONSUMER_SECRET_TWITTER = "j4KAvtlfrsIrYCOcfRk6B0wSRAE7ScZTxfYmuCkicd12siv3Nk";
        /// <summary>
        /// The consumer secret for reddit
        /// </summary>
        public const string CONSUMER_SECRET_REDDIT = "uYUv7VbTOfyk69QDL7j35-rMmwM";
        /// <summary>
        /// The consumer refresh for reddit
        /// </summary>
        public const string CONSUMER_REFRESH_REDDIT = "182903465627-ufFz2y29JZV1TDj8h7-y_d48wtI";
    }

    /// <summary>
    /// Class ReceiverInfo.
    /// </summary>
    public class ReceiverInfo
    {
        /// <summary>
        /// The telegram message receiver identifier
        /// </summary>
        public const int TELEGRAM_MESSAGE_RECEIVER_ID = 1042056575;
    }

    /// <summary>
    /// Class AppInfo.
    /// </summary>
    public class AppInfo
    {
        /// <summary>
        /// The reddit application identifier
        /// </summary>
        public const string REDDIT_APP_ID = "JrK4e8pitgzHyw";
    }
}
