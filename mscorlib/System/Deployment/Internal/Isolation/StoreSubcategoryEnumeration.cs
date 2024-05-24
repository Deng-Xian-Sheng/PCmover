using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200068B RID: 1675
	internal class StoreSubcategoryEnumeration : IEnumerator
	{
		// Token: 0x06004F69 RID: 20329 RVA: 0x0011C5D4 File Offset: 0x0011A7D4
		public StoreSubcategoryEnumeration(IEnumSTORE_CATEGORY_SUBCATEGORY pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F6A RID: 20330 RVA: 0x0011C5E3 File Offset: 0x0011A7E3
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F6B RID: 20331 RVA: 0x0011C5E6 File Offset: 0x0011A7E6
		private STORE_CATEGORY_SUBCATEGORY GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000CA7 RID: 3239
		// (get) Token: 0x06004F6C RID: 20332 RVA: 0x0011C5FC File Offset: 0x0011A7FC
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000CA8 RID: 3240
		// (get) Token: 0x06004F6D RID: 20333 RVA: 0x0011C609 File Offset: 0x0011A809
		public STORE_CATEGORY_SUBCATEGORY Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F6E RID: 20334 RVA: 0x0011C614 File Offset: 0x0011A814
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			STORE_CATEGORY_SUBCATEGORY[] array = new STORE_CATEGORY_SUBCATEGORY[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F6F RID: 20335 RVA: 0x0011C654 File Offset: 0x0011A854
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x04002203 RID: 8707
		private IEnumSTORE_CATEGORY_SUBCATEGORY _enum;

		// Token: 0x04002204 RID: 8708
		private bool _fValid;

		// Token: 0x04002205 RID: 8709
		private STORE_CATEGORY_SUBCATEGORY _current;
	}
}
