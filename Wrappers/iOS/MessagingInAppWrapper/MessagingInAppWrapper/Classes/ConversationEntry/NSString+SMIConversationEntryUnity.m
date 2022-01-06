//
//  NSString+SMIConversationEntryUnity.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import "NSString+SMIConversationEntryUnity.h"
#import "NSDictionary+SMIConversationEntryUnity.h"

@implementation NSString (SMIConversationEntryUnity)
+ (NSString *)iaw_stringFromEntry:(id<SMIConversationEntry>)entry {
    id dict = [NSDictionary iaw_unityDictionaryFromEntry:entry];
    if (!dict) {
        return nil;
    }

    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:dict options:0 error:nil];
    if (!jsonData) {
        return nil;
    }

    return [NSString.alloc initWithData:jsonData encoding:NSUTF8StringEncoding];
}
@end
