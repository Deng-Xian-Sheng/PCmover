using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200065D RID: 1629
	[ComVisible(true)]
	[Serializable]
	public struct PropertyToken
	{
		// Token: 0x06004CED RID: 19693 RVA: 0x0011726C File Offset: 0x0011546C
		internal PropertyToken(int str)
		{
			this.m_property = str;
		}

		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x06004CEE RID: 19694 RVA: 0x00117275 File Offset: 0x00115475
		public int Token
		{
			get
			{
				return this.m_property;
			}
		}

		// Token: 0x06004CEF RID: 19695 RVA: 0x0011727D File Offset: 0x0011547D
		public override int GetHashCode()
		{
			return this.m_property;
		}

		// Token: 0x06004CF0 RID: 19696 RVA: 0x00117285 File Offset: 0x00115485
		public override bool Equals(object obj)
		{
			return obj is PropertyToken && this.Equals((PropertyToken)obj);
		}

		// Token: 0x06004CF1 RID: 19697 RVA: 0x0011729D File Offset: 0x0011549D
		public bool Equals(PropertyToken obj)
		{
			return obj.m_property == this.m_property;
		}

		// Token: 0x06004CF2 RID: 19698 RVA: 0x001172AD File Offset: 0x001154AD
		public static bool operator ==(PropertyToken a, PropertyToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004CF3 RID: 19699 RVA: 0x001172B7 File Offset: 0x001154B7
		public static bool operator !=(PropertyToken a, PropertyToken b)
		{
			return !(a == b);
		}

		// Token: 0x04002194 RID: 8596
		public static readonly PropertyToken Empty;

		// Token: 0x04002195 RID: 8597
		internal int m_property;
	}
}
