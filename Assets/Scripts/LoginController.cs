using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    public event Action<PlayerProfile> OnSignedIn;
    public event Action<PlayerProfile> OnAvatarUpdate;

    private PlayerInfo playerInfo;

    private PlayerProfile playerProfile;
    public PlayerProfile PlayerProfile => playerProfile;

    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        PlayerAccountService.Instance.SignedIn += SignedIn;
    }

    private async void SignedIn()
    {
        try
        {
            var accessToken = PlayerAccountService.Instance.AccessToken;
            await SignInWithUnityAsync(accessToken);

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public async Task InitSignIn()
    {
        await PlayerAccountService.Instance.StartSignInAsync();
    }

    private async Task SignInWithUnityAsync(string accessToken)
    {
        try
        {
            // await AuthenticationService.Instance.SignInWithUnityAsync(accessToken);

            await AuthenticationService.Instance.SignInWithGoogleAsync(accessToken);



            Debug.Log(accessToken);
            Debug.Log("SignIn is successful.");

            playerInfo = AuthenticationService.Instance.PlayerInfo;

            var name = await AuthenticationService.Instance.GetPlayerNameAsync();
            
            Debug.Log(name);

            playerProfile.playerInfo = playerInfo;
            playerProfile.Name = name;

            Debug.Log(playerInfo.Id);
            Debug.Log(playerProfile.Name);


            Debug.Log(playerInfo.Username);
            Debug.Log(playerInfo.GetGoogleId());
            Debug.Log(playerInfo.GetAppleId());
            Debug.Log(playerInfo.GetFacebookId());
            Debug.Log(playerInfo.GetCustomId());
            Debug.Log(playerInfo.GetUnityId());

            OnSignedIn?.Invoke(playerProfile);
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
        }
    }

    private void OnDestroy()
    {
        PlayerAccountService.Instance.SignedIn -= SignedIn;
    }
}


[Serializable]
public struct PlayerProfile
{
    public PlayerInfo playerInfo;
    public string Name;
}