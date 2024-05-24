using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200045A RID: 1114
	internal sealed class UInt64TypeInfo : TraceLoggingTypeInfo<ulong>
	{
		// Token: 0x06003678 RID: 13944 RVA: 0x000D32FE File Offset: 0x000D14FE
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format64(format, TraceLoggingDataType.UInt64));
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x000D330F File Offset: 0x000D150F
		public override void WriteData(TraceLoggingDataCollector collector, ref ulong value)
		{
			collector.AddScalar(value);
		}
	}
}
