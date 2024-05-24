using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B3 RID: 1715
	public class FooterHtmlLayout
	{
		// Token: 0x06004205 RID: 16901 RVA: 0x002269FC File Offset: 0x002259FC
		internal FooterHtmlLayout()
		{
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06004206 RID: 16902 RVA: 0x00226A54 File Offset: 0x00225A54
		public HeaderFooterHtmlLayoutElement Left
		{
			get
			{
				if (this.a == null)
				{
					this.a = new HeaderFooterHtmlLayoutElement();
				}
				return this.a;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06004207 RID: 16903 RVA: 0x00226A88 File Offset: 0x00225A88
		public HeaderFooterHtmlLayoutElement Right
		{
			get
			{
				if (this.b == null)
				{
					this.b = new HeaderFooterHtmlLayoutElement();
				}
				return this.b;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06004208 RID: 16904 RVA: 0x00226ABC File Offset: 0x00225ABC
		public HeaderFooterHtmlLayoutElement Center
		{
			get
			{
				if (this.c == null)
				{
					this.c = new HeaderFooterHtmlLayoutElement();
				}
				return this.c;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06004209 RID: 16905 RVA: 0x00226AF0 File Offset: 0x00225AF0
		// (set) Token: 0x0600420A RID: 16906 RVA: 0x00226B08 File Offset: 0x00225B08
		public float? TopPadding
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

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x0600420B RID: 16907 RVA: 0x00226B14 File Offset: 0x00225B14
		// (set) Token: 0x0600420C RID: 16908 RVA: 0x00226B2C File Offset: 0x00225B2C
		public float? RightMargin
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

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x0600420D RID: 16909 RVA: 0x00226B38 File Offset: 0x00225B38
		// (set) Token: 0x0600420E RID: 16910 RVA: 0x00226B50 File Offset: 0x00225B50
		public float? LeftMargin
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x0600420F RID: 16911 RVA: 0x00226B5C File Offset: 0x00225B5C
		// (set) Token: 0x06004210 RID: 16912 RVA: 0x00226B74 File Offset: 0x00225B74
		public float? BottomMargin
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x06004211 RID: 16913 RVA: 0x00226B80 File Offset: 0x00225B80
		internal float a()
		{
			return this.h;
		}

		// Token: 0x06004212 RID: 16914 RVA: 0x00226B98 File Offset: 0x00225B98
		internal void a(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06004213 RID: 16915 RVA: 0x00226BA4 File Offset: 0x00225BA4
		internal float? b()
		{
			float num = this.h;
			float? num2 = this.d;
			num2 = ((num2 != null) ? new float?(num + num2.GetValueOrDefault()) : null);
			float? num3 = this.f;
			return (num2 != null & num3 != null) ? new float?(num2.GetValueOrDefault() + num3.GetValueOrDefault()) : null;
		}

		// Token: 0x040024AD RID: 9389
		private HeaderFooterHtmlLayoutElement a;

		// Token: 0x040024AE RID: 9390
		private HeaderFooterHtmlLayoutElement b;

		// Token: 0x040024AF RID: 9391
		private HeaderFooterHtmlLayoutElement c;

		// Token: 0x040024B0 RID: 9392
		private float? d = new float?(18f);

		// Token: 0x040024B1 RID: 9393
		private float? e = null;

		// Token: 0x040024B2 RID: 9394
		private float? f = null;

		// Token: 0x040024B3 RID: 9395
		private float? g = null;

		// Token: 0x040024B4 RID: 9396
		private float h = 0f;
	}
}
