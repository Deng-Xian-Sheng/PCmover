using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000475 RID: 1141
	internal sealed class EnumUInt64TypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036D0 RID: 14032 RVA: 0x000D3775 File Offset: 0x000D1975
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format64(format, TraceLoggingDataType.UInt64));
		}

		// Token: 0x060036D1 RID: 14033 RVA: 0x000D3786 File Offset: 0x000D1986
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<ulong>.Cast<EnumType>(value));
		}

		// Token: 0x060036D2 RID: 14034 RVA: 0x000D3799 File Offset: 0x000D1999
		public override object GetData(object value)
		{
			return value;
		}
	}
}
