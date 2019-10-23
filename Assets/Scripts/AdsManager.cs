using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

    public static void ShowAd()
    {
        if (Advertisement.IsReady("video"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("video", options);
        }
        else
        {
            GameManager.SetRestart();
        }
    }

    private static void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManager.SetRestart();
                break;
            case ShowResult.Skipped:
                GameManager.SetRestart();
                break;
            case ShowResult.Failed:
                GameManager.SetRestart();
                break;
        }
    }
}
