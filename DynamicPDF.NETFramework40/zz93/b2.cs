using System;
using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000061 RID: 97
	internal class b2 : b1
	{
		// Token: 0x060003D7 RID: 983 RVA: 0x00044A27 File Offset: 0x00043A27
		internal b2(Stream A_0, Document A_1, b5 A_2) : base(A_0, A_1)
		{
			this.a = A_2;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00044A3C File Offset: 0x00043A3C
		internal override void ah(byte[] A_0, bool A_1)
		{
			base.c(A_0.Length * 4 + 4);
			this.l[this.m++] = 40;
			this.i.Reset(this.c);
			if (this.h.a() == b5.a)
			{
				base.c(this.i.Encrypt(254));
				base.c(this.i.Encrypt(byte.MaxValue));
				for (int i = 0; i < A_0.Length; i++)
				{
					base.c(this.i.Encrypt((byte)(A_0[i] >> 8)));
					base.c(this.i.Encrypt(A_0[i]));
				}
			}
			else
			{
				byte[] array = new byte[A_0.Length * 2 + 2];
				int num = 2;
				array[0] = 254;
				array[1] = byte.MaxValue;
				for (int i = 0; i < A_0.Length; i++)
				{
					array[num++] = (byte)(A_0[i] >> 8);
					array[num++] = A_0[i];
				}
				byte[] array2 = this.i.Encrypt(array);
				base.c(array2.Length + 1);
				for (int i = 0; i < array2.Length; i++)
				{
					base.c(array2[i]);
				}
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00044BC0 File Offset: 0x00043BC0
		public override void WriteText(byte[] text)
		{
			base.c(text.Length * 2 + 2);
			this.l[this.m++] = 40;
			base.g();
			this.i.Reset(this.c);
			if (this.h.a() == b5.a)
			{
				for (int i = 0; i < text.Length; i++)
				{
					base.c(this.i.Encrypt(text[i]));
				}
			}
			else
			{
				byte[] array = this.i.Encrypt(text);
				base.c(array.Length + 1);
				for (int i = 0; i < array.Length; i++)
				{
					base.c(array[i]);
				}
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00044CAC File Offset: 0x00043CAC
		public override void WriteText(string text)
		{
			base.c(text.Length * 4 + 6);
			this.l[this.m++] = 40;
			int m = this.m;
			bool flag = false;
			this.i.Reset(this.c);
			if (this.h.a() == b5.a)
			{
				for (int i = 0; i < text.Length; i++)
				{
					byte b = base.b(text[i]);
					if (b == 0)
					{
						flag = true;
						break;
					}
					base.c(this.i.Encrypt(b));
				}
				if (flag)
				{
					this.m = m;
					this.i.Reset(this.c);
					base.c(this.i.Encrypt(254));
					base.c(this.i.Encrypt(byte.MaxValue));
					for (int i = 0; i < text.Length; i++)
					{
						base.c(this.i.Encrypt((byte)(text[i] >> 8)));
						base.c(this.i.Encrypt((byte)text[i]));
					}
				}
			}
			else
			{
				byte[] array = new byte[text.Length];
				for (int i = 0; i < text.Length; i++)
				{
					array[i] = base.b(text[i]);
					if (array[i] == 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					byte[] array2 = this.i.Encrypt(array);
					base.c(array2.Length + 1);
					for (int i = 0; i < array2.Length; i++)
					{
						base.c(array2[i]);
					}
				}
				else
				{
					this.m = m;
					this.i.Reset(this.c);
					byte[] array3 = new byte[text.Length * 2 + 2];
					int num = 2;
					array3[0] = 254;
					array3[1] = byte.MaxValue;
					for (int i = 0; i < text.Length; i++)
					{
						array3[num++] = (byte)(text[i] >> 8);
						array3[num++] = (byte)text[i];
					}
					array3 = this.i.Encrypt(array3);
					base.c(array3.Length * 2 + 1);
					for (int i = 0; i < array3.Length; i++)
					{
						base.c(array3[i]);
					}
				}
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00044F91 File Offset: 0x00043F91
		public override void WriteStream(byte[] data, int length)
		{
			this.WriteStream(data, 0, length);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00044FA0 File Offset: 0x00043FA0
		internal override void ac(bp A_0)
		{
			base.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			base.g();
			this.i.Reset(this.c);
			A_0.q(this.f, this.i);
			if (this.h.a() == b5.a)
			{
				this.a += A_0.s();
			}
			else
			{
				this.a += A_0.s() + 16 + (16 - A_0.s() % 16);
			}
			DocumentWriter.e.CopyTo(this.l, 0);
			this.m = 10;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00045074 File Offset: 0x00044074
		public override void WriteStream(byte[] data, int start, int length)
		{
			base.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			base.g();
			this.i.Reset(this.c);
			this.i.Encrypt(this.f, data, start, length);
			if (this.h.a() == b5.a)
			{
				this.a += length;
			}
			else
			{
				this.a += length + 16 + (16 - length % 16);
			}
			base.c(10);
			DocumentWriter.e.CopyTo(this.l, this.m);
			this.m += 10;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00045150 File Offset: 0x00044150
		internal override void ab(agx A_0, int A_1)
		{
			base.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			base.g();
			byte[] data = A_0.k(A_1);
			this.i.Reset(this.c);
			this.i.Encrypt(this.f, data, 0, A_1);
			if (this.h.a() == b5.a)
			{
				this.a += A_1;
			}
			else
			{
				this.a += A_1 + 16 + (16 - A_1 % 16);
			}
			base.c(10);
			DocumentWriter.e.CopyTo(this.l, this.m);
			this.m += 10;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00045234 File Offset: 0x00044234
		public override int WriteStreamWithCompression(byte[] data, int length)
		{
			base.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			base.g();
			y0 y = new y0();
			y.b(data, 0, length);
			y.b();
			byte[] array = new byte[(int)((float)length * 1.002f + 12f)];
			int num = y.a(array);
			this.i.Reset(this.c);
			this.i.Encrypt(this.f, array, 0, num);
			DocumentWriter.e.CopyTo(this.l, 0);
			this.m = 10;
			int result;
			if (this.h.a() == b5.a)
			{
				this.a += num;
				result = num;
			}
			else
			{
				this.a += num + 16 + (16 - num % 16);
				result = num + 16 + (16 - num % 16);
			}
			return result;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00045344 File Offset: 0x00044344
		internal override void ai(int A_0)
		{
			if (this.h.a() == b5.a)
			{
				this.WriteNumber(A_0);
			}
			else if (this.h.d())
			{
				this.WriteNumber(A_0);
			}
			else
			{
				this.WriteNumber(A_0 + 16 + 16 - A_0 % 16);
			}
		}

		// Token: 0x04000261 RID: 609
		private new b5 a;
	}
}
