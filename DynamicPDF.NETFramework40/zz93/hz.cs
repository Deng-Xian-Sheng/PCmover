using System;

namespace zz93
{
	// Token: 0x0200013F RID: 319
	internal class hz : fd
	{
		// Token: 0x06000C19 RID: 3097 RVA: 0x0009087C File Offset: 0x0008F87C
		internal hz(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00090890 File Offset: 0x0008F890
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			if (num <= 448574430)
			{
				if (num != 6662337)
				{
					if (num != 7021096)
					{
						if (num == 448574430)
						{
							this.a = new gh(gf.d);
						}
					}
					else
					{
						this.a = new gh(gf.c);
					}
				}
				else
				{
					this.a = new gh(gf.e);
					this.a.a(true);
				}
			}
			else if (num != 505607249)
			{
				if (num != 705063489)
				{
					if (num == 893228481)
					{
						this.a = new gh(gf.b);
					}
				}
				else
				{
					this.a = new gh(gf.a);
				}
			}
			else
			{
				this.a = new gh(gf.e);
				this.a.d(true);
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00090954 File Offset: 0x0008F954
		internal override int cv()
		{
			return 31536467;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0009096C File Offset: 0x0008F96C
		internal gh a()
		{
			return this.a;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00090984 File Offset: 0x0008F984
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000645 RID: 1605
		private new gh a;
	}
}
