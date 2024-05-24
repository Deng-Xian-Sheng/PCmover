using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200046F RID: 1135
	internal sealed class EnumSByteTypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036B8 RID: 14008 RVA: 0x000D3660 File Offset: 0x000D1860
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format8(format, TraceLoggingDataType.Int8));
		}

		// Token: 0x060036B9 RID: 14009 RVA: 0x000D3670 File Offset: 0x000D1870
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<sbyte>.Cast<EnumType>(value));
		}

		// Token: 0x060036BA RID: 14010 RVA: 0x000D3683 File Offset: 0x000D1883
		public override object GetData(object value)
		{
			return value;
		}
	}
}
