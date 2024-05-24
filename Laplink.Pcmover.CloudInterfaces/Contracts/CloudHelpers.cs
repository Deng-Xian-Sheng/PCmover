using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000006 RID: 6
	public class CloudHelpers
	{
		// Token: 0x06000025 RID: 37
		[DllImport("secur32.dll", CharSet = CharSet.Auto)]
		public static extern byte GetUserNameEx(int nameFormat, StringBuilder userName, ref int userNameSize);

		// Token: 0x06000026 RID: 38 RVA: 0x00002050 File Offset: 0x00000250
		public static string GetUPN()
		{
			string result = null;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				int capacity = stringBuilder.Capacity;
				if (CloudHelpers.GetUserNameEx(8, stringBuilder, ref capacity) != 0)
				{
					result = stringBuilder.ToString();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0200000E RID: 14
		public enum EXTENDED_NAME_FORMAT
		{
			// Token: 0x04000019 RID: 25
			NameUnknown,
			// Token: 0x0400001A RID: 26
			NameFullyQualifiedDN,
			// Token: 0x0400001B RID: 27
			NameSamCompatible,
			// Token: 0x0400001C RID: 28
			NameDisplay,
			// Token: 0x0400001D RID: 29
			NameUniqueId = 6,
			// Token: 0x0400001E RID: 30
			NameCanonical,
			// Token: 0x0400001F RID: 31
			NameUserPrincipal,
			// Token: 0x04000020 RID: 32
			NameCanonicalEx,
			// Token: 0x04000021 RID: 33
			NameServicePrincipal,
			// Token: 0x04000022 RID: 34
			NameDnsDomain = 12
		}
	}
}
