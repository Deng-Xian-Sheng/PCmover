using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000699 RID: 1689
	public class PageDimensions : AreaDimensions
	{
		// Token: 0x06004009 RID: 16393 RVA: 0x002206A7 File Offset: 0x0021F6A7
		public PageDimensions(float width, float height) : this(PageDimensions.a(width, height), 50f)
		{
		}

		// Token: 0x0600400A RID: 16394 RVA: 0x002206BE File Offset: 0x0021F6BE
		public PageDimensions(float width, float height, float margins) : this(PageDimensions.a(width, height), margins)
		{
		}

		// Token: 0x0600400B RID: 16395 RVA: 0x002206D1 File Offset: 0x0021F6D1
		public PageDimensions(PageSize size) : this(PageDimensions.a(size, PageOrientation.Portrait), 50f)
		{
		}

		// Token: 0x0600400C RID: 16396 RVA: 0x002206E8 File Offset: 0x0021F6E8
		public PageDimensions(PageSize size, PageOrientation orientation) : this(PageDimensions.a(size, orientation), 50f)
		{
		}

		// Token: 0x0600400D RID: 16397 RVA: 0x002206FF File Offset: 0x0021F6FF
		public PageDimensions(PageSize size, float margins) : this(PageDimensions.a(size, PageOrientation.Portrait), margins)
		{
		}

		// Token: 0x0600400E RID: 16398 RVA: 0x00220712 File Offset: 0x0021F712
		public PageDimensions(PageSize size, PageOrientation orientation, float margins) : this(PageDimensions.a(size, orientation), margins)
		{
		}

		// Token: 0x0600400F RID: 16399 RVA: 0x00220725 File Offset: 0x0021F725
		public PageDimensions(Dimensions edgeDimensions) : this(edgeDimensions, 50f)
		{
		}

		// Token: 0x06004010 RID: 16400 RVA: 0x00220736 File Offset: 0x0021F736
		public PageDimensions(Dimensions edgeDimensions, float margins) : base(edgeDimensions, new Dimensions(edgeDimensions, margins))
		{
		}

		// Token: 0x06004011 RID: 16401 RVA: 0x00220749 File Offset: 0x0021F749
		public PageDimensions(Dimensions edgeDimensions, Dimensions marginDimensions) : base(edgeDimensions, marginDimensions)
		{
		}

		// Token: 0x06004012 RID: 16402 RVA: 0x00220758 File Offset: 0x0021F758
		internal override float az()
		{
			return 1f;
		}

		// Token: 0x06004013 RID: 16403 RVA: 0x00220770 File Offset: 0x0021F770
		internal override float a0()
		{
			return 1f;
		}

		// Token: 0x06004014 RID: 16404 RVA: 0x00220788 File Offset: 0x0021F788
		public virtual void Draw(DocumentWriter writer)
		{
			if (base.Edge.Left != 0f || base.Edge.Top != 0f)
			{
				throw new GeneratorException("Left and top edge of page must be 0. Use ExtendedPageDimensions if this is required.");
			}
			writer.WriteName(PageDimensions.c);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber(base.Edge.Right);
			writer.WriteNumber(base.Edge.Bottom);
			writer.WriteArrayClose();
			if (!base.Body.Equals(base.Edge))
			{
				writer.WriteName(PageDimensions.d);
				writer.WriteArrayOpen();
				writer.WriteNumber(base.Body.Left);
				writer.WriteNumber(base.Body.Top);
				writer.WriteNumber(base.Body.Right);
				writer.WriteNumber(base.Body.Bottom);
				writer.WriteArrayClose();
			}
		}

		// Token: 0x06004015 RID: 16405 RVA: 0x00220894 File Offset: 0x0021F894
		public override float GetPdfY(float y)
		{
			return base.Edge.Bottom - base.Body.Top - y;
		}

		// Token: 0x06004016 RID: 16406 RVA: 0x002208BF File Offset: 0x0021F8BF
		public void SetMargins(float margins)
		{
			base.LeftMargin = margins;
			base.TopMargin = margins;
			base.RightMargin = margins;
			base.BottomMargin = margins;
		}

		// Token: 0x06004017 RID: 16407 RVA: 0x002208E2 File Offset: 0x0021F8E2
		public void SetMargins(float leftAndRight, float topAndBottom)
		{
			base.LeftMargin = leftAndRight;
			base.TopMargin = topAndBottom;
			base.RightMargin = leftAndRight;
			base.BottomMargin = topAndBottom;
		}

		// Token: 0x06004018 RID: 16408 RVA: 0x00220905 File Offset: 0x0021F905
		public void SetMargins(float leftMargin, float topMargin, float rightMargin, float bottomMargin)
		{
			base.LeftMargin = leftMargin;
			base.TopMargin = topMargin;
			base.RightMargin = rightMargin;
			base.BottomMargin = bottomMargin;
		}

		// Token: 0x06004019 RID: 16409 RVA: 0x0022092C File Offset: 0x0021F92C
		internal override float aw(float A_0)
		{
			return this.GetPdfX(A_0);
		}

		// Token: 0x0600401A RID: 16410 RVA: 0x00220948 File Offset: 0x0021F948
		internal override float ax(float A_0)
		{
			return this.GetPdfY(A_0);
		}

		// Token: 0x0600401B RID: 16411 RVA: 0x00220964 File Offset: 0x0021F964
		internal override float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			return this.aw(A_1) - A_0.LeftMargin;
		}

		// Token: 0x0600401C RID: 16412 RVA: 0x00220984 File Offset: 0x0021F984
		internal override float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			return A_0.Height - A_0.TopMargin - this.ax(A_2);
		}

		// Token: 0x0600401D RID: 16413 RVA: 0x002209AB File Offset: 0x0021F9AB
		internal override AreaDimensions ay()
		{
			throw new GeneratorException("PageDimensions do not have a Parent.");
		}

		// Token: 0x0600401E RID: 16414 RVA: 0x002209B8 File Offset: 0x0021F9B8
		internal override void a1(OperatorWriter A_0)
		{
		}

		// Token: 0x0600401F RID: 16415 RVA: 0x002209BB File Offset: 0x0021F9BB
		internal override void a2(OperatorWriter A_0)
		{
		}

		// Token: 0x06004020 RID: 16416 RVA: 0x002209C0 File Offset: 0x0021F9C0
		private static Dimensions a(PageSize A_0, PageOrientation A_1)
		{
			return new Dimensions(A_0, A_1);
		}

		// Token: 0x06004021 RID: 16417 RVA: 0x002209DC File Offset: 0x0021F9DC
		private static Dimensions a(float A_0, float A_1)
		{
			return new Dimensions(A_0, A_1);
		}

		// Token: 0x04002391 RID: 9105
		private const float a = 50f;

		// Token: 0x04002392 RID: 9106
		private const PageOrientation b = PageOrientation.Portrait;

		// Token: 0x04002393 RID: 9107
		private static byte[] c = new byte[]
		{
			77,
			101,
			100,
			105,
			97,
			66,
			111,
			120
		};

		// Token: 0x04002394 RID: 9108
		private static byte[] d = new byte[]
		{
			65,
			114,
			116,
			66,
			111,
			120
		};
	}
}
