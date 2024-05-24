using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000470 RID: 1136
	internal sealed class EnumInt16TypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036BC RID: 14012 RVA: 0x000D368E File Offset: 0x000D188E
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format16(format, TraceLoggingDataType.Int16));
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x000D369E File Offset: 0x000D189E
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<short>.Cast<EnumType>(value));
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x000D36B1 File Offset: 0x000D18B1
		public override object GetData(object value)
		{
			return value;
		}
	}
}
