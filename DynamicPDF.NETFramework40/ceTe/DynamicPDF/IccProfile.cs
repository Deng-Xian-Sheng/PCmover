using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200069D RID: 1693
	public class IccProfile : Resource
	{
		// Token: 0x0600405B RID: 16475 RVA: 0x002215CC File Offset: 0x002205CC
		public IccProfile(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			this.a(array);
		}

		// Token: 0x0600405C RID: 16476 RVA: 0x00221613 File Offset: 0x00220613
		public IccProfile(byte[] iccProfile)
		{
			this.a(iccProfile);
		}

		// Token: 0x0600405D RID: 16477 RVA: 0x00221628 File Offset: 0x00220628
		public IccProfile(Stream iccProfile)
		{
			byte[] array = new byte[iccProfile.Length];
			iccProfile.Read(array, 0, array.Length);
			this.a(array);
		}

		// Token: 0x0600405E RID: 16478 RVA: 0x00221660 File Offset: 0x00220660
		private new void a(byte[] A_0)
		{
			if (A_0.Length < 200 || this.a(A_0, 36) != 1633907568)
			{
				throw new GeneratorException("Invalid ICC Profile. File has an invalid signature.");
			}
			int num = this.a(A_0, 12);
			if (num <= 1886549106)
			{
				if (num == 1835955314)
				{
					goto IL_77;
				}
				if (num == 1886549106)
				{
					goto IL_77;
				}
			}
			else
			{
				if (num == 1935896178)
				{
					goto IL_77;
				}
				if (num == 1936744803)
				{
					goto IL_77;
				}
			}
			throw new GeneratorException("Invalid ICC Profile. Devise class is not compatible with PDF.");
			IL_77:
			num = this.a(A_0, 16);
			if (num <= 1196573017)
			{
				if (num == 1129142603)
				{
					this.b = 4;
					goto IL_DC;
				}
				if (num == 1196573017)
				{
					this.b = 1;
					goto IL_DC;
				}
			}
			else
			{
				if (num == 1281450528)
				{
					this.b = 3;
					goto IL_DC;
				}
				if (num == 1380401696)
				{
					this.b = 3;
					goto IL_DC;
				}
			}
			throw new GeneratorException("Invalid ICC Profile. Color space is not compatible with PDF.");
			IL_DC:
			this.a = y0.a(A_0, 0, A_0.Length);
		}

		// Token: 0x0600405F RID: 16479 RVA: 0x0022175C File Offset: 0x0022075C
		private new int a(byte[] A_0, int A_1)
		{
			int num = (int)A_0[A_1++] << 24;
			num |= (int)A_0[A_1++] << 16;
			num |= (int)A_0[A_1++] << 8;
			return num | (int)A_0[A_1];
		}

		// Token: 0x06004060 RID: 16480 RVA: 0x0022179C File Offset: 0x0022079C
		internal new int a()
		{
			return this.b;
		}

		// Token: 0x06004061 RID: 16481 RVA: 0x002217B4 File Offset: 0x002207B4
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(78);
			writer.WriteNumber(this.b);
			writer.WriteName(Resource.e);
			writer.ai(this.a.Length);
			writer.WriteName(Resource.c);
			writer.WriteName(Resource.d);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.a, this.a.Length);
			writer.WriteEndObject();
		}

		// Token: 0x040023B1 RID: 9137
		private new byte[] a;

		// Token: 0x040023B2 RID: 9138
		private new int b;
	}
}
