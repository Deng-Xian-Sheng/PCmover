using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B5 RID: 1717
	public class HeaderHtmlLayout
	{
		// Token: 0x06004221 RID: 16929 RVA: 0x00226D1C File Offset: 0x00225D1C
		internal HeaderHtmlLayout()
		{
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06004222 RID: 16930 RVA: 0x00226D74 File Offset: 0x00225D74
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

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06004223 RID: 16931 RVA: 0x00226DA8 File Offset: 0x00225DA8
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

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06004224 RID: 16932 RVA: 0x00226DDC File Offset: 0x00225DDC
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

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06004225 RID: 16933 RVA: 0x00226E10 File Offset: 0x00225E10
		// (set) Token: 0x06004226 RID: 16934 RVA: 0x00226E28 File Offset: 0x00225E28
		public float? TopMargin
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

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06004227 RID: 16935 RVA: 0x00226E34 File Offset: 0x00225E34
		// (set) Token: 0x06004228 RID: 16936 RVA: 0x00226E4C File Offset: 0x00225E4C
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

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06004229 RID: 16937 RVA: 0x00226E58 File Offset: 0x00225E58
		// (set) Token: 0x0600422A RID: 16938 RVA: 0x00226E70 File Offset: 0x00225E70
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

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600422B RID: 16939 RVA: 0x00226E7C File Offset: 0x00225E7C
		// (set) Token: 0x0600422C RID: 16940 RVA: 0x00226E94 File Offset: 0x00225E94
		public float? BottomPadding
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

		// Token: 0x0600422D RID: 16941 RVA: 0x00226EA0 File Offset: 0x00225EA0
		internal float a()
		{
			return this.h;
		}

		// Token: 0x0600422E RID: 16942 RVA: 0x00226EB8 File Offset: 0x00225EB8
		internal void a(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x0600422F RID: 16943 RVA: 0x00226EC4 File Offset: 0x00225EC4
		internal float? b()
		{
			float num = this.h;
			float? num2 = this.d;
			num2 = ((num2 != null) ? new float?(num + num2.GetValueOrDefault()) : null);
			float? num3 = this.f;
			return (num2 != null & num3 != null) ? new float?(num2.GetValueOrDefault() + num3.GetValueOrDefault()) : null;
		}

		// Token: 0x040024BB RID: 9403
		private HeaderFooterHtmlLayoutElement a;

		// Token: 0x040024BC RID: 9404
		private HeaderFooterHtmlLayoutElement b;

		// Token: 0x040024BD RID: 9405
		private HeaderFooterHtmlLayoutElement c;

		// Token: 0x040024BE RID: 9406
		private float? d = null;

		// Token: 0x040024BF RID: 9407
		private float? e = null;

		// Token: 0x040024C0 RID: 9408
		private float? f = new float?(18f);

		// Token: 0x040024C1 RID: 9409
		private float? g = null;

		// Token: 0x040024C2 RID: 9410
		private float h = 0f;
	}
}
