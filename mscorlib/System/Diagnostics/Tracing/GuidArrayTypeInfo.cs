using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000478 RID: 1144
	internal sealed class GuidArrayTypeInfo : TraceLoggingTypeInfo<Guid[]>
	{
		// Token: 0x060036DB RID: 14043 RVA: 0x000D380E File Offset: 0x000D1A0E
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.MakeDataType(TraceLoggingDataType.Guid, format));
		}

		// Token: 0x060036DC RID: 14044 RVA: 0x000D381F File Offset: 0x000D1A1F
		public override void WriteData(TraceLoggingDataCollector collector, ref Guid[] value)
		{
			collector.AddArray(value);
		}
	}
}
