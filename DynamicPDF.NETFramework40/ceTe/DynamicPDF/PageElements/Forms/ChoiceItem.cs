using System;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E2 RID: 2018
	public class ChoiceItem
	{
		// Token: 0x060051B9 RID: 20921 RVA: 0x0028B129 File Offset: 0x0028A129
		internal ChoiceItem(string A_0, string A_1, bool A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x060051BA RID: 20922 RVA: 0x0028B150 File Offset: 0x0028A150
		public string ItemName
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x060051BB RID: 20923 RVA: 0x0028B168 File Offset: 0x0028A168
		// (set) Token: 0x060051BC RID: 20924 RVA: 0x0028B180 File Offset: 0x0028A180
		public string ExportValue
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

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x060051BD RID: 20925 RVA: 0x0028B18C File Offset: 0x0028A18C
		// (set) Token: 0x060051BE RID: 20926 RVA: 0x0028B1A4 File Offset: 0x0028A1A4
		public bool Selected
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

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x060051BF RID: 20927 RVA: 0x0028B1B0 File Offset: 0x0028A1B0
		public bool Default
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x04002BBE RID: 11198
		private string a;

		// Token: 0x04002BBF RID: 11199
		private string b;

		// Token: 0x04002BC0 RID: 11200
		private bool c = false;
	}
}
