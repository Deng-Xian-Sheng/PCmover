using System;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000809 RID: 2057
	[Serializable]
	internal class CallBackHelper
	{
		// Token: 0x17000EB4 RID: 3764
		// (get) Token: 0x060058B1 RID: 22705 RVA: 0x00138CD9 File Offset: 0x00136ED9
		// (set) Token: 0x060058B2 RID: 22706 RVA: 0x00138CE6 File Offset: 0x00136EE6
		internal bool IsEERequested
		{
			get
			{
				return (this._flags & 1) == 1;
			}
			set
			{
				if (value)
				{
					this._flags |= 1;
				}
			}
		}

		// Token: 0x17000EB5 RID: 3765
		// (set) Token: 0x060058B3 RID: 22707 RVA: 0x00138CF9 File Offset: 0x00136EF9
		internal bool IsCrossDomain
		{
			set
			{
				if (value)
				{
					this._flags |= 256;
				}
			}
		}

		// Token: 0x060058B4 RID: 22708 RVA: 0x00138D10 File Offset: 0x00136F10
		internal CallBackHelper(IntPtr privateData, bool bFromEE, int targetDomainID)
		{
			this.IsEERequested = bFromEE;
			this.IsCrossDomain = (targetDomainID != 0);
			this._privateData = privateData;
		}

		// Token: 0x060058B5 RID: 22709 RVA: 0x00138D30 File Offset: 0x00136F30
		[SecurityCritical]
		internal void Func()
		{
			if (this.IsEERequested)
			{
				Context.ExecuteCallBackInEE(this._privateData);
			}
		}

		// Token: 0x04002867 RID: 10343
		internal const int RequestedFromEE = 1;

		// Token: 0x04002868 RID: 10344
		internal const int XDomainTransition = 256;

		// Token: 0x04002869 RID: 10345
		private int _flags;

		// Token: 0x0400286A RID: 10346
		private IntPtr _privateData;
	}
}
