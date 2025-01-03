using UnityEditor;
using UnityEngine;
using System;
using AssetStoreTools.Uploader;
using AssetStoreTools.Validator;
using AssetStoreTools.Utility;

namespace AssetStoreTools
{
    internal class AssetStoreTools : EditorWindow
    {
        [MenuItem("Tools/Asset Store/Uploader", false, 0)]
        public static void ShowAssetStoreToolsUploader()
        {
            Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
            var wnd = GetWindow<AssetStoreUploader>(inspectorType);
            wnd.Show();
        }
        
                
        [MenuItem("Tools/Asset Store/Validator", false, 1)]
        public static void ShowAssetStoreToolsValidator()
        {
            Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
            var wnd = GetWindow<AssetStoreValidator>(typeof(AssetStoreUploader), inspectorType);
            wnd.Show();
        }

        [MenuItem("Tools/Asset Store/Publisher Portal", false, 20)]
        public static void OpenPublisherPortal()
        {
            Application.OpenURL("https://publisher.unity.com/");
        }

        [MenuItem("Tools/Asset Store/Submission Guidelines", false, 21)]
        public static void OpenSubmissionGuidelines()
        {
            Application.OpenURL("https://assetstore.unity.com/publishing/submission-guidelines/");
        }

        [MenuItem("Tools/Asset Store/Provide Feedback", false, 22)]
        public static void OpenFeedback()
        {
            Application.OpenURL("https://forum.unity.com/threads/new-asset-store-tools-version-coming-july-20th-2022.1310939/");
        }

        [MenuItem("Tools/Asset Store/Check for Updates", false, 45)]
        public static void OpenUpdateChecker()
        {
            var wnd = GetWindowWithRect<ASToolsUpdater>(new Rect(Screen.width / 2, Screen.height / 2, 400, 150), true);
            wnd.Show();
        }

        [MenuItem("Tools/Asset Store/Settings", false, 50)]
        public static void OpenSettings()
        {
            ASToolsPreferencesProvider.OpenSettings();
        }
    }
}