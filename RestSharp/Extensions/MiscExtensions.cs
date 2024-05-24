using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace RestSharp.Extensions
{
	// Token: 0x02000047 RID: 71
	[NullableContext(1)]
	[Nullable(0)]
	public static class MiscExtensions
	{
		// Token: 0x060004CD RID: 1229 RVA: 0x0000BA78 File Offset: 0x00009C78
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static void SaveAs(this byte[] input, string path)
		{
			File.WriteAllBytes(path, input);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000BA84 File Offset: 0x00009C84
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static byte[] ReadAsBytes(this Stream input)
		{
			byte[] array = new byte[16384];
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int count;
				while ((count = input.Read(array, 0, array.Length)) > 0)
				{
					memoryStream.Write(array, 0, count);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000BAE4 File Offset: 0x00009CE4
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static void CopyTo(this Stream input, Stream output)
		{
			byte[] array = new byte[32768];
			for (;;)
			{
				int num = input.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				output.Write(array, 0, num);
			}
		}
	}
}
