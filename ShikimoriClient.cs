using ShikiHuiki.TokenContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShikiHuiki.UserClass;
using System.Net.Http;
using ShikiHuiki.Constants;
using Newtonsoft.Json;
using System.Net;
using ShikiHuiki.Exceptions;
using ShikiHuiki.Requests;

namespace ShikiHuiki
{
    public class ShikimoriClient
    {
        internal Token AuthToken { get; private set; }
        internal User CurrentUser { get; private set; }
        private event Action<Token> RefreshTokenEvent;
        public event Action<string> ErrorTextEvent;

      
        public ShikimoriClient(string authCode)
        {
            RefreshTokenEvent += ShikimoriClient_RefreshTokenEvent;
        }
        public void GetAnime()
        {
            
        }

        private void ShikimoriClient_RefreshTokenEvent(Token obj)
        {
            this.AuthToken = AuthRequest.Authorization(obj).Result;
        }

    }
}
