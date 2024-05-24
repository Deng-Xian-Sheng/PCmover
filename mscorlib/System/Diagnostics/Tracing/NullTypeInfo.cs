using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000451 RID: 1105
	internal sealed class NullTypeInfo<DataType> : TraceLoggingTypeInfo<DataType>
	{
		// Token: 0x0600365C RID: 13916 RVA: 0x000D31D2 File Offset: 0x000D13D2
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.AddGroup(name);
		}

		// Token: 0x0600365D RID: 13917 RVA: 0x000D31DC File Offset: 0x000D13DC
		public override void WriteData(TraceLoggingDataCollector collector, ref DataType value)
		{
		}

		// Token: 0x0600365E RID: 13918 RVA: 0x000D31DE File Offset: 0x000D13DE
		public override object GetData(object value)
		{
			return null;
		}
	}
}
