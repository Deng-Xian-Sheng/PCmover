using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000465 RID: 1125
	internal sealed class Int32ArrayTypeInfo : TraceLoggingTypeInfo<int[]>
	{
		// Token: 0x06003699 RID: 13977 RVA: 0x000D34F0 File Offset: 0x000D16F0
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format32(format, TraceLoggingDataType.Int32));
		}

		// Token: 0x0600369A RID: 13978 RVA: 0x000D3500 File Offset: 0x000D1700
		public override void WriteData(TraceLoggingDataCollector collector, ref int[] value)
		{
			collector.AddArray(value);
		}
	}
}
