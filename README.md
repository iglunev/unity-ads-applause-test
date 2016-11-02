# Unity Ads Applause test project

Fork of https://github.com/Unity-Technologies/unity-ads-assetstore-test, with following changes specific to Applause:

- setting default game ids to the ones used by Applause testers
- set version number to SDK version number (convenient for Applause testers)
- enable Unity Analytics on project

Project is maintained using Unity 5.x, typically latest public version.

For Unity Analytics, project is bound to <https://developer.cloud.unity3d.com/orgs/unityads-sdk-team/projects/unity-ads-applause-test/> under `UnityAds-SDK-team` org.

Applause instructions are available at <https://docs.google.com/document/d/1sVMyM82s01fZ7KXlJG7BBp1FwxxESfEc3g6GcbBC6HM>

### From commandline

```
$ ./build.sh android,ios "/Applications/Unity 5.4.2f1" http://cdn.unityads.unity3d.com/unitypackage/2.0.5/UnityAds.unitypackage
```

### Using Unity

1. Open `UnityAdsApplauseTest` project in Unity
1. Open MainScene
1. Open Asset Store window
1. Search for "Unity Ads" and download/import either Unity Ads SDK 1.x or 2.x
1. Set `UNITY_ADS` scripting define, either in Player Settings, or from `File->AutoBuilder->Enable Ads` menu
1. Play in editor or deploy to your Android or iOS device

## Logging

Unity Ads related device logs are written with topic `UnityAds`, e.g. to filter relevant logs on Android, use:

```
$ adb logcat -v time UnityAds:V *:S
```

## Sending to Applause

### Android

Simply send the generated .apk file from Unity, along with instructions as PDF file

### iOS

Need to be member of Applifier Oy org 

1. Open Xcode project
1. Product->Archive
1. In Archives window, choose Export...
1. -> Save for Development Deployment
1. -> "Applifier Oy"
1. -> "For all compatible devices"

Save and send generated .ipa file to Applause with instructions as PDF file
