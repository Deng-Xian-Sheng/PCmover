using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000453 RID: 1107
	internal sealed class ByteTypeInfo : TraceLoggingTypeInfo<byte>
	{
		// Token: 0x06003663 RID: 13923 RVA: 0x000D320F File Offset: 0x000D140F
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format8(format, TraceLoggingDataType.UInt8));
		}

		// Token: 0x06003664 RID: 13924 RVA: 0x000D321F File Offset: 0x000D141F
		public override void WriteData(TraceLoggingDataCollector collector, ref byte value)
		{
			collector.AddScalar(value);
		}
	}
}
