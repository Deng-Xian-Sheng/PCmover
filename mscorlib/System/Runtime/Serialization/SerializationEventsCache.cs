using System;
using System.Collections;

namespace System.Runtime.Serialization
{
	// Token: 0x02000757 RID: 1879
	internal static class SerializationEventsCache
	{
		// Token: 0x060052E2 RID: 21218 RVA: 0x001236DC File Offset: 0x001218DC
		internal static SerializationEvents GetSerializationEventsForType(Type t)
		{
			SerializationEvents serializationEvents;
			if ((serializationEvents = (SerializationEvents)SerializationEventsCache.cache[t]) == null)
			{
				object syncRoot = SerializationEventsCache.cache.SyncRoot;
				lock (syncRoot)
				{
					if ((serializationEvents = (SerializationEvents)SerializationEventsCache.cache[t]) == null)
					{
						serializationEvents = new SerializationEvents(t);
						SerializationEventsCache.cache[t] = serializationEvents;
					}
				}
			}
			return serializationEvents;
		}

		// Token: 0x040024BD RID: 9405
		private static Hashtable cache = new Hashtable();
	}
}
