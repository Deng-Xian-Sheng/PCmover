using System;
using System.Reflection;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200044C RID: 1100
	internal class NonGenericProperytWriter<ContainerType> : PropertyAccessor<ContainerType>
	{
		// Token: 0x0600364F RID: 13903 RVA: 0x000D2F6B File Offset: 0x000D116B
		public NonGenericProperytWriter(PropertyAnalysis property)
		{
			this.getterInfo = property.getterInfo;
			this.typeInfo = property.typeInfo;
		}

		// Token: 0x06003650 RID: 13904 RVA: 0x000D2F8C File Offset: 0x000D118C
		public override void Write(TraceLoggingDataCollector collector, ref ContainerType container)
		{
			object value = (container == null) ? null : this.getterInfo.Invoke(container, null);
			this.typeInfo.WriteObjectData(collector, value);
		}

		// Token: 0x06003651 RID: 13905 RVA: 0x000D2FCE File Offset: 0x000D11CE
		public override object GetData(ContainerType container)
		{
			if (container != null)
			{
				return this.getterInfo.Invoke(container, null);
			}
			return null;
		}

		// Token: 0x04001849 RID: 6217
		private readonly TraceLoggingTypeInfo typeInfo;

		// Token: 0x0400184A RID: 6218
		private readonly MethodInfo getterInfo;
	}
}
