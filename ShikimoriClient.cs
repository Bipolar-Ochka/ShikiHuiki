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
using System.Diagnostics;
using System.Collections.Concurrent;

namespace ShikiHuiki
{
    public class ShikimoriClient
    {
        internal Token AuthToken { get; private set; }
        internal User CurrentUser { get; private set; }
        private event Action<Token> RefreshTokenEvent;
        public event Action<string> ErrorTextEvent;

      
        public ShikimoriClient()
        {
            RefreshTokenEvent += ShikimoriClient_RefreshTokenEvent;
        }
        public async Task ShikiLogin(string authCode)
        {
            await GetToken(authCode).ConfigureAwait(false);
            await GetCurrentUser().ConfigureAwait(false);
        }
        public async Task GetAnime(List<UserAnimeRate> testlist, AnimeStatus status=AnimeStatus.None,int limitItemsByReq=50)
        {
            try
            {
                await UserAnimeRequest.GetUserAnime(this.CurrentUser, this.AuthToken, limitItemsByReq,testlist).ConfigureAwait(false);
                if(status != AnimeStatus.None)
                {
                    testlist = testlist.Where(item => item.Status == AnimeParams.AnimeStatusString[status]).ToList();
                }
            }
            catch(TokenExpiredException e)
            {
                RefreshTokenEvent?.Invoke(this.AuthToken);
                ErrorTextEvent?.Invoke(e.Message);
                return;
            }
            catch(Exception e)
            {
                ErrorTextEvent?.Invoke(e.Message);
                return;
            }

        }

        public string GetNickname()
        {
            return this.CurrentUser?.Name;
        }

        private async Task GetCurrentUser()
        {
            try
            {
                var user = await WhoAmIRequest.Whoami(this.AuthToken).ConfigureAwait(false);
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

        private async Task GetToken(string authCode)
        {
            try
            {
                var tok = await AuthRequest.Authorization(authCode).ConfigureAwait(false);
                this.AuthToken = tok;
            }
            catch (TokenExpiredException e)
            {
                RefreshTokenEvent?.Invoke(this.AuthToken);
                //ErrorTextEvent?.Invoke(e.Message);
            }
            catch (Exception e)
            {
                //ErrorTextEvent?.Invoke(e.Message);
                throw;
            }
        }
        private void ShikimoriClient_RefreshTokenEvent(Token obj)
        {
            this.AuthToken = AuthRequest.Authorization(obj).Result;
        }

    }
}
