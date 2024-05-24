using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000472 RID: 1138
	internal sealed class EnumInt32TypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036C4 RID: 14020 RVA: 0x000D36EA File Offset: 0x000D18EA
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format32(format, TraceLoggingDataType.Int32));
		}

		// Token: 0x060036C5 RID: 14021 RVA: 0x000D36FA File Offset: 0x000D18FA
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<int>.Cast<EnumType>(value));
		}

		// Token: 0x060036C6 RID: 14022 RVA: 0x000D370D File Offset: 0x000D190D
		public override object GetData(object value)
		{
			return value;
		}
	}
}
