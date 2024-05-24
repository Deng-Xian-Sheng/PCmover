using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000473 RID: 1139
	internal sealed class EnumUInt32TypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036C8 RID: 14024 RVA: 0x000D3718 File Offset: 0x000D1918
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format32(format, TraceLoggingDataType.UInt32));
		}

		// Token: 0x060036C9 RID: 14025 RVA: 0x000D3728 File Offset: 0x000D1928
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<uint>.Cast<EnumType>(value));
		}

		// Token: 0x060036CA RID: 14026 RVA: 0x000D373B File Offset: 0x000D193B
		public override object GetData(object value)
		{
			return value;
		}
	}
}
