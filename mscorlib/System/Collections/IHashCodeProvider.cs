using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x020004A0 RID: 1184
	[Obsolete("Please use IEqualityComparer instead.")]
	[ComVisible(true)]
	public interface IHashCodeProvider
	{
		// Token: 0x060038BB RID: 14523
		int GetHashCode(object obj);
	}
}
