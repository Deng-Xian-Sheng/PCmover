using System;
using System.Reflection;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200044F RID: 1103
	internal sealed class PropertyAnalysis
	{
		// Token: 0x06003658 RID: 13912 RVA: 0x000D314D File Offset: 0x000D134D
		public PropertyAnalysis(string name, MethodInfo getterInfo, TraceLoggingTypeInfo typeInfo, EventFieldAttribute fieldAttribute)
		{
			this.name = name;
			this.getterInfo = getterInfo;
			this.typeInfo = typeInfo;
			this.fieldAttribute = fieldAttribute;
		}

		// Token: 0x0400184F RID: 6223
		internal readonly string name;

		// Token: 0x04001850 RID: 6224
		internal readonly MethodInfo getterInfo;

		// Token: 0x04001851 RID: 6225
		internal readonly TraceLoggingTypeInfo typeInfo;

		// Token: 0x04001852 RID: 6226
		internal readonly EventFieldAttribute fieldAttribute;
	}
}
