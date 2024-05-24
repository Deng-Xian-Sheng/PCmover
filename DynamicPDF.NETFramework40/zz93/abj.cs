using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000421 RID: 1057
	internal class abj : abd
	{
		// Token: 0x06002BF4 RID: 11252 RVA: 0x00194907 File Offset: 0x00193907
		internal abj(abi A_0, abk A_1)
		{
			this.b = A_0;
			this.a = A_1;
		}

		// Token: 0x06002BF5 RID: 11253 RVA: 0x00194938 File Offset: 0x00193938
		internal string j()
		{
			string text = string.Empty;
			for (abk abk = this.a; abk != null; abk = abk.d())
			{
				if (abk.c().hy() == ag9.j)
				{
					ab6 ab = (ab6)abk.c();
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"/",
						abk.a().j9(),
						" ",
						ab.c().ToString(),
						" 0 R "
					});
				}
			}
			return text;
		}

		// Token: 0x06002BF6 RID: 11254 RVA: 0x001949F8 File Offset: 0x001939F8
		internal override ag9 hy()
		{
			return ag9.g;
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x00194A0C File Offset: 0x00193A0C
		internal abi k()
		{
			return this.b;
		}

		// Token: 0x06002BF8 RID: 11256 RVA: 0x00194A24 File Offset: 0x00193A24
		internal abk l()
		{
			return this.a;
		}

		// Token: 0x06002BF9 RID: 11257 RVA: 0x00194A3C File Offset: 0x00193A3C
		private void a()
		{
			if (!this.e)
			{
				for (abk abk = this.l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num != 5479461)
					{
						if (num == 332800284)
						{
							this.d = (abu)abk.c();
						}
					}
					else
					{
						this.c = (abu)abk.c();
					}
				}
				this.e = true;
			}
		}

		// Token: 0x06002BFA RID: 11258 RVA: 0x00194AC1 File Offset: 0x00193AC1
		protected void a(abu A_0, abu A_1)
		{
			this.c = A_0;
			this.d = A_1;
			this.e = true;
		}

		// Token: 0x06002BFB RID: 11259 RVA: 0x00194ADC File Offset: 0x00193ADC
		internal ag1 m()
		{
			this.a();
			ag1 result;
			if (this.c == null)
			{
				result = ag1.a;
			}
			else
			{
				result = (ag1)this.c.j8();
			}
			return result;
		}

		// Token: 0x06002BFC RID: 11260 RVA: 0x00194B14 File Offset: 0x00193B14
		internal ag0 n()
		{
			this.a();
			ag0 result;
			if (this.d == null)
			{
				result = ag0.a;
			}
			else
			{
				result = (ag0)this.d.j8();
			}
			return result;
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x00194B4C File Offset: 0x00193B4C
		internal int f(int A_0)
		{
			for (abk abk = this.a; abk != null; abk = abk.d())
			{
				A_0 = abk.a().kb(A_0);
			}
			return A_0;
		}

		// Token: 0x06002BFE RID: 11262 RVA: 0x00194B8C File Offset: 0x00193B8C
		internal void b(DocumentWriter A_0)
		{
			for (abk abk = this.a; abk != null; abk = abk.d())
			{
				abk.a(A_0);
			}
		}

		// Token: 0x06002BFF RID: 11263 RVA: 0x00194BC0 File Offset: 0x00193BC0
		internal void b(agx A_0, DocumentWriter A_1)
		{
			for (abk abk = this.a; abk != null; abk = abk.d())
			{
				abk.a(A_0, A_1);
			}
		}

		// Token: 0x06002C00 RID: 11264 RVA: 0x00194BF4 File Offset: 0x00193BF4
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteDictionaryOpen();
				this.b(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06002C01 RID: 11265 RVA: 0x00194C28 File Offset: 0x00193C28
		internal abj g(int A_0)
		{
			for (abk abk = this.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == A_0)
				{
					abj result;
					if (abk.c().hy() == ag9.g)
					{
						abj abj = (abj)abk.c();
						result = abj;
					}
					else
					{
						result = null;
					}
					return result;
				}
			}
			return null;
		}

		// Token: 0x06002C02 RID: 11266 RVA: 0x00194C9C File Offset: 0x00193C9C
		internal ab6 h(int A_0)
		{
			for (abk abk = this.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == A_0)
				{
					ab6 result;
					if (abk.c().hy() == ag9.j)
					{
						ab6 ab = (ab6)abk.c();
						result = ab;
					}
					else
					{
						result = null;
					}
					return result;
				}
			}
			return null;
		}

		// Token: 0x06002C03 RID: 11267 RVA: 0x00194D10 File Offset: 0x00193D10
		internal string o()
		{
			for (abk abk = this.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num == 567551866)
				{
					if (abk.c().hy() == ag9.e)
					{
						abe abe = (abe)abk.c();
						for (int i = 0; i < abe.a(); i++)
						{
							if (abe.a(i).hy() == ag9.g)
							{
								for (abk abk2 = ((abj)abe.a(i)).a; abk2 != null; abk2 = abk2.d())
								{
									if (abk2.a().j9() == "Name")
									{
										return ((abu)abk2.c()).j9();
									}
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x040014A9 RID: 5289
		private abk a;

		// Token: 0x040014AA RID: 5290
		private abi b;

		// Token: 0x040014AB RID: 5291
		private abu c = null;

		// Token: 0x040014AC RID: 5292
		private abu d = null;

		// Token: 0x040014AD RID: 5293
		private bool e = false;
	}
}
