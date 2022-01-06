//
//  NSDictionary+SMIParticipantUnity.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import "NSDictionary+SMIParticipantUnity.h"
#import "IAWDefines.h"

IAWParticipantKeys const IAWParticipantKeysUnityRole = @"role";
IAWParticipantKeys const IAWParticipantKeysUnitySubject = @"subject";
IAWParticipantKeys const IAWParticipantKeysUnityDisplayName = @"displayName";
IAWParticipantKeys const IAWParticipantKeysUnityLocal = @"local";

@implementation NSDictionary (SMIParticipantUnity)
+ (NSDictionary *)iaw_unityDictionaryFromSender:(id<SMIParticipant>)sender {
    return @{
        IAWParticipantKeysUnityRole: IAW_SafeReference(sender.role),
        IAWParticipantKeysUnitySubject: IAW_SafeReference(sender.subject),
        IAWParticipantKeysUnityDisplayName: IAW_SafeReference(sender.displayName),
        IAWParticipantKeysUnityLocal: @(sender.isLocal)
    };
}
@end
