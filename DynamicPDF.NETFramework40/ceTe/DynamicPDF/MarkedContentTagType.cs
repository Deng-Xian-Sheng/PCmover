using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200065F RID: 1631
	public class MarkedContentTagType : TagType
	{
		// Token: 0x06003DC5 RID: 15813 RVA: 0x00216AED File Offset: 0x00215AED
		internal MarkedContentTagType(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003DC6 RID: 15814 RVA: 0x00216B08 File Offset: 0x00215B08
		public override string ToString()
		{
			return this.a;
		}

		// Token: 0x04002160 RID: 8544
		private new string a = null;
	}
}
