using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x02000149 RID: 329
	internal class h9
	{
		// Token: 0x06000C43 RID: 3139 RVA: 0x00090ED7 File Offset: 0x0008FED7
		internal void a(h8 A_0)
		{
			this.a.Insert(0, A_0);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x00090EE8 File Offset: 0x0008FEE8
		internal int a()
		{
			return this.a[0].b();
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x00090F0C File Offset: 0x0008FF0C
		internal ig b()
		{
			return this.b;
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00090F24 File Offset: 0x0008FF24
		internal void a(ig A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x00090F30 File Offset: 0x0008FF30
		private id a(int A_0, id A_1, id A_2, ref id A_3, ia A_4)
		{
			if (A_2 != null)
			{
				if (A_4.a() != null)
				{
					if (A_3 == null)
					{
						id id = A_4.a();
						if (id.b() > A_2.b())
						{
							while (id != null && id.b() > A_2.b())
							{
								id = id.c();
							}
						}
						if (id != null && A_2.b() == id.b())
						{
							List<int> list = this.c.b(id.a());
							foreach (int num in list)
							{
								if (num == A_0 || A_0 == 62)
								{
									A_3 = id;
									return A_1;
								}
							}
							return null;
						}
						return null;
					}
					else if (A_3.c() != null)
					{
						id id2 = A_3.c();
						if (id2.b() > A_2.b())
						{
							while (id2 != null && id2.b() > A_2.b())
							{
								id2 = id2.c();
							}
						}
						if (id2 != null)
						{
							List<int> list = this.c.b(id2.a());
							foreach (int num in list)
							{
								if (num == A_0 || A_0 == 62)
								{
									A_3 = id2;
									return A_1;
								}
							}
						}
						return null;
					}
				}
			}
			return null;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00091150 File Offset: 0x00090150
		private id b(int A_0, id A_1)
		{
			id result;
			if (A_0 == 62)
			{
				result = A_1;
			}
			else
			{
				List<int> list = this.c.b(A_1.a());
				foreach (int num in list)
				{
					if (num == A_0)
					{
						return A_1;
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x000911DC File Offset: 0x000901DC
		private id a(int A_0, id A_1)
		{
			id result;
			if (A_0 == 62)
			{
				result = A_1;
			}
			else
			{
				while (A_1 != null)
				{
					List<int> list = this.c.b(A_1.a());
					foreach (int num in list)
					{
						if (num == A_0)
						{
							return A_1;
						}
					}
					A_1 = A_1.c();
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x00091280 File Offset: 0x00090280
		internal ig a(g8 A_0, ia A_1, hl A_2)
		{
			this.c = A_2;
			id a_ = A_0.a();
			id id = A_0.a().c();
			id id2 = null;
			for (int i = 1; i < this.a.Count; i++)
			{
				ie ie = this.a[i - 1].a();
				int a_2 = this.a[i].b();
				if (ie == ie.c)
				{
					id2 = null;
					a_ = id;
					id = this.a(a_2, id);
					if (id == null)
					{
						return null;
					}
					id = id.c();
				}
				else if (ie == ie.b)
				{
					id2 = null;
					a_ = id;
					id = this.b(a_2, id);
					if (id == null)
					{
						return null;
					}
					id = id.c();
				}
				else if (ie == ie.a)
				{
					id = this.a(a_2, id, a_, ref id2, A_1);
					if (id == null)
					{
						return null;
					}
				}
				else
				{
					id = null;
				}
			}
			return this.b;
		}

		// Token: 0x04000652 RID: 1618
		private List<h8> a = new List<h8>();

		// Token: 0x04000653 RID: 1619
		private ig b = null;

		// Token: 0x04000654 RID: 1620
		private hl c = null;
	}
}
