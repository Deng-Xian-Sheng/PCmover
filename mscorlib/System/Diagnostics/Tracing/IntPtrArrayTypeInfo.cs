using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000469 RID: 1129
	internal sealed class IntPtrArrayTypeInfo : TraceLoggingTypeInfo<IntPtr[]>
	{
		// Token: 0x060036A5 RID: 13989 RVA: 0x000D357A File Offset: 0x000D177A
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.FormatPtr(format, Statics.IntPtrType));
		}

		// Token: 0x060036A6 RID: 13990 RVA: 0x000D358E File Offset: 0x000D178E
		public override void WriteData(TraceLoggingDataCollector collector, ref IntPtr[] value)
		{
			collector.AddArray(value);
		}
	}
}
