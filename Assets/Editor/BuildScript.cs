using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;

public class BuildScript
{
    [MenuItem("Build/Build Android APK")]
    public static void BuildAndroidAPK()
    {
        // Define build path
        string buildPath = "build/android";
        string buildName = "KidsMobileGame.apk";
        
        // Create directory if it doesn't exist
        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }
        
        string outputPath = Path.Combine(buildPath, buildName);
        
        // Define scenes
        string[] scenes = FindEnabledEditorScenes();
        
        if (scenes.Length == 0)
        {
            Debug.LogError("No scenes found! Please add scenes to build settings.");
            return;
        }
        
        Debug.Log($"Building APK with {scenes.Length} scene(s) to: {outputPath}");
        
        // Build player
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };
        
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build succeeded! APK saved to: {outputPath}");
            Debug.Log($"Build size: {summary.totalSize} bytes");
        }
        else
        {
            Debug.LogError($"Build failed! Result: {summary.result}");
        }
    }
    
    static string[] FindEnabledEditorScenes()
    {
        System.Collections.Generic.List<string> editorScenes = new System.Collections.Generic.List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                editorScenes.Add(scene.path);
        }
        return editorScenes.ToArray();
    }
}
