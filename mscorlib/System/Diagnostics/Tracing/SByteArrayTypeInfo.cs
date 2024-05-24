using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000462 RID: 1122
	internal sealed class SByteArrayTypeInfo : TraceLoggingTypeInfo<sbyte[]>
	{
		// Token: 0x06003690 RID: 13968 RVA: 0x000D348A File Offset: 0x000D168A
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format8(format, TraceLoggingDataType.Int8));
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x000D349A File Offset: 0x000D169A
		public override void WriteData(TraceLoggingDataCollector collector, ref sbyte[] value)
		{
			collector.AddArray(value);
		}
	}
}
