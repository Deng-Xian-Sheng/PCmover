using System;
using System.Collections.Generic;
using System.Threading;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000486 RID: 1158
	internal abstract class TraceLoggingTypeInfo<DataType> : TraceLoggingTypeInfo
	{
		// Token: 0x0600375C RID: 14172 RVA: 0x000D50F9 File Offset: 0x000D32F9
		protected TraceLoggingTypeInfo() : base(typeof(DataType))
		{
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x000D510B File Offset: 0x000D330B
		protected TraceLoggingTypeInfo(string name, EventLevel level, EventOpcode opcode, EventKeywords keywords, EventTags tags) : base(typeof(DataType), name, level, opcode, keywords, tags)
		{
		}

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x0600375E RID: 14174 RVA: 0x000D5124 File Offset: 0x000D3324
		public static TraceLoggingTypeInfo<DataType> Instance
		{
			get
			{
				return TraceLoggingTypeInfo<DataType>.instance ?? TraceLoggingTypeInfo<DataType>.InitInstance();
			}
		}

		// Token: 0x0600375F RID: 14175
		public abstract void WriteData(TraceLoggingDataCollector collector, ref DataType value);

		// Token: 0x06003760 RID: 14176 RVA: 0x000D5134 File Offset: 0x000D3334
		public override void WriteObjectData(TraceLoggingDataCollector collector, object value)
		{
			DataType dataType = (value == null) ? default(DataType) : ((DataType)((object)value));
			this.WriteData(collector, ref dataType);
		}

		// Token: 0x06003761 RID: 14177 RVA: 0x000D5160 File Offset: 0x000D3360
		internal static TraceLoggingTypeInfo<DataType> GetInstance(List<Type> recursionCheck)
		{
			if (TraceLoggingTypeInfo<DataType>.instance == null)
			{
				int count = recursionCheck.Count;
				TraceLoggingTypeInfo<DataType> value = Statics.CreateDefaultTypeInfo<DataType>(recursionCheck);
				Interlocked.CompareExchange<TraceLoggingTypeInfo<DataType>>(ref TraceLoggingTypeInfo<DataType>.instance, value, null);
				recursionCheck.RemoveRange(count, recursionCheck.Count - count);
			}
			return TraceLoggingTypeInfo<DataType>.instance;
		}

		// Token: 0x06003762 RID: 14178 RVA: 0x000D51A3 File Offset: 0x000D33A3
		private static TraceLoggingTypeInfo<DataType> InitInstance()
		{
			return TraceLoggingTypeInfo<DataType>.GetInstance(new List<Type>());
		}

		// Token: 0x040018A4 RID: 6308
		private static TraceLoggingTypeInfo<DataType> instance;
	}
}
