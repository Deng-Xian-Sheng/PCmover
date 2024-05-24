﻿using System;
using System.Globalization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A85 RID: 2693
	[Serializable]
	internal class EUCJPEncoding : DBCSCodePageEncoding
	{
		// Token: 0x06006972 RID: 26994 RVA: 0x0016B121 File Offset: 0x00169321
		[SecurityCritical]
		public EUCJPEncoding() : base(51932, 932)
		{
			this.m_bUseMlangTypeForSerialization = true;
		}

		// Token: 0x06006973 RID: 26995 RVA: 0x0016B13C File Offset: 0x0016933C
		[SecurityCritical]
		protected unsafe override string GetMemorySectionName()
		{
			int num = this.bFlagDataTable ? this.dataTableCodePage : this.CodePage;
			return string.Format(CultureInfo.InvariantCulture, "CodePage_{0}_{1}_{2}_{3}_{4}_EUCJP", new object[]
			{
				num,
				this.pCodePage->VersionMajor,
				this.pCodePage->VersionMinor,
				this.pCodePage->VersionRevision,
				this.pCodePage->VersionBuild
			});
		}

		// Token: 0x06006974 RID: 26996 RVA: 0x0016B1CC File Offset: 0x001693CC
		protected override bool CleanUpBytes(ref int bytes)
		{
			if (bytes >= 256)
			{
				if (bytes >= 64064 && bytes <= 64587)
				{
					if (bytes >= 64064 && bytes <= 64091)
					{
						if (bytes <= 64073)
						{
							bytes -= 2897;
						}
						else if (bytes >= 64074 && bytes <= 64083)
						{
							bytes -= 29430;
						}
						else if (bytes >= 64084 && bytes <= 64087)
						{
							bytes -= 2907;
						}
						else if (bytes == 64088)
						{
							bytes = 34698;
						}
						else if (bytes == 64089)
						{
							bytes = 34690;
						}
						else if (bytes == 64090)
						{
							bytes = 34692;
						}
						else if (bytes == 64091)
						{
							bytes = 34714;
						}
					}
					else if (bytes >= 64092 && bytes <= 64587)
					{
						byte b = (byte)bytes;
						if (b < 92)
						{
							bytes -= 3423;
						}
						else if (b >= 128 && b <= 155)
						{
							bytes -= 3357;
						}
						else
						{
							bytes -= 3356;
						}
					}
				}
				byte b2 = (byte)(bytes >> 8);
				byte b3 = (byte)bytes;
				b2 -= ((b2 > 159) ? 177 : 113);
				b2 = (byte)(((int)b2 << 1) + 1);
				if (b3 > 158)
				{
					b3 -= 126;
					b2 += 1;
				}
				else
				{
					if (b3 > 126)
					{
						b3 -= 1;
					}
					b3 -= 31;
				}
				bytes = ((int)b2 << 8 | (int)b3 | 32896);
				if ((bytes & 65280) < 41216 || (bytes & 65280) > 65024 || (bytes & 255) < 161 || (bytes & 255) > 254)
				{
					return false;
				}
			}
			else
			{
				if (bytes >= 161 && bytes <= 223)
				{
					bytes |= 36352;
					return true;
				}
				if (bytes >= 129 && bytes != 160 && bytes != 255)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06006975 RID: 26997 RVA: 0x0016B3DC File Offset: 0x001695DC
		[SecurityCritical]
		protected unsafe override void CleanUpEndBytes(char* chars)
		{
			for (int i = 161; i <= 254; i++)
			{
				chars[i] = '￾';
			}
			chars[142] = '￾';
		}
	}
}
