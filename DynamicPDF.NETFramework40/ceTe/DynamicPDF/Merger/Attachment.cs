using System;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006E2 RID: 1762
	public class Attachment
	{
		// Token: 0x06004435 RID: 17461 RVA: 0x002331C0 File Offset: 0x002321C0
		internal Attachment(abd A_0, aba A_1)
		{
			abj abj;
			if (A_0.GetType() == typeof(ab6))
			{
				abj = (abj)A_0.h6();
			}
			else
			{
				abj = (abj)A_0;
			}
			for (abk abk = abj.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 6)
				{
					if (num != 326)
					{
						if (num == 1350)
						{
							this.b = ((ab7)abk.c().h6()).kf();
						}
					}
					else
					{
						this.f = (abj)abk.c().h6();
					}
				}
				else
				{
					this.c = ((ab7)abk.c().h6()).kf();
				}
			}
			if (this.c != null)
			{
				this.a = this.c;
			}
			else
			{
				this.a = this.b;
			}
		}

		// Token: 0x06004436 RID: 17462 RVA: 0x002332C8 File Offset: 0x002322C8
		internal byte[] a()
		{
			for (abk abk = this.f.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 6)
				{
					afj afj = (afj)abk.c().h6();
					this.e = afj.j4();
					break;
				}
			}
			return this.e;
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06004437 RID: 17463 RVA: 0x00233338 File Offset: 0x00232338
		// (set) Token: 0x06004438 RID: 17464 RVA: 0x00233350 File Offset: 0x00232350
		public string Filename
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06004439 RID: 17465 RVA: 0x0023335C File Offset: 0x0023235C
		public string MimeType
		{
			get
			{
				if (this.d == null)
				{
					abj abj = this.f;
					for (abk abk = abj.l(); abk != null; abk = abk.d())
					{
						if (abk.a().j8() == 6)
						{
							abj abj2 = (abj)abk.c().h6();
							for (abk abk2 = abj2.l(); abk2 != null; abk2 = abk2.d())
							{
								if (abk2.a().j8() == 332800284)
								{
									this.d = ((abu)abk2.c()).j9();
								}
							}
						}
					}
				}
				return this.d;
			}
		}

		// Token: 0x0600443A RID: 17466 RVA: 0x00233438 File Offset: 0x00232438
		public byte[] GetData()
		{
			byte[] result;
			if (this.e == null)
			{
				result = this.a();
			}
			else
			{
				result = this.e;
			}
			return result;
		}

		// Token: 0x040025FE RID: 9726
		private string a;

		// Token: 0x040025FF RID: 9727
		private string b;

		// Token: 0x04002600 RID: 9728
		private string c;

		// Token: 0x04002601 RID: 9729
		private string d;

		// Token: 0x04002602 RID: 9730
		private byte[] e;

		// Token: 0x04002603 RID: 9731
		private abj f;
	}
}
