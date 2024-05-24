using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000479 RID: 1145
	internal sealed class DateTimeTypeInfo : TraceLoggingTypeInfo<DateTime>
	{
		// Token: 0x060036DE RID: 14046 RVA: 0x000D3831 File Offset: 0x000D1A31
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.MakeDataType(TraceLoggingDataType.FileTime, format));
		}

		// Token: 0x060036DF RID: 14047 RVA: 0x000D3844 File Offset: 0x000D1A44
		public override void WriteData(TraceLoggingDataCollector collector, ref DateTime value)
		{
			long ticks = value.Ticks;
			collector.AddScalar((ticks < 504911232000000000L) ? 0L : (ticks - 504911232000000000L));
		}
	}
}
