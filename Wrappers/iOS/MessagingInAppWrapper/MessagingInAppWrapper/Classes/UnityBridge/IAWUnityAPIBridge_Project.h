//
//  IAWUnityAPIBridge_Project.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <SMIClientCore/SMICoreDelegate.h>
#import <MessagingInAppWrapper/IAWUnityAPIBridge.h>

@interface IAWUnityAPIBridge() <SMICoreDelegate>
+ (instancetype)sharedInstance;

@property (nonatomic, readwrite, weak) id<SMICoreClient> core;
@end
