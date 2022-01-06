#!/bin/bash
cd "$( dirname "${BASH_SOURCE[0]}" )"

cd ../

ASSET_DIR="Assets"
INAPP_PLUGIN_DIR="${ASSET_DIR}/Plugins/Salesforce/InApp"
IOS_ASSET_FRAMEWORK_DIR="${INAPP_PLUGIN_DIR}/iOS/Frameworks"

IOS_BUILD_CONFIGURATION=${IOS_BUILD_CONFIGURATION:-Debug}
IOS_DEPENDENCIES_DIR="Dependencies/InAppSDK-iOS"
IOS_RELEASE_DIR="${IOS_DEPENDENCIES_DIR}/Release/SMIClientCore-${IOS_BUILD_CONFIGURATION}/Framework"
IOS_FRAMEWORK_NAME="SMIClientCore.xcframework"

pushd "${IOS_DEPENDENCIES_DIR}"

xcodebuild -workspace "SMIClientSDK.xcworkspace" -scheme SMIClientCoreUniversal

popd

# Remove the previous framework
rm -rf "${IOS_ASSET_FRAMEWORK_DIR}"
mkdir -p "${IOS_ASSET_FRAMEWORK_DIR}"

cp -a "${IOS_RELEASE_DIR}/${IOS_FRAMEWORK_NAME}" "${IOS_ASSET_FRAMEWORK_DIR}"
