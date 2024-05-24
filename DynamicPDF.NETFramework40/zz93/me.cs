using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020001E0 RID: 480
	internal class me : lj
	{
		// Token: 0x06001492 RID: 5266 RVA: 0x000E5EF0 File Offset: 0x000E4EF0
		internal me()
		{
			this.a = null;
			this.d = null;
			this.b = gs.a;
			this.c = x5.c();
			this.f = Color.d("black");
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x000E5F40 File Offset: 0x000E4F40
		internal override int[] ds()
		{
			return lj.b();
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x000E5F58 File Offset: 0x000E4F58
		internal new string a()
		{
			return this.a;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x000E5F70 File Offset: 0x000E4F70
		internal new void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x000E5F7C File Offset: 0x000E4F7C
		internal new Font b()
		{
			return this.d;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x000E5F94 File Offset: 0x000E4F94
		internal new void a(Font A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x000E5FA0 File Offset: 0x000E4FA0
		internal new gs c()
		{
			return this.b;
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x000E5FB8 File Offset: 0x000E4FB8
		internal new void a(gs A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x000E5FC4 File Offset: 0x000E4FC4
		internal new x5 d()
		{
			return this.c;
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x000E5FDC File Offset: 0x000E4FDC
		internal new void a(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x000E5FE8 File Offset: 0x000E4FE8
		internal new bool e()
		{
			return this.e;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x000E6000 File Offset: 0x000E5000
		internal new void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x000E600C File Offset: 0x000E500C
		internal new Color f()
		{
			return this.f;
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x000E6024 File Offset: 0x000E5024
		internal new void a(Color A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x000E6030 File Offset: 0x000E5030
		internal override void dt(int A_0, fd A_1)
		{
			if (A_0 != 202920309)
			{
				if (A_0 == 510035525)
				{
					if (((iv)A_1).a() != null)
					{
						string text = ((iv)A_1).a().a();
						if (text.StartsWith("rgb"))
						{
							string text2 = text.Substring(text.IndexOf('(') + 1, text.Length - (text.IndexOf('(') + 1) - 1);
							string[] array = text2.Split(new char[]
							{
								','
							});
							float[] array2 = new float[array.Length];
							for (int i = 0; i < array.Length; i++)
							{
								array2[i] = float.Parse(array[i].Trim()) / 255f;
							}
							string a_ = string.Concat(new string[]
							{
								"rgb(",
								array2[0].ToString(),
								",",
								array2[1].ToString(),
								",",
								array2[2].ToString(),
								")"
							});
							this.f = Color.d(a_);
						}
						else
						{
							this.f = Color.d(text);
						}
					}
				}
			}
			else
			{
				this.b = ((i5)A_1).a().c();
				this.c = ((i5)A_1).a().b();
			}
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x000E61C8 File Offset: 0x000E51C8
		internal override lj du()
		{
			me me = new me();
			me.a(this.a());
			me.a(this.b());
			me.a(this.c());
			me.a(this.d());
			me.a(this.e());
			return me;
		}

		// Token: 0x040009C3 RID: 2499
		private new string a;

		// Token: 0x040009C4 RID: 2500
		private new gs b;

		// Token: 0x040009C5 RID: 2501
		private new x5 c;

		// Token: 0x040009C6 RID: 2502
		private new Font d;

		// Token: 0x040009C7 RID: 2503
		private new bool e = false;

		// Token: 0x040009C8 RID: 2504
		private new Color f;
	}
}
