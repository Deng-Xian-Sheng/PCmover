using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000454 RID: 1108
	internal sealed class SByteTypeInfo : TraceLoggingTypeInfo<sbyte>
	{
		// Token: 0x06003666 RID: 13926 RVA: 0x000D3231 File Offset: 0x000D1431
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format8(format, TraceLoggingDataType.Int8));
		}

		// Token: 0x06003667 RID: 13927 RVA: 0x000D3241 File Offset: 0x000D1441
		public override void WriteData(TraceLoggingDataCollector collector, ref sbyte value)
		{
			collector.AddScalar(value);
		}
	}
}
