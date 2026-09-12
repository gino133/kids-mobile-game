using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildScript
{
    public static void BuildAndroidAPK()
    {
        // Define output path
        string outputPath = "build/android/KidsMobileGame.apk";
        
        // Define scenes to build
        string[] scenes = FindScenes();
        
        if (scenes.Length == 0)
        {
            Debug.LogError("No scenes found! Please add scenes to Assets/Scenes/");
            return;
        }
        
        // Configure build settings
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };
        
        // Configure Android player settings
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;
        PlayerSettings.companyName = "KidsGame";
        PlayerSettings.productName = "Kids Mobile Game";
        PlayerSettings.bundleIdentifier = "com.kidsgame.mobile";
        
        // Increment version
        int versionCode = int.Parse(PlayerSettings.Android.bundleVersionCode);
        PlayerSettings.Android.bundleVersionCode = versionCode + 1;
        
        // Build
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded! Output: " + outputPath);
            Debug.Log("Build size: " + (summary.totalSize / 1024f / 1024f).ToString("F2") + " MB");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build failed!");
        }
    }
    
    private static string[] FindScenes()
    {
        // Try to find scenes in Assets/Scenes/
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene", new[] { "Assets/Scenes" });
        
        if (sceneGuids.Length == 0)
        {
            Debug.LogWarning("No scenes found in Assets/Scenes/. Creating default scene paths.");
            // Return empty array - scenes must be manually added
            return new string[] { };
        }
        
        string[] scenePaths = new string[sceneGuids.Length];
        for (int i = 0; i < sceneGuids.Length; i++)
        {
            scenePaths[i] = AssetDatabase.GUIDToAssetPath(sceneGuids[i]);
        }
        
        return scenePaths;
    }
}
