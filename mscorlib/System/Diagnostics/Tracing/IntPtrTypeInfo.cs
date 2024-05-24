using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200045B RID: 1115
	internal sealed class IntPtrTypeInfo : TraceLoggingTypeInfo<IntPtr>
	{
		// Token: 0x0600367B RID: 13947 RVA: 0x000D3321 File Offset: 0x000D1521
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.FormatPtr(format, Statics.IntPtrType));
		}

		// Token: 0x0600367C RID: 13948 RVA: 0x000D3335 File Offset: 0x000D1535
		public override void WriteData(TraceLoggingDataCollector collector, ref IntPtr value)
		{
			collector.AddScalar(value);
		}
	}
}
