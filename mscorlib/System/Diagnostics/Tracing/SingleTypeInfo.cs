using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200045E RID: 1118
	internal sealed class SingleTypeInfo : TraceLoggingTypeInfo<float>
	{
		// Token: 0x06003684 RID: 13956 RVA: 0x000D3390 File Offset: 0x000D1590
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format32(format, TraceLoggingDataType.Float));
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x000D33A1 File Offset: 0x000D15A1
		public override void WriteData(TraceLoggingDataCollector collector, ref float value)
		{
			collector.AddScalar(value);
		}
	}
}
