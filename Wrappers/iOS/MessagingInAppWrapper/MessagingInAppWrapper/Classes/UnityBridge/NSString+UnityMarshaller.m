//
//  NSString+UnityMarshaller.m
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import "NSString+UnityMarshaller.h"

@implementation NSString (UnityMarshaller)

+ (NSString *)iaw_stringCopyFromChar:(const char*)string {
    if (string == NULL) {
        return NULL;
    }

    char *res = (char *)malloc(strlen(string) + 1);
    strcpy(res, string);

    NSString *nsRes = [NSString stringWithCString:res encoding:NSUTF8StringEncoding];
    free(res);

    return nsRes;
}

- (const char *)iaw_toCharArray {
    return strdup([self UTF8String]);
}

@end
