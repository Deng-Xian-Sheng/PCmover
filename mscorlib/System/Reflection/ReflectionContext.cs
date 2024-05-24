using System;

namespace System.Reflection
{
	// Token: 0x0200061C RID: 1564
	[__DynamicallyInvokable]
	public abstract class ReflectionContext
	{
		// Token: 0x06004898 RID: 18584 RVA: 0x00107422 File Offset: 0x00105622
		[__DynamicallyInvokable]
		protected ReflectionContext()
		{
		}

		// Token: 0x06004899 RID: 18585
		[__DynamicallyInvokable]
		public abstract Assembly MapAssembly(Assembly assembly);

		// Token: 0x0600489A RID: 18586
		[__DynamicallyInvokable]
		public abstract TypeInfo MapType(TypeInfo type);

		// Token: 0x0600489B RID: 18587 RVA: 0x0010742A File Offset: 0x0010562A
		[__DynamicallyInvokable]
		public virtual TypeInfo GetTypeForObject(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return this.MapType(value.GetType().GetTypeInfo());
		}
	}
}
