using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Security.Principal
{
	// Token: 0x02000334 RID: 820
	[ComVisible(false)]
	public class IdentityReferenceCollection : ICollection<IdentityReference>, IEnumerable<IdentityReference>, IEnumerable
	{
		// Token: 0x060028FB RID: 10491 RVA: 0x0009703C File Offset: 0x0009523C
		public IdentityReferenceCollection() : this(0)
		{
		}

		// Token: 0x060028FC RID: 10492 RVA: 0x00097045 File Offset: 0x00095245
		public IdentityReferenceCollection(int capacity)
		{
			this._Identities = new List<IdentityReference>(capacity);
		}

		// Token: 0x060028FD RID: 10493 RVA: 0x00097059 File Offset: 0x00095259
		public void CopyTo(IdentityReference[] array, int offset)
		{
			this._Identities.CopyTo(0, array, offset, this.Count);
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x060028FE RID: 10494 RVA: 0x0009706F File Offset: 0x0009526F
		public int Count
		{
			get
			{
				return this._Identities.Count;
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x060028FF RID: 10495 RVA: 0x0009707C File Offset: 0x0009527C
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06002900 RID: 10496 RVA: 0x0009707F File Offset: 0x0009527F
		public void Add(IdentityReference identity)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			this._Identities.Add(identity);
		}

		// Token: 0x06002901 RID: 10497 RVA: 0x000970A1 File Offset: 0x000952A1
		public bool Remove(IdentityReference identity)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			if (this.Contains(identity))
			{
				this._Identities.Remove(identity);
				return true;
			}
			return false;
		}

		// Token: 0x06002902 RID: 10498 RVA: 0x000970D0 File Offset: 0x000952D0
		public void Clear()
		{
			this._Identities.Clear();
		}

		// Token: 0x06002903 RID: 10499 RVA: 0x000970DD File Offset: 0x000952DD
		public bool Contains(IdentityReference identity)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			return this._Identities.Contains(identity);
		}

		// Token: 0x06002904 RID: 10500 RVA: 0x000970FF File Offset: 0x000952FF
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06002905 RID: 10501 RVA: 0x00097107 File Offset: 0x00095307
		public IEnumerator<IdentityReference> GetEnumerator()
		{
			return new IdentityReferenceEnumerator(this);
		}

		// Token: 0x17000558 RID: 1368
		public IdentityReference this[int index]
		{
			get
			{
				return this._Identities[index];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this._Identities[index] = value;
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06002908 RID: 10504 RVA: 0x00097140 File Offset: 0x00095340
		internal List<IdentityReference> Identities
		{
			get
			{
				return this._Identities;
			}
		}

		// Token: 0x06002909 RID: 10505 RVA: 0x00097148 File Offset: 0x00095348
		public IdentityReferenceCollection Translate(Type targetType)
		{
			return this.Translate(targetType, false);
		}

		// Token: 0x0600290A RID: 10506 RVA: 0x00097154 File Offset: 0x00095354
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlPrincipal = true)]
		public IdentityReferenceCollection Translate(Type targetType, bool forceSuccess)
		{
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			if (!targetType.IsSubclassOf(typeof(IdentityReference)))
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_MustBeIdentityReference"), "targetType");
			}
			if (this.Identities.Count == 0)
			{
				return new IdentityReferenceCollection();
			}
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.Identities.Count; i++)
			{
				Type type = this.Identities[i].GetType();
				if (!(type == targetType))
				{
					if (type == typeof(SecurityIdentifier))
					{
						num++;
					}
					else
					{
						if (!(type == typeof(NTAccount)))
						{
							throw new SystemException();
						}
						num2++;
					}
				}
			}
			bool flag = false;
			IdentityReferenceCollection identityReferenceCollection = null;
			IdentityReferenceCollection identityReferenceCollection2 = null;
			if (num == this.Count)
			{
				flag = true;
				identityReferenceCollection = this;
			}
			else if (num > 0)
			{
				identityReferenceCollection = new IdentityReferenceCollection(num);
			}
			if (num2 == this.Count)
			{
				flag = true;
				identityReferenceCollection2 = this;
			}
			else if (num2 > 0)
			{
				identityReferenceCollection2 = new IdentityReferenceCollection(num2);
			}
			IdentityReferenceCollection identityReferenceCollection3 = null;
			if (!flag)
			{
				identityReferenceCollection3 = new IdentityReferenceCollection(this.Identities.Count);
				for (int j = 0; j < this.Identities.Count; j++)
				{
					IdentityReference identityReference = this[j];
					Type type2 = identityReference.GetType();
					if (!(type2 == targetType))
					{
						if (type2 == typeof(SecurityIdentifier))
						{
							identityReferenceCollection.Add(identityReference);
						}
						else
						{
							if (!(type2 == typeof(NTAccount)))
							{
								throw new SystemException();
							}
							identityReferenceCollection2.Add(identityReference);
						}
					}
				}
			}
			bool flag2 = false;
			IdentityReferenceCollection identityReferenceCollection4 = null;
			IdentityReferenceCollection identityReferenceCollection5 = null;
			if (num > 0)
			{
				identityReferenceCollection4 = SecurityIdentifier.Translate(identityReferenceCollection, targetType, out flag2);
				if (flag && (!forceSuccess || !flag2))
				{
					identityReferenceCollection3 = identityReferenceCollection4;
				}
			}
			if (num2 > 0)
			{
				identityReferenceCollection5 = NTAccount.Translate(identityReferenceCollection2, targetType, out flag2);
				if (flag && (!forceSuccess || !flag2))
				{
					identityReferenceCollection3 = identityReferenceCollection5;
				}
			}
			if (forceSuccess && flag2)
			{
				identityReferenceCollection3 = new IdentityReferenceCollection();
				if (identityReferenceCollection4 != null)
				{
					foreach (IdentityReference identityReference2 in identityReferenceCollection4)
					{
						if (identityReference2.GetType() != targetType)
						{
							identityReferenceCollection3.Add(identityReference2);
						}
					}
				}
				if (identityReferenceCollection5 != null)
				{
					foreach (IdentityReference identityReference3 in identityReferenceCollection5)
					{
						if (identityReference3.GetType() != targetType)
						{
							identityReferenceCollection3.Add(identityReference3);
						}
					}
				}
				throw new IdentityNotMappedException(Environment.GetResourceString("IdentityReference_IdentityNotMapped"), identityReferenceCollection3);
			}
			if (!flag)
			{
				num = 0;
				num2 = 0;
				identityReferenceCollection3 = new IdentityReferenceCollection(this.Identities.Count);
				for (int k = 0; k < this.Identities.Count; k++)
				{
					IdentityReference identityReference4 = this[k];
					Type type3 = identityReference4.GetType();
					if (type3 == targetType)
					{
						identityReferenceCollection3.Add(identityReference4);
					}
					else if (type3 == typeof(SecurityIdentifier))
					{
						identityReferenceCollection3.Add(identityReferenceCollection4[num++]);
					}
					else
					{
						if (!(type3 == typeof(NTAccount)))
						{
							throw new SystemException();
						}
						identityReferenceCollection3.Add(identityReferenceCollection5[num2++]);
					}
				}
			}
			return identityReferenceCollection3;
		}

		// Token: 0x04001089 RID: 4233
		private List<IdentityReference> _Identities;
	}
}
