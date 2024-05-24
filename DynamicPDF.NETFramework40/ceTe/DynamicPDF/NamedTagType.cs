using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000660 RID: 1632
	public class NamedTagType : TagType
	{
		// Token: 0x06003DC7 RID: 15815 RVA: 0x00216B20 File Offset: 0x00215B20
		public NamedTagType(string customTagName, StandardTagType standardTagType)
		{
			this.a = customTagName;
			this.b = standardTagType;
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06003DC8 RID: 15816 RVA: 0x00216B48 File Offset: 0x00215B48
		public string Name
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06003DC9 RID: 15817 RVA: 0x00216B60 File Offset: 0x00215B60
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06003DCA RID: 15818 RVA: 0x00216B6C File Offset: 0x00215B6C
		public StandardTagType TagType
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06003DCB RID: 15819 RVA: 0x00216B84 File Offset: 0x00215B84
		public override string ToString()
		{
			return this.a;
		}

		// Token: 0x06003DCC RID: 15820 RVA: 0x00216B9C File Offset: 0x00215B9C
		internal override bool b3()
		{
			return true;
		}

		// Token: 0x04002161 RID: 8545
		private new string a = null;

		// Token: 0x04002162 RID: 8546
		private StandardTagType b = null;
	}
}
