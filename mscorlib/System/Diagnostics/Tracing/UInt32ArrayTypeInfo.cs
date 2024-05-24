using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000466 RID: 1126
	internal sealed class UInt32ArrayTypeInfo : TraceLoggingTypeInfo<uint[]>
	{
		// Token: 0x0600369C RID: 13980 RVA: 0x000D3512 File Offset: 0x000D1712
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format32(format, TraceLoggingDataType.UInt32));
		}

		// Token: 0x0600369D RID: 13981 RVA: 0x000D3522 File Offset: 0x000D1722
		public override void WriteData(TraceLoggingDataCollector collector, ref uint[] value)
		{
			collector.AddArray(value);
		}
	}
}
