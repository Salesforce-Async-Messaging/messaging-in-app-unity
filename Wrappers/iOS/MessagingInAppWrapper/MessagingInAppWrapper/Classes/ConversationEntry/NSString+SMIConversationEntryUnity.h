//
//  NSString+SMIConversationEntryUnity.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>
#import <SMIClientCore/SMIClientCore.h>

NS_ASSUME_NONNULL_BEGIN

@interface NSString (SMIConversationEntryUnity)
+ (NSString *)iaw_stringFromEntry:(id<SMIConversationEntry>)entry;
@end

NS_ASSUME_NONNULL_END
