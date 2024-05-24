using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020000E2 RID: 226
	internal class fe : fd
	{
		// Token: 0x060009F6 RID: 2550 RVA: 0x00080A43 File Offset: 0x0007FA43
		internal fe()
		{
			this.a = new fb<fs>[5];
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00080A68 File Offset: 0x0007FA68
		internal fe(gi A_0)
		{
			this.a = new fb<fs>[5];
			this.cw(A_0);
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00080A98 File Offset: 0x0007FA98
		internal override bool ct()
		{
			return this.c;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00080AB0 File Offset: 0x0007FAB0
		internal override void cu(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00080ABC File Offset: 0x0007FABC
		internal fb<fs>[] a()
		{
			return this.a;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00080AD4 File Offset: 0x0007FAD4
		internal void a(fb<fs>[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00080AE0 File Offset: 0x0007FAE0
		internal override int cv()
		{
			return 1617181893;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00080AF8 File Offset: 0x0007FAF8
		private void b(gi A_0)
		{
			if (A_0.ax())
			{
				this.a(A_0);
			}
			else if (!A_0.a8())
			{
				string text = A_0.ah();
				if (text != null)
				{
					string text2 = null;
					int num = A_0.a(text, 0, text.Length);
					if (num <= 7021096)
					{
						if (num != 136794 && num != 7021096)
						{
							goto IL_BD;
						}
					}
					else if (num != 141185593 && num != 426354259 && num != 448574430)
					{
						goto IL_BD;
					}
					if (A_0.ax())
					{
						text2 = A_0.ah();
					}
					else if (A_0.ba())
					{
						text += A_0.ah();
					}
					IL_BD:
					if (string.Compare(text, "inherit", true) == 0)
					{
						this.e(text);
						this.c(text);
						this.b(text);
						this.b(505607249);
						this.d(text);
					}
					else if (text2 == null)
					{
						this.a(text, A_0);
					}
					else
					{
						afw a_ = new afw(this.d(A_0.a(text, 0, text.Length)), x5.a(0f), i2.a, m4.a(new h2(A_0.a(text2))), i2.a);
						this.a(440052479, a_);
					}
				}
			}
			else
			{
				string text = A_0.a9();
				this.d(text);
			}
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00080C80 File Offset: 0x0007FC80
		private void a(string A_0, gi A_1)
		{
			int a_ = A_1.a(A_0, 0, A_0.Length);
			if (A_0.EndsWith("gif") || A_0.EndsWith("jpg") || A_0.EndsWith("png") || string.Compare(A_0, "none", true) == 0 || A_0.StartsWith("data:image/") || A_0.EndsWith("svg"))
			{
				this.e(A_0);
			}
			else if (this.g(a_))
			{
				this.c(A_0);
			}
			else if (this.f(a_))
			{
				this.b(A_0);
			}
			else if (this.e(a_))
			{
				this.b(a_);
			}
			else
			{
				this.d(A_0);
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00080D5C File Offset: 0x0007FD5C
		private void a(gi A_0, int A_1)
		{
			if (A_1 <= 137106767)
			{
				if (A_1 == 19010090)
				{
					string text = A_0.ah();
					this.b(text);
					return;
				}
				if (A_1 == 137106767)
				{
					string text = A_0.ah();
					this.e(text);
					return;
				}
			}
			else
			{
				if (A_1 == 440052479)
				{
					if (A_0.ax())
					{
						this.a(A_0);
					}
					else
					{
						string text = A_0.ah();
						if (text != null)
						{
							string text2 = null;
							int num = A_0.a(text, 0, text.Length);
							int num2 = num;
							if (num2 <= 7021096)
							{
								if (num2 != 136794 && num2 != 7021096)
								{
									goto IL_184;
								}
							}
							else if (num2 != 141185593 && num2 != 426354259 && num2 != 448574430)
							{
								goto IL_184;
							}
							if (A_0.ax())
							{
								text2 = A_0.ah();
							}
							else if (A_0.ba())
							{
								text += A_0.ah();
							}
							IL_184:
							if (text2 == null)
							{
								this.b(A_0.a(text, 0, text.Length));
							}
							else
							{
								i4 i = A_0.a(text2);
								ff ff = this.c(num);
								afw a_ = new afw(fr.j, x5.a(ff.a().a()), ff.a().b(), m4.a(new h2(A_0.a(text2))), i.b());
								this.a(440052479, a_);
							}
						}
					}
					return;
				}
				if (A_1 == 510035525)
				{
					string text;
					if (!A_0.a8())
					{
						text = A_0.ai();
					}
					else
					{
						text = A_0.a9();
					}
					if (text != null && text != string.Empty)
					{
						this.d(text);
					}
					return;
				}
				if (A_1 == 808234079)
				{
					string text = A_0.ah();
					this.c(text);
					return;
				}
			}
			A_0.ap();
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00080F88 File Offset: 0x0007FF88
		private void a(gi A_0)
		{
			string text = A_0.au().Trim();
			if (!text.ToLower().Contains("gradient"))
			{
				i4 a_ = A_0.a(text);
				if (A_0.a0() && A_0.aw() && A_0.ax())
				{
					text = A_0.au().Trim();
					i4 i = A_0.a(text);
					ff ff = new ff(a_, i);
					afw a_2 = new afw(fr.j, m4.a(new h2(a_)), a_.b(), m4.a(new h2(i)), i.b());
					this.a(440052479, a_2);
				}
				else
				{
					afw a_2;
					if (!A_0.ax() && A_0.ba())
					{
						string text2 = A_0.ah();
						int a_3 = A_0.a(text2, 0, text2.Length);
						ff ff2 = this.c(a_3);
						a_2 = new afw(fr.j, m4.a(new h2(a_)), a_.b(), x5.a(ff2.b().a()), ff2.b().b());
					}
					else
					{
						i4 i = A_0.a("50%");
						a_2 = new afw(fr.j, m4.a(new h2(a_)), a_.b(), m4.a(new h2(i)), i2.b);
					}
					this.a(440052479, a_2);
				}
			}
			else
			{
				A_0.ap();
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0008111C File Offset: 0x0008011C
		private void e(string A_0)
		{
			string text = A_0.ToLower();
			afv afv;
			if (text != null)
			{
				if (text == "none")
				{
					afv = new afv("none");
					goto IL_52;
				}
				if (text == "inherit")
				{
					afv = new afv("none");
					afv.d(true);
					goto IL_52;
				}
			}
			afv = new afv(A_0);
			IL_52:
			this.a(137106767, afv);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00081188 File Offset: 0x00080188
		private void d(string A_0)
		{
			string text = A_0.ToLower();
			afu afu;
			if (text != null)
			{
				if (text == "transparent")
				{
					afu = new afu(null);
					afu.a(true);
					goto IL_187;
				}
				if (text == "inherit")
				{
					afu = new afu(null);
					afu.d(true);
					goto IL_187;
				}
			}
			if (A_0.Length > 0 && A_0.Length != 7 && A_0[0] == '#')
			{
				char[] array = new char[7];
				int num = 0;
				array[0] = A_0[0];
				num++;
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
				}
				A_0 = new string(array);
			}
			afu = new afu(A_0);
			IL_187:
			this.a(510035525, afu);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0008132C File Offset: 0x0008032C
		private bool g(int A_0)
		{
			return A_0 == 677765424 || A_0 == 891372530;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00081358 File Offset: 0x00080358
		private void c(string A_0)
		{
			string text = A_0.ToLower();
			aft aft;
			if (text != null)
			{
				if (text == "fixed")
				{
					aft = new aft(fq.b);
					goto IL_60;
				}
				if (text == "scroll")
				{
					aft = new aft(fq.a);
					goto IL_60;
				}
				if (text == "inherit")
				{
					aft = new aft(fq.c);
					aft.d(true);
					goto IL_60;
				}
			}
			aft = new aft(fq.a);
			IL_60:
			this.a(808234079, aft);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000813D4 File Offset: 0x000803D4
		private bool f(int A_0)
		{
			if (A_0 <= 19010090)
			{
				if (A_0 != 18910250 && A_0 != 19010090)
				{
					goto IL_33;
				}
			}
			else if (A_0 != 19352618 && A_0 != 145482279)
			{
				goto IL_33;
			}
			return true;
			IL_33:
			return false;
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0008141C File Offset: 0x0008041C
		private void b(string A_0)
		{
			string text = A_0.ToLower();
			afx afx;
			if (text != null)
			{
				if (text == "repeat")
				{
					afx = new afx(gl.a);
					goto IL_8C;
				}
				if (text == "repeat-x")
				{
					afx = new afx(gl.b);
					goto IL_8C;
				}
				if (text == "repeat-y")
				{
					afx = new afx(gl.c);
					goto IL_8C;
				}
				if (text == "no-repeat")
				{
					afx = new afx(gl.d);
					goto IL_8C;
				}
				if (text == "inherit")
				{
					afx = new afx(gl.e);
					afx.d(true);
					goto IL_8C;
				}
			}
			afx = new afx(gl.a);
			IL_8C:
			this.a(19010090, afx);
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000814C4 File Offset: 0x000804C4
		private bool e(int A_0)
		{
			if (A_0 <= 443232922)
			{
				if (A_0 <= 149363472)
				{
					if (A_0 <= 7021096)
					{
						if (A_0 != 136794 && A_0 != 7021096)
						{
							goto IL_129;
						}
					}
					else if (A_0 != 141185593 && A_0 != 144841534 && A_0 != 149363472)
					{
						goto IL_129;
					}
				}
				else if (A_0 <= 259604940)
				{
					if (A_0 != 157384505 && A_0 != 174593994 && A_0 != 259604940)
					{
						goto IL_129;
					}
				}
				else if (A_0 != 329281306 && A_0 != 426354259 && A_0 != 443232922)
				{
					goto IL_129;
				}
			}
			else if (A_0 <= 754496083)
			{
				if (A_0 <= 448574430)
				{
					if (A_0 != 448307050 && A_0 != 448574430)
					{
						goto IL_129;
					}
				}
				else if (A_0 != 678428473 && A_0 != 742433627 && A_0 != 754496083)
				{
					goto IL_129;
				}
			}
			else if (A_0 <= 1027823409)
			{
				if (A_0 != 958951608 && A_0 != 1018784736 && A_0 != 1027823409)
				{
					goto IL_129;
				}
			}
			else if (A_0 != 1039877689 && A_0 != 1194346825 && A_0 != 1446231331)
			{
				goto IL_129;
			}
			return true;
			IL_129:
			return false;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00081600 File Offset: 0x00080600
		private fr d(int A_0)
		{
			if (A_0 <= 443232922)
			{
				if (A_0 <= 149363472)
				{
					if (A_0 <= 7021096)
					{
						if (A_0 != 136794)
						{
							if (A_0 != 7021096)
							{
								goto IL_14C;
							}
							goto IL_134;
						}
					}
					else
					{
						if (A_0 == 141185593)
						{
							goto IL_138;
						}
						if (A_0 != 144841534)
						{
							if (A_0 != 149363472)
							{
								goto IL_14C;
							}
							goto IL_12C;
						}
					}
				}
				else if (A_0 <= 259604940)
				{
					if (A_0 == 157384505)
					{
						goto IL_12C;
					}
					if (A_0 == 174593994)
					{
						goto IL_13C;
					}
					if (A_0 != 259604940)
					{
						goto IL_14C;
					}
					goto IL_130;
				}
				else
				{
					if (A_0 == 329281306 || A_0 == 426354259)
					{
						goto IL_140;
					}
					if (A_0 != 443232922)
					{
						goto IL_14C;
					}
				}
				return fr.a;
				IL_12C:
				return fr.b;
			}
			if (A_0 <= 754496083)
			{
				if (A_0 <= 448574430)
				{
					if (A_0 == 448307050)
					{
						goto IL_130;
					}
					if (A_0 != 448574430)
					{
						goto IL_14C;
					}
					goto IL_13C;
				}
				else
				{
					if (A_0 == 678428473)
					{
						goto IL_148;
					}
					if (A_0 != 742433627)
					{
						if (A_0 != 754496083)
						{
							goto IL_14C;
						}
						goto IL_140;
					}
				}
			}
			else if (A_0 <= 1027823409)
			{
				if (A_0 == 958951608)
				{
					goto IL_134;
				}
				if (A_0 != 1018784736)
				{
					if (A_0 != 1027823409)
					{
						goto IL_14C;
					}
					goto IL_138;
				}
			}
			else
			{
				if (A_0 == 1039877689)
				{
					goto IL_134;
				}
				if (A_0 == 1194346825)
				{
					goto IL_148;
				}
				if (A_0 != 1446231331)
				{
					goto IL_14C;
				}
				goto IL_13C;
			}
			return fr.h;
			IL_148:
			return fr.i;
			IL_130:
			return fr.c;
			IL_134:
			return fr.d;
			IL_138:
			return fr.e;
			IL_13C:
			return fr.f;
			IL_140:
			return fr.g;
			IL_14C:
			return fr.j;
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00081760 File Offset: 0x00080760
		private ff c(int A_0)
		{
			ff result;
			if (A_0 <= 7021096)
			{
				if (A_0 == 136794)
				{
					result = new ff(new i4(i2.b, 0f), new i4(i2.b, 0f));
					return result;
				}
				if (A_0 == 7021096)
				{
					result = new ff(new i4(i2.b, 0f), new i4(i2.b, 0f));
					return result;
				}
			}
			else
			{
				if (A_0 == 141185593)
				{
					result = new ff(new i4(i2.b, 50f), new i4(i2.b, 50f));
					return result;
				}
				if (A_0 == 426354259)
				{
					result = new ff(new i4(i2.b, 100f), new i4(i2.b, 100f));
					return result;
				}
				if (A_0 == 448574430)
				{
					result = new ff(new i4(i2.b, 100f), new i4(i2.b, 100f));
					return result;
				}
			}
			result = new ff(new i4(i2.b, 0f), new i4(i2.b, 0f));
			return result;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00081878 File Offset: 0x00080878
		private void b(int A_0)
		{
			ff ff;
			afw afw;
			if (A_0 <= 443232922)
			{
				if (A_0 <= 149363472)
				{
					if (A_0 <= 7021096)
					{
						if (A_0 == 136794)
						{
							goto IL_1D5;
						}
						if (A_0 != 7021096)
						{
							goto IL_58D;
						}
						goto IL_2B9;
					}
					else
					{
						if (A_0 == 141185593)
						{
							goto IL_32B;
						}
						if (A_0 != 144841534)
						{
							if (A_0 != 149363472)
							{
								goto IL_58D;
							}
							goto IL_1D5;
						}
					}
				}
				else if (A_0 <= 259604940)
				{
					if (A_0 == 157384505)
					{
						goto IL_1D5;
					}
					if (A_0 == 174593994)
					{
						goto IL_39D;
					}
					if (A_0 != 259604940)
					{
						goto IL_58D;
					}
					goto IL_247;
				}
				else
				{
					if (A_0 == 329281306)
					{
						goto IL_40F;
					}
					if (A_0 == 426354259)
					{
						goto IL_481;
					}
					if (A_0 != 443232922)
					{
						goto IL_58D;
					}
				}
				ff = new ff(new i4(i2.b, 0f), new i4(i2.b, 0f));
				afw = new afw(fr.a, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
				afw.a(true);
				goto IL_5FC;
				IL_1D5:
				ff = new ff(new i4(i2.b, 50f), new i4(i2.b, 0f));
				afw = new afw(fr.b, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
				afw.a(true);
				goto IL_5FC;
			}
			if (A_0 <= 754496083)
			{
				if (A_0 <= 505607249)
				{
					if (A_0 == 448307050)
					{
						goto IL_247;
					}
					if (A_0 == 448574430)
					{
						goto IL_39D;
					}
					if (A_0 != 505607249)
					{
						goto IL_58D;
					}
					afw = new afw(fr.k, x5.a(0f), i2.a, x5.a(0f), i2.a);
					afw.d(true);
					goto IL_5FC;
				}
				else if (A_0 != 678428473)
				{
					if (A_0 == 742433627)
					{
						goto IL_481;
					}
					if (A_0 != 754496083)
					{
						goto IL_58D;
					}
					goto IL_40F;
				}
			}
			else if (A_0 <= 1027823409)
			{
				if (A_0 == 958951608)
				{
					goto IL_2B9;
				}
				if (A_0 == 1018784736)
				{
					goto IL_481;
				}
				if (A_0 != 1027823409)
				{
					goto IL_58D;
				}
				goto IL_32B;
			}
			else
			{
				if (A_0 == 1039877689)
				{
					goto IL_2B9;
				}
				if (A_0 != 1194346825)
				{
					if (A_0 != 1446231331)
					{
						goto IL_58D;
					}
					goto IL_39D;
				}
			}
			ff = new ff(new i4(i2.b, 100f), new i4(i2.b, 100f));
			afw = new afw(fr.i, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_247:
			ff = new ff(new i4(i2.b, 100f), new i4(i2.b, 0f));
			afw = new afw(fr.c, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_2B9:
			ff = new ff(new i4(i2.b, 0f), new i4(i2.b, 50f));
			afw = new afw(fr.d, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_32B:
			ff = new ff(new i4(i2.b, 50f), new i4(i2.b, 50f));
			afw = new afw(fr.e, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_39D:
			ff = new ff(new i4(i2.b, 100f), new i4(i2.b, 50f));
			afw = new afw(fr.f, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_40F:
			ff = new ff(new i4(i2.b, 0f), new i4(i2.b, 100f));
			afw = new afw(fr.g, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_481:
			ff = new ff(new i4(i2.b, 50f), new i4(i2.b, 100f));
			afw = new afw(fr.h, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			goto IL_5FC;
			IL_58D:
			ff = new ff(new i4(i2.b, 0f), new i4(i2.b, 0f));
			afw = new afw(fr.a, m4.a(new h2(ff.a())), ff.a().b(), m4.a(new h2(ff.b())), ff.b().b());
			afw.a(true);
			IL_5FC:
			this.a(440052479, afw);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00081E90 File Offset: 0x00080E90
		private void a(int A_0, fs A_1)
		{
			if (A_1 != null)
			{
				int num = this.a(A_0);
				if (num < 0)
				{
					this.a[this.b++] = new fb<fs>(A_0, A_1);
				}
				else
				{
					this.a[num].a(A_0);
					this.a[num].a(A_1);
				}
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00081F14 File Offset: 0x00080F14
		private int a(int A_0)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a() == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00081F64 File Offset: 0x00080F64
		private void a(fb<fs> A_0, ref fe A_1, ref int A_2)
		{
			if (!this.a(A_0.a(), A_1.a(), ref A_2))
			{
				A_1.a()[A_2].a(A_0.a());
				A_1.a()[A_2].a(A_0.b());
				A_1.a()[A_2].b().d(A_0.b().g());
				A_2++;
			}
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00081FF0 File Offset: 0x00080FF0
		private bool a(int A_0, fb<fs>[] A_1, ref int A_2)
		{
			while (A_2 < A_1.Length)
			{
				bool result;
				if (A_1[A_2].a() != 0 && A_1[A_2].a() == A_0)
				{
					result = true;
				}
				else
				{
					if (A_1[A_2].a() != 0)
					{
						A_2++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00082064 File Offset: 0x00081064
		private Color a(string A_0)
		{
			A_0 = A_0.ToLower();
			Color result;
			if (A_0.Equals("transparent"))
			{
				result = null;
			}
			else
			{
				result = Color.d(A_0);
			}
			return result;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0008209C File Offset: 0x0008109C
		internal override void cw(gi A_0)
		{
			if (A_0.x())
			{
				int a_ = A_0.y();
				this.a(A_0, a_);
			}
			else
			{
				this.a = new fb<fs>[5];
				this.b = 0;
				this.b(A_0);
				while (A_0.a0() && A_0.aw())
				{
					this.b(A_0);
				}
				this.c = true;
			}
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00082111 File Offset: 0x00081111
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00082120 File Offset: 0x00081120
		internal bool b()
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0 && this.a()[i].b().g())
				{
					result = true;
					i = this.a().Length;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00082190 File Offset: 0x00081190
		internal bool h(int A_0)
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() == A_0 && this.a()[i].b().g())
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x000821F8 File Offset: 0x000811F8
		internal fe a(fe A_0)
		{
			fb<fs>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (this.a()[i].a() == array[j].a())
						{
							if (this.a()[i].b().g() && !array[j].b().g())
							{
								this.a()[i].a(array[j].b());
								this.a()[i].b().d(false);
							}
							break;
						}
					}
				}
			}
			return this;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00082304 File Offset: 0x00081304
		internal fe b(fe A_0)
		{
			fe fe = new fe();
			int num = 0;
			fb<fs>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					fe.a()[num].a(this.a()[i].a());
					fe.a()[num].a(this.a()[i].b());
					num++;
				}
			}
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = false;
				if (array[i].a() != 0)
				{
					for (int j = 0; j < this.a().Length; j++)
					{
						if (this.a()[j].a() == array[i].a())
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.a(array[i], ref fe, ref num);
					}
				}
			}
			return fe;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00082450 File Offset: 0x00081450
		internal bool a(int A_0, fb<fs>[] A_1)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].a() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00082494 File Offset: 0x00081494
		internal fe a(fe A_0, fe A_1)
		{
			fe fe = new fe();
			fb<fs>[] array = A_0.a();
			fb<fs>[] array2 = A_1.a();
			int num = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!this.a(array2[i].a(), array, ref num))
				{
					if (array2[i].a() != 0)
					{
						array[num].a(array2[i].a());
						array[num].a(array2[i].b());
					}
				}
				num = 0;
			}
			fe.a(array);
			return fe;
		}

		// Token: 0x04000505 RID: 1285
		private new fb<fs>[] a;

		// Token: 0x04000506 RID: 1286
		private int b = 0;

		// Token: 0x04000507 RID: 1287
		private bool c = false;
	}
}
