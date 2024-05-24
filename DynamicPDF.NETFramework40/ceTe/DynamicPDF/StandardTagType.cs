using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000664 RID: 1636
	public class StandardTagType : TagType
	{
		// Token: 0x06003DD6 RID: 15830 RVA: 0x00216D18 File Offset: 0x00215D18
		internal StandardTagType(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003DD7 RID: 15831 RVA: 0x00216D34 File Offset: 0x00215D34
		public override string ToString()
		{
			return this.a;
		}

		// Token: 0x0400216B RID: 8555
		private new string a = null;
	}
}
