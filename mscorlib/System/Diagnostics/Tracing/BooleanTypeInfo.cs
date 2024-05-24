using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000452 RID: 1106
	internal sealed class BooleanTypeInfo : TraceLoggingTypeInfo<bool>
	{
		// Token: 0x06003660 RID: 13920 RVA: 0x000D31E9 File Offset: 0x000D13E9
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format8(format, TraceLoggingDataType.Boolean8));
		}

		// Token: 0x06003661 RID: 13921 RVA: 0x000D31FD File Offset: 0x000D13FD
		public override void WriteData(TraceLoggingDataCollector collector, ref bool value)
		{
			collector.AddScalar(value);
		}
	}
}
