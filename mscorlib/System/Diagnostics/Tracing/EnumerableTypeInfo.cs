using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200043E RID: 1086
	internal sealed class EnumerableTypeInfo<IterableType, ElementType> : TraceLoggingTypeInfo<IterableType> where IterableType : IEnumerable<ElementType>
	{
		// Token: 0x060035EE RID: 13806 RVA: 0x000D21B1 File Offset: 0x000D03B1
		public EnumerableTypeInfo(TraceLoggingTypeInfo<ElementType> elementInfo)
		{
			this.elementInfo = elementInfo;
		}

		// Token: 0x060035EF RID: 13807 RVA: 0x000D21C0 File Offset: 0x000D03C0
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			collector.BeginBufferedArray();
			this.elementInfo.WriteMetadata(collector, name, format);
			collector.EndBufferedArray();
		}

		// Token: 0x060035F0 RID: 13808 RVA: 0x000D21DC File Offset: 0x000D03DC
		public override void WriteData(TraceLoggingDataCollector collector, ref IterableType value)
		{
			int bookmark = collector.BeginBufferedArray();
			int num = 0;
			if (value != null)
			{
				foreach (ElementType elementType in value)
				{
					ElementType elementType2 = elementType;
					this.elementInfo.WriteData(collector, ref elementType2);
					num++;
				}
			}
			collector.EndBufferedArray(bookmark, num);
		}

		// Token: 0x060035F1 RID: 13809 RVA: 0x000D2258 File Offset: 0x000D0458
		public override object GetData(object value)
		{
			IterableType iterableType = (IterableType)((object)value);
			List<object> list = new List<object>();
			foreach (ElementType elementType in iterableType)
			{
				list.Add(this.elementInfo.GetData(elementType));
			}
			return list.ToArray();
		}

		// Token: 0x04001814 RID: 6164
		private readonly TraceLoggingTypeInfo<ElementType> elementInfo;
	}
}
