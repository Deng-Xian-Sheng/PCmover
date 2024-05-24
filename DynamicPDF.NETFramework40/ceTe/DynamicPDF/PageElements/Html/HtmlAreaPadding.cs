using System;

namespace ceTe.DynamicPDF.PageElements.Html
{
	// Token: 0x020007F7 RID: 2039
	public class HtmlAreaPadding
	{
		// Token: 0x060052E1 RID: 21217 RVA: 0x002902C0 File Offset: 0x0028F2C0
		public HtmlAreaPadding(float padding)
		{
			this.a = padding;
			this.b = padding;
			this.c = padding;
			this.d = padding;
		}

		// Token: 0x060052E2 RID: 21218 RVA: 0x00290320 File Offset: 0x0028F320
		public HtmlAreaPadding(float top, float right, float bottom, float left)
		{
			this.a = top;
			this.b = right;
			this.c = bottom;
			this.d = left;
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x060052E3 RID: 21219 RVA: 0x00290380 File Offset: 0x0028F380
		// (set) Token: 0x060052E4 RID: 21220 RVA: 0x00290398 File Offset: 0x0028F398
		public float Top
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

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x060052E5 RID: 21221 RVA: 0x002903A4 File Offset: 0x0028F3A4
		// (set) Token: 0x060052E6 RID: 21222 RVA: 0x002903BC File Offset: 0x0028F3BC
		public float Right
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

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x060052E7 RID: 21223 RVA: 0x002903C8 File Offset: 0x0028F3C8
		// (set) Token: 0x060052E8 RID: 21224 RVA: 0x002903E0 File Offset: 0x0028F3E0
		public float Bottom
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

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x060052E9 RID: 21225 RVA: 0x002903EC File Offset: 0x0028F3EC
		// (set) Token: 0x060052EA RID: 21226 RVA: 0x00290404 File Offset: 0x0028F404
		public float Left
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

		// Token: 0x04002C47 RID: 11335
		private float a = 0f;

		// Token: 0x04002C48 RID: 11336
		private float b = 0f;

		// Token: 0x04002C49 RID: 11337
		private float c = 0f;

		// Token: 0x04002C4A RID: 11338
		private float d = 0f;
	}
}
