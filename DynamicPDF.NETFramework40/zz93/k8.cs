using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001B4 RID: 436
	internal class k8
	{
		// Token: 0x060010C5 RID: 4293 RVA: 0x000C187C File Offset: 0x000C087C
		internal k8()
		{
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x000C18F0 File Offset: 0x000C08F0
		internal k8(k8 A_0)
		{
			this.a = A_0.a;
			this.b = A_0.e();
			this.c = A_0.f();
			this.d = A_0.g();
			this.e = A_0.h();
			this.f = A_0.j();
			this.g = A_0.k();
			this.h = A_0.i();
			this.i = A_0.b();
			this.j = A_0.d();
			this.k = A_0.c();
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000C19E8 File Offset: 0x000C09E8
		internal Color a()
		{
			return this.a;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000C1A00 File Offset: 0x000C0A00
		internal void a(Color A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x000C1A0C File Offset: 0x000C0A0C
		internal bool b()
		{
			return this.i;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x000C1A24 File Offset: 0x000C0A24
		internal void a(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x000C1A30 File Offset: 0x000C0A30
		internal bool c()
		{
			return this.k;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x000C1A48 File Offset: 0x000C0A48
		internal void b(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x000C1A54 File Offset: 0x000C0A54
		internal bool d()
		{
			return this.j;
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x000C1A6C File Offset: 0x000C0A6C
		internal void c(bool A_0)
		{
			this.j = A_0;
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x000C1A78 File Offset: 0x000C0A78
		internal string e()
		{
			return this.b;
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x000C1A90 File Offset: 0x000C0A90
		internal gl f()
		{
			return this.c;
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x000C1AA8 File Offset: 0x000C0AA8
		internal fq g()
		{
			return this.d;
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x000C1AC0 File Offset: 0x000C0AC0
		internal fr h()
		{
			return this.e;
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x000C1AD8 File Offset: 0x000C0AD8
		internal void a(fr A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x000C1AE4 File Offset: 0x000C0AE4
		internal afw i()
		{
			return this.h;
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x000C1AFC File Offset: 0x000C0AFC
		internal x5 j()
		{
			return this.f;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x000C1B14 File Offset: 0x000C0B14
		internal void a(x5 A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x000C1B20 File Offset: 0x000C0B20
		internal x5 k()
		{
			return this.g;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x000C1B38 File Offset: 0x000C0B38
		internal void b(x5 A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x000C1B44 File Offset: 0x000C0B44
		private string a(string A_0)
		{
			if (A_0.Length > 0 && A_0.Length != 7 && A_0[0] == '#')
			{
				char[] array = new char[7];
				int num = 0;
				array[0] = A_0[0];
				num++;
				if (A_0.Length > 7)
				{
					A_0 = A_0.Substring(0, 7);
				}
				switch (A_0.Length)
				{
				case 4:
					for (int i = 1; i < array.Length; i++)
					{
						if (i % 2 == 0)
						{
							array[i] = A_0[num];
							num++;
						}
						else
						{
							array[i] = A_0[num];
						}
					}
					break;
				case 5:
					for (int i = 1; i < array.Length; i++)
					{
						if (i > 4)
						{
							array[i] = '0';
						}
						else
						{
							array[i] = A_0[i];
						}
					}
					break;
				case 6:
					for (int i = 1; i < array.Length; i++)
					{
						if (i > 5)
						{
							array[i] = '0';
						}
						else
						{
							array[i] = A_0[i];
						}
					}
					break;
				case 7:
					for (int i = 1; i < array.Length; i++)
					{
						array[i] = A_0[i];
					}
					break;
				}
				A_0 = new string(array);
			}
			return A_0;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x000C1CC8 File Offset: 0x000C0CC8
		internal void a(fb<fs>[] A_0)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				int num = A_0[i].a();
				if (num <= 137106767)
				{
					if (num != 0)
					{
						if (num != 19010090)
						{
							if (num == 137106767)
							{
								this.j = true;
								this.b = A_0[i].b().km().a();
								if (this.b == "none")
								{
									this.b = null;
								}
							}
						}
						else
						{
							this.c = A_0[i].b().ko().a();
						}
					}
					else if (A_0[i].b() != null && !A_0[i].b().g())
					{
						i = A_0.Length;
					}
				}
				else if (num != 440052479)
				{
					if (num != 510035525)
					{
						if (num == 808234079)
						{
							this.d = A_0[i].b().kk().a();
						}
					}
					else
					{
						string text = A_0[i].b().kl().a();
						if (text != null)
						{
							if (text.StartsWith("rgb"))
							{
								string text2 = text.Substring(text.IndexOf('(') + 1, text.Length - (text.IndexOf('(') + 1) - 1);
								string[] array = text2.Split(new char[]
								{
									','
								});
								float[] array2 = new float[3];
								int num2 = array.Length;
								if (array.Length > 3)
								{
									num2 = 3;
								}
								for (int j = 0; j < num2; j++)
								{
									if (array[j].Contains("%"))
									{
										int length = array[j].IndexOf('%');
										string text3 = array[j].Substring(0, length);
										array2[j] = float.Parse(text3.Trim()) * 2.55f / 255f;
									}
									else
									{
										array2[j] = float.Parse(array[j].Trim()) / 255f;
									}
								}
								this.a = Color.d(string.Concat(new string[]
								{
									"rgb(",
									array2[0].ToString(),
									",",
									array2[1].ToString(),
									",",
									array2[2].ToString(),
									")"
								}));
							}
							else
							{
								this.a = Color.d(this.a(text));
							}
							this.i = true;
						}
					}
				}
				else
				{
					this.h = A_0[i].b().kn();
					this.e = this.h.kn().e();
					this.f = this.h.a();
					this.g = this.h.c();
				}
			}
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x000C2014 File Offset: 0x000C1014
		internal void a(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			if (this.a != null && x5.c(A_3, x5.c()) && x5.c(A_4, x5.c()))
			{
				A_0.SetGraphicsMode();
				A_0.SetFillColor(this.a);
				A_0.Write_re(x5.b(A_1), x5.b(A_2), x5.b(A_3), x5.b(A_4));
				A_0.Write_f();
			}
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x000C2094 File Offset: 0x000C1094
		internal k8 l()
		{
			return new k8(this);
		}

		// Token: 0x04000815 RID: 2069
		private Color a = null;

		// Token: 0x04000816 RID: 2070
		private string b = null;

		// Token: 0x04000817 RID: 2071
		private gl c = gl.a;

		// Token: 0x04000818 RID: 2072
		private fq d = fq.a;

		// Token: 0x04000819 RID: 2073
		private fr e = fr.k;

		// Token: 0x0400081A RID: 2074
		private x5 f;

		// Token: 0x0400081B RID: 2075
		private x5 g;

		// Token: 0x0400081C RID: 2076
		private afw h = new afw(fr.a, x5.a(0f), i2.c, x5.a(0f), i2.c);

		// Token: 0x0400081D RID: 2077
		private bool i = false;

		// Token: 0x0400081E RID: 2078
		private bool j = false;

		// Token: 0x0400081F RID: 2079
		private bool k = false;
	}
}
