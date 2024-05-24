using System;
using System.Collections;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000858 RID: 2136
	public class CourierBold : CoreLatinFont
	{
		// Token: 0x060056AC RID: 22188 RVA: 0x0029BAA8 File Offset: 0x0029AAA8
		public CourierBold(SingleByteEncoder encoder) : base(600, encoder, ceTe.DynamicPDF.Text.CourierBold.a(encoder), "Courier-Bold", 833, -300, 17)
		{
		}

		// Token: 0x060056AD RID: 22189 RVA: 0x0029BAD0 File Offset: 0x0029AAD0
		private new static long a(SingleByteEncoder A_0)
		{
			long result;
			if (ceTe.DynamicPDF.Text.CourierBold.a.ContainsKey(A_0))
			{
				result = (long)ceTe.DynamicPDF.Text.CourierBold.a[A_0];
			}
			else
			{
				long num = Resource.NewUid();
				ceTe.DynamicPDF.Text.CourierBold.a[A_0] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x060056AE RID: 22190 RVA: 0x0029BB24 File Offset: 0x0029AB24
		public override string FormFontName
		{
			get
			{
				return "CoBo";
			}
		}

		// Token: 0x060056AF RID: 22191 RVA: 0x0029BB3C File Offset: 0x0029AB3C
		internal override short be()
		{
			return -197;
		}

		// Token: 0x060056B0 RID: 22192 RVA: 0x0029BB54 File Offset: 0x0029AB54
		internal override short bf()
		{
			return 52;
		}

		// Token: 0x04002E32 RID: 11826
		private new static Hashtable a = new Hashtable();
	}
}
