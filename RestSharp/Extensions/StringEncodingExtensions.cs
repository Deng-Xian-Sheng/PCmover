using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestSharp.Extensions
{
	// Token: 0x0200004D RID: 77
	[NullableContext(1)]
	[Nullable(0)]
	public static class StringEncodingExtensions
	{
		// Token: 0x060004DB RID: 1243 RVA: 0x0000C048 File Offset: 0x0000A248
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static string AsString(this byte[] buffer, [Nullable(2)] string encoding)
		{
			StringEncodingExtensions.<>c__DisplayClass0_0 CS$<>8__locals1;
			CS$<>8__locals1.encoding = encoding;
			Encoding encoding2 = CS$<>8__locals1.encoding.IsEmpty() ? Encoding.UTF8 : StringEncodingExtensions.<AsString>g__TryParseEncoding|0_0(ref CS$<>8__locals1);
			return StringEncodingExtensions.AsString(buffer, encoding2);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000C080 File Offset: 0x0000A280
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static string AsString(this byte[] buffer)
		{
			return StringEncodingExtensions.AsString(buffer, Encoding.UTF8);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000C08D File Offset: 0x0000A28D
		private static string AsString(byte[] buffer, Encoding encoding)
		{
			if (buffer != null)
			{
				return encoding.GetString(buffer, 0, buffer.Length);
			}
			return "";
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0000C0A4 File Offset: 0x0000A2A4
		[CompilerGenerated]
		internal static Encoding <AsString>g__TryParseEncoding|0_0(ref StringEncodingExtensions.<>c__DisplayClass0_0 A_0)
		{
			Encoding result;
			try
			{
				result = (Encoding.GetEncoding(A_0.encoding) ?? Encoding.UTF8);
			}
			catch (ArgumentException)
			{
				result = Encoding.UTF8;
			}
			return result;
		}
	}
}
