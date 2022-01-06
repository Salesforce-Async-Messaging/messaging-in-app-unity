//
//  NSDictionary+SMIConversationEntryUnity.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>
#import <SMIClientCore/SMIClientCore.h>

NS_ASSUME_NONNULL_BEGIN

typedef NSString *IAWConversationEntryKeys NS_TYPED_ENUM;

FOUNDATION_EXPORT IAWConversationEntryKeys const IAWConversationEntryKeysUnityId;
FOUNDATION_EXPORT IAWConversationEntryKeys const IAWConversationEntryKeysUnityConversationId;
FOUNDATION_EXPORT IAWConversationEntryKeys const SMIConversationEntryKeysUnityTimestamp;
FOUNDATION_EXPORT IAWConversationEntryKeys const SMIConversationEntryKeysUnityFormat;
FOUNDATION_EXPORT IAWConversationEntryKeys const SMIConversationEntryKeysUnityType;
FOUNDATION_EXPORT IAWConversationEntryKeys const SMIConversationEntryKeysUnityStatus;
FOUNDATION_EXPORT IAWConversationEntryKeys const SMIConversationEntryKeysUnityPayload;
FOUNDATION_EXPORT IAWConversationEntryKeys const IAWConversationEntryKeysUnitySender;

@interface NSDictionary (SMIConversationEntryUnity)
+ (NSDictionary *)iaw_unityDictionaryFromEntry:(id<SMIConversationEntry>)entry;
@end

NS_ASSUME_NONNULL_END
