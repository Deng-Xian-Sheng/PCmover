using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000476 RID: 1142
	internal sealed class StringTypeInfo : TraceLoggingTypeInfo<string>
	{
		// Token: 0x060036D4 RID: 14036 RVA: 0x000D37A4 File Offset: 0x000D19A4
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddBinary(name, Statics.MakeDataType(TraceLoggingDataType.CountedUtf16String, format));
		}

		// Token: 0x060036D5 RID: 14037 RVA: 0x000D37B5 File Offset: 0x000D19B5
		public override void WriteData(TraceLoggingDataCollector collector, ref string value)
		{
			collector.AddBinary(value);
		}

		// Token: 0x060036D6 RID: 14038 RVA: 0x000D37C0 File Offset: 0x000D19C0
		public override object GetData(object value)
		{
			object obj = base.GetData(value);
			if (obj == null)
			{
				obj = "";
			}
			return obj;
		}
	}
}
