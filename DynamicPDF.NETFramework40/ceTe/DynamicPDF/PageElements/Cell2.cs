using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements.BarCoding;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000706 RID: 1798
	public class Cell2
	{
		// Token: 0x0600465C RID: 18012 RVA: 0x0023F364 File Offset: 0x0023E364
		internal Cell2()
		{
		}

		// Token: 0x0600465D RID: 18013 RVA: 0x0023F414 File Offset: 0x0023E414
		internal Cell2(Row2 A_0, string A_1, Font A_2, float? A_3, Color A_4, Color A_5, int A_6, int A_7)
		{
			this.b = A_0;
			this.f = A_6;
			this.g = A_7;
			this.j = A_1;
			if (A_2 != null)
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(A_2);
			}
			if (A_3 != null)
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.d(A_3);
			}
			if (A_4 != null)
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(A_4);
			}
			if (A_5 != null)
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.b(A_5);
			}
		}

		// Token: 0x0600465E RID: 18014 RVA: 0x0023F5B4 File Offset: 0x0023E5B4
		internal Cell2(Row2 A_0, PageElement A_1, int A_2, int A_3)
		{
			this.b = A_0;
			this.a = A_1;
			this.f = A_2;
			this.g = A_3;
		}

		// Token: 0x0600465F RID: 18015 RVA: 0x0023F680 File Offset: 0x0023E680
		internal void a(q0 A_0, int A_1, int? A_2)
		{
			Color color = this.b.e().u()[this.ColumnIndex, this.i].a().l();
			this.d = ((this.f() != null) ? this.f().Value : this.a(A_0, A_2));
			float cellSpacing = A_0.d().CellSpacing;
			float num = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value;
			float num2 = this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width.Value;
			float num3 = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value;
			float num4 = this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
			float num5 = 0f;
			float num6 = A_0.d().Border.Top.Width.Value;
			if (A_1 == 0)
			{
				num5 = A_0.d().Border.Left.Width.Value;
			}
			A_0.a(A_0.a() + (cellSpacing + num5));
			if (color != null || !this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle.Equals(LineStyle.None) || !this.b.e().u()[this.ColumnIndex, this.i].b().Right.LineStyle.Equals(LineStyle.None) || !this.b.e().u()[this.ColumnIndex, this.i].b().Top.LineStyle.Equals(LineStyle.None) || !this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.LineStyle.Equals(LineStyle.None))
			{
				A_0.c().SetGraphicsMode();
			}
			if (color != null)
			{
				A_0.c().SetFillColor(color);
				if (!this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle.Equals(LineStyle.None))
				{
					float num7 = this.c - num;
					if (!this.b.e().u()[this.ColumnIndex, this.i].b().Right.LineStyle.Equals(LineStyle.None))
					{
						num7 -= num2;
					}
					A_0.c().Write_re(A_0.a() + num, A_0.b() + cellSpacing + num6, num7, this.d);
				}
				else
				{
					A_0.c().Write_re(A_0.a(), A_0.b() + cellSpacing + num6, this.c, this.d);
				}
				A_0.c().Write_f();
			}
			this.s = new qz(A_0.a() + num / 2f, A_0.b() + num6, A_0.a() + num / 2f, A_0.b() + num6 + this.d, this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value, this.b.e().u()[this.ColumnIndex, this.i].b().Left.Color, this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle);
			this.t = new qz(A_0.a() - num2 / 2f + this.c, A_0.b() + num6, A_0.a() - num2 / 2f + this.c, A_0.b() + num6 + this.d, this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width.Value, this.b.e().u()[this.ColumnIndex, this.i].b().Right.Color, this.b.e().u()[this.ColumnIndex, this.i].b().Right.LineStyle);
			this.u = new qz(A_0.a(), A_0.b() + num3 / 2f + num6, A_0.a() + this.c, A_0.b() + num3 / 2f + num6, this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value, this.b.e().u()[this.ColumnIndex, this.i].b().Top.Color, this.b.e().u()[this.ColumnIndex, this.i].b().Top.LineStyle);
			this.v = new qz(A_0.a(), A_0.b() + this.d - num4 / 2f + num6, A_0.a() + this.c, A_0.b() + this.d - num4 / 2f + num6, this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value, this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Color, this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.LineStyle);
			A_0.a(A_0.a() + this.c);
		}

		// Token: 0x06004660 RID: 18016 RVA: 0x0023FE04 File Offset: 0x0023EE04
		internal void b(q0 A_0, int A_1, int? A_2)
		{
			Color color = this.b.e().u()[this.ColumnIndex, this.i].a().l();
			this.d = ((this.f() != null) ? this.f().Value : this.a(A_0, A_2));
			float num = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value;
			Color color2 = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Color;
			float cellSpacing = A_0.d().CellSpacing;
			float num2 = 0f;
			float num3 = A_0.d().Border.Top.Width.Value;
			if (A_1 == 0)
			{
				num2 = A_0.d().Border.Left.Width.Value;
			}
			A_0.a(A_0.a() + (cellSpacing + num2));
			if (num > 0f || color != null)
			{
				A_0.c().SetGraphicsMode();
				bool flag;
				bool flag2;
				if (num > 0f && color != null)
				{
					A_0.c().SetLineWidth(num);
					A_0.c().SetLineStyle(this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle);
					flag = true;
					flag2 = true;
				}
				else if (num > 0f && color == null)
				{
					A_0.c().SetLineWidth(num);
					A_0.c().SetLineStyle(this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle);
					flag = false;
					flag2 = true;
				}
				else
				{
					flag = true;
					flag2 = false;
				}
				if ((flag && flag2) || flag)
				{
					A_0.c().SetFillColor(color);
				}
				bool flag3;
				if (!this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle.Equals(LineStyle.None))
				{
					float? width = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width;
					flag3 = (width.GetValueOrDefault() == 0f && width != null);
				}
				else
				{
					flag3 = true;
				}
				if (!flag3)
				{
					A_0.c().SetStrokeColor(color2);
					A_0.c().Write_re(A_0.a() + num / 2f, A_0.b() + cellSpacing + num / 2f + num3, this.c - num, this.d - num);
					if (flag)
					{
						if (flag2)
						{
							A_0.c().Write_b_();
						}
						else
						{
							A_0.c().Write_f();
						}
					}
					else
					{
						A_0.c().Write_s_();
					}
				}
				else if (color != null)
				{
					A_0.c().Write_re(A_0.a() + num / 2f, A_0.b() + cellSpacing + num / 2f + num3, this.c - num / 2f, this.d - num);
					A_0.c().Write_f();
				}
			}
			A_0.a(A_0.a() + this.c);
		}

		// Token: 0x06004661 RID: 18017 RVA: 0x0024020C File Offset: 0x0023F20C
		internal void c(q0 A_0, int A_1, int? A_2)
		{
			Color color = this.b.e().u()[this.ColumnIndex, this.i].a().l();
			this.d = ((this.f() != null) ? this.f().Value : this.a(A_0, A_2));
			float cellSpacing = A_0.d().CellSpacing;
			float num = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value;
			float num2 = this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width.Value;
			float num3 = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value;
			float num4 = this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
			float num5 = 0f;
			float num6 = A_0.d().Border.Top.Width.Value;
			if (A_1 == 0)
			{
				num5 = A_0.d().Border.Left.Width.Value;
			}
			A_0.a(A_0.a() + (cellSpacing + num5));
			if (color != null || !this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle.Equals(LineStyle.None) || !this.b.e().u()[this.ColumnIndex, this.i].b().Right.LineStyle.Equals(LineStyle.None) || !this.b.e().u()[this.ColumnIndex, this.i].b().Top.LineStyle.Equals(LineStyle.None) || !this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.LineStyle.Equals(LineStyle.None))
			{
				A_0.c().SetGraphicsMode();
			}
			if (color != null)
			{
				A_0.c().SetFillColor(color);
				A_0.c().Write_re(A_0.a() + num / 2f, A_0.b() + cellSpacing + num6 + num3 / 2f, this.c - num2 / 2f, this.d - num4 / 2f - num3 / 2f);
				A_0.c().Write_f();
			}
			A_0.c().SetLineWidth(num);
			A_0.c().SetLineStyle(this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle);
			bool flag;
			if (!this.b.e().u()[this.ColumnIndex, this.i].b().Left.LineStyle.Equals(LineStyle.None))
			{
				float? width = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width;
				flag = (width.GetValueOrDefault() == 0f && width != null);
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				A_0.c().SetStrokeColor(this.b.e().u()[this.ColumnIndex, this.i].b().Left.Color);
				A_0.c().Write_m_(A_0.a() + num / 2f, A_0.b() + cellSpacing + num6);
				A_0.c().Write_l_(A_0.a() + num / 2f, A_0.b() + cellSpacing + num6 + this.d);
				A_0.c().Write_S();
			}
			A_0.c().SetLineWidth(num2);
			A_0.c().SetLineStyle(this.b.e().u()[this.ColumnIndex, this.i].b().Right.LineStyle);
			bool flag2;
			if (!this.b.e().u()[this.ColumnIndex, this.i].b().Right.LineStyle.Equals(LineStyle.None))
			{
				float? width = this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width;
				flag2 = (width.GetValueOrDefault() == 0f && width != null);
			}
			else
			{
				flag2 = true;
			}
			if (!flag2)
			{
				A_0.c().SetStrokeColor(this.b.e().u()[this.ColumnIndex, this.i].b().Right.Color);
				A_0.c().Write_m_(A_0.a() - num2 / 2f + this.c, A_0.b() + cellSpacing + num6);
				A_0.c().Write_l_(A_0.a() - num2 / 2f + this.c, A_0.b() + cellSpacing + num6 + this.d);
				A_0.c().Write_S();
			}
			A_0.c().SetLineWidth(num3);
			A_0.c().SetLineStyle(this.b.e().u()[this.ColumnIndex, this.i].b().Top.LineStyle);
			bool flag3;
			if (!this.b.e().u()[this.ColumnIndex, this.i].b().Top.LineStyle.Equals(LineStyle.None))
			{
				float? width = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width;
				flag3 = (width.GetValueOrDefault() == 0f && width != null);
			}
			else
			{
				flag3 = true;
			}
			if (!flag3)
			{
				A_0.c().SetStrokeColor(this.b.e().u()[this.ColumnIndex, this.i].b().Top.Color);
				A_0.c().Write_m_(A_0.a(), A_0.b() + num3 / 2f + cellSpacing + num6);
				A_0.c().Write_l_(A_0.a() + this.c, A_0.b() + num3 / 2f + cellSpacing + num6);
				A_0.c().Write_S();
			}
			A_0.c().SetLineWidth(num4);
			A_0.c().SetLineStyle(this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.LineStyle);
			bool flag4;
			if (!this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.LineStyle.Equals(LineStyle.None))
			{
				float? width = this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width;
				flag4 = (width.GetValueOrDefault() == 0f && width != null);
			}
			else
			{
				flag4 = true;
			}
			if (!flag4)
			{
				A_0.c().SetStrokeColor(this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Color);
				A_0.c().Write_m_(A_0.a(), A_0.b() + this.d - num4 / 2f + cellSpacing + num6);
				A_0.c().Write_l_(A_0.a() + this.c, A_0.b() + this.d - num4 / 2f + cellSpacing + num6);
				A_0.c().Write_S();
			}
			A_0.a(A_0.a() + this.c);
		}

		// Token: 0x06004662 RID: 18018 RVA: 0x00240B94 File Offset: 0x0023FB94
		internal void a(q0 A_0, int A_1)
		{
			CellPadding cellPadding = this.b.e().u()[this.ColumnIndex, this.i].c();
			float num = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value;
			float num2 = this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width.Value;
			float num3 = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value;
			float num4 = this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
			float num5 = 0f;
			float value = A_0.d().Border.Top.Width.Value;
			if (A_1 == 0)
			{
				num5 = A_0.d().Border.Left.Width.Value;
			}
			float num6 = this.a();
			A_0.a(A_0.a() + (num5 + num6));
			if (this.a != null)
			{
				float a_;
				float a_2;
				float num7;
				float num8;
				if (!(this.a is IArea))
				{
					a_ = A_0.a() + cellPadding.Left.Value + num;
					a_2 = A_0.b() + cellPadding.Top.Value + num3;
					num7 = this.d - (cellPadding.Top.Value + cellPadding.Bottom.Value) - (num3 + num4);
					num8 = this.c - (cellPadding.Left.Value + cellPadding.Right.Value) - (num + num2);
				}
				else
				{
					IArea area = (IArea)this.a;
					num7 = area.Height;
					num8 = area.Width;
					switch (this.b.e().u()[this.ColumnIndex, this.i].a().j().Value)
					{
					case TextAlign.Center:
						a_ = A_0.a() + (this.c - num8) / 2f;
						break;
					case TextAlign.Right:
						a_ = A_0.a() + (this.c - cellPadding.Right.Value - num8 - num2);
						break;
					default:
						a_ = A_0.a() + cellPadding.Left.Value + num;
						break;
					}
					switch (this.b.e().u()[this.ColumnIndex, this.i].a().k().Value)
					{
					case ceTe.DynamicPDF.VAlign.Center:
						a_2 = A_0.b() + num6 + (this.d - num7) / 2f + value;
						break;
					case ceTe.DynamicPDF.VAlign.Bottom:
						a_2 = A_0.b() + num6 + (this.d - cellPadding.Bottom.Value - num7 - num4) + value;
						break;
					default:
						a_2 = A_0.b() + cellPadding.Top.Value + num6 + num3 + value;
						break;
					}
				}
				if (this.a is ImportedPageArea)
				{
					ImportedPageArea importedPageArea = (ImportedPageArea)this.a;
					importedPageArea.a(a_);
					importedPageArea.b(a_2);
					this.a.Draw(A_0.c());
					importedPageArea.a(0f);
					importedPageArea.b(0f);
				}
				else if (this.a is ImportedPageData)
				{
					ImportedPageData importedPageData = (ImportedPageData)this.a;
					importedPageData.a(a_);
					importedPageData.b(a_2);
					this.a.Draw(A_0.c());
					importedPageData.a(0f);
					importedPageData.b(0f);
				}
				else
				{
					A_0.c().SetDimensionsShift(a_, a_2, num8, num7);
					this.a.Draw(A_0.c());
					A_0.c().ResetDimensions();
				}
			}
			if (this.o() != null)
			{
				A_0.c().SetTextMode();
				switch (this.b.e().u()[this.ColumnIndex, this.i].a().k().Value)
				{
				case ceTe.DynamicPDF.VAlign.Center:
					if (this.y > 0)
					{
						float num9 = (this.y == this.o().Count) ? (this.d / 2f - this.o().GetRequiredHeight(0) / 2f) : (this.d / 2f - this.a(this.x, this.y) / 2f);
						this.o().jb(A_0.c(), A_0.a() + cellPadding.Left.Value + num, A_0.b() + num6 + num9 + value, this.b.e().u()[this.ColumnIndex, this.i].a().j().Value, this.b.e().u()[this.ColumnIndex, this.i].a().i(), null, 0f, this.b.e().u()[this.ColumnIndex, this.i].a().f().Value, this.x, this.y, this.b.e().u()[this.ColumnIndex, this.i].a().e().Value, false);
					}
					break;
				case ceTe.DynamicPDF.VAlign.Bottom:
					if (this.y > 0)
					{
						float num10 = (this.y == this.o().Count) ? (this.d - this.o().GetRequiredHeight(0)) : (this.d - this.a(this.x, this.y));
						num10 = num10 - cellPadding.Bottom.Value - num4;
						this.o().jb(A_0.c(), A_0.a() + cellPadding.Left.Value + num, A_0.b() + num6 + num10 + value, this.b.e().u()[this.ColumnIndex, this.i].a().j().Value, this.b.e().u()[this.ColumnIndex, this.i].a().i(), null, 0f, this.b.e().u()[this.ColumnIndex, this.i].a().f().Value, this.x, this.y, this.b.e().u()[this.ColumnIndex, this.i].a().e().Value, false);
					}
					break;
				default:
					if (this.y > 0)
					{
						this.o().jb(A_0.c(), A_0.a() + cellPadding.Left.Value + num, A_0.b() + cellPadding.Top.Value + num6 + num3 + value, this.b.e().u()[this.ColumnIndex, this.i].a().j().Value, this.b.e().u()[this.ColumnIndex, this.i].a().i(), null, 0f, this.b.e().u()[this.ColumnIndex, this.i].a().f().Value, this.x, this.y, this.b.e().u()[this.ColumnIndex, this.i].a().e().Value, false);
					}
					break;
				}
			}
			A_0.a(A_0.a() + this.c);
		}

		// Token: 0x06004663 RID: 18019 RVA: 0x0024155C File Offset: 0x0024055C
		private float a(int A_0, int A_1)
		{
			float result;
			if (!GlobalSettings.UseLegacyTextHeightCalculations)
			{
				result = this.o().i()[A_1 - 1].YOffset - this.o().i()[A_0].YOffset + this.o().Leading + 0.001f - this.o().Font.GetLineGap(this.o().FontSize);
			}
			else
			{
				result = this.o().i()[A_1 - 1].YOffset - this.o().i()[A_0].YOffset + this.o().Leading + 0.001f;
			}
			return result;
		}

		// Token: 0x06004664 RID: 18020 RVA: 0x0024160C File Offset: 0x0024060C
		internal void a(q0 A_0, int A_1, StructureElement A_2)
		{
			if (this.q == null && this.a != null && this.a.b4())
			{
				this.q = ((TaggablePageElement)this.a).Tag;
			}
			TagOptions tagOptions = null;
			PageWriter pageWriter = A_0.c();
			StructureElement structureElement = null;
			if (pageWriter.Document.Tag != null)
			{
				if (this.o == null)
				{
					structureElement = new StructureElement((this.b.e().r() && this.b.e().q()) ? TagType.TableDataCell : TagType.TableHeader, true);
					structureElement.a(false);
					structureElement.Parent = A_2;
					structureElement.Order = this.p;
					pageWriter.Document.j().e(structureElement);
					structureElement.a(A_0, this, false);
					if (this.b.Tag != null)
					{
						this.o = structureElement;
					}
				}
				else if (this.o.g())
				{
					structureElement = (StructureElement)this.o;
					if (!structureElement.u())
					{
						if (structureElement.Parent == null)
						{
							structureElement.Parent = A_2;
						}
						pageWriter.Document.j().e(structureElement);
						structureElement.a(A_0, this, false);
					}
				}
				if (this.a != null && this.a.b4() && (this.o == null || this.o.g()))
				{
					if (this.q == null)
					{
						((TaggablePageElement)this.a).a(structureElement, !this.b.e().r() || !this.b.e().q(), null, this.r);
					}
					else if (this.q.g() && !pageWriter.Document.j().f().Contains(this.q))
					{
						((TaggablePageElement)this.a).a(structureElement, !this.b.e().r() || !this.b.e().q(), (StructureElement)this.q, this.r);
					}
				}
				else if (this.a is Group)
				{
					foreach (object obj in ((Group)this.a).d())
					{
						PageElement pageElement = (PageElement)obj;
						if (pageElement.b4() && (this.o == null || this.o.g()))
						{
							((TaggablePageElement)pageElement).a(structureElement, !this.b.e().r() || !this.b.e().q(), null, this.r);
						}
					}
				}
			}
			CellPadding cellPadding = this.b.e().u()[this.ColumnIndex, this.i].c();
			float num = this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value;
			float num2 = this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width.Value;
			float num3 = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value;
			float num4 = this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
			float num5 = 0f;
			float num6 = A_0.d().Border.Top.Width.Value;
			if (A_1 == 0)
			{
				num5 = A_0.d().Border.Left.Width.Value;
			}
			float num7 = this.a();
			A_0.a(A_0.a() + (num5 + num7));
			if (this.a != null)
			{
				float num8;
				float num9;
				float num10;
				float num11;
				if (!(this.a is IArea))
				{
					num8 = A_0.a() + cellPadding.Left.Value + num;
					num9 = A_0.b() + cellPadding.Top.Value + num3;
					num10 = this.d - (cellPadding.Top.Value + cellPadding.Bottom.Value) - (num3 + num4);
					num11 = this.c - (cellPadding.Left.Value + cellPadding.Right.Value) - (num - num2);
				}
				else
				{
					IArea area = (IArea)this.a;
					num10 = area.Height;
					num11 = area.Width;
					switch (this.b.e().u()[this.ColumnIndex, this.i].a().j().Value)
					{
					case TextAlign.Center:
						num8 = A_0.a() + (this.c - num11) / 2f;
						break;
					case TextAlign.Right:
						num8 = A_0.a() + (this.c - cellPadding.Right.Value - num11 - num2);
						break;
					default:
						num8 = A_0.a() + cellPadding.Left.Value + num;
						break;
					}
					switch (this.b.e().u()[this.ColumnIndex, this.i].a().k().Value)
					{
					case ceTe.DynamicPDF.VAlign.Center:
						num9 = A_0.b() + num7 + (this.d - num10) / 2f + num6;
						break;
					case ceTe.DynamicPDF.VAlign.Bottom:
						num9 = A_0.b() + num7 + (this.d - cellPadding.Bottom.Value - num10 - num4) + num6;
						break;
					default:
						num9 = A_0.b() + cellPadding.Top.Value + num7 + num3 + num6;
						break;
					}
				}
				A_0.c().SetDimensionsShift(num8, num9, num11, num10);
				if (A_0.c().Document.Tag != null)
				{
					if (this.o != null && !this.o.g())
					{
						A_0.c().SetTextMode();
						((Artifact)this.Tag).a(pageWriter, null, null, A_0, true);
						tagOptions = pageWriter.Document.Tag;
						pageWriter.Document.Tag = null;
					}
				}
				this.a.Draw(A_0.c());
				if (this.q == null && this.a.b4())
				{
					((TaggablePageElement)this.a).Tag = null;
				}
				else if (this.a is Group)
				{
					foreach (object obj2 in ((Group)this.a).d())
					{
						PageElement pageElement = (PageElement)obj2;
						if (pageElement.b4())
						{
							((TaggablePageElement)pageElement).Tag = null;
						}
					}
				}
				A_0.c().ResetDimensions();
			}
			if (this.o() != null)
			{
				A_0.c().SetTextMode();
				if (A_0.c().Document.Tag != null)
				{
					if (this.o != null && !this.o.g())
					{
						((Artifact)this.Tag).a(pageWriter, null, null, A_0, true);
						tagOptions = pageWriter.Document.Tag;
						pageWriter.Document.Tag = null;
					}
				}
				AttributeTypeList attributeTypeList = null;
				AttributeClassList a_ = null;
				StructureElement structureElement2 = null;
				if (pageWriter.Document.Tag != null)
				{
					if (this.r && this.b.Tag != null)
					{
						Artifact.a(pageWriter);
					}
					else if (this.o().l())
					{
						structureElement2 = new StructureElement(TagType.Paragraph, true);
						structureElement2.a(false);
						AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
						attributeTypeList = new AttributeTypeList(1);
						attributeTypeList.Add(attributeObject);
						AttributeObject attributeObject2 = new AttributeObject(attributeObject.Owner);
						attributeObject2.a(A_0, this, true);
						structureElement2.AttributeLists.Add(attributeObject2);
						structureElement2.Order = this.p;
						structureElement2.Parent = structureElement;
					}
					else
					{
						StructureElement structureElement3 = new StructureElement(TagType.Paragraph, true);
						structureElement3.a(false);
						structureElement3.Order = this.p;
						structureElement3.Parent = structureElement;
						structureElement3.a(A_0, this);
					}
				}
				switch (this.b.e().u()[this.ColumnIndex, this.i].a().k().Value)
				{
				case ceTe.DynamicPDF.VAlign.Center:
				{
					float num12 = (this.y == this.o().Count) ? (this.d / 2f - this.o().GetRequiredHeight(0) / 2f) : (this.d / 2f - this.a(this.x, this.y) / 2f);
					this.o().k2(A_0.c(), A_0.a() + cellPadding.Left.Value + num, A_0.b() + num7 + num12 + num6, this.b.e().u()[this.ColumnIndex, this.i].a().j().Value, this.b.e().u()[this.ColumnIndex, this.i].a().i(), null, 0f, this.b.e().u()[this.ColumnIndex, this.i].a().f().Value, this.x, this.y, this.b.e().u()[this.ColumnIndex, this.i].a().e().Value, false, structureElement2, attributeTypeList, a_, false);
					break;
				}
				case ceTe.DynamicPDF.VAlign.Bottom:
				{
					float num13 = (this.y == this.o().Count) ? (this.d - this.o().GetRequiredHeight(0)) : (this.d - this.a(this.x, this.y));
					num13 = num13 - cellPadding.Bottom.Value - num4;
					this.o().k2(A_0.c(), A_0.a() + cellPadding.Left.Value + num, A_0.b() + num7 + num13 + num6, this.b.e().u()[this.ColumnIndex, this.i].a().j().Value, this.b.e().u()[this.ColumnIndex, this.i].a().i(), null, 0f, this.b.e().u()[this.ColumnIndex, this.i].a().f().Value, this.x, this.y, this.b.e().u()[this.ColumnIndex, this.i].a().e().Value, false, structureElement2, attributeTypeList, a_, false);
					break;
				}
				default:
					this.o().k2(A_0.c(), A_0.a() + cellPadding.Left.Value + num, A_0.b() + cellPadding.Top.Value + num7 + num3 + num6, this.b.e().u()[this.ColumnIndex, this.i].a().j().Value, this.b.e().u()[this.ColumnIndex, this.i].a().i(), null, 0f, this.b.e().u()[this.ColumnIndex, this.i].a().f().Value, this.x, this.y, this.b.e().u()[this.ColumnIndex, this.i].a().e().Value, false, structureElement2, attributeTypeList, a_, false);
					break;
				}
				if (pageWriter.Document.Tag != null)
				{
					pageWriter.z();
				}
			}
			A_0.a(A_0.a() + this.c);
			this.r = true;
			if (tagOptions != null && this.o != null && !this.o.g())
			{
				Tag.a(A_0.c());
				A_0.c().Document.Tag = tagOptions;
			}
		}

		// Token: 0x06004665 RID: 18021 RVA: 0x00242594 File Offset: 0x00241594
		internal void b()
		{
			if (this.f == 1)
			{
				this.c = this.b.e().c()[this.h].Width;
			}
			else
			{
				float num = 0f;
				for (int i = this.h; i < this.h + this.f; i++)
				{
					if (i >= this.b.e().c().Count)
					{
						break;
					}
					num += this.b.e().c()[i].Width + this.b.e().o();
				}
				this.c = num - this.b.e().o();
			}
		}

		// Token: 0x06004666 RID: 18022 RVA: 0x00242678 File Offset: 0x00241678
		internal float a(bool A_0)
		{
			if (A_0)
			{
				float num = 0f;
				float num2 = 0f;
				q1 q = this.b.e().u()[this.ColumnIndex, this.i].a();
				CellPadding cellPadding = this.b.e().u()[this.ColumnIndex, this.i].c();
				float num3 = cellPadding.Top.Value;
				float num4 = cellPadding.Bottom.Value;
				float num5 = cellPadding.Left.Value;
				float num6 = cellPadding.Right.Value;
				if (this.a != null)
				{
					if (this.a is IArea)
					{
						IArea area = (IArea)this.a;
						num = area.Height + num3 + num4 + this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value + this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
					}
					else if (this.a is BarCode)
					{
						BarCode barCode = (BarCode)this.a;
						num = x5.b(barCode.b7()) + barCode.Height + num3 + num4 + this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value + this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
					}
					else if (this.a is Chart)
					{
						Chart chart = (Chart)this.a;
						num = x5.b(chart.b7()) + chart.Height + num3 + num4 + this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value + this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
					}
				}
				float num7 = this.c - num5 - num6 - this.b.e().u()[this.ColumnIndex, this.i].b().Left.Width.Value - this.b.e().u()[this.ColumnIndex, this.i].b().Right.Width.Value;
				this.a(num7);
				if (this.j != null && this.o() == null && !this.e())
				{
					this.a(q.g().GetTextLines(this.j.ToCharArray(), num7, q.h().Value));
				}
				if (this.o() != null)
				{
					this.o().AutoLeading = q.a().Value;
					if (q.b() != null)
					{
						this.o().Leading = q.b().Value;
					}
					this.o().ParagraphIndent = q.c().Value;
					this.o().ParagraphSpacing = q.d().Value;
					this.x = 0;
					this.y = this.o().Count;
					num2 = this.o().GetRequiredHeight(0) + num3 + num4 + this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value + this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value;
				}
				if (num2 >= num)
				{
					this.e = num2;
				}
				else
				{
					this.e = num;
				}
			}
			return this.e;
		}

		// Token: 0x06004667 RID: 18023 RVA: 0x00242BB8 File Offset: 0x00241BB8
		internal void a(float A_0, float A_1, bool A_2)
		{
			if (this.b.e().u() == null)
			{
				this.b.e().ae();
			}
			CellPadding cellPadding = this.b.e().u()[this.ColumnIndex, this.i].c();
			float num = cellPadding.Top.Value;
			float num2 = cellPadding.Bottom.Value;
			float num3 = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value + this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value + num + num2;
			float num4 = A_0;
			if (A_0 == 0f)
			{
				A_0 = A_1;
			}
			for (int i = this.i(); i < this.o().Count; i++)
			{
				if (num3 + this.o().Leading > A_0)
				{
					if (i == this.i())
					{
						this.y = i + 1;
						num3 += this.o().Leading;
					}
					else
					{
						this.y = i;
					}
					this.b.a(true);
					break;
				}
				this.y = i + 1;
				num3 += this.o().Leading;
			}
			if (this.y == this.o().Count || this.y == this.x)
			{
				this.z = true;
			}
			this.c(num3);
			if ((num4 == 0f && A_2) || (this.b.g() < num3 && this.b.g() < this.b.ActualRowHeight))
			{
				this.b.b(num3);
			}
		}

		// Token: 0x06004668 RID: 18024 RVA: 0x00242E0C File Offset: 0x00241E0C
		internal float a(float A_0, float A_1, bool A_2, ref bool A_3)
		{
			if (this.b.e().u() == null)
			{
				this.b.e().ae();
			}
			CellPadding cellPadding = this.b.e().u()[this.ColumnIndex, this.i].c();
			float num = cellPadding.Top.Value;
			float num2 = cellPadding.Bottom.Value;
			float num3 = this.b.e().u()[this.ColumnIndex, this.i].b().Top.Width.Value + this.b.e().u()[this.ColumnIndex, this.i].b().Bottom.Width.Value + num + num2;
			A_1 -= A_0;
			int num4 = this.y;
			for (int i = this.x; i < this.o().Count; i++)
			{
				if (num3 + this.o().Leading > A_1)
				{
					if (i == this.x && A_2)
					{
						num3 += this.o().Leading;
						this.y = i + 1;
						this.b.a(true);
					}
					else
					{
						this.y = i;
						if (i != this.x)
						{
							this.b.a(true);
						}
					}
					break;
				}
				num3 += this.o().Leading;
				this.y = i + 1;
			}
			float result;
			if (this.o() != null && this.y == this.x)
			{
				A_3 = false;
				this.y = num4;
				result = 0f;
			}
			else if (this.x != this.o().Count)
			{
				A_3 = true;
				this.z = (this.y == this.o().Count);
				this.c(num3);
				result = ((this.x == this.y) ? 0f : num3);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06004669 RID: 18025 RVA: 0x0024308C File Offset: 0x0024208C
		internal Cell2 a(Row2 A_0, qy A_1)
		{
			Cell2 cell = new Cell2();
			cell.a = this.a;
			cell.b = A_0;
			cell.c = this.c;
			cell.d = this.d;
			cell.e = this.e;
			cell.f = this.f;
			cell.g = this.g;
			cell.h = this.h;
			cell.i = this.i;
			cell.j = this.j;
			cell.k = this.k;
			if (this.l != null)
			{
				cell.l = this.l.m();
			}
			if (this.m != null)
			{
				cell.m = this.m.a(A_1);
			}
			if (this.n != null)
			{
				cell.n = this.n.b(A_1);
			}
			cell.o = this.o;
			cell.p = this.p;
			cell.q = this.q;
			cell.r = this.r;
			if (this.s != null)
			{
				cell.s = new qz(this.s.a(), this.s.b(), this.s.c(), this.s.d(), this.s.e(), this.s.f(), this.s.g());
			}
			if (this.t != null)
			{
				cell.t = new qz(this.t.a(), this.t.b(), this.t.c(), this.t.d(), this.t.e(), this.t.f(), this.t.g());
			}
			if (this.u != null)
			{
				cell.u = new qz(this.u.a(), this.u.b(), this.u.c(), this.u.d(), this.u.e(), this.u.f(), this.u.g());
			}
			if (this.v != null)
			{
				cell.v = new qz(this.v.a(), this.v.b(), this.v.c(), this.v.d(), this.v.e(), this.v.f(), this.v.g());
			}
			cell.w = this.w;
			cell.x = this.x;
			cell.y = this.y;
			cell.z = this.z;
			cell.aa = this.aa;
			cell.ab = this.ab;
			cell.ac = this.ac;
			cell.ad = this.ad;
			cell.ae = this.ae;
			return cell;
		}

		// Token: 0x0600466A RID: 18026 RVA: 0x002433B8 File Offset: 0x002423B8
		internal float c()
		{
			float result;
			if (this.g == 1)
			{
				result = this.b.f();
			}
			else
			{
				float num = 0f;
				for (int i = this.i; i < this.i + this.g; i++)
				{
					if (i < this.b.e().d().Count)
					{
						num += this.b.e().d()[i].f() + this.b.e().o();
					}
				}
				result = num - this.b.e().o();
			}
			return result;
		}

		// Token: 0x0600466B RID: 18027 RVA: 0x00243478 File Offset: 0x00242478
		internal float a(q0 A_0, int? A_1)
		{
			float num = 0f;
			if (this.g >= 1 && A_0.d().f() == null)
			{
				if (this.g == 1 || this.e() || this.b.c() || this.e == 0f)
				{
					if (this.b.g() < this.aa)
					{
						return this.aa;
					}
					if (this.g > 1 && A_0.d().d())
					{
						if (this.u() + this.g - 1 > A_1)
						{
							num += this.b.g() + this.b.e().o();
							for (int i = A_1.Value + 1; i < this.i + this.g; i++)
							{
								if (i < this.b.e().d().Count)
								{
									num += this.b.e().d()[i].f() + this.b.e().o();
								}
							}
							return num - this.b.e().o();
						}
					}
					return this.b.g();
				}
				else if (A_1 != null && this.g > 1 && A_0.d().d() && !this.e())
				{
					if (this.u() + this.g - 1 > A_1)
					{
						num += this.b.g() + this.b.e().o();
						for (int i = A_1.Value + 1; i < this.i + this.g; i++)
						{
							if (i < this.b.e().d().Count)
							{
								num += this.b.e().d()[i].f() + this.b.e().o();
							}
						}
						return num - this.b.e().o();
					}
					return this.b.g();
				}
			}
			float result;
			if (this.g > 1 && A_0.d().f() != null && this.g > A_0.d().f())
			{
				int i = this.i;
				for (;;)
				{
					int num2 = i;
					if (!(num2 < this.i + A_0.d().f()))
					{
						break;
					}
					if (i < this.b.e().d().Count)
					{
						num += this.b.e().d()[i].f() + this.b.e().o();
					}
					i++;
				}
				result = num - this.b.e().o();
			}
			else if (A_0.d().h() < this.b.e().d().Count)
			{
				for (int i = this.i; i < this.i + this.g; i++)
				{
					if (i > A_0.d().h())
					{
						break;
					}
					if (this.b.e().d()[i].f() != 0f)
					{
						if (i == A_0.d().h() && i != this.i + this.g)
						{
							num += this.b.e().d()[i].g() + this.b.e().o();
						}
						else
						{
							num += this.b.e().d()[i].f() + this.b.e().o();
						}
					}
					else
					{
						num += this.b.g() + this.b.e().o();
					}
				}
				result = num - this.b.e().o();
			}
			else
			{
				for (int i = this.i; i < this.i + this.g; i++)
				{
					if (i < this.b.e().d().Count)
					{
						if (this.b.e().d()[i].f() != 0f)
						{
							num += this.b.e().d()[i].f() + this.b.e().o();
						}
						else
						{
							num += this.b.g() + this.b.e().o();
						}
					}
				}
				result = num - this.b.e().o();
			}
			return result;
		}

		// Token: 0x0600466C RID: 18028 RVA: 0x00243AD8 File Offset: 0x00242AD8
		private float a()
		{
			return this.b.e().o();
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x0600466D RID: 18029 RVA: 0x00243AFC File Offset: 0x00242AFC
		// (set) Token: 0x0600466E RID: 18030 RVA: 0x00243B14 File Offset: 0x00242B14
		public bool Splittable
		{
			get
			{
				return this.w;
			}
			set
			{
				this.w = value;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x0600466F RID: 18031 RVA: 0x00243B20 File Offset: 0x00242B20
		// (set) Token: 0x06004670 RID: 18032 RVA: 0x00243B38 File Offset: 0x00242B38
		public string Text
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
				this.b.e().a(true);
				this.b.e().c(true);
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06004671 RID: 18033 RVA: 0x00243B68 File Offset: 0x00242B68
		// (set) Token: 0x06004672 RID: 18034 RVA: 0x00243B80 File Offset: 0x00242B80
		public PageElement Element
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.b.e().a(true);
				this.b.e().c(true);
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06004673 RID: 18035 RVA: 0x00243BB0 File Offset: 0x00242BB0
		// (set) Token: 0x06004674 RID: 18036 RVA: 0x00243BF4 File Offset: 0x00242BF4
		public CellPadding Padding
		{
			get
			{
				if (this.n == null)
				{
					this.n = new CellPadding(this.b.e());
				}
				return this.n;
			}
			set
			{
				this.n = value;
				this.n.a(this.b.e());
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06004675 RID: 18037 RVA: 0x00243C58 File Offset: 0x00242C58
		public Border Border
		{
			get
			{
				if (this.m == null)
				{
					this.m = new Border(this.b.e());
				}
				return this.m;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06004676 RID: 18038 RVA: 0x00243C98 File Offset: 0x00242C98
		// (set) Token: 0x06004677 RID: 18039 RVA: 0x00243CD0 File Offset: 0x00242CD0
		public float? FontSize
		{
			get
			{
				float? result;
				if (this.l != null)
				{
					result = this.l.h();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.d(value);
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06004678 RID: 18040 RVA: 0x00243D3C File Offset: 0x00242D3C
		// (set) Token: 0x06004679 RID: 18041 RVA: 0x00243D6C File Offset: 0x00242D6C
		public Font Font
		{
			get
			{
				Font result;
				if (this.l != null)
				{
					result = this.l.g();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(value);
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x0600467A RID: 18042 RVA: 0x00243DD8 File Offset: 0x00242DD8
		public Row2 Row
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600467B RID: 18043 RVA: 0x00243DF0 File Offset: 0x00242DF0
		public int ColumnIndex
		{
			get
			{
				if (this.b.e().m())
				{
					this.b.e().ac();
				}
				return this.h;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x0600467C RID: 18044 RVA: 0x00243E30 File Offset: 0x00242E30
		// (set) Token: 0x0600467D RID: 18045 RVA: 0x00243E48 File Offset: 0x00242E48
		public int ColumnSpan
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
				this.b.e().a(true);
				this.b.e().b(true);
				this.b.e().c(true);
				this.b.e().d(true);
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x0600467E RID: 18046 RVA: 0x00243EA8 File Offset: 0x00242EA8
		// (set) Token: 0x0600467F RID: 18047 RVA: 0x00243EC0 File Offset: 0x00242EC0
		public int RowSpan
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
				this.b.e().a(true);
				this.b.e().b(true);
				this.b.e().c(true);
				this.b.e().d(true);
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06004680 RID: 18048 RVA: 0x00243F20 File Offset: 0x00242F20
		public float Width
		{
			get
			{
				if (this.b.e().m())
				{
					this.b.e().ac();
				}
				return this.c;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06004681 RID: 18049 RVA: 0x00243F60 File Offset: 0x00242F60
		public float Height
		{
			get
			{
				if (this.b.e().l())
				{
					if (this.b.e().m())
					{
						this.b.e().ac();
					}
					this.b.e().ad();
				}
				return this.c();
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06004682 RID: 18050 RVA: 0x00243FCC File Offset: 0x00242FCC
		// (set) Token: 0x06004683 RID: 18051 RVA: 0x00243FFC File Offset: 0x00242FFC
		public Color BackgroundColor
		{
			get
			{
				Color result;
				if (this.l != null)
				{
					result = this.l.l();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.b(value);
				this.b.e().a(null);
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06004684 RID: 18052 RVA: 0x00244044 File Offset: 0x00243044
		// (set) Token: 0x06004685 RID: 18053 RVA: 0x00244074 File Offset: 0x00243074
		public Color TextColor
		{
			get
			{
				Color result;
				if (this.l != null)
				{
					result = this.l.i();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(value);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06004686 RID: 18054 RVA: 0x002440BC File Offset: 0x002430BC
		// (set) Token: 0x06004687 RID: 18055 RVA: 0x002440F4 File Offset: 0x002430F4
		public TextAlign? Align
		{
			get
			{
				TextAlign? result;
				if (this.l != null)
				{
					result = this.l.j();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(value);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06004688 RID: 18056 RVA: 0x0024413C File Offset: 0x0024313C
		// (set) Token: 0x06004689 RID: 18057 RVA: 0x00244174 File Offset: 0x00243174
		public VAlign? VAlign
		{
			get
			{
				VAlign? result;
				if (this.l != null)
				{
					result = this.l.k();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(value);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x0600468A RID: 18058 RVA: 0x002441BC File Offset: 0x002431BC
		// (set) Token: 0x0600468B RID: 18059 RVA: 0x002441F0 File Offset: 0x002431F0
		public bool? AutoLeading
		{
			get
			{
				bool? result;
				if (this.l != null)
				{
					result = this.l.a();
				}
				else
				{
					result = new bool?(true);
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(value);
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x0600468C RID: 18060 RVA: 0x0024425C File Offset: 0x0024325C
		// (set) Token: 0x0600468D RID: 18061 RVA: 0x00244294 File Offset: 0x00243294
		public float? Leading
		{
			get
			{
				float? result;
				if (this.l != null)
				{
					result = this.l.b();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.a(value);
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x0600468E RID: 18062 RVA: 0x00244300 File Offset: 0x00243300
		// (set) Token: 0x0600468F RID: 18063 RVA: 0x00244338 File Offset: 0x00243338
		public float? ParagraphIndent
		{
			get
			{
				float? result;
				if (this.l != null)
				{
					result = this.l.c();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.b(value);
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06004690 RID: 18064 RVA: 0x002443A4 File Offset: 0x002433A4
		// (set) Token: 0x06004691 RID: 18065 RVA: 0x002443DC File Offset: 0x002433DC
		public float? ParagraphSpacing
		{
			get
			{
				float? result;
				if (this.l != null)
				{
					result = this.l.d();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.c(value);
				this.b.e().a(true);
				this.b.e().c(true);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06004692 RID: 18066 RVA: 0x00244448 File Offset: 0x00243448
		// (set) Token: 0x06004693 RID: 18067 RVA: 0x00244480 File Offset: 0x00243480
		public bool? RightToLeft
		{
			get
			{
				bool? result;
				if (this.l != null)
				{
					result = this.l.e();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.b(value);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06004694 RID: 18068 RVA: 0x002444C8 File Offset: 0x002434C8
		// (set) Token: 0x06004695 RID: 18069 RVA: 0x00244500 File Offset: 0x00243500
		public bool? Underline
		{
			get
			{
				bool? result;
				if (this.l != null)
				{
					result = this.l.f();
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (this.l == null)
				{
					this.l = new q1();
				}
				this.l.c(value);
				this.b.e().a(null);
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06004696 RID: 18070 RVA: 0x00244548 File Offset: 0x00243548
		// (set) Token: 0x06004697 RID: 18071 RVA: 0x00244560 File Offset: 0x00243560
		public Tag Tag
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
				if (this.o != null && this.o.g())
				{
					((StructureElement)this.o).a(false);
				}
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06004698 RID: 18072 RVA: 0x002445A8 File Offset: 0x002435A8
		// (set) Token: 0x06004699 RID: 18073 RVA: 0x002445C0 File Offset: 0x002435C0
		public int TagOrder
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x0600469A RID: 18074 RVA: 0x002445CC File Offset: 0x002435CC
		internal float d()
		{
			return this.e;
		}

		// Token: 0x0600469B RID: 18075 RVA: 0x002445E4 File Offset: 0x002435E4
		internal bool e()
		{
			return this.ac;
		}

		// Token: 0x0600469C RID: 18076 RVA: 0x002445FC File Offset: 0x002435FC
		internal void b(bool A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x0600469D RID: 18077 RVA: 0x00244606 File Offset: 0x00243606
		internal void a(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600469E RID: 18078 RVA: 0x00244610 File Offset: 0x00243610
		internal void b(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600469F RID: 18079 RVA: 0x0024461C File Offset: 0x0024361C
		internal float? f()
		{
			return this.ad;
		}

		// Token: 0x060046A0 RID: 18080 RVA: 0x00244634 File Offset: 0x00243634
		internal void a(float? A_0)
		{
			this.ad = A_0;
		}

		// Token: 0x060046A1 RID: 18081 RVA: 0x00244640 File Offset: 0x00243640
		internal float g()
		{
			return this.ab;
		}

		// Token: 0x060046A2 RID: 18082 RVA: 0x00244658 File Offset: 0x00243658
		internal void a(float A_0)
		{
			this.ab = A_0;
		}

		// Token: 0x060046A3 RID: 18083 RVA: 0x00244662 File Offset: 0x00243662
		internal void a(PageElement A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060046A4 RID: 18084 RVA: 0x0024466C File Offset: 0x0024366C
		internal void b(float A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060046A5 RID: 18085 RVA: 0x00244678 File Offset: 0x00243678
		internal float h()
		{
			return this.aa;
		}

		// Token: 0x060046A6 RID: 18086 RVA: 0x00244690 File Offset: 0x00243690
		internal void c(float A_0)
		{
			this.aa = A_0;
		}

		// Token: 0x060046A7 RID: 18087 RVA: 0x0024469C File Offset: 0x0024369C
		internal int i()
		{
			return this.x;
		}

		// Token: 0x060046A8 RID: 18088 RVA: 0x002446B4 File Offset: 0x002436B4
		internal void c(int A_0)
		{
			this.x = A_0;
		}

		// Token: 0x060046A9 RID: 18089 RVA: 0x002446C0 File Offset: 0x002436C0
		internal int j()
		{
			return this.y;
		}

		// Token: 0x060046AA RID: 18090 RVA: 0x002446D8 File Offset: 0x002436D8
		internal void d(int A_0)
		{
			this.y = A_0;
		}

		// Token: 0x060046AB RID: 18091 RVA: 0x002446E4 File Offset: 0x002436E4
		internal bool k()
		{
			return this.z;
		}

		// Token: 0x060046AC RID: 18092 RVA: 0x002446FC File Offset: 0x002436FC
		internal void c(bool A_0)
		{
			this.z = A_0;
		}

		// Token: 0x060046AD RID: 18093 RVA: 0x00244708 File Offset: 0x00243708
		internal Border l()
		{
			return this.m;
		}

		// Token: 0x060046AE RID: 18094 RVA: 0x00244720 File Offset: 0x00243720
		internal CellPadding m()
		{
			return this.n;
		}

		// Token: 0x060046AF RID: 18095 RVA: 0x00244738 File Offset: 0x00243738
		internal q1 n()
		{
			return this.l;
		}

		// Token: 0x060046B0 RID: 18096 RVA: 0x00244750 File Offset: 0x00243750
		internal TextLineList o()
		{
			return this.k;
		}

		// Token: 0x060046B1 RID: 18097 RVA: 0x00244768 File Offset: 0x00243768
		internal void a(TextLineList A_0)
		{
			this.k = A_0;
		}

		// Token: 0x060046B2 RID: 18098 RVA: 0x00244774 File Offset: 0x00243774
		internal qz p()
		{
			return this.s;
		}

		// Token: 0x060046B3 RID: 18099 RVA: 0x0024478C File Offset: 0x0024378C
		internal qz q()
		{
			return this.t;
		}

		// Token: 0x060046B4 RID: 18100 RVA: 0x002447A4 File Offset: 0x002437A4
		internal qz r()
		{
			return this.u;
		}

		// Token: 0x060046B5 RID: 18101 RVA: 0x002447BC File Offset: 0x002437BC
		internal qz s()
		{
			return this.v;
		}

		// Token: 0x060046B6 RID: 18102 RVA: 0x002447D4 File Offset: 0x002437D4
		internal int t()
		{
			return this.h;
		}

		// Token: 0x060046B7 RID: 18103 RVA: 0x002447EC File Offset: 0x002437EC
		internal void e(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x060046B8 RID: 18104 RVA: 0x002447F8 File Offset: 0x002437F8
		internal int u()
		{
			return this.i;
		}

		// Token: 0x060046B9 RID: 18105 RVA: 0x00244810 File Offset: 0x00243810
		internal void f(int A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060046BA RID: 18106 RVA: 0x0024481C File Offset: 0x0024381C
		internal bool v()
		{
			return this.ae;
		}

		// Token: 0x060046BB RID: 18107 RVA: 0x00244834 File Offset: 0x00243834
		internal void d(bool A_0)
		{
			this.ae = A_0;
		}

		// Token: 0x040026E8 RID: 9960
		private PageElement a = null;

		// Token: 0x040026E9 RID: 9961
		private Row2 b;

		// Token: 0x040026EA RID: 9962
		private float c;

		// Token: 0x040026EB RID: 9963
		private float d;

		// Token: 0x040026EC RID: 9964
		private float e;

		// Token: 0x040026ED RID: 9965
		private int f;

		// Token: 0x040026EE RID: 9966
		private int g;

		// Token: 0x040026EF RID: 9967
		private int h;

		// Token: 0x040026F0 RID: 9968
		private int i;

		// Token: 0x040026F1 RID: 9969
		private string j;

		// Token: 0x040026F2 RID: 9970
		private TextLineList k = null;

		// Token: 0x040026F3 RID: 9971
		private q1 l;

		// Token: 0x040026F4 RID: 9972
		private Border m = null;

		// Token: 0x040026F5 RID: 9973
		private CellPadding n = null;

		// Token: 0x040026F6 RID: 9974
		private Tag o;

		// Token: 0x040026F7 RID: 9975
		private int p = 0;

		// Token: 0x040026F8 RID: 9976
		private Tag q = null;

		// Token: 0x040026F9 RID: 9977
		private bool r = false;

		// Token: 0x040026FA RID: 9978
		private qz s = null;

		// Token: 0x040026FB RID: 9979
		private qz t = null;

		// Token: 0x040026FC RID: 9980
		private qz u = null;

		// Token: 0x040026FD RID: 9981
		private qz v = null;

		// Token: 0x040026FE RID: 9982
		private bool w = false;

		// Token: 0x040026FF RID: 9983
		private int x = 0;

		// Token: 0x04002700 RID: 9984
		private int y = 0;

		// Token: 0x04002701 RID: 9985
		private bool z = true;

		// Token: 0x04002702 RID: 9986
		private float aa = 0f;

		// Token: 0x04002703 RID: 9987
		private float ab = 0f;

		// Token: 0x04002704 RID: 9988
		private bool ac = false;

		// Token: 0x04002705 RID: 9989
		private float? ad = null;

		// Token: 0x04002706 RID: 9990
		private bool ae = false;
	}
}
