using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestSharp.Extensions
{
	// Token: 0x0200004C RID: 76
	[NullableContext(1)]
	[Nullable(0)]
	internal static class StreamExtensions
	{
		// Token: 0x060004D9 RID: 1241 RVA: 0x0000C004 File Offset: 0x0000A204
		public static void WriteString(this Stream stream, string value, Encoding encoding)
		{
			byte[] bytes = encoding.GetBytes(value);
			stream.Write(bytes, 0, bytes.Length);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0000C024 File Offset: 0x0000A224
		public static Task WriteStringAsync(this Stream stream, string value, Encoding encoding, CancellationToken cancellationToken)
		{
			byte[] bytes = encoding.GetBytes(value);
			return stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
		}
	}
}
