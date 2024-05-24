using System;
using System.Reflection;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000263 RID: 611
	[DefaultMember("Item")]
	internal class p1
	{
		// Token: 0x06001BA6 RID: 7078 RVA: 0x0011D8B8 File Offset: 0x0011C8B8
		internal p1()
		{
			os os = this.a;
			os a_;
			this.a.b(a_ = this.a);
			os.a(a_);
		}

		// Token: 0x06001BA7 RID: 7079 RVA: 0x0011D904 File Offset: 0x0011C904
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06001BA8 RID: 7080 RVA: 0x0011D91C File Offset: 0x0011C91C
		internal d0 a(int A_0)
		{
			return this.d(A_0).a();
		}

		// Token: 0x06001BA9 RID: 7081 RVA: 0x0011D93A File Offset: 0x0011C93A
		internal void a(int A_0, d0 A_1)
		{
			this.d(A_0).a(A_1);
		}

		// Token: 0x06001BAA RID: 7082 RVA: 0x0011D94B File Offset: 0x0011C94B
		internal void a(d0 A_0)
		{
			this.b(this.b, A_0);
		}

		// Token: 0x06001BAB RID: 7083 RVA: 0x0011D95C File Offset: 0x0011C95C
		internal p1 b()
		{
			p1 p = new p1();
			if (this.a() > 0)
			{
				for (os os = this.a.b(); os != this.a; os = os.b())
				{
					p.a(os.a());
				}
			}
			return p;
		}

		// Token: 0x06001BAC RID: 7084 RVA: 0x0011D9BC File Offset: 0x0011C9BC
		internal void c()
		{
			this.c++;
			os os = this.a;
			os a_;
			this.a.b(a_ = this.a);
			os.a(a_);
			this.b = 0;
		}

		// Token: 0x06001BAD RID: 7085 RVA: 0x0011DA00 File Offset: 0x0011CA00
		internal d0 d()
		{
			d0 result = null;
			if (this.b > 0)
			{
				result = this.a(this.b - 1);
			}
			return result;
		}

		// Token: 0x06001BAE RID: 7086 RVA: 0x0011DA38 File Offset: 0x0011CA38
		internal bool b(d0 A_0)
		{
			return 0 <= this.c(A_0);
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x0011DA58 File Offset: 0x0011CA58
		internal int c(d0 A_0)
		{
			int num = 0;
			if (A_0 == null)
			{
				for (os os = this.a.b(); os != this.a; os = os.b())
				{
					if (os.a() == null)
					{
						break;
					}
					num++;
				}
			}
			else
			{
				for (os os = this.a.b(); os != this.a; os = os.b())
				{
					if (A_0.Equals(os.a()))
					{
						break;
					}
					num++;
				}
			}
			if (this.b <= num)
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x0011DB0C File Offset: 0x0011CB0C
		internal void b(int A_0, d0 A_1)
		{
			os os;
			if (A_0 == this.b)
			{
				os = new os(A_1, this.a, this.a.c());
			}
			else
			{
				os os2 = this.d(A_0);
				os = new os(A_1, os2, os2.c());
			}
			os.c().a(os);
			os.b().b(os);
			this.b++;
			this.c++;
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x0011DB94 File Offset: 0x0011CB94
		internal void b(int A_0)
		{
			for (os os = this.a.c(); os != this.a; os = os.c())
			{
				if (os.a().cn() == A_0)
				{
					this.a(os);
					break;
				}
			}
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x0011DBEC File Offset: 0x0011CBEC
		internal void d(d0 A_0)
		{
			if (A_0 == null)
			{
				for (os os = this.a.b(); os != this.a; os = os.b())
				{
					if (os.a() == null)
					{
						this.a(os);
					}
				}
			}
			else
			{
				for (os os = this.a.b(); os != this.a; os = os.b())
				{
					if (A_0.Equals(os.a()))
					{
						this.a(os);
					}
				}
			}
		}

		// Token: 0x06001BB3 RID: 7091 RVA: 0x0011DC88 File Offset: 0x0011CC88
		internal void c(int A_0)
		{
			this.a(this.d(A_0));
		}

		// Token: 0x06001BB4 RID: 7092 RVA: 0x0011DC9C File Offset: 0x0011CC9C
		internal void a(os A_0)
		{
			if (A_0 != this.a)
			{
				A_0.c().a(A_0.b());
				A_0.b().b(A_0.c());
				this.b--;
				this.c++;
			}
		}

		// Token: 0x06001BB5 RID: 7093 RVA: 0x0011DCFC File Offset: 0x0011CCFC
		internal os d(int A_0)
		{
			if (A_0 < 0 || this.b <= A_0)
			{
				throw new GeneratorException("Index out of bounds.");
			}
			os os = this.a;
			if (A_0 < this.b / 2)
			{
				for (int i = 0; i <= A_0; i++)
				{
					os = os.b();
				}
			}
			else
			{
				for (int i = this.b; i > A_0; i--)
				{
					os = os.c();
				}
			}
			return os;
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x0011DD84 File Offset: 0x0011CD84
		internal bool e(int A_0)
		{
			os os = this.a.b();
			while (os.a() != null)
			{
				if (os.a().cn() == A_0)
				{
					return true;
				}
				os = os.b();
			}
			return false;
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x0011DDD8 File Offset: 0x0011CDD8
		internal p2 e()
		{
			return new p2(this);
		}

		// Token: 0x04000C84 RID: 3204
		internal os a = new os(null, null, null);

		// Token: 0x04000C85 RID: 3205
		private int b = 0;

		// Token: 0x04000C86 RID: 3206
		internal int c;
	}
}
