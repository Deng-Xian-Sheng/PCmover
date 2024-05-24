using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000475 RID: 1141
	internal class ads
	{
		// Token: 0x06002F45 RID: 12101 RVA: 0x001AD381 File Offset: 0x001AC381
		internal ads()
		{
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x001AD38C File Offset: 0x001AC38C
		internal ads(BinaryReader A_0)
		{
			this.a = (ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte());
			if (this.a > 0)
			{
				this.b = A_0.ReadByte();
				this.c = A_0.ReadBytes((int)(this.a * (ushort)this.b + (ushort)this.b));
				this.d = A_0.ReadBytes(this.a((int)this.a) - this.a(0));
			}
		}

		// Token: 0x06002F47 RID: 12103 RVA: 0x001AD418 File Offset: 0x001AC418
		internal int a(int A_0)
		{
			if (A_0 * (int)this.b >= this.c.Length)
			{
				throw new Exception("Offset is out of range");
			}
			int result;
			switch (this.b)
			{
			case 1:
				result = (int)(this.c[A_0] - 1);
				break;
			case 2:
				result = ((int)this.c[A_0 * (int)this.b] << 8 | (int)this.c[A_0 * (int)this.b + 1]) - 1;
				break;
			case 3:
				result = ((int)this.c[A_0 * (int)this.b] << 16 | (int)this.c[A_0 * (int)this.b + 1] << 8 | (int)this.c[A_0 * (int)this.b + 2]) - 1;
				break;
			case 4:
				result = ((int)this.c[A_0 * (int)this.b] << 24 | (int)this.c[A_0 * (int)this.b + 1] << 16 | (int)this.c[A_0 * (int)this.b + 2] << 8 | (int)this.c[A_0 * (int)this.b + 3]) - 1;
				break;
			default:
				result = 0;
				break;
			}
			return result;
		}

		// Token: 0x06002F48 RID: 12104 RVA: 0x001AD53C File Offset: 0x001AC53C
		internal void a(int A_0, int A_1)
		{
			if (A_0 * (int)this.b >= this.c.Length)
			{
				throw new Exception("Offset is out of range");
			}
			switch (this.b)
			{
			case 1:
				this.c[A_0] = (byte)A_1;
				break;
			case 2:
				this.c[A_0 * (int)this.b] = (byte)(A_1 >> 8);
				this.c[A_0 * (int)this.b + 1] = (byte)A_1;
				break;
			case 3:
				this.c[A_0 * (int)this.b] = (byte)(A_1 >> 16);
				this.c[A_0 * (int)this.b + 1] = (byte)(A_1 >> 8);
				this.c[A_0 * (int)this.b + 2] = (byte)A_1;
				break;
			case 4:
				this.c[A_0 * (int)this.b] = (byte)(A_1 >> 24);
				this.c[A_0 * (int)this.b + 1] = (byte)(A_1 >> 16);
				this.c[A_0 * (int)this.b + 2] = (byte)(A_1 >> 8);
				this.c[A_0 * (int)this.b + 3] = (byte)A_1;
				break;
			}
		}

		// Token: 0x06002F49 RID: 12105 RVA: 0x001AD65C File Offset: 0x001AC65C
		internal void a(add A_0)
		{
			A_0.b((int)this.a);
			if (this.a > 0)
			{
				A_0.a(this.b);
				A_0.a(this.c);
				A_0.a(this.d);
			}
		}

		// Token: 0x06002F4A RID: 12106 RVA: 0x001AD6B0 File Offset: 0x001AC6B0
		internal ushort a()
		{
			return this.a;
		}

		// Token: 0x06002F4B RID: 12107 RVA: 0x001AD6C8 File Offset: 0x001AC6C8
		internal void a(ushort A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002F4C RID: 12108 RVA: 0x001AD6D4 File Offset: 0x001AC6D4
		internal byte[] b()
		{
			return this.c;
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x001AD6EC File Offset: 0x001AC6EC
		internal void a(byte[] A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x001AD6F8 File Offset: 0x001AC6F8
		internal byte c()
		{
			return this.b;
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x001AD710 File Offset: 0x001AC710
		internal void a(byte A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002F50 RID: 12112 RVA: 0x001AD71C File Offset: 0x001AC71C
		internal byte[] d()
		{
			return this.d;
		}

		// Token: 0x06002F51 RID: 12113 RVA: 0x001AD734 File Offset: 0x001AC734
		internal void b(byte[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002F52 RID: 12114 RVA: 0x001AD740 File Offset: 0x001AC740
		internal int e()
		{
			int result;
			if (this.a > 0)
			{
				result = 3 + this.c.Length + this.d.Length;
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x04001684 RID: 5764
		private ushort a;

		// Token: 0x04001685 RID: 5765
		private byte b;

		// Token: 0x04001686 RID: 5766
		private byte[] c;

		// Token: 0x04001687 RID: 5767
		private byte[] d;
	}
}
