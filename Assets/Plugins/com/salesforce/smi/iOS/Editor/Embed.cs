//using UnityEditor;
//using UnityEditor.Callbacks;
//using UnityEditor.iOS.Xcode;
//using UnityEditor.iOS.Xcode.Extensions;
//using System.IO;
//using System.Collections.Generic;

//namespace Plugins.Salesforce.InApp
//{
//    public class Embed
//    {
//        const string FRAMEWORK_SEARCH_PATHS = "FRAMEWORK_SEARCH_PATHS";
//        const string FrameworkName = "SMIClientCore";
//        const string FrameworkRootDir = "Frameworks";
//        const string FrameworkPath = "Plugins/iOS/com/salesforce/inapp/Frameworks";

//        static readonly string cwd = Directory.GetCurrentDirectory();
//        static readonly string XCFrameworkPath = string.Format("{0}/{1}/{2}.xcframework", FrameworkRootDir, FrameworkPath, FrameworkName);
//        static readonly string assetDir = string.Format("{0}/Assets/{1}", cwd, FrameworkPath);
//        static readonly string[] Archs = {
//            "ios-arm64",
//            "ios-arm64_x86_64-simulator"
//        };

//        [PostProcessBuild]
//        public static void onPostprocessBuild(BuildTarget buildTarget, string path)
//        {
//            if (buildTarget != BuildTarget.iOS) { return; }

//            string projectPath = PBXProject.GetPBXProjectPath(path);
//            PBXProject project = new PBXProject();

//            // On the default framework copy Unity will mirror the directory structure of the xcframework but will omit the top level Info.plist
//            // So we'll include it here.
//            File.Copy(string.Format("{0}/{1}.xcframework/Info.plist", assetDir, FrameworkName), string.Format("{0}/../../{1}/", projectPath, XCFrameworkPath));
//            project.ReadFromFile(projectPath);
//            string mainTargetGUID = project.GetUnityMainTargetGuid();
//            string unityFrameworkGUID = project.GetUnityFrameworkTargetGuid();

//            cleanTarget(project, unityFrameworkGUID);

//            addXCFramework(project, mainTargetGUID, true);
//            addXCFramework(project, unityFrameworkGUID, false);
//            project.WriteToFile(projectPath);
//        }

//        private static void cleanTarget(PBXProject project, string GUID)
//        {
//            string[] frameworkSearchPath = project.GetBuildPropertyForAnyConfig(GUID, FRAMEWORK_SEARCH_PATHS).Split(" ");
//            List<string> removeValues = new List<string>();

//            // Unity as of 2021: by default doesn't seem to understand how to properly handle xcframeworks
//            // It will add each framework under the xcframework structure as a link target for the UnityLibrary Scheme
//            // We'll just remove all of them from the project and explicitly add the xcframework as a build dependency.
//            foreach (string arch in Archs)
//            {
//                string path = string.Format("{0}/{1}/{2}.framework", XCFrameworkPath, arch, FrameworkName);
//                project.RemoveFile(project.FindFileGuidByRealPath(path));
//            }

//            // We want to scrub out the arch specific framework search paths from the project settings as well.
//            foreach(string path in frameworkSearchPath)
//            {
//                if (path.Contains(XCFrameworkPath)) {
//                    removeValues.Add(path);
//                }
//            }

//            project.UpdateBuildProperty(GUID, FRAMEWORK_SEARCH_PATHS, null, removeValues);
//        }

//        private static void addXCFramework(PBXProject project, string GUID, bool embed = false)
//        {
//            string searchPath = string.Format("$(PROJECT_DIR)/{0}/{1}/", FrameworkRootDir, FrameworkPath);
//            string property = project.GetBuildPropertyForAnyConfig(GUID, FRAMEWORK_SEARCH_PATHS);
//            List<string> addValues = new List<string>();

//            if (property == null || property.Length == 0)
//            {
//                addValues.Add("$(inherited)");
//            }

//            addValues.Add(searchPath);

//            project.UpdateBuildProperty(GUID, FRAMEWORK_SEARCH_PATHS, addValues, null);
//            string frameworkGUID = project.AddFile(XCFrameworkPath, XCFrameworkPath);
//            string linkBinaryBuildPhaseGUID = project.GetFrameworksBuildPhaseByTarget(GUID);

//            project.AddFileToBuildSection(GUID, linkBinaryBuildPhaseGUID, frameworkGUID);
//            if (embed)
//            {
//                project.AddFileToEmbedFrameworks(GUID, frameworkGUID);
//            }
//        }
//    }
//}