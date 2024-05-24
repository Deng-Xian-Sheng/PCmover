using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200047B RID: 1147
	internal sealed class TimeSpanTypeInfo : TraceLoggingTypeInfo<TimeSpan>
	{
		// Token: 0x060036E4 RID: 14052 RVA: 0x000D390D File Offset: 0x000D1B0D
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.MakeDataType(TraceLoggingDataType.Int64, format));
		}

		// Token: 0x060036E5 RID: 14053 RVA: 0x000D391E File Offset: 0x000D1B1E
		public override void WriteData(TraceLoggingDataCollector collector, ref TimeSpan value)
		{
			collector.AddScalar(value.Ticks);
		}
	}
}
