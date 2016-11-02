using System.Collections.Generic;

/// <summary>
/// Used internally by Unity during testing of Ads SDK to track results
/// Requires Analytics to be enabled for project in that case
/// Otherwise this class can just be ignored
/// </summary>
public static class Analytics
{
    public static void SendInitializeAdsEvent (string gameId)
    {
        #if UNITY_ANALYTICS
        var data = new Dictionary<string, object> ();
        data.Add ("GameId", gameId);
        SendCustomEventAndLogError ("AdsInitialized", data);
        #endif
    }

    public static void SendShowAdEvent (string gameId, string placementId)
    {
        #if UNITY_ANALYTICS
        var data = new Dictionary<string, object> ();
        data.Add ("GameId", gameId);
        data.Add ("PlacementId", placementId);
        SendCustomEventAndLogError ("ShowAd", data);
        #endif
    }

    public static void SendAdFinishedEvent (string gameId, string result)
    {
        #if UNITY_ANALYTICS
        var data = new Dictionary<string, object> ();
        data.Add ("GameId", gameId);
        data.Add ("Result", result);
        SendCustomEventAndLogError ("AdFinished", data);
        #endif
    }

    private static void SendCustomEventAndLogError (string customEventName, Dictionary<string, object> data)
    {
        #if UNITY_ANALYTICS
        var result = UnityEngine.Analytics.Analytics.CustomEvent (customEventName, data);
        if (result != UnityEngine.Analytics.AnalyticsResult.Ok)
        {
            UIController.Instance.Log ("Failed to send analytics event: " + result.ToString ());
        }
        #endif
    }
}
