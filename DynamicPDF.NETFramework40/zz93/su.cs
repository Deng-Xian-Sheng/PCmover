using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002D2 RID: 722
	internal class su
	{
		// Token: 0x060020A0 RID: 8352 RVA: 0x00140E69 File Offset: 0x0013FE69
		internal su(int A_0, Stream A_1)
		{
			this.b = A_0;
			this.a = A_1;
			this.a();
		}

		// Token: 0x060020A1 RID: 8353 RVA: 0x00140E98 File Offset: 0x0013FE98
		internal void a()
		{
			int num = 0;
			int num2 = 0;
			if (this.b > 0)
			{
				num = 0;
				int num3 = this.a.ReadByte();
				this.b--;
				num2 = 0;
				if (16 == (num3 & -33) && !this.d)
				{
					this.d = true;
					num2 = ss.a(ref num, this.a);
					this.c = new sn(num2, this.a);
				}
				if (16 == (num3 & -33))
				{
					this.f = new byte[this.b];
					this.a.Read(this.f, 0, this.b);
					MemoryStream memoryStream = new MemoryStream(this.f);
					num3 = memoryStream.ReadByte();
					if (16 == (num3 & -33))
					{
						num2 = ss.a(ref num, memoryStream);
						this.e = new sf(num2, memoryStream);
					}
				}
			}
			this.b -= num;
			this.b -= num2;
		}

		// Token: 0x060020A2 RID: 8354 RVA: 0x00140FB8 File Offset: 0x0013FFB8
		internal sn b()
		{
			return this.c;
		}

		// Token: 0x060020A3 RID: 8355 RVA: 0x00140FD0 File Offset: 0x0013FFD0
		internal sf c()
		{
			return this.e;
		}

		// Token: 0x060020A4 RID: 8356 RVA: 0x00140FE8 File Offset: 0x0013FFE8
		internal byte[] d()
		{
			return this.f;
		}

		// Token: 0x04000E4D RID: 3661
		private Stream a;

		// Token: 0x04000E4E RID: 3662
		private int b = 0;

		// Token: 0x04000E4F RID: 3663
		private sn c;

		// Token: 0x04000E50 RID: 3664
		private bool d = false;

		// Token: 0x04000E51 RID: 3665
		private sf e;

		// Token: 0x04000E52 RID: 3666
		private byte[] f;
	}
}
