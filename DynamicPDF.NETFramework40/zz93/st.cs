using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002D1 RID: 721
	internal class st
	{
		// Token: 0x0600209C RID: 8348 RVA: 0x00140A71 File Offset: 0x0013FA71
		internal st(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x0600209D RID: 8349 RVA: 0x00140AA8 File Offset: 0x0013FAA8
		private void a()
		{
			while (this.a > 0)
			{
				int num = this.b.ReadByte();
				this.a--;
				int num2 = 0;
				int num3 = 0;
				if (num == 2 && !this.e)
				{
					this.e = true;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				else if (num == 6)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					this.b.Position = this.b.Position + (long)num3;
				}
				else if (16 == (num & -33) && !this.g)
				{
					this.g = true;
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					this.c = new sl(num3, this.b);
				}
				else if (num == 2 && !this.f)
				{
					num2 = 0;
					this.f = true;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				else if (num == 24)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				else if (16 == (num & -33))
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					this.b.Position = this.b.Position + (long)num3;
				}
				else if (num == 1)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				else if (num == 2)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
					this.d = new sh(array);
				}
				else if (num == 160)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				else if (num - 160 == 1)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					this.b.Position = this.b.Position + (long)num3;
				}
				this.a -= num2;
				this.a -= num3;
			}
		}

		// Token: 0x0600209E RID: 8350 RVA: 0x00140E34 File Offset: 0x0013FE34
		internal sl b()
		{
			return this.c;
		}

		// Token: 0x0600209F RID: 8351 RVA: 0x00140E4C File Offset: 0x0013FE4C
		internal long c()
		{
			return this.d.d();
		}

		// Token: 0x04000E46 RID: 3654
		private int a;

		// Token: 0x04000E47 RID: 3655
		private Stream b;

		// Token: 0x04000E48 RID: 3656
		private sl c;

		// Token: 0x04000E49 RID: 3657
		private sh d;

		// Token: 0x04000E4A RID: 3658
		private bool e = false;

		// Token: 0x04000E4B RID: 3659
		private bool f = false;

		// Token: 0x04000E4C RID: 3660
		private bool g = false;
	}
}
