using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200071D RID: 1821
	public class Bookmark : PageElement, ICoordinate
	{
		// Token: 0x06004862 RID: 18530 RVA: 0x0025629C File Offset: 0x0025529C
		public Bookmark(string text, float x, float y) : this(text, x, y, null)
		{
		}

		// Token: 0x06004863 RID: 18531 RVA: 0x002562AC File Offset: 0x002552AC
		public Bookmark(string text, float x, float y, Outline parentOutline)
		{
			this.b = text;
			this.c = x;
			this.d = x5.a(y);
			this.a = parentOutline;
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06004864 RID: 18532 RVA: 0x002562FC File Offset: 0x002552FC
		// (set) Token: 0x06004865 RID: 18533 RVA: 0x00256314 File Offset: 0x00255314
		public string Text
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

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06004866 RID: 18534 RVA: 0x00256320 File Offset: 0x00255320
		// (set) Token: 0x06004867 RID: 18535 RVA: 0x00256338 File Offset: 0x00255338
		public float X
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

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06004868 RID: 18536 RVA: 0x00256344 File Offset: 0x00255344
		// (set) Token: 0x06004869 RID: 18537 RVA: 0x00256362 File Offset: 0x00255362
		public float Y
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x0600486A RID: 18538 RVA: 0x00256374 File Offset: 0x00255374
		// (set) Token: 0x0600486B RID: 18539 RVA: 0x0025638C File Offset: 0x0025538C
		public TextStyle Style
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

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x0600486C RID: 18540 RVA: 0x00256398 File Offset: 0x00255398
		// (set) Token: 0x0600486D RID: 18541 RVA: 0x002563B0 File Offset: 0x002553B0
		public Outline ParentOutline
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

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x0600486E RID: 18542 RVA: 0x002563BC File Offset: 0x002553BC
		// (set) Token: 0x0600486F RID: 18543 RVA: 0x002563D4 File Offset: 0x002553D4
		public RgbColor Color
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

		// Token: 0x06004870 RID: 18544 RVA: 0x002563E0 File Offset: 0x002553E0
		public override void Draw(PageWriter writer)
		{
			float x = writer.Dimensions.aw(this.c) - writer.Page.Dimensions.LeftMargin;
			float y = writer.Page.Dimensions.Edge.Bottom - writer.Dimensions.ax(x5.b(this.d)) - writer.Page.Dimensions.Body.Top;
			Outline outline;
			if (this.a == null)
			{
				outline = writer.Document.Outlines.Add(this.b, new XYDestination(writer.PageNumber, x, y));
			}
			else
			{
				outline = this.a.ChildOutlines.Add(this.b, new XYDestination(writer.PageNumber, x, y));
			}
			outline.Color = this.f;
			outline.Style = this.e;
		}

		// Token: 0x06004871 RID: 18545 RVA: 0x002564D0 File Offset: 0x002554D0
		internal override x5 b7()
		{
			return this.d;
		}

		// Token: 0x06004872 RID: 18546 RVA: 0x002564E8 File Offset: 0x002554E8
		internal override x5 b8()
		{
			return this.d;
		}

		// Token: 0x04002799 RID: 10137
		private new Outline a = null;

		// Token: 0x0400279A RID: 10138
		private string b;

		// Token: 0x0400279B RID: 10139
		private float c;

		// Token: 0x0400279C RID: 10140
		private new x5 d;

		// Token: 0x0400279D RID: 10141
		private TextStyle e = TextStyle.Regular;

		// Token: 0x0400279E RID: 10142
		private RgbColor f = null;
	}
}
