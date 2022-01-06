//
//  NSString+UnityMarshaller.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface NSString (UnityMarshaller)
+ (NSString *)iaw_stringCopyFromChar:(const char*)string;
- (const char *)iaw_toCharArray;
@end

NS_ASSUME_NONNULL_END
