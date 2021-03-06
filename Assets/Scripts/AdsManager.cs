using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private Player player;
  public void ShowRewardedAD()
    {

         if (Advertisement.IsReady("rewardedVideo"))
         {
             Debug.Log("Showing Rewarded Ad");
             var options = new ShowOptions
             {
                 resultCallback = HandleShowResult
             };
             Advertisement.Show("rewardedVideo", options);
         }
         else
         {
             Debug.Log("Advertisement not ready");
         }
     }

     private void HandleShowResult(ShowResult result)
     {
         switch(result)
         {
             case ShowResult.Finished:
                player.AddDiamonds(100);
                UIManager.Instance.OpenShop(player.GetDiamonds());
                 break;
             case ShowResult.Skipped:
                 Debug.Log("You skipped the add, no gems for you");
                 break;
             case ShowResult.Failed:
                 Debug.Log("Video Failed");
                 break;
         }
    }
        
}
