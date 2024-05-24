using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000457 RID: 1111
	internal sealed class Int32TypeInfo : TraceLoggingTypeInfo<int>
	{
		// Token: 0x0600366F RID: 13935 RVA: 0x000D3297 File Offset: 0x000D1497
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format32(format, TraceLoggingDataType.Int32));
		}

		// Token: 0x06003670 RID: 13936 RVA: 0x000D32A7 File Offset: 0x000D14A7
		public override void WriteData(TraceLoggingDataCollector collector, ref int value)
		{
			collector.AddScalar(value);
		}
	}
}
