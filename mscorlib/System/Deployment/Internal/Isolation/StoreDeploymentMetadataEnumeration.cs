using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000681 RID: 1665
	internal class StoreDeploymentMetadataEnumeration : IEnumerator
	{
		// Token: 0x06004F32 RID: 20274 RVA: 0x0011C2F9 File Offset: 0x0011A4F9
		public StoreDeploymentMetadataEnumeration(IEnumSTORE_DEPLOYMENT_METADATA pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F33 RID: 20275 RVA: 0x0011C308 File Offset: 0x0011A508
		private IDefinitionAppId GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000C9D RID: 3229
		// (get) Token: 0x06004F34 RID: 20276 RVA: 0x0011C31E File Offset: 0x0011A51E
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000C9E RID: 3230
		// (get) Token: 0x06004F35 RID: 20277 RVA: 0x0011C326 File Offset: 0x0011A526
		public IDefinitionAppId Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F36 RID: 20278 RVA: 0x0011C32E File Offset: 0x0011A52E
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F37 RID: 20279 RVA: 0x0011C334 File Offset: 0x0011A534
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			IDefinitionAppId[] array = new IDefinitionAppId[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F38 RID: 20280 RVA: 0x0011C370 File Offset: 0x0011A570
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x040021F4 RID: 8692
		private IEnumSTORE_DEPLOYMENT_METADATA _enum;

		// Token: 0x040021F5 RID: 8693
		private bool _fValid;

		// Token: 0x040021F6 RID: 8694
		private IDefinitionAppId _current;
	}
}
