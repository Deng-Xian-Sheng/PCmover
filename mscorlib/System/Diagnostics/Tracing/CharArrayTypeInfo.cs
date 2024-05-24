using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200046B RID: 1131
	internal sealed class CharArrayTypeInfo : TraceLoggingTypeInfo<char[]>
	{
		// Token: 0x060036AB RID: 13995 RVA: 0x000D35C6 File Offset: 0x000D17C6
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format16(format, TraceLoggingDataType.Char16));
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x000D35DA File Offset: 0x000D17DA
		public override void WriteData(TraceLoggingDataCollector collector, ref char[] value)
		{
			collector.AddArray(value);
		}
	}
}
