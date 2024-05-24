using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000464 RID: 1124
	internal sealed class UInt16ArrayTypeInfo : TraceLoggingTypeInfo<ushort[]>
	{
		// Token: 0x06003696 RID: 13974 RVA: 0x000D34CE File Offset: 0x000D16CE
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format16(format, TraceLoggingDataType.UInt16));
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x000D34DE File Offset: 0x000D16DE
		public override void WriteData(TraceLoggingDataCollector collector, ref ushort[] value)
		{
			collector.AddArray(value);
		}
	}
}
