using System;

namespace System.Text
{
	// Token: 0x02000A73 RID: 2675
	[Serializable]
	public sealed class EncodingInfo
	{
		// Token: 0x06006873 RID: 26739 RVA: 0x00160A26 File Offset: 0x0015EC26
		internal EncodingInfo(int codePage, string name, string displayName)
		{
			this.iCodePage = codePage;
			this.strEncodingName = name;
			this.strDisplayName = displayName;
		}

		// Token: 0x170011DC RID: 4572
		// (get) Token: 0x06006874 RID: 26740 RVA: 0x00160A43 File Offset: 0x0015EC43
		public int CodePage
		{
			get
			{
				return this.iCodePage;
			}
		}

		// Token: 0x170011DD RID: 4573
		// (get) Token: 0x06006875 RID: 26741 RVA: 0x00160A4B File Offset: 0x0015EC4B
		public string Name
		{
			get
			{
				return this.strEncodingName;
			}
		}

		// Token: 0x170011DE RID: 4574
		// (get) Token: 0x06006876 RID: 26742 RVA: 0x00160A53 File Offset: 0x0015EC53
		public string DisplayName
		{
			get
			{
				return this.strDisplayName;
			}
		}

		// Token: 0x06006877 RID: 26743 RVA: 0x00160A5B File Offset: 0x0015EC5B
		public Encoding GetEncoding()
		{
			return Encoding.GetEncoding(this.iCodePage);
		}

		// Token: 0x06006878 RID: 26744 RVA: 0x00160A68 File Offset: 0x0015EC68
		public override bool Equals(object value)
		{
			EncodingInfo encodingInfo = value as EncodingInfo;
			return encodingInfo != null && this.CodePage == encodingInfo.CodePage;
		}

		// Token: 0x06006879 RID: 26745 RVA: 0x00160A8F File Offset: 0x0015EC8F
		public override int GetHashCode()
		{
			return this.CodePage;
		}

		// Token: 0x04002EAE RID: 11950
		private int iCodePage;

		// Token: 0x04002EAF RID: 11951
		private string strEncodingName;

		// Token: 0x04002EB0 RID: 11952
		private string strDisplayName;
	}
}
