using System;
using System.Collections;
using System.IO;

namespace zz93
{
	// Token: 0x02000470 RID: 1136
	internal class adn : sa
	{
		// Token: 0x06002F25 RID: 12069 RVA: 0x001AC988 File Offset: 0x001AB988
		internal adn(int[] A_0, char[] A_1, Stream A_2, byte[] A_3, int A_4) : base(A_2, A_3, A_4)
		{
			this.a = A_0;
			this.c = A_1;
			this.d = new ado[A_0.Length];
			this.b = new char[A_0.Length / 2];
			Hashtable hashtable = new Hashtable(A_0.Length);
			ado[] array = new ado[A_0.Length];
			int num = 0;
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i] >= base.p().Length)
				{
					break;
				}
				if (hashtable.ContainsKey(this.a[i]))
				{
					this.d[i] = (ado)hashtable[this.a[i]];
				}
				else
				{
					ado ado = new ado(this, (char)i, this.a[i]);
					this.d[i] = ado;
					hashtable.Add(this.a[i], ado);
					array[num++] = ado;
				}
				if (this.d[i].a())
				{
					this.a((char)i);
				}
			}
			ushort num2 = 0;
			while ((int)num2 < num - 1)
			{
				array[(int)num2].a(array[(int)(num2 + 1)].c());
				num2 += 1;
			}
			array[num - 1].a(base.p().Length);
		}

		// Token: 0x06002F26 RID: 12070 RVA: 0x001ACB18 File Offset: 0x001ABB18
		private void a(char A_0)
		{
			this.e++;
			if (this.e >= this.b.Length)
			{
				char[] array = new char[this.b.Length * 2];
				this.b.CopyTo(array, 0);
				this.b = array;
			}
			this.b[this.e] = A_0;
		}

		// Token: 0x06002F27 RID: 12071 RVA: 0x001ACB80 File Offset: 0x001ABB80
		internal void a(bool[] A_0)
		{
			for (int i = 0; i < this.e; i++)
			{
				if (A_0[(int)this.d[(int)this.b[i]].b()])
				{
					this.d[(int)this.b[i]].a(A_0);
				}
			}
		}

		// Token: 0x06002F28 RID: 12072 RVA: 0x001ACBDC File Offset: 0x001ABBDC
		internal void a(ad8 A_0, bool A_1)
		{
			if (A_1)
			{
				A_0.c()[0] = true;
				A_0.b();
				int num = A_0.e();
				Hashtable hashtable = new Hashtable();
				for (int i = 0; i < A_0.c().Length; i++)
				{
					if (A_0.c()[i] && this.a[i] != this.a[i + 1])
					{
						ado ado = this.d[i];
						if (hashtable.ContainsKey(ado))
						{
							A_0.d()[i] = (int)hashtable[ado];
						}
						else
						{
							int num2 = A_0.e() - num;
							A_0.d()[i] = num2;
							hashtable.Add(ado, num2);
							A_0.a(base.p(), ado.c(), ado.d());
						}
					}
				}
				A_0.c(A_0.e() - num);
				if (A_0.d()[A_0.d().Length - 1] < 0)
				{
					A_0.d()[A_0.d().Length - 1] = A_0.f();
				}
				A_0.a(7, num, A_0.f());
			}
			else
			{
				A_0.b();
				A_0.a(7, base.p().Length);
				A_0.a(base.p());
			}
		}

		// Token: 0x06002F29 RID: 12073 RVA: 0x001ACD50 File Offset: 0x001ABD50
		internal ado[] a()
		{
			return this.d;
		}

		// Token: 0x0400166A RID: 5738
		private new int[] a;

		// Token: 0x0400166B RID: 5739
		private char[] b;

		// Token: 0x0400166C RID: 5740
		private char[] c;

		// Token: 0x0400166D RID: 5741
		private new ado[] d;

		// Token: 0x0400166E RID: 5742
		private new int e = 0;
	}
}
