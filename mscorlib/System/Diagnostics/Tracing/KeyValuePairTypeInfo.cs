using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200047D RID: 1149
	internal sealed class KeyValuePairTypeInfo<K, V> : TraceLoggingTypeInfo<KeyValuePair<K, V>>
	{
		// Token: 0x060036EA RID: 14058 RVA: 0x000D3961 File Offset: 0x000D1B61
		public KeyValuePairTypeInfo(List<Type> recursionCheck)
		{
			this.keyInfo = TraceLoggingTypeInfo<K>.GetInstance(recursionCheck);
			this.valueInfo = TraceLoggingTypeInfo<V>.GetInstance(recursionCheck);
		}

		// Token: 0x060036EB RID: 14059 RVA: 0x000D3984 File Offset: 0x000D1B84
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			TraceLoggingMetadataCollector collector2 = collector.AddGroup(name);
			this.keyInfo.WriteMetadata(collector2, "Key", EventFieldFormat.Default);
			this.valueInfo.WriteMetadata(collector2, "Value", format);
		}

		// Token: 0x060036EC RID: 14060 RVA: 0x000D39C0 File Offset: 0x000D1BC0
		public override void WriteData(TraceLoggingDataCollector collector, ref KeyValuePair<K, V> value)
		{
			K key = value.Key;
			V value2 = value.Value;
			this.keyInfo.WriteData(collector, ref key);
			this.valueInfo.WriteData(collector, ref value2);
		}

		// Token: 0x060036ED RID: 14061 RVA: 0x000D39F8 File Offset: 0x000D1BF8
		public override object GetData(object value)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			KeyValuePair<K, V> keyValuePair = (KeyValuePair<K, V>)value;
			dictionary.Add("Key", this.keyInfo.GetData(keyValuePair.Key));
			dictionary.Add("Value", this.valueInfo.GetData(keyValuePair.Value));
			return dictionary;
		}

		// Token: 0x04001855 RID: 6229
		private readonly TraceLoggingTypeInfo<K> keyInfo;

		// Token: 0x04001856 RID: 6230
		private readonly TraceLoggingTypeInfo<V> valueInfo;
	}
}
