using System;
using System.Collections;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000859 RID: 2137
	public class CourierBoldOblique : CoreLatinFont
	{
		// Token: 0x060056B2 RID: 22194 RVA: 0x0029BB74 File Offset: 0x0029AB74
		public CourierBoldOblique(SingleByteEncoder encoder) : base(600, encoder, ceTe.DynamicPDF.Text.CourierBoldOblique.a(encoder), "Courier-BoldOblique", 833, -300, 17)
		{
		}

		// Token: 0x060056B3 RID: 22195 RVA: 0x0029BB9C File Offset: 0x0029AB9C
		private new static long a(SingleByteEncoder A_0)
		{
			long result;
			if (ceTe.DynamicPDF.Text.CourierBoldOblique.a.ContainsKey(A_0))
			{
				result = (long)ceTe.DynamicPDF.Text.CourierBoldOblique.a[A_0];
			}
			else
			{
				long num = Resource.NewUid();
				ceTe.DynamicPDF.Text.CourierBoldOblique.a[A_0] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x060056B4 RID: 22196 RVA: 0x0029BBF0 File Offset: 0x0029ABF0
		public override string FormFontName
		{
			get
			{
				return "CoBO";
			}
		}

		// Token: 0x060056B5 RID: 22197 RVA: 0x0029BC08 File Offset: 0x0029AC08
		internal override short be()
		{
			return -197;
		}

		// Token: 0x060056B6 RID: 22198 RVA: 0x0029BC20 File Offset: 0x0029AC20
		internal override short bf()
		{
			return 52;
		}

		// Token: 0x04002E33 RID: 11827
		private new static Hashtable a = new Hashtable();
	}
}
