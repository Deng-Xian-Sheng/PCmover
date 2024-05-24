using System;

namespace zz93
{
	// Token: 0x0200015B RID: 347
	internal class ir : fd
	{
		// Token: 0x06000CE6 RID: 3302 RVA: 0x00095BF8 File Offset: 0x00094BF8
		internal ir()
		{
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00095C03 File Offset: 0x00094C03
		internal ir(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00095C18 File Offset: 0x00094C18
		internal override void cw(gi A_0)
		{
			string text = A_0.ah().ToLower();
			string text2 = text;
			if (text2 != null)
			{
				if (text2 == "auto")
				{
					this.a = new @is(text);
					this.a.a(true);
					return;
				}
				if (text2 == "fixed")
				{
					this.a = new @is(text);
					return;
				}
				if (text2 == "inherit")
				{
					this.a = new @is(null);
					this.a.d(true);
					return;
				}
			}
			this.a = new @is(null);
			this.a.a(true);
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00095CC0 File Offset: 0x00094CC0
		internal @is a()
		{
			return this.a;
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00095CD8 File Offset: 0x00094CD8
		internal override int cv()
		{
			return 1005822593;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00095CF0 File Offset: 0x00094CF0
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006A3 RID: 1699
		private new @is a;
	}
}
