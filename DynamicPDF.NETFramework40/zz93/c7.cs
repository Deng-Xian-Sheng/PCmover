using System;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;

namespace zz93
{
	// Token: 0x02000090 RID: 144
	internal class c7 : c6
	{
		// Token: 0x06000713 RID: 1811 RVA: 0x00060F04 File Offset: 0x0005FF04
		internal int b()
		{
			return this.e;
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00060F1C File Offset: 0x0005FF1C
		internal void b(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00060F28 File Offset: 0x0005FF28
		internal new void a(abd A_0, r2 A_1, int A_2, int A_3)
		{
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			abe abe = null;
			if (A_0.hy() == ag9.j)
			{
				abd abd = A_0.h6();
				if (abd != null)
				{
					if (abd.hy() == ag9.g)
					{
						c5 c = new c5((abj)abd, this.e);
						c.a(null, null, A_2, A_3, A_1);
						base.a(this.a++, c);
					}
					else if (abd.hy() == ag9.e)
					{
						abe = (abe)A_0.h6();
					}
				}
			}
			else if (A_0.hy() == ag9.e)
			{
				abe = (abe)A_0;
			}
			if (abe != null)
			{
				for (int i = 0; i < abe.a(); i++)
				{
					if (abe.a(i).hy() == ag9.j)
					{
						if (abe.a(i).h6().hy() == ag9.g)
						{
							c5 c = new c5((abj)((ab6)abe.a(i)).h6(), this.e);
							c.a(null, null, A_2, A_3, A_1);
							base.a(this.a++, c);
							c.a(i);
						}
					}
				}
			}
			this.a();
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x000610D4 File Offset: 0x000600D4
		private new void a(c5 A_0, abd A_1, int A_2)
		{
			if (A_1 != null && A_1.hy() == ag9.b)
			{
				if (A_0.f() != null && A_0.f().a() != null && A_0.f().a().e() != null)
				{
					if (A_0.f().a().h().o() < ((abw)A_1).kd())
					{
						A_0.f().a().h().a(((abw)A_1).kd());
					}
					c4 c = new c4(A_0.f(), A_1);
					c.a(((abw)A_1).kd());
					if (this.a(A_0.f().a().h().e()))
					{
						A_0.a(c);
						c.b(A_2);
					}
				}
			}
			else if (A_1 != null && A_1.hy() == ag9.g)
			{
				int num = this.a((abj)A_1);
				if (num == 1)
				{
					this.a((abj)A_1, 1, A_0, A_2);
				}
				else if (num == 2)
				{
					this.a((abj)A_1, 2, A_0, A_2);
				}
			}
			else if (A_1 != null && A_1.hy() == ag9.j)
			{
				abj a_ = (abj)A_1.h6();
				int num = this.a(a_);
				if (num == 1)
				{
					this.a(a_, 1, A_0, A_2);
				}
				else if (num == 2)
				{
					this.a(a_, 2, A_0, A_2);
				}
			}
			else
			{
				A_0.a(null);
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x000612C0 File Offset: 0x000602C0
		private new void a()
		{
			abe abe = null;
			for (int i = 0; i < this.a; i++)
			{
				abd abd = ((c5)this.a[i]).e();
				if (abd != null && abd.hy() == ag9.j)
				{
					if (abd.h6().hy() == ag9.g)
					{
						if (this.a((abj)abd.h6()) < 1)
						{
							c5 c = new c5((abj)abd.h6(), this.e);
							c.a((c5)this.a[i], null, this.c, this.d, this.b);
							base.a(this.a++, c);
							c.a(0);
						}
						else
						{
							this.a((c5)this.a[i], abd, 0);
						}
					}
					else if (abd.h6().hy() == ag9.e)
					{
						abe = (abe)abd.h6();
					}
					else
					{
						this.a((c5)this.a[i], abd, 0);
					}
				}
				else if (abd != null && abd.hy() == ag9.e)
				{
					abe = (abe)abd.h6();
				}
				else
				{
					this.a((c5)this.a[i], abd, 0);
				}
				if (abe != null)
				{
					for (int j = 0; j < abe.a(); j++)
					{
						if (abe.a(j).hy() == ag9.g)
						{
							if (this.a((abj)abe.a(j)) < 1)
							{
								c5 c = new c5((abj)abe.a(j), this.e);
								c.a((c5)this.a[i], null, this.c, this.d, this.b);
								base.a(this.a++, c);
								c.a(j);
							}
							else
							{
								this.a((c5)this.a[i], abe.a(j), j);
							}
						}
						else if (abe.a(j).hy() == ag9.j && abe.a(j).h6().hy() == ag9.g)
						{
							if (this.a((abj)abe.a(j).h6()) < 1)
							{
								c5 c = new c5((abj)abe.a(j).h6(), this.e);
								c.a((c5)this.a[i], null, this.c, this.d, this.b);
								base.a(this.a++, c);
								c.a(j);
							}
							else
							{
								this.a((c5)this.a[i], abe.a(j), j);
							}
						}
						else
						{
							this.a((c5)this.a[i], abe.a(j), j);
						}
					}
					abe = null;
				}
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00061664 File Offset: 0x00060664
		private new int a(abj A_0)
		{
			int result = 0;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 5479461)
				{
					if (((abu)abk.c()).j9().Equals("MCR"))
					{
						result = 1;
						break;
					}
					if (((abu)abk.c()).j9().Equals("OBJR"))
					{
						result = 2;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00061700 File Offset: 0x00060700
		private new void a(abj A_0, int A_1, c5 A_2, int A_3)
		{
			abk abk = A_0.l();
			ab6 ab = null;
			abd abd = null;
			int num = -1;
			acb acb = null;
			PdfFormField pdfFormField = null;
			while (abk != null)
			{
				int num2 = abk.a().j8();
				if (num2 <= 63658)
				{
					if (num2 != 1063)
					{
						if (num2 == 63658)
						{
							int num3 = A_2.l();
							if (abk.c().hy() != ag9.i)
							{
								ab6 ab2 = (ab6)abk.c();
								if (A_2.a().Equals("Form"))
								{
									for (int i = 0; i < ab2.b().Form.Fields.Count; i++)
									{
										if (ab2.b().Form.Fields[i].l() == ab2.c())
										{
											pdfFormField = ab2.b().Form.Fields[i];
											break;
										}
									}
								}
								else if (A_2.f() != null || ab != null)
								{
									abp[] array = null;
									if (A_2.f() != null)
									{
										if (A_2.f().a().h().j() != null)
										{
											array = A_2.f().a().h().j().a();
										}
									}
									else if (ab != null && ab.a().h() != null)
									{
										array = ab.a().h().j().a();
									}
									if (array != null)
									{
										for (int i = 0; i < array.Length; i++)
										{
											if (array[i] != null)
											{
												abp abp = array[i];
												if (abp.a() == ab2.c())
												{
													if (!(abp is abq))
													{
														acb = (acb)abp;
														break;
													}
													for (int j = 0; j < ab2.b().Form.Fields.Count; j++)
													{
														if (ab2.b().Form.Fields[j].l() == ab2.c())
														{
															pdfFormField = ab2.b().Form.Fields[j];
															break;
														}
													}
												}
											}
										}
									}
								}
								else
								{
									PdfPageList pages = ab2.b().Pages;
									for (int i = 0; i < pages.Count; i++)
									{
										if (pages[i].j() != null)
										{
											abp[] array2 = pages[i].j().a();
											if (array2 != null)
											{
												for (int k = 0; k < array2.Length; k++)
												{
													if (array2[k] != null)
													{
														abp abp = array2[k];
														if (abp.a() == ab2.c())
														{
															if (!(abp is abq))
															{
																acb = (acb)abp;
																break;
															}
															for (int j = 0; j < ab2.b().Form.Fields.Count; j++)
															{
																if (ab2.b().Form.Fields[j].l() == ab2.c())
																{
																	pdfFormField = ab2.b().Form.Fields[j];
																	break;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
							abk.a(false);
						}
					}
					else
					{
						ab = (ab6)abk.c();
					}
				}
				else if (num2 != 81197)
				{
					if (num2 == 3420740)
					{
						num = ((abw)abk.c()).kd();
					}
				}
				else
				{
					abd = abk.c();
				}
				abk = abk.d();
			}
			if (pdfFormField != null && pdfFormField.g() == null && A_2.bt())
			{
				bool flag = false;
				if (ab != null)
				{
					if (this.a(ab.a().h().e()))
					{
						flag = true;
					}
				}
				else if (A_2.f() != null)
				{
					if (this.a(A_2.f().a().h().e()))
					{
						flag = true;
					}
				}
				if (flag)
				{
					pdfFormField.a(A_2);
					A_2.a(new int[2]);
					A_2.c()[0] = pdfFormField.ac();
				}
			}
			if (acb != null && A_2.bt() && acb.b() == null)
			{
				bool flag = false;
				if (ab != null)
				{
					if (this.a(ab.a().h().e()))
					{
						flag = true;
					}
				}
				else if (A_2.f() != null)
				{
					if (this.a(A_2.f().a().h().e()))
					{
						flag = true;
					}
				}
				if (flag)
				{
					acb.a(A_2);
					A_2.a(new int[2]);
					A_2.c()[0] = acb.c();
				}
			}
			if (A_1 == 1)
			{
				c4 c;
				if (ab != null)
				{
					if (ab.a() != null && ab.a().h() != null && ab.a().h().o() < num)
					{
						ab.a().h().a(num);
					}
					c = new c4(ab, A_0);
					if (abd != null)
					{
						c.bo(true);
					}
					else
					{
						c.a(num);
					}
					if (ab.a() != null && ab.a().h() != null)
					{
						if (this.a(ab.a().h().e()))
						{
							A_2.a(c);
						}
					}
				}
				else
				{
					c = new c4(A_2.f(), A_0);
					if (abd != null)
					{
						c.bo(true);
					}
					else
					{
						c.a(num);
					}
					if (A_2.f() != null)
					{
						if (this.a(A_2.f().a().h().e()))
						{
							A_2.a(c);
						}
					}
					else
					{
						A_2.a(c);
					}
				}
				c.b(A_3);
			}
			else if (A_1 == 2)
			{
				c3 c2;
				if (ab != null)
				{
					c2 = new c3(ab, A_0);
					if (ab.a() != null && ab.a().h() != null && this.a(ab.a().h().e()))
					{
						A_2.a(c2);
					}
				}
				else
				{
					c2 = new c3(A_2.f(), A_0);
					if (A_2.f() != null && this.a(A_2.f().a().h().e()))
					{
						A_2.a(c2);
					}
				}
				c2.b(A_3);
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00061F4C File Offset: 0x00060F4C
		private new bool a(int A_0)
		{
			return A_0 >= this.c - 1 && A_0 < this.d + (this.c - 1);
		}

		// Token: 0x040003C4 RID: 964
		private new int a = 0;

		// Token: 0x040003C5 RID: 965
		private r2 b = null;

		// Token: 0x040003C6 RID: 966
		private int c = 0;

		// Token: 0x040003C7 RID: 967
		private int d = 0;

		// Token: 0x040003C8 RID: 968
		private int e = 0;
	}
}
