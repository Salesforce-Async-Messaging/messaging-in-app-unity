package com.salesforce.messaginginappwrapper

import android.content.Context
import com.salesforce.android.smi.core.CoreClient
import com.salesforce.android.smi.core.CoreConfiguration
import com.salesforce.android.smi.core.events.CoreEvent
import com.salesforce.android.smi.network.data.domain.conversationEntry.entryPayload.ConversationEntryType
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.async
import kotlinx.coroutines.flow.filter
import kotlinx.coroutines.flow.filterIsInstance
import java.util.*

class UnityWrapper {
    companion object {
        lateinit var core: CoreClient
        lateinit var listener: UnityInterface

        @JvmStatic
        fun registerConfig(context: Context, config: CoreConfiguration, listener: UnityInterface) {
            this.core = CoreClient.Factory.create(context, config)
            this.listener = listener

            GlobalScope.async {
                core.events.filterIsInstance<CoreEvent.ConversationEvent.Entry>().filter {
                    // For the POC we'll only be handling Message Types.
                    it.conversationEntry.entryType == ConversationEntryType.Message
                }.collect { event ->
                    listener.onMessageReceived(event)
                }
            }
        }

        @JvmStatic
        fun start() {
            GlobalScope.async { core.start(this) }
        }

        @JvmStatic
        fun stop() {
            core.stop()
        }

        @JvmStatic
        fun reset() {
            // How to clear storage??
        }

        @JvmStatic
        fun sendMessage(message: String, conversationId: String) {
            val uuid = UUID.fromString(conversationId)
            val conversation = core.conversationClient(conversationId = uuid)
            GlobalScope.async { conversation.sendMessage(message) }
        }
    }
}