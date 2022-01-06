//
//  IAWUnityAPIBridge.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>

#ifdef __cplusplus
extern "C" {
#endif

typedef void (*DidReceiveMessageFunctionPtr)(const char *entry);

/// Must be called before any other operation, or if the configuration has changed.
/// @param inConfig the input configuration to be used for InApp.
BOOL IAW_Core_RegisterConfig(struct IAWUnityMarshalledConfig *inConfig);

BOOL IAW_Core_Start(void);
BOOL IAW_Core_Stop(void);
BOOL IAW_Core_Reset(void);
BOOL IAW_Core_SendMessage(char *inMessage, char *inConversationId);

/// Pass a f;unction object that takes a string as a single parameter.
/// @param callback Function Pointer to a function which will receive the message result as serialized JSON.
void IAW_Core_Delegate_RegisterDidReceiveMessage(DidReceiveMessageFunctionPtr callback);

#ifdef __cplusplus
}
#endif

NS_ASSUME_NONNULL_BEGIN

@interface IAWUnityAPIBridge : NSObject

@end

NS_ASSUME_NONNULL_END
