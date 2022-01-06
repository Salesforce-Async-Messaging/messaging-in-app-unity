//
//  NSDictionary+SMITextMessageUnity.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>
#import <SMIClientCore/SMIClientCore.h>

NS_ASSUME_NONNULL_BEGIN

typedef NSString *IAWTextMessageKeys NS_TYPED_ENUM;

FOUNDATION_EXPORT IAWTextMessageKeys const IAWTextMessageKeysUnityText;

@interface NSDictionary (SMITextMessageUnity)
+ (NSDictionary *)iaw_unityDictionaryFromTextMessage:(id<SMITextMessage>)textMessage;
@end

NS_ASSUME_NONNULL_END
