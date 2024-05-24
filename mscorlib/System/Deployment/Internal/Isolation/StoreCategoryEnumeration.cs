using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000689 RID: 1673
	internal class StoreCategoryEnumeration : IEnumerator
	{
		// Token: 0x06004F5E RID: 20318 RVA: 0x0011C540 File Offset: 0x0011A740
		public StoreCategoryEnumeration(IEnumSTORE_CATEGORY pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F5F RID: 20319 RVA: 0x0011C54F File Offset: 0x0011A74F
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F60 RID: 20320 RVA: 0x0011C552 File Offset: 0x0011A752
		private STORE_CATEGORY GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000CA5 RID: 3237
		// (get) Token: 0x06004F61 RID: 20321 RVA: 0x0011C568 File Offset: 0x0011A768
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000CA6 RID: 3238
		// (get) Token: 0x06004F62 RID: 20322 RVA: 0x0011C575 File Offset: 0x0011A775
		public STORE_CATEGORY Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F63 RID: 20323 RVA: 0x0011C580 File Offset: 0x0011A780
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			STORE_CATEGORY[] array = new STORE_CATEGORY[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F64 RID: 20324 RVA: 0x0011C5C0 File Offset: 0x0011A7C0
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x04002200 RID: 8704
		private IEnumSTORE_CATEGORY _enum;

		// Token: 0x04002201 RID: 8705
		private bool _fValid;

		// Token: 0x04002202 RID: 8706
		private STORE_CATEGORY _current;
	}
}
