using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000459 RID: 1113
	internal class ac1 : Encoder
	{
		// Token: 0x06002DDF RID: 11743 RVA: 0x001A06A3 File Offset: 0x0019F6A3
		internal ac1() : base(true)
		{
		}

		// Token: 0x06002DE0 RID: 11744 RVA: 0x001A06B0 File Offset: 0x0019F6B0
		public override byte[] Encode(FontSubsetter subsetter, char[] text, int start, int length, bool rightToLeft)
		{
			byte[] array = new byte[length];
			if (rightToLeft)
			{
				int num = start + length;
				int num2 = length - 1;
				for (int i = start; i < num; i++)
				{
					byte b = this.a(text[i]);
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
					byte b = this.a(text[i]);
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

		// Token: 0x06002DE1 RID: 11745 RVA: 0x001A07AC File Offset: 0x0019F7AC
		public byte a(char A_0)
		{
			byte result;
			if (A_0 >= 'a' && A_0 <= 'd')
			{
				result = (byte)A_0;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06002DE2 RID: 11746 RVA: 0x001A07D8 File Offset: 0x0019F7D8
		internal override int fl()
		{
			return 1;
		}

		// Token: 0x06002DE3 RID: 11747 RVA: 0x001A07EC File Offset: 0x0019F7EC
		internal override void fm(br A_0, FontSubsetter A_1, char[] A_2, int A_3, int A_4, bool A_5)
		{
			A_0.g();
			if (A_5)
			{
				for (int i = A_3 + A_4 - 1; i >= A_3; i--)
				{
					byte b = this.a(A_2[i]);
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
					byte b = this.a(A_2[i]);
					if (b != 0)
					{
						A_0.b(b);
					}
				}
			}
			A_0.h();
		}
	}
}
