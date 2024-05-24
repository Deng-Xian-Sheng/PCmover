using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000685 RID: 1669
	internal class StoreAssemblyEnumeration : IEnumerator
	{
		// Token: 0x06004F48 RID: 20296 RVA: 0x0011C418 File Offset: 0x0011A618
		public StoreAssemblyEnumeration(IEnumSTORE_ASSEMBLY pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F49 RID: 20297 RVA: 0x0011C427 File Offset: 0x0011A627
		private STORE_ASSEMBLY GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000CA1 RID: 3233
		// (get) Token: 0x06004F4A RID: 20298 RVA: 0x0011C43D File Offset: 0x0011A63D
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000CA2 RID: 3234
		// (get) Token: 0x06004F4B RID: 20299 RVA: 0x0011C44A File Offset: 0x0011A64A
		public STORE_ASSEMBLY Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F4C RID: 20300 RVA: 0x0011C452 File Offset: 0x0011A652
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F4D RID: 20301 RVA: 0x0011C458 File Offset: 0x0011A658
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			STORE_ASSEMBLY[] array = new STORE_ASSEMBLY[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F4E RID: 20302 RVA: 0x0011C498 File Offset: 0x0011A698
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x040021FA RID: 8698
		private IEnumSTORE_ASSEMBLY _enum;

		// Token: 0x040021FB RID: 8699
		private bool _fValid;

		// Token: 0x040021FC RID: 8700
		private STORE_ASSEMBLY _current;
	}
}
