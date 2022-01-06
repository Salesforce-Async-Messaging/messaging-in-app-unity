//
//  NSDictionary+SMIConversationEntryUnity.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <SMIClientCore/SMIClientCore.h>
#import "NSDictionary+SMIConversationEntryUnity.h"
#import "NSDictionary+SMIParticipantUnity.h"
#import "NSDictionary+SMITextMessageUnity.h"
#import "NSDate+IAWEpoch.h"

#import "IAWDefines.h"

IAWConversationEntryKeys const IAWConversationEntryKeysUnityId = @"id";
IAWConversationEntryKeys const IAWConversationEntryKeysUnityConversationId = @"conversationId";
IAWConversationEntryKeys const IAWConversationEntryKeysUnityTimestamp = @"timestamp";
IAWConversationEntryKeys const IAWConversationEntryKeysUnityFormat = @"format";
IAWConversationEntryKeys const IAWConversationEntryKeysUnityType = @"type";
IAWConversationEntryKeys const IAWConversationEntryKeysUnityStatus = @"status";
IAWConversationEntryKeys const IAWConversationEntryKeysUnityPayload = @"payload";
IAWConversationEntryKeys const IAWConversationEntryKeysUnitySender = @"sender";

@implementation NSDictionary (SMIConversationEntryUnity)

+ (NSDictionary *)iaw_unityDictionaryFromEntry:(id<SMIConversationEntry>)entry {
    id<SMIParticipant> participant = (id<SMIParticipant>)entry.sender;
    NSDictionary *payload = nil;

    // Add all entry types here. Initially we only added support for text messages.
    // To support other entry types, you will have to write custom handlers that will
    // convert those payloads to dictionaries, and then assign them here.
    // see `NSDictionary+SMITextMessageUnity`
    if (entry.format == SMIConversationFormatTypesTextMessage) {
        id<SMITextMessage> textPayload = (id<SMITextMessage>)entry.payload;
        payload = [NSDictionary iaw_unityDictionaryFromTextMessage:textPayload];
    } else {
        // If we can't resolve the payload, just return an empty dict for the entire entry
        return nil;
    }

    NSDictionary *sender = [NSDictionary iaw_unityDictionaryFromSender:participant];

    return @{
        IAWConversationEntryKeysUnityId: IAW_SafeReference(entry.identifier),
        IAWConversationEntryKeysUnityConversationId: IAW_SafeReference(entry.conversationId.UUIDString),
        IAWConversationEntryKeysUnityTimestamp: [NSDate iaw_epochFromDate:entry.timestamp],
        IAWConversationEntryKeysUnityFormat: IAW_SafeReference(entry.format),
        IAWConversationEntryKeysUnityType: IAW_SafeReference(entry.type),
        IAWConversationEntryKeysUnityStatus: IAW_SafeReference(entry.status),
        IAWConversationEntryKeysUnityPayload: IAW_SafeReference(payload),
        IAWConversationEntryKeysUnitySender: IAW_SafeReference(sender)
    };
}

@end
