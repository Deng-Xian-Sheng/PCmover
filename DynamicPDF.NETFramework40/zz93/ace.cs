using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000440 RID: 1088
	internal class ace
	{
		// Token: 0x06002CFA RID: 11514 RVA: 0x001996CC File Offset: 0x001986CC
		internal ace(abj A_0)
		{
			this.a = A_0;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 276615959)
				{
					if (num != 1768372)
					{
						if (num != 87121142)
						{
							if (num == 276615959)
							{
								this.e = (abj)abk.c().h6();
							}
						}
						else
						{
							this.c = (abj)abk.c().h6();
						}
					}
					else
					{
						this.b = (abj)abk.c().h6();
					}
				}
				else if (num <= 329388686)
				{
					if (num != 277299595)
					{
						if (num == 329388686)
						{
							this.h = (abj)abk.c().h6();
						}
					}
					else
					{
						this.f = (abj)abk.c().h6();
					}
				}
				else if (num != 406725201)
				{
					if (num == 572024150)
					{
						this.g = (abj)abk.c().h6();
					}
				}
				else
				{
					this.d = (abj)abk.c().h6();
				}
			}
		}

		// Token: 0x06002CFB RID: 11515 RVA: 0x00199834 File Offset: 0x00198834
		private void a()
		{
			if (!this.j)
			{
				int num = -1;
				if (this.b != null)
				{
					num = this.b.f(num);
				}
				if (this.c != null)
				{
					num = this.c.f(num);
				}
				if (this.d != null)
				{
					num = this.d.f(num);
				}
				if (this.e != null)
				{
					num = this.e.f(num);
				}
				if (this.f != null)
				{
					num = this.f.f(num);
				}
				if (this.g != null)
				{
					num = this.g.f(num);
				}
				if (this.h != null)
				{
					num = this.h.f(num);
				}
				this.i = num + 1;
			}
			this.j = true;
		}

		// Token: 0x06002CFC RID: 11516 RVA: 0x0019991C File Offset: 0x0019891C
		internal int b()
		{
			this.a();
			return this.i;
		}

		// Token: 0x06002CFD RID: 11517 RVA: 0x0019993C File Offset: 0x0019893C
		internal void a(DocumentWriter A_0, PageResources A_1)
		{
			if (A_1 == null)
			{
				this.a.hz(A_0);
			}
			else
			{
				A_0.WriteName(ace.k);
				A_0.WriteDictionaryOpen();
				A_0.WriteName(ace.l);
				A_0.WriteArrayOpen();
				A_0.WriteName(ace.m);
				A_0.WriteName(ace.n);
				A_0.WriteName(ace.o);
				A_0.WriteName(ace.p);
				A_0.WriteName(ace.q);
				A_0.WriteArrayClose();
				if ((this.b != null && this.b.l() != null) || A_1.Fonts.Count > 0)
				{
					A_0.WriteName(ace.r);
					A_0.WriteDictionaryOpen();
					if (A_1.Fonts.Count > 0)
					{
						A_1.Fonts.DrawEntries(A_0);
					}
					if (this.b != null)
					{
						this.b.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				if ((this.d != null && this.d.l() != null) || A_1.XObjects.Count > 0)
				{
					A_0.WriteName(ace.x);
					A_0.WriteDictionaryOpen();
					if (A_1.XObjects.Count > 0)
					{
						A_1.XObjects.DrawEntries(A_0);
					}
					if (this.d != null)
					{
						this.d.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				if ((this.c != null && this.c.l() != null) || A_1.ExtGStates.Count > 0)
				{
					A_0.WriteName(ace.t);
					A_0.WriteDictionaryOpen();
					if (A_1.ExtGStates.Count > 0)
					{
						A_1.ExtGStates.DrawEntries(A_0);
					}
					if (this.c != null)
					{
						this.c.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				if ((this.e != null && this.e.l() != null) || A_1.ColorSpaces.Count > 0)
				{
					A_0.WriteName(ace.s);
					A_0.WriteDictionaryOpen();
					if (A_1.ColorSpaces.Count > 0)
					{
						A_1.ColorSpaces.DrawEntries(A_0);
					}
					if (this.e != null)
					{
						this.e.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				if ((this.f != null && this.f.l() != null) || A_1.Patterns.Count > 0)
				{
					A_0.WriteName(ace.u);
					A_0.WriteDictionaryOpen();
					if (A_1.Patterns.Count > 0)
					{
						A_1.Patterns.DrawEntries(A_0);
					}
					if (this.f != null)
					{
						this.f.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				if ((this.g != null && this.g.l() != null) || A_1.Properties.Count > 0)
				{
					A_0.WriteName(ace.v);
					A_0.WriteDictionaryOpen();
					if (A_1.Properties.Count > 0)
					{
						A_1.Properties.DrawEntries(A_0);
					}
					if (this.g != null)
					{
						this.g.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				if ((this.h != null && this.h.l() != null) || A_1.Shadings.Count > 0)
				{
					A_0.WriteName(ace.w);
					A_0.WriteDictionaryOpen();
					if (A_1.Shadings.Count > 0)
					{
						A_1.Shadings.DrawEntries(A_0);
					}
					if (this.h != null)
					{
						this.h.b(A_0);
					}
					A_0.WriteDictionaryClose();
				}
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06002CFE RID: 11518 RVA: 0x00199D82 File Offset: 0x00198D82
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteName(ace.k);
			this.a.hz(A_0);
		}

		// Token: 0x06002CFF RID: 11519 RVA: 0x00199DA0 File Offset: 0x00198DA0
		internal abj c()
		{
			return this.b;
		}

		// Token: 0x06002D00 RID: 11520 RVA: 0x00199DB8 File Offset: 0x00198DB8
		internal abj d()
		{
			return this.d;
		}

		// Token: 0x0400152F RID: 5423
		private abj a;

		// Token: 0x04001530 RID: 5424
		private abj b;

		// Token: 0x04001531 RID: 5425
		private abj c;

		// Token: 0x04001532 RID: 5426
		private abj d;

		// Token: 0x04001533 RID: 5427
		private abj e;

		// Token: 0x04001534 RID: 5428
		private abj f;

		// Token: 0x04001535 RID: 5429
		private abj g;

		// Token: 0x04001536 RID: 5430
		private abj h;

		// Token: 0x04001537 RID: 5431
		private int i = 0;

		// Token: 0x04001538 RID: 5432
		private bool j = false;

		// Token: 0x04001539 RID: 5433
		private static byte[] k = new byte[]
		{
			82,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			115
		};

		// Token: 0x0400153A RID: 5434
		private static byte[] l = new byte[]
		{
			80,
			114,
			111,
			99,
			83,
			101,
			116
		};

		// Token: 0x0400153B RID: 5435
		private static byte[] m = new byte[]
		{
			80,
			68,
			70
		};

		// Token: 0x0400153C RID: 5436
		private static byte[] n = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			67
		};

		// Token: 0x0400153D RID: 5437
		private static byte[] o = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			73
		};

		// Token: 0x0400153E RID: 5438
		private static byte[] p = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			66
		};

		// Token: 0x0400153F RID: 5439
		private static byte[] q = new byte[]
		{
			84,
			101,
			120,
			116
		};

		// Token: 0x04001540 RID: 5440
		private static byte[] r = new byte[]
		{
			70,
			111,
			110,
			116
		};

		// Token: 0x04001541 RID: 5441
		private static byte[] s = new byte[]
		{
			67,
			111,
			108,
			111,
			114,
			83,
			112,
			97,
			99,
			101
		};

		// Token: 0x04001542 RID: 5442
		private static byte[] t = new byte[]
		{
			69,
			120,
			116,
			71,
			83,
			116,
			97,
			116,
			101
		};

		// Token: 0x04001543 RID: 5443
		private static byte[] u = new byte[]
		{
			80,
			97,
			116,
			116,
			101,
			114,
			110
		};

		// Token: 0x04001544 RID: 5444
		private static byte[] v = new byte[]
		{
			80,
			114,
			111,
			112,
			101,
			114,
			116,
			105,
			101,
			115
		};

		// Token: 0x04001545 RID: 5445
		private static byte[] w = new byte[]
		{
			83,
			104,
			97,
			100,
			105,
			110,
			103
		};

		// Token: 0x04001546 RID: 5446
		private static byte[] x = new byte[]
		{
			88,
			79,
			98,
			106,
			101,
			99,
			116
		};
	}
}
