package com.salesforce.messaginginappwrapper

import com.salesforce.android.smi.core.events.CoreEvent

interface UnityInterface {
    fun onMessageReceived(event: CoreEvent.ConversationEvent.Entry)
}