using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000456 RID: 1110
	internal sealed class UInt16TypeInfo : TraceLoggingTypeInfo<ushort>
	{
		// Token: 0x0600366C RID: 13932 RVA: 0x000D3275 File Offset: 0x000D1475
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format16(format, TraceLoggingDataType.UInt16));
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x000D3285 File Offset: 0x000D1485
		public override void WriteData(TraceLoggingDataCollector collector, ref ushort value)
		{
			collector.AddScalar(value);
		}
	}
}
