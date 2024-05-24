using System;

namespace zz93
{
	// Token: 0x02000118 RID: 280
	internal class gw : fd
	{
		// Token: 0x06000B2E RID: 2862 RVA: 0x00089ED6 File Offset: 0x00088ED6
		internal gw(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00089EEC File Offset: 0x00088EEC
		internal override void cw(gi A_0)
		{
			this.a(A_0);
			while (A_0.a3())
			{
				this.a(A_0);
			}
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00089F18 File Offset: 0x00088F18
		private void a(gi A_0)
		{
			string text = A_0.ah();
			if (text.EndsWith(".cur"))
			{
				this.a = g1.a;
				this.b = text;
			}
			else if (text != null)
			{
				this.a(text);
			}
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x00089F68 File Offset: 0x00088F68
		private void a(string A_0)
		{
			string text = A_0.ToLower();
			switch (text)
			{
			case "auto":
				this.a = g1.b;
				return;
			case "crosshair":
				this.a = g1.c;
				return;
			case "default":
				this.a = g1.d;
				return;
			case "e-resize":
				this.a = g1.g;
				return;
			case "help":
				this.a = g1.q;
				return;
			case "move":
				this.a = g1.f;
				return;
			case "ne-resize":
				this.a = g1.h;
				return;
			case "n-resize":
				this.a = g1.j;
				return;
			case "nw-resize":
				this.a = g1.i;
				return;
			case "pointer":
				this.a = g1.e;
				return;
			case "se-resize":
				this.a = g1.k;
				return;
			case "s-resize":
				this.a = g1.m;
				return;
			case "sw-resize":
				this.a = g1.l;
				return;
			case "text":
				this.a = g1.o;
				return;
			case "wait":
				this.a = g1.p;
				return;
			case "w-resize":
				this.a = g1.n;
				return;
			}
			this.a = g1.b;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0008A170 File Offset: 0x00089170
		internal g1 a()
		{
			return this.a;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0008A188 File Offset: 0x00089188
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0008A1A0 File Offset: 0x000891A0
		internal override int cv()
		{
			return 427944185;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0008A1B7 File Offset: 0x000891B7
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x040005B8 RID: 1464
		private new g1 a;

		// Token: 0x040005B9 RID: 1465
		private string b;
	}
}
