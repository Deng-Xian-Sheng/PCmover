using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000742 RID: 1858
	[ComVisible(true)]
	public sealed class SerializationInfoEnumerator : IEnumerator
	{
		// Token: 0x06005221 RID: 21025 RVA: 0x001209E5 File Offset: 0x0011EBE5
		internal SerializationInfoEnumerator(string[] members, object[] info, Type[] types, int numItems)
		{
			this.m_members = members;
			this.m_data = info;
			this.m_types = types;
			this.m_numItems = numItems - 1;
			this.m_currItem = -1;
			this.m_current = false;
		}

		// Token: 0x06005222 RID: 21026 RVA: 0x00120A1A File Offset: 0x0011EC1A
		public bool MoveNext()
		{
			if (this.m_currItem < this.m_numItems)
			{
				this.m_currItem++;
				this.m_current = true;
			}
			else
			{
				this.m_current = false;
			}
			return this.m_current;
		}

		// Token: 0x17000D8A RID: 3466
		// (get) Token: 0x06005223 RID: 21027 RVA: 0x00120A50 File Offset: 0x0011EC50
		object IEnumerator.Current
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return new SerializationEntry(this.m_members[this.m_currItem], this.m_data[this.m_currItem], this.m_types[this.m_currItem]);
			}
		}

		// Token: 0x17000D8B RID: 3467
		// (get) Token: 0x06005224 RID: 21028 RVA: 0x00120AA8 File Offset: 0x0011ECA8
		public SerializationEntry Current
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return new SerializationEntry(this.m_members[this.m_currItem], this.m_data[this.m_currItem], this.m_types[this.m_currItem]);
			}
		}

		// Token: 0x06005225 RID: 21029 RVA: 0x00120AF9 File Offset: 0x0011ECF9
		public void Reset()
		{
			this.m_currItem = -1;
			this.m_current = false;
		}

		// Token: 0x17000D8C RID: 3468
		// (get) Token: 0x06005226 RID: 21030 RVA: 0x00120B09 File Offset: 0x0011ED09
		public string Name
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return this.m_members[this.m_currItem];
			}
		}

		// Token: 0x17000D8D RID: 3469
		// (get) Token: 0x06005227 RID: 21031 RVA: 0x00120B30 File Offset: 0x0011ED30
		public object Value
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return this.m_data[this.m_currItem];
			}
		}

		// Token: 0x17000D8E RID: 3470
		// (get) Token: 0x06005228 RID: 21032 RVA: 0x00120B57 File Offset: 0x0011ED57
		public Type ObjectType
		{
			get
			{
				if (!this.m_current)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
				return this.m_types[this.m_currItem];
			}
		}

		// Token: 0x04002454 RID: 9300
		private string[] m_members;

		// Token: 0x04002455 RID: 9301
		private object[] m_data;

		// Token: 0x04002456 RID: 9302
		private Type[] m_types;

		// Token: 0x04002457 RID: 9303
		private int m_numItems;

		// Token: 0x04002458 RID: 9304
		private int m_currItem;

		// Token: 0x04002459 RID: 9305
		private bool m_current;
	}
}
