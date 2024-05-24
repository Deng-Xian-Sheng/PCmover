using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200046E RID: 1134
	internal sealed class EnumByteTypeInfo<EnumType> : TraceLoggingTypeInfo<EnumType>
	{
		// Token: 0x060036B4 RID: 14004 RVA: 0x000D3632 File Offset: 0x000D1832
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddScalar(name, Statics.Format8(format, TraceLoggingDataType.UInt8));
		}

		// Token: 0x060036B5 RID: 14005 RVA: 0x000D3642 File Offset: 0x000D1842
		public override void WriteData(TraceLoggingDataCollector collector, ref EnumType value)
		{
			collector.AddScalar(EnumHelper<byte>.Cast<EnumType>(value));
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x000D3655 File Offset: 0x000D1855
		public override object GetData(object value)
		{
			return value;
		}
	}
}
