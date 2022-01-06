//
//  NSDictionary+SMITextMessageUnity.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import "NSDictionary+SMITextMessageUnity.h"
#import "IAWDefines.h"

IAWTextMessageKeys const IAWTextMessageKeysUnityText = @"text";

@implementation NSDictionary (SMITextMessageUnity)
+ (NSDictionary *)iaw_unityDictionaryFromTextMessage:(id<SMITextMessage>)textMessage {
    return @{
        IAWTextMessageKeysUnityText: IAW_SafeReference(textMessage.text)
    };
}
@end
