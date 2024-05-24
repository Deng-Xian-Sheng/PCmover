using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009FE RID: 2558
	internal abstract class RuntimeClass : __ComObject
	{
		// Token: 0x060064EE RID: 25838
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr GetRedirectedGetHashCodeMD();

		// Token: 0x060064EF RID: 25839
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern int RedirectGetHashCode(IntPtr pMD);

		// Token: 0x060064F0 RID: 25840 RVA: 0x00157C34 File Offset: 0x00155E34
		[SecuritySafeCritical]
		public override int GetHashCode()
		{
			IntPtr redirectedGetHashCodeMD = this.GetRedirectedGetHashCodeMD();
			if (redirectedGetHashCodeMD == IntPtr.Zero)
			{
				return base.GetHashCode();
			}
			return this.RedirectGetHashCode(redirectedGetHashCodeMD);
		}

		// Token: 0x060064F1 RID: 25841
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr GetRedirectedToStringMD();

		// Token: 0x060064F2 RID: 25842
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern string RedirectToString(IntPtr pMD);

		// Token: 0x060064F3 RID: 25843 RVA: 0x00157C64 File Offset: 0x00155E64
		[SecuritySafeCritical]
		public override string ToString()
		{
			IStringable stringable = this as IStringable;
			if (stringable != null)
			{
				return stringable.ToString();
			}
			IntPtr redirectedToStringMD = this.GetRedirectedToStringMD();
			if (redirectedToStringMD == IntPtr.Zero)
			{
				return base.ToString();
			}
			return this.RedirectToString(redirectedToStringMD);
		}

		// Token: 0x060064F4 RID: 25844
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr GetRedirectedEqualsMD();

		// Token: 0x060064F5 RID: 25845
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern bool RedirectEquals(object obj, IntPtr pMD);

		// Token: 0x060064F6 RID: 25846 RVA: 0x00157CA4 File Offset: 0x00155EA4
		[SecuritySafeCritical]
		public override bool Equals(object obj)
		{
			IntPtr redirectedEqualsMD = this.GetRedirectedEqualsMD();
			if (redirectedEqualsMD == IntPtr.Zero)
			{
				return base.Equals(obj);
			}
			return this.RedirectEquals(obj, redirectedEqualsMD);
		}
	}
}
