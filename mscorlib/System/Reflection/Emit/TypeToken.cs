using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000666 RID: 1638
	[ComVisible(true)]
	[Serializable]
	public struct TypeToken
	{
		// Token: 0x06004EB0 RID: 20144 RVA: 0x0011BB6D File Offset: 0x00119D6D
		internal TypeToken(int str)
		{
			this.m_class = str;
		}

		// Token: 0x17000C6C RID: 3180
		// (get) Token: 0x06004EB1 RID: 20145 RVA: 0x0011BB76 File Offset: 0x00119D76
		public int Token
		{
			get
			{
				return this.m_class;
			}
		}

		// Token: 0x06004EB2 RID: 20146 RVA: 0x0011BB7E File Offset: 0x00119D7E
		public override int GetHashCode()
		{
			return this.m_class;
		}

		// Token: 0x06004EB3 RID: 20147 RVA: 0x0011BB86 File Offset: 0x00119D86
		public override bool Equals(object obj)
		{
			return obj is TypeToken && this.Equals((TypeToken)obj);
		}

		// Token: 0x06004EB4 RID: 20148 RVA: 0x0011BB9E File Offset: 0x00119D9E
		public bool Equals(TypeToken obj)
		{
			return obj.m_class == this.m_class;
		}

		// Token: 0x06004EB5 RID: 20149 RVA: 0x0011BBAE File Offset: 0x00119DAE
		public static bool operator ==(TypeToken a, TypeToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004EB6 RID: 20150 RVA: 0x0011BBB8 File Offset: 0x00119DB8
		public static bool operator !=(TypeToken a, TypeToken b)
		{
			return !(a == b);
		}

		// Token: 0x040021CC RID: 8652
		public static readonly TypeToken Empty;

		// Token: 0x040021CD RID: 8653
		internal int m_class;
	}
}
