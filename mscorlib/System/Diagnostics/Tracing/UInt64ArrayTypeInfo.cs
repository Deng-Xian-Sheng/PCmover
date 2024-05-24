using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000468 RID: 1128
	internal sealed class UInt64ArrayTypeInfo : TraceLoggingTypeInfo<ulong[]>
	{
		// Token: 0x060036A2 RID: 13986 RVA: 0x000D3557 File Offset: 0x000D1757
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format64(format, TraceLoggingDataType.UInt64));
		}

		// Token: 0x060036A3 RID: 13987 RVA: 0x000D3568 File Offset: 0x000D1768
		public override void WriteData(TraceLoggingDataCollector collector, ref ulong[] value)
		{
			collector.AddArray(value);
		}
	}
}
