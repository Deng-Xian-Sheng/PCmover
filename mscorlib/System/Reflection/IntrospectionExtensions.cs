using System;

namespace System.Reflection
{
	// Token: 0x020005EB RID: 1515
	[__DynamicallyInvokable]
	public static class IntrospectionExtensions
	{
		// Token: 0x0600464D RID: 17997 RVA: 0x00102444 File Offset: 0x00100644
		[__DynamicallyInvokable]
		public static TypeInfo GetTypeInfo(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			IReflectableType reflectableType = (IReflectableType)type;
			if (reflectableType == null)
			{
				return null;
			}
			return reflectableType.GetTypeInfo();
		}
	}
}
