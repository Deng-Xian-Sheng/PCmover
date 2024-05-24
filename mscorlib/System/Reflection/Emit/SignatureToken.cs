using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200065F RID: 1631
	[ComVisible(true)]
	public struct SignatureToken
	{
		// Token: 0x06004D2D RID: 19757 RVA: 0x001184A0 File Offset: 0x001166A0
		internal SignatureToken(int str, ModuleBuilder mod)
		{
			this.m_signature = str;
			this.m_moduleBuilder = mod;
		}

		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x06004D2E RID: 19758 RVA: 0x001184B0 File Offset: 0x001166B0
		public int Token
		{
			get
			{
				return this.m_signature;
			}
		}

		// Token: 0x06004D2F RID: 19759 RVA: 0x001184B8 File Offset: 0x001166B8
		public override int GetHashCode()
		{
			return this.m_signature;
		}

		// Token: 0x06004D30 RID: 19760 RVA: 0x001184C0 File Offset: 0x001166C0
		public override bool Equals(object obj)
		{
			return obj is SignatureToken && this.Equals((SignatureToken)obj);
		}

		// Token: 0x06004D31 RID: 19761 RVA: 0x001184D8 File Offset: 0x001166D8
		public bool Equals(SignatureToken obj)
		{
			return obj.m_signature == this.m_signature;
		}

		// Token: 0x06004D32 RID: 19762 RVA: 0x001184E8 File Offset: 0x001166E8
		public static bool operator ==(SignatureToken a, SignatureToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004D33 RID: 19763 RVA: 0x001184F2 File Offset: 0x001166F2
		public static bool operator !=(SignatureToken a, SignatureToken b)
		{
			return !(a == b);
		}

		// Token: 0x0400219D RID: 8605
		public static readonly SignatureToken Empty;

		// Token: 0x0400219E RID: 8606
		internal int m_signature;

		// Token: 0x0400219F RID: 8607
		internal ModuleBuilder m_moduleBuilder;
	}
}
