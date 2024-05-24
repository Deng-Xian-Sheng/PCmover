using System;

namespace zz93
{
	// Token: 0x02000136 RID: 310
	internal class hq : fd
	{
		// Token: 0x06000BB7 RID: 2999 RVA: 0x0008DF64 File Offset: 0x0008CF64
		internal hq()
		{
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0008DF7D File Offset: 0x0008CF7D
		internal hq(gi A_0)
		{
			this.a = new fb<f8>[3];
			this.cw(A_0);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0008DFAC File Offset: 0x0008CFAC
		internal override void cw(gi A_0)
		{
			if (A_0.x())
			{
				int a_ = A_0.y();
				this.a(A_0, a_);
			}
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0008DFDC File Offset: 0x0008CFDC
		internal fb<f8>[] a()
		{
			return this.a;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0008DFF4 File Offset: 0x0008CFF4
		internal void a(fb<f8>[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0008E000 File Offset: 0x0008D000
		internal override int cv()
		{
			return 6947816;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0008E017 File Offset: 0x0008D017
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0008E024 File Offset: 0x0008D024
		internal override bool ct()
		{
			return this.c;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0008E03C File Offset: 0x0008D03C
		internal override void cu(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0008E048 File Offset: 0x0008D048
		private void a(gi A_0, int A_1)
		{
			if (A_1 <= 389285250)
			{
				if (A_1 == 144877216)
				{
					this.a = new fb<f8>[3];
					this.b = 0;
					string text = A_0.ah();
					this.e(text);
					while (A_0.a0())
					{
						text = A_0.ah();
						this.e(text);
					}
					this.c = true;
					return;
				}
				if (A_1 == 389285250)
				{
					string text = A_0.ah();
					string text2 = text.ToLower();
					af5 af;
					if (text2 != null)
					{
						if (text2 == "inherit")
						{
							af = new af5(hp.a);
							af.d(true);
							goto IL_13B;
						}
					}
					af = new af5(this.b(text));
					IL_13B:
					this.a(A_1, af);
					return;
				}
			}
			else
			{
				if (A_1 == 430959576)
				{
					string text = A_0.ah();
					string text2 = text.ToLower();
					af6 af2;
					if (text2 != null)
					{
						if (text2 == "inherit")
						{
							af2 = new af6(ok.v);
							af2.d(true);
							goto IL_18A;
						}
					}
					af2 = new af6(this.a(text));
					IL_18A:
					this.a(A_1, af2);
					return;
				}
				if (A_1 == 514326864)
				{
					string text = A_0.ah();
					string text2 = text.ToLower();
					af4 af3;
					if (text2 != null)
					{
						if (text2 == "none")
						{
							af3 = new af4(null);
							af3.a(true);
							goto IL_EA;
						}
						if (text2 == "inherit")
						{
							af3 = new af4(null);
							af3.d(true);
							goto IL_EA;
						}
					}
					af3 = new af4(text);
					IL_EA:
					this.a(A_1, af3);
					return;
				}
			}
			A_0.ap();
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0008E1F4 File Offset: 0x0008D1F4
		private void e(string A_0)
		{
			if (string.Compare(A_0, "inherit", true) == 0)
			{
				af4 af = new af4(null);
				af5 af2 = new af5(hp.a);
				af6 af3 = new af6(ok.v);
				af.d(true);
				af2.d(true);
				af3.d(true);
				this.a(514326864, af);
				this.a(389285250, af2);
				this.a(430959576, af3);
			}
			else if (this.d(A_0))
			{
				this.a(430959576, new af6(this.a(A_0)));
			}
			else if (this.c(A_0))
			{
				this.a(389285250, new af5(this.b(A_0)));
			}
			else if (A_0.ToLower().EndsWith("gif") || A_0.ToLower().EndsWith("jpg") || A_0.ToLower().EndsWith("jpeg") || A_0.ToLower().EndsWith("png") || string.Compare(A_0, "none", true) == 0)
			{
				this.a(514326864, new af4(A_0));
			}
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0008E348 File Offset: 0x0008D348
		private bool d(string A_0)
		{
			string text = A_0.ToLower();
			switch (text)
			{
			case "armenian":
			case "circle":
			case "cjk-ideographic":
			case "decimal":
			case "decimal-leading-zero":
			case "disc":
			case "georgian":
			case "hebrew":
			case "hiragana":
			case "hiragana-iroha":
			case "katakana":
			case "katakana-iroha":
			case "lower-alpha":
			case "lower-greek":
			case "lower-latin":
			case "lower-roman":
			case "none":
			case "square":
			case "upper-alpha":
			case "upper-latin":
			case "upper-roman":
				return true;
			}
			return false;
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0008E4FC File Offset: 0x0008D4FC
		private bool c(string A_0)
		{
			string text = A_0.ToLower();
			if (text != null)
			{
				if (text == "inside" || text == "outside")
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0008E53C File Offset: 0x0008D53C
		private hp b(string A_0)
		{
			string text = A_0.ToLower();
			if (text != null)
			{
				if (text == "inside")
				{
					return hp.a;
				}
				if (text == "outside")
				{
					return hp.b;
				}
			}
			return hp.a;
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0008E580 File Offset: 0x0008D580
		private ok a(string A_0)
		{
			string text = A_0.ToLower();
			switch (text)
			{
			case "armenian":
				return ok.o;
			case "circle":
				return ok.h;
			case "cjk-ideographic":
				return ok.q;
			case "decimal":
				return ok.e;
			case "decimal-leading-zero":
				return ok.j;
			case "disc":
				return ok.f;
			case "georgian":
				return ok.p;
			case "hebrew":
				return ok.n;
			case "hiragana":
				return ok.r;
			case "hiragana-iroha":
				return ok.t;
			case "katakana":
				return ok.s;
			case "katakana-iroha":
				return ok.u;
			case "lower-alpha":
				return ok.b;
			case "lower-greek":
				return ok.k;
			case "lower-latin":
				return ok.l;
			case "lower-roman":
				return ok.d;
			case "none":
				return ok.i;
			case "square":
				return ok.g;
			case "upper-alpha":
				return ok.a;
			case "upper-latin":
				return ok.m;
			case "upper-roman":
				return ok.c;
			}
			return ok.v;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0008E794 File Offset: 0x0008D794
		private void a(int A_0, f8 A_1)
		{
			int num = this.a(A_0);
			if (num < 0)
			{
				this.a[this.b++] = new fb<f8>(A_0, A_1);
			}
			else
			{
				this.a[num].a(A_0);
				this.a[num].a(A_1);
			}
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0008E80C File Offset: 0x0008D80C
		private int a(int A_0)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a() == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0008E85C File Offset: 0x0008D85C
		private bool a(int A_0, fb<f8>[] A_1, ref int A_2)
		{
			while (A_2 < A_1.Length)
			{
				bool result;
				if (A_1[A_2].a() != 0 && A_1[A_2].a() == A_0)
				{
					result = true;
				}
				else
				{
					if (A_1[A_2].a() != 0)
					{
						A_2++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0008E8D0 File Offset: 0x0008D8D0
		private void a(fb<f8> A_0, ref hq A_1, ref int A_2)
		{
			if (!this.a(A_0.a(), A_1.a()))
			{
				A_1.a()[A_2].a(A_0.a());
				A_1.a()[A_2].a(A_0.b());
				A_1.a()[A_2].b().d(A_0.b().g());
				A_2++;
			}
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0008E95C File Offset: 0x0008D95C
		internal bool b()
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0 && this.a()[i].b().g())
				{
					result = true;
					i = this.a().Length;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0008E9CC File Offset: 0x0008D9CC
		internal hq a(hq A_0)
		{
			fb<f8>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (this.a()[i].a() == array[j].a())
						{
							if (this.a()[i].b().g() && !array[j].b().g())
							{
								this.a()[i].a(array[j].b());
								this.a()[i].b().d(false);
							}
							break;
						}
					}
				}
			}
			return this;
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0008EAD8 File Offset: 0x0008DAD8
		internal hq a(hq A_0, hq A_1)
		{
			hq hq = new hq();
			fb<f8>[] array = A_0.a();
			fb<f8>[] array2 = A_1.a();
			int num = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!this.a(array2[i].a(), array, ref num))
				{
					if (array2[i].a() != 0)
					{
						array[num].a(array2[i].a());
						array[num].a(array2[i].b());
					}
				}
				num = 0;
			}
			hq.a(array);
			return hq;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0008EB94 File Offset: 0x0008DB94
		internal bool a(int A_0, fb<f8>[] A_1)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].a() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000636 RID: 1590
		private new fb<f8>[] a;

		// Token: 0x04000637 RID: 1591
		private int b = 0;

		// Token: 0x04000638 RID: 1592
		private bool c = false;
	}
}
