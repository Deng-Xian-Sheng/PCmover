using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200046C RID: 1132
	internal sealed class DoubleArrayTypeInfo : TraceLoggingTypeInfo<double[]>
	{
		// Token: 0x060036AE RID: 13998 RVA: 0x000D35EC File Offset: 0x000D17EC
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddArray(name, Statics.Format64(format, TraceLoggingDataType.Double));
		}

		// Token: 0x060036AF RID: 13999 RVA: 0x000D35FD File Offset: 0x000D17FD
		public override void WriteData(TraceLoggingDataCollector collector, ref double[] value)
		{
			collector.AddArray(value);
		}
	}
}
