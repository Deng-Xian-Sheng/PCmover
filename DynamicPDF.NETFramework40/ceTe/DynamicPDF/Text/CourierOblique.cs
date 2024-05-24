using System;
using System.Collections;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x0200085A RID: 2138
	public class CourierOblique : CoreLatinFont
	{
		// Token: 0x060056B8 RID: 22200 RVA: 0x0029BC40 File Offset: 0x0029AC40
		public CourierOblique(SingleByteEncoder encoder) : base(600, encoder, ceTe.DynamicPDF.Text.CourierOblique.a(encoder), "Courier-Oblique", 833, -300, 17)
		{
		}

		// Token: 0x060056B9 RID: 22201 RVA: 0x0029BC68 File Offset: 0x0029AC68
		private new static long a(SingleByteEncoder A_0)
		{
			long result;
			if (ceTe.DynamicPDF.Text.CourierOblique.a.ContainsKey(A_0))
			{
				result = (long)ceTe.DynamicPDF.Text.CourierOblique.a[A_0];
			}
			else
			{
				long num = Resource.NewUid();
				ceTe.DynamicPDF.Text.CourierOblique.a[A_0] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x060056BA RID: 22202 RVA: 0x0029BCBC File Offset: 0x0029ACBC
		public override string FormFontName
		{
			get
			{
				return "CoOb";
			}
		}

		// Token: 0x060056BB RID: 22203 RVA: 0x0029BCD4 File Offset: 0x0029ACD4
		internal override short be()
		{
			return -197;
		}

		// Token: 0x060056BC RID: 22204 RVA: 0x0029BCEC File Offset: 0x0029ACEC
		internal override short bf()
		{
			return 52;
		}

		// Token: 0x04002E34 RID: 11828
		private new static Hashtable a = new Hashtable();
	}
}
