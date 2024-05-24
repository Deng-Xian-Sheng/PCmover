using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200046A RID: 1130
	internal sealed class UIntPtrArrayTypeInfo : TraceLoggingTypeInfo<UIntPtr[]>
	{
		// Token: 0x060036A8 RID: 13992 RVA: 0x000D35A0 File Offset: 0x000D17A0
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.FormatPtr(format, Statics.UIntPtrType));
		}

		// Token: 0x060036A9 RID: 13993 RVA: 0x000D35B4 File Offset: 0x000D17B4
		public override void WriteData(TraceLoggingDataCollector collector, ref UIntPtr[] value)
		{
			collector.AddArray(value);
		}
	}
}
