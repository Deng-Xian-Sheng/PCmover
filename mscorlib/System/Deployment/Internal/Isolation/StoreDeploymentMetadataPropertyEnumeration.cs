using System;
using System.Collections;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000683 RID: 1667
	internal class StoreDeploymentMetadataPropertyEnumeration : IEnumerator
	{
		// Token: 0x06004F3D RID: 20285 RVA: 0x0011C384 File Offset: 0x0011A584
		public StoreDeploymentMetadataPropertyEnumeration(IEnumSTORE_DEPLOYMENT_METADATA_PROPERTY pI)
		{
			this._enum = pI;
		}

		// Token: 0x06004F3E RID: 20286 RVA: 0x0011C393 File Offset: 0x0011A593
		private StoreOperationMetadataProperty GetCurrent()
		{
			if (!this._fValid)
			{
				throw new InvalidOperationException();
			}
			return this._current;
		}

		// Token: 0x17000C9F RID: 3231
		// (get) Token: 0x06004F3F RID: 20287 RVA: 0x0011C3A9 File Offset: 0x0011A5A9
		object IEnumerator.Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x17000CA0 RID: 3232
		// (get) Token: 0x06004F40 RID: 20288 RVA: 0x0011C3B6 File Offset: 0x0011A5B6
		public StoreOperationMetadataProperty Current
		{
			get
			{
				return this.GetCurrent();
			}
		}

		// Token: 0x06004F41 RID: 20289 RVA: 0x0011C3BE File Offset: 0x0011A5BE
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004F42 RID: 20290 RVA: 0x0011C3C4 File Offset: 0x0011A5C4
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			StoreOperationMetadataProperty[] array = new StoreOperationMetadataProperty[1];
			uint num = this._enum.Next(1U, array);
			if (num == 1U)
			{
				this._current = array[0];
			}
			return this._fValid = (num == 1U);
		}

		// Token: 0x06004F43 RID: 20291 RVA: 0x0011C404 File Offset: 0x0011A604
		[SecuritySafeCritical]
		public void Reset()
		{
			this._fValid = false;
			this._enum.Reset();
		}

		// Token: 0x040021F7 RID: 8695
		private IEnumSTORE_DEPLOYMENT_METADATA_PROPERTY _enum;

		// Token: 0x040021F8 RID: 8696
		private bool _fValid;

		// Token: 0x040021F9 RID: 8697
		private StoreOperationMetadataProperty _current;
	}
}
