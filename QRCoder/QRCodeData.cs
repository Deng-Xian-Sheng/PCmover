using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using QRCoder.Framework4._0Methods;

namespace QRCoder
{
	// Token: 0x02000016 RID: 22
	public class QRCodeData : IDisposable
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000044C8 File Offset: 0x000026C8
		// (set) Token: 0x06000059 RID: 89 RVA: 0x000044D0 File Offset: 0x000026D0
		public List<BitArray> ModuleMatrix { get; set; }

		// Token: 0x0600005A RID: 90 RVA: 0x000044DC File Offset: 0x000026DC
		public QRCodeData(int version)
		{
			this.Version = version;
			int num = QRCodeData.ModulesPerSideFromVersion(version);
			this.ModuleMatrix = new List<BitArray>();
			for (int i = 0; i < num; i++)
			{
				this.ModuleMatrix.Add(new BitArray(num));
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004525 File Offset: 0x00002725
		public QRCodeData(string pathToRawData, QRCodeData.Compression compressMode) : this(File.ReadAllBytes(pathToRawData), compressMode)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004534 File Offset: 0x00002734
		public QRCodeData(byte[] rawData, QRCodeData.Compression compressMode)
		{
			List<byte> list = new List<byte>(rawData);
			if (compressMode == QRCodeData.Compression.Deflate)
			{
				using (MemoryStream memoryStream = new MemoryStream(list.ToArray()))
				{
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
						{
							Stream4Methods.CopyTo(deflateStream, memoryStream2);
						}
						list = new List<byte>(memoryStream2.ToArray());
						goto IL_C9;
					}
				}
			}
			if (compressMode == QRCodeData.Compression.GZip)
			{
				using (MemoryStream memoryStream3 = new MemoryStream(list.ToArray()))
				{
					using (MemoryStream memoryStream4 = new MemoryStream())
					{
						using (GZipStream gzipStream = new GZipStream(memoryStream3, CompressionMode.Decompress))
						{
							Stream4Methods.CopyTo(gzipStream, memoryStream4);
						}
						list = new List<byte>(memoryStream4.ToArray());
					}
				}
			}
			IL_C9:
			if (list[0] != 81 || list[1] != 82 || list[2] != 82)
			{
				throw new Exception("Invalid raw data file. Filetype doesn't match \"QRR\".");
			}
			int num = (int)list[4];
			list.RemoveRange(0, 5);
			this.Version = (num - 21 - 8) / 4 + 1;
			Queue<bool> queue = new Queue<bool>(8 * list.Count);
			foreach (byte b in list)
			{
				new BitArray(new byte[]
				{
					b
				});
				for (int i = 7; i >= 0; i--)
				{
					queue.Enqueue(((int)b & 1 << i) != 0);
				}
			}
			this.ModuleMatrix = new List<BitArray>(num);
			for (int j = 0; j < num; j++)
			{
				this.ModuleMatrix.Add(new BitArray(num));
				for (int k = 0; k < num; k++)
				{
					this.ModuleMatrix[j][k] = queue.Dequeue();
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004774 File Offset: 0x00002974
		public byte[] GetRawData(QRCodeData.Compression compressMode)
		{
			List<byte> list = new List<byte>();
			list.AddRange(new byte[]
			{
				81,
				82,
				82,
				0
			});
			list.Add((byte)this.ModuleMatrix.Count);
			Queue<int> queue = new Queue<int>();
			foreach (BitArray bitArray in this.ModuleMatrix)
			{
				foreach (object obj in bitArray)
				{
					queue.Enqueue(((bool)obj) ? 1 : 0);
				}
			}
			for (int i = 0; i < 8 - this.ModuleMatrix.Count * this.ModuleMatrix.Count % 8; i++)
			{
				queue.Enqueue(0);
			}
			while (queue.Count > 0)
			{
				byte b = 0;
				for (int j = 7; j >= 0; j--)
				{
					b += (byte)(queue.Dequeue() << j);
				}
				list.Add(b);
			}
			byte[] array = list.ToArray();
			if (compressMode == QRCodeData.Compression.Deflate)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
					{
						deflateStream.Write(array, 0, array.Length);
					}
					return memoryStream.ToArray();
				}
			}
			if (compressMode == QRCodeData.Compression.GZip)
			{
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					using (GZipStream gzipStream = new GZipStream(memoryStream2, CompressionMode.Compress, true))
					{
						gzipStream.Write(array, 0, array.Length);
					}
					array = memoryStream2.ToArray();
				}
			}
			return array;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004974 File Offset: 0x00002B74
		public void SaveRawData(string filePath, QRCodeData.Compression compressMode)
		{
			File.WriteAllBytes(filePath, this.GetRawData(compressMode));
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00004983 File Offset: 0x00002B83
		// (set) Token: 0x06000060 RID: 96 RVA: 0x0000498B File Offset: 0x00002B8B
		public int Version { get; private set; }

		// Token: 0x06000061 RID: 97 RVA: 0x00004994 File Offset: 0x00002B94
		private static int ModulesPerSideFromVersion(int version)
		{
			return 21 + (version - 1) * 4;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000499E File Offset: 0x00002B9E
		public void Dispose()
		{
			this.ModuleMatrix = null;
			this.Version = 0;
		}

		// Token: 0x0200003E RID: 62
		public enum Compression
		{
			// Token: 0x040000C8 RID: 200
			Uncompressed,
			// Token: 0x040000C9 RID: 201
			Deflate,
			// Token: 0x040000CA RID: 202
			GZip
		}
	}
}
