using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x020002AA RID: 682
	public class FormattedTextArea : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06001E54 RID: 7764 RVA: 0x00131EB8 File Offset: 0x00130EB8
		internal FormattedTextArea(FormattedTextArea A_0, float A_1, float A_2, float A_3) : base(A_1, A_2, A_3)
		{
			this.k = true;
			this.m = A_0.FontFaces;
			this.b = A_0.Width;
			this.f = A_0.d() + A_0.e();
			this.n = A_0.c();
			this.a = A_0.a;
			this.g = this.n.a(this.Height, this.f);
			this.h = this.n.b(this.f);
			this.i = A_0.c().a(this.f).p() - A_0.c().a(this.f).i();
			this.j = true;
			this.c = (this.d = A_0.Style);
			this.u = this.f;
			this.l = A_0.l;
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x0013207C File Offset: 0x0013107C
		public FormattedTextArea(string text, float x, float y, float width, float height, FontFamily fontFamily, float fontSize, bool preserveWhitespace) : base(x, y, height)
		{
			this.ad = text;
			this.a = text.ToCharArray();
			this.b = width;
			this.c = new FormattedTextAreaStyle(fontFamily, fontSize, preserveWhitespace);
		}

		// Token: 0x06001E56 RID: 7766 RVA: 0x00132188 File Offset: 0x00131188
		public FormattedTextArea(string text, float x, float y, float width, float height, FormattedTextAreaStyle style) : base(x, y, height)
		{
			this.ad = text;
			this.a = text.ToCharArray();
			this.b = width;
			this.c = style;
		}

		// Token: 0x06001E57 RID: 7767 RVA: 0x0013228C File Offset: 0x0013128C
		internal FormattedTextArea(ceTe.DynamicPDF.ReportWriter.ReportElements.FormattedRecordArea A_0, char[] A_1) : base(A_0.X, A_0.Y, A_0.Height, A_0.Angle)
		{
			this.a = A_1;
			this.b = A_0.Width;
			this.c = A_0.InitialStyle;
			this.l = A_0.VAlign;
			this.m = A_0.a();
		}

		// Token: 0x06001E58 RID: 7768 RVA: 0x001323B8 File Offset: 0x001313B8
		internal FormattedTextArea(rw A_0, float A_1, float A_2, float A_3) : base(A_1, A_2, A_3)
		{
			this.m = A_0.FontFaces;
			this.b = A_0.Width;
			this.f = A_0.d() + A_0.e();
			this.n = A_0.c();
			this.a = A_0.a;
			this.g = this.c().a(this.Height, this.d());
			this.h = this.c().b(this.d());
			this.i = A_0.c().a(this.d()).p() - A_0.c().a(this.d()).i();
			this.j = true;
			this.c = (this.d = A_0.Style);
			this.l = A_0.l;
		}

		// Token: 0x06001E59 RID: 7769 RVA: 0x00132568 File Offset: 0x00131568
		internal FormattedTextArea(rw A_0) : base(A_0.X, A_0.Y, A_0.Height)
		{
			this.Width = A_0.Width;
			this.Style = A_0.Style;
			this.a(A_0.h());
			this.e = A_0.e;
			this.b(A_0.d());
			this.c(A_0.e());
			this.c(A_0.i());
			this.b(A_0.f());
			this.a(A_0.g());
			this.b(A_0.j());
			this.a(A_0.b());
			this.VAlign = A_0.VAlign;
			this.m = A_0.FontFaces;
			this.a(new FormattedTextArea.b(A_0, this.a, 0));
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x00132710 File Offset: 0x00131710
		internal FormattedTextArea(ceTe.DynamicPDF.LayoutEngine.LayoutElements.FormattedRecordArea A_0, char[] A_1) : base(A_0.X, A_0.Y, A_0.Height, A_0.Angle)
		{
			this.a = A_1;
			this.b = A_0.Width;
			this.c = A_0.InitialStyle;
			this.l = A_0.VAlign;
			this.m = A_0.a();
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x0013283C File Offset: 0x0013183C
		internal FormattedTextArea(amr A_0, float A_1, float A_2, float A_3) : base(A_1, A_2, A_3)
		{
			this.m = A_0.FontFaces;
			this.b = A_0.Width;
			this.f = A_0.d() + A_0.e();
			this.n = A_0.c();
			this.a = A_0.a;
			this.g = this.c().a(this.Height, this.d());
			this.h = this.c().b(this.d());
			this.i = A_0.c().a(this.d()).p() - A_0.c().a(this.d()).i();
			this.j = true;
			this.c = (this.d = A_0.Style);
			this.l = A_0.l;
		}

		// Token: 0x06001E5C RID: 7772 RVA: 0x001329EC File Offset: 0x001319EC
		internal FormattedTextArea(amr A_0) : base(A_0.X, A_0.Y, A_0.Height)
		{
			this.Width = A_0.Width;
			this.Style = A_0.Style;
			this.a(A_0.h());
			this.e = A_0.e;
			this.b(A_0.d());
			this.c(A_0.e());
			this.c(A_0.i());
			this.b(A_0.f());
			this.a(A_0.g());
			this.b(A_0.j());
			this.a(A_0.b());
			this.VAlign = A_0.VAlign;
			this.m = A_0.FontFaces;
			this.a(new FormattedTextArea.b(A_0, this.a, 0));
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06001E5D RID: 7773 RVA: 0x00132B94 File Offset: 0x00131B94
		public FontFamilyList FontFaces
		{
			get
			{
				return this.m;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06001E5E RID: 7774 RVA: 0x00132BAC File Offset: 0x00131BAC
		// (set) Token: 0x06001E5F RID: 7775 RVA: 0x00132BC4 File Offset: 0x00131BC4
		public VAlign VAlign
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06001E60 RID: 7776 RVA: 0x00132BD0 File Offset: 0x00131BD0
		// (set) Token: 0x06001E61 RID: 7777 RVA: 0x00132BE8 File Offset: 0x00131BE8
		public float Width
		{
			get
			{
				return this.b;
			}
			set
			{
				if (this.k)
				{
					throw new Exception("Width can not be changed on an overflow FormattedTextArea.");
				}
				this.j = false;
				this.b = value;
				this.a = this.ad.ToCharArray();
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06001E62 RID: 7778 RVA: 0x00132C30 File Offset: 0x00131C30
		// (set) Token: 0x06001E63 RID: 7779 RVA: 0x00132C48 File Offset: 0x00131C48
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				if (this.j)
				{
					this.g = this.n.a(this.Height, this.f);
				}
			}
		}

		// Token: 0x06001E64 RID: 7780 RVA: 0x00132C8C File Offset: 0x00131C8C
		internal string b()
		{
			if (this.k)
			{
				throw new Exception("Text can not be read on an overflow FormattedTextArea.");
			}
			return new string(this.a);
		}

		// Token: 0x06001E65 RID: 7781 RVA: 0x00132CC4 File Offset: 0x00131CC4
		internal void a(string A_0)
		{
			if (this.k)
			{
				throw new Exception("Text can not be changed on an overflow FormattedTextArea.");
			}
			this.j = false;
			this.a = A_0.ToCharArray();
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06001E66 RID: 7782 RVA: 0x00132D00 File Offset: 0x00131D00
		// (set) Token: 0x06001E67 RID: 7783 RVA: 0x00132D32 File Offset: 0x00131D32
		public string Text
		{
			get
			{
				if (this.k)
				{
					throw new Exception("Text can not be read on an overflow FormattedTextArea.");
				}
				return this.ad;
			}
			set
			{
				this.ad = value;
				this.a = value.ToCharArray();
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06001E68 RID: 7784 RVA: 0x00132D48 File Offset: 0x00131D48
		// (set) Token: 0x06001E69 RID: 7785 RVA: 0x00132D60 File Offset: 0x00131D60
		public FormattedTextAreaStyle Style
		{
			get
			{
				return this.c;
			}
			set
			{
				if (this.k)
				{
					throw new Exception("Style can not be changed on an overflow FormattedTextArea.");
				}
				this.j = false;
				this.c = value;
			}
		}

		// Token: 0x06001E6A RID: 7786 RVA: 0x00132D98 File Offset: 0x00131D98
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				this.a(writer);
			}
			else
			{
				this.a();
				writer.SetTextMode();
				int num = 0;
				int num2 = 0;
				FormattedTextAreaStyle a_ = this.c;
				bool flag = false;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = this.n.a(this.l, base.Height, this.f, this.g);
				FormattedTextArea.a a = new FormattedTextArea.a(0f, 0f, 0f, Grayscale.Black, null, 0f);
				for (int i = this.f; i < this.g + this.f; i++)
				{
					FormattedTextArea.c c = this.n.a(i);
					num4 = c.p() - this.i + num5;
					if (i != this.f && num4 > this.Height)
					{
						break;
					}
					if (c.q().b() > 0)
					{
						c.b();
						num = 0;
						num2 = 0;
						num3 = 0f;
						Queue queue = null;
						this.a(writer, c, num4 + this.Y, ref num3);
						foreach (object obj in c.q())
						{
							FormattedTextArea.e e = (FormattedTextArea.e)obj;
							FormattedTextArea.g g = null;
							foreach (object obj2 in e.a())
							{
								FormattedTextArea.g g2 = (FormattedTextArea.g)obj2;
								if (flag != g2.h().Underline)
								{
									if (g2.h().Underline)
									{
										if (queue == null)
										{
											queue = new Queue();
										}
										a = new FormattedTextArea.a(num3, g2.h().Font.Size * 0.1f, g2.h().Font.Size * 0.05f, g2.h().Font.Color, g2.h().GetFont(), g2.h().Font.Size);
									}
									else
									{
										if (g == null)
										{
											a.c = num3;
										}
										else
										{
											a.c = num3 - g.g();
										}
										queue.Enqueue(a);
									}
									flag = g2.h().Underline;
								}
								if (num + num2 == g2.d())
								{
									num2 += g2.a();
								}
								else
								{
									this.a(writer, a_, num, num2, c.o());
									num = g2.d();
									num2 = g2.a();
									a_ = g2.h();
								}
								num3 += g2.b();
								if (c.c().Paragraph.Align == TextAlign.Justify)
								{
									num3 += (float)g2.a() * c.n() + (float)g2.c() * c.o();
								}
								g = g2;
							}
						}
						if (flag)
						{
							a.c = num3;
							queue.Enqueue(a);
							flag = false;
						}
						this.a(writer, a_, num, num2, c.o());
						if (queue != null)
						{
							this.a(writer, queue, num4);
						}
					}
				}
				writer.SetCharacterSpacing(0f);
				writer.SetTextRise(0f);
			}
		}

		// Token: 0x06001E6B RID: 7787 RVA: 0x001331D0 File Offset: 0x001321D0
		private void a(PageWriter A_0)
		{
			this.a();
			A_0.SetTextMode();
			float num = 0f;
			StructureElement structureElement = null;
			AttributeTypeList attributeTypeList = null;
			AttributeClassList attributeClassList = null;
			StructureElement structureElement2 = null;
			for (int i = 0; i < this.n.af(); i++)
			{
				FormattedTextArea.c c = this.n.a(i);
				if (i < this.n.af() - 1)
				{
					if (c.k() || c.m())
					{
						this.x = true;
					}
				}
				if (!this.y)
				{
					foreach (object obj in c.q())
					{
						FormattedTextArea.e e = (FormattedTextArea.e)obj;
						foreach (object obj2 in e.a())
						{
							FormattedTextArea.g g = (FormattedTextArea.g)obj2;
							if (num != g.h().TextRise || g.h().Underline)
							{
								this.y = true;
								break;
							}
						}
					}
				}
			}
			if (this.n.af() == 1)
			{
				this.x = false;
			}
			if (this.Tag == null)
			{
				structureElement2 = new StructureElement(TagType.Paragraph, true);
			}
			else if (this.Tag.g())
			{
				structureElement2 = (StructureElement)this.Tag;
				structureElement2.Order = this.TagOrder;
				if (this.x || this.y)
				{
					structureElement2.a(A_0, this, A_0.Document.j());
					attributeTypeList = structureElement2.s();
					attributeClassList = structureElement2.t();
				}
			}
			else
			{
				this.Tag.e(A_0, this);
				this.ac = true;
			}
			if (!this.ac)
			{
				if (this.x || this.y)
				{
					if (A_0.k() != null)
					{
						structureElement2.Parent = A_0.k();
					}
					if (this.x)
					{
						structureElement = new StructureElement((StandardTagType)structureElement2.TagType, true);
						structureElement.Parent = structureElement2;
					}
					if (!this.y)
					{
						this.aa = false;
					}
				}
				else
				{
					structureElement2.e(A_0, this);
					this.ab = true;
					this.aa = false;
				}
			}
			this.y = false;
			int num2 = 0;
			int num3 = 0;
			FormattedTextAreaStyle formattedTextAreaStyle = this.c;
			bool flag = false;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = this.n.a(this.l, base.Height, this.f, this.g);
			Queue queue = null;
			Queue queue2 = null;
			FormattedTextArea.a a = new FormattedTextArea.a(0f, 0f, 0f, Grayscale.Black, null, 0f);
			float num7 = 0f;
			float num8 = 0f;
			if (!this.ac)
			{
				for (int j = this.f; j < this.g + this.f; j++)
				{
					FormattedTextArea.c c2 = this.n.a(j);
					foreach (object obj3 in c2.q())
					{
						FormattedTextArea.e e = (FormattedTextArea.e)obj3;
						foreach (object obj4 in e.a())
						{
							FormattedTextArea.g g = (FormattedTextArea.g)obj4;
							if (num != g.h().TextRise || g.h().Underline)
							{
								this.y = true;
								break;
							}
						}
					}
					if (c2.k() || c2.m())
					{
						break;
					}
				}
			}
			for (int k = this.f; k < this.g + this.f; k++)
			{
				FormattedTextArea.c c3 = this.n.a(k);
				num5 = c3.p() - this.i + num6;
				if (k != this.f && num5 > this.Height)
				{
					break;
				}
				if (c3.q().b() > 0)
				{
					c3.b();
					num2 = 0;
					num3 = 0;
					num4 = 0f;
					queue = null;
					this.a(A_0, c3, num5 + this.Y, ref num4);
					if (!this.y && structureElement != null && !this.ac)
					{
						DocumentWriter documentWriter = A_0.DocumentWriter;
						documentWriter.i(documentWriter.ae() + 1);
						structureElement.e(A_0, null);
						this.a(structureElement, attributeTypeList, attributeClassList, A_0.DocumentWriter.ae());
						int num9 = this.a(k);
						if (num9 < 1)
						{
							num9 = 1;
						}
						this.u = num9;
						float a_;
						if (k == 0)
						{
							a_ = this.Y;
						}
						else
						{
							a_ = num5;
						}
						structureElement.a(formattedTextAreaStyle, this, A_0, this.c().b(k, num9), num4, a_, this.Width);
						this.ab = true;
						this.y = true;
						this.aa = false;
					}
					foreach (object obj5 in c3.q())
					{
						FormattedTextArea.e e2 = (FormattedTextArea.e)obj5;
						FormattedTextArea.g g2 = null;
						foreach (object obj6 in e2.a())
						{
							FormattedTextArea.g g3 = (FormattedTextArea.g)obj6;
							if (flag != g3.h().Underline)
							{
								if (g3.h().Underline)
								{
									if (queue == null)
									{
										queue = new Queue();
									}
									a = new FormattedTextArea.a(num4, g3.h().Font.Size * 0.1f, g3.h().Font.Size * 0.05f, g3.h().Font.Color, g3.h().GetFont(), g3.h().Font.Size);
									a.h = num5;
									num7 = num4;
								}
								else
								{
									if (g2 == null)
									{
										a.c = num4;
									}
									else
									{
										a.c = num4 - g2.g();
									}
									queue.Enqueue(a);
								}
								flag = g3.h().Underline;
							}
							if (num2 + num3 == g3.d())
							{
								num3 += g3.a();
							}
							else
							{
								if (num3 > 0 && (formattedTextAreaStyle.Underline || formattedTextAreaStyle.TextRise != 0f))
								{
									if (formattedTextAreaStyle.Underline && formattedTextAreaStyle.TextRise != 0f)
									{
										A_0.Write_Tm(num8, num5 + this.Y);
									}
									else if (formattedTextAreaStyle.Underline && num7 != this.r)
									{
										A_0.Write_Tm(num7, num5 + this.Y);
										this.r = num7;
									}
									else if (formattedTextAreaStyle.TextRise != 0f && num8 != this.r)
									{
										A_0.Write_Tm(num8, num5 + this.Y);
										this.r = num8;
									}
								}
								this.a(A_0, formattedTextAreaStyle, num2, num3, c3.o(), structureElement, attributeClassList, attributeTypeList, structureElement2, k, num5 + this.Y);
								if (formattedTextAreaStyle.Underline)
								{
									if (queue != null && queue.Count > 0)
									{
										this.a(A_0, queue, queue2);
										if (this.r != num4)
										{
											A_0.Write_Tm(num4, num5 + this.Y);
											this.r = num4;
										}
										queue.Clear();
									}
								}
								if (num3 > 0)
								{
									if (this.o != formattedTextAreaStyle.Underline)
									{
										this.o = formattedTextAreaStyle.Underline;
									}
									if (formattedTextAreaStyle.Underline)
									{
										num7 = num4;
									}
								}
								if (this.q != formattedTextAreaStyle.TextRise && num3 > 0)
								{
									this.q = formattedTextAreaStyle.TextRise;
									if (this.r != num4)
									{
										A_0.Write_Tm(num4, num5 + this.Y);
										this.r = num4;
									}
								}
								num2 = g3.d();
								num3 = g3.a();
								formattedTextAreaStyle = g3.h();
								num8 = num4;
								if (formattedTextAreaStyle.Underline && formattedTextAreaStyle.TextRise != 0f)
								{
									num7 = num4;
								}
							}
							num4 += g3.b();
							if (c3.c().Paragraph.Align == TextAlign.Justify)
							{
								num4 += (float)g3.a() * c3.n() + (float)g3.c() * c3.o();
							}
							g2 = g3;
						}
					}
					if (flag)
					{
						a.c = num4;
						queue.Enqueue(a);
						flag = false;
					}
					if (formattedTextAreaStyle.Underline && num3 > 0 && this.r != num7)
					{
						A_0.Write_Tm(num7, num5 + this.Y);
						this.r = num7;
					}
					this.a(A_0, formattedTextAreaStyle, num2, num3, c3.o(), structureElement, attributeClassList, attributeTypeList, structureElement2, k, num5 + this.Y);
					if (num3 > 0)
					{
						if (this.o != formattedTextAreaStyle.Underline)
						{
							this.o = formattedTextAreaStyle.Underline;
						}
						if (this.q != formattedTextAreaStyle.TextRise)
						{
							this.q = formattedTextAreaStyle.TextRise;
						}
					}
					if (k + 1 < this.n.af() && queue != null)
					{
						if (this.a(this.n.a(k + 1)))
						{
							if (queue2 == null)
							{
								queue2 = new Queue();
							}
							foreach (object obj7 in queue)
							{
								FormattedTextArea.a a2 = (FormattedTextArea.a)obj7;
								queue2.Enqueue(a2);
							}
						}
					}
					else if (queue != null && queue.Count > 0)
					{
						this.a(A_0, queue, queue2);
					}
				}
				if ((c3.m() || c3.k()) && !this.ac)
				{
					if (this.ab)
					{
						this.a(k, formattedTextAreaStyle, A_0, num5 + this.Y, this.v, this.w);
						Tag.a(A_0);
						this.ab = false;
					}
					if (k + 1 < this.g + this.f)
					{
						if (this.p)
						{
							this.a(k, formattedTextAreaStyle, A_0, num5 + this.Y, this.v, this.w);
							Tag.a(A_0);
							this.p = false;
						}
						structureElement = new StructureElement((StandardTagType)structureElement2.TagType, true);
						this.s = this.r;
						structureElement.Parent = structureElement2;
						this.aa = true;
						this.y = false;
						for (int j = k + 1; j < this.g + this.f; j++)
						{
							FormattedTextArea.c c2 = this.n.a(j);
							foreach (object obj8 in c2.q())
							{
								FormattedTextArea.e e = (FormattedTextArea.e)obj8;
								foreach (object obj9 in e.a())
								{
									FormattedTextArea.g g = (FormattedTextArea.g)obj9;
									if (num != g.h().TextRise || g.h().Underline)
									{
										this.y = true;
										break;
									}
								}
							}
							if (c2.k() || c2.m())
							{
								break;
							}
						}
						if (!this.y)
						{
							if (formattedTextAreaStyle.Underline || formattedTextAreaStyle.TextRise > 0f)
							{
								this.o = false;
								this.q = 0f;
							}
							this.aa = false;
						}
					}
				}
			}
			A_0.SetCharacterSpacing(0f);
			if ((this.p || this.ab) && !this.ac)
			{
				if (this.z != null)
				{
					this.a(this.g + this.f, formattedTextAreaStyle, A_0, num5 + this.Y, this.v, this.w);
				}
				Tag.a(A_0);
			}
			if (this.ac)
			{
				Tag.a(A_0);
			}
			A_0.SetTextRise(0f);
		}

		// Token: 0x06001E6C RID: 7788 RVA: 0x00134268 File Offset: 0x00133268
		private bool a(FormattedTextArea.c A_0)
		{
			foreach (object obj in A_0.q())
			{
				FormattedTextArea.e e = (FormattedTextArea.e)obj;
				using (IEnumerator enumerator2 = e.a().GetEnumerator())
				{
					if (enumerator2.MoveNext())
					{
						FormattedTextArea.g g = (FormattedTextArea.g)enumerator2.Current;
						if (g.h().Underline)
						{
							return true;
						}
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x06001E6D RID: 7789 RVA: 0x0013434C File Offset: 0x0013334C
		private int a(int A_0)
		{
			for (int i = A_0; i < this.g + this.f; i++)
			{
				FormattedTextArea.c c = this.n.a(i);
				if (c.k() || c.m())
				{
					return i - A_0 + 1;
				}
			}
			return this.g + this.f - A_0 + 1;
		}

		// Token: 0x06001E6E RID: 7790 RVA: 0x001343BC File Offset: 0x001333BC
		private void a(int A_0, FormattedTextAreaStyle A_1, PageWriter A_2, float A_3, int A_4, int A_5)
		{
			if (this.z != null)
			{
				bool flag = false;
				A_0++;
				float a_;
				if (A_0 == 0 || A_0 - this.u == 0)
				{
					A_0++;
					flag = true;
					a_ = this.s;
				}
				else
				{
					a_ = this.X;
				}
				float num = A_3;
				Font font = A_1.GetFont();
				float num2 = font.GetDefaultLeading(A_1.Font.Size);
				if (this.t == 0f && this.u == this.d())
				{
					A_3 = this.Y + this.n.a(this.l, base.Height, this.f, this.g);
				}
				else if (this.t == 0f && this.u != 0)
				{
					A_3 -= num2;
				}
				else
				{
					A_3 = this.t - num2;
				}
				if (this.u == 0)
				{
					num2 *= (float)(A_0 - this.u - 1);
				}
				else
				{
					num2 *= (float)(A_0 - this.u);
				}
				char[] array = new char[A_5];
				Array.Copy(this.a, A_4, array, 0, A_5);
				float num3 = font.GetTextWidth(array, A_1.Font.Size);
				if (num3 > this.Width)
				{
					num3 = this.Width;
				}
				this.z.a(A_1, this, A_2, num2, a_, A_3, num3);
				this.t = num;
				if (flag)
				{
					A_0--;
				}
				this.u = A_0;
			}
			this.w = 0;
		}

		// Token: 0x06001E6F RID: 7791 RVA: 0x00134580 File Offset: 0x00133580
		private void a(StructureElement A_0, AttributeTypeList A_1, AttributeClassList A_2, int A_3)
		{
			if (A_1 != null)
			{
				for (int i = 0; i < A_1.Count; i++)
				{
					AttributeObject attributeType = ((AttributeObject)A_1[i]).c();
					A_0.AttributeLists.Add(attributeType);
				}
			}
			if (A_2 != null)
			{
				for (int i = 0; i < A_2.Count; i++)
				{
					AttributeClass attributeClass = A_2[i].a(null);
					AttributeClass attributeClass2 = attributeClass;
					attributeClass2.a(attributeClass2.a() + A_3.ToString());
					A_0.Classes.Add(attributeClass);
				}
			}
		}

		// Token: 0x06001E70 RID: 7792 RVA: 0x00134624 File Offset: 0x00133624
		public FormattedTextArea GetOverflowFormattedTextArea()
		{
			return this.GetOverflowFormattedTextArea(this.X, this.Y, this.Height);
		}

		// Token: 0x06001E71 RID: 7793 RVA: 0x00134650 File Offset: 0x00133650
		public FormattedTextArea GetOverflowFormattedTextArea(float x, float y)
		{
			return this.GetOverflowFormattedTextArea(x, y, this.Height);
		}

		// Token: 0x06001E72 RID: 7794 RVA: 0x00134670 File Offset: 0x00133670
		public FormattedTextArea GetOverflowFormattedTextArea(float x, float y, float height)
		{
			FormattedTextArea result;
			if (this.HasOverflowText())
			{
				result = new FormattedTextArea(this, x, y, height)
				{
					Tag = this.Tag,
					TagOrder = this.TagOrder
				};
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001E73 RID: 7795 RVA: 0x001346BC File Offset: 0x001336BC
		public float GetRequiredHeight()
		{
			this.a();
			return this.h;
		}

		// Token: 0x06001E74 RID: 7796 RVA: 0x001346DC File Offset: 0x001336DC
		public bool HasOverflowText()
		{
			this.a();
			return this.f + this.g < this.n.af();
		}

		// Token: 0x06001E75 RID: 7797 RVA: 0x00134710 File Offset: 0x00133710
		internal FormattedTextArea.b c()
		{
			return this.n;
		}

		// Token: 0x06001E76 RID: 7798 RVA: 0x00134728 File Offset: 0x00133728
		internal void a(FormattedTextArea.b A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x00134734 File Offset: 0x00133734
		internal int d()
		{
			return this.f;
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x0013474C File Offset: 0x0013374C
		internal void b(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x00134758 File Offset: 0x00133758
		internal int e()
		{
			return this.g;
		}

		// Token: 0x06001E7A RID: 7802 RVA: 0x00134770 File Offset: 0x00133770
		internal void c(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x0013477C File Offset: 0x0013377C
		internal float f()
		{
			return this.i;
		}

		// Token: 0x06001E7C RID: 7804 RVA: 0x00134794 File Offset: 0x00133794
		internal void b(float A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06001E7D RID: 7805 RVA: 0x001347A0 File Offset: 0x001337A0
		internal bool g()
		{
			return this.j;
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x001347B8 File Offset: 0x001337B8
		internal void a(bool A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001E7F RID: 7807 RVA: 0x001347C4 File Offset: 0x001337C4
		internal FormattedTextAreaStyle h()
		{
			return this.d;
		}

		// Token: 0x06001E80 RID: 7808 RVA: 0x001347DC File Offset: 0x001337DC
		internal void a(FormattedTextAreaStyle A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001E81 RID: 7809 RVA: 0x001347E8 File Offset: 0x001337E8
		internal override byte cb()
		{
			return 67;
		}

		// Token: 0x06001E82 RID: 7810 RVA: 0x001347FC File Offset: 0x001337FC
		internal float i()
		{
			return this.h;
		}

		// Token: 0x06001E83 RID: 7811 RVA: 0x00134814 File Offset: 0x00133814
		internal void c(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06001E84 RID: 7812 RVA: 0x00134820 File Offset: 0x00133820
		internal bool j()
		{
			return this.k;
		}

		// Token: 0x06001E85 RID: 7813 RVA: 0x00134838 File Offset: 0x00133838
		internal void b(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x00134844 File Offset: 0x00133844
		private void a()
		{
			if (!this.j || !this.d.Equals(this.c))
			{
				this.d = new FormattedTextAreaStyle(this.c);
				this.n = new FormattedTextArea.b(this, this.a, 0);
				this.f = 0;
				this.i = 0f;
				this.g = this.n.a(this.Height, 0);
				this.h = this.n.b(0);
				this.j = true;
			}
		}

		// Token: 0x06001E87 RID: 7815 RVA: 0x001348DC File Offset: 0x001338DC
		private void a(PageWriter A_0, Queue A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetLineCap(LineCap.Butt);
			A_0.SetLineStyle(LineStyle.Solid);
			foreach (object obj in A_1)
			{
				FormattedTextArea.a a = (FormattedTextArea.a)obj;
				A_0.SetStrokeColor(a.e);
				A_0.SetLineWidth(a.f.d(a.g));
				A_0.Write_m_(a.a, this.Y + (A_2 - a.f.GetAscender(a.g)) + a.f.GetBaseLine(a.g, a.f.GetDefaultLeading(a.g)) - a.f.c(a.g));
				A_0.Write_l_(a.c, this.Y + (A_2 - a.f.GetAscender(a.g)) + a.f.GetBaseLine(a.g, a.f.GetDefaultLeading(a.g)) - a.f.c(a.g));
				A_0.Write_S();
			}
			if (A_0.Document.Tag != null)
			{
				this.p = true;
			}
			A_0.SetTextMode();
		}

		// Token: 0x06001E88 RID: 7816 RVA: 0x00134A80 File Offset: 0x00133A80
		private void a(PageWriter A_0, Queue A_1, Queue A_2)
		{
			A_0.z();
			A_0.SetGraphicsMode();
			Artifact.a(A_0);
			A_0.SetLineCap(LineCap.Butt);
			A_0.SetLineStyle(LineStyle.Solid);
			foreach (object obj in A_1)
			{
				FormattedTextArea.a a = (FormattedTextArea.a)obj;
				A_0.SetStrokeColor(a.e);
				A_0.SetLineWidth(a.f.d(a.g));
				A_0.Write_m_(a.a, this.Y + (a.h - a.f.GetAscender(a.g)) + a.f.GetBaseLine(a.g, a.f.GetDefaultLeading(a.g)) - a.f.c(a.g));
				A_0.Write_l_(a.c, this.Y + (a.h - a.f.GetAscender(a.g)) + a.f.GetBaseLine(a.g, a.f.GetDefaultLeading(a.g)) - a.f.c(a.g));
				A_0.Write_S();
			}
			if (A_2 != null)
			{
				foreach (object obj2 in A_2)
				{
					FormattedTextArea.a a = (FormattedTextArea.a)obj2;
					A_0.SetStrokeColor(a.e);
					A_0.SetLineWidth(a.f.d(a.g));
					A_0.Write_m_(a.a, this.Y + (a.h - a.f.GetAscender(a.g)) + a.f.GetBaseLine(a.g, a.f.GetDefaultLeading(a.g)) - a.f.c(a.g));
					A_0.Write_l_(a.c, this.Y + (a.h - a.f.GetAscender(a.g)) + a.f.GetBaseLine(a.g, a.f.GetDefaultLeading(a.g)) - a.f.c(a.g));
					A_0.Write_S();
				}
				A_2 = null;
			}
			A_0.z();
			A_0.SetTextMode();
		}

		// Token: 0x06001E89 RID: 7817 RVA: 0x00134D98 File Offset: 0x00133D98
		private void a(PageWriter A_0, FormattedTextArea.c A_1, float A_2, ref float A_3)
		{
			A_3 = this.X + A_1.c().Paragraph.LeftIndent;
			if (A_1.l())
			{
				A_3 += A_1.c().Paragraph.Indent;
			}
			switch (A_1.c().Paragraph.Align)
			{
			case TextAlign.Center:
				A_3 += (A_1.d() - A_1.e()) / 2f;
				break;
			case TextAlign.Right:
				A_3 += A_1.d() - A_1.e();
				break;
			}
			A_0.SetCharacterSpacing(A_1.n());
			A_0.Write_Tm(A_3, A_2);
			this.r = A_3;
		}

		// Token: 0x06001E8A RID: 7818 RVA: 0x00134E58 File Offset: 0x00133E58
		private void a(PageWriter A_0, FormattedTextAreaStyle A_1, int A_2, int A_3, float A_4)
		{
			if (A_3 > 0)
			{
				this.a(A_0, A_1);
				if (A_4 != 0f)
				{
					A_0.Write_TJ(this.a, A_2, A_3, A_4, false);
				}
				else
				{
					A_0.Write_Tj_(this.a, A_2, A_3, false);
				}
			}
		}

		// Token: 0x06001E8B RID: 7819 RVA: 0x00134EB4 File Offset: 0x00133EB4
		private void a(PageWriter A_0, FormattedTextAreaStyle A_1)
		{
			if (!this.e)
			{
				this.e = true;
			}
			A_0.SetFillColor(A_1.Font.Color);
			A_0.SetFont(A_1.GetFont(), A_1.Font.Size);
			A_0.SetTextRise(A_1.TextRise);
		}

		// Token: 0x06001E8C RID: 7820 RVA: 0x00134F0C File Offset: 0x00133F0C
		private void a(PageWriter A_0, FormattedTextAreaStyle A_1, int A_2, int A_3, float A_4, StructureElement A_5, AttributeClassList A_6, AttributeTypeList A_7, StructureElement A_8, int A_9, float A_10)
		{
			if (A_3 > 0)
			{
				this.a(A_0, A_1, A_5, A_6, A_7, A_8, A_9, A_10, A_2);
				if (A_4 != 0f)
				{
					A_0.a(this.a, A_2, A_3, A_4, false);
				}
				else
				{
					A_0.a(this.a, A_2, A_3, false);
				}
				this.w += A_3;
			}
		}

		// Token: 0x06001E8D RID: 7821 RVA: 0x00134F84 File Offset: 0x00133F84
		private void a(PageWriter A_0, FormattedTextAreaStyle A_1, StructureElement A_2, AttributeClassList A_3, AttributeTypeList A_4, StructureElement A_5, int A_6, float A_7, int A_8)
		{
			if (!this.e)
			{
				this.e = true;
			}
			if ((this.o != A_1.Underline || this.aa || this.q != A_1.TextRise) && !this.ac)
			{
				if (this.p)
				{
					this.a(A_6, new FormattedTextAreaStyle(A_1)
					{
						Underline = this.o,
						TextRise = this.q
					}, A_0, A_7, this.v, this.w);
					Tag.a(A_0);
				}
				this.z = new StructureElement(TagType.Span, true);
				DocumentWriter documentWriter = A_0.DocumentWriter;
				documentWriter.i(documentWriter.ae() + 1);
				this.a(this.z, A_4, A_3, A_0.DocumentWriter.ae());
				this.s = this.r;
				if (A_2 == null)
				{
					this.z.Parent = A_5;
					this.z.IncludeDefaultAttributes = A_5.IncludeDefaultAttributes;
				}
				else
				{
					this.z.Parent = A_2;
					this.z.IncludeDefaultAttributes = A_2.IncludeDefaultAttributes;
				}
				this.z.e(A_0, null);
				this.v = A_8;
				this.p = true;
				this.aa = false;
			}
			A_0.SetFillColor(A_1.Font.Color);
			A_0.SetFont(A_1.GetFont(), A_1.Font.Size);
			A_0.SetTextRise(A_1.TextRise);
		}

		// Token: 0x04000D65 RID: 3429
		private new char[] a;

		// Token: 0x04000D66 RID: 3430
		private float b;

		// Token: 0x04000D67 RID: 3431
		private FormattedTextAreaStyle c;

		// Token: 0x04000D68 RID: 3432
		private new FormattedTextAreaStyle d;

		// Token: 0x04000D69 RID: 3433
		private bool e = false;

		// Token: 0x04000D6A RID: 3434
		private int f = 0;

		// Token: 0x04000D6B RID: 3435
		private int g = 0;

		// Token: 0x04000D6C RID: 3436
		private float h = 0f;

		// Token: 0x04000D6D RID: 3437
		private float i = 0f;

		// Token: 0x04000D6E RID: 3438
		private bool j = false;

		// Token: 0x04000D6F RID: 3439
		private bool k = false;

		// Token: 0x04000D70 RID: 3440
		private VAlign l;

		// Token: 0x04000D71 RID: 3441
		private FontFamilyList m = new FontFamilyList();

		// Token: 0x04000D72 RID: 3442
		private FormattedTextArea.b n = null;

		// Token: 0x04000D73 RID: 3443
		private new bool o = false;

		// Token: 0x04000D74 RID: 3444
		private bool p = false;

		// Token: 0x04000D75 RID: 3445
		private float q = 0f;

		// Token: 0x04000D76 RID: 3446
		private float r = 0f;

		// Token: 0x04000D77 RID: 3447
		private float s = 0f;

		// Token: 0x04000D78 RID: 3448
		private float t = 0f;

		// Token: 0x04000D79 RID: 3449
		private int u = 0;

		// Token: 0x04000D7A RID: 3450
		private int v = 0;

		// Token: 0x04000D7B RID: 3451
		private int w = 0;

		// Token: 0x04000D7C RID: 3452
		private bool x = false;

		// Token: 0x04000D7D RID: 3453
		private bool y = false;

		// Token: 0x04000D7E RID: 3454
		private StructureElement z = null;

		// Token: 0x04000D7F RID: 3455
		private bool aa = true;

		// Token: 0x04000D80 RID: 3456
		private bool ab = false;

		// Token: 0x04000D81 RID: 3457
		private bool ac = false;

		// Token: 0x04000D82 RID: 3458
		private string ad;

		// Token: 0x02000710 RID: 1808
		private new struct a
		{
			// Token: 0x060047B9 RID: 18361 RVA: 0x00251790 File Offset: 0x00250790
			internal a(float A_0, float A_1, float A_2, Color A_3, Font A_4, float A_5)
			{
				this.a = A_0;
				this.b = A_1;
				this.c = 0f;
				this.d = A_2;
				this.e = A_3;
				this.f = A_4;
				this.g = A_5;
				this.h = 0f;
			}

			// Token: 0x04002740 RID: 10048
			public float a;

			// Token: 0x04002741 RID: 10049
			public float b;

			// Token: 0x04002742 RID: 10050
			public float c;

			// Token: 0x04002743 RID: 10051
			public float d;

			// Token: 0x04002744 RID: 10052
			public Color e;

			// Token: 0x04002745 RID: 10053
			public Font f;

			// Token: 0x04002746 RID: 10054
			public float g;

			// Token: 0x04002747 RID: 10055
			public float h;
		}

		// Token: 0x02000711 RID: 1809
		[DefaultMember("Item")]
		internal class b : IEnumerable
		{
			// Token: 0x060047BA RID: 18362 RVA: 0x002517E4 File Offset: 0x002507E4
			public b(FormattedTextArea A_0, char[] A_1, int A_2)
			{
				this.h = A_0;
				this.j = A_1;
				this.g = A_2;
				this.i = new FormattedTextAreaStyle(A_0.Style);
				this.n = new FormattedTextArea.e(this.i);
				this.a(false, true);
				this.x();
			}

			// Token: 0x060047BB RID: 18363 RVA: 0x00251918 File Offset: 0x00250918
			public void a(bool A_0, bool A_1)
			{
				if (this.m != null)
				{
					if (this.m.l() && this.k.Count > 0)
					{
						this.y += this.m.c().Paragraph.SpacingBefore;
					}
					if (A_0)
					{
						this.m.a(true);
						this.m.c(A_1);
						if (A_1)
						{
							this.o = true;
						}
					}
					this.m.a(ref this.y);
					if (A_0 && A_1)
					{
						this.y += this.m.c().Paragraph.SpacingAfter;
					}
				}
				this.m = new FormattedTextArea.c(this.h, this.n.b(), this.o);
				this.k.Add(this.m);
				this.o = false;
			}

			// Token: 0x060047BC RID: 18364 RVA: 0x00251A34 File Offset: 0x00250A34
			public IEnumerator GetEnumerator()
			{
				return this.k.GetEnumerator();
			}

			// Token: 0x060047BD RID: 18365 RVA: 0x00251A54 File Offset: 0x00250A54
			private float w()
			{
				if (this.p)
				{
					this.l = this.i.GetFont();
					this.p = false;
				}
				return (float)this.l.GetGlyphWidth(this.j[this.g]) * this.i.Font.Size / 1000f;
			}

			// Token: 0x060047BE RID: 18366 RVA: 0x00251AC0 File Offset: 0x00250AC0
			public void x()
			{
				while (this.g < this.j.Length)
				{
					this.y();
				}
				this.ad();
				this.ac();
				if (this.m.e() > 0f)
				{
					this.m.a(true);
					this.m.c(true);
					if (this.m.l() && this.k.Count > 0)
					{
						this.y += this.m.c().Paragraph.SpacingBefore;
					}
					this.m.a(ref this.y);
				}
				else if (this.k.Count > 1)
				{
					this.y = this.a(this.k.Count - 2).p() + this.a(this.k.Count - 2).j();
					this.k.RemoveAt(this.k.Count - 1);
				}
			}

			// Token: 0x060047BF RID: 18367 RVA: 0x00251BF8 File Offset: 0x00250BF8
			public void y()
			{
				if (this.j[this.g] > ' ')
				{
					this.z();
				}
				else
				{
					this.ab();
				}
			}

			// Token: 0x060047C0 RID: 18368 RVA: 0x00251C34 File Offset: 0x00250C34
			public void z()
			{
				this.r = this.g;
				while (this.g < this.j.Length && this.j[this.g] > ' ')
				{
					if (this.j[this.g] == '&' && this.g + 1 < this.j.Length && this.j[this.g + 1] > ' ' && this.j[this.g + 1] != '&' && this.j[this.g + 1] != '<')
					{
						this.aa();
						if (this.g >= this.j.Length || this.j[this.g] <= ' ')
						{
							break;
						}
					}
					if (this.j[this.g] == '<' && this.g + 1 < this.j.Length && (this.j[this.g + 1] == '/' || (this.j[this.g + 1] > ' ' && this.j[this.g + 1] != '>' && this.j[this.g + 1] != '<')))
					{
						this.ae();
						break;
					}
					float num = this.w();
					if (this.g < this.j.Length && this.a(this.j[this.g]))
					{
						if (num + this.t + this.n.c() > this.m.d() - this.m.e())
						{
							this.ad();
							this.ac();
							this.r = this.g;
						}
					}
					if (this.s > 0 && num + this.t + this.n.c() > this.m.d())
					{
						this.ad();
						this.ac();
						this.a(false, false);
						this.r = this.g;
					}
					if (this.j[this.g] == '-')
					{
						if (this.g + 1 < this.j.Length && this.j[this.g + 1] != '-')
						{
							this.s++;
							this.g++;
							this.t += num;
							this.ad();
							this.ac();
							this.r = this.g;
							break;
						}
					}
					this.t += num;
					this.s++;
					this.g++;
				}
			}

			// Token: 0x060047C1 RID: 18369 RVA: 0x00251F48 File Offset: 0x00250F48
			private bool a(char A_0)
			{
				return A_0 >= '⺀' && (A_0 <= '힯' || (A_0 >= '豈' && A_0 <= '﫿'));
			}

			// Token: 0x060047C2 RID: 18370 RVA: 0x00251FA4 File Offset: 0x00250FA4
			public void aa()
			{
				this.g++;
				this.ad();
				bool flag = true;
				int num = this.g;
				int num2 = 0;
				if (this.g < this.j.Length)
				{
					while (this.j[this.g] != ';' && num2 < 6)
					{
						this.g++;
						num2++;
						if (this.g >= this.j.Length)
						{
							return;
						}
					}
				}
				if (this.j[num] == '#')
				{
					int i = num + 1;
					int num3 = i + num2 - 1;
					int num4 = 0;
					while (i < num3)
					{
						if (this.j[i] >= '0' && this.j[i] <= '9')
						{
							num4 = num4 * 10 + (int)this.j[i] - 48;
						}
						i++;
					}
					if (num4 >= 32)
					{
						this.j[this.g] = (char)num4;
					}
				}
				else
				{
					int num5 = this.a(num, num2);
					if (num5 <= 25774)
					{
						if (num5 <= 653)
						{
							if (num5 == 244)
							{
								this.j[this.g] = '>';
								goto IL_375;
							}
							if (num5 == 404)
							{
								this.j[this.g] = '<';
								goto IL_375;
							}
							if (num5 == 653)
							{
								this.j[this.g] = '™';
								goto IL_375;
							}
						}
						else if (num5 <= 4263)
						{
							if (num5 == 1456)
							{
								this.j[this.g] = '&';
								goto IL_375;
							}
							if (num5 == 4263)
							{
								this.j[this.g] = '°';
								goto IL_375;
							}
						}
						else
						{
							if (num5 == 18599)
							{
								this.j[this.g] = '®';
								goto IL_375;
							}
							if (num5 == 25774)
							{
								this.j[this.g] = '¥';
								goto IL_375;
							}
						}
					}
					else if (num5 <= 185935)
					{
						if (num5 <= 103892)
						{
							if (num5 == 49651)
							{
								this.j[this.g] = '\'';
								goto IL_375;
							}
							if (num5 == 103892)
							{
								this.j[this.g] = '¢';
								goto IL_375;
							}
						}
						else
						{
							if (num5 == 114201)
							{
								this.j[this.g] = '©';
								goto IL_375;
							}
							if (num5 == 185935)
							{
								this.j[this.g] = '€';
								goto IL_375;
							}
						}
					}
					else if (num5 <= 579060)
					{
						if (num5 == 461424)
						{
							this.j[this.g] = '\u00a0';
							this.q = true;
							goto IL_375;
						}
						if (num5 == 579060)
						{
							this.j[this.g] = '"';
							goto IL_375;
						}
					}
					else
					{
						if (num5 == 17290692)
						{
							this.j[this.g] = '£';
							goto IL_375;
						}
						if (num5 == 21562501)
						{
							this.j[this.g] = '™';
							goto IL_375;
						}
					}
					flag = false;
					IL_375:;
				}
				if (flag)
				{
					this.r = this.g;
					this.t += this.w();
					this.s++;
					this.g++;
					if (this.g + 1 < this.j.Length && this.j[this.g] == '&' && this.j[this.g + 1] > ' ' && this.j[this.g + 1] != '&' && this.j[this.g + 1] != '<')
					{
						this.aa();
					}
				}
				else
				{
					this.g -= num2 + 1;
					this.r = this.g;
					this.t += this.w();
					this.s++;
					this.g++;
				}
			}

			// Token: 0x060047C3 RID: 18371 RVA: 0x00252430 File Offset: 0x00251430
			public void ab()
			{
				if (!this.i.Paragraph.PreserveWhiteSpace)
				{
					this.j[this.g] = ' ';
					this.w++;
					this.x += this.w();
					this.g++;
					while (this.g < this.j.Length && this.j[this.g] < '!')
					{
						this.g++;
					}
				}
				else
				{
					bool flag = false;
					while (this.g < this.j.Length && this.j[this.g] < '!')
					{
						char c = this.j[this.g];
						if (c != '\n')
						{
							if (c != '\r')
							{
								this.w++;
								this.x += this.w();
								flag = false;
							}
							else
							{
								this.j(true);
								flag = true;
							}
						}
						else if (!flag)
						{
							this.j(true);
							flag = false;
						}
						else
						{
							this.r++;
						}
						this.g++;
					}
				}
				this.ad();
				this.ac();
			}

			// Token: 0x060047C4 RID: 18372 RVA: 0x00252593 File Offset: 0x00251593
			private void j(bool A_0)
			{
				this.ad();
				this.ac();
				this.a(true, A_0);
				this.r = this.g + 1;
			}

			// Token: 0x060047C5 RID: 18373 RVA: 0x002525BC File Offset: 0x002515BC
			public void ac()
			{
				if (this.u != 0)
				{
					if ((!this.a || this.n.d() > 1) && this.n.c() > this.m.d() - this.m.e())
					{
						this.a(false, false);
					}
					this.m.a(this.n);
					this.n = new FormattedTextArea.e(this.i);
					this.v = 0f;
					this.u = 0;
					this.a = false;
					this.q = false;
				}
			}

			// Token: 0x060047C6 RID: 18374 RVA: 0x00252670 File Offset: 0x00251670
			public void ad()
			{
				if (this.s != 0 || this.w != 0)
				{
					if (this.s > 0 || this.u > 0 || this.m.g() > 0 || this.q || this.i.Paragraph.PreserveWhiteSpace)
					{
						this.n.a(new FormattedTextArea.g(this.i, this.r, this.s, this.t, this.w, this.x));
						this.v += this.t + this.x;
						this.u += this.s + this.w;
					}
					this.t = 0f;
					this.s = 0;
					this.x = 0f;
					this.w = 0;
				}
			}

			// Token: 0x060047C7 RID: 18375 RVA: 0x00252774 File Offset: 0x00251774
			public void ae()
			{
				this.g++;
				this.ad();
				if ((this.g < this.j.Length && this.j[this.g] != '<') || this.j[this.g] != '>')
				{
					if (this.j[this.g] == '/')
					{
						this.g++;
						this.i(true);
					}
					else
					{
						this.i(false);
					}
					while (this.g < this.j.Length && this.j[this.g] != '>')
					{
						this.g++;
					}
					this.g++;
				}
				if (this.g + 1 < this.j.Length && this.j[this.g] == '<' && (this.j[this.g + 1] == '/' || (this.j[this.g + 1] > ' ' && this.j[this.g + 1] != '>' && this.j[this.g + 1] != '<')))
				{
					this.ae();
				}
				this.r = this.g;
			}

			// Token: 0x060047C8 RID: 18376 RVA: 0x002528F0 File Offset: 0x002518F0
			private void i(bool A_0)
			{
				if (this.g + 1 < this.j.Length)
				{
					int num = this.r();
					int num2 = num;
					if (num2 <= 82)
					{
						if (num2 <= 9)
						{
							if (num2 == 2)
							{
								goto IL_C1;
							}
							if (num2 != 9)
							{
								return;
							}
						}
						else
						{
							if (num2 == 16)
							{
								this.h(A_0);
								return;
							}
							if (num2 == 21)
							{
								this.c(!A_0);
								return;
							}
							if (num2 != 82)
							{
								return;
							}
							if (!A_0)
							{
								if (this.m.q().b() == 0 && this.u == 0)
								{
									this.m.b(false);
								}
								this.j(false);
								this.z = this.m;
							}
							return;
						}
					}
					else if (num2 <= 20144)
					{
						if (num2 != 173)
						{
							if (num2 == 20130)
							{
								this.a(A_0);
								return;
							}
							if (num2 != 20144)
							{
								return;
							}
							this.b(A_0);
							return;
						}
					}
					else
					{
						if (num2 == 212436)
						{
							this.g(A_0);
							return;
						}
						if (num2 == 402885)
						{
							this.f(A_0);
							return;
						}
						if (num2 != 659111367)
						{
							return;
						}
						goto IL_C1;
					}
					this.d(!A_0);
					return;
					IL_C1:
					this.e(!A_0);
				}
			}

			// Token: 0x060047C9 RID: 18377 RVA: 0x00252A70 File Offset: 0x00251A70
			private bool v()
			{
				int num = this.g;
				while (num < this.j.Length && this.j[num] != '>')
				{
					num++;
				}
				num++;
				while (num < this.j.Length && this.j[num] <= ' ')
				{
					if (this.j[num++] == '\n')
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060047CA RID: 18378 RVA: 0x00252AF8 File Offset: 0x00251AF8
			private void h(bool A_0)
			{
				if (A_0)
				{
					this.i = new FormattedTextAreaStyle(this.i);
					if (this.c.Count > 1)
					{
						this.c.Pop();
					}
					if (this.c.Count > 0)
					{
						this.i.Paragraph = (FormattedTextAreaStyle.ParagraphStyle)this.c.Peek();
					}
					this.ac();
					if (!this.i.Paragraph.PreserveWhiteSpace || (this.i.Paragraph.PreserveWhiteSpace && !this.v()))
					{
						this.n.a(this.i);
						this.j(true);
					}
				}
				else
				{
					bool flag = false;
					if (this.z == this.m)
					{
						if (this.k.Count > 1 && ((FormattedTextArea.c)this.k[this.k.Count - 2]).q().b() == 0 && this.m.q().b() == 0 && this.u == 0)
						{
							this.m.b(true);
							flag = false;
						}
						else if (this.k.Count > 1 && ((FormattedTextArea.c)this.k[this.k.Count - 2]).q().b() > 0 && this.m.q().b() == 0 && this.u == 0)
						{
							((FormattedTextArea.c)this.k[this.k.Count - 2]).c(true);
							this.y += ((FormattedTextArea.c)this.k[this.k.Count - 2]).c().Paragraph.SpacingAfter;
							this.m.b(true);
							flag = false;
						}
						else if (this.k.Count > 1 && ((FormattedTextArea.c)this.k[this.k.Count - 2]).q().b() == 0 && (this.m.q().b() > 0 || this.u > 0))
						{
							this.m.b(true);
							flag = true;
						}
						else
						{
							flag = true;
						}
					}
					if (this.c.Count == 0)
					{
						this.c.Push(this.i.Paragraph);
					}
					this.i = new FormattedTextAreaStyle(this.i);
					while (!this.t())
					{
						int num = this.s();
						if (num <= 407979258)
						{
							if (num <= 104950243)
							{
								if (num != 1451246)
								{
									if (num != 104950243)
									{
										goto IL_3A6;
									}
									this.k();
								}
								else
								{
									this.j();
								}
							}
							else if (num != 316806612)
							{
								if (num != 407979258)
								{
									goto IL_3A6;
								}
								this.n();
							}
							else
							{
								this.o();
							}
						}
						else if (num <= 667321232)
						{
							if (num != 611432285)
							{
								if (num != 667321232)
								{
									goto IL_3A6;
								}
								this.l();
							}
							else
							{
								this.m();
							}
						}
						else if (num != 689167772)
						{
							if (num != 690099417)
							{
								goto IL_3A6;
							}
							this.q();
						}
						else
						{
							this.p();
						}
						continue;
						IL_3A6:
						this.u();
					}
					if (this.j[this.g - 1] != '/')
					{
						this.c.Push(this.i.Paragraph);
						if (this.m.q().b() < 1 && this.s == 0)
						{
							if (this.u <= 0)
							{
								this.m.a(this.i, this.af() == 1);
							}
						}
						if ((this.u > 0 || this.m.q().b() > 0 || flag) && (!this.i.Paragraph.PreserveWhiteSpace || (this.i.Paragraph.PreserveWhiteSpace && !this.v())))
						{
							if (this.u == 0 && this.m.q().b() > 0)
							{
								this.n.a(this.i);
							}
							this.j(true);
						}
					}
					else
					{
						this.i.Paragraph = (FormattedTextAreaStyle.ParagraphStyle)this.c.Peek();
						if (!this.i.Paragraph.PreserveWhiteSpace || (this.i.Paragraph.PreserveWhiteSpace && !this.v()))
						{
							this.j(true);
						}
					}
				}
			}

			// Token: 0x060047CB RID: 18379 RVA: 0x0025304C File Offset: 0x0025204C
			private void u()
			{
				if (this.g + 2 < this.j.Length && this.j[this.g] == '=')
				{
					this.g++;
					bool flag = false;
					bool flag2 = false;
					if (this.j[this.g] == '"')
					{
						flag2 = true;
						this.g++;
					}
					else if (this.j[this.g] == '\'')
					{
						flag = true;
						this.g++;
					}
					if (flag2)
					{
						while (this.g < this.j.Length && this.j[this.g] != '"')
						{
							this.g++;
						}
					}
					else if (flag)
					{
						while (this.g < this.j.Length && this.j[this.g] != '\'')
						{
							this.g++;
						}
					}
					else
					{
						while (this.g < this.j.Length && this.j[this.g] != ' ' && this.j[this.g] != '/' && this.j[this.g] != '>')
						{
							this.g++;
						}
					}
				}
			}

			// Token: 0x060047CC RID: 18380 RVA: 0x002531F0 File Offset: 0x002521F0
			private void g(bool A_0)
			{
				if (A_0)
				{
					this.i = new FormattedTextAreaStyle(this.i);
					if (this.b.Count > 1)
					{
						this.b.Pop();
					}
					if (this.b.Count > 0)
					{
						this.i.Font = (FormattedTextAreaStyle.FontStyle)this.b.Peek();
						this.p = true;
					}
				}
				else
				{
					if (this.b.Count == 0)
					{
						this.b.Push(this.i.Font);
					}
					this.i = new FormattedTextAreaStyle(this.i);
					while (!this.t())
					{
						int num = this.s();
						if (num <= 632645)
						{
							if (num != 197733)
							{
								if (num != 632645)
								{
									goto IL_11C;
								}
								this.g();
							}
							else
							{
								this.e();
							}
						}
						else if (num != 3650034)
						{
							if (num != 552902102)
							{
								goto IL_11C;
							}
							this.f();
						}
						else
						{
							this.d();
						}
						continue;
						IL_11C:
						this.u();
					}
					if (this.j[this.g - 1] != '/')
					{
						this.b.Push(this.i.Font);
					}
					else
					{
						this.i.Font = (FormattedTextAreaStyle.FontStyle)this.b.Peek();
					}
				}
			}

			// Token: 0x060047CD RID: 18381 RVA: 0x00253388 File Offset: 0x00252388
			private void f(bool A_0)
			{
				if (A_0)
				{
					this.i = new FormattedTextAreaStyle(this.i);
					if (this.d.Count > 1)
					{
						this.d.Pop();
					}
					if (this.d.Count > 0)
					{
						this.i.Line = (FormattedTextAreaStyle.LineStyle)this.d.Peek();
					}
				}
				else
				{
					if (this.d.Count == 0)
					{
						this.d.Push(this.i.Line);
					}
					this.i = new FormattedTextAreaStyle(this.i);
					while (!this.t())
					{
						int num = this.s();
						if (num != 405468971)
						{
							if (num != 407933225)
							{
								this.u();
							}
							else
							{
								this.i();
							}
						}
						else
						{
							this.h();
						}
					}
					if (this.j[this.g - 1] != '/')
					{
						this.d.Push(this.i.Line);
						if (this.m.q().b() < 1 && this.s == 0)
						{
							this.m.a(this.i, this.af() == 1);
						}
					}
					else
					{
						this.i.Line = (FormattedTextAreaStyle.LineStyle)this.d.Peek();
					}
				}
			}

			// Token: 0x060047CE RID: 18382 RVA: 0x00253530 File Offset: 0x00252530
			private bool t()
			{
				while (this.g < this.j.Length && (this.j[this.g] < '!' || this.j[this.g] == '/' || this.j[this.g] == '\'' || this.j[this.g] == '"'))
				{
					this.g++;
				}
				return this.g >= this.j.Length || this.j[this.g] == '>';
			}

			// Token: 0x060047CF RID: 18383 RVA: 0x002535EC File Offset: 0x002525EC
			private int s()
			{
				int num = 0;
				while (this.g < this.j.Length && this.j[this.g] < '!')
				{
					this.g++;
				}
				int a_ = this.g;
				while (this.g < this.j.Length && this.j[this.g] > ' ' && this.j[this.g] != '=')
				{
					this.g++;
					num++;
				}
				return this.a(a_, num);
			}

			// Token: 0x060047D0 RID: 18384 RVA: 0x002536A0 File Offset: 0x002526A0
			private int r()
			{
				int a_ = this.g;
				int num = 0;
				while (this.g < this.j.Length && this.j[this.g] > ' ' && this.j[this.g] != '/' && this.j[this.g] != '>')
				{
					this.g++;
					num++;
				}
				return this.a(a_, num);
			}

			// Token: 0x060047D1 RID: 18385 RVA: 0x00253728 File Offset: 0x00252728
			private int a(int A_0, int A_1)
			{
				int num = 0;
				int num2 = 0;
				int i;
				for (i = 0; i < A_1; i++)
				{
					num2 <<= 5;
					num2 |= (int)(this.j[A_0 + i] % ' ');
					if (i % 6 == 5)
					{
						num ^= num2;
						num2 = 0;
					}
				}
				if (i % 6 != 0)
				{
					num ^= num2;
				}
				return num;
			}

			// Token: 0x060047D2 RID: 18386 RVA: 0x00253790 File Offset: 0x00252790
			private void q()
			{
				this.i.Paragraph.SpacingBefore = this.c();
			}

			// Token: 0x060047D3 RID: 18387 RVA: 0x002537A9 File Offset: 0x002527A9
			private void p()
			{
				this.i.Paragraph.SpacingAfter = this.c();
			}

			// Token: 0x060047D4 RID: 18388 RVA: 0x002537C2 File Offset: 0x002527C2
			private void o()
			{
				this.i.Paragraph.Indent = this.c();
			}

			// Token: 0x060047D5 RID: 18389 RVA: 0x002537DB File Offset: 0x002527DB
			private void n()
			{
				this.i.Paragraph.LeftIndent = this.c();
			}

			// Token: 0x060047D6 RID: 18390 RVA: 0x002537F4 File Offset: 0x002527F4
			private void m()
			{
				this.i.Paragraph.RightIndent = this.c();
			}

			// Token: 0x060047D7 RID: 18391 RVA: 0x0025380D File Offset: 0x0025280D
			private void l()
			{
				this.i.Paragraph.AllowOrphanLines = bool.Parse(this.a());
			}

			// Token: 0x060047D8 RID: 18392 RVA: 0x0025382B File Offset: 0x0025282B
			private void k()
			{
				this.i.Paragraph.PreserveWhiteSpace = bool.Parse(this.a());
			}

			// Token: 0x060047D9 RID: 18393 RVA: 0x0025384C File Offset: 0x0025284C
			private void j()
			{
				string text = this.a().ToLower();
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "left"))
					{
						if (!(text2 == "right"))
						{
							if (!(text2 == "center"))
							{
								if (text2 == "justify")
								{
									this.i.Paragraph.Align = TextAlign.Justify;
								}
							}
							else
							{
								this.i.Paragraph.Align = TextAlign.Center;
							}
						}
						else
						{
							this.i.Paragraph.Align = TextAlign.Right;
						}
					}
					else
					{
						this.i.Paragraph.Align = TextAlign.Left;
					}
				}
			}

			// Token: 0x060047DA RID: 18394 RVA: 0x002538F0 File Offset: 0x002528F0
			private void i()
			{
				this.i.Line.Leading = this.c();
			}

			// Token: 0x060047DB RID: 18395 RVA: 0x0025390C File Offset: 0x0025290C
			private void h()
			{
				string text = this.a().ToLower();
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "auto"))
					{
						if (!(text2 == "atleast"))
						{
							if (text2 == "exactly")
							{
								this.i.Line.LeadingType = LineLeadingType.Exactly;
							}
						}
						else
						{
							this.i.Line.LeadingType = LineLeadingType.AtLeast;
						}
					}
					else
					{
						this.i.Line.LeadingType = LineLeadingType.Auto;
					}
				}
			}

			// Token: 0x060047DC RID: 18396 RVA: 0x00253990 File Offset: 0x00252990
			private void g()
			{
				switch (this.b())
				{
				case 0:
					this.i.Font.Size = 6f;
					break;
				case 1:
					this.i.Font.Size = 8f;
					break;
				case 2:
					this.i.Font.Size = 10f;
					break;
				case 3:
					this.i.Font.Size = 12f;
					break;
				case 4:
					this.i.Font.Size = 14f;
					break;
				case 5:
					this.i.Font.Size = 18f;
					break;
				case 6:
					this.i.Font.Size = 24f;
					break;
				case 7:
					this.i.Font.Size = 36f;
					break;
				}
			}

			// Token: 0x060047DD RID: 18397 RVA: 0x00253A8E File Offset: 0x00252A8E
			private void f()
			{
				this.i.Font.Size = this.c();
			}

			// Token: 0x060047DE RID: 18398 RVA: 0x00253AA8 File Offset: 0x00252AA8
			private void e()
			{
				string text = this.a().ToLower();
				string text2 = text;
				if (text2 != null)
				{
					if (text2 == "helvetica")
					{
						this.i.Font.Face = FontFamily.Helvetica;
						goto IL_FB;
					}
					if (text2 == "times")
					{
						this.i.Font.Face = FontFamily.Times;
						goto IL_FB;
					}
					if (text2 == "courier")
					{
						this.i.Font.Face = FontFamily.Courier;
						goto IL_FB;
					}
					if (text2 == "symbol")
					{
						this.i.Font.Face = FontFamily.Symbol;
						goto IL_FB;
					}
					if (text2 == "zapfdingbats")
					{
						this.i.Font.Face = FontFamily.ZapfDingbats;
						goto IL_FB;
					}
				}
				FontFamily fontFamily = this.h.FontFaces[text];
				if (fontFamily != null)
				{
					this.i.Font.Face = fontFamily;
				}
				IL_FB:
				this.p = true;
			}

			// Token: 0x060047DF RID: 18399 RVA: 0x00253BB7 File Offset: 0x00252BB7
			private void d()
			{
				this.i.Font.Color = Color.d(this.a());
			}

			// Token: 0x060047E0 RID: 18400 RVA: 0x00253BD5 File Offset: 0x00252BD5
			private void e(bool A_0)
			{
				this.i = new FormattedTextAreaStyle(this.i);
				this.i.Bold = A_0;
				this.p = true;
			}

			// Token: 0x060047E1 RID: 18401 RVA: 0x00253BFC File Offset: 0x00252BFC
			private void d(bool A_0)
			{
				this.i = new FormattedTextAreaStyle(this.i);
				this.i.Italic = A_0;
				this.p = true;
			}

			// Token: 0x060047E2 RID: 18402 RVA: 0x00253C23 File Offset: 0x00252C23
			private void c(bool A_0)
			{
				this.i = new FormattedTextAreaStyle(this.i);
				this.i.Underline = A_0;
				this.p = true;
			}

			// Token: 0x060047E3 RID: 18403 RVA: 0x00253C4C File Offset: 0x00252C4C
			private void b(bool A_0)
			{
				if (this.e == null)
				{
					this.e = new Stack();
				}
				if (A_0)
				{
					this.i = new FormattedTextAreaStyle(this.i);
					if (this.e.Count > 0)
					{
						this.i.TextRise -= (float)this.e.Pop();
					}
				}
				else
				{
					float num = 0f;
					this.i = new FormattedTextAreaStyle(this.i);
					while (!this.t())
					{
						int num2 = this.s();
						if (num2 == 248468565)
						{
							goto IL_AB;
						}
						if (num2 == 509824180)
						{
							goto IL_AB;
						}
						this.u();
						continue;
						IL_AB:
						num = this.c();
					}
					if (num == 0f)
					{
						num = this.i.Font.Size / 3f;
					}
					this.i.TextRise += num;
					this.e.Push(num);
				}
			}

			// Token: 0x060047E4 RID: 18404 RVA: 0x00253D70 File Offset: 0x00252D70
			private void a(bool A_0)
			{
				if (this.f == null)
				{
					this.f = new Stack();
				}
				if (A_0)
				{
					this.i = new FormattedTextAreaStyle(this.i);
					if (this.f.Count > 0)
					{
						this.i.TextRise += (float)this.f.Pop();
					}
				}
				else
				{
					float num = 0f;
					this.i = new FormattedTextAreaStyle(this.i);
					while (!this.t())
					{
						int num2 = this.s();
						if (num2 == 248468565)
						{
							goto IL_AB;
						}
						if (num2 == 509824180)
						{
							goto IL_AB;
						}
						this.u();
						continue;
						IL_AB:
						num = this.c();
					}
					if (num == 0f)
					{
						num = this.i.Font.Size / 3f;
					}
					this.i.TextRise -= num;
					this.f.Push(num);
				}
			}

			// Token: 0x060047E5 RID: 18405 RVA: 0x00253E94 File Offset: 0x00252E94
			private float c()
			{
				return float.Parse(this.a(), CultureInfo.InvariantCulture);
			}

			// Token: 0x060047E6 RID: 18406 RVA: 0x00253EB8 File Offset: 0x00252EB8
			private int b()
			{
				return int.Parse(this.a());
			}

			// Token: 0x060047E7 RID: 18407 RVA: 0x00253ED8 File Offset: 0x00252ED8
			private string a()
			{
				while (this.g < this.j.Length && this.j[this.g] != '=')
				{
					this.g++;
				}
				string result;
				if (this.g + 2 < this.j.Length && this.j[this.g] == '=')
				{
					this.g++;
					while (this.g < this.j.Length && this.j[this.g] <= ' ')
					{
						this.g++;
					}
					bool flag = false;
					bool flag2 = false;
					if (this.j[this.g] == '"')
					{
						flag2 = true;
						this.g++;
					}
					else if (this.j[this.g] == '\'')
					{
						flag = true;
						this.g++;
					}
					int startIndex = this.g;
					int num = 0;
					if (flag2)
					{
						while (this.g < this.j.Length && this.j[this.g] != '"')
						{
							this.g++;
							num++;
						}
					}
					else if (flag)
					{
						while (this.g < this.j.Length && this.j[this.g] != '\'')
						{
							this.g++;
							num++;
						}
					}
					else
					{
						while (this.g < this.j.Length && this.j[this.g] != ' ' && this.j[this.g] != '/' && this.j[this.g] != '>')
						{
							this.g++;
							num++;
						}
					}
					result = new string(this.j, startIndex, num);
				}
				else
				{
					if (this.g < this.j.Length && this.j[this.g] == '=')
					{
						this.g++;
					}
					result = "";
				}
				return result;
			}

			// Token: 0x060047E8 RID: 18408 RVA: 0x00254174 File Offset: 0x00253174
			public FormattedTextArea.c a(int A_0)
			{
				return (FormattedTextArea.c)this.k[A_0];
			}

			// Token: 0x060047E9 RID: 18409 RVA: 0x00254198 File Offset: 0x00253198
			public int af()
			{
				return this.k.Count;
			}

			// Token: 0x060047EA RID: 18410 RVA: 0x002541B8 File Offset: 0x002531B8
			public float b(int A_0)
			{
				float result;
				if (A_0 == 0)
				{
					result = this.y + 0.001f;
				}
				else
				{
					result = this.y - this.a(A_0).p() + this.a(A_0).i() + 0.001f;
				}
				return result;
			}

			// Token: 0x060047EB RID: 18411 RVA: 0x0025420C File Offset: 0x0025320C
			public float a(VAlign A_0, float A_1, int A_2, int A_3)
			{
				float result;
				switch (A_0)
				{
				case VAlign.Center:
					result = (A_1 - this.b(A_2, A_3)) / 2f;
					break;
				case VAlign.Bottom:
					result = A_1 - this.b(A_2, A_3);
					break;
				default:
					result = 0f;
					break;
				}
				return result;
			}

			// Token: 0x060047EC RID: 18412 RVA: 0x0025425C File Offset: 0x0025325C
			public float b(int A_0, int A_1)
			{
				return this.a(A_0 + A_1 - 1).p() - this.a(A_0).p() + this.a(A_0 + A_1 - 1).j() + this.a(A_0).i();
			}

			// Token: 0x060047ED RID: 18413 RVA: 0x002542AC File Offset: 0x002532AC
			public int a(float A_0, int A_1)
			{
				if (A_1 != 0)
				{
					A_0 += this.a(A_1).p() - this.a(A_1).i();
				}
				int num = 0;
				int num2 = A_1;
				int result;
				if (A_1 >= this.af())
				{
					result = 0;
				}
				else
				{
					while (num2 < this.af() && (num == 0 || A_0 > this.a(num2).p() + this.a(num2).j()))
					{
						num2++;
						num++;
					}
					if (num > 2 && !this.a(num2 - 1).c().Paragraph.AllowOrphanLines)
					{
						if (this.a(num2 - 1).l() && !this.a(num2 - 1).m())
						{
							num--;
						}
						else if (this.a(num2 - 2).l() && num2 + 1 < this.af() && !this.a(num2 - 1).m() && this.a(num2).m())
						{
							num -= 2;
						}
						else if (num2 > 2 && this.af() > num2 && this.a(num2).m())
						{
							num--;
						}
					}
					result = num;
				}
				return result;
			}

			// Token: 0x060047EE RID: 18414 RVA: 0x00254408 File Offset: 0x00253408
			public int b(float A_0, int A_1)
			{
				if (A_1 != 0)
				{
					A_0 += this.a(A_1).p() - this.a(A_1).i();
				}
				int num = 0;
				int num2 = A_1;
				int result;
				if (A_1 >= this.af())
				{
					result = 0;
				}
				else
				{
					while (num2 < this.af() && A_0 > this.a(num2).p() + this.a(num2).j())
					{
						num2++;
						num++;
					}
					if (num > 2 && !this.a(num2 - 1).c().Paragraph.AllowOrphanLines)
					{
						if (this.a(num2 - 1).l() && !this.a(num2 - 1).m())
						{
							num--;
						}
						else if (this.a(num2 - 2).l() && num2 + 1 < this.af() && !this.a(num2 - 1).m() && this.a(num2).m())
						{
							num -= 2;
						}
						else if (num2 > 2 && this.af() > num2 && this.a(num2).m())
						{
							num--;
						}
					}
					result = num;
				}
				return result;
			}

			// Token: 0x04002748 RID: 10056
			private bool a = true;

			// Token: 0x04002749 RID: 10057
			private Stack b = new Stack();

			// Token: 0x0400274A RID: 10058
			private Stack c = new Stack();

			// Token: 0x0400274B RID: 10059
			private Stack d = new Stack();

			// Token: 0x0400274C RID: 10060
			private Stack e = null;

			// Token: 0x0400274D RID: 10061
			private Stack f = null;

			// Token: 0x0400274E RID: 10062
			private int g = 0;

			// Token: 0x0400274F RID: 10063
			private FormattedTextArea h = null;

			// Token: 0x04002750 RID: 10064
			private FormattedTextAreaStyle i = null;

			// Token: 0x04002751 RID: 10065
			private char[] j = null;

			// Token: 0x04002752 RID: 10066
			private ArrayList k = new ArrayList();

			// Token: 0x04002753 RID: 10067
			private Font l = null;

			// Token: 0x04002754 RID: 10068
			private FormattedTextArea.c m = null;

			// Token: 0x04002755 RID: 10069
			private FormattedTextArea.e n = null;

			// Token: 0x04002756 RID: 10070
			private bool o = true;

			// Token: 0x04002757 RID: 10071
			private bool p = true;

			// Token: 0x04002758 RID: 10072
			private bool q = false;

			// Token: 0x04002759 RID: 10073
			private int r = 0;

			// Token: 0x0400275A RID: 10074
			private int s = 0;

			// Token: 0x0400275B RID: 10075
			private float t = 0f;

			// Token: 0x0400275C RID: 10076
			private int u = 0;

			// Token: 0x0400275D RID: 10077
			private float v = 0f;

			// Token: 0x0400275E RID: 10078
			private int w = 0;

			// Token: 0x0400275F RID: 10079
			private float x = 0f;

			// Token: 0x04002760 RID: 10080
			private float y = 0f;

			// Token: 0x04002761 RID: 10081
			private FormattedTextArea.c z = null;
		}

		// Token: 0x02000712 RID: 1810
		internal class c
		{
			// Token: 0x060047EF RID: 18415 RVA: 0x0025455C File Offset: 0x0025355C
			public c(FormattedTextArea A_0, FormattedTextAreaStyle A_1, bool A_2)
			{
				this.d = A_0;
				this.b = A_2;
				this.a(A_1, true);
				this.f = new FormattedTextArea.d();
			}

			// Token: 0x060047F0 RID: 18416 RVA: 0x0025462C File Offset: 0x0025362C
			public void a(ref float A_0)
			{
				switch (this.e.Line.LeadingType)
				{
				case LineLeadingType.Auto:
					A_0 += this.k;
					break;
				case LineLeadingType.AtLeast:
					if (this.e.Line.Leading > this.k + this.l + this.m)
					{
						this.j = this.e.Line.Leading;
						this.k = this.j - this.l - this.m;
					}
					A_0 += this.k;
					break;
				case LineLeadingType.Exactly:
				{
					this.j = this.e.Line.Leading;
					float num = this.j / (this.k + this.l + this.m);
					this.k *= num;
					this.l *= num;
					this.m *= num;
					A_0 += this.k;
					break;
				}
				}
				this.q = A_0;
				A_0 += this.l + this.m;
				this.q().a();
				this.a();
			}

			// Token: 0x060047F1 RID: 18417 RVA: 0x00254774 File Offset: 0x00253774
			public void b()
			{
				switch (this.c().Paragraph.Align)
				{
				case TextAlign.Justify:
					break;
				case TextAlign.FullJustify:
					break;
				default:
					return;
				}
				if ((!this.k() && this.g() != 1) || this.c().Paragraph.Align == TextAlign.FullJustify)
				{
					if (this.f() > 0)
					{
						this.o = (this.d() - this.e()) / (float)this.f();
					}
					else
					{
						this.p = (this.d() - this.e()) / (float)(this.g() - 1);
					}
				}
			}

			// Token: 0x060047F2 RID: 18418 RVA: 0x00254828 File Offset: 0x00253828
			public void a(FormattedTextArea.e A_0)
			{
				this.f.a(A_0);
				this.g += A_0.c() + A_0.e();
				if (A_0.f() > this.j)
				{
					this.j = A_0.f();
				}
				if (A_0.g() > this.k)
				{
					this.k = A_0.g();
				}
				if (A_0.h() > this.l)
				{
					this.l = A_0.h();
				}
				if (A_0.i() > this.m)
				{
					this.m = A_0.i();
				}
			}

			// Token: 0x060047F3 RID: 18419 RVA: 0x002548E4 File Offset: 0x002538E4
			private void a()
			{
				this.g = 0f;
				this.h = 0;
				this.i = 0;
				foreach (object obj in this.q())
				{
					FormattedTextArea.e e = (FormattedTextArea.e)obj;
					foreach (object obj2 in e.a())
					{
						FormattedTextArea.g g = (FormattedTextArea.g)obj2;
						this.g += g.b();
						this.h += g.c();
						this.i += g.a();
					}
				}
			}

			// Token: 0x060047F4 RID: 18420 RVA: 0x002549F8 File Offset: 0x002539F8
			public void a(FormattedTextAreaStyle A_0, bool A_1)
			{
				if (this.b && !A_1)
				{
					this.q += A_0.Paragraph.SpacingBefore - this.e.Paragraph.SpacingBefore;
				}
				this.e = A_0;
				Font font = A_0.GetFont();
				float size = A_0.Font.Size;
				this.j = font.GetDefaultLeading(size);
				this.k = font.GetAscender(size);
				this.l = -font.GetDescender(size);
				this.m = font.GetLineGap(size);
				this.n = this.d.Width - this.e.Paragraph.LeftIndent - this.e.Paragraph.RightIndent;
				if (this.b)
				{
					this.n -= this.e.Paragraph.Indent;
				}
			}

			// Token: 0x060047F5 RID: 18421 RVA: 0x00254AF0 File Offset: 0x00253AF0
			public FormattedTextAreaStyle c()
			{
				return this.e;
			}

			// Token: 0x060047F6 RID: 18422 RVA: 0x00254B08 File Offset: 0x00253B08
			public float d()
			{
				return this.n;
			}

			// Token: 0x060047F7 RID: 18423 RVA: 0x00254B20 File Offset: 0x00253B20
			public float e()
			{
				return this.g;
			}

			// Token: 0x060047F8 RID: 18424 RVA: 0x00254B38 File Offset: 0x00253B38
			public int f()
			{
				return this.h;
			}

			// Token: 0x060047F9 RID: 18425 RVA: 0x00254B50 File Offset: 0x00253B50
			public int g()
			{
				return this.i;
			}

			// Token: 0x060047FA RID: 18426 RVA: 0x00254B68 File Offset: 0x00253B68
			public float h()
			{
				return this.j;
			}

			// Token: 0x060047FB RID: 18427 RVA: 0x00254B80 File Offset: 0x00253B80
			public float i()
			{
				return this.k;
			}

			// Token: 0x060047FC RID: 18428 RVA: 0x00254B98 File Offset: 0x00253B98
			public float j()
			{
				return this.l;
			}

			// Token: 0x060047FD RID: 18429 RVA: 0x00254BB0 File Offset: 0x00253BB0
			public bool k()
			{
				return this.a;
			}

			// Token: 0x060047FE RID: 18430 RVA: 0x00254BC8 File Offset: 0x00253BC8
			public void a(bool A_0)
			{
				this.a = A_0;
			}

			// Token: 0x060047FF RID: 18431 RVA: 0x00254BD4 File Offset: 0x00253BD4
			public bool l()
			{
				return this.b;
			}

			// Token: 0x06004800 RID: 18432 RVA: 0x00254BEC File Offset: 0x00253BEC
			internal void b(bool A_0)
			{
				this.b = A_0;
			}

			// Token: 0x06004801 RID: 18433 RVA: 0x00254BF8 File Offset: 0x00253BF8
			public bool m()
			{
				return this.c;
			}

			// Token: 0x06004802 RID: 18434 RVA: 0x00254C10 File Offset: 0x00253C10
			public void c(bool A_0)
			{
				this.c = A_0;
			}

			// Token: 0x06004803 RID: 18435 RVA: 0x00254C1C File Offset: 0x00253C1C
			public float n()
			{
				return this.p;
			}

			// Token: 0x06004804 RID: 18436 RVA: 0x00254C34 File Offset: 0x00253C34
			public float o()
			{
				return this.o;
			}

			// Token: 0x06004805 RID: 18437 RVA: 0x00254C4C File Offset: 0x00253C4C
			public float p()
			{
				return this.q;
			}

			// Token: 0x06004806 RID: 18438 RVA: 0x00254C64 File Offset: 0x00253C64
			public FormattedTextArea.d q()
			{
				return this.f;
			}

			// Token: 0x04002762 RID: 10082
			private bool a = false;

			// Token: 0x04002763 RID: 10083
			private bool b = false;

			// Token: 0x04002764 RID: 10084
			private bool c = false;

			// Token: 0x04002765 RID: 10085
			private FormattedTextArea d = null;

			// Token: 0x04002766 RID: 10086
			private FormattedTextAreaStyle e;

			// Token: 0x04002767 RID: 10087
			private FormattedTextArea.d f = new FormattedTextArea.d();

			// Token: 0x04002768 RID: 10088
			private float g = 0f;

			// Token: 0x04002769 RID: 10089
			private int h = 0;

			// Token: 0x0400276A RID: 10090
			private int i = 0;

			// Token: 0x0400276B RID: 10091
			private float j = 0f;

			// Token: 0x0400276C RID: 10092
			private float k = 0f;

			// Token: 0x0400276D RID: 10093
			private float l = 0f;

			// Token: 0x0400276E RID: 10094
			private float m = 0f;

			// Token: 0x0400276F RID: 10095
			private float n = 0f;

			// Token: 0x04002770 RID: 10096
			private float o = 0f;

			// Token: 0x04002771 RID: 10097
			private float p = 0f;

			// Token: 0x04002772 RID: 10098
			private float q = 0f;
		}

		// Token: 0x02000713 RID: 1811
		internal new class d : IEnumerable
		{
			// Token: 0x06004807 RID: 18439 RVA: 0x00254C7C File Offset: 0x00253C7C
			public IEnumerator GetEnumerator()
			{
				return this.a.GetEnumerator();
			}

			// Token: 0x06004808 RID: 18440 RVA: 0x00254C9C File Offset: 0x00253C9C
			public void a()
			{
				if (this.a.Count > 0)
				{
					for (int i = this.a.Count - 1; i >= 0; i--)
					{
						if (((FormattedTextArea.e)this.a[i]).a().a())
						{
							break;
						}
					}
				}
			}

			// Token: 0x06004809 RID: 18441 RVA: 0x00254D07 File Offset: 0x00253D07
			public void a(FormattedTextArea.e A_0)
			{
				this.a.Add(A_0);
			}

			// Token: 0x0600480A RID: 18442 RVA: 0x00254D18 File Offset: 0x00253D18
			public int b()
			{
				return this.a.Count;
			}

			// Token: 0x04002773 RID: 10099
			private ArrayList a = new ArrayList();
		}

		// Token: 0x02000714 RID: 1812
		internal class e
		{
			// Token: 0x0600480C RID: 18444 RVA: 0x00254D4C File Offset: 0x00253D4C
			internal e(FormattedTextAreaStyle A_0)
			{
				this.b = A_0;
			}

			// Token: 0x0600480D RID: 18445 RVA: 0x00254DC0 File Offset: 0x00253DC0
			public void a(FormattedTextArea.g A_0)
			{
				this.a.a(A_0);
				this.c += A_0.f();
				this.e += A_0.g();
				this.d += A_0.e();
				Font font = A_0.h().GetFont();
				float size = A_0.h().Font.Size;
				float defaultLeading = font.GetDefaultLeading(size);
				float ascender = font.GetAscender(size);
				float num = -font.GetDescender(size);
				float lineGap = font.GetLineGap(size);
				if (this.f < defaultLeading)
				{
					this.f = defaultLeading;
				}
				if (this.g < ascender)
				{
					this.g = ascender;
				}
				if (this.h < num)
				{
					this.h = num;
				}
				if (this.i < lineGap)
				{
					this.i = lineGap;
				}
			}

			// Token: 0x0600480E RID: 18446 RVA: 0x00254EBC File Offset: 0x00253EBC
			public FormattedTextArea.f a()
			{
				return this.a;
			}

			// Token: 0x0600480F RID: 18447 RVA: 0x00254ED4 File Offset: 0x00253ED4
			public FormattedTextAreaStyle b()
			{
				return this.b;
			}

			// Token: 0x06004810 RID: 18448 RVA: 0x00254EEC File Offset: 0x00253EEC
			internal void a(FormattedTextAreaStyle A_0)
			{
				this.b = A_0;
			}

			// Token: 0x06004811 RID: 18449 RVA: 0x00254EF8 File Offset: 0x00253EF8
			public float c()
			{
				return this.c;
			}

			// Token: 0x06004812 RID: 18450 RVA: 0x00254F10 File Offset: 0x00253F10
			public int d()
			{
				return this.d;
			}

			// Token: 0x06004813 RID: 18451 RVA: 0x00254F28 File Offset: 0x00253F28
			public float e()
			{
				return this.e;
			}

			// Token: 0x06004814 RID: 18452 RVA: 0x00254F40 File Offset: 0x00253F40
			public float f()
			{
				return this.f;
			}

			// Token: 0x06004815 RID: 18453 RVA: 0x00254F58 File Offset: 0x00253F58
			public float g()
			{
				return this.g;
			}

			// Token: 0x06004816 RID: 18454 RVA: 0x00254F70 File Offset: 0x00253F70
			public float h()
			{
				return this.h;
			}

			// Token: 0x06004817 RID: 18455 RVA: 0x00254F88 File Offset: 0x00253F88
			public float i()
			{
				return this.i;
			}

			// Token: 0x04002774 RID: 10100
			private FormattedTextArea.f a = new FormattedTextArea.f();

			// Token: 0x04002775 RID: 10101
			private FormattedTextAreaStyle b;

			// Token: 0x04002776 RID: 10102
			private float c = 0f;

			// Token: 0x04002777 RID: 10103
			private int d = 0;

			// Token: 0x04002778 RID: 10104
			private float e = 0f;

			// Token: 0x04002779 RID: 10105
			private float f = 0f;

			// Token: 0x0400277A RID: 10106
			private float g = 0f;

			// Token: 0x0400277B RID: 10107
			private float h = 0f;

			// Token: 0x0400277C RID: 10108
			private float i = 0f;
		}

		// Token: 0x02000715 RID: 1813
		[DefaultMember("Item")]
		internal class f : IEnumerable
		{
			// Token: 0x06004818 RID: 18456 RVA: 0x00254FA0 File Offset: 0x00253FA0
			public IEnumerator GetEnumerator()
			{
				return this.a.GetEnumerator();
			}

			// Token: 0x06004819 RID: 18457 RVA: 0x00254FC0 File Offset: 0x00253FC0
			public bool a()
			{
				if (this.a.Count > 0)
				{
					for (int i = this.a.Count - 1; i >= 0; i--)
					{
						((FormattedTextArea.g)this.a[i]).a(true);
						if (((FormattedTextArea.g)this.a[i]).e() > 0)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600481A RID: 18458 RVA: 0x00255048 File Offset: 0x00254048
			public FormattedTextArea.g a(int A_0)
			{
				return (FormattedTextArea.g)this.a[A_0];
			}

			// Token: 0x0600481B RID: 18459 RVA: 0x0025506B File Offset: 0x0025406B
			public void a(FormattedTextArea.g A_0)
			{
				this.a.Add(A_0);
			}

			// Token: 0x0400277D RID: 10109
			private ArrayList a = new ArrayList();
		}

		// Token: 0x02000716 RID: 1814
		internal class g
		{
			// Token: 0x0600481D RID: 18461 RVA: 0x0025508F File Offset: 0x0025408F
			public g(FormattedTextAreaStyle A_0, int A_1, int A_2, float A_3, int A_4, float A_5)
			{
				this.a = A_0;
				this.b = A_1;
				this.c = A_2;
				this.e = A_4;
				this.d = A_3;
				this.f = A_5;
			}

			// Token: 0x0600481E RID: 18462 RVA: 0x002550D0 File Offset: 0x002540D0
			public int a()
			{
				int result;
				if (this.g)
				{
					result = this.c;
				}
				else
				{
					result = this.c + this.e;
				}
				return result;
			}

			// Token: 0x0600481F RID: 18463 RVA: 0x00255108 File Offset: 0x00254108
			public float b()
			{
				float result;
				if (this.g)
				{
					result = this.d;
				}
				else
				{
					result = this.d + this.f;
				}
				return result;
			}

			// Token: 0x06004820 RID: 18464 RVA: 0x00255140 File Offset: 0x00254140
			public int c()
			{
				int result;
				if (this.g)
				{
					result = 0;
				}
				else
				{
					result = this.e;
				}
				return result;
			}

			// Token: 0x06004821 RID: 18465 RVA: 0x0025516C File Offset: 0x0025416C
			public int d()
			{
				return this.b;
			}

			// Token: 0x06004822 RID: 18466 RVA: 0x00255184 File Offset: 0x00254184
			public int e()
			{
				return this.c;
			}

			// Token: 0x06004823 RID: 18467 RVA: 0x0025519C File Offset: 0x0025419C
			public float f()
			{
				return this.d;
			}

			// Token: 0x06004824 RID: 18468 RVA: 0x002551B4 File Offset: 0x002541B4
			public float g()
			{
				return this.f;
			}

			// Token: 0x06004825 RID: 18469 RVA: 0x002551CC File Offset: 0x002541CC
			public FormattedTextAreaStyle h()
			{
				return this.a;
			}

			// Token: 0x06004826 RID: 18470 RVA: 0x002551E4 File Offset: 0x002541E4
			public void a(bool A_0)
			{
				this.g = A_0;
			}

			// Token: 0x0400277E RID: 10110
			private FormattedTextAreaStyle a;

			// Token: 0x0400277F RID: 10111
			private int b;

			// Token: 0x04002780 RID: 10112
			private int c;

			// Token: 0x04002781 RID: 10113
			private float d;

			// Token: 0x04002782 RID: 10114
			private int e;

			// Token: 0x04002783 RID: 10115
			private float f;

			// Token: 0x04002784 RID: 10116
			private bool g = false;
		}
	}
}
