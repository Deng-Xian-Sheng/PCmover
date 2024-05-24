using System;
using System.Threading;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000450 RID: 1104
	internal class SimpleEventTypes<T> : TraceLoggingEventTypes
	{
		// Token: 0x06003659 RID: 13913 RVA: 0x000D3172 File Offset: 0x000D1372
		private SimpleEventTypes(TraceLoggingTypeInfo<T> typeInfo) : base(typeInfo.Name, typeInfo.Tags, new TraceLoggingTypeInfo[]
		{
			typeInfo
		})
		{
			this.typeInfo = typeInfo;
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x0600365A RID: 13914 RVA: 0x000D3197 File Offset: 0x000D1397
		public static SimpleEventTypes<T> Instance
		{
			get
			{
				return SimpleEventTypes<T>.instance ?? SimpleEventTypes<T>.InitInstance();
			}
		}

		// Token: 0x0600365B RID: 13915 RVA: 0x000D31A8 File Offset: 0x000D13A8
		private static SimpleEventTypes<T> InitInstance()
		{
			SimpleEventTypes<T> value = new SimpleEventTypes<T>(TraceLoggingTypeInfo<T>.Instance);
			Interlocked.CompareExchange<SimpleEventTypes<T>>(ref SimpleEventTypes<T>.instance, value, null);
			return SimpleEventTypes<T>.instance;
		}

		// Token: 0x04001853 RID: 6227
		private static SimpleEventTypes<T> instance;

		// Token: 0x04001854 RID: 6228
		internal readonly TraceLoggingTypeInfo<T> typeInfo;
	}
}
