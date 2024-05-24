using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000335 RID: 821
	[ComVisible(false)]
	internal class IdentityReferenceEnumerator : IEnumerator<IdentityReference>, IDisposable, IEnumerator
	{
		// Token: 0x0600290B RID: 10507 RVA: 0x000974C0 File Offset: 0x000956C0
		internal IdentityReferenceEnumerator(IdentityReferenceCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			this._Collection = collection;
			this._Current = -1;
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x0600290C RID: 10508 RVA: 0x000974E4 File Offset: 0x000956E4
		object IEnumerator.Current
		{
			get
			{
				return this._Collection.Identities[this._Current];
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x0600290D RID: 10509 RVA: 0x000974FC File Offset: 0x000956FC
		public IdentityReference Current
		{
			get
			{
				return ((IEnumerator)this).Current as IdentityReference;
			}
		}

		// Token: 0x0600290E RID: 10510 RVA: 0x00097509 File Offset: 0x00095709
		public bool MoveNext()
		{
			this._Current++;
			return this._Current < this._Collection.Count;
		}

		// Token: 0x0600290F RID: 10511 RVA: 0x0009752C File Offset: 0x0009572C
		public void Reset()
		{
			this._Current = -1;
		}

		// Token: 0x06002910 RID: 10512 RVA: 0x00097535 File Offset: 0x00095735
		public void Dispose()
		{
		}

		// Token: 0x0400108A RID: 4234
		private int _Current;

		// Token: 0x0400108B RID: 4235
		private readonly IdentityReferenceCollection _Collection;
	}
}
