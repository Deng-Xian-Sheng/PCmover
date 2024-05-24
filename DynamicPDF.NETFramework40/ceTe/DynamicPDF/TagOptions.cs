using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000666 RID: 1638
	public class TagOptions
	{
		// Token: 0x06003DDD RID: 15837 RVA: 0x00216DC5 File Offset: 0x00215DC5
		public TagOptions()
		{
		}

		// Token: 0x06003DDE RID: 15838 RVA: 0x00216DD7 File Offset: 0x00215DD7
		public TagOptions(bool layoutAttributes)
		{
			this.a = layoutAttributes;
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06003DDF RID: 15839 RVA: 0x00216DF0 File Offset: 0x00215DF0
		// (set) Token: 0x06003DE0 RID: 15840 RVA: 0x00216E08 File Offset: 0x00215E08
		public bool IncludeLayoutAttributes
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

		// Token: 0x0400216C RID: 8556
		private bool a = false;
	}
}
