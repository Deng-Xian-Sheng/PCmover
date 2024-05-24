using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000467 RID: 1127
	internal sealed class Int64ArrayTypeInfo : TraceLoggingTypeInfo<long[]>
	{
		// Token: 0x0600369F RID: 13983 RVA: 0x000D3534 File Offset: 0x000D1734
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format64(format, TraceLoggingDataType.Int64));
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x000D3545 File Offset: 0x000D1745
		public override void WriteData(TraceLoggingDataCollector collector, ref long[] value)
		{
			collector.AddArray(value);
		}
	}
}
