using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200046D RID: 1133
	internal sealed class SingleArrayTypeInfo : TraceLoggingTypeInfo<float[]>
	{
		// Token: 0x060036B1 RID: 14001 RVA: 0x000D360F File Offset: 0x000D180F
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format32(format, TraceLoggingDataType.Float));
		}

		// Token: 0x060036B2 RID: 14002 RVA: 0x000D3620 File Offset: 0x000D1820
		public override void WriteData(TraceLoggingDataCollector collector, ref float[] value)
		{
			collector.AddArray(value);
		}
	}
}
