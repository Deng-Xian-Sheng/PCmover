using System;
using ceTe.DynamicPDF.PageElements.Html;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B4 RID: 1716
	public class HeaderFooterHtmlLayoutElement
	{
		// Token: 0x06004214 RID: 16916 RVA: 0x00226C24 File Offset: 0x00225C24
		internal HeaderFooterHtmlLayoutElement()
		{
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06004215 RID: 16917 RVA: 0x00226C44 File Offset: 0x00225C44
		// (set) Token: 0x06004216 RID: 16918 RVA: 0x00226C5C File Offset: 0x00225C5C
		public string Text
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06004217 RID: 16919 RVA: 0x00226C68 File Offset: 0x00225C68
		// (set) Token: 0x06004218 RID: 16920 RVA: 0x00226C80 File Offset: 0x00225C80
		public bool ShowOnFirstPage
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06004219 RID: 16921 RVA: 0x00226C8C File Offset: 0x00225C8C
		// (set) Token: 0x0600421A RID: 16922 RVA: 0x00226CA4 File Offset: 0x00225CA4
		public bool ShowOnLastPage
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x0600421B RID: 16923 RVA: 0x00226CB0 File Offset: 0x00225CB0
		// (set) Token: 0x0600421C RID: 16924 RVA: 0x00226CC8 File Offset: 0x00225CC8
		public bool HasPageNumbers
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x0600421D RID: 16925 RVA: 0x00226CD4 File Offset: 0x00225CD4
		// (set) Token: 0x0600421E RID: 16926 RVA: 0x00226CEC File Offset: 0x00225CEC
		public float? Width
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

		// Token: 0x0600421F RID: 16927 RVA: 0x00226CF8 File Offset: 0x00225CF8
		internal HtmlArea a()
		{
			return this.f;
		}

		// Token: 0x06004220 RID: 16928 RVA: 0x00226D10 File Offset: 0x00225D10
		internal void a(HtmlArea A_0)
		{
			this.f = A_0;
		}

		// Token: 0x040024B5 RID: 9397
		private string a;

		// Token: 0x040024B6 RID: 9398
		private bool b = true;

		// Token: 0x040024B7 RID: 9399
		private bool c = true;

		// Token: 0x040024B8 RID: 9400
		private bool d;

		// Token: 0x040024B9 RID: 9401
		private float? e;

		// Token: 0x040024BA RID: 9402
		private HtmlArea f = null;
	}
}
