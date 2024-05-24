using System;
using System.IO;

namespace zz93
{
	// Token: 0x020004E0 RID: 1248
	internal class agp : aa9
	{
		// Token: 0x060032D3 RID: 13011 RVA: 0x001C4EEC File Offset: 0x001C3EEC
		internal agp(Stream A_0)
		{
			this.c = A_0;
			this.b = (int)((A_0.Length - 1L) / 16384L);
		}

		// Token: 0x060032D4 RID: 13012 RVA: 0x001C4F23 File Offset: 0x001C3F23
		internal agp(long A_0)
		{
			this.b = (int)((A_0 - 1L) / 16384L);
		}

		// Token: 0x060032D5 RID: 13013 RVA: 0x001C4F50 File Offset: 0x001C3F50
		internal int a()
		{
			return this.b;
		}

		// Token: 0x060032D6 RID: 13014 RVA: 0x001C4F68 File Offset: 0x001C3F68
		internal int b()
		{
			byte[] array = new byte[8];
			this.k9();
			this.c.Seek(0L, SeekOrigin.Begin);
			this.c.Read(array, 0, 8);
			int result;
			if (array[0] == 37 && array[1] == 80 && array[2] == 68 && array[3] == 70 && array[4] == 45 && array[6] == 46)
			{
				result = (int)((array[5] - 48) * 10 + array[7] - 48);
			}
			else
			{
				result = 14;
			}
			return result;
		}

		// Token: 0x060032D7 RID: 13015 RVA: 0x001C4FF4 File Offset: 0x001C3FF4
		internal int a(long A_0)
		{
			return (int)(A_0 / 16384L);
		}

		// Token: 0x060032D8 RID: 13016 RVA: 0x001C5010 File Offset: 0x001C4010
		internal short b(long A_0)
		{
			return (short)(A_0 % 16384L);
		}

		// Token: 0x060032D9 RID: 13017 RVA: 0x001C502C File Offset: 0x001C402C
		internal agy c(long A_0)
		{
			return this.a(this.a(A_0));
		}

		// Token: 0x060032DA RID: 13018 RVA: 0x001C504C File Offset: 0x001C404C
		internal agy c()
		{
			return this.a(this.b);
		}

		// Token: 0x060032DB RID: 13019 RVA: 0x001C506C File Offset: 0x001C406C
		internal agy a(int A_0)
		{
			agy result;
			if (this.e != null && this.e.d() == A_0)
			{
				result = this.e;
			}
			else
			{
				int num = A_0 * 16384;
				this.k9();
				byte[] array;
				if (A_0 == this.b)
				{
					if (this.c.Length % 16384L == 0L)
					{
						array = new byte[16384];
					}
					else
					{
						array = new byte[this.c.Length % 16384L];
					}
				}
				else
				{
					array = new byte[16384];
				}
				lock (this.c)
				{
					this.c.Seek((long)num, SeekOrigin.Begin);
					this.c.Read(array, 0, array.Length);
				}
				agy agy = new agy(this, A_0, array, num);
				this.e = agy;
				result = agy;
			}
			return result;
		}

		// Token: 0x060032DC RID: 13020 RVA: 0x001C5194 File Offset: 0x001C4194
		internal override aba k8()
		{
			if (this.e == null)
			{
				this.e = this.c();
			}
			return new agx(this, this.e);
		}

		// Token: 0x060032DD RID: 13021 RVA: 0x001C51D0 File Offset: 0x001C41D0
		internal agx d()
		{
			if (this.e == null)
			{
				this.e = this.c();
			}
			return new agx(this, this.e);
		}

		// Token: 0x060032DE RID: 13022 RVA: 0x001C520A File Offset: 0x001C420A
		internal virtual void k9()
		{
		}

		// Token: 0x060032DF RID: 13023 RVA: 0x001C520F File Offset: 0x001C420F
		internal void a(Stream A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060032E0 RID: 13024 RVA: 0x001C5219 File Offset: 0x001C4219
		internal void e()
		{
			this.c = null;
		}

		// Token: 0x060032E1 RID: 13025 RVA: 0x001C5224 File Offset: 0x001C4224
		internal agx a(int A_0, int A_1)
		{
			agx result;
			if (this.d == null)
			{
				result = new agx(this, A_0, A_1);
			}
			else
			{
				agx agx = this.d;
				this.d = null;
				agx.c(A_0, A_1);
				result = agx;
			}
			return result;
		}

		// Token: 0x060032E2 RID: 13026 RVA: 0x001C526C File Offset: 0x001C426C
		internal agx a(int A_0, int A_1, int A_2)
		{
			agx result;
			if (this.d == null)
			{
				result = new agx(this, A_0, A_1, A_2);
			}
			else
			{
				agx agx = this.d;
				this.d = null;
				agx.a(A_0, A_1, A_2);
				result = agx;
			}
			return result;
		}

		// Token: 0x060032E3 RID: 13027 RVA: 0x001C52B4 File Offset: 0x001C42B4
		internal void a(agx A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0400185D RID: 6237
		internal new const short a = 16384;

		// Token: 0x0400185E RID: 6238
		private int b;

		// Token: 0x0400185F RID: 6239
		private Stream c;

		// Token: 0x04001860 RID: 6240
		private agx d = null;

		// Token: 0x04001861 RID: 6241
		private agy e = null;
	}
}
