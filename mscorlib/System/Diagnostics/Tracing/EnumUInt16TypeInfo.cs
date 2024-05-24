using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000471 RID: 1137
	internal sealed class EnumUInt16TypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036C0 RID: 14016 RVA: 0x000D36BC File Offset: 0x000D18BC
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format16(format, TraceLoggingDataType.UInt16));
		}

		// Token: 0x060036C1 RID: 14017 RVA: 0x000D36CC File Offset: 0x000D18CC
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<ushort>.Cast<EnumType>(value));
		}

		// Token: 0x060036C2 RID: 14018 RVA: 0x000D36DF File Offset: 0x000D18DF
		public override object GetData(object value)
		{
			return value;
		}
	}
}
