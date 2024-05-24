using System;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003B6 RID: 950
	[Serializable]
	internal class CodePageDataItem
	{
		// Token: 0x06002F44 RID: 12100 RVA: 0x000B5900 File Offset: 0x000B3B00
		[SecurityCritical]
		internal unsafe CodePageDataItem(int dataIndex)
		{
			this.m_dataIndex = dataIndex;
			this.m_uiFamilyCodePage = (int)EncodingTable.codePageDataPtr[dataIndex].uiFamilyCodePage;
			this.m_flags = EncodingTable.codePageDataPtr[dataIndex].flags;
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x000B5950 File Offset: 0x000B3B50
		[SecurityCritical]
		internal unsafe static string CreateString(sbyte* pStrings, uint index)
		{
			if (*pStrings == 124)
			{
				int num = 1;
				int num2 = 1;
				for (;;)
				{
					sbyte b = pStrings[num2];
					if (b == 124 || b == 0)
					{
						if (index == 0U)
						{
							break;
						}
						index -= 1U;
						num = num2 + 1;
						if (b == 0)
						{
							goto IL_37;
						}
					}
					num2++;
				}
				return new string(pStrings, num, num2 - num);
				IL_37:
				throw new ArgumentException("pStrings");
			}
			return new string(pStrings);
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06002F46 RID: 12102 RVA: 0x000B59A5 File Offset: 0x000B3BA5
		public unsafe string WebName
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_webName == null)
				{
					this.m_webName = CodePageDataItem.CreateString(EncodingTable.codePageDataPtr[this.m_dataIndex].Names, 0U);
				}
				return this.m_webName;
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06002F47 RID: 12103 RVA: 0x000B59DA File Offset: 0x000B3BDA
		public virtual int UIFamilyCodePage
		{
			get
			{
				return this.m_uiFamilyCodePage;
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06002F48 RID: 12104 RVA: 0x000B59E2 File Offset: 0x000B3BE2
		public unsafe string HeaderName
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_headerName == null)
				{
					this.m_headerName = CodePageDataItem.CreateString(EncodingTable.codePageDataPtr[this.m_dataIndex].Names, 1U);
				}
				return this.m_headerName;
			}
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06002F49 RID: 12105 RVA: 0x000B5A17 File Offset: 0x000B3C17
		public unsafe string BodyName
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_bodyName == null)
				{
					this.m_bodyName = CodePageDataItem.CreateString(EncodingTable.codePageDataPtr[this.m_dataIndex].Names, 2U);
				}
				return this.m_bodyName;
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06002F4A RID: 12106 RVA: 0x000B5A4C File Offset: 0x000B3C4C
		public uint Flags
		{
			get
			{
				return this.m_flags;
			}
		}

		// Token: 0x04001408 RID: 5128
		internal int m_dataIndex;

		// Token: 0x04001409 RID: 5129
		internal int m_uiFamilyCodePage;

		// Token: 0x0400140A RID: 5130
		internal string m_webName;

		// Token: 0x0400140B RID: 5131
		internal string m_headerName;

		// Token: 0x0400140C RID: 5132
		internal string m_bodyName;

		// Token: 0x0400140D RID: 5133
		internal uint m_flags;
	}
}
