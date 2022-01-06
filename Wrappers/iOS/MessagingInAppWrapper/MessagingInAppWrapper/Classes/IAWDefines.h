//
//  IAWDefines.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#ifdef IAW_SafeReference
#undef IAW_SafeReference
#endif

#define IAW_SafeReference(value) value ? value : NSNull.null

#ifdef IAW_safeReferenceWithString
#undef IAW_safeReferenceWithString
#endif

#define IAW_safeReferenceWithString(value) value == nil ? @"" : value

#ifdef IAW_safeDereference
#undef IAW_safeDereference
#endif

#define IAW_safeDereference(value) [value isKindOfClass:NSNull.class] ? nil : value

#ifdef IAWLog
#undef IAWLog
#endif

#ifdef DEBUG

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wgnu-zero-variadic-macro-arguments"

#define IAWLog(format, ...) NSLog(format, ##__VA_ARGS__)

#pragma clang diagnostic pop

#else
#define IAWLog(format, ...)

#endif
