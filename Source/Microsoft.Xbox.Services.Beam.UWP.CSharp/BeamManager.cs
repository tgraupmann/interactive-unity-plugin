using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;

namespace Xbox.Services.Beam
{
    public partial class BeamManager
    {
        public async Task<string> GetTokenAsync()
        {
            string authToken = string.Empty;
            // Get an XToken
            // Find the account provider using the signed in user.
            // We always use the 1st signed in user, because we just need a valid token. It doesn't
            // matter who's it is.
            Windows.System.User currentUser;
            WebTokenRequest request;
            var users = await Windows.System.User.FindAllAsync();
            currentUser = users[0];
            WebAccountProvider xboxProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://xsts.auth.xboxlive.com", "", currentUser);

            // Build the web token request using the account provider.
            // Url = URL of the service we are getting a token for - for example https://apis.mycompany.com/something. 
            // As this is a sample just use xboxlive.com
            // Target & Policy should always be set to "xboxlive.signin" and "DELEGATION"
            // For this call to succeed your console needs to be in the XDKS.1 sandbox
            request = new Windows.Security.Authentication.Web.Core.WebTokenRequest(xboxProvider);
            request.Properties.Add("Url", "https://xboxlive.com");
            request.Properties.Add("Target", "xboxlive.signin");
            request.Properties.Add("Policy", "DELEGATION");

            // Request a token - correct pattern is to call getTokenSilentlyAsync and if that 
            // fails with WebTokenRequestStatus.userInteractionRequired then call requestTokenAsync
            // to get the token and prompt the user if required.
            // getTokenSilentlyAsync can be called on a background thread.
            WebTokenRequestResult tokenResult = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(request);
            //If we got back a token call our service with that token 
            if (tokenResult.ResponseStatus == WebTokenRequestStatus.Success)
            {
                authToken = tokenResult.ResponseData[0].Token;
            }
            else if (tokenResult.ResponseStatus == WebTokenRequestStatus.UserInteractionRequired)
            { // WebTokenRequestStatus.userInteractionRequired = 3
              // If user interaction is required then call requestTokenAsync instead - this will prompt for user permission if required
              // Note: RequestTokenAsync cannot be called on a background thread.
                WebTokenRequestResult tokenResult2 = await WebAuthenticationCoreManager.RequestTokenAsync(request);
                //If we got back a token call our service with that token 
                if (tokenResult2.ResponseStatus == WebTokenRequestStatus.Success)
                {
                    authToken = tokenResult.ResponseData[0].Token;
                }
                else if (tokenResult2.ResponseStatus == WebTokenRequestStatus.UserCancel)
                { // WebTokenRequestStatus.UserCancel = 1
                    Debug.WriteLine("User Cancelled the request to get a token");
                }
                else
                {
                    Debug.WriteLine("An error occured getting the token: " + tokenResult2.ResponseStatus + " " + tokenResult2.ResponseError.ErrorCode);
                }
                return authToken;
            }
            else
            {
                Debug.WriteLine("An error occured getting the token");
            }
            return authToken;
        }
    }
}
