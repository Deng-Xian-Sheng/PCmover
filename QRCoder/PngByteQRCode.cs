using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace QRCoder
{
	// Token: 0x02000010 RID: 16
	public sealed class PngByteQRCode : AbstractQRCode, IDisposable
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00003838 File Offset: 0x00001A38
		public PngByteQRCode()
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003840 File Offset: 0x00001A40
		public PngByteQRCode(QRCodeData data) : base(data)
		{
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000384C File Offset: 0x00001A4C
		public byte[] GetGraphic(int pixelsPerModule, bool drawQuietZones = true)
		{
			byte[] bytes;
			using (PngByteQRCode.PngBuilder pngBuilder = new PngByteQRCode.PngBuilder())
			{
				int num = (base.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
				pngBuilder.WriteHeader(num, num, 1, PngByteQRCode.PngBuilder.ColorType.Greyscale);
				pngBuilder.WriteScanlines(this.DrawScanlines(pixelsPerModule, drawQuietZones));
				pngBuilder.WriteEnd();
				bytes = pngBuilder.GetBytes();
			}
			return bytes;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000038BC File Offset: 0x00001ABC
		public byte[] GetGraphic(int pixelsPerModule, byte[] darkColorRgba, byte[] lightColorRgba, bool drawQuietZones = true)
		{
			byte[] bytes;
			using (PngByteQRCode.PngBuilder pngBuilder = new PngByteQRCode.PngBuilder())
			{
				int num = (base.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
				pngBuilder.WriteHeader(num, num, 1, PngByteQRCode.PngBuilder.ColorType.Indexed);
				pngBuilder.WritePalette(new byte[][]
				{
					darkColorRgba,
					lightColorRgba
				});
				pngBuilder.WriteScanlines(this.DrawScanlines(pixelsPerModule, drawQuietZones));
				pngBuilder.WriteEnd();
				bytes = pngBuilder.GetBytes();
			}
			return bytes;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003944 File Offset: 0x00001B44
		private byte[] DrawScanlines(int pixelsPerModule, bool drawQuietZones)
		{
			List<BitArray> moduleMatrix = base.QrCodeData.ModuleMatrix;
			int num = moduleMatrix.Count - (drawQuietZones ? 0 : 8);
			int num2 = drawQuietZones ? 0 : 4;
			int num3 = (num * pixelsPerModule + 7) / 8 + 1;
			byte[] array = new byte[num3 * num * pixelsPerModule];
			for (int i = 0; i < num; i++)
			{
				BitArray bitArray = moduleMatrix[i + num2];
				int num4 = i * pixelsPerModule * num3;
				for (int j = 0; j < num; j++)
				{
					if (!bitArray[j + num2])
					{
						int k = j * pixelsPerModule;
						int num5 = k + pixelsPerModule;
						while (k < num5)
						{
							byte[] array2 = array;
							int num6 = num4 + 1 + k / 8;
							array2[num6] |= (byte)(128 >> k % 8);
							k++;
						}
					}
				}
				for (int l = 1; l < pixelsPerModule; l++)
				{
					Array.Copy(array, num4, array, num4 + l * num3, num3);
				}
			}
			return array;
		}

		// Token: 0x0200003D RID: 61
		private sealed class PngBuilder : IDisposable
		{
			// Token: 0x06000110 RID: 272 RVA: 0x0000A936 File Offset: 0x00008B36
			public void Dispose()
			{
				MemoryStream memoryStream = this.stream;
				if (memoryStream != null)
				{
					memoryStream.Dispose();
				}
				this.stream = null;
			}

			// Token: 0x06000111 RID: 273 RVA: 0x0000A950 File Offset: 0x00008B50
			public byte[] GetBytes()
			{
				byte[] array = this.stream.ToArray();
				int num3;
				for (int i = PngByteQRCode.PngBuilder.PngSignature.Length; i < array.Length; i = num3 + 4)
				{
					int num = (int)array[i] << 24 | (int)array[i + 1] << 16 | (int)array[i + 2] << 8 | (int)array[i + 3];
					uint num2 = PngByteQRCode.PngBuilder.Crc32(array, i + 4, num + 4);
					num3 = i + 8 + num;
					array[num3] = (byte)(num2 >> 24);
					array[num3 + 1] = (byte)(num2 >> 16);
					array[num3 + 2] = (byte)(num2 >> 8);
					array[num3 + 3] = (byte)num2;
				}
				return array;
			}

			// Token: 0x06000112 RID: 274 RVA: 0x0000A9D8 File Offset: 0x00008BD8
			public void WriteHeader(int width, int height, byte bitDepth, PngByteQRCode.PngBuilder.ColorType colorType)
			{
				this.stream.Write(PngByteQRCode.PngBuilder.PngSignature, 0, PngByteQRCode.PngBuilder.PngSignature.Length);
				this.WriteChunkStart(PngByteQRCode.PngBuilder.IHDR, 13);
				this.WriteIntBigEndian((uint)width);
				this.WriteIntBigEndian((uint)height);
				this.stream.WriteByte(bitDepth);
				this.stream.WriteByte((byte)colorType);
				this.stream.WriteByte(0);
				this.stream.WriteByte(0);
				this.stream.WriteByte(0);
				this.WriteChunkEnd();
			}

			// Token: 0x06000113 RID: 275 RVA: 0x0000AA5C File Offset: 0x00008C5C
			public void WritePalette(params byte[][] rgbaColors)
			{
				bool flag = false;
				this.WriteChunkStart(PngByteQRCode.PngBuilder.PLTE, 3 * rgbaColors.Length);
				foreach (byte[] array in rgbaColors)
				{
					flag |= (array.Length > 3 && array[3] < byte.MaxValue);
					this.stream.WriteByte(array[0]);
					this.stream.WriteByte(array[1]);
					this.stream.WriteByte(array[2]);
				}
				this.WriteChunkEnd();
				if (!flag)
				{
					return;
				}
				this.WriteChunkStart(PngByteQRCode.PngBuilder.tRNS, rgbaColors.Length);
				foreach (byte[] array2 in rgbaColors)
				{
					this.stream.WriteByte((array2.Length > 3) ? array2[3] : byte.MaxValue);
				}
				this.WriteChunkEnd();
			}

			// Token: 0x06000114 RID: 276 RVA: 0x0000AB20 File Offset: 0x00008D20
			public void WriteScanlines(byte[] scanlines)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					PngByteQRCode.PngBuilder.Deflate(memoryStream, scanlines);
					this.WriteChunkStart(PngByteQRCode.PngBuilder.IDAT, (int)(memoryStream.Length + 6L));
					this.stream.WriteByte(120);
					this.stream.WriteByte(156);
					memoryStream.Position = 0L;
					memoryStream.CopyTo(this.stream);
					uint value = PngByteQRCode.PngBuilder.Adler32(scanlines, 0, scanlines.Length);
					this.WriteIntBigEndian(value);
					this.WriteChunkEnd();
				}
			}

			// Token: 0x06000115 RID: 277 RVA: 0x0000ABB4 File Offset: 0x00008DB4
			public void WriteEnd()
			{
				this.WriteChunkStart(PngByteQRCode.PngBuilder.IEND, 0);
				this.WriteChunkEnd();
			}

			// Token: 0x06000116 RID: 278 RVA: 0x0000ABC8 File Offset: 0x00008DC8
			private void WriteChunkStart(byte[] type, int length)
			{
				this.WriteIntBigEndian((uint)length);
				this.stream.Write(type, 0, 4);
			}

			// Token: 0x06000117 RID: 279 RVA: 0x0000ABDF File Offset: 0x00008DDF
			private void WriteChunkEnd()
			{
				this.stream.SetLength(this.stream.Length + 4L);
				this.stream.Position += 4L;
			}

			// Token: 0x06000118 RID: 280 RVA: 0x0000AC0E File Offset: 0x00008E0E
			private void WriteIntBigEndian(uint value)
			{
				this.stream.WriteByte((byte)(value >> 24));
				this.stream.WriteByte((byte)(value >> 16));
				this.stream.WriteByte((byte)(value >> 8));
				this.stream.WriteByte((byte)value);
			}

			// Token: 0x06000119 RID: 281 RVA: 0x0000AC4C File Offset: 0x00008E4C
			private static void Deflate(Stream output, byte[] bytes)
			{
				using (DeflateStream deflateStream = new DeflateStream(output, CompressionMode.Compress, true))
				{
					deflateStream.Write(bytes, 0, bytes.Length);
				}
			}

			// Token: 0x0600011A RID: 282 RVA: 0x0000AC8C File Offset: 0x00008E8C
			private static uint Adler32(byte[] data, int index, int length)
			{
				uint num = 1U;
				uint num2 = 0U;
				int num3 = index + length;
				for (int i = index; i < num3; i++)
				{
					num = (num + (uint)data[i]) % 65521U;
					num2 = (num2 + num) % 65521U;
				}
				return (num2 << 16) + num;
			}

			// Token: 0x0600011B RID: 283 RVA: 0x0000ACCC File Offset: 0x00008ECC
			private static uint Crc32(byte[] data, int index, int length)
			{
				uint num = uint.MaxValue;
				int num2 = index + length;
				for (int i = index; i < num2; i++)
				{
					num = (PngByteQRCode.PngBuilder.CrcTable[(int)((num ^ (uint)data[i]) & 255U)] ^ num >> 8);
				}
				return num ^ uint.MaxValue;
			}

			// Token: 0x040000BF RID: 191
			private static readonly byte[] PngSignature = new byte[]
			{
				137,
				80,
				78,
				71,
				13,
				10,
				26,
				10
			};

			// Token: 0x040000C0 RID: 192
			private static readonly uint[] CrcTable = new uint[]
			{
				0U,
				1996959894U,
				3993919788U,
				2567524794U,
				124634137U,
				1886057615U,
				3915621685U,
				2657392035U,
				249268274U,
				2044508324U,
				3772115230U,
				2547177864U,
				162941995U,
				2125561021U,
				3887607047U,
				2428444049U,
				498536548U,
				1789927666U,
				4089016648U,
				2227061214U,
				450548861U,
				1843258603U,
				4107580753U,
				2211677639U,
				325883990U,
				1684777152U,
				4251122042U,
				2321926636U,
				335633487U,
				1661365465U,
				4195302755U,
				2366115317U,
				997073096U,
				1281953886U,
				3579855332U,
				2724688242U,
				1006888145U,
				1258607687U,
				3524101629U,
				2768942443U,
				901097722U,
				1119000684U,
				3686517206U,
				2898065728U,
				853044451U,
				1172266101U,
				3705015759U,
				2882616665U,
				651767980U,
				1373503546U,
				3369554304U,
				3218104598U,
				565507253U,
				1454621731U,
				3485111705U,
				3099436303U,
				671266974U,
				1594198024U,
				3322730930U,
				2970347812U,
				795835527U,
				1483230225U,
				3244367275U,
				3060149565U,
				1994146192U,
				31158534U,
				2563907772U,
				4023717930U,
				1907459465U,
				112637215U,
				2680153253U,
				3904427059U,
				2013776290U,
				251722036U,
				2517215374U,
				3775830040U,
				2137656763U,
				141376813U,
				2439277719U,
				3865271297U,
				1802195444U,
				476864866U,
				2238001368U,
				4066508878U,
				1812370925U,
				453092731U,
				2181625025U,
				4111451223U,
				1706088902U,
				314042704U,
				2344532202U,
				4240017532U,
				1658658271U,
				366619977U,
				2362670323U,
				4224994405U,
				1303535960U,
				984961486U,
				2747007092U,
				3569037538U,
				1256170817U,
				1037604311U,
				2765210733U,
				3554079995U,
				1131014506U,
				879679996U,
				2909243462U,
				3663771856U,
				1141124467U,
				855842277U,
				2852801631U,
				3708648649U,
				1342533948U,
				654459306U,
				3188396048U,
				3373015174U,
				1466479909U,
				544179635U,
				3110523913U,
				3462522015U,
				1591671054U,
				702138776U,
				2966460450U,
				3352799412U,
				1504918807U,
				783551873U,
				3082640443U,
				3233442989U,
				3988292384U,
				2596254646U,
				62317068U,
				1957810842U,
				3939845945U,
				2647816111U,
				81470997U,
				1943803523U,
				3814918930U,
				2489596804U,
				225274430U,
				2053790376U,
				3826175755U,
				2466906013U,
				167816743U,
				2097651377U,
				4027552580U,
				2265490386U,
				503444072U,
				1762050814U,
				4150417245U,
				2154129355U,
				426522225U,
				1852507879U,
				4275313526U,
				2312317920U,
				282753626U,
				1742555852U,
				4189708143U,
				2394877945U,
				397917763U,
				1622183637U,
				3604390888U,
				2714866558U,
				953729732U,
				1340076626U,
				3518719985U,
				2797360999U,
				1068828381U,
				1219638859U,
				3624741850U,
				2936675148U,
				906185462U,
				1090812512U,
				3747672003U,
				2825379669U,
				829329135U,
				1181335161U,
				3412177804U,
				3160834842U,
				628085408U,
				1382605366U,
				3423369109U,
				3138078467U,
				570562233U,
				1426400815U,
				3317316542U,
				2998733608U,
				733239954U,
				1555261956U,
				3268935591U,
				3050360625U,
				752459403U,
				1541320221U,
				2607071920U,
				3965973030U,
				1969922972U,
				40735498U,
				2617837225U,
				3943577151U,
				1913087877U,
				83908371U,
				2512341634U,
				3803740692U,
				2075208622U,
				213261112U,
				2463272603U,
				3855990285U,
				2094854071U,
				198958881U,
				2262029012U,
				4057260610U,
				1759359992U,
				534414190U,
				2176718541U,
				4139329115U,
				1873836001U,
				414664567U,
				2282248934U,
				4279200368U,
				1711684554U,
				285281116U,
				2405801727U,
				4167216745U,
				1634467795U,
				376229701U,
				2685067896U,
				3608007406U,
				1308918612U,
				956543938U,
				2808555105U,
				3495958263U,
				1231636301U,
				1047427035U,
				2932959818U,
				3654703836U,
				1088359270U,
				936918000U,
				2847714899U,
				3736837829U,
				1202900863U,
				817233897U,
				3183342108U,
				3401237130U,
				1404277552U,
				615818150U,
				3134207493U,
				3453421203U,
				1423857449U,
				601450431U,
				3009837614U,
				3294710456U,
				1567103746U,
				711928724U,
				3020668471U,
				3272380065U,
				1510334235U,
				755167117U
			};

			// Token: 0x040000C1 RID: 193
			private static readonly byte[] IHDR = new byte[]
			{
				73,
				72,
				68,
				82
			};

			// Token: 0x040000C2 RID: 194
			private static readonly byte[] IDAT = new byte[]
			{
				73,
				68,
				65,
				84
			};

			// Token: 0x040000C3 RID: 195
			private static readonly byte[] IEND = new byte[]
			{
				73,
				69,
				78,
				68
			};

			// Token: 0x040000C4 RID: 196
			private static readonly byte[] PLTE = new byte[]
			{
				80,
				76,
				84,
				69
			};

			// Token: 0x040000C5 RID: 197
			private static readonly byte[] tRNS = new byte[]
			{
				116,
				82,
				78,
				83
			};

			// Token: 0x040000C6 RID: 198
			private MemoryStream stream = new MemoryStream();

			// Token: 0x02000085 RID: 133
			public enum ColorType : byte
			{
				// Token: 0x0400029D RID: 669
				Greyscale,
				// Token: 0x0400029E RID: 670
				Indexed = 3
			}
		}
	}
}
