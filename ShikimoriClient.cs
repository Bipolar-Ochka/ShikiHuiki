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
            GetToken(authCode);
            GetCurrentUser();
        }
        public List<UserAnimeRate> GetAnime(AnimeStatus status=AnimeStatus.None,int limitItemsByReq=50)
        {
            try
            {
                var animeList = UserAnimeRequest.GetUserAnime(this.CurrentUser, this.AuthToken, limitItemsByReq).Result;
                if(status != AnimeStatus.None)
                {
                    animeList = animeList.Where(item => item.Status == AnimeParams.AnimeStatusString[status]).ToList();
                }
                return animeList;
            }
            catch(TokenExpiredException e)
            {
                RefreshTokenEvent?.Invoke(this.AuthToken);
                ErrorTextEvent?.Invoke(e.Message);
                return null;
            }
            catch(Exception e)
            {
                ErrorTextEvent?.Invoke(e.Message);
                return null;
            }

        }

        private void GetCurrentUser()
        {
            try
            {
                var user = WhoAmIRequest.Whoami(this.AuthToken).Result;
                this.CurrentUser = user;
            }
            catch (TokenExpiredException e)
            {
                RefreshTokenEvent?.Invoke(this.AuthToken);
                ErrorTextEvent?.Invoke(e.Message);
            }
            catch (Exception e)
            {
                ErrorTextEvent?.Invoke(e.Message);
            }
        }

        private void GetToken(string authCode)
        {
            try
            {
                var tok = AuthRequest.Authorization(authCode).Result;
                this.AuthToken = tok;
            }
            catch (TokenExpiredException e)
            {
                RefreshTokenEvent?.Invoke(this.AuthToken);
                ErrorTextEvent?.Invoke(e.Message);
            }
            catch (Exception e)
            {
                ErrorTextEvent?.Invoke(e.Message);
            }
        }
        private void ShikimoriClient_RefreshTokenEvent(Token obj)
        {
            this.AuthToken = AuthRequest.Authorization(obj).Result;
        }

    }
}
