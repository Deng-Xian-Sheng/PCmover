using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000439 RID: 1081
	internal sealed class ArrayTypeInfo<ElementType> : TraceLoggingTypeInfo<ElementType[]>
	{
		// Token: 0x060035D4 RID: 13780 RVA: 0x000D1B4F File Offset: 0x000CFD4F
		public ArrayTypeInfo(TraceLoggingTypeInfo<ElementType> elementInfo)
		{
			this.elementInfo = elementInfo;
		}

		// Token: 0x060035D5 RID: 13781 RVA: 0x000D1B5E File Offset: 0x000CFD5E
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.BeginBufferedArray();
			this.elementInfo.WriteMetadata(collector, name, format);
			collector.EndBufferedArray();
		}

		// Token: 0x060035D6 RID: 13782 RVA: 0x000D1B7C File Offset: 0x000CFD7C
		public override void WriteData(TraceLoggingDataCollector collector, ref ElementType[] value)
		{
			int bookmark = collector.BeginBufferedArray();
			int count = 0;
			if (value != null)
			{
				count = value.Length;
				for (int i = 0; i < value.Length; i++)
				{
					this.elementInfo.WriteData(collector, ref value[i]);
				}
			}
			collector.EndBufferedArray(bookmark, count);
		}

		// Token: 0x060035D7 RID: 13783 RVA: 0x000D1BC8 File Offset: 0x000CFDC8
		public override object GetData(object value)
		{
			ElementType[] array = (ElementType[])value;
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = this.elementInfo.GetData(array[i]);
			}
			return array2;
		}

		// Token: 0x04001806 RID: 6150
		private readonly TraceLoggingTypeInfo<ElementType> elementInfo;
	}
}
