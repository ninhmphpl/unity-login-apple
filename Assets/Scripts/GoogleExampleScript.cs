using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class GoogleExampleScript : MonoBehaviour
// {
//     void InitializePlayGamesLogin()
//     {
//         var config = new PlayGamesClientConfiguration.Builder()
//             // Requests an ID token be generated.  
//             // This OAuth token can be used to
//             // identify the player to other services such as Firebase.
//             .RequestIdToken()
//             .Build();

//         PlayGamesPlatform.InitializeInstance(config);
//         PlayGamesPlatform.DebugLogEnabled = true;
//         PlayGamesPlatform.Activate();
//     }

//     void LoginGoogle()
// {
//     Social.localUser.Authenticate(OnGoogleLogin);
// }

// void OnGoogleLogin(bool success)
// {
//     if (success)
//     {
//         // Call Unity Authentication SDK to sign in or link with Google.
//         Debug.Log("Login with Google done. IdToken: " + ((PlayGamesLocalUser)Social.localUser).GetIdToken());
//     }
//     else
//     {
//         Debug.Log("Unsuccessful login");
//     }
// }
// }
