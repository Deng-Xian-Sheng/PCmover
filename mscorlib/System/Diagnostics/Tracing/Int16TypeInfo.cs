using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000455 RID: 1109
	internal sealed class Int16TypeInfo : TraceLoggingTypeInfo<short>
	{
		// Token: 0x06003669 RID: 13929 RVA: 0x000D3253 File Offset: 0x000D1453
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format16(format, TraceLoggingDataType.Int16));
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x000D3263 File Offset: 0x000D1463
		public override void WriteData(TraceLoggingDataCollector collector, ref short value)
		{
			collector.AddScalar(value);
		}
	}
}
