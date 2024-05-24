using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000660 RID: 1632
	[ComVisible(true)]
	[Serializable]
	public struct StringToken
	{
		// Token: 0x06004D35 RID: 19765 RVA: 0x00118500 File Offset: 0x00116700
		internal StringToken(int str)
		{
			this.m_string = str;
		}

		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x06004D36 RID: 19766 RVA: 0x00118509 File Offset: 0x00116709
		public int Token
		{
			get
			{
				return this.m_string;
			}
		}

		// Token: 0x06004D37 RID: 19767 RVA: 0x00118511 File Offset: 0x00116711
		public override int GetHashCode()
		{
			return this.m_string;
		}

		// Token: 0x06004D38 RID: 19768 RVA: 0x00118519 File Offset: 0x00116719
		public override bool Equals(object obj)
		{
			return obj is StringToken && this.Equals((StringToken)obj);
		}

		// Token: 0x06004D39 RID: 19769 RVA: 0x00118531 File Offset: 0x00116731
		public bool Equals(StringToken obj)
		{
			return obj.m_string == this.m_string;
		}

		// Token: 0x06004D3A RID: 19770 RVA: 0x00118541 File Offset: 0x00116741
		public static bool operator ==(StringToken a, StringToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004D3B RID: 19771 RVA: 0x0011854B File Offset: 0x0011674B
		public static bool operator !=(StringToken a, StringToken b)
		{
			return !(a == b);
		}

		// Token: 0x040021A0 RID: 8608
		internal int m_string;
	}
}
