using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000458 RID: 1112
	internal sealed class UInt32TypeInfo : TraceLoggingTypeInfo<uint>
	{
		// Token: 0x06003672 RID: 13938 RVA: 0x000D32B9 File Offset: 0x000D14B9
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format32(format, TraceLoggingDataType.UInt32));
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x000D32C9 File Offset: 0x000D14C9
		public override void WriteData(TraceLoggingDataCollector collector, ref uint value)
		{
			collector.AddScalar(value);
		}
	}
}
