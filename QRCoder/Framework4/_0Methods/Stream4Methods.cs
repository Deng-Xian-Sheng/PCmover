using System;
using System.IO;

namespace QRCoder.Framework4._0Methods
{
	// Token: 0x0200001A RID: 26
	internal class Stream4Methods
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00006C10 File Offset: 0x00004E10
		public static void CopyTo(Stream input, Stream output)
		{
			byte[] array = new byte[16384];
			int count;
			while ((count = input.Read(array, 0, array.Length)) > 0)
			{
				output.Write(array, 0, count);
			}
		}
	}
}
