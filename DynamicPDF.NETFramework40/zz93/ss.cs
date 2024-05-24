using System;
using System.IO;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020002D0 RID: 720
	internal class ss
	{
		// Token: 0x06002096 RID: 8342 RVA: 0x0014088F File Offset: 0x0013F88F
		internal ss(Stream A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002097 RID: 8343 RVA: 0x001408A4 File Offset: 0x0013F8A4
		internal void a()
		{
			byte b = (byte)this.a.ReadByte();
			if (16 == ((int)b & -33))
			{
				int num = 0;
				int a_ = ss.a(ref num, this.a);
				this.b = new su(a_, this.a);
			}
		}

		// Token: 0x06002098 RID: 8344 RVA: 0x001408F4 File Offset: 0x0013F8F4
		internal int b()
		{
			int result;
			if (this.b != null)
			{
				result = (int)this.b.b().b().b();
			}
			else
			{
				result = 6;
			}
			return result;
		}

		// Token: 0x06002099 RID: 8345 RVA: 0x00140930 File Offset: 0x0013F930
		internal st c()
		{
			st result;
			if (this.b != null)
			{
				result = this.b.c().b().b();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600209A RID: 8346 RVA: 0x00140968 File Offset: 0x0013F968
		internal byte[] d()
		{
			byte[] result;
			if (this.b != null)
			{
				result = this.b.d();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600209B RID: 8347 RVA: 0x00140998 File Offset: 0x0013F998
		internal static int a(ref int A_0, Stream A_1)
		{
			int num = A_1.ReadByte();
			A_0++;
			if (num < 0)
			{
				throw new TimestampException("Timestamp Information is not valid");
			}
			int result;
			if (num == 128)
			{
				result = -1;
			}
			else
			{
				if (num > 127)
				{
					int num2 = num & 127;
					if (num2 > 4)
					{
						throw new TimestampException("Timestamp Information is not valid");
					}
					num = 0;
					for (int i = 0; i < num2; i++)
					{
						int num3 = A_1.ReadByte();
						A_0++;
						if (num3 < 0)
						{
							throw new TimestampException("Timestamp Information is not valid");
						}
						num = (num << 8) + num3;
					}
					if (num < 0)
					{
						throw new TimestampException("Timestamp Information is not valid");
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x04000E44 RID: 3652
		private Stream a;

		// Token: 0x04000E45 RID: 3653
		private su b;
	}
}
