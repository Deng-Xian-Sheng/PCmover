using System;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200071E RID: 1822
	[Obsolete("This class is obsolete. Use Cell2 class instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Cell
	{
		// Token: 0x06004873 RID: 18547 RVA: 0x00256500 File Offset: 0x00255500
		internal Cell(Row A_0, string A_1, Font A_2, float A_3, Color A_4, Color A_5, int A_6, int A_7)
		{
			this.c = A_0;
			this.g = A_6;
			this.h = A_7;
			this.l = A_2;
			this.m = A_3;
			this.n = A_4;
			this.k = A_5;
			this.a = Font.Helvetica.GetTextLines(A_1.ToCharArray(), 100f, 12f);
		}

		// Token: 0x06004874 RID: 18548 RVA: 0x002565D8 File Offset: 0x002555D8
		internal Cell(Row A_0, PageElement A_1, int A_2, int A_3)
		{
			this.c = A_0;
			this.b = A_1;
			this.g = A_2;
			this.h = A_3;
		}

		// Token: 0x06004875 RID: 18549 RVA: 0x00256678 File Offset: 0x00255678
		internal void a(acx A_0)
		{
			Color color = this.d();
			this.e = this.h();
			float num = A_0.d().a().q;
			if (num > 0f || color != null)
			{
				A_0.c().SetGraphicsMode();
				bool flag;
				bool flag2;
				if (num > 0f && color != null)
				{
					A_0.c().SetLineWidth(num);
					A_0.c().SetLineStyle(LineStyle.Solid);
					flag = true;
					flag2 = true;
				}
				else if (num > 0f && color == null)
				{
					A_0.c().SetLineWidth(num);
					A_0.c().SetLineStyle(LineStyle.Solid);
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
				A_0.c().SetStrokeColor(A_0.d().a().r);
				A_0.c().Write_re(A_0.a(), A_0.b(), this.d, this.e);
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
			A_0.a(A_0.a() + this.d);
		}

		// Token: 0x06004876 RID: 18550 RVA: 0x00256808 File Offset: 0x00255808
		internal void b(acx A_0)
		{
			float num = this.g();
			if (this.b != null)
			{
				float x;
				float y;
				float num2;
				float num3;
				if (!(this.b is IArea))
				{
					x = A_0.a() + num;
					y = A_0.b() + num;
					num2 = this.e - num * 2f;
					num3 = this.d - num * 2f;
				}
				else
				{
					IArea area = (IArea)this.b;
					num2 = area.Height;
					num3 = area.Width;
					switch (this.b())
					{
					case TextAlign.Center:
						x = A_0.a() + (this.d - num3) / 2f;
						break;
					case TextAlign.Right:
						x = A_0.a() + (this.d - num - num3);
						break;
					default:
						x = A_0.a() + num;
						break;
					}
					switch (this.a())
					{
					case ceTe.DynamicPDF.VAlign.Center:
						y = A_0.b() + (this.e - num2) / 2f;
						break;
					case ceTe.DynamicPDF.VAlign.Bottom:
						y = A_0.b() + (this.e - num - num2);
						break;
					default:
						y = A_0.b() + num;
						break;
					}
				}
				A_0.c().SetDimensionsShift(x, y, num3, num2);
				this.b.Draw(A_0.c());
				A_0.c().ResetDimensions();
			}
			if (this.a != null)
			{
				A_0.c().SetTextMode();
				this.a.Font = this.e();
				if (this.a.Font is OpenTypeFont && ((OpenTypeFont)this.a.Font).UseCharacterShaping)
				{
					this.a = this.a.Font.a(this.a);
				}
				this.a.FontSize = this.f();
				switch (this.a())
				{
				case ceTe.DynamicPDF.VAlign.Center:
				{
					float num4 = this.e / 2f - this.a.GetRequiredHeight(0) / 2f;
					this.a.ja(A_0.c(), A_0.a() + num, A_0.b() + num4, this.b(), this.c(), null, 0f, this.q, this.p, false);
					break;
				}
				case ceTe.DynamicPDF.VAlign.Bottom:
				{
					float num5 = this.e - this.a.GetRequiredHeight(0) - num;
					this.a.ja(A_0.c(), A_0.a() + num, A_0.b() + num5, this.b(), this.c(), null, 0f, this.q, this.p, false);
					break;
				}
				default:
					this.a.ja(A_0.c(), A_0.a() + num, A_0.b() + num, this.b(), this.c(), null, 0f, this.q, this.p, false);
					break;
				}
			}
			A_0.a(A_0.a() + this.d);
		}

		// Token: 0x06004877 RID: 18551 RVA: 0x00256B5C File Offset: 0x00255B5C
		internal void a(acx A_0, StructureElement A_1)
		{
			if (this.v == null && this.b != null && this.b.b4())
			{
				this.v = ((TaggablePageElement)this.b).Tag;
			}
			TagOptions tagOptions = null;
			PageWriter pageWriter = A_0.c();
			StructureElement structureElement = null;
			if (pageWriter.Document.Tag != null)
			{
				if (this.t == null)
				{
					structureElement = new StructureElement((this.c.c().ab && this.c.c().aa) ? TagType.TableDataCell : TagType.TableHeader, true);
					structureElement.a(false);
					structureElement.Parent = A_1;
					structureElement.Order = this.u;
					pageWriter.Document.j().e(structureElement);
					structureElement.a(A_0, this, false);
					if (this.c.Tag != null)
					{
						this.t = structureElement;
					}
				}
				else if (this.t.g())
				{
					structureElement = (StructureElement)this.t;
					if (!structureElement.u())
					{
						if (structureElement.Parent == null)
						{
							structureElement.Parent = A_1;
						}
						pageWriter.Document.j().e(structureElement);
						structureElement.a(A_0, this, false);
					}
				}
				if (this.b != null && this.b.b4() && (this.t == null || this.t.g()))
				{
					if (this.v == null)
					{
						((TaggablePageElement)this.b).a(structureElement, !this.c.c().ab || !this.c.c().aa, null, this.w);
					}
					else if (this.v.g() && !pageWriter.Document.j().f().Contains(this.v))
					{
						((TaggablePageElement)this.b).a(structureElement, !this.c.c().ab || !this.c.c().aa, (StructureElement)this.v, this.w);
					}
				}
				else if (this.b is Group)
				{
					foreach (object obj in ((Group)this.b).d())
					{
						PageElement pageElement = (PageElement)obj;
						if (pageElement.b4() && (this.t == null || this.t.g()))
						{
							((TaggablePageElement)pageElement).a(structureElement, !this.c.c().ab || !this.c.c().aa, null, this.w);
						}
					}
				}
			}
			float num = this.g();
			if (this.b != null)
			{
				float x;
				float y;
				float num2;
				float num3;
				if (!(this.b is IArea))
				{
					x = A_0.a() + num;
					y = A_0.b() + num;
					num2 = this.e - num * 2f;
					num3 = this.d - num * 2f;
				}
				else
				{
					IArea area = (IArea)this.b;
					num2 = area.Height;
					num3 = area.Width;
					switch (this.b())
					{
					case TextAlign.Center:
						x = A_0.a() + (this.d - num3) / 2f;
						break;
					case TextAlign.Right:
						x = A_0.a() + (this.d - num - num3);
						break;
					default:
						x = A_0.a() + num;
						break;
					}
					switch (this.a())
					{
					case ceTe.DynamicPDF.VAlign.Center:
						y = A_0.b() + (this.e - num2) / 2f;
						break;
					case ceTe.DynamicPDF.VAlign.Bottom:
						y = A_0.b() + (this.e - num - num2);
						break;
					default:
						y = A_0.b() + num;
						break;
					}
				}
				A_0.c().SetDimensionsShift(x, y, num3, num2);
				if (A_0.c().Document.Tag != null)
				{
					if (this.t != null && !this.t.g())
					{
						A_0.c().SetTextMode();
						((Artifact)this.Tag).a(pageWriter, null, null, A_0);
						tagOptions = pageWriter.Document.Tag;
						pageWriter.Document.Tag = null;
					}
				}
				this.b.Draw(A_0.c());
				if (this.v == null && this.b.b4())
				{
					((TaggablePageElement)this.b).Tag = null;
				}
				else if (this.b is Group)
				{
					foreach (object obj2 in ((Group)this.b).d())
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
			if (this.a != null)
			{
				A_0.c().SetTextMode();
				if (A_0.c().Document.Tag != null)
				{
					if (this.t != null && !this.t.g())
					{
						((Artifact)this.Tag).a(pageWriter, null, null, A_0);
						tagOptions = pageWriter.Document.Tag;
						pageWriter.Document.Tag = null;
					}
				}
				AttributeTypeList attributeTypeList = null;
				AttributeClassList a_ = null;
				StructureElement structureElement2 = null;
				if (pageWriter.Document.Tag != null)
				{
					if (this.w && this.c.Tag != null)
					{
						Artifact.a(pageWriter);
					}
					else if (this.a.l())
					{
						structureElement2 = new StructureElement(TagType.Paragraph, true);
						structureElement2.a(false);
						AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
						attributeTypeList = new AttributeTypeList(1);
						attributeTypeList.Add(attributeObject);
						AttributeObject attributeObject2 = new AttributeObject(attributeObject.Owner);
						attributeObject2.a(A_0, this, true);
						structureElement2.AttributeLists.Add(attributeObject2);
						structureElement2.Order = this.u;
						structureElement2.Parent = structureElement;
					}
					else
					{
						StructureElement structureElement3 = new StructureElement(TagType.Paragraph, true);
						structureElement3.a(false);
						structureElement3.Order = this.u;
						structureElement3.Parent = structureElement;
						structureElement3.a(A_0, this);
					}
				}
				this.a.Font = this.e();
				if (this.a.Font is OpenTypeFont && ((OpenTypeFont)this.a.Font).UseCharacterShaping)
				{
					this.a = this.a.Font.a(this.a);
				}
				this.a.FontSize = this.f();
				switch (this.a())
				{
				case ceTe.DynamicPDF.VAlign.Center:
				{
					float num4 = this.e / 2f - this.a.GetRequiredHeight(0) / 2f;
					this.a.jc(A_0.c(), A_0.a() + num, A_0.b() + num4, this.b(), this.c(), null, 0f, this.q, this.p, false, structureElement2, attributeTypeList, a_);
					break;
				}
				case ceTe.DynamicPDF.VAlign.Bottom:
				{
					float num5 = this.e - this.a.GetRequiredHeight(0) - num;
					this.a.jc(A_0.c(), A_0.a() + num, A_0.b() + num5, this.b(), this.c(), null, 0f, this.q, this.p, false, structureElement2, attributeTypeList, a_);
					break;
				}
				default:
					this.a.jc(A_0.c(), A_0.a() + num, A_0.b() + num, this.b(), this.c(), null, 0f, this.q, this.p, false, structureElement2, attributeTypeList, a_);
					break;
				}
				if (pageWriter.Document.Tag != null)
				{
					pageWriter.z();
				}
			}
			A_0.a(A_0.a() + this.d);
			this.w = true;
			if (tagOptions != null && this.t != null && !this.t.g())
			{
				Tag.a(A_0.c());
				A_0.c().Document.Tag = tagOptions;
			}
		}

		// Token: 0x06004878 RID: 18552 RVA: 0x00257578 File Offset: 0x00256578
		internal void i()
		{
			if (this.g == 1)
			{
				this.d = this.c.c().a[this.i].Width;
			}
			else
			{
				float num = 0f;
				for (int i = this.i; i < this.i + this.g; i++)
				{
					if (i >= this.c.c().a.Count)
					{
						break;
					}
					num += this.c.c().a[i].Width;
				}
				this.d = num;
			}
		}

		// Token: 0x06004879 RID: 18553 RVA: 0x00257634 File Offset: 0x00256634
		internal float a(bool A_0)
		{
			if (A_0)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = this.g();
				if (this.b != null)
				{
					if (this.b is IArea)
					{
						IArea area = (IArea)this.b;
						num = area.Height + num3 * 2f;
					}
				}
				if (this.a != null)
				{
					this.a.Font = this.e();
					if (this.a.Font is OpenTypeFont && ((OpenTypeFont)this.a.Font).UseCharacterShaping)
					{
						this.a = this.a.Font.a(this.a);
					}
					this.a.FontSize = this.f();
					this.a.Width = this.d - num3 * 2f;
					num2 = this.a.GetRequiredHeight(0) + num3 * 2f;
				}
				if (num2 >= num)
				{
					this.f = num2;
				}
				else
				{
					this.f = num;
				}
			}
			return this.f;
		}

		// Token: 0x0600487A RID: 18554 RVA: 0x00257788 File Offset: 0x00256788
		private float h()
		{
			float result;
			if (this.h == 1)
			{
				result = this.c.d();
			}
			else
			{
				float num = 0f;
				for (int i = this.j; i < this.j + this.h; i++)
				{
					if (i < this.c.c().b.Count)
					{
						num += this.c.c().b[i].d();
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x0600487B RID: 18555 RVA: 0x00257820 File Offset: 0x00256820
		private float g()
		{
			float padding;
			if (!this.o.Equals(-3.4028235E+38f))
			{
				padding = this.o;
			}
			else if (!this.c.Padding.Equals(-3.4028235E+38f))
			{
				padding = this.c.Padding;
			}
			else
			{
				padding = this.c.c().h;
			}
			return padding;
		}

		// Token: 0x0600487C RID: 18556 RVA: 0x0025788C File Offset: 0x0025688C
		private float f()
		{
			float fontSize;
			if (!this.m.Equals(-3.4028235E+38f))
			{
				fontSize = this.m;
			}
			else if (!this.c.FontSize.Equals(-3.4028235E+38f))
			{
				fontSize = this.c.FontSize;
			}
			else
			{
				fontSize = this.c.c().g;
			}
			return fontSize;
		}

		// Token: 0x0600487D RID: 18557 RVA: 0x002578F8 File Offset: 0x002568F8
		private Font e()
		{
			Font font;
			if (this.l != null)
			{
				font = this.l;
			}
			else if (this.c.Font != null)
			{
				font = this.c.Font;
			}
			else
			{
				font = this.c.c().f;
			}
			return font;
		}

		// Token: 0x0600487E RID: 18558 RVA: 0x00257954 File Offset: 0x00256954
		private Color d()
		{
			Color result;
			if (this.k != null)
			{
				result = this.k;
			}
			else if (this.c.BackgroundColor != null)
			{
				result = this.c.BackgroundColor;
			}
			else if (this.c.c().e != null)
			{
				result = this.c.c().e;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600487F RID: 18559 RVA: 0x002579CC File Offset: 0x002569CC
		private Color c()
		{
			Color result;
			if (this.n != null)
			{
				result = this.n;
			}
			else if (this.c.TextColor != null)
			{
				result = this.c.TextColor;
			}
			else if (this.c.c().i != null)
			{
				result = this.c.c().i;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06004880 RID: 18560 RVA: 0x00257A44 File Offset: 0x00256A44
		private TextAlign b()
		{
			TextAlign align;
			if (this.s != CellAlign.Inherit)
			{
				align = (TextAlign)this.s;
			}
			else if (this.c.Align != CellAlign.Inherit)
			{
				align = (TextAlign)this.c.Align;
			}
			else
			{
				align = this.c.c().d;
			}
			return align;
		}

		// Token: 0x06004881 RID: 18561 RVA: 0x00257AA0 File Offset: 0x00256AA0
		private VAlign a()
		{
			VAlign valign;
			if (this.r != CellVAlign.Inherit)
			{
				valign = (VAlign)this.r;
			}
			else if (this.c.VAlign != CellVAlign.Inherit)
			{
				valign = (VAlign)this.c.VAlign;
			}
			else
			{
				valign = this.c.c().j;
			}
			return valign;
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06004882 RID: 18562 RVA: 0x00257AFC File Offset: 0x00256AFC
		// (set) Token: 0x06004883 RID: 18563 RVA: 0x00257B34 File Offset: 0x00256B34
		public string Text
		{
			get
			{
				if (this.a == null)
				{
					throw new TableException("This cell contains no text");
				}
				return this.a.GetText();
			}
			set
			{
				this.a.SetText(value);
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06004884 RID: 18564 RVA: 0x00257B68 File Offset: 0x00256B68
		// (set) Token: 0x06004885 RID: 18565 RVA: 0x00257B80 File Offset: 0x00256B80
		public PageElement Element
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x06004886 RID: 18566 RVA: 0x00257BAC File Offset: 0x00256BAC
		internal TextLineList j()
		{
			return this.a;
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06004887 RID: 18567 RVA: 0x00257BC4 File Offset: 0x00256BC4
		// (set) Token: 0x06004888 RID: 18568 RVA: 0x00257BDC File Offset: 0x00256BDC
		public float Padding
		{
			get
			{
				return this.g();
			}
			set
			{
				if (value <= 0f)
				{
					this.o = 0f;
				}
				else
				{
					this.o = value;
				}
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06004889 RID: 18569 RVA: 0x00257C2C File Offset: 0x00256C2C
		// (set) Token: 0x0600488A RID: 18570 RVA: 0x00257C44 File Offset: 0x00256C44
		public float FontSize
		{
			get
			{
				return this.f();
			}
			set
			{
				this.m = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x0600488B RID: 18571 RVA: 0x00257C70 File Offset: 0x00256C70
		// (set) Token: 0x0600488C RID: 18572 RVA: 0x00257C88 File Offset: 0x00256C88
		public Font Font
		{
			get
			{
				return this.e();
			}
			set
			{
				this.l = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x0600488D RID: 18573 RVA: 0x00257CB4 File Offset: 0x00256CB4
		public Row Row
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x0600488E RID: 18574 RVA: 0x00257CCC File Offset: 0x00256CCC
		public int ColumnIndex
		{
			get
			{
				if (this.c.c().v)
				{
					this.c.c().g();
				}
				return this.i;
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x0600488F RID: 18575 RVA: 0x00257D0C File Offset: 0x00256D0C
		// (set) Token: 0x06004890 RID: 18576 RVA: 0x00257D24 File Offset: 0x00256D24
		public int ColumnSpan
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
				this.c.c().s = true;
				this.c.c().t = true;
				this.c.c().u = true;
				this.c.c().v = true;
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06004891 RID: 18577 RVA: 0x00257D80 File Offset: 0x00256D80
		// (set) Token: 0x06004892 RID: 18578 RVA: 0x00257D98 File Offset: 0x00256D98
		public int RowSpan
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
				this.c.c().s = true;
				this.c.c().t = true;
				this.c.c().u = true;
				this.c.c().v = true;
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06004893 RID: 18579 RVA: 0x00257DF4 File Offset: 0x00256DF4
		public float Width
		{
			get
			{
				if (this.c.c().v)
				{
					this.c.c().g();
				}
				return this.d;
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06004894 RID: 18580 RVA: 0x00257E34 File Offset: 0x00256E34
		public float Height
		{
			get
			{
				if (this.c.c().u)
				{
					if (this.c.c().v)
					{
						this.c.c().g();
					}
					this.c.c().h();
				}
				return this.h();
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06004895 RID: 18581 RVA: 0x00257EA0 File Offset: 0x00256EA0
		// (set) Token: 0x06004896 RID: 18582 RVA: 0x00257EB8 File Offset: 0x00256EB8
		public Color BackgroundColor
		{
			get
			{
				return this.d();
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06004897 RID: 18583 RVA: 0x00257EC4 File Offset: 0x00256EC4
		// (set) Token: 0x06004898 RID: 18584 RVA: 0x00257EDC File Offset: 0x00256EDC
		public Color TextColor
		{
			get
			{
				return this.c();
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06004899 RID: 18585 RVA: 0x00257EE8 File Offset: 0x00256EE8
		// (set) Token: 0x0600489A RID: 18586 RVA: 0x00257F00 File Offset: 0x00256F00
		public CellAlign Align
		{
			get
			{
				return (CellAlign)this.b();
			}
			set
			{
				this.s = value;
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x0600489B RID: 18587 RVA: 0x00257F0C File Offset: 0x00256F0C
		// (set) Token: 0x0600489C RID: 18588 RVA: 0x00257F24 File Offset: 0x00256F24
		public CellVAlign VAlign
		{
			get
			{
				return (CellVAlign)this.a();
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x0600489D RID: 18589 RVA: 0x00257F30 File Offset: 0x00256F30
		// (set) Token: 0x0600489E RID: 18590 RVA: 0x00257F68 File Offset: 0x00256F68
		public bool AutoLeading
		{
			get
			{
				if (this.a == null)
				{
					throw new TableException("This cell contains no text and therefore the AutoLeading property does not exist.");
				}
				return this.a.AutoLeading;
			}
			set
			{
				this.a.AutoLeading = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x0600489F RID: 18591 RVA: 0x00257F9C File Offset: 0x00256F9C
		// (set) Token: 0x060048A0 RID: 18592 RVA: 0x00257FD4 File Offset: 0x00256FD4
		public float Leading
		{
			get
			{
				if (this.a == null)
				{
					throw new TableException("This cell contains no text and therefore the Leading property does not exist.");
				}
				return this.a.Leading;
			}
			set
			{
				this.a.Leading = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x060048A1 RID: 18593 RVA: 0x00258008 File Offset: 0x00257008
		// (set) Token: 0x060048A2 RID: 18594 RVA: 0x00258040 File Offset: 0x00257040
		public float ParagraphIndent
		{
			get
			{
				if (this.a == null)
				{
					throw new TableException("This cell contains no text and therefore the ParagraphIndent property does not exist.");
				}
				return this.a.ParagraphIndent;
			}
			set
			{
				this.a.ParagraphIndent = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x060048A3 RID: 18595 RVA: 0x00258074 File Offset: 0x00257074
		// (set) Token: 0x060048A4 RID: 18596 RVA: 0x002580AC File Offset: 0x002570AC
		public float ParagraphSpacing
		{
			get
			{
				if (this.a == null)
				{
					throw new TableException("This cell contains no text and therefore the ParagraphSpacing property does not exist.");
				}
				return this.a.ParagraphSpacing;
			}
			set
			{
				this.a.ParagraphSpacing = value;
				this.c.c().s = true;
				this.c.c().u = true;
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x060048A5 RID: 18597 RVA: 0x002580E0 File Offset: 0x002570E0
		// (set) Token: 0x060048A6 RID: 18598 RVA: 0x002580F8 File Offset: 0x002570F8
		public bool RightToLeft
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

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x060048A7 RID: 18599 RVA: 0x00258104 File Offset: 0x00257104
		// (set) Token: 0x060048A8 RID: 18600 RVA: 0x0025811C File Offset: 0x0025711C
		public bool Underline
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x060048A9 RID: 18601 RVA: 0x00258128 File Offset: 0x00257128
		internal int k()
		{
			return this.i;
		}

		// Token: 0x060048AA RID: 18602 RVA: 0x00258140 File Offset: 0x00257140
		internal void a(int A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060048AB RID: 18603 RVA: 0x0025814C File Offset: 0x0025714C
		internal int l()
		{
			return this.j;
		}

		// Token: 0x060048AC RID: 18604 RVA: 0x00258164 File Offset: 0x00257164
		internal void b(int A_0)
		{
			this.j = A_0;
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x060048AD RID: 18605 RVA: 0x00258170 File Offset: 0x00257170
		// (set) Token: 0x060048AE RID: 18606 RVA: 0x00258188 File Offset: 0x00257188
		public Tag Tag
		{
			get
			{
				return this.t;
			}
			set
			{
				this.t = value;
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x060048AF RID: 18607 RVA: 0x00258194 File Offset: 0x00257194
		// (set) Token: 0x060048B0 RID: 18608 RVA: 0x002581AC File Offset: 0x002571AC
		public int TagOrder
		{
			get
			{
				return this.u;
			}
			set
			{
				this.u = value;
			}
		}

		// Token: 0x0400279F RID: 10143
		private TextLineList a = null;

		// Token: 0x040027A0 RID: 10144
		private PageElement b = null;

		// Token: 0x040027A1 RID: 10145
		private Row c;

		// Token: 0x040027A2 RID: 10146
		private float d;

		// Token: 0x040027A3 RID: 10147
		private float e;

		// Token: 0x040027A4 RID: 10148
		private float f;

		// Token: 0x040027A5 RID: 10149
		private int g;

		// Token: 0x040027A6 RID: 10150
		private int h;

		// Token: 0x040027A7 RID: 10151
		private int i;

		// Token: 0x040027A8 RID: 10152
		private int j;

		// Token: 0x040027A9 RID: 10153
		private Color k = null;

		// Token: 0x040027AA RID: 10154
		private Font l = null;

		// Token: 0x040027AB RID: 10155
		private float m = float.MinValue;

		// Token: 0x040027AC RID: 10156
		private Color n = null;

		// Token: 0x040027AD RID: 10157
		private float o = float.MinValue;

		// Token: 0x040027AE RID: 10158
		private bool p = false;

		// Token: 0x040027AF RID: 10159
		private bool q = false;

		// Token: 0x040027B0 RID: 10160
		private CellVAlign r = CellVAlign.Inherit;

		// Token: 0x040027B1 RID: 10161
		private CellAlign s = CellAlign.Inherit;

		// Token: 0x040027B2 RID: 10162
		private Tag t;

		// Token: 0x040027B3 RID: 10163
		private int u = 0;

		// Token: 0x040027B4 RID: 10164
		private Tag v = null;

		// Token: 0x040027B5 RID: 10165
		private bool w = false;
	}
}
