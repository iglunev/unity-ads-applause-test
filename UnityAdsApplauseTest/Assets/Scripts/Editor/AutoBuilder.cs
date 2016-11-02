﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class AutoBuilder
{
	static string GetProjectName ()
	{
		string[] s = Application.dataPath.Split ('/');
		return s[s.Length - 2];
	}
	
	static string[] GetScenePaths ()
	{
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
		
		for (int i = 0; i < scenes.Length; i++)
		{
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
		
		return scenes;
	}

	[MenuItem("File/AutoBuilder/Enable Ads")]
	static void EnableAds ()
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, "UNITY_ADS");
		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.iOS, "UNITY_ADS");
	}

    [MenuItem("File/AutoBuilder/Set Version Number")]
    static void SetVersionNumber ()
    {
        #if UNITY_ADS
        PlayerSettings.bundleVersion = UnityEngine.Advertisements.Advertisement.version;
        #endif
    }

	[MenuItem("File/AutoBuilder/Android")]
	static void PerformAndroidBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTarget.Android);
		Directory.CreateDirectory ("Builds");
		BuildPipeline.BuildPlayer (GetScenePaths (), "Builds/Android.apk", BuildTarget.Android, BuildOptions.None);
	}

	[MenuItem ("File/AutoBuilder/iOS")]
	static void PerformiOSBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTarget.iOS);
		Directory.CreateDirectory ("Builds");
		BuildPipeline.BuildPlayer (GetScenePaths (), "Builds/iOS", BuildTarget.iOS, BuildOptions.None);
	}
}
