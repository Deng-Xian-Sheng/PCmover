using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000474 RID: 1140
	internal sealed class EnumInt64TypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036CC RID: 14028 RVA: 0x000D3746 File Offset: 0x000D1946
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format64(format, TraceLoggingDataType.Int64));
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x000D3757 File Offset: 0x000D1957
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<long>.Cast<EnumType>(value));
		}

		// Token: 0x060036CE RID: 14030 RVA: 0x000D376A File Offset: 0x000D196A
		public override object GetData(object value)
		{
			return value;
		}
	}
}
