using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200045C RID: 1116
	internal sealed class UIntPtrTypeInfo : TraceLoggingTypeInfo<UIntPtr>
	{
		// Token: 0x0600367E RID: 13950 RVA: 0x000D3347 File Offset: 0x000D1547
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.FormatPtr(format, Statics.UIntPtrType));
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x000D335B File Offset: 0x000D155B
		public override void WriteData(TraceLoggingDataCollector collector, ref UIntPtr value)
		{
			collector.AddScalar(value);
		}
	}
}
