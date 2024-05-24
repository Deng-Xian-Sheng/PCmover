using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200070C RID: 1804
	public class Row2
	{
		// Token: 0x0600470B RID: 18187 RVA: 0x00245CAC File Offset: 0x00244CAC
		internal int a()
		{
			return this.f;
		}

		// Token: 0x0600470C RID: 18188 RVA: 0x00245CC4 File Offset: 0x00244CC4
		internal void a(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600470D RID: 18189 RVA: 0x00245CCE File Offset: 0x00244CCE
		internal Row2()
		{
		}

		// Token: 0x0600470E RID: 18190 RVA: 0x00245CFC File Offset: 0x00244CFC
		internal Row2(qy A_0, float A_1, Font A_2, float? A_3, Color A_4, Color A_5)
		{
			if (A_1 <= 0f)
			{
				A_1 = 0f;
				this.e = false;
			}
			this.a = A_1;
			this.b = A_1;
			this.l = A_1;
			this.c = A_0;
			if (A_2 != null)
			{
				this.CellDefault.Font = A_2;
			}
			if (A_3 != null)
			{
				this.CellDefault.FontSize = A_3;
			}
			if (A_4 != null)
			{
				this.CellDefault.TextColor = A_4;
			}
			if (A_5 != null)
			{
				this.CellDefault.BackgroundColor = A_5;
			}
			this.d = new Cell2List(this, A_0.c().Count);
		}

		// Token: 0x0600470F RID: 18191 RVA: 0x00245DE4 File Offset: 0x00244DE4
		internal Row2(qy A_0, float A_1, CellDefault A_2)
		{
			if (A_1 <= 0f)
			{
				A_1 = 0f;
				this.e = false;
			}
			this.a = A_1;
			this.b = A_1;
			this.l = A_1;
			this.c = A_0;
			if (A_2 != null)
			{
				this.g = A_2;
			}
			this.d = new Cell2List(this, A_0.c().Count);
		}

		// Token: 0x06004710 RID: 18192 RVA: 0x00245E80 File Offset: 0x00244E80
		internal void a(q0 A_0, bool A_1, int A_2)
		{
			this.j = new qv[0];
			int num = 0;
			float num2 = this.c.n().Left.Width.Value;
			if (A_0.d().b().f() > 0 && A_0.d().i() > 0)
			{
				int num3 = A_0.d().b().f() - 1;
				for (int i = 0; i <= num3; i++)
				{
					int num4 = i;
					int a_ = i;
					if (i >= A_0.d().b().c().Count)
					{
						break;
					}
					A_0.d().b().e(num4);
					num4 += A_0.d().b().c()[num4].b() - 1;
					if (num4 > num3)
					{
						num3 = num4;
					}
					Cell2 cell = A_0.d().b().e()[i, A_2];
					if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
					{
						if (!A_1)
						{
							cell.a(A_0, a_, null);
							if (num >= this.j.Length)
							{
								this.j = this.a(this.j);
							}
							this.j[num] = new qv(cell.p(), cell.q(), cell.r(), cell.s());
							num++;
						}
						else
						{
							cell.a(A_0, a_);
						}
					}
					else if (cell != null && cell.t() != -1)
					{
						if (cell.u() != A_2)
						{
							A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num2));
						}
					}
				}
			}
			for (int i = A_0.d().i(); i <= A_0.d().j(); i++)
			{
				Cell2 cell = A_0.d().b().e()[i, A_2];
				int a_;
				if (i == A_0.d().i() && (A_0.d().b().f() <= 0 || A_0.d().i() <= 0))
				{
					a_ = 0;
				}
				else
				{
					a_ = i;
				}
				if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
				{
					if (!A_1)
					{
						cell.a(A_0, a_, null);
						if (num >= this.j.Length)
						{
							this.j = this.a(this.j);
						}
						this.j[num] = new qv(cell.p(), cell.q(), cell.r(), cell.s());
						num++;
					}
					else
					{
						cell.a(A_0, a_);
					}
					num2 = 0f;
				}
				else if (cell != null && cell.t() != -1)
				{
					if (cell.u() != A_2)
					{
						A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num2));
						num2 = 0f;
					}
				}
			}
			A_0.b(A_0.b() + (this.b + A_0.d().CellSpacing));
			A_0.a(A_0.d().X);
		}

		// Token: 0x06004711 RID: 18193 RVA: 0x002462B8 File Offset: 0x002452B8
		internal void a(q0 A_0, bool A_1, int A_2, StructureElement A_3)
		{
			StructureElement a_ = null;
			TagOptions a_2 = null;
			this.a(A_0, A_1, A_3, ref a_, ref a_2);
			this.j = new qv[0];
			int num = 0;
			float num2 = this.c.n().Left.Width.Value;
			if (A_0.d().b().f() > 0 && A_0.d().i() > 0)
			{
				int num3 = A_0.d().b().f() - 1;
				for (int i = 0; i <= num3; i++)
				{
					int num4 = i;
					int a_3 = i;
					if (i >= A_0.d().b().c().Count)
					{
						break;
					}
					A_0.d().b().e(num4);
					num4 += A_0.d().b().c()[num4].b() - 1;
					if (num4 > num3)
					{
						num3 = num4;
					}
					Cell2 cell = A_0.d().b().e()[i, A_2];
					if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
					{
						if (!A_1)
						{
							cell.a(A_0, a_3, null);
							if (num >= this.j.Length)
							{
								this.j = this.a(this.j);
							}
							this.j[num] = new qv(cell.p(), cell.q(), cell.r(), cell.s());
							num++;
						}
						else
						{
							cell.a(A_0, a_3, a_);
						}
					}
					else if (cell != null && cell.t() != -1)
					{
						if (cell.u() != A_2)
						{
							A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num2));
						}
					}
				}
			}
			for (int i = A_0.d().i(); i <= A_0.d().j(); i++)
			{
				if (A_0.c().Document.Tag != null)
				{
					if (!this.c.q() && A_1)
					{
						if (this.c.f() - i <= 0)
						{
							this.c.g(true);
						}
					}
				}
				Cell2 cell = A_0.d().b().e()[i, A_2];
				int a_3;
				if (i == A_0.d().i() && (A_0.d().b().f() <= 0 || A_0.d().i() <= 0))
				{
					a_3 = 0;
				}
				else
				{
					a_3 = i;
				}
				if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
				{
					if (!A_1)
					{
						cell.a(A_0, a_3, null);
						if (num >= this.j.Length)
						{
							this.j = this.a(this.j);
						}
						this.j[num] = new qv(cell.p(), cell.q(), cell.r(), cell.s());
						num++;
					}
					else
					{
						cell.a(A_0, a_3, a_);
					}
					num2 = 0f;
				}
				else if (cell != null && cell.t() != -1)
				{
					if (cell.u() != A_2)
					{
						A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num2));
					}
				}
			}
			A_0.b(A_0.b() + (this.b + A_0.d().CellSpacing));
			A_0.a(A_0.d().X);
			this.a(A_0, A_1, a_2);
		}

		// Token: 0x06004712 RID: 18194 RVA: 0x00246774 File Offset: 0x00245774
		internal void b(q0 A_0, bool A_1, int A_2, Row2 A_3)
		{
			float num = this.c.n().Left.Width.Value;
			if (A_0.d().b().f() > 0 && A_0.d().i() > 0)
			{
				int num2 = A_0.d().b().f() - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = i;
					int a_ = i;
					if (i >= A_0.d().b().c().Count)
					{
						break;
					}
					A_0.d().b().e(num3);
					num3 += A_0.d().b().c()[num3].b() - 1;
					if (num3 > num2)
					{
						num2 = num3;
					}
					Cell2 cell = A_0.d().b().e()[i, A_2];
					if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
					{
						if (!A_1)
						{
							if (this.e().u()[i, A_2].b().d() && this.e().u()[i, A_2].b().b() && this.e().u()[i, A_2].b().c())
							{
								cell.b(A_0, a_, null);
							}
							else
							{
								cell.c(A_0, a_, null);
							}
						}
						else
						{
							cell.a(A_0, a_);
						}
					}
					else if (cell != null && cell.t() != -1)
					{
						if (cell.u() != A_2)
						{
							A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num));
							num = 0f;
						}
					}
				}
			}
			if (A_3 == null)
			{
				for (int i = A_0.d().i(); i <= A_0.d().j(); i++)
				{
					Cell2 cell = A_0.d().b().e()[i, A_2];
					int a_;
					if (i == A_0.d().i() && (A_0.d().b().f() <= 0 || A_0.d().i() <= 0))
					{
						a_ = 0;
					}
					else
					{
						a_ = i;
					}
					if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
					{
						if (!A_1)
						{
							if (this.e().u()[i, A_2].b().d() && this.e().u()[i, A_2].b().b() && this.e().u()[i, A_2].b().c())
							{
								cell.b(A_0, a_, null);
							}
							else
							{
								cell.c(A_0, a_, null);
							}
						}
						else
						{
							cell.a(A_0, a_);
						}
						num = 0f;
					}
					else if (cell != null && cell.t() != -1)
					{
						if (cell.u() != A_2)
						{
							A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num));
							num = 0f;
						}
					}
				}
			}
			else
			{
				this.a(A_0, A_1, A_2, A_3);
			}
			if (A_3 != null)
			{
				A_0.b(A_0.b() + (this.l + A_0.d().CellSpacing));
			}
			else
			{
				A_0.b(A_0.b() + (this.b + A_0.d().CellSpacing));
			}
			A_0.a(A_0.d().X);
		}

		// Token: 0x06004713 RID: 18195 RVA: 0x00246C2C File Offset: 0x00245C2C
		private void a(q0 A_0, bool A_1, int A_2, Row2 A_3)
		{
			int value = this.a(A_3);
			float num = this.c.n().Left.Width.Value;
			for (int i = A_0.d().i(); i <= A_0.d().j(); i++)
			{
				Cell2 cell = null;
				bool flag = true;
				for (int j = A_0.d().i(); j <= A_0.d().j(); j++)
				{
					if (A_3.Cells[j] != null && A_3.Cells[j].t() == i)
					{
						cell = A_3.Cells[j];
						break;
					}
				}
				if (cell == null)
				{
					flag = false;
					cell = A_0.d().b().e()[i, A_2];
				}
				int a_;
				if (i == A_0.d().i() && (A_0.d().b().f() <= 0 || A_0.d().i() <= 0))
				{
					a_ = 0;
				}
				else
				{
					a_ = i;
				}
				if (cell != null && cell.t() != -1 && cell.t() == i && (cell.u() == A_2 || flag))
				{
					if (!A_1)
					{
						if (this.e().u()[i, A_2].b().d() && this.e().u()[i, A_2].b().b() && this.e().u()[i, A_2].b().c())
						{
							cell.b(A_0, a_, new int?(value));
						}
						else
						{
							cell.c(A_0, a_, new int?(value));
						}
					}
					else
					{
						cell.a(A_0, a_);
					}
					num = 0f;
				}
				else if (cell != null && cell.t() != -1)
				{
					if (cell.u() != A_2)
					{
						A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num));
						num = 0f;
					}
				}
			}
		}

		// Token: 0x06004714 RID: 18196 RVA: 0x00246EC4 File Offset: 0x00245EC4
		internal void a(q0 A_0, bool A_1, int A_2, StructureElement A_3, Row2 A_4)
		{
			StructureElement structureElement = null;
			TagOptions a_ = null;
			this.a(A_0, A_1, A_3, ref structureElement, ref a_);
			float num = this.c.n().Left.Width.Value;
			if (A_0.d().b().f() > 0 && A_0.d().i() > 0)
			{
				int num2 = A_0.d().b().f() - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = i;
					int a_2 = i;
					if (i >= A_0.d().b().c().Count)
					{
						break;
					}
					A_0.d().b().e(num3);
					num3 += A_0.d().b().c()[num3].b() - 1;
					if (num3 > num2)
					{
						num2 = num3;
					}
					Cell2 cell = A_0.d().b().e()[i, A_2];
					if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
					{
						if (!A_1)
						{
							if (this.e().u()[i, A_2].b().d() && this.e().u()[i, A_2].b().b() && this.e().u()[i, A_2].b().c())
							{
								cell.b(A_0, a_2, null);
							}
							else
							{
								cell.c(A_0, a_2, null);
							}
						}
						else
						{
							cell.a(A_0, a_2, structureElement);
						}
					}
					else if (cell != null && cell.t() != -1)
					{
						if (cell.u() != A_2)
						{
							A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num));
						}
					}
				}
			}
			if (A_4 == null)
			{
				for (int i = A_0.d().i(); i <= A_0.d().j(); i++)
				{
					if (A_0.c().Document.Tag != null)
					{
						if (!this.c.q() && A_1)
						{
							if (this.c.f() - i <= 0)
							{
								this.c.g(true);
							}
						}
					}
					Cell2 cell = A_0.d().b().e()[i, A_2];
					int a_2;
					if (i == A_0.d().i() && (A_0.d().b().f() <= 0 || A_0.d().i() <= 0))
					{
						a_2 = 0;
					}
					else
					{
						a_2 = i;
					}
					if (cell != null && cell.t() != -1 && cell.t() == i && cell.u() == A_2)
					{
						if (!A_1)
						{
							if (this.e().u()[i, A_2].b().d() && this.e().u()[i, A_2].b().b() && this.e().u()[i, A_2].b().c())
							{
								cell.b(A_0, a_2, null);
							}
							else
							{
								cell.c(A_0, a_2, null);
							}
						}
						else
						{
							cell.a(A_0, a_2, structureElement);
						}
						num = 0f;
					}
					else if (cell != null && cell.t() != -1)
					{
						if (cell.u() != A_2)
						{
							A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num));
						}
					}
				}
			}
			else
			{
				this.a(A_0, A_1, A_2, A_4, structureElement);
			}
			if (A_4 != null)
			{
				A_0.b(A_0.b() + (this.l + A_0.d().CellSpacing));
			}
			else
			{
				A_0.b(A_0.b() + (this.b + A_0.d().CellSpacing));
			}
			A_0.a(A_0.d().X);
			this.a(A_0, A_1, a_);
		}

		// Token: 0x06004715 RID: 18197 RVA: 0x0024740C File Offset: 0x0024640C
		private void a(q0 A_0, bool A_1, int A_2, Row2 A_3, StructureElement A_4)
		{
			PageWriter pageWriter = A_0.c();
			if (A_1)
			{
				if (pageWriter.Document.Tag != null)
				{
					StructureElement structureElement;
					if (A_0.d().Tag == null)
					{
						if (A_0.d().k() != null && A_0.d().k().Tag != null)
						{
							structureElement = (StructureElement)A_0.d().k().Tag;
						}
						else
						{
							structureElement = new StructureElement(TagType.Table);
							if (A_0.d().k() != null)
							{
								A_0.d().k().Tag = structureElement;
							}
						}
					}
					else
					{
						structureElement = (StructureElement)A_0.d().Tag;
					}
					if (pageWriter.k() != null)
					{
						structureElement.Parent = pageWriter.k();
					}
					if (this.c.h() > 0)
					{
						this.c.h(false);
					}
				}
			}
			int value = this.a(A_3);
			float num = this.c.n().Left.Width.Value;
			for (int i = A_0.d().i(); i <= A_0.d().j(); i++)
			{
				if (A_0.c().Document.Tag != null)
				{
					if (!this.c.q() && A_1)
					{
						if (this.c.f() - i <= 0)
						{
							this.c.g(true);
						}
					}
				}
				Cell2 cell = null;
				bool flag = true;
				for (int j = A_0.d().i(); j <= A_0.d().j(); j++)
				{
					if (A_3.Cells[j] != null && A_3.Cells[j].t() == i)
					{
						cell = A_3.Cells[j];
						break;
					}
				}
				if (cell == null)
				{
					flag = false;
					cell = A_0.d().b().e()[i, A_2];
				}
				int a_;
				if (i == A_0.d().i() && (A_0.d().b().f() <= 0 || A_0.d().i() <= 0))
				{
					a_ = 0;
				}
				else
				{
					a_ = i;
				}
				if (cell != null && cell.t() != -1 && cell.t() == i && (cell.u() == A_2 || flag))
				{
					if (!A_1)
					{
						if (this.e().u()[i, A_2].b().d() && this.e().u()[i, A_2].b().b() && this.e().u()[i, A_2].b().c())
						{
							cell.b(A_0, a_, new int?(value));
						}
						else
						{
							cell.c(A_0, a_, new int?(value));
						}
					}
					else
					{
						cell.a(A_0, a_, A_4);
					}
					num = 0f;
				}
				else if (cell != null && cell.t() != -1)
				{
					if (cell.u() != A_2)
					{
						A_0.a(A_0.a() + (this.c.c()[i].Width + this.c.o() + num));
					}
				}
			}
		}

		// Token: 0x06004716 RID: 18198 RVA: 0x00247828 File Offset: 0x00246828
		private int a(Row2 A_0)
		{
			int num = -1;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].u() > num)
				{
					num = A_0.Cells[i].u();
				}
			}
			return num;
		}

		// Token: 0x06004717 RID: 18199 RVA: 0x00247888 File Offset: 0x00246888
		internal void b()
		{
			this.b = this.a;
			this.l = this.a;
			foreach (object obj in this.d)
			{
				Cell2 cell = (Cell2)obj;
				if (cell != null && cell.t() != -1)
				{
					if (cell.RowSpan == 1)
					{
						float num = cell.a(true);
						if (num > this.b)
						{
							this.b = num;
							this.l = num;
						}
					}
				}
			}
		}

		// Token: 0x06004718 RID: 18200 RVA: 0x00247954 File Offset: 0x00246954
		internal void b(int A_0)
		{
			foreach (object obj in this.d)
			{
				Cell2 cell = (Cell2)obj;
				if (cell != null && cell.t() != -1)
				{
					if (cell.RowSpan == 1)
					{
						float num = cell.a(false);
						if (num > this.b)
						{
							this.b = num;
							this.l = this.b;
						}
					}
					else
					{
						float num = cell.a(true);
						float num2 = 0f;
						float num3 = 0f;
						bool flag = this.a(cell, A_0, ref num2, ref num3);
						if (num > num2)
						{
							float num4 = num - num2;
							if (flag)
							{
								for (int i = A_0; i < A_0 + cell.RowSpan; i++)
								{
									if (i < this.c.d().Count)
									{
										Row2 row = this.c.d()[i];
										row.a(row.f() + this.c.d()[i].f() / num2 * num4);
										this.c.d()[i].b(this.c.d()[i].f());
									}
								}
							}
							else
							{
								for (int i = A_0; i < A_0 + cell.RowSpan; i++)
								{
									if (i < this.c.d().Count && !this.c.d()[i].h())
									{
										Row2 row2 = this.c.d()[i];
										row2.a(row2.f() + this.c.d()[i].f() / num3 * num4);
										this.c.d()[i].b(this.c.d()[i].f());
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06004719 RID: 18201 RVA: 0x00247C04 File Offset: 0x00246C04
		internal void c(int A_0)
		{
			foreach (object obj in this.d)
			{
				Cell2 cell = (Cell2)obj;
				if (cell != null && cell.t() != -1)
				{
					if (!cell.Splittable)
					{
						if (cell.RowSpan == 1)
						{
							float num = cell.a(false);
							if (num > this.b)
							{
								this.b = num;
								this.l = this.b;
							}
						}
						else
						{
							float num = cell.a(false);
							float num2 = 0f;
							float num3 = 0f;
							bool flag = this.a(cell, A_0, ref num2, ref num3);
							if (num > num2)
							{
								float num4 = num - num2;
								if (flag)
								{
									for (int i = A_0; i < A_0 + cell.RowSpan; i++)
									{
										if (i < this.c.d().Count)
										{
											Row2 row = this.c.d()[i];
											row.a(row.f() + this.c.d()[i].f() / num2 * num4);
											this.c.d()[i].b(this.c.d()[i].f());
										}
									}
								}
								else
								{
									for (int i = A_0; i < A_0 + cell.RowSpan; i++)
									{
										if (i < this.c.d().Count && !this.c.d()[i].h())
										{
											Row2 row2 = this.c.d()[i];
											row2.a(row2.f() + this.c.d()[i].f() / num3 * num4);
											this.c.d()[i].b(this.c.d()[i].f());
										}
									}
								}
							}
						}
					}
					else
					{
						cell.a(false);
					}
				}
			}
		}

		// Token: 0x0600471A RID: 18202 RVA: 0x00247ECC File Offset: 0x00246ECC
		internal void b(int A_0, Cell2[,] A_1)
		{
			foreach (object obj in this.d)
			{
				Cell2 cell = (Cell2)obj;
				if (cell != null)
				{
					int i = this.a(A_0, A_1);
					if (i == -1)
					{
						cell.e(-1);
						cell.f(-1);
					}
					else
					{
						if (cell.RowSpan == 1 && cell.ColumnSpan == 1)
						{
							cell.e(i);
							cell.f(A_0);
							A_1[i, A_0] = cell;
						}
						else if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
						{
							cell.e(i);
							cell.f(A_0);
							int num = i;
							while (i < num + cell.ColumnSpan)
							{
								if (i < this.c.c().Count)
								{
									for (int j = A_0; j < A_0 + cell.RowSpan; j++)
									{
										if (j < this.c.d().Count)
										{
											A_1[i, j] = cell;
										}
									}
								}
								i++;
							}
						}
						cell.b();
					}
				}
			}
		}

		// Token: 0x0600471B RID: 18203 RVA: 0x00248078 File Offset: 0x00247078
		internal Row2 a(qy A_0)
		{
			Row2 row = new Row2();
			row.a = this.a;
			row.b = this.b;
			row.c = A_0;
			row.d = new Cell2List(row, A_0.c().Count);
			for (int i = 0; i < this.Cells.Count; i++)
			{
				row.d.a(this.Cells[i].a(row, A_0));
			}
			row.e = this.e;
			row.f = this.f;
			row.g = new CellDefault(A_0);
			if (this.g != null && this.g.a() != null)
			{
				row.g.a(this.g.a().m());
			}
			if (this.g != null && this.g.b() != null)
			{
				row.g.a(this.g.b().b(A_0));
			}
			if (this.g != null && this.g.c() != null)
			{
				row.g.a(this.g.c().a(A_0));
			}
			row.h = this.h;
			row.i = this.i;
			if (this.j != null)
			{
				for (int i = 0; i < this.j.Length; i++)
				{
					row.j[i] = new qv(this.j[i].a(), this.j[i].b(), this.j[i].c(), this.j[i].d());
				}
			}
			row.k = this.k;
			row.l = this.l;
			return row;
		}

		// Token: 0x0600471C RID: 18204 RVA: 0x00248290 File Offset: 0x00247290
		private bool a(Cell2 A_0, int A_1, ref float A_2, ref float A_3)
		{
			for (int i = A_1; i < A_1 + A_0.RowSpan; i++)
			{
				if (i < this.c.d().Count)
				{
					A_2 += this.c.d()[i].f();
					if (!this.c.d()[i].h())
					{
						A_3 += this.c.d()[i].f() + this.c.o();
					}
				}
			}
			return A_3 == 0f || A_3 == A_2;
		}

		// Token: 0x0600471D RID: 18205 RVA: 0x00248360 File Offset: 0x00247360
		private int a(int A_0, Cell2[,] A_1)
		{
			int num = 0;
			while (A_1[num, A_0] != null)
			{
				num++;
				if (num == this.c.c().Count)
				{
					return -1;
				}
			}
			return num;
		}

		// Token: 0x0600471E RID: 18206 RVA: 0x002483B0 File Offset: 0x002473B0
		private void a(q0 A_0, bool A_1, TagOptions A_2)
		{
			if (A_1 && A_2 != null && this.h != null && !this.h.g())
			{
				Tag.a(A_0.c());
				A_0.c().Document.Tag = A_2;
			}
		}

		// Token: 0x0600471F RID: 18207 RVA: 0x00248400 File Offset: 0x00247400
		private void a(q0 A_0, bool A_1, StructureElement A_2, ref StructureElement A_3, ref TagOptions A_4)
		{
			if (A_1)
			{
				PageWriter pageWriter = A_0.c();
				if (pageWriter.Document.Tag != null)
				{
					if (this.h == null)
					{
						A_3 = new StructureElement(TagType.TableRow);
						A_3.a(false);
						A_3.Parent = A_2;
						A_3.Order = this.i;
						pageWriter.Document.j().e(A_3);
					}
					else if (this.h.g())
					{
						A_3 = (StructureElement)this.h;
						if (!A_3.u())
						{
							if (A_3.Parent == null)
							{
								A_3.Parent = A_2;
							}
							if (A_0.d().Tag == null)
							{
								A_0.d().Tag = A_2;
							}
							pageWriter.Document.j().e(A_3);
							A_3.a(A_0, this);
						}
						else if (((StructureElement)this.h).o() != null && ((StructureElement)this.h).o().Count > 0)
						{
							A_3.a(A_0, this);
						}
					}
					else
					{
						pageWriter.SetTextMode();
						((Artifact)this.Tag).a(pageWriter, null, this, A_0, true);
						A_4 = pageWriter.Document.Tag;
						pageWriter.Document.Tag = null;
					}
					if (this.c.f() > 0)
					{
						this.c.g(false);
					}
				}
			}
		}

		// Token: 0x06004720 RID: 18208 RVA: 0x002485C8 File Offset: 0x002475C8
		private qv[] a(qv[] A_0)
		{
			qv[] array = new qv[A_0.Length + 1];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			A_0 = array;
			return A_0;
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06004721 RID: 18209 RVA: 0x002485F8 File Offset: 0x002475F8
		public CellDefault CellDefault
		{
			get
			{
				if (this.g == null)
				{
					this.g = new CellDefault(this.c);
				}
				return this.g;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06004722 RID: 18210 RVA: 0x00248634 File Offset: 0x00247634
		// (set) Token: 0x06004723 RID: 18211 RVA: 0x0024864C File Offset: 0x0024764C
		public float Height
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.c.a(true);
				this.c.c(true);
				this.e = true;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06004724 RID: 18212 RVA: 0x00248678 File Offset: 0x00247678
		public Cell2List Cells
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06004725 RID: 18213 RVA: 0x00248690 File Offset: 0x00247690
		public float ActualRowHeight
		{
			get
			{
				if (this.c.l())
				{
					if (this.c.m())
					{
						this.c.ac();
					}
					this.c.ad();
				}
				return this.b;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06004726 RID: 18214 RVA: 0x002486E8 File Offset: 0x002476E8
		// (set) Token: 0x06004727 RID: 18215 RVA: 0x00248700 File Offset: 0x00247700
		public Tag Tag
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
				if (this.h != null && this.h.g())
				{
					((StructureElement)this.h).a(false);
				}
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06004728 RID: 18216 RVA: 0x00248748 File Offset: 0x00247748
		// (set) Token: 0x06004729 RID: 18217 RVA: 0x00248760 File Offset: 0x00247760
		public int TagOrder
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x0600472A RID: 18218 RVA: 0x0024876C File Offset: 0x0024776C
		internal bool c()
		{
			return this.k;
		}

		// Token: 0x0600472B RID: 18219 RVA: 0x00248784 File Offset: 0x00247784
		internal void a(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600472C RID: 18220 RVA: 0x00248790 File Offset: 0x00247790
		internal CellDefault d()
		{
			return this.g;
		}

		// Token: 0x0600472D RID: 18221 RVA: 0x002487A8 File Offset: 0x002477A8
		internal qy e()
		{
			return this.c;
		}

		// Token: 0x0600472E RID: 18222 RVA: 0x002487C0 File Offset: 0x002477C0
		internal float f()
		{
			return this.b;
		}

		// Token: 0x0600472F RID: 18223 RVA: 0x002487D8 File Offset: 0x002477D8
		internal void a(float A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004730 RID: 18224 RVA: 0x002487E4 File Offset: 0x002477E4
		internal float g()
		{
			return this.l;
		}

		// Token: 0x06004731 RID: 18225 RVA: 0x002487FC File Offset: 0x002477FC
		internal void b(float A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06004732 RID: 18226 RVA: 0x00248808 File Offset: 0x00247808
		internal bool h()
		{
			return this.e;
		}

		// Token: 0x06004733 RID: 18227 RVA: 0x00248820 File Offset: 0x00247820
		internal qv[] i()
		{
			return this.j;
		}

		// Token: 0x0400271A RID: 10010
		private float a;

		// Token: 0x0400271B RID: 10011
		private float b;

		// Token: 0x0400271C RID: 10012
		private qy c;

		// Token: 0x0400271D RID: 10013
		private Cell2List d;

		// Token: 0x0400271E RID: 10014
		private bool e = true;

		// Token: 0x0400271F RID: 10015
		private int f = 1;

		// Token: 0x04002720 RID: 10016
		private CellDefault g;

		// Token: 0x04002721 RID: 10017
		private Tag h;

		// Token: 0x04002722 RID: 10018
		private int i = 0;

		// Token: 0x04002723 RID: 10019
		private qv[] j = null;

		// Token: 0x04002724 RID: 10020
		private bool k = false;

		// Token: 0x04002725 RID: 10021
		private float l;
	}
}
