using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005E9 RID: 1513
	[ComVisible(true)]
	public interface ICustomAttributeProvider
	{
		// Token: 0x06004649 RID: 17993
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x0600464A RID: 17994
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x0600464B RID: 17995
		bool IsDefined(Type attributeType, bool inherit);
	}
}
