using System;
using System.IO;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000063 RID: 99
	internal class b4 : b3
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x00047672 File Offset: 0x00046672
		internal b4(Stream A_0, Document A_1, b5 A_2) : base(A_0, A_1)
		{
			this.a = A_2;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00047686 File Offset: 0x00046686
		public override void WriteStream(byte[] data, int length)
		{
			this.WriteStream(data, 0, length);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00047694 File Offset: 0x00046694
		public override void WriteStream(byte[] data, int start, int length)
		{
			zz k = this.k;
			k.a(k.k() | 128);
			if (this.h.a() == b5.a)
			{
				this.w += length;
			}
			else
			{
				this.w += length + 16 + (16 - length % 16);
			}
			base.f();
			this.k.l().a(new zt(data, start, length));
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00047720 File Offset: 0x00046720
		internal override void ac(bp A_0)
		{
			zz k = this.k;
			k.a(k.k() | 128);
			if (this.a == b5.a)
			{
				this.w += A_0.s();
			}
			else
			{
				this.w += A_0.s() + 16 + (16 - A_0.s() % 16);
			}
			base.f();
			this.k.l().a(new zs(A_0));
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000477B4 File Offset: 0x000467B4
		internal override void ab(agx A_0, int A_1)
		{
			zz k = this.k;
			k.a(k.k() | 128);
			if (this.a == b5.a)
			{
				this.w += A_1;
			}
			else
			{
				this.w += A_1 + 16 + (16 - A_1 % 16);
			}
			base.f();
			this.k.l().a(new afc(A_0, A_1));
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00047838 File Offset: 0x00046838
		public override int WriteStreamWithCompression(byte[] data, int length)
		{
			zz k = this.k;
			k.a(k.k() | 128);
			base.f();
			int num = (int)((float)length * 1.002f + 12f);
			if (this.h.a() == b5.a)
			{
				base.a(num);
			}
			else
			{
				base.a(num + 16 + (16 - num % 16));
			}
			y0 y = new y0();
			y.b(data, 0, length);
			y.b();
			num = y.c(this.s, this.u, num);
			this.k.l().a(new zt(this.s, this.u, num));
			this.u += num;
			this.v = this.u;
			int result;
			if (this.h.a() == b5.a)
			{
				this.w += num;
				result = num;
			}
			else
			{
				this.w += num + 16 + (16 - num % 16);
				result = num + 16 + (16 - num % 16);
			}
			return result;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00047968 File Offset: 0x00046968
		public override void WriteText(string text)
		{
			if (this.h.a() == b5.a)
			{
				base.a(text.Length * 4 + 6);
			}
			else
			{
				int num = text.Length * 4;
				base.a(num + 16 + 16 - num % 16);
			}
			this.s[this.u++] = 40;
			int u = this.u;
			bool flag = false;
			base.f();
			for (int i = 0; i < text.Length; i++)
			{
				byte b = base.b(text[i]);
				if (b == 0)
				{
					flag = true;
					break;
				}
				this.s[this.u++] = b;
			}
			if (!flag)
			{
				if (this.u > u)
				{
					this.k.l().a(new zu(this.s, u, this.u - u));
					this.v = this.u;
				}
			}
			else
			{
				this.u = u;
				this.s[this.u++] = 254;
				this.s[this.u++] = byte.MaxValue;
				for (int i = 0; i < text.Length; i++)
				{
					this.s[this.u++] = (byte)(text[i] >> 8);
					this.s[this.u++] = (byte)text[i];
				}
				this.k.l().a(new zu(this.s, this.v, this.u - this.v));
				this.v = this.u;
			}
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00047B9C File Offset: 0x00046B9C
		internal override void ah(byte[] A_0, bool A_1)
		{
			if (this.h.a() == b5.a)
			{
				base.a(A_0.Length * 4 + 6);
			}
			else
			{
				int num = A_0.Length * 4;
				base.a(num + 16 + 16 - num % 16);
			}
			this.s[this.u++] = 40;
			base.f();
			this.s[this.u++] = 254;
			this.s[this.u++] = byte.MaxValue;
			for (int i = 0; i < A_0.Length; i++)
			{
				this.s[this.u++] = (byte)(A_0[i] >> 8);
				this.s[this.u++] = A_0[i];
			}
			this.k.l().a(new zu(this.s, this.v, this.u - this.v));
			this.v = this.u;
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00047CF0 File Offset: 0x00046CF0
		public override void WriteText(byte[] text)
		{
			base.a(1);
			this.s[this.u++] = 40;
			base.f();
			this.k.l().a(new zu(text, 0, text.Length));
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00047D64 File Offset: 0x00046D64
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

		// Token: 0x0400027B RID: 635
		private new b5 a;
	}
}
