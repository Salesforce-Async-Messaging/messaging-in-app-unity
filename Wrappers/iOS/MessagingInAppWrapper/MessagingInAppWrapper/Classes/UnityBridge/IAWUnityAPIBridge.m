//
//  IAWUnityAPIBridge.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <SMIClientCore/SMIClientCore.h>
#import <MessagingInAppWrapper/IAWUnityMarshalledConfig.h>

#import "IAWUnityAPIBridge_Project.h"
#import "NSString+UnityMarshaller.h"
#import "NSString+SMIConversationEntryUnity.h"
#import "IAWDefines.h"

@interface IAWUnityAPIBridge()
@property (nonatomic, readwrite, assign) DidReceiveMessageFunctionPtr didReceiveMessagePtr;
@end

@implementation IAWUnityAPIBridge

+ (instancetype)sharedInstance {
    static dispatch_once_t once;
    static id sharedInstance;

    dispatch_once(&once, ^{
        sharedInstance = [self.alloc init];
    });

    return sharedInstance;
}

- (void)core:(__weak id<SMICoreClient>)core didReceiveEntry:(id<SMIConversationEntry>)entry {
    id json = [NSString iaw_stringFromEntry:entry];

    if (json && self.didReceiveMessagePtr) {
        self.didReceiveMessagePtr([json iaw_toCharArray]);
    }
}

@end

BOOL IAW_Core_RegisterConfig(struct IAWUnityMarshalledConfig *inConfig) {
    IAWLog(@"[InApp] Called: IAW_Core_RegisterConfig");

    id URLString = [NSString iaw_stringCopyFromChar:inConfig->serviceURL];
    id organizationId = [NSString iaw_stringCopyFromChar:inConfig->organizationId];
    id developerName = [NSString iaw_stringCopyFromChar:inConfig->DeveloperName];
    NSURL *serviceURL = [NSURL URLWithString:URLString];

    IAWLog(@"[InApp] urlString: %@", URLString);
    IAWLog(@"[InApp] organizationID: %@", organizationId);
    IAWLog(@"[InApp] developerName: %@", developerName);
    IAWLog(@"[InApp] NSURL: %@", serviceURL);

    SMICoreConfiguration *config = [SMICoreConfiguration.alloc initWithServiceAPI:serviceURL organizationId:organizationId developerName:developerName];
    id<SMICoreClient> coreClient = [SMICoreFactory createWithConfig:config];
    if (!coreClient) {
        return NO;
    }

    // Remove delegate to ensure that we're not sending duplicate events to the singleton.
    [IAWUnityAPIBridge.sharedInstance.core removeDelegate:IAWUnityAPIBridge.sharedInstance];

    IAWUnityAPIBridge.sharedInstance.core = coreClient;
    [coreClient addDelegate:IAWUnityAPIBridge.sharedInstance];
    return YES;
}

BOOL IAW_Core_Start() {
    IAWLog(@"[InApp] Called: IAW_Core_Start");
    id<SMICoreClient> core = IAWUnityAPIBridge.sharedInstance.core;
    if (!core) { return NO; }

    [core start];

    return YES;
}

BOOL IAW_Core_Stop() {
    IAWLog(@"[InApp] Called: IAW_Core_Stop");
    id<SMICoreClient> core = IAWUnityAPIBridge.sharedInstance.core;
    if (!core) { return NO; }

    [core stop];

    return YES;
}

BOOL IAW_Core_Reset() {
    IAWLog(@"[InApp] Called: IAW_Core_Reset");
    id<SMICoreClient> core = IAWUnityAPIBridge.sharedInstance.core;
    if (!core) { return NO; }

    [core destroyStorage:^(__unused NSError * _Nullable error) {}];
    return YES;
}

BOOL IAW_Core_SendMessage(char *inMessage, char *inConversationId) {
    IAWLog(@"[InApp] Called: IAW_Core_SendMessage");
    id<SMICoreClient> core = IAWUnityAPIBridge.sharedInstance.core;
    if (!core) { return NO; }

    id message = [NSString iaw_stringCopyFromChar:inMessage];
    id stringId = [NSString iaw_stringCopyFromChar:inConversationId];
    NSUUID *conversationId = [NSUUID.alloc initWithUUIDString:stringId];

    IAWLog(@"[InApp] Using Conversation Id: %@", conversationId.UUIDString);

    id<SMIConversationClient> client = [core conversationClientWithId:conversationId];
    if (!client) { return NO; }

    [client sendMessage:message];
    return YES;
}

void IAW_Core_Delegate_RegisterDidReceiveMessage(DidReceiveMessageFunctionPtr callback) {
    IAWUnityAPIBridge.sharedInstance.didReceiveMessagePtr = callback;
}
