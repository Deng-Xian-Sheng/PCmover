using System;

namespace System.Reflection.Emit
{
	// Token: 0x0200062C RID: 1580
	internal class NativeVersionInfo
	{
		// Token: 0x06004987 RID: 18823 RVA: 0x0010A818 File Offset: 0x00108A18
		internal NativeVersionInfo()
		{
			this.m_strDescription = null;
			this.m_strCompany = null;
			this.m_strTitle = null;
			this.m_strCopyright = null;
			this.m_strTrademark = null;
			this.m_strProduct = null;
			this.m_strProductVersion = null;
			this.m_strFileVersion = null;
			this.m_lcid = -1;
		}

		// Token: 0x04001E6C RID: 7788
		internal string m_strDescription;

		// Token: 0x04001E6D RID: 7789
		internal string m_strCompany;

		// Token: 0x04001E6E RID: 7790
		internal string m_strTitle;

		// Token: 0x04001E6F RID: 7791
		internal string m_strCopyright;

		// Token: 0x04001E70 RID: 7792
		internal string m_strTrademark;

		// Token: 0x04001E71 RID: 7793
		internal string m_strProduct;

		// Token: 0x04001E72 RID: 7794
		internal string m_strProductVersion;

		// Token: 0x04001E73 RID: 7795
		internal string m_strFileVersion;

		// Token: 0x04001E74 RID: 7796
		internal int m_lcid;
	}
}
