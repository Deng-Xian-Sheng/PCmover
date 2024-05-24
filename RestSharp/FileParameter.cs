using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200000C RID: 12
	[NullableContext(1)]
	[Nullable(0)]
	public class FileParameter
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021BD File Offset: 0x000003BD
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000021C5 File Offset: 0x000003C5
		public long ContentLength { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021CE File Offset: 0x000003CE
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000021D6 File Offset: 0x000003D6
		public Action<Stream> Writer { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021DF File Offset: 0x000003DF
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000021E7 File Offset: 0x000003E7
		public string FileName { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021F0 File Offset: 0x000003F0
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000021F8 File Offset: 0x000003F8
		public string ContentType { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002201 File Offset: 0x00000401
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002209 File Offset: 0x00000409
		public string Name { get; set; }

		// Token: 0x06000017 RID: 23 RVA: 0x00002214 File Offset: 0x00000414
		public static FileParameter Create(string name, byte[] data, string filename, string contentType)
		{
			return new FileParameter
			{
				Writer = delegate(Stream s)
				{
					s.Write(data, 0, data.Length);
				},
				FileName = filename,
				ContentType = contentType,
				ContentLength = (long)data.Length,
				Name = name
			};
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002268 File Offset: 0x00000468
		public static FileParameter Create(string name, byte[] data, string filename)
		{
			return FileParameter.Create(name, data, filename, null);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002273 File Offset: 0x00000473
		public static FileParameter Create(string name, Action<Stream> writer, long contentLength, string fileName, string contentType = null)
		{
			return new FileParameter
			{
				Name = name,
				FileName = fileName,
				ContentType = contentType,
				Writer = writer,
				ContentLength = contentLength
			};
		}
	}
}
