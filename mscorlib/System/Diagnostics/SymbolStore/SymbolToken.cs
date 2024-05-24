using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x02000408 RID: 1032
	[ComVisible(true)]
	public struct SymbolToken
	{
		// Token: 0x060033E1 RID: 13281 RVA: 0x000C6630 File Offset: 0x000C4830
		public SymbolToken(int val)
		{
			this.m_token = val;
		}

		// Token: 0x060033E2 RID: 13282 RVA: 0x000C6639 File Offset: 0x000C4839
		public int GetToken()
		{
			return this.m_token;
		}

		// Token: 0x060033E3 RID: 13283 RVA: 0x000C6641 File Offset: 0x000C4841
		public override int GetHashCode()
		{
			return this.m_token;
		}

		// Token: 0x060033E4 RID: 13284 RVA: 0x000C6649 File Offset: 0x000C4849
		public override bool Equals(object obj)
		{
			return obj is SymbolToken && this.Equals((SymbolToken)obj);
		}

		// Token: 0x060033E5 RID: 13285 RVA: 0x000C6661 File Offset: 0x000C4861
		public bool Equals(SymbolToken obj)
		{
			return obj.m_token == this.m_token;
		}

		// Token: 0x060033E6 RID: 13286 RVA: 0x000C6671 File Offset: 0x000C4871
		public static bool operator ==(SymbolToken a, SymbolToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x060033E7 RID: 13287 RVA: 0x000C667B File Offset: 0x000C487B
		public static bool operator !=(SymbolToken a, SymbolToken b)
		{
			return !(a == b);
		}

		// Token: 0x040016FF RID: 5887
		internal int m_token;
	}
}
