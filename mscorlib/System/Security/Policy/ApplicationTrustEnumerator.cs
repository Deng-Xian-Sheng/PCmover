using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x02000347 RID: 839
	[ComVisible(true)]
	public sealed class ApplicationTrustEnumerator : IEnumerator
	{
		// Token: 0x060029BC RID: 10684 RVA: 0x0009A509 File Offset: 0x00098709
		private ApplicationTrustEnumerator()
		{
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x0009A511 File Offset: 0x00098711
		[SecurityCritical]
		internal ApplicationTrustEnumerator(ApplicationTrustCollection trusts)
		{
			this.m_trusts = trusts;
			this.m_current = -1;
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x060029BE RID: 10686 RVA: 0x0009A527 File Offset: 0x00098727
		public ApplicationTrust Current
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_trusts[this.m_current];
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x060029BF RID: 10687 RVA: 0x0009A53A File Offset: 0x0009873A
		object IEnumerator.Current
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_trusts[this.m_current];
			}
		}

		// Token: 0x060029C0 RID: 10688 RVA: 0x0009A54D File Offset: 0x0009874D
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			if (this.m_current == this.m_trusts.Count - 1)
			{
				return false;
			}
			this.m_current++;
			return true;
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x0009A575 File Offset: 0x00098775
		public void Reset()
		{
			this.m_current = -1;
		}

		// Token: 0x0400111C RID: 4380
		[SecurityCritical]
		private ApplicationTrustCollection m_trusts;

		// Token: 0x0400111D RID: 4381
		private int m_current;
	}
}
