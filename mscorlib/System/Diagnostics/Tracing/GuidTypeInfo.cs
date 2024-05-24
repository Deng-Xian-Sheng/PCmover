using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000477 RID: 1143
	internal sealed class GuidTypeInfo : TraceLoggingTypeInfo<Guid>
	{
		// Token: 0x060036D8 RID: 14040 RVA: 0x000D37E7 File Offset: 0x000D19E7
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.MakeDataType(TraceLoggingDataType.Guid, format));
		}

		// Token: 0x060036D9 RID: 14041 RVA: 0x000D37F8 File Offset: 0x000D19F8
		public override void WriteData(TraceLoggingDataCollector collector, ref Guid value)
		{
			collector.AddScalar(value);
		}
	}
}
