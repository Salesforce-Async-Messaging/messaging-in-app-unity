# InAppSDK-Unity

## Disclaimer

Please note that this is intended as an example of how you can integrate the Messaging for InApp solution into your mobile unity applications.

This example only contains a minimum integration of basic features of the InAppSDK and is not a full solution. Salesforce is not providing support or additional features for this unity plugin at this time.

## Prerequisites

Before continuing please ensure that your development environment meets the following criteria.

- *NOTE*: For iOS you must be running MacOS Monterey (12.4) or higher. You must also have Xcode 13.3+ installed.

The following will be needed before you will be able to build and deploy the Unity project included.

1. Unity Hub (Highly recommended), and an editor version of unity that is 2021.2.7f1 or later. You can install the Unity Hub [Here](https://unity.com/download)
2. Xcode 13.3+
3. Cocoapods 1.11.3+
4. Android Studio Bumblebee (2021.1.1 Patch 2 or later)
5. A local clone of this git repository.

## Setup

Once you have installed all listed requirements you can get started with the following.

1. Open the Unity Hub application
2. Select Open -> Add project from Disk

![Open the InAppSDK-Unity Project](Docs/Images/Unity-Hub-Open-Project.png?raw=true)

3. Navigate to the directory where you cloned this repo
4. Select Add Project.
5. You should now see `InAppSDK-Unity` listed as a project in the Unity Hub. From here ensure that the `EDITOR VERSION` is set to 2021.2.7f1 or later.
6. Click on the `InAppSDK-Unity` project to open the project within the Unity Editor.
7. In the Unity Editor open the `Sample Scene` by navigating in the Project hierarchy to: `Assets/Plugins/com/salesforce/smi/Common/Test/Scenes`
8. You should now see something like the following in the Scene Viewer in the Unity Editor.

![Viewing the InAppSDK-Unity Sample Scene](Docs/Images/InApp-Sample-Scene.png?raw=true)


9. In the Unity Editor open the Build Settings (File -> Build Settings). 
10. In the Build Settings window ensure that the `Sample Scene` is included in the build. If it's not listed you can click `Add Open Scenes`

![Setting up Build Settings](Docs/Images/Build-Settings.png?raw=true)

You're almost ready to get started. First you need to decide for which platform you wish to build.

### iOS

To build and deploy to an iOS device you should do the following.

1. Choose the `iOS` platform from the platform list on the left of the Build Settings window.
2. If iOS is not the current platform you must click `Switch Platform`
3. Click `Build and Run`
4. You will be asked for a location where the iOS project will be created. It is recommended that you make a `Build/iOS` directory from the root of the project for this.

Now Unity will compile the project and create a `Unity-iPhone.xcworkspace` in the directory you chose. This project is preconfigured to pull all required dependencies via cocoapods.

From here you can open the `Unity-iPhone.xcworkspace` and build to your device. See the following documentation [Here](https://docs.unity3d.com/Manual/UnityCloudBuildiOS.html) for more information about building to iOS with Unity.

### Android

For Android the process is almost identical to iOS with one step you need to perform *BEFORE* you attempt to build from Unity.
In this repo there is an Android project in the `Wrappers/Android/Wrapper` directory. You should open this project in Android studio and run the `publishToLocalMaven` gradle task.

When the wrapper has been deployed to your local maven repository you can continue in the Build Settings. 

1. Choose the `Android` platform from the platform list on the left of the Build Settings window.
2. If AndroidS is not the current platform you must click `Switch Platform`
3. Ensure that you have an android device connected, and you should be able to select that device in the `Run Device` dropdown. You may need to hit `Refresh` for your device to be listed.
4. Click `Build and Run`
5. You will be asked for a location and a name for the Android apk. It is recommended that you make a `Build/Android` directory from the root of the project for this.
