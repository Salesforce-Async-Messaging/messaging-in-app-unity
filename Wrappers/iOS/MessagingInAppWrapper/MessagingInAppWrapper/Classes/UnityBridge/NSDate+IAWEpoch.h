//
//  NSDate+IAWEpoch.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface NSDate (IAWEpoch)
+ (NSNumber *)iaw_epochFromDate:(NSDate *)date;
@end

NS_ASSUME_NONNULL_END
