using System;
using System.IO;

namespace Laplink.Tools.Helpers
{
	// Token: 0x0200000C RID: 12
	public static class StreamExtensions
	{
		// Token: 0x06000067 RID: 103 RVA: 0x000034A0 File Offset: 0x000016A0
		public static byte[] ReadIntoByteArray(this Stream s)
		{
			if (s == null)
			{
				return null;
			}
			byte[] array = new byte[1024];
			byte[] array2 = null;
			int num = 0;
			int num2;
			do
			{
				num2 = s.Read(array, 0, 1024);
				if (num2 != 0)
				{
					byte[] array3 = new byte[num + num2];
					if (num > 0)
					{
						Array.Copy(array2, array3, num);
					}
					Array.Copy(array, 0, array3, num, num2);
					num += num2;
					array2 = array3;
				}
			}
			while (num2 > 0);
			return array2;
		}

		// Token: 0x0400002B RID: 43
		private const int BUFLEN = 1024;
	}
}
