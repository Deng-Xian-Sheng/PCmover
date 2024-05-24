using System;
using System.Collections;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000755 RID: 1877
	public sealed class SerializationObjectManager
	{
		// Token: 0x060052D6 RID: 21206 RVA: 0x00123242 File Offset: 0x00121442
		public SerializationObjectManager(StreamingContext context)
		{
			this.m_context = context;
			this.m_objectSeenTable = new Hashtable();
		}

		// Token: 0x060052D7 RID: 21207 RVA: 0x00123268 File Offset: 0x00121468
		[SecurityCritical]
		public void RegisterObject(object obj)
		{
			SerializationEvents serializationEventsForType = SerializationEventsCache.GetSerializationEventsForType(obj.GetType());
			if (serializationEventsForType.HasOnSerializingEvents && this.m_objectSeenTable[obj] == null)
			{
				this.m_objectSeenTable[obj] = true;
				serializationEventsForType.InvokeOnSerializing(obj, this.m_context);
				this.AddOnSerialized(obj);
			}
		}

		// Token: 0x060052D8 RID: 21208 RVA: 0x001232BD File Offset: 0x001214BD
		public void RaiseOnSerializedEvent()
		{
			if (this.m_onSerializedHandler != null)
			{
				this.m_onSerializedHandler(this.m_context);
			}
		}

		// Token: 0x060052D9 RID: 21209 RVA: 0x001232D8 File Offset: 0x001214D8
		[SecuritySafeCritical]
		private void AddOnSerialized(object obj)
		{
			SerializationEvents serializationEventsForType = SerializationEventsCache.GetSerializationEventsForType(obj.GetType());
			this.m_onSerializedHandler = serializationEventsForType.AddOnSerialized(obj, this.m_onSerializedHandler);
		}

		// Token: 0x040024B6 RID: 9398
		private Hashtable m_objectSeenTable = new Hashtable();

		// Token: 0x040024B7 RID: 9399
		private SerializationEventHandler m_onSerializedHandler;

		// Token: 0x040024B8 RID: 9400
		private StreamingContext m_context;
	}
}
