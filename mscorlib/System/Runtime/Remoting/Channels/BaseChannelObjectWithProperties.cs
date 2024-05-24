using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000850 RID: 2128
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public abstract class BaseChannelObjectWithProperties : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x17000F05 RID: 3845
		// (get) Token: 0x06005A37 RID: 23095 RVA: 0x0013D781 File Offset: 0x0013B981
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				return this;
			}
		}

		// Token: 0x17000F06 RID: 3846
		public virtual object this[object key]
		{
			[SecuritySafeCritical]
			get
			{
				return null;
			}
			[SecuritySafeCritical]
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000F07 RID: 3847
		// (get) Token: 0x06005A3A RID: 23098 RVA: 0x0013D78E File Offset: 0x0013B98E
		public virtual ICollection Keys
		{
			[SecuritySafeCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000F08 RID: 3848
		// (get) Token: 0x06005A3B RID: 23099 RVA: 0x0013D794 File Offset: 0x0013B994
		public virtual ICollection Values
		{
			[SecuritySafeCritical]
			get
			{
				ICollection keys = this.Keys;
				if (keys == null)
				{
					return null;
				}
				ArrayList arrayList = new ArrayList();
				foreach (object key in keys)
				{
					arrayList.Add(this[key]);
				}
				return arrayList;
			}
		}

		// Token: 0x06005A3C RID: 23100 RVA: 0x0013D800 File Offset: 0x0013BA00
		[SecuritySafeCritical]
		public virtual bool Contains(object key)
		{
			if (key == null)
			{
				return false;
			}
			ICollection keys = this.Keys;
			if (keys == null)
			{
				return false;
			}
			string text = key as string;
			foreach (object obj in keys)
			{
				if (text != null)
				{
					string text2 = obj as string;
					if (text2 != null)
					{
						if (string.Compare(text, text2, StringComparison.OrdinalIgnoreCase) == 0)
						{
							return true;
						}
						continue;
					}
				}
				if (key.Equals(obj))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000F09 RID: 3849
		// (get) Token: 0x06005A3D RID: 23101 RVA: 0x0013D894 File Offset: 0x0013BA94
		public virtual bool IsReadOnly
		{
			[SecuritySafeCritical]
			get
			{
				return false;
			}
		}

		// Token: 0x17000F0A RID: 3850
		// (get) Token: 0x06005A3E RID: 23102 RVA: 0x0013D897 File Offset: 0x0013BA97
		public virtual bool IsFixedSize
		{
			[SecuritySafeCritical]
			get
			{
				return true;
			}
		}

		// Token: 0x06005A3F RID: 23103 RVA: 0x0013D89A File Offset: 0x0013BA9A
		[SecuritySafeCritical]
		public virtual void Add(object key, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A40 RID: 23104 RVA: 0x0013D8A1 File Offset: 0x0013BAA1
		[SecuritySafeCritical]
		public virtual void Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A41 RID: 23105 RVA: 0x0013D8A8 File Offset: 0x0013BAA8
		[SecuritySafeCritical]
		public virtual void Remove(object key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A42 RID: 23106 RVA: 0x0013D8AF File Offset: 0x0013BAAF
		[SecuritySafeCritical]
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return new DictionaryEnumeratorByKeys(this);
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x0013D8B7 File Offset: 0x0013BAB7
		[SecuritySafeCritical]
		public virtual void CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000F0B RID: 3851
		// (get) Token: 0x06005A44 RID: 23108 RVA: 0x0013D8C0 File Offset: 0x0013BAC0
		public virtual int Count
		{
			[SecuritySafeCritical]
			get
			{
				ICollection keys = this.Keys;
				if (keys == null)
				{
					return 0;
				}
				return keys.Count;
			}
		}

		// Token: 0x17000F0C RID: 3852
		// (get) Token: 0x06005A45 RID: 23109 RVA: 0x0013D8DF File Offset: 0x0013BADF
		public virtual object SyncRoot
		{
			[SecuritySafeCritical]
			get
			{
				return this;
			}
		}

		// Token: 0x17000F0D RID: 3853
		// (get) Token: 0x06005A46 RID: 23110 RVA: 0x0013D8E2 File Offset: 0x0013BAE2
		public virtual bool IsSynchronized
		{
			[SecuritySafeCritical]
			get
			{
				return false;
			}
		}

		// Token: 0x06005A47 RID: 23111 RVA: 0x0013D8E5 File Offset: 0x0013BAE5
		[SecuritySafeCritical]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DictionaryEnumeratorByKeys(this);
		}
	}
}
