using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200045D RID: 1117
	internal sealed class DoubleTypeInfo : TraceLoggingTypeInfo<double>
	{
		// Token: 0x06003681 RID: 13953 RVA: 0x000D336D File Offset: 0x000D156D
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format64(format, TraceLoggingDataType.Double));
		}

		// Token: 0x06003682 RID: 13954 RVA: 0x000D337E File Offset: 0x000D157E
		public override void WriteData(TraceLoggingDataCollector collector, ref double value)
		{
			collector.AddScalar(value);
		}
	}
}
