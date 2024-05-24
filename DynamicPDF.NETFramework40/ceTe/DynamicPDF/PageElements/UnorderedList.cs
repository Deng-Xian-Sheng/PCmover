using System;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000747 RID: 1863
	public class UnorderedList : List
	{
		// Token: 0x06004BB4 RID: 19380 RVA: 0x00265544 File Offset: 0x00264544
		public UnorderedList(float x, float y, float width, float height) : base(x, y, width, height)
		{
			this.a = new UnorderedSubList(width, height, Font.Helvetica, 12f, this.e, this.d);
			base.a(this.a);
		}

		// Token: 0x06004BB5 RID: 19381 RVA: 0x002655B0 File Offset: 0x002645B0
		internal UnorderedList(float A_0, float A_1, float A_2, float A_3, ae7 A_4, UnorderedSubList A_5) : base(A_0, A_1, A_2, A_3)
		{
			this.a = A_5;
			base.a(this.a);
			this.c = A_4;
			base.a(A_4);
		}

		// Token: 0x06004BB6 RID: 19382 RVA: 0x00265614 File Offset: 0x00264614
		public UnorderedList(float x, float y, float width, float height, Font font, float fontSize, UnorderedListStyle bullet) : base(x, y, width, height)
		{
			this.e = bullet;
			this.a = new UnorderedSubList(width, height, font, fontSize, this.e, this.d);
			base.a(this.a);
		}

		// Token: 0x06004BB7 RID: 19383 RVA: 0x00265684 File Offset: 0x00264684
		public UnorderedList(float x, float y, float width, float height, Font font, float fontSize) : base(x, y, width, height)
		{
			this.a = new UnorderedSubList(width, height, font, fontSize, this.e, this.d);
			base.a(this.a);
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06004BB9 RID: 19385 RVA: 0x002656FC File Offset: 0x002646FC
		// (set) Token: 0x06004BB8 RID: 19384 RVA: 0x002656EA File Offset: 0x002646EA
		public UnorderedListStyle BulletStyle
		{
			get
			{
				return this.a.BulletStyle;
			}
			set
			{
				this.a.BulletStyle = value;
			}
		}

		// Token: 0x06004BBA RID: 19386 RVA: 0x0026571C File Offset: 0x0026471C
		public float GetRequiredHeight()
		{
			ListItem listItem = this.a.aa();
			listItem.a(true);
			float num = this.a.a(this.c);
			if (this.c != null)
			{
				this.c.d();
			}
			return num + 0.001f;
		}

		// Token: 0x06004BBB RID: 19387 RVA: 0x00265774 File Offset: 0x00264774
		public UnorderedList GetOverFlowList()
		{
			return this.GetOverFlowList(base.X, base.Y);
		}

		// Token: 0x06004BBC RID: 19388 RVA: 0x00265798 File Offset: 0x00264798
		public UnorderedList GetOverFlowList(float x, float y)
		{
			UnorderedList result;
			if (this.a.Items.Count > 0)
			{
				ListItem listItem = this.a.Items[0];
				if (listItem.aa() >= 1)
				{
					this.b = new ae7();
					this.a.c(this.Height);
					this.a.a(this.c, this.b, this.Height);
					this.b = this.a.ab();
					if (this.c != null)
					{
						this.c.d();
					}
					this.b.d();
					if (this.b.a() >= 1)
					{
						UnorderedList unorderedList = new UnorderedList(x, y, base.Width, this.Height, this.b, this.a);
						unorderedList.a(base.a());
						result = unorderedList;
					}
					else
					{
						result = null;
					}
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040028DD RID: 10461
		private new UnorderedSubList a;

		// Token: 0x040028DE RID: 10462
		private ae7 b = null;

		// Token: 0x040028DF RID: 10463
		private ae7 c = null;

		// Token: 0x040028E0 RID: 10464
		private new bool d = false;

		// Token: 0x040028E1 RID: 10465
		private UnorderedListStyle e = UnorderedListStyle.Disc;
	}
}
