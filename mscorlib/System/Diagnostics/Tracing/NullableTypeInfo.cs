using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200047E RID: 1150
	internal sealed class NullableTypeInfo<T> : TraceLoggingTypeInfo<T?> where T : struct
	{
		// Token: 0x060036EE RID: 14062 RVA: 0x000D3A57 File Offset: 0x000D1C57
		public NullableTypeInfo(List<Type> recursionCheck)
		{
			this.valueInfo = TraceLoggingTypeInfo<T>.GetInstance(recursionCheck);
		}

		// Token: 0x060036EF RID: 14063 RVA: 0x000D3A6C File Offset: 0x000D1C6C
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			TraceLoggingMetadataCollector traceLoggingMetadataCollector = collector.AddGroup(name);
			traceLoggingMetadataCollector.AddScalar("HasValue", TraceLoggingDataType.Boolean8);
			this.valueInfo.WriteMetadata(traceLoggingMetadataCollector, "Value", format);
		}

		// Token: 0x060036F0 RID: 14064 RVA: 0x000D3AA4 File Offset: 0x000D1CA4
		public override void WriteData(TraceLoggingDataCollector collector, ref T? value)
		{
			bool flag = value != null;
			collector.AddScalar(flag);
			T t = flag ? value.Value : default(T);
			this.valueInfo.WriteData(collector, ref t);
		}

		// Token: 0x04001857 RID: 6231
		private readonly TraceLoggingTypeInfo<T> valueInfo;
	}
}
