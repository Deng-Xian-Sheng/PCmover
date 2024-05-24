using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200068D RID: 1677
	internal class StoreCategoryInstanceEnumeration : IEnumerator
	{
		// Token: 0x06004F74 RID: 20340 RVA: 0x0011C668 File Offset: 0x0011A868
		public StoreCategoryInstanceEnumeration(IEnumSTORE_CATEGORY_INSTANCE pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F75 RID: 20341 RVA: 0x0011C677 File Offset: 0x0011A877
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F76 RID: 20342 RVA: 0x0011C67A File Offset: 0x0011A87A
		private STORE_CATEGORY_INSTANCE GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000CA9 RID: 3241
		// (get) Token: 0x06004F77 RID: 20343 RVA: 0x0011C690 File Offset: 0x0011A890
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000CAA RID: 3242
		// (get) Token: 0x06004F78 RID: 20344 RVA: 0x0011C69D File Offset: 0x0011A89D
		public STORE_CATEGORY_INSTANCE Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F79 RID: 20345 RVA: 0x0011C6A8 File Offset: 0x0011A8A8
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			STORE_CATEGORY_INSTANCE[] array = new STORE_CATEGORY_INSTANCE[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F7A RID: 20346 RVA: 0x0011C6E8 File Offset: 0x0011A8E8
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x04002206 RID: 8710
		private IEnumSTORE_CATEGORY_INSTANCE _enum;

		// Token: 0x04002207 RID: 8711
		private bool _fValid;

		// Token: 0x04002208 RID: 8712
		private STORE_CATEGORY_INSTANCE _current;
	}
}
