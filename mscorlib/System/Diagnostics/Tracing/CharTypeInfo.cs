using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200045F RID: 1119
	internal sealed class CharTypeInfo : TraceLoggingTypeInfo<char>
	{
		// Token: 0x06003687 RID: 13959 RVA: 0x000D33B3 File Offset: 0x000D15B3
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format16(format, TraceLoggingDataType.Char16));
		}

		// Token: 0x06003688 RID: 13960 RVA: 0x000D33C7 File Offset: 0x000D15C7
		public override void WriteData(TraceLoggingDataCollector collector, ref char value)
		{
			collector.AddScalar(value);
		}
	}
}
