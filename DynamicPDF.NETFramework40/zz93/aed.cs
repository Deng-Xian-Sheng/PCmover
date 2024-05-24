using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200048A RID: 1162
	internal class aed : ceTe.DynamicPDF.Text.Encoder
	{
		// Token: 0x06002FF8 RID: 12280 RVA: 0x001B121B File Offset: 0x001B021B
		internal aed() : base(false)
		{
		}

		// Token: 0x06002FF9 RID: 12281 RVA: 0x001B1227 File Offset: 0x001B0227
		public override void DrawEncoding(DocumentWriter writer)
		{
			writer.WriteName(ceTe.DynamicPDF.Text.Encoder.i);
			writer.WriteName(aed.a);
		}

		// Token: 0x06002FFA RID: 12282 RVA: 0x001B1244 File Offset: 0x001B0244
		public override byte[] Encode(FontSubsetter subsetter, char[] text, int start, int length, bool rightToLeft)
		{
			byte[] bytes;
			if (rightToLeft)
			{
				char[] array = new char[length];
				for (int i = 0; i < length; i++)
				{
					array[i] = text[start + length - i];
				}
				bytes = Encoding.BigEndianUnicode.GetBytes(array, 0, length);
			}
			else
			{
				bytes = Encoding.BigEndianUnicode.GetBytes(text, start, length);
			}
			return bytes;
		}

		// Token: 0x06002FFB RID: 12283 RVA: 0x001B12A8 File Offset: 0x001B02A8
		internal override int fl()
		{
			return 2;
		}

		// Token: 0x06002FFC RID: 12284 RVA: 0x001B12BC File Offset: 0x001B02BC
		private ushort a(char A_0)
		{
			ushort result;
			if (A_0 >= '\ud800' && A_0 <= '\udfff')
			{
				result = 65533;
			}
			else
			{
				result = (ushort)A_0;
			}
			return result;
		}

		// Token: 0x06002FFD RID: 12285 RVA: 0x001B12F0 File Offset: 0x001B02F0
		internal override void fm(br A_0, FontSubsetter A_1, char[] A_2, int A_3, int A_4, bool A_5)
		{
			A_0.g();
			if (A_5)
			{
				for (int i = A_3 + A_4 - 1; i >= A_3; i--)
				{
					ushort num = this.a(A_2[i]);
					A_0.b((byte)(num >> 8));
					A_0.b((byte)num);
				}
			}
			else
			{
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					ushort num = this.a(A_2[i]);
					A_0.b((byte)(num >> 8));
					A_0.b((byte)num);
				}
			}
			A_0.h();
		}

		// Token: 0x040016DB RID: 5851
		private static byte[] a = new byte[]
		{
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121,
			45,
			72
		};
	}
}
