//
//  NSDictionary+SMIParticipantUnity.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>
#import <SMIClientCore/SMIClientCore.h>

NS_ASSUME_NONNULL_BEGIN

typedef NSString *IAWParticipantKeys NS_TYPED_ENUM;

FOUNDATION_EXPORT IAWParticipantKeys const IAWParticipantKeysUnityRole;
FOUNDATION_EXPORT IAWParticipantKeys const IAWParticipantKeysUnitySubject;
FOUNDATION_EXPORT IAWParticipantKeys const IAWParticipantKeysUnityDisplayName;
FOUNDATION_EXPORT IAWParticipantKeys const IAWParticipantKeysUnityLocal;

@interface NSDictionary (SMIParticipantUnity)
+ (NSDictionary *)iaw_unityDictionaryFromSender:(id<SMIParticipant>)sender;
@end

NS_ASSUME_NONNULL_END
