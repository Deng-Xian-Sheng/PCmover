using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000460 RID: 1120
	internal sealed class BooleanArrayTypeInfo : TraceLoggingTypeInfo<bool[]>
	{
		// Token: 0x0600368A RID: 13962 RVA: 0x000D33D9 File Offset: 0x000D15D9
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format8(format, TraceLoggingDataType.Boolean8));
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x000D33ED File Offset: 0x000D15ED
		public override void WriteData(TraceLoggingDataCollector collector, ref bool[] value)
		{
			collector.AddArray(value);
		}
	}
}
