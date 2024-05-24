using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200073B RID: 1851
	public class OrderedSubList : SubList, IListProperties
	{
		// Token: 0x06004AA9 RID: 19113 RVA: 0x00260468 File Offset: 0x0025F468
		internal OrderedSubList(float A_0, float A_1, Font A_2, float A_3, NumberingStyle A_4, bool A_5) : base(A_0, A_1, A_2, A_3, A_5)
		{
			this.a = A_4;
			base.a(new OrderedListItemList(this));
		}

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06004AAB RID: 19115 RVA: 0x002604C4 File Offset: 0x0025F4C4
		// (set) Token: 0x06004AAA RID: 19114 RVA: 0x002604B7 File Offset: 0x0025F4B7
		public string BulletPrefix
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

		// Token: 0x06004AAC RID: 19116 RVA: 0x002604DC File Offset: 0x0025F4DC
		string IListProperties.a()
		{
			return this.c;
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06004AAE RID: 19118 RVA: 0x00260500 File Offset: 0x0025F500
		// (set) Token: 0x06004AAD RID: 19117 RVA: 0x002604F4 File Offset: 0x0025F4F4
		public string BulletSuffix
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

		// Token: 0x06004AAF RID: 19119 RVA: 0x00260518 File Offset: 0x0025F518
		string IListProperties.b()
		{
			return this.b;
		}

		// Token: 0x06004AB0 RID: 19120 RVA: 0x00260530 File Offset: 0x0025F530
		internal NumberingStyle c()
		{
			return this.a;
		}

		// Token: 0x06004AB1 RID: 19121 RVA: 0x00260548 File Offset: 0x0025F548
		NumberingStyle IListProperties.d()
		{
			return this.a;
		}

		// Token: 0x04002884 RID: 10372
		private new NumberingStyle a = NumberingStyle.Numeric;

		// Token: 0x04002885 RID: 10373
		private string b = ".";

		// Token: 0x04002886 RID: 10374
		private string c = "";
	}
}
