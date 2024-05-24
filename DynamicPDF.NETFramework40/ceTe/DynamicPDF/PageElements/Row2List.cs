using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200070D RID: 1805
	public class Row2List : IEnumerable
	{
		// Token: 0x06004734 RID: 18228 RVA: 0x00248838 File Offset: 0x00247838
		internal Row2List()
		{
		}

		// Token: 0x06004735 RID: 18229 RVA: 0x00248850 File Offset: 0x00247850
		public Row2 Add()
		{
			return this.Add(0.001f, null, null, null, null);
		}

		// Token: 0x06004736 RID: 18230 RVA: 0x0024887C File Offset: 0x0024787C
		public Row2 Add(float height)
		{
			return this.Add(height, null, null, null, null);
		}

		// Token: 0x06004737 RID: 18231 RVA: 0x002488A4 File Offset: 0x002478A4
		public Row2 Add(Font font, float? fontSize)
		{
			return this.Add(0.001f, font, fontSize, null, null);
		}

		// Token: 0x06004738 RID: 18232 RVA: 0x002488C8 File Offset: 0x002478C8
		public Row2 Add(float height, Font font, float? fontSize)
		{
			return this.Add(height, font, fontSize, null, null);
		}

		// Token: 0x06004739 RID: 18233 RVA: 0x002488E8 File Offset: 0x002478E8
		public Row2 Add(Font font, float? fontSize, Color textColor, Color backColor)
		{
			return this.Add(0.001f, font, fontSize, textColor, backColor);
		}

		// Token: 0x0600473A RID: 18234 RVA: 0x0024890C File Offset: 0x0024790C
		public Row2 Add(float height, Font font, float? fontSize, Color textColor, Color backColor)
		{
			Row2 row = new Row2(this.b, height, font, fontSize, textColor, backColor);
			this.a.Add(row);
			this.b.d(true);
			this.b.a(null);
			return row;
		}

		// Token: 0x0600473B RID: 18235 RVA: 0x00248959 File Offset: 0x00247959
		internal void a(Row2 A_0)
		{
			this.a.Add(A_0);
		}

		// Token: 0x0600473C RID: 18236 RVA: 0x0024896C File Offset: 0x0024796C
		internal void a(q0 A_0, bool A_1)
		{
			if (A_0.d().b().h() > 0 && A_0.d().g() > 0)
			{
				int num = A_0.d().b().h() - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i;
					A_0.d().b().d(num2);
					num2 += A_0.d().b().d()[num2].a() - 1;
					if (num2 > num)
					{
						num = num2;
					}
					this[i].b(A_0, A_1, i, null);
				}
			}
		}

		// Token: 0x0600473D RID: 18237 RVA: 0x00248A24 File Offset: 0x00247A24
		internal void a(q0 A_0, bool A_1, float A_2, float A_3, Table2 A_4, bool A_5)
		{
			this.c = new List<qz>();
			this.d = new List<qz>();
			bool flag = true;
			if (A_0.d().CellSpacing > 0f || !A_5)
			{
				if (A_5 && A_0.d().b().h() > 0 && A_0.d().g() > 0)
				{
					int num = A_0.d().b().h() - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = i;
						A_0.d().b().d(num2);
						num2 += A_0.d().b().d()[num2].a() - 1;
						if (num2 > num)
						{
							num = num2;
						}
						this[i].b(A_0, A_1, i, null);
					}
				}
				if (A_0.d().CellSpacing > 0f)
				{
					if (A_4.f() == null)
					{
						if (A_0.d().h() == this.b.d().Count)
						{
							for (int j = A_0.d().g(); j < A_0.d().h(); j++)
							{
								this[j].b(A_0, A_1, j, null);
							}
						}
						else
						{
							for (int j = A_0.d().g(); j <= A_0.d().h(); j++)
							{
								this[j].b(A_0, A_1, j, null);
							}
						}
					}
					else
					{
						int j = A_0.d().g();
						for (;;)
						{
							int num3 = j;
							if (!(num3 <= A_0.d().h() + A_4.f() - 1))
							{
								break;
							}
							this[j].b(A_0, A_1, j, null);
							j++;
						}
					}
				}
				else if (A_4.f() == null)
				{
					if (A_0.d().h() == this.b.d().Count)
					{
						for (int j = A_0.d().g(); j < A_0.d().h(); j++)
						{
							flag = this.a(j, A_0, A_1);
						}
					}
					else
					{
						for (int j = A_0.d().g(); j <= A_0.d().h(); j++)
						{
							flag = this.a(j, A_0, A_1);
						}
					}
				}
				else
				{
					int j = A_0.d().g();
					for (;;)
					{
						int num3 = j;
						if (!(num3 <= A_0.d().h() + A_4.f() - 1))
						{
							break;
						}
						flag = this.a(j, A_0, A_1);
						j++;
					}
				}
			}
			else
			{
				if (A_5 && A_0.d().b().h() > 0 && A_0.d().g() > 0)
				{
					int num = A_0.d().b().h() - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = i;
						A_0.d().b().d(num2);
						num2 += A_0.d().b().d()[num2].a() - 1;
						if (num2 > num)
						{
							num = num2;
						}
						this.a(i, A_0, A_1);
					}
				}
				for (int j = A_0.d().g(); j <= A_0.d().h(); j++)
				{
					flag = this.a(j, A_0, A_1);
				}
			}
			if (!flag)
			{
				this.b();
				this.d();
				this.c();
				this.a(A_2, A_3, A_0);
				this.a(A_0);
			}
		}

		// Token: 0x0600473E RID: 18238 RVA: 0x00248F4C File Offset: 0x00247F4C
		private bool a(int A_0, q0 A_1, bool A_2)
		{
			bool result = true;
			this[A_0].a(A_1, A_2, A_0);
			if (!A_2)
			{
				qv[] array = this[A_0].i();
				if (array.Length > 0)
				{
					if (this.c.Count > 0)
					{
						this.b(array);
						this.a();
					}
					else
					{
						this.b(array);
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600473F RID: 18239 RVA: 0x00248FC8 File Offset: 0x00247FC8
		private bool a(int A_0, q0 A_1, bool A_2, StructureElement A_3)
		{
			bool result = true;
			this[A_0].a(A_1, A_2, A_0, A_3);
			if (!A_2)
			{
				qv[] array = this[A_0].i();
				if (array.Length > 0)
				{
					if (this.c.Count > 0)
					{
						this.b(array);
						this.a();
					}
					else
					{
						this.b(array);
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06004740 RID: 18240 RVA: 0x00249044 File Offset: 0x00248044
		private void a(float A_0, float A_1, q0 A_2)
		{
			List<qz> list = new List<qz>();
			float num = this.e().n().Top.Width.Value;
			float num2 = this.e().n().Bottom.Width.Value;
			float num3 = this.e().n().Left.Width.Value;
			float num4 = this.e().n().Right.Width.Value;
			Color color = this.e().n().Left.Color;
			Color color2 = this.e().n().Right.Color;
			Color color3 = this.e().n().Top.Color;
			Color color4 = this.e().n().Bottom.Color;
			list.Add(new qz(A_2.d().X + num3 / 2f, A_2.d().Y, A_2.d().X + num3 / 2f, A_2.d().Y + A_1 + num, num3, color, this.e().n().Left.LineStyle));
			list.Add(new qz(A_2.d().X + A_0 + num3 + num4 / 2f, A_2.d().Y, A_2.d().X + A_0 + num3 + num4 / 2f, A_2.d().Y + A_1 + num, num4, color2, this.e().n().Right.LineStyle));
			list.Add(new qz(A_2.d().X, A_2.d().Y + num / 2f, A_2.d().X + A_0 + num3 + num4, A_2.d().Y + num / 2f, num, color3, this.e().n().Top.LineStyle));
			list.Add(new qz(A_2.d().X, A_2.d().Y + A_1 + num + num2 / 2f, A_2.d().X + A_0 + num3 + num4, A_2.d().Y + A_1 + num + num2 / 2f, num2, color4, this.e().n().Bottom.LineStyle));
			A_0 += num4;
			A_1 += num2;
			this.a(list, num3, num, A_1, A_0, A_2.d().Y, A_2.d().X);
		}

		// Token: 0x06004741 RID: 18241 RVA: 0x0024930C File Offset: 0x0024830C
		private void a(List<qz> A_0, float A_1, float A_2, float A_3, float A_4, float A_5, float A_6)
		{
			bool flag = false;
			qz qz = A_0[0];
			qz.b(qz.b() + 0.001f);
			qz qz2 = A_0[1];
			qz2.b(qz2.b() + 0.001f);
			qz qz3 = A_0[2];
			qz3.a(qz3.a() + 0.001f);
			qz qz4 = A_0[3];
			qz4.a(qz4.a() + 0.001f);
			if (A_0[0].g() != LineStyle.None && this.c.Count > 0 && this.c[0] != null)
			{
				float num = A_0[0].a() + A_0[0].e() / 2f + 0.001f;
				float num2 = this.c[0].a() - this.c[0].e() / 2f + 0.001f;
				float num3 = (num > num2) ? (num - num2) : (num2 - num);
				bool flag2 = num3 < 0.001f;
				if (flag2 && A_0[0].f().Equals(this.c[0].f()) && A_0[0].g().Equals(this.c[0].g()))
				{
					num3 = ((this.c[0].b() > A_5 + A_2) ? (this.c[0].b() + 0.001f - (A_5 + A_2 + 0.001f)) : (A_5 + A_2 + 0.001f - (this.c[0].b() + 0.001f)));
					flag2 = (num3 < 0.001f);
					if (flag2)
					{
						num3 = ((this.c[0].d() > A_3 + A_5) ? (this.c[0].d() + 0.001f - (A_3 + A_5 + 0.001f)) : (A_3 + A_5 + 0.001f - (this.c[0].d() + 0.001f)));
						flag2 = (num3 < 0.001f);
						if (flag2)
						{
							num = A_0[0].a() - A_0[0].e() / 2f;
							num2 = this.c[0].a() + this.c[0].e() / 2f;
							float a_ = (num + num2) / 2f;
							qz qz5 = this.c[0];
							qz5.e(qz5.e() + A_0[0].e());
							this.c[0].a(a_);
							this.c[0].c(a_);
							this.c[0].b(A_0[0].b());
							this.c[0].d(A_0[0].d());
							A_0[0] = null;
						}
					}
				}
			}
			if (A_0[1].g() != LineStyle.None)
			{
				for (int i = 0; i < this.c.Count; i++)
				{
					if (this.c[i] != null)
					{
						float num = A_0[1].a() - A_0[1].e() / 2f + 0.001f;
						float num2 = this.c[i].a() + this.c[i].e() / 2f + 0.001f;
						float num3 = (num > num2) ? (num - num2) : (num2 - num);
						bool flag2 = num3 < 0.001f;
						if (flag2 && A_0[1].f().Equals(this.c[i].f()) && A_0[1].g().Equals(this.c[i].g()))
						{
							num3 = ((this.c[i].b() > A_5 + A_2) ? (this.c[i].b() + 0.001f - (A_5 + A_2 + 0.001f)) : (A_5 + A_2 + 0.001f - (this.c[i].b() + 0.001f)));
							flag2 = (num3 < 0.001f);
							if (flag2)
							{
								num3 = ((this.c[i].d() > A_3 + A_5) ? (this.c[i].d() + 0.001f - (A_3 + A_5 + 0.001f)) : (A_3 + A_5 + 0.001f - (this.c[i].d() + 0.001f)));
								flag2 = (num3 < 0.001f);
								if (flag2)
								{
									num = A_0[1].a() + A_0[1].e() / 2f;
									num2 = this.c[i].a() - this.c[i].e() / 2f;
									float a_ = (num + num2) / 2f;
									qz qz6 = this.c[i];
									qz6.e(qz6.e() + A_0[1].e());
									this.c[i].a(a_);
									this.c[i].c(a_);
									this.c[i].b(A_0[1].b());
									this.c[i].d(A_0[1].d());
									A_0[1] = null;
									break;
								}
							}
						}
					}
				}
			}
			if (A_0[2].g() != LineStyle.None && this.d.Count > 0 && this.d[0] != null)
			{
				float num = A_0[2].b() + A_0[2].e() / 2f + 0.001f;
				float num2 = this.d[0].b() - this.d[0].e() / 2f + 0.001f;
				float num3 = (num > num2) ? (num - num2) : (num2 - num);
				bool flag2 = num3 < 0.001f;
				if (flag2 && A_0[2].f().Equals(this.d[0].f()) && A_0[2].g().Equals(this.d[0].g()))
				{
					num3 = ((this.d[0].a() > A_6 + A_1) ? (this.d[0].a() + 0.001f - (A_6 + A_1 + 0.001f)) : (A_6 + A_1 + 0.001f - (this.d[0].a() + 0.001f)));
					flag2 = (num3 < 0.001f);
					if (flag2)
					{
						num3 = ((this.d[0].c() > A_4 + A_6) ? (this.d[0].c() + 0.001f - (A_4 + A_6 + 0.001f)) : (A_4 + A_6 + 0.001f - (this.d[0].c() + 0.001f)));
						flag2 = (num3 < 0.001f);
						if (flag2)
						{
							num = A_0[2].b() - A_0[2].e() / 2f;
							num2 = this.d[0].b() + this.d[0].e() / 2f;
							float a_ = (num + num2) / 2f;
							qz qz7 = this.d[0];
							qz7.e(qz7.e() + A_0[2].e());
							this.d[0].b(a_);
							this.d[0].d(a_);
							this.d[0].a(A_0[2].a());
							this.d[0].c(A_0[2].c());
							A_0[2] = null;
							flag = true;
						}
					}
				}
			}
			if (A_0[0] != null)
			{
				this.d.Add(A_0[0]);
			}
			if (A_0[1] != null)
			{
				this.d.Add(A_0[1]);
			}
			if (!flag)
			{
				if (A_0[2].g() != LineStyle.None)
				{
					this.d.Add(A_0[2]);
				}
			}
			flag = false;
			if (A_0[3].g() != LineStyle.None)
			{
				for (int i = 0; i < this.d.Count; i++)
				{
					if (this.d[i] != null)
					{
						float num = A_0[3].b() - A_0[3].e() / 2f + 0.001f;
						float num2 = this.d[i].b() + this.d[i].e() / 2f + 0.001f;
						float num3 = (num > num2) ? (num - num2) : (num2 - num);
						bool flag2 = num3 < 0.0001f;
						if (flag2 && A_0[3].f().Equals(this.d[i].f()) && A_0[3].g().Equals(this.d[i].g()))
						{
							num3 = ((this.d[i].a() > A_6 + A_1) ? (this.d[i].a() + 0.001f - (A_6 + A_1 + 0.001f)) : (A_6 + A_1 + 0.001f - (this.d[i].a() + 0.001f)));
							flag2 = (num3 < 0.001f);
							if (flag2)
							{
								num3 = ((this.d[i].c() > A_4 + A_6) ? (this.d[i].c() + 0.001f - (A_4 + A_6 + 0.001f)) : (A_4 + A_6 + 0.001f - (this.d[i].c() + 0.001f)));
								flag2 = (num3 < 0.001f);
								if (flag2)
								{
									num = A_0[3].b() + A_0[3].e() / 2f;
									num2 = this.d[i].b() - this.d[i].e() / 2f;
									float a_ = (num + num2) / 2f;
									qz qz8 = this.d[i];
									qz8.e(qz8.e() + A_0[3].e());
									this.d[i].b(a_);
									this.d[i].d(a_);
									this.d[i].a(A_0[3].a());
									this.d[i].c(A_0[3].c());
									A_0[3] = null;
									flag = true;
									break;
								}
							}
						}
					}
				}
				if (!flag)
				{
					if (A_0[3].g() != LineStyle.None)
					{
						this.d.Add(A_0[3]);
					}
				}
			}
		}

		// Token: 0x06004742 RID: 18242 RVA: 0x0024A07C File Offset: 0x0024907C
		private void a(q0 A_0)
		{
			bool flag = true;
			Color color = null;
			float num = 0f;
			LineStyle lineStyle = LineStyle.None;
			int num2 = 0;
			for (int i = 0; i < this.c.Count; i++)
			{
				if (this.c[i] != null)
				{
					if (color != null)
					{
						if (!color.Equals(this.c[i].f()) || num != this.c[i].e() || lineStyle != this.c[i].g())
						{
							bool flag2 = false;
							for (int j = num2; j < i; j++)
							{
								A_0.c().SetLineWidth(this.c[j].e());
								A_0.c().SetLineStyle(this.c[j].g());
								if (this.c[j].g() != LineStyle.None && this.c[j].e() != 0f)
								{
									A_0.c().SetStrokeColor(this.c[j].f());
									A_0.c().Write_m_(this.c[j].a(), this.c[j].b());
									A_0.c().Write_l_(this.c[j].c(), this.c[j].d());
									flag2 = true;
								}
							}
							if (flag2)
							{
								A_0.c().Write_S();
							}
							num2 = i;
						}
					}
					color = this.c[i].f();
					num = this.c[i].e();
					lineStyle = this.c[i].g();
					flag = true;
				}
			}
			if (flag)
			{
				flag = false;
				for (int j = num2; j < this.c.Count; j++)
				{
					if (this.c[j] != null)
					{
						A_0.c().SetLineWidth(this.c[j].e());
						A_0.c().SetLineStyle(this.c[j].g());
						if (this.c[j].g() != LineStyle.None && this.c[j].e() != 0f)
						{
							A_0.c().SetStrokeColor(this.c[j].f());
							A_0.c().Write_m_(this.c[j].a(), this.c[j].b());
							A_0.c().Write_l_(this.c[j].c(), this.c[j].d());
							flag = true;
						}
					}
				}
				if (flag)
				{
					A_0.c().Write_S();
				}
			}
			color = null;
			num = 0f;
			lineStyle = LineStyle.None;
			num2 = 0;
			for (int i = 0; i < this.d.Count; i++)
			{
				if (this.d[i] != null)
				{
					if (color != null)
					{
						if (!color.Equals(this.d[i].f()) || num != this.d[i].e() || lineStyle != this.d[i].g())
						{
							bool flag2 = false;
							for (int j = num2; j < i; j++)
							{
								A_0.c().SetLineWidth(this.d[j].e());
								A_0.c().SetLineStyle(this.d[j].g());
								if (this.d[j].g() != LineStyle.None && this.d[j].e() != 0f)
								{
									A_0.c().SetStrokeColor(this.d[j].f());
									A_0.c().Write_m_(this.d[j].a(), this.d[j].b());
									A_0.c().Write_l_(this.d[j].c(), this.d[j].d());
									flag2 = true;
								}
							}
							if (flag2)
							{
								A_0.c().Write_S();
							}
							num2 = i;
						}
					}
					color = this.d[i].f();
					num = this.d[i].e();
					lineStyle = this.d[i].g();
					flag = true;
				}
			}
			if (flag)
			{
				flag = false;
				for (int j = num2; j < this.d.Count; j++)
				{
					if (this.d[j] != null)
					{
						A_0.c().SetLineWidth(this.d[j].e());
						A_0.c().SetLineStyle(this.d[j].g());
						if (this.d[j].g() != LineStyle.None && this.d[j].e() != 0f)
						{
							A_0.c().SetStrokeColor(this.d[j].f());
							A_0.c().Write_m_(this.d[j].a(), this.d[j].b());
							A_0.c().Write_l_(this.d[j].c(), this.d[j].d());
							flag = true;
						}
					}
				}
				if (flag)
				{
					A_0.c().Write_S();
				}
			}
		}

		// Token: 0x06004743 RID: 18243 RVA: 0x0024A7BC File Offset: 0x002497BC
		private void b(qv[] A_0)
		{
			this.c.Add(new qz(A_0[0].a().a(), A_0[0].a().b(), A_0[0].a().c(), A_0[0].a().d(), A_0[0].a().e(), A_0[0].a().f(), A_0[0].a().g()));
			for (int i = 0; i < A_0.Length; i++)
			{
				if (i + 1 < A_0.Length)
				{
					float num = A_0[i].b().a() + A_0[i].b().e() / 2f + 0.001f;
					float num2 = A_0[i + 1].a().a() - A_0[i + 1].a().e() / 2f + 0.001f;
					float num3 = (num > num2) ? (num - num2) : (num2 - num);
					bool flag = num3 < 0.001f;
					if (A_0[i].b().g().Equals(A_0[i + 1].a().g()) && A_0[i].b().f().Equals(A_0[i + 1].a().f()) && A_0[i].b().d() == A_0[i + 1].a().d() && flag)
					{
						num = A_0[i].b().a() - A_0[i].b().e() / 2f;
						num2 = A_0[i + 1].a().a() + A_0[i + 1].a().e() / 2f;
						float num4 = (num + num2) / 2f;
						this.c.Add(new qz(num4, A_0[i].b().b(), num4, A_0[i].b().d(), A_0[i].b().e() + A_0[i + 1].a().e(), A_0[i].b().f(), A_0[i].b().g()));
					}
					else
					{
						this.c.Add(new qz(A_0[i].b().a(), A_0[i].b().b(), A_0[i].b().c(), A_0[i].b().d(), A_0[i].b().e(), A_0[i].b().f(), A_0[i].b().g()));
						this.c.Add(new qz(A_0[i + 1].a().a(), A_0[i + 1].a().b(), A_0[i + 1].a().c(), A_0[i + 1].a().d(), A_0[i + 1].a().e(), A_0[i + 1].a().f(), A_0[i + 1].a().g()));
					}
				}
				else
				{
					this.c.Add(new qz(A_0[i].b().a(), A_0[i].b().b(), A_0[i].b().c(), A_0[i].b().d(), A_0[i].b().e(), A_0[i].b().f(), A_0[i].b().g()));
				}
			}
			if (this.d.Count <= 0)
			{
				for (int i = 0; i < A_0.Length; i++)
				{
					this.d.Add(new qz(A_0[i].c().a(), A_0[i].c().b(), A_0[i].c().c(), A_0[i].c().d(), A_0[i].c().e(), A_0[i].c().f(), A_0[i].c().g()));
				}
				for (int i = 0; i < A_0.Length; i++)
				{
					this.d.Add(new qz(A_0[i].d().a(), A_0[i].d().b(), A_0[i].d().c(), A_0[i].d().d(), A_0[i].d().e(), A_0[i].d().f(), A_0[i].d().g()));
				}
			}
			else
			{
				this.a(A_0);
			}
			A_0 = null;
		}

		// Token: 0x06004744 RID: 18244 RVA: 0x0024AD9C File Offset: 0x00249D9C
		private void a(qv[] A_0)
		{
			bool flag = false;
			for (int i = 0; i < this.d.Count; i++)
			{
				if (this.d[i].e() == 0f)
				{
					this.d[i] = null;
					this.d.RemoveAt(i);
					i--;
				}
			}
			for (int i = 0; i < A_0.Length; i++)
			{
				for (int j = 0; j < this.d.Count; j++)
				{
					if (this.d[j] != null)
					{
						float num = A_0[i].c().b() - A_0[i].c().e() / 2f + 0.001f;
						float num2 = this.d[j].b() + this.d[j].e() / 2f + 0.001f;
						float num3 = (num > num2) ? (num - num2) : (num2 - num);
						bool flag2 = num3 < 0.001f;
						if (flag2 && A_0[i].c().g().Equals(this.d[j].g()) && A_0[i].c().f().Equals(this.d[j].f()) && A_0[i].c().a() == this.d[j].a() && A_0[i].c().c() == this.d[j].c() && A_0[i].c().e() > 0f)
						{
							num = A_0[i].c().b() - A_0[i].c().e() / 2f;
							num2 = this.d[j].b() + this.d[j].e() / 2f;
							float a_ = (num + num2) / 2f;
							this.d[j].e(A_0[i].c().e() + this.d[j].e());
							this.d[j].b(a_);
							this.d[j].d(a_);
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.d.Add(new qz(A_0[i].c().a(), A_0[i].c().b(), A_0[i].c().c(), A_0[i].c().d(), A_0[i].c().e(), A_0[i].c().f(), A_0[i].c().g()));
				}
				flag = false;
			}
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i].d() != null)
				{
					this.d.Add(new qz(A_0[i].d().a(), A_0[i].d().b(), A_0[i].d().c(), A_0[i].d().d(), A_0[i].d().e(), A_0[i].d().f(), A_0[i].d().g()));
				}
			}
		}

		// Token: 0x06004745 RID: 18245 RVA: 0x0024B1FC File Offset: 0x0024A1FC
		private void d()
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				if (this.d[i] != null)
				{
					for (int j = i + 1; j < this.d.Count; j++)
					{
						if (this.d[j] != null)
						{
							if (this.d[i].c() == this.d[j].a() && this.d[i].b() == this.d[j].b() && this.d[i].e() == this.d[j].e() && this.d[i].f().Equals(this.d[j].f()) && this.d[i].g().Equals(this.d[j].g()))
							{
								this.d[i].c(this.d[j].c());
								this.d[j] = null;
								this.d.RemoveAt(j);
								j--;
							}
						}
					}
				}
			}
		}

		// Token: 0x06004746 RID: 18246 RVA: 0x0024B390 File Offset: 0x0024A390
		private void c()
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				if (this.d[i] != null)
				{
					for (int j = i + 1; j < this.d.Count; j++)
					{
						if (this.d[j] != null)
						{
							float num = this.d[i].b() + this.d[i].e() / 2f + 0.001f;
							float num2 = this.d[j].b() - this.d[j].e() / 2f + 0.001f;
							float num3 = (num > num2) ? (num - num2) : (num2 - num);
							bool flag = num3 < 0.001f;
							if (flag && this.d[i].g().Equals(this.d[j].g()) && this.d[i].f().Equals(this.d[j].f()) && this.d[i].a() == this.d[j].a() && this.d[i].c() == this.d[j].c())
							{
								num = this.d[i].b() + this.d[i].e() / 2f;
								num2 = this.d[j].b() - this.d[j].e() / 2f;
								float a_ = (num + num2) / 2f;
								this.d[i].e(this.d[i].e() + this.d[j].e());
								this.d[i].b(a_);
								this.d[i].d(a_);
								this.d[j] = null;
								this.d.RemoveAt(j);
								j--;
								break;
							}
						}
					}
				}
			}
			this.d();
		}

		// Token: 0x06004747 RID: 18247 RVA: 0x0024B640 File Offset: 0x0024A640
		private void b()
		{
			for (int i = 0; i < this.c.Count; i++)
			{
				if (this.c[i] != null)
				{
					for (int j = i + 1; j < this.c.Count; j++)
					{
						if (this.c[j] != null)
						{
							float num = this.c[i].a() + this.c[i].e() / 2f + 0.001f;
							float num2 = this.c[j].a() - this.c[j].e() / 2f + 0.001f;
							float num3 = (num > num2) ? (num - num2) : (num2 - num);
							bool flag = num3 < 0.001f;
							if (this.c[i].g().Equals(this.c[j].g()) && this.c[i].f().Equals(this.c[j].f()) && this.c[i].d() == this.c[j].d() && flag)
							{
								num = this.c[i].a() - this.c[i].e() / 2f;
								num2 = this.c[j].a() + this.c[j].e() / 2f;
								float a_ = (num + num2) / 2f;
								this.c[i].a(a_);
								this.c[i].c(a_);
								this.c[i].e(this.c[i].e() + this.c[j].e());
								this.c[j] = null;
								this.c.RemoveAt(j);
								j--;
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06004748 RID: 18248 RVA: 0x0024B8C0 File Offset: 0x0024A8C0
		private void a()
		{
			for (int i = 0; i < this.c.Count; i++)
			{
				if (this.c[i] != null)
				{
					for (int j = i + 1; j < this.c.Count; j++)
					{
						if (this.c[j] != null)
						{
							if (this.c[i].a() == this.c[j].a() && this.c[i].d() == this.c[j].b() && this.c[i].e().Equals(this.c[j].e()) && this.c[i].f().Equals(this.c[j].f()) && this.c[i].g().Equals(this.c[j].g()))
							{
								this.c[i].d(this.c[j].d());
								this.c[j] = null;
								this.c.RemoveAt(j);
								j--;
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06004749 RID: 18249 RVA: 0x0024BA60 File Offset: 0x0024AA60
		internal void b(q0 A_0, bool A_1)
		{
			PageWriter pageWriter = A_0.c();
			StructureElement structureElement = null;
			if (A_1)
			{
				if (pageWriter.Document.Tag != null)
				{
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
					if (this.b.h() > 0)
					{
						this.b.h(false);
					}
				}
			}
			if (A_0.d().b().h() > 0 && A_0.d().g() > 0)
			{
				int num = A_0.d().b().h() - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i;
					A_0.d().b().d(num2);
					num2 += A_0.d().b().d()[num2].a() - 1;
					if (num2 > num)
					{
						num = num2;
					}
					this[i].a(A_0, A_1, i, structureElement, null);
				}
			}
		}

		// Token: 0x0600474A RID: 18250 RVA: 0x0024BC40 File Offset: 0x0024AC40
		internal void b(q0 A_0, bool A_1, float A_2, float A_3, Table2 A_4, bool A_5)
		{
			PageWriter pageWriter = A_0.c();
			StructureElement structureElement = null;
			if (A_1)
			{
				if (pageWriter.Document.Tag != null)
				{
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
					if (this.b.h() > 0)
					{
						this.b.h(false);
					}
				}
			}
			this.c = new List<qz>();
			this.d = new List<qz>();
			bool flag = true;
			if (A_0.d().CellSpacing > 0f || !A_5)
			{
				if (A_5 && A_0.d().b().h() > 0 && A_0.d().g() > 0)
				{
					int num = A_0.d().b().h() - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = i;
						A_0.d().b().d(num2);
						num2 += A_0.d().b().d()[num2].a() - 1;
						if (num2 > num)
						{
							num = num2;
						}
						this[i].a(A_0, A_1, i, structureElement, null);
					}
				}
				if (A_0.d().CellSpacing > 0f)
				{
					if (A_4.f() == null)
					{
						for (int j = A_0.d().g(); j <= A_0.d().h(); j++)
						{
							if (A_0.c().Document.Tag != null)
							{
								if (!this.b.r() && A_1)
								{
									if (this.b.h() - j <= 0)
									{
										this.b.h(true);
									}
								}
							}
							this[j].a(A_0, A_1, j, structureElement, null);
						}
					}
					else
					{
						int j = A_0.d().g();
						for (;;)
						{
							int num3 = j;
							if (!(num3 <= A_0.d().h() + A_4.f() - 1))
							{
								break;
							}
							if (A_0.c().Document.Tag != null)
							{
								if (!this.b.r() && A_1)
								{
									if (this.b.h() - j <= 0)
									{
										this.b.h(true);
									}
								}
							}
							this[j].a(A_0, A_1, j, structureElement, null);
							j++;
						}
					}
				}
				else if (A_4.f() == null)
				{
					for (int j = A_0.d().g(); j <= A_0.d().h(); j++)
					{
						if (A_0.c().Document.Tag != null)
						{
							if (!this.b.r() && A_1)
							{
								if (this.b.h() - j <= 0)
								{
									this.b.h(true);
								}
							}
						}
						flag = this.a(j, A_0, A_1, structureElement);
					}
				}
				else
				{
					int j = A_0.d().g();
					for (;;)
					{
						int num3 = j;
						if (!(num3 <= A_0.d().h() + A_4.f() - 1))
						{
							break;
						}
						if (A_0.c().Document.Tag != null)
						{
							if (!this.b.r() && A_1)
							{
								if (this.b.h() - j <= 0)
								{
									this.b.h(true);
								}
							}
						}
						flag = this.a(j, A_0, A_1, structureElement);
						j++;
					}
				}
			}
			else
			{
				if (A_5 && A_0.d().b().h() > 0 && A_0.d().g() > 0)
				{
					int num = A_0.d().b().h() - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = i;
						A_0.d().b().d(num2);
						num2 += A_0.d().b().d()[num2].a() - 1;
						if (num2 > num)
						{
							num = num2;
						}
						flag = this.a(i, A_0, A_1, structureElement);
					}
				}
				for (int j = A_0.d().g(); j <= A_0.d().h(); j++)
				{
					if (A_0.c().Document.Tag != null)
					{
						if (!this.b.r() && A_1)
						{
							if (this.b.h() - j <= 0)
							{
								this.b.h(true);
							}
						}
					}
					flag = this.a(j, A_0, A_1, structureElement);
				}
				if (!flag)
				{
					this.b();
					this.d();
					this.c();
					this.a(A_2, A_3, A_0);
					this.a(A_0);
				}
			}
			if (!flag)
			{
				this.b();
				this.d();
				this.c();
				this.a(A_2, A_3, A_0);
				this.a(A_0);
			}
			if (A_1)
			{
				if (pageWriter.Document.Tag != null)
				{
					if (A_0.d().Tag == null)
					{
						AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
						attributeObject.b(A_0.d(), pageWriter);
						structureElement.AttributeLists.Add(attributeObject);
					}
					else
					{
						((StructureElement)A_0.d().Tag).a(pageWriter, A_0.d(), pageWriter.Document.j());
					}
				}
			}
		}

		// Token: 0x17000487 RID: 1159
		public Row2 this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x0600474C RID: 18252 RVA: 0x0024C494 File Offset: 0x0024B494
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x0600474D RID: 18253 RVA: 0x0024C4B4 File Offset: 0x0024B4B4
		internal qy e()
		{
			return this.b;
		}

		// Token: 0x0600474E RID: 18254 RVA: 0x0024C4CC File Offset: 0x0024B4CC
		internal void a(qy A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600474F RID: 18255 RVA: 0x0024C4D8 File Offset: 0x0024B4D8
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x04002726 RID: 10022
		private List<Row2> a = new List<Row2>();

		// Token: 0x04002727 RID: 10023
		private qy b;

		// Token: 0x04002728 RID: 10024
		private List<qz> c;

		// Token: 0x04002729 RID: 10025
		private List<qz> d;
	}
}
