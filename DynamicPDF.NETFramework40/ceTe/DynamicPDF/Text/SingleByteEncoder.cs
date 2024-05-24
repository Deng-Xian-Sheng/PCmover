using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x020002B7 RID: 695
	public abstract class SingleByteEncoder : Encoder
	{
		// Token: 0x06001FEA RID: 8170 RVA: 0x0013AE60 File Offset: 0x00139E60
		internal SingleByteEncoder(ushort[] A_0, ushort A_1, bool A_2) : base(true)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = new byte[(int)(this.b + 1)];
			for (int i = 0; i < 256; i++)
			{
				ushort num = this.a[i];
				if (num <= A_1)
				{
					this.d[(int)this.a[i]] = (byte)i;
				}
			}
		}

		// Token: 0x06001FEB RID: 8171 RVA: 0x0013AEDC File Offset: 0x00139EDC
		public virtual byte Encode(char character)
		{
			byte result;
			if (character <= (char)this.b)
			{
				result = this.d[(int)character];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06001FEC RID: 8172 RVA: 0x0013AF08 File Offset: 0x00139F08
		public char Decode(byte character)
		{
			return (char)this.a[(int)character];
		}

		// Token: 0x06001FED RID: 8173 RVA: 0x0013AF24 File Offset: 0x00139F24
		public override byte[] Encode(FontSubsetter subsetter, char[] text, int start, int length, bool rightToLeft)
		{
			byte[] array = new byte[length];
			if (rightToLeft)
			{
				int num = start + length;
				int num2 = length - 1;
				for (int i = start; i < num; i++)
				{
					byte b = this.Encode(text[i]);
					if (b != 0)
					{
						array[num2--] = b;
					}
				}
				if (num2 >= 0)
				{
					num2++;
					byte[] array2 = new byte[length - num2];
					Array.Copy(array, num2, array2, 0, array2.Length);
					return array2;
				}
			}
			else
			{
				int num = start + length;
				int num2 = 0;
				for (int i = start; i < num; i++)
				{
					byte b = this.Encode(text[i]);
					if (b != 0)
					{
						array[num2++] = b;
					}
				}
				if (num2 < array.Length)
				{
					byte[] array2 = new byte[num2];
					Array.Copy(array, array2, num2);
					return array2;
				}
			}
			return array;
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06001FEE RID: 8174 RVA: 0x0013B020 File Offset: 0x0013A020
		public bool IsBuiltInEncoding
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x06001FEF RID: 8175 RVA: 0x0013B038 File Offset: 0x0013A038
		internal override int fl()
		{
			return 1;
		}

		// Token: 0x06001FF0 RID: 8176 RVA: 0x0013B04C File Offset: 0x0013A04C
		internal override void fm(br A_0, FontSubsetter A_1, char[] A_2, int A_3, int A_4, bool A_5)
		{
			A_0.g();
			if (A_5)
			{
				for (int i = A_3 + A_4 - 1; i >= A_3; i--)
				{
					byte b = this.Encode(A_2[i]);
					if (b != 0)
					{
						A_0.b(b);
					}
				}
			}
			else
			{
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					byte b = this.Encode(A_2[i]);
					if (b != 0)
					{
						A_0.b(b);
					}
				}
			}
			A_0.h();
		}

		// Token: 0x04000DD0 RID: 3536
		private ushort[] a;

		// Token: 0x04000DD1 RID: 3537
		private ushort b;

		// Token: 0x04000DD2 RID: 3538
		private bool c;

		// Token: 0x04000DD3 RID: 3539
		private byte[] d;
	}
}
