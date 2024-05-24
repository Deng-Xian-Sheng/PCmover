using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200064E RID: 1614
	[ComVisible(true)]
	[Serializable]
	public struct MethodToken
	{
		// Token: 0x06004BFB RID: 19451 RVA: 0x001130C0 File Offset: 0x001112C0
		internal MethodToken(int str)
		{
			this.m_method = str;
		}

		// Token: 0x17000BEE RID: 3054
		// (get) Token: 0x06004BFC RID: 19452 RVA: 0x001130C9 File Offset: 0x001112C9
		public int Token
		{
			get
			{
				return this.m_method;
			}
		}

		// Token: 0x06004BFD RID: 19453 RVA: 0x001130D1 File Offset: 0x001112D1
		public override int GetHashCode()
		{
			return this.m_method;
		}

		// Token: 0x06004BFE RID: 19454 RVA: 0x001130D9 File Offset: 0x001112D9
		public override bool Equals(object obj)
		{
			return obj is MethodToken && this.Equals((MethodToken)obj);
		}

		// Token: 0x06004BFF RID: 19455 RVA: 0x001130F1 File Offset: 0x001112F1
		public bool Equals(MethodToken obj)
		{
			return obj.m_method == this.m_method;
		}

		// Token: 0x06004C00 RID: 19456 RVA: 0x00113101 File Offset: 0x00111301
		public static bool operator ==(MethodToken a, MethodToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004C01 RID: 19457 RVA: 0x0011310B File Offset: 0x0011130B
		public static bool operator !=(MethodToken a, MethodToken b)
		{
			return !(a == b);
		}

		// Token: 0x04001F4C RID: 8012
		public static readonly MethodToken Empty;

		// Token: 0x04001F4D RID: 8013
		internal int m_method;
	}
}
