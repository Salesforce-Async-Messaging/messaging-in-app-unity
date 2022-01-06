//
//  NSDate+IAWEpoch.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import "NSDate+IAWEpoch.h"

@implementation NSDate (IAWEpoch)
+ (NSNumber *)iaw_epochFromDate:(NSDate *)date {
    NSUInteger epoch = (NSUInteger)(floor(date.timeIntervalSince1970));
    epoch *= 1000;

    return @(epoch);
}
@end
