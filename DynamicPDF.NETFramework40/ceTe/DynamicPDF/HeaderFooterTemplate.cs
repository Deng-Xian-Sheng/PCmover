using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006C0 RID: 1728
	public class HeaderFooterTemplate : Template
	{
		// Token: 0x060042B5 RID: 17077 RVA: 0x0022BE21 File Offset: 0x0022AE21
		public HeaderFooterTemplate()
		{
		}

		// Token: 0x060042B6 RID: 17078 RVA: 0x0022BE60 File Offset: 0x0022AE60
		public HeaderFooterTemplate(string footerText)
		{
			this.e = new HeaderFooterText();
			this.e.Text = footerText;
		}

		// Token: 0x060042B7 RID: 17079 RVA: 0x0022BEC0 File Offset: 0x0022AEC0
		public HeaderFooterTemplate(string headerText, string footerText)
		{
			this.b = new HeaderFooterText();
			this.b.Text = headerText;
			this.e = new HeaderFooterText();
			this.e.Text = footerText;
		}

		// Token: 0x060042B8 RID: 17080 RVA: 0x0022BF38 File Offset: 0x0022AF38
		public HeaderFooterTemplate(string headerText, string footerText, Font font, float fontsize)
		{
			this.b = new HeaderFooterText();
			this.b.Text = headerText;
			this.e = new HeaderFooterText();
			this.e.Text = footerText;
			HeaderFooterText headerFooterText = this.b;
			this.e.Font = font;
			headerFooterText.Font = font;
			HeaderFooterText headerFooterText2 = this.b;
			this.e.FontSize = fontsize;
			headerFooterText2.FontSize = fontsize;
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060042B9 RID: 17081 RVA: 0x0022BFE8 File Offset: 0x0022AFE8
		// (set) Token: 0x060042BA RID: 17082 RVA: 0x0022C000 File Offset: 0x0022B000
		public HeaderFooterText HeaderCenter
		{
			get
			{
				return this.b;
			}
			set
			{
				if (value != null)
				{
					this.b = value.c();
				}
				else
				{
					this.b = value;
				}
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060042BB RID: 17083 RVA: 0x0022C02C File Offset: 0x0022B02C
		// (set) Token: 0x060042BC RID: 17084 RVA: 0x0022C044 File Offset: 0x0022B044
		public HeaderFooterText HeaderLeft
		{
			get
			{
				return this.c;
			}
			set
			{
				if (value != null)
				{
					this.c = value.c();
				}
				else
				{
					this.c = value;
				}
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060042BD RID: 17085 RVA: 0x0022C070 File Offset: 0x0022B070
		// (set) Token: 0x060042BE RID: 17086 RVA: 0x0022C088 File Offset: 0x0022B088
		public HeaderFooterText HeaderRight
		{
			get
			{
				return this.d;
			}
			set
			{
				if (value != null)
				{
					this.d = value.c();
				}
				else
				{
					this.d = value;
				}
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060042BF RID: 17087 RVA: 0x0022C0B4 File Offset: 0x0022B0B4
		// (set) Token: 0x060042C0 RID: 17088 RVA: 0x0022C0CC File Offset: 0x0022B0CC
		public HeaderFooterText FooterCenter
		{
			get
			{
				return this.e;
			}
			set
			{
				if (value != null)
				{
					this.e = value.c();
				}
				else
				{
					this.e = value;
				}
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060042C1 RID: 17089 RVA: 0x0022C0F8 File Offset: 0x0022B0F8
		// (set) Token: 0x060042C2 RID: 17090 RVA: 0x0022C110 File Offset: 0x0022B110
		public HeaderFooterText FooterLeft
		{
			get
			{
				return this.f;
			}
			set
			{
				if (value != null)
				{
					this.f = value.c();
				}
				else
				{
					this.f = value;
				}
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060042C3 RID: 17091 RVA: 0x0022C13C File Offset: 0x0022B13C
		// (set) Token: 0x060042C4 RID: 17092 RVA: 0x0022C154 File Offset: 0x0022B154
		public HeaderFooterText FooterRight
		{
			get
			{
				return this.g;
			}
			set
			{
				if (value != null)
				{
					this.g = value.c();
				}
				else
				{
					this.g = value;
				}
			}
		}

		// Token: 0x060042C5 RID: 17093 RVA: 0x0022C180 File Offset: 0x0022B180
		internal override int j2()
		{
			return 703119003;
		}

		// Token: 0x060042C6 RID: 17094 RVA: 0x0022C198 File Offset: 0x0022B198
		internal PageDimensions a()
		{
			return this.h;
		}

		// Token: 0x060042C7 RID: 17095 RVA: 0x0022C1B0 File Offset: 0x0022B1B0
		internal void a(PageDimensions A_0)
		{
			this.h = A_0;
		}

		// Token: 0x060042C8 RID: 17096 RVA: 0x0022C1BC File Offset: 0x0022B1BC
		public override void Draw(PageWriter writer)
		{
			this.a(writer);
			if (base.Elements.Count > 0)
			{
				base.Elements.Draw(writer);
			}
		}

		// Token: 0x060042C9 RID: 17097 RVA: 0x0022C1F4 File Offset: 0x0022B1F4
		private void a(PageWriter A_0)
		{
			float num = 0f;
			float num2 = 0f;
			if (this.b != null)
			{
				if (this.b.a())
				{
					float width = this.h.Width - (this.h.LeftMargin + this.h.RightMargin);
					num2 -= this.h.TopMargin / 2f;
					num2 -= 12f;
					if (!this.b.b())
					{
						base.Elements.Add(new PageNumberingLabel(this.b.Text, num, num2, width, 12f, Font.Helvetica, 12f, TextAlign.Center));
						this.b.b(true);
					}
				}
				else
				{
					this.b.a(A_0, this.h, true, TextAlign.Center);
				}
				num = 0f;
				num2 = 0f;
			}
			if (this.c != null)
			{
				if (this.c.a())
				{
					float width = this.h.Width - (this.h.LeftMargin + this.h.RightMargin);
					num -= this.h.LeftMargin / 2f;
					num2 -= this.h.TopMargin / 2f;
					num2 -= 12f;
					if (!this.c.b())
					{
						base.Elements.Add(new PageNumberingLabel(this.c.Text, num, num2, width, 12f, Font.Helvetica, 12f, TextAlign.Left));
						this.c.b(true);
					}
				}
				else
				{
					this.c.a(A_0, this.h, true, TextAlign.Left);
				}
				num = 0f;
				num2 = 0f;
			}
			if (this.d != null)
			{
				if (this.d.a())
				{
					float width = this.h.Width - (this.h.LeftMargin + this.h.RightMargin / 2f);
					num2 -= this.h.TopMargin / 2f;
					num2 -= 12f;
					if (!this.d.b())
					{
						base.Elements.Add(new PageNumberingLabel(this.d.Text, num, num2, width, 12f, Font.Helvetica, 12f, TextAlign.Right));
						this.d.b(true);
					}
				}
				else
				{
					this.d.a(A_0, this.h, true, TextAlign.Right);
				}
				num = 0f;
			}
			if (this.e != null)
			{
				if (this.e.a())
				{
					float width = this.h.Width - (this.h.LeftMargin + this.h.RightMargin);
					num2 = this.h.Height;
					num2 -= this.h.TopMargin + this.h.BottomMargin;
					num2 += this.h.BottomMargin / 2f;
					if (!this.e.b())
					{
						base.Elements.Add(new PageNumberingLabel(this.e.Text, num, num2, width, 12f, Font.Helvetica, 12f, TextAlign.Center));
						this.e.b(true);
					}
				}
				else
				{
					this.e.a(A_0, this.h, false, TextAlign.Center);
				}
				num = 0f;
			}
			if (this.f != null)
			{
				if (this.f.a())
				{
					num2 = this.h.Height;
					float width = this.h.Width - (this.h.LeftMargin + this.h.RightMargin);
					num -= this.h.LeftMargin / 2f;
					num2 -= this.h.TopMargin + this.h.BottomMargin;
					num2 += this.h.BottomMargin / 2f;
					if (!this.f.b())
					{
						base.Elements.Add(new PageNumberingLabel(this.f.Text, num, num2, width, 12f, Font.Helvetica, 12f, TextAlign.Left));
						this.f.b(true);
					}
				}
				else
				{
					this.f.a(A_0, this.h, false, TextAlign.Left);
				}
				num = 0f;
			}
			if (this.g != null)
			{
				if (this.g.a())
				{
					float width = this.h.Width - (this.h.LeftMargin + this.h.RightMargin / 2f);
					num2 = this.h.Height;
					num2 -= this.h.TopMargin + this.h.BottomMargin;
					num2 += this.h.BottomMargin / 2f;
					if (!this.g.b())
					{
						base.Elements.Add(new PageNumberingLabel(this.g.Text, num, num2, width, 12f, Font.Helvetica, 12f, TextAlign.Right));
						this.g.b(true);
					}
				}
				else
				{
					this.g.a(A_0, this.h, false, TextAlign.Right);
				}
			}
		}

		// Token: 0x04002518 RID: 9496
		internal const int a = 703119003;

		// Token: 0x04002519 RID: 9497
		private HeaderFooterText b = null;

		// Token: 0x0400251A RID: 9498
		private HeaderFooterText c = null;

		// Token: 0x0400251B RID: 9499
		private HeaderFooterText d = null;

		// Token: 0x0400251C RID: 9500
		private HeaderFooterText e = null;

		// Token: 0x0400251D RID: 9501
		private HeaderFooterText f = null;

		// Token: 0x0400251E RID: 9502
		private HeaderFooterText g = null;

		// Token: 0x0400251F RID: 9503
		private PageDimensions h = null;
	}
}
