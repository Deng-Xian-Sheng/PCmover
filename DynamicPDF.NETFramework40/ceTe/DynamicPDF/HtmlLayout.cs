using System;
using System.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements.Html;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B6 RID: 1718
	public class HtmlLayout
	{
		// Token: 0x06004230 RID: 16944 RVA: 0x00226F44 File Offset: 0x00225F44
		public HtmlLayout(Uri uri, PageInfo pageInfo)
		{
			this.d = this.a(uri);
			this.g = pageInfo;
		}

		// Token: 0x06004231 RID: 16945 RVA: 0x00226F78 File Offset: 0x00225F78
		public HtmlLayout(Stream stream, PageInfo pageInfo)
		{
			this.f = stream;
			this.g = pageInfo;
		}

		// Token: 0x06004232 RID: 16946 RVA: 0x00226FA6 File Offset: 0x00225FA6
		public HtmlLayout(string text, PageInfo pageInfo)
		{
			this.c = text;
			this.g = pageInfo;
		}

		// Token: 0x06004233 RID: 16947 RVA: 0x00226FD4 File Offset: 0x00225FD4
		public HtmlLayout(Uri uri, Uri baseRef, PageInfo pageInfo)
		{
			this.d = this.a(uri);
			this.e = baseRef;
			this.g = pageInfo;
		}

		// Token: 0x06004234 RID: 16948 RVA: 0x0022700F File Offset: 0x0022600F
		public HtmlLayout(Stream stream, Uri baseRef, PageInfo pageInfo)
		{
			this.f = stream;
			this.e = baseRef;
			this.g = pageInfo;
		}

		// Token: 0x06004235 RID: 16949 RVA: 0x00227044 File Offset: 0x00226044
		public HtmlLayout(string text, Uri baseRef, PageInfo pageInfo)
		{
			this.c = text;
			this.e = baseRef;
			this.g = pageInfo;
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06004236 RID: 16950 RVA: 0x0022707C File Offset: 0x0022607C
		public HeaderHtmlLayout Header
		{
			get
			{
				if (this.a == null)
				{
					this.a = new HeaderHtmlLayout();
					this.a.LeftMargin = new float?(this.LeftMargin);
					this.a.RightMargin = new float?(this.RightMargin);
				}
				return this.a;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06004237 RID: 16951 RVA: 0x002270E0 File Offset: 0x002260E0
		public FooterHtmlLayout Footer
		{
			get
			{
				if (this.b == null)
				{
					this.b = new FooterHtmlLayout();
					this.b.LeftMargin = new float?(this.LeftMargin);
					this.b.RightMargin = new float?(this.RightMargin);
				}
				return this.b;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06004238 RID: 16952 RVA: 0x00227144 File Offset: 0x00226144
		// (set) Token: 0x06004239 RID: 16953 RVA: 0x0022715C File Offset: 0x0022615C
		public Uri BaseRef
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x0600423A RID: 16954 RVA: 0x00227168 File Offset: 0x00226168
		// (set) Token: 0x0600423B RID: 16955 RVA: 0x0022718A File Offset: 0x0022618A
		public float TopMargin
		{
			get
			{
				return this.g.a().TopMargin;
			}
			set
			{
				this.g.a().TopMargin = value;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x0600423C RID: 16956 RVA: 0x002271A0 File Offset: 0x002261A0
		// (set) Token: 0x0600423D RID: 16957 RVA: 0x002271C2 File Offset: 0x002261C2
		public float RightMargin
		{
			get
			{
				return this.g.a().RightMargin;
			}
			set
			{
				this.g.a().RightMargin = value;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x0600423E RID: 16958 RVA: 0x002271D8 File Offset: 0x002261D8
		// (set) Token: 0x0600423F RID: 16959 RVA: 0x002271FA File Offset: 0x002261FA
		public float BottomMargin
		{
			get
			{
				return this.g.a().BottomMargin;
			}
			set
			{
				this.g.a().BottomMargin = value;
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06004240 RID: 16960 RVA: 0x00227210 File Offset: 0x00226210
		// (set) Token: 0x06004241 RID: 16961 RVA: 0x00227232 File Offset: 0x00226232
		public float LeftMargin
		{
			get
			{
				return this.g.a().LeftMargin;
			}
			set
			{
				this.g.a().LeftMargin = value;
			}
		}

		// Token: 0x06004242 RID: 16962 RVA: 0x00227248 File Offset: 0x00226248
		public Document Layout()
		{
			Document document = new Document();
			this.Layout(document);
			return document;
		}

		// Token: 0x06004243 RID: 16963 RVA: 0x0022726C File Offset: 0x0022626C
		public void Layout(Document document)
		{
			document.RequireLicense(1);
			float width = this.g.a().Body.Width;
			HtmlArea htmlArea = this.a(0f, 0f, width, this.g.a().Body.Height);
			if (this.a != null || this.b != null)
			{
				ij a_ = htmlArea.j();
				if (this.a != null)
				{
					this.b(a_);
				}
				if (this.b != null)
				{
					this.a(a_);
				}
			}
			float num = (this.a != null) ? this.a.a() : 0f;
			float num2 = num - this.g.a().TopMargin;
			num2 = ((num2 < 0f) ? 0f : num2);
			float num3 = this.g.a().Body.Height - num2;
			if (this.b != null && this.b.a() > this.g.a().BottomMargin)
			{
				num3 -= this.b.a() - this.g.a().BottomMargin;
			}
			if (num3 < this.g.a().Body.Height / 4f)
			{
				num3 = this.g.a().Body.Height / 4f;
			}
			bool flag = true;
			do
			{
				Page page;
				if (this.g.b() == null)
				{
					page = new Page(this.g.a());
				}
				else
				{
					page = new ImportedPage(this.g.b());
				}
				document.Pages.Add(page);
				if (num > this.g.a().TopMargin)
				{
					if (flag)
					{
						this.a(htmlArea);
					}
				}
				HtmlArea overflowHtmlArea = htmlArea.GetOverflowHtmlArea(htmlArea.X, num2, num3);
				bool flag2 = this.b(page, flag, overflowHtmlArea == null);
				if (overflowHtmlArea == null)
				{
					if (!flag2)
					{
						htmlArea.Y = 0f;
					}
					else if (num > this.g.a().TopMargin)
					{
						htmlArea.Y = this.a();
					}
				}
				page.Elements.Add(htmlArea);
				this.a(page, flag, overflowHtmlArea == null);
				htmlArea = overflowHtmlArea;
				flag = false;
			}
			while (htmlArea != null);
		}

		// Token: 0x06004244 RID: 16964 RVA: 0x00227544 File Offset: 0x00226544
		private float a()
		{
			float result;
			if (this.a != null)
			{
				float num = 0f;
				if (this.a.Left.a() != null && this.a.Left.ShowOnLastPage)
				{
					num = this.a.Left.a().Height;
				}
				if (this.a.Center.a() != null && this.a.Center.ShowOnLastPage)
				{
					if (this.a.Center.a().Height > num)
					{
						num = this.a.Center.a().Height;
					}
				}
				if (this.a.Right.a() != null && this.a.Right.ShowOnLastPage)
				{
					if (this.a.Right.a().Height > num)
					{
						num = this.a.Right.a().Height;
					}
				}
				float num2 = (this.a.BottomPadding != null) ? this.a.BottomPadding.Value : 0f;
				float num3 = (this.a.TopMargin != null) ? this.a.TopMargin.Value : 0f;
				float num4 = num + num3 + num2;
				result = num4 - this.g.a().TopMargin;
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06004245 RID: 16965 RVA: 0x00227714 File Offset: 0x00226714
		private void a(HtmlArea A_0)
		{
			if (this.a != null)
			{
				float num = 0f;
				bool flag = false;
				if (this.a.Left.a() != null && this.a.Left.ShowOnFirstPage)
				{
					num = this.a.Left.a().Height;
					flag = true;
				}
				if (this.a.Center.a() != null && this.a.Center.ShowOnFirstPage)
				{
					if (this.a.Center.a().Height > num)
					{
						num = this.a.Center.a().Height;
					}
					flag = true;
				}
				if (this.a.Right.a() != null && this.a.Right.ShowOnFirstPage)
				{
					if (this.a.Right.a().Height > num)
					{
						num = this.a.Right.a().Height;
					}
					flag = true;
				}
				if (flag)
				{
					float num2 = (this.a.BottomPadding != null) ? this.a.BottomPadding.Value : 0f;
					float num3 = (this.a.TopMargin != null) ? this.a.TopMargin.Value : 0f;
					float num4 = num;
					num4 += num3 + num2;
					A_0.Y = num4 - this.g.a().TopMargin;
					A_0.Height = this.g.a().Body.Height - A_0.Y;
				}
				else
				{
					A_0.Y = 0f;
					A_0.Height = this.g.a().Body.Height;
				}
			}
			if (this.b != null)
			{
				float num5 = 0f;
				bool flag2 = false;
				if (this.b.Left.a() != null && this.b.Left.ShowOnFirstPage)
				{
					num5 = this.b.Left.a().Height;
					flag2 = true;
				}
				if (this.b.Center.a() != null && this.b.Center.ShowOnFirstPage)
				{
					if (this.b.Center.a().Height > num5)
					{
						num5 = this.b.Center.a().Height;
					}
					flag2 = true;
				}
				if (this.b.Right.a() != null && this.b.Right.ShowOnFirstPage)
				{
					if (this.b.Right.a().Height > num5)
					{
						num5 = this.b.Right.a().Height;
					}
					flag2 = true;
				}
				if (flag2)
				{
					float num6 = (this.b.TopPadding != null) ? this.b.TopPadding.Value : 0f;
					float num7 = (this.b.BottomMargin != null) ? this.b.BottomMargin.Value : 0f;
					float num8 = num5;
					num8 += num6 + num7;
					if (num8 - this.g.a().BottomMargin > 0f)
					{
						A_0.Height -= num8 - this.g.a().BottomMargin;
					}
				}
			}
		}

		// Token: 0x06004246 RID: 16966 RVA: 0x00227B5C File Offset: 0x00226B5C
		private void a(Page A_0, bool A_1, bool A_2, HtmlArea A_3)
		{
			if (A_1 && A_2)
			{
				if (this.b.Left.a() != null && (this.b.Left.ShowOnFirstPage || this.b.Left.ShowOnLastPage))
				{
					this.a(A_0, this.b.Left.a(), A_3, false);
				}
				if (this.b.Right.a() != null && (this.b.Right.ShowOnFirstPage || this.b.Right.ShowOnLastPage))
				{
					this.a(A_0, this.b.Right.a(), A_3, false);
				}
				if (this.b.Center.a() != null && (this.b.Center.ShowOnFirstPage || this.b.Center.ShowOnLastPage))
				{
					this.a(A_0, this.b.Center.a(), A_3, false);
				}
			}
			else if (A_1 && !A_2)
			{
				if (this.b.Left.a() != null && this.b.Left.ShowOnFirstPage)
				{
					this.a(A_0, this.b.Left.a(), A_3, false);
				}
				if (this.b.Right.a() != null && this.b.Right.ShowOnFirstPage)
				{
					this.a(A_0, this.b.Right.a(), A_3, false);
				}
				if (this.b.Center.a() != null && this.b.Center.ShowOnFirstPage)
				{
					this.a(A_0, this.b.Center.a(), A_3, false);
				}
			}
			else if (!A_1 && A_2)
			{
				if (this.b.Left.a() != null && this.b.Left.ShowOnLastPage)
				{
					this.a(A_0, this.b.Left.a(), A_3, false);
				}
				if (this.b.Right.a() != null && this.b.Right.ShowOnLastPage)
				{
					this.a(A_0, this.b.Right.a(), A_3, false);
				}
				if (this.b.Center.a() != null && this.b.Center.ShowOnLastPage)
				{
					this.a(A_0, this.b.Center.a(), A_3, false);
				}
			}
			else
			{
				if (this.b.Left.a() != null)
				{
					this.a(A_0, this.b.Left.a(), A_3, false);
				}
				if (this.b.Right.a() != null)
				{
					this.a(A_0, this.b.Right.a(), A_3, false);
				}
				if (this.b.Center.a() != null)
				{
					this.a(A_0, this.b.Center.a(), A_3, false);
				}
			}
		}

		// Token: 0x06004247 RID: 16967 RVA: 0x00227F2C File Offset: 0x00226F2C
		private bool b(Page A_0, bool A_1, bool A_2)
		{
			bool result = false;
			if (this.a != null)
			{
				result = this.a(this.a.Left, A_0, A_1, A_2);
				if (this.a(this.a.Center, A_0, A_1, A_2))
				{
					result = true;
				}
				if (this.a(this.a.Right, A_0, A_1, A_2))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06004248 RID: 16968 RVA: 0x00227FA4 File Offset: 0x00226FA4
		private void a(Page A_0, bool A_1, bool A_2)
		{
			if (this.b != null)
			{
				this.a(this.b.Left, A_0, A_1, A_2);
				this.a(this.b.Center, A_0, A_1, A_2);
				this.a(this.b.Right, A_0, A_1, A_2);
			}
		}

		// Token: 0x06004249 RID: 16969 RVA: 0x00228000 File Offset: 0x00227000
		private bool a(HeaderFooterHtmlLayoutElement A_0, Page A_1, bool A_2, bool A_3)
		{
			bool result = false;
			if (A_0.a() != null)
			{
				if (A_2 && A_0.ShowOnFirstPage)
				{
					A_1.Elements.Add(A_0.a());
					result = true;
				}
				else if (A_3 && A_0.ShowOnLastPage)
				{
					A_1.Elements.Add(A_0.a());
					result = true;
				}
				else if (!A_2 && !A_3)
				{
					A_1.Elements.Add(A_0.a());
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600424A RID: 16970 RVA: 0x002280A0 File Offset: 0x002270A0
		private void a(Page A_0, HtmlArea A_1, HtmlArea A_2, bool A_3)
		{
			if (A_2.d() != null)
			{
				A_1.a(A_2.d().c());
			}
			float height = this.a(A_1, A_3, this.g.a());
			A_1.Height = height;
			A_0.Elements.Add(A_1);
		}

		// Token: 0x0600424B RID: 16971 RVA: 0x002280F8 File Offset: 0x002270F8
		private HtmlArea a(float A_0, float A_1, float A_2, float A_3)
		{
			HtmlArea result = null;
			if (this.e != null)
			{
				if (this.c != null)
				{
					result = new HtmlArea(this.c, A_0, A_1, this.e, A_2, A_3);
				}
				else if (this.d != null)
				{
					result = new HtmlArea(this.d, A_0, A_1, this.e, A_2, A_3);
				}
				else if (this.f != null)
				{
					result = new HtmlArea(this.f, A_0, A_1, this.e, A_2, A_3);
				}
			}
			else if (this.c != null)
			{
				result = new HtmlArea(this.c, A_0, A_1, A_2, A_3);
			}
			else if (this.d != null)
			{
				result = new HtmlArea(this.d, A_0, A_1, A_2, A_3);
			}
			else if (this.f != null)
			{
				result = new HtmlArea(this.f, A_0, A_1, A_2, A_3);
			}
			return result;
		}

		// Token: 0x0600424C RID: 16972 RVA: 0x00228210 File Offset: 0x00227210
		private void b(ij A_0)
		{
			float num = 0f;
			float num2 = (this.Header.LeftMargin != null) ? this.a.LeftMargin.Value : 0f;
			float num3 = (this.a.RightMargin != null) ? this.a.RightMargin.Value : 0f;
			float num4 = this.g.a().Width - num2 - num3;
			float a_ = -this.g.a().LeftMargin + num2;
			this.a(this.a.Left, a_, num4, A_0, gn.a, true, ref num);
			this.a(this.a.Right, a_, num4, A_0, gn.b, true, ref num);
			this.a(this.a.Center, a_, num4, A_0, gn.c, true, ref num);
			if (this.a.Center.a() != null)
			{
				if (this.a.Center.Width != null)
				{
					float x = (num4 - this.a.Center.Width.Value) / 2f;
					this.a.Center.a().X = x;
				}
			}
			if (this.a.Right.a() != null)
			{
				if (this.a.Right.Width != null)
				{
					float x = num4 - this.a.Right.Width.Value;
					this.a.Right.a().X = x;
				}
			}
			float num5 = (this.a.BottomPadding != null) ? this.a.BottomPadding.Value : 0f;
			float num6 = (this.a.TopMargin != null) ? this.a.TopMargin.Value : 0f;
			this.a.a(num + num6 + num5);
			this.b(this.a.Left, num6, num5);
			this.b(this.a.Right, num6, num5);
			this.b(this.a.Center, num6, num5);
		}

		// Token: 0x0600424D RID: 16973 RVA: 0x002284B0 File Offset: 0x002274B0
		private void a(HeaderFooterHtmlLayoutElement A_0, float A_1, float A_2, ij A_3, gn A_4, bool A_5, ref float A_6)
		{
			if (A_0.Text != null)
			{
				float width = (A_0.Width != null) ? A_0.Width.Value : A_2;
				float height = A_5 ? this.g.a().TopMargin : this.g.a().BottomMargin;
				HtmlArea htmlArea = new HtmlArea(A_0.Text, A_1, 0f, width, height);
				htmlArea.a(A_3);
				if (A_0.HasPageNumbers)
				{
					htmlArea.a(true);
				}
				htmlArea.a(A_4);
				float num = htmlArea.Height = this.a(htmlArea, A_5, this.g.a());
				if (num > A_6)
				{
					A_6 = num;
				}
				A_0.a(htmlArea);
			}
		}

		// Token: 0x0600424E RID: 16974 RVA: 0x0022859C File Offset: 0x0022759C
		private void b(HeaderFooterHtmlLayoutElement A_0, float A_1, float A_2)
		{
			if (A_0.Text != null)
			{
				if (this.a.TopMargin != null)
				{
					A_0.a().Y = -this.g.a().TopMargin + A_1;
				}
				else
				{
					A_0.a().Y = -this.g.a().TopMargin + (this.a.a() - A_0.a().Height - A_2);
				}
			}
		}

		// Token: 0x0600424F RID: 16975 RVA: 0x00228630 File Offset: 0x00227630
		private void a(HeaderFooterHtmlLayoutElement A_0, float A_1, float A_2)
		{
			if (A_0.Text != null)
			{
				if (this.b.BottomMargin != null)
				{
					A_0.a().Y = this.g.a().Edge.Height - this.b.BottomMargin.Value;
				}
				else if (this.g.a().BottomMargin - this.b.a() >= 0f)
				{
					A_0.a().Y = this.g.a().Body.Height + A_1;
				}
				else
				{
					A_0.a().Y = this.g.a().Body.Bottom - (this.b.a() - ((this.b.TopPadding != null) ? this.b.TopPadding.Value : 0f));
				}
			}
		}

		// Token: 0x06004250 RID: 16976 RVA: 0x00228758 File Offset: 0x00227758
		private void a(ij A_0)
		{
			float num = 0f;
			float num2 = (this.b.LeftMargin != null) ? this.b.LeftMargin.Value : 0f;
			float num3 = (this.b.RightMargin != null) ? this.b.RightMargin.Value : 0f;
			float num4 = this.g.a().Width - num2 - num3;
			float a_ = -this.g.a().LeftMargin + num2;
			this.a(this.b.Left, a_, num4, A_0, gn.a, false, ref num);
			this.a(this.b.Right, a_, num4, A_0, gn.b, false, ref num);
			this.a(this.b.Center, a_, num4, A_0, gn.c, false, ref num);
			if (this.b.Center.a() != null)
			{
				if (this.b.Center.Width != null)
				{
					float x = (num4 - this.b.Center.Width.Value) / 2f;
					this.b.Center.a().X = x;
				}
			}
			if (this.b.Right.a() != null)
			{
				if (this.b.Right.Width != null)
				{
					float x = num4 - this.b.Right.Width.Value;
					this.b.Right.a().X = x;
				}
			}
			float num5 = (this.b.TopPadding != null) ? this.b.TopPadding.Value : 0f;
			float num6 = (this.b.BottomMargin != null) ? this.b.BottomMargin.Value : 0f;
			this.b.a(num + num5 + num6);
			this.a(this.b.Left, num5, num6);
			this.a(this.b.Right, num5, num6);
			this.a(this.b.Center, num5, num6);
		}

		// Token: 0x06004251 RID: 16977 RVA: 0x002289F8 File Offset: 0x002279F8
		private float a(HtmlArea A_0, bool A_1, PageDimensions A_2)
		{
			bool flag = false;
			float num;
			if (A_1)
			{
				num = A_0.a(A_2.TopMargin, ref flag);
			}
			else
			{
				num = A_0.a(A_2.BottomMargin, ref flag);
			}
			float result;
			if (flag)
			{
				result = num;
			}
			else
			{
				float a_ = (A_2.Height - (A_2.TopMargin + A_2.BottomMargin)) * 30f / 100f;
				num = A_0.a(a_, ref flag);
				if (flag)
				{
					result = num;
				}
				else
				{
					if (A_1)
					{
						if (this.b != null)
						{
							return num;
						}
						a_ = (A_2.Height - (A_2.TopMargin + A_2.BottomMargin)) * 50f / 100f;
						num = A_0.a(a_, ref flag);
						if (flag)
						{
							return num;
						}
					}
					else if (this.a == null)
					{
						a_ = (A_2.Height - (A_2.TopMargin + A_2.BottomMargin)) * 50f / 100f;
						num = A_0.a(a_, ref flag);
						if (flag)
						{
							return num;
						}
					}
					result = num;
				}
			}
			return result;
		}

		// Token: 0x06004252 RID: 16978 RVA: 0x00228B44 File Offset: 0x00227B44
		private Uri a(Uri A_0)
		{
			Uri result;
			if (!A_0.IsAbsoluteUri)
			{
				string fullPath = Path.GetFullPath(A_0.OriginalString);
				result = new Uri(fullPath);
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x040024C3 RID: 9411
		private HeaderHtmlLayout a = null;

		// Token: 0x040024C4 RID: 9412
		private FooterHtmlLayout b = null;

		// Token: 0x040024C5 RID: 9413
		private string c;

		// Token: 0x040024C6 RID: 9414
		private Uri d;

		// Token: 0x040024C7 RID: 9415
		private Uri e;

		// Token: 0x040024C8 RID: 9416
		private Stream f = null;

		// Token: 0x040024C9 RID: 9417
		private PageInfo g;
	}
}
