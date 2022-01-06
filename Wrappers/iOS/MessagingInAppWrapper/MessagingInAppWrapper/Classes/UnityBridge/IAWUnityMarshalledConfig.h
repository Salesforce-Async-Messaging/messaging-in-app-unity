//
//  IAWUnityMarshalledConfig.h
//  MessagingInAppWrapper
//
//  Created by Jeremy Wright on 2022-06-28.
//

#import <Foundation/Foundation.h>

#ifdef __cplusplus
extern "C" {
#endif

struct IAWUnityMarshalledConfig {
    char *serviceURL;
    char *organizationId;
    char *DeveloperName;
};

#ifdef __cplusplus
}
#endif
