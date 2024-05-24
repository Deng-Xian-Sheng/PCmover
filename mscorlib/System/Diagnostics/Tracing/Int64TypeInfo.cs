using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000459 RID: 1113
	internal sealed class Int64TypeInfo : TraceLoggingTypeInfo<long>
	{
		// Token: 0x06003675 RID: 13941 RVA: 0x000D32DB File Offset: 0x000D14DB
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format64(format, TraceLoggingDataType.Int64));
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x000D32EC File Offset: 0x000D14EC
		public override void WriteData(TraceLoggingDataCollector collector, ref long value)
		{
			collector.AddScalar(value);
		}
	}
}
