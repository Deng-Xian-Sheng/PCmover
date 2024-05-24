using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000463 RID: 1123
	internal sealed class Int16ArrayTypeInfo : TraceLoggingTypeInfo<short[]>
	{
		// Token: 0x06003693 RID: 13971 RVA: 0x000D34AC File Offset: 0x000D16AC
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format16(format, TraceLoggingDataType.Int16));
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x000D34BC File Offset: 0x000D16BC
		public override void WriteData(TraceLoggingDataCollector collector, ref short[] value)
		{
			collector.AddArray(value);
		}
	}
}
