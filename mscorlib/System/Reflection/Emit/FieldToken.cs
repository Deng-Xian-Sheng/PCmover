using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200063B RID: 1595
	[ComVisible(true)]
	[Serializable]
	public struct FieldToken
	{
		// Token: 0x06004A8D RID: 19085 RVA: 0x0010D85D File Offset: 0x0010BA5D
		internal FieldToken(int field, Type fieldClass)
		{
			this.m_fieldTok = field;
			this.m_class = fieldClass;
		}

		// Token: 0x17000BA9 RID: 2985
		// (get) Token: 0x06004A8E RID: 19086 RVA: 0x0010D86D File Offset: 0x0010BA6D
		public int Token
		{
			get
			{
				return this.m_fieldTok;
			}
		}

		// Token: 0x06004A8F RID: 19087 RVA: 0x0010D875 File Offset: 0x0010BA75
		public override int GetHashCode()
		{
			return this.m_fieldTok;
		}

		// Token: 0x06004A90 RID: 19088 RVA: 0x0010D87D File Offset: 0x0010BA7D
		public override bool Equals(object obj)
		{
			return obj is FieldToken && this.Equals((FieldToken)obj);
		}

		// Token: 0x06004A91 RID: 19089 RVA: 0x0010D895 File Offset: 0x0010BA95
		public bool Equals(FieldToken obj)
		{
			return obj.m_fieldTok == this.m_fieldTok && obj.m_class == this.m_class;
		}

		// Token: 0x06004A92 RID: 19090 RVA: 0x0010D8B5 File Offset: 0x0010BAB5
		public static bool operator ==(FieldToken a, FieldToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004A93 RID: 19091 RVA: 0x0010D8BF File Offset: 0x0010BABF
		public static bool operator !=(FieldToken a, FieldToken b)
		{
			return !(a == b);
		}

		// Token: 0x04001EB4 RID: 7860
		public static readonly FieldToken Empty;

		// Token: 0x04001EB5 RID: 7861
		internal int m_fieldTok;

		// Token: 0x04001EB6 RID: 7862
		internal object m_class;
	}
}
