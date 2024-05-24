using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200074A RID: 1866
	public class UnorderedSubList : SubList
	{
		// Token: 0x06004BC5 RID: 19397 RVA: 0x00266145 File Offset: 0x00265145
		internal UnorderedSubList(float A_0, float A_1, Font A_2, float A_3, UnorderedListStyle A_4, bool A_5) : base(A_0, A_1, A_2, A_3, A_5)
		{
			this.a = A_4;
			base.a(new UnorderedListItemList(this));
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06004BC7 RID: 19399 RVA: 0x00266178 File Offset: 0x00265178
		// (set) Token: 0x06004BC6 RID: 19398 RVA: 0x0026616C File Offset: 0x0026516C
		public UnorderedListStyle BulletStyle
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

		// Token: 0x040028F3 RID: 10483
		private new UnorderedListStyle a;
	}
}
