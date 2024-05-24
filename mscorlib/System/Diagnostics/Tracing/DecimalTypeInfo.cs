using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200047C RID: 1148
	internal sealed class DecimalTypeInfo : TraceLoggingTypeInfo<decimal>
	{
		// Token: 0x060036E7 RID: 14055 RVA: 0x000D3934 File Offset: 0x000D1B34
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.MakeDataType(TraceLoggingDataType.Double, format));
		}

		// Token: 0x060036E8 RID: 14056 RVA: 0x000D3945 File Offset: 0x000D1B45
		public override void WriteData(TraceLoggingDataCollector collector, ref decimal value)
		{
			collector.AddScalar((double)value);
		}
	}
}
