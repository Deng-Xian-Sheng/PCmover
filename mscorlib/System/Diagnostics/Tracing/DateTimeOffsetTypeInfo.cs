﻿using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200047A RID: 1146
	internal sealed class DateTimeOffsetTypeInfo : TraceLoggingTypeInfo<DateTimeOffset>
	{
		// Token: 0x060036E1 RID: 14049 RVA: 0x000D3884 File Offset: 0x000D1A84
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			TraceLoggingMetadataCollector traceLoggingMetadataCollector = collector.AddGroup(name);
			traceLoggingMetadataCollector.AddScalar("Ticks", Statics.MakeDataType(TraceLoggingDataType.FileTime, format));
			traceLoggingMetadataCollector.AddScalar("Offset", TraceLoggingDataType.Int64);
		}

		// Token: 0x060036E2 RID: 14050 RVA: 0x000D38BC File Offset: 0x000D1ABC
		public override void WriteData(TraceLoggingDataCollector collector, ref DateTimeOffset value)
		{
			long ticks = value.Ticks;
			collector.AddScalar((ticks < 504911232000000000L) ? 0L : (ticks - 504911232000000000L));
			collector.AddScalar(value.Offset.Ticks);
		}
	}
}
