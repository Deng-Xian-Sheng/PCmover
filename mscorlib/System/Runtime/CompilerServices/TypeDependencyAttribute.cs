using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008C5 RID: 2245
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
	internal sealed class TypeDependencyAttribute : Attribute
	{
		// Token: 0x06005DBC RID: 23996 RVA: 0x001497E4 File Offset: 0x001479E4
		public TypeDependencyAttribute(string typeName)
		{
			if (typeName == null)
			{
				throw new ArgumentNullException("typeName");
			}
			this.typeName = typeName;
		}

		// Token: 0x04002A2C RID: 10796
		private string typeName;
	}
}
