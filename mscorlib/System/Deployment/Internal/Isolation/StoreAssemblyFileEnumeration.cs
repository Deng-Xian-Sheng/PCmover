using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000687 RID: 1671
	internal class StoreAssemblyFileEnumeration : IEnumerator
	{
		// Token: 0x06004F53 RID: 20307 RVA: 0x0011C4AC File Offset: 0x0011A6AC
		public StoreAssemblyFileEnumeration(IEnumSTORE_ASSEMBLY_FILE pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F54 RID: 20308 RVA: 0x0011C4BB File Offset: 0x0011A6BB
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F55 RID: 20309 RVA: 0x0011C4BE File Offset: 0x0011A6BE
		private STORE_ASSEMBLY_FILE GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000CA3 RID: 3235
		// (get) Token: 0x06004F56 RID: 20310 RVA: 0x0011C4D4 File Offset: 0x0011A6D4
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000CA4 RID: 3236
		// (get) Token: 0x06004F57 RID: 20311 RVA: 0x0011C4E1 File Offset: 0x0011A6E1
		public STORE_ASSEMBLY_FILE Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F58 RID: 20312 RVA: 0x0011C4EC File Offset: 0x0011A6EC
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			STORE_ASSEMBLY_FILE[] array = new STORE_ASSEMBLY_FILE[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F59 RID: 20313 RVA: 0x0011C52C File Offset: 0x0011A72C
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x040021FD RID: 8701
		private IEnumSTORE_ASSEMBLY_FILE _enum;

		// Token: 0x040021FE RID: 8702
		private bool _fValid;

		// Token: 0x040021FF RID: 8703
		private STORE_ASSEMBLY_FILE _current;
	}
}
