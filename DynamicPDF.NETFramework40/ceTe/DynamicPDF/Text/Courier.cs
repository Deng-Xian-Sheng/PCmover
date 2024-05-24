using System;
using System.Collections;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000857 RID: 2135
	public class Courier : CoreLatinFont
	{
		// Token: 0x060056A6 RID: 22182 RVA: 0x0029B9DC File Offset: 0x0029A9DC
		public Courier(SingleByteEncoder encoder) : base(600, encoder, ceTe.DynamicPDF.Text.Courier.a(encoder), "Courier", 900, -220, 30)
		{
		}

		// Token: 0x060056A7 RID: 22183 RVA: 0x0029BA04 File Offset: 0x0029AA04
		private new static long a(SingleByteEncoder A_0)
		{
			long result;
			if (ceTe.DynamicPDF.Text.Courier.a.ContainsKey(A_0))
			{
				result = (long)ceTe.DynamicPDF.Text.Courier.a[A_0];
			}
			else
			{
				long num = Resource.NewUid();
				ceTe.DynamicPDF.Text.Courier.a[A_0] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x060056A8 RID: 22184 RVA: 0x0029BA58 File Offset: 0x0029AA58
		public override string FormFontName
		{
			get
			{
				return "Cour";
			}
		}

		// Token: 0x060056A9 RID: 22185 RVA: 0x0029BA70 File Offset: 0x0029AA70
		internal override short be()
		{
			return -197;
		}

		// Token: 0x060056AA RID: 22186 RVA: 0x0029BA88 File Offset: 0x0029AA88
		internal override short bf()
		{
			return 52;
		}

		// Token: 0x04002E31 RID: 11825
		private new static Hashtable a = new Hashtable();
	}
}
