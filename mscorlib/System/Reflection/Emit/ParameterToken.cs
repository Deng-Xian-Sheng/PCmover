using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200065B RID: 1627
	[ComVisible(true)]
	[Serializable]
	public struct ParameterToken
	{
		// Token: 0x06004CC3 RID: 19651 RVA: 0x00116E9C File Offset: 0x0011509C
		internal ParameterToken(int tkParam)
		{
			this.m_tkParameter = tkParam;
		}

		// Token: 0x17000C09 RID: 3081
		// (get) Token: 0x06004CC4 RID: 19652 RVA: 0x00116EA5 File Offset: 0x001150A5
		public int Token
		{
			get
			{
				return this.m_tkParameter;
			}
		}

		// Token: 0x06004CC5 RID: 19653 RVA: 0x00116EAD File Offset: 0x001150AD
		public override int GetHashCode()
		{
			return this.m_tkParameter;
		}

		// Token: 0x06004CC6 RID: 19654 RVA: 0x00116EB5 File Offset: 0x001150B5
		public override bool Equals(object obj)
		{
			return obj is ParameterToken && this.Equals((ParameterToken)obj);
		}

		// Token: 0x06004CC7 RID: 19655 RVA: 0x00116ECD File Offset: 0x001150CD
		public bool Equals(ParameterToken obj)
		{
			return obj.m_tkParameter == this.m_tkParameter;
		}

		// Token: 0x06004CC8 RID: 19656 RVA: 0x00116EDD File Offset: 0x001150DD
		public static bool operator ==(ParameterToken a, ParameterToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004CC9 RID: 19657 RVA: 0x00116EE7 File Offset: 0x001150E7
		public static bool operator !=(ParameterToken a, ParameterToken b)
		{
			return !(a == b);
		}

		// Token: 0x04002188 RID: 8584
		public static readonly ParameterToken Empty;

		// Token: 0x04002189 RID: 8585
		internal int m_tkParameter;
	}
}
