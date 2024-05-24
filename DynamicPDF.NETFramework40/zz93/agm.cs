using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004DD RID: 1245
	internal class agm : bp
	{
		// Token: 0x060032C3 RID: 12995 RVA: 0x001C4A57 File Offset: 0x001C3A57
		internal agm(agn A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060032C4 RID: 12996 RVA: 0x001C4A78 File Offset: 0x001C3A78
		internal override bool o()
		{
			return true;
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x001C4A8C File Offset: 0x001C3A8C
		internal override void p(Stream A_0)
		{
			if (this.a.a().Length - this.b >= this.c)
			{
				A_0.Write(this.a.a(), this.b, this.c);
			}
			else
			{
				int num = this.a.a().Length - this.b;
				A_0.Write(this.a.a(), this.b, num);
				agn agn = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (agn.a().Length < num2)
					{
						num2 = agn.a().Length;
					}
					A_0.Write(agn.a(), 0, num2);
					num += num2;
					agn = agn.c();
				}
				while (num < this.c);
			}
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x001C4B6C File Offset: 0x001C3B6C
		internal override void q(Stream A_0, Encrypter A_1)
		{
			if (this.a.a().Length - this.b >= this.c)
			{
				A_1.Encrypt(A_0, this.a.a(), this.b, this.c);
			}
			else if (A_1 is bz || A_1 is b0)
			{
				byte[] array = new byte[this.c];
				int num = this.a.a().Length - this.b;
				Array.Copy(this.a.a(), this.b, array, 0, num);
				agn agn = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (agn.a().Length < num2)
					{
						num2 = agn.a().Length;
					}
					Array.Copy(agn.a(), 0, array, num, num2);
					num += num2;
					agn = agn.c();
				}
				while (num < this.c);
				A_1.Encrypt(A_0, array, 0, this.c);
			}
			else
			{
				int num = this.a.a().Length - this.b;
				A_1.Encrypt(A_0, this.a.a(), this.b, num);
				agn agn = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (agn.a().Length < num2)
					{
						num2 = agn.a().Length;
					}
					A_1.Encrypt(A_0, agn.a(), 0, num2);
					num += num2;
					agn = agn.c();
				}
				while (num < this.c);
			}
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x001C4D28 File Offset: 0x001C3D28
		internal override void r(byte[] A_0, int A_1)
		{
			int num = this.a.b() - this.b;
			Array.Copy(this.a.a(), this.b, A_0, A_1, num);
			A_1 += num;
			agn agn = this.a.c();
			do
			{
				int num2 = this.c - num;
				if (agn.b() < num2)
				{
					num2 = agn.b();
				}
				Array.Copy(agn.a(), 0, A_0, A_1, num2);
				num += num2;
				A_1 += num;
				agn = agn.c();
			}
			while (num < this.c);
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x001C4DC8 File Offset: 0x001C3DC8
		internal agn a()
		{
			return this.a;
		}

		// Token: 0x060032C9 RID: 13001 RVA: 0x001C4DE0 File Offset: 0x001C3DE0
		internal int b()
		{
			return this.b;
		}

		// Token: 0x060032CA RID: 13002 RVA: 0x001C4DF8 File Offset: 0x001C3DF8
		internal override int s()
		{
			return this.c;
		}

		// Token: 0x04001855 RID: 6229
		private agn a;

		// Token: 0x04001856 RID: 6230
		private int b;

		// Token: 0x04001857 RID: 6231
		private int c;
	}
}
