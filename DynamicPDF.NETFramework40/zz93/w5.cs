using System;
using System.Collections;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000372 RID: 882
	internal class w5
	{
		// Token: 0x0600258B RID: 9611 RVA: 0x0015F714 File Offset: 0x0015E714
		internal w5(wd A_0, char[] A_1, int A_2, int A_3)
		{
			this.f = A_0.v();
			this.g = A_0.w();
			this.e = true;
			this.h = A_0.bc();
			this.a = A_1;
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x0600258C RID: 9612 RVA: 0x0015F772 File Offset: 0x0015E772
		internal w5(char[] A_0, int A_1, int A_2)
		{
			this.f = null;
			this.g = null;
			this.e = false;
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x0600258D RID: 9613 RVA: 0x0015F7B0 File Offset: 0x0015E7B0
		internal string a()
		{
			return this.f;
		}

		// Token: 0x0600258E RID: 9614 RVA: 0x0015F7C8 File Offset: 0x0015E7C8
		internal string b()
		{
			return this.g;
		}

		// Token: 0x0600258F RID: 9615 RVA: 0x0015F7E0 File Offset: 0x0015E7E0
		internal char c()
		{
			return this.a[this.b];
		}

		// Token: 0x06002590 RID: 9616 RVA: 0x0015F800 File Offset: 0x0015E800
		internal char[] d()
		{
			return this.a;
		}

		// Token: 0x06002591 RID: 9617 RVA: 0x0015F818 File Offset: 0x0015E818
		internal int e()
		{
			return this.b;
		}

		// Token: 0x06002592 RID: 9618 RVA: 0x0015F830 File Offset: 0x0015E830
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002593 RID: 9619 RVA: 0x0015F83A File Offset: 0x0015E83A
		internal void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06002594 RID: 9620 RVA: 0x0015F844 File Offset: 0x0015E844
		internal sz f()
		{
			return this.d;
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x0015F85C File Offset: 0x0015E85C
		internal q7 g()
		{
			char c = this.a[this.b];
			q7 result;
			if (c != '"')
			{
				if (c != '[')
				{
					if (this.p())
					{
						result = new tn(this);
					}
					else
					{
						int num = this.b;
						while (this.b < this.c && (w5.c(this.a[this.b]) || w5.a(this.a[this.b])))
						{
							this.b++;
						}
						int num2 = this.b - num;
						if (this.b == this.c)
						{
							result = new tw(new string(this.a, num, num2));
						}
						else
						{
							c = this.a[this.b];
							if (c != '(')
							{
								if (c != '.')
								{
									if (c != '[')
									{
										result = new tw(new string(this.a, num, num2));
									}
									else
									{
										result = this.b(num, num2);
									}
								}
								else
								{
									result = this.c(num, num2);
								}
							}
							else
							{
								result = this.a(num, num2);
							}
						}
					}
				}
				else
				{
					this.b++;
					int num3 = this.b;
					while (this.a[this.b] != ']')
					{
						this.b++;
					}
					int length = this.b - num3;
					this.b++;
					result = new tw(new string(this.a, num3, length));
				}
			}
			else
			{
				result = new tp(this);
			}
			return result;
		}

		// Token: 0x06002596 RID: 9622 RVA: 0x0015FA10 File Offset: 0x0015EA10
		internal bool b(bool A_0)
		{
			int i = this.b;
			bool result = false;
			bool flag = i == 0;
			if (A_0)
			{
				while (this.a[i] != '#')
				{
					if (this.a[i] == '[')
					{
						while (this.a[i] != ']')
						{
							i++;
						}
						i++;
					}
					else if (this.a[i] == '"')
					{
						i++;
						while (this.a[i] != '"')
						{
							i++;
						}
						i++;
					}
					else
					{
						if (w5.a(flag ? ' ' : this.a[i - 1], this.a[i]))
						{
							result = true;
							break;
						}
						i++;
					}
				}
			}
			else
			{
				while (i < this.c)
				{
					if (this.a[i] == '[')
					{
						while (this.a[i] != ']')
						{
							i++;
						}
						i++;
					}
					else if (this.a[i] == '"')
					{
						i++;
						while (this.a[i] != '"')
						{
							i++;
						}
						i++;
					}
					else
					{
						if (w5.a(flag ? ' ' : this.a[i - 1], this.a[i]))
						{
							result = true;
							break;
						}
						i++;
					}
				}
			}
			return result;
		}

		// Token: 0x06002597 RID: 9623 RVA: 0x0015FBC8 File Offset: 0x0015EBC8
		internal static bool a(char A_0, char A_1)
		{
			return (!w5.c(A_0) || A_1 != '(') && A_1 != ')' && rj.b(A_1);
		}

		// Token: 0x06002598 RID: 9624 RVA: 0x0015FC04 File Offset: 0x0015EC04
		internal q7 c(bool A_0)
		{
			int num = this.b;
			if (A_0)
			{
				while (this.a[num] != '#')
				{
					num++;
				}
			}
			else
			{
				num = this.c;
			}
			char[] array = new char[num - this.b];
			Array.Copy(this.a, this.b, array, 0, array.Length);
			this.b = num;
			rj rj = new rj();
			array = rj.b(array);
			w5 w = new w5(array, 0, array.Length - 1);
			w.e = this.e;
			w.g = this.g;
			w.f = this.f;
			w.h = this.h;
			w.d = this.d;
			w.i = true;
			q7 result = w.h();
			this.d = w.d;
			return result;
		}

		// Token: 0x06002599 RID: 9625 RVA: 0x0015FCF4 File Offset: 0x0015ECF4
		internal q7 h()
		{
			ArrayList arrayList = new ArrayList(3);
			while (this.b <= this.c && this.a[this.b] != ',' && this.a[this.b] != ')')
			{
				this.q();
				if (this.d(this.a[this.b]))
				{
					arrayList.Add(this.a(arrayList));
				}
				else
				{
					arrayList.Add(this.g());
				}
				if (this.b + 1 == this.a.Length)
				{
					break;
				}
			}
			return (q7)arrayList[arrayList.Count - 1];
		}

		// Token: 0x0600259A RID: 9626 RVA: 0x0015FDC4 File Offset: 0x0015EDC4
		internal bool d(char A_0)
		{
			if (A_0 <= '/')
			{
				if (A_0 == '!')
				{
					return true;
				}
				switch (A_0)
				{
				case '%':
					return true;
				case '&':
					return true;
				case '*':
					return true;
				case '+':
					return true;
				case '-':
					return true;
				case '/':
					return true;
				}
			}
			else
			{
				switch (A_0)
				{
				case '<':
					return true;
				case '=':
					return true;
				case '>':
					return true;
				default:
					switch (A_0)
					{
					case '^':
						return true;
					case '_':
						return true;
					default:
						switch (A_0)
						{
						case '|':
							return true;
						case '~':
							return true;
						}
						break;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x0600259B RID: 9627 RVA: 0x0015FE94 File Offset: 0x0015EE94
		internal q7 a(ArrayList A_0)
		{
			q7 result = null;
			char c = this.a[this.b];
			if (c <= '/')
			{
				if (c != '!')
				{
					switch (c)
					{
					case '%':
						result = new rb(A_0);
						this.b++;
						break;
					case '&':
						result = new q9(A_0);
						this.b++;
						break;
					case '*':
						result = new um(A_0);
						this.b++;
						break;
					case '+':
						result = new rg(A_0);
						this.b++;
						break;
					case '-':
						result = new u1(A_0);
						this.b++;
						break;
					case '/':
						result = new t6(A_0);
						this.b++;
						break;
					}
				}
				else if (this.b != this.c && this.a[++this.b] == '=')
				{
					result = new rd(A_0);
					this.b++;
				}
				else
				{
					result = new re(A_0);
				}
			}
			else
			{
				switch (c)
				{
				case '<':
					if (this.b != this.c && this.a[++this.b] == '=')
					{
						result = new ui(A_0);
						this.b++;
					}
					else
					{
						result = new uj(A_0);
					}
					break;
				case '=':
					result = new t7(A_0);
					this.b++;
					this.b++;
					break;
				case '>':
					if (this.b != this.c && this.a[++this.b] == '=')
					{
						result = new ub(A_0);
						this.b++;
					}
					else
					{
						result = new uc(A_0);
					}
					break;
				default:
					switch (c)
					{
					case '^':
						result = new ri(A_0);
						this.b++;
						break;
					case '_':
						result = new un(A_0);
						this.b++;
						break;
					default:
						switch (c)
						{
						case '|':
							result = new rf(A_0);
							this.b++;
							break;
						case '~':
							result = new rh(A_0);
							this.b++;
							break;
						}
						break;
					}
					break;
				}
			}
			return result;
		}

		// Token: 0x0600259C RID: 9628 RVA: 0x00160174 File Offset: 0x0015F174
		internal q7 i()
		{
			int num = this.b;
			bool a_ = true;
			int num2 = 0;
			if (this.b < this.c)
			{
				while (this.a[this.b] != '#')
				{
					this.b++;
					if (this.b > this.c)
					{
						break;
					}
				}
				num2 = this.b;
				this.b = num;
			}
			if ((this.a[num - 1] == '#' || this.a[num - 1] == ' ') && this.a[num2] == '#')
			{
				while (this.a[this.b] != '#')
				{
					if (!this.p() && this.a[this.b] != ' ')
					{
						a_ = false;
					}
					this.a(this.e() + 1);
				}
			}
			else
			{
				while (this.b < this.c)
				{
					if (!this.p() && this.a[this.b] != ' ')
					{
						a_ = false;
					}
					this.a(this.e() + 1);
				}
			}
			return new tw(new string(this.a, num, this.b - num), a_);
		}

		// Token: 0x0600259D RID: 9629 RVA: 0x001602F0 File Offset: 0x0015F2F0
		internal q7 j()
		{
			char c = this.a[this.b];
			q7 result;
			if (c != '"')
			{
				result = new x4(this.a, this.b, this.c);
			}
			else
			{
				result = new x4(this.a, this.b, this.c);
			}
			return result;
		}

		// Token: 0x0600259E RID: 9630 RVA: 0x00160348 File Offset: 0x0015F348
		internal string b(int A_0)
		{
			return new string(this.a, A_0, this.c - A_0);
		}

		// Token: 0x0600259F RID: 9631 RVA: 0x00160370 File Offset: 0x0015F370
		private int d(int A_0, int A_1)
		{
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < A_1; i++)
			{
				num2 <<= 5;
				num2 |= (int)(this.a[A_0 + i] % ' ');
				if (i % 6 == 5)
				{
					num ^= num2;
					num2 = 0;
				}
			}
			if (i % 6 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x060025A0 RID: 9632 RVA: 0x001603D8 File Offset: 0x0015F3D8
		internal int k()
		{
			this.q();
			int num = this.b;
			while (w5.c(this.a[this.b]))
			{
				this.b++;
			}
			int num2 = this.b;
			this.q();
			return this.d(num, num2 - num);
		}

		// Token: 0x060025A1 RID: 9633 RVA: 0x00160438 File Offset: 0x0015F438
		internal string l()
		{
			this.q();
			int num = this.b;
			while (w5.c(this.a[this.b]))
			{
				this.b++;
			}
			int num2 = this.b;
			this.q();
			return new string(this.a, num, num2 - num);
		}

		// Token: 0x060025A2 RID: 9634 RVA: 0x0016049C File Offset: 0x0015F49C
		internal int m()
		{
			this.q();
			int num = (int)(this.a[this.b] - '0');
			this.b++;
			while (w5.b(this.a[this.b]))
			{
				num *= 10;
				num += (int)(this.a[this.b] - '0');
				this.b++;
			}
			this.q();
			return num;
		}

		// Token: 0x060025A3 RID: 9635 RVA: 0x0016051C File Offset: 0x0015F51C
		private q7 c(int A_0, int A_1)
		{
			if ((this.a[A_0] == 'G' || this.a[A_0] == 'g') && A_1 == 6 && (this.a[A_0 + 1] == 'l' || this.a[A_0 + 1] == 'L') && (this.a[A_0 + 2] == 'o' || this.a[A_0 + 2] == 'O') && (this.a[A_0 + 3] == 'b' || this.a[A_0 + 3] == 'B') && (this.a[A_0 + 4] == 'a' || this.a[A_0 + 4] == 'A') && (this.a[A_0 + 5] == 'l' || this.a[A_0 + 5] == 'L'))
			{
				return this.n();
			}
			throw new DplxParseException("Invalid object variable.");
		}

		// Token: 0x060025A4 RID: 9636 RVA: 0x00160600 File Offset: 0x0015F600
		internal q7 n()
		{
			this.b++;
			this.q();
			int num = this.b;
			while (w5.c(this.a[this.b]))
			{
				this.b++;
			}
			int a_ = this.b - num;
			if (this.a[this.b] == '[')
			{
				if (u7.a(this.a, num, a_))
				{
					return new u7(this);
				}
				if (u8.a(this.a, num, a_))
				{
					throw new DplxParseException("The ConnectionStrings indexer can only be used in a query's connectionString attribute.");
				}
			}
			throw new DplxParseException("Invalid Report variable.");
		}

		// Token: 0x060025A5 RID: 9637 RVA: 0x001606C0 File Offset: 0x0015F6C0
		private q7 b(int A_0, int A_1)
		{
			q7 result;
			if (u9.a(this.a, A_0, A_1))
			{
				result = new u9(this);
			}
			else if (vb.a(this.a, A_0, A_1))
			{
				result = new vb(this);
			}
			else
			{
				result = new va(new string(this.a, A_0, A_1), this);
			}
			return result;
		}

		// Token: 0x060025A6 RID: 9638 RVA: 0x00160724 File Offset: 0x0015F724
		private q7 a(int A_0, int A_1)
		{
			q7 result;
			if (t1.a(this.a, A_0, A_1))
			{
				result = new t1(this);
			}
			else if (t9.a(this.a, A_0, A_1))
			{
				result = new t9(this);
			}
			else if (ty.a(this.a, A_0, A_1))
			{
				result = new ty(this);
			}
			else if (um.a(this.a, A_0, A_1))
			{
				result = new um(this);
			}
			else if (u1.a(this.a, A_0, A_1))
			{
				result = new u1(this);
			}
			else if (t6.a(this.a, A_0, A_1))
			{
				result = new t6(this);
			}
			else if (ug.a(this.a, A_0, A_1))
			{
				result = new ug(this);
			}
			else if (uu.a(this.a, A_0, A_1))
			{
				result = new uu(this);
			}
			else if (t0.a(this.a, A_0, A_1))
			{
				result = new t0(this);
			}
			else if (u0.a(this.a, A_0, A_1))
			{
				result = new u0(this);
			}
			else if (uh.a(this.a, A_0, A_1))
			{
				result = new uh(this);
			}
			else if (u4.a(this.a, A_0, A_1))
			{
				result = new u4(this);
			}
			else if (u3.a(this.a, A_0, A_1))
			{
				result = new u3(this);
			}
			else if (u2.a(this.a, A_0, A_1))
			{
				result = new u2(this);
			}
			else if (uz.a(this.a, A_0, A_1))
			{
				result = new uz(this);
			}
			else if (ut.a(this.a, A_0, A_1))
			{
				result = new ut(this);
			}
			else if (uy.a(this.a, A_0, A_1))
			{
				result = new uy(this);
			}
			else if (up.a(this.a, A_0, A_1))
			{
				result = new up(this);
			}
			else if (t8.a(this.a, A_0, A_1))
			{
				result = new t8(this);
			}
			else if (tz.a(this.a, A_0, A_1))
			{
				result = new tz(this);
			}
			else if (un.a(this.a, A_0, A_1))
			{
				result = new un(this);
			}
			else if (uv.a(this.a, A_0, A_1))
			{
				result = new uv(this);
			}
			else if (tx.a(this.a, A_0, A_1))
			{
				result = new tx(this);
			}
			else if (ux.a(this.a, A_0, A_1))
			{
				result = new ux(this);
			}
			else if (u6.a(this.a, A_0, A_1))
			{
				result = new u6(this);
			}
			else if (ul.a(this.a, A_0, A_1))
			{
				result = new ul(this);
			}
			else if (t5.a(this.a, A_0, A_1))
			{
				result = new t5(this);
			}
			else if (ud.a(this.a, A_0, A_1))
			{
				result = new ud(this);
			}
			else if (uk.a(this.a, A_0, A_1))
			{
				result = new uk(this);
			}
			else if (uw.a(this.a, A_0, A_1))
			{
				result = new uw(this);
			}
			else if (u5.a(this.a, A_0, A_1))
			{
				result = new u5(this);
			}
			else if (t2.a(this.a, A_0, A_1))
			{
				result = new t2(this);
			}
			else if (t3.a(this.a, A_0, A_1))
			{
				result = new t3(this);
			}
			else if (uc.a(this.a, A_0, A_1))
			{
				result = new uc(this);
			}
			else if (uj.a(this.a, A_0, A_1))
			{
				result = new uj(this);
			}
			else if (t7.a(this.a, A_0, A_1))
			{
				result = new t7(this);
			}
			else if (ub.a(this.a, A_0, A_1))
			{
				result = new ub(this);
			}
			else if (ui.a(this.a, A_0, A_1))
			{
				result = new ui(this);
			}
			else if (uf.a(this.a, A_0, A_1))
			{
				result = new uf(this);
			}
			else if (ue.a(this.a, A_0, A_1))
			{
				result = new ue(this);
			}
			else if (us.a(this.a, A_0, A_1))
			{
				result = new us(this);
			}
			else if (uo.a(this.a, A_0, A_1))
			{
				result = new uo(this);
			}
			else if (uq.a(this.a, A_0, A_1))
			{
				result = new uq(this);
			}
			else if (ua.a(this.a, A_0, A_1))
			{
				result = new ua(this);
			}
			else if (q9.a(this.a, A_0, A_1))
			{
				result = new q9(this);
			}
			else if (rb.a(this.a, A_0, A_1))
			{
				result = new rb(this);
			}
			else if (rd.a(this.a, A_0, A_1))
			{
				result = new rd(this);
			}
			else if (re.a(this.a, A_0, A_1))
			{
				result = new re(this);
			}
			else if (rf.a(this.a, A_0, A_1))
			{
				result = new rf(this);
			}
			else if (rh.a(this.a, A_0, A_1))
			{
				result = new rh(this);
			}
			else if (ri.a(this.a, A_0, A_1))
			{
				result = new ri(this);
			}
			else
			{
				if (!this.e)
				{
					throw new DplxParseException("Aggregate functions are not allowed in this context.");
				}
				if (tj.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new tj(this);
				}
				else if (s0.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new s0(this);
				}
				else if (s9.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new s9(this);
				}
				else if (s3.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new s3(this);
				}
				else if (s5.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new s5(this);
				}
				else if (tb.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new tb(this);
				}
				else if (tf.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new tf(this);
				}
				else if (s7.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new s7(this);
				}
				else if (td.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new td(this);
				}
				else
				{
					if (!th.a(this.a, A_0, A_1))
					{
						throw new DplxParseException("Invalid function.");
					}
					if (this.d == null)
					{
						this.d = new sz();
					}
					result = new th(this);
				}
			}
			return result;
		}

		// Token: 0x060025A7 RID: 9639 RVA: 0x00161036 File Offset: 0x00160036
		internal void o()
		{
			this.b++;
		}

		// Token: 0x060025A8 RID: 9640 RVA: 0x00161048 File Offset: 0x00160048
		internal bool p()
		{
			return w5.b(this.a[this.b]);
		}

		// Token: 0x060025A9 RID: 9641 RVA: 0x0016106C File Offset: 0x0016006C
		private static bool c(char A_0)
		{
			return A_0 <= 'z' && (A_0 >= 'a' || (A_0 <= 'Z' && (A_0 >= 'A' || (A_0 <= '9' && A_0 >= '0'))));
		}

		// Token: 0x060025AA RID: 9642 RVA: 0x001610D8 File Offset: 0x001600D8
		private static bool b(char A_0)
		{
			return A_0 <= '9' && A_0 >= '0';
		}

		// Token: 0x060025AB RID: 9643 RVA: 0x00161108 File Offset: 0x00160108
		private static bool a(char A_0)
		{
			return A_0 == '_';
		}

		// Token: 0x060025AC RID: 9644 RVA: 0x0016112C File Offset: 0x0016012C
		internal void q()
		{
			while (this.a[this.b] <= ' ')
			{
				this.b++;
			}
		}

		// Token: 0x060025AD RID: 9645 RVA: 0x00161164 File Offset: 0x00160164
		internal void r()
		{
			while (this.a[this.b] != '"')
			{
				this.b++;
			}
		}

		// Token: 0x060025AE RID: 9646 RVA: 0x0016119C File Offset: 0x0016019C
		internal void s()
		{
			while (this.a[this.b] != ']')
			{
				this.b++;
			}
		}

		// Token: 0x060025AF RID: 9647 RVA: 0x001611D4 File Offset: 0x001601D4
		internal void t()
		{
			while (this.a[this.b] != '.')
			{
				this.b++;
			}
		}

		// Token: 0x060025B0 RID: 9648 RVA: 0x0016120C File Offset: 0x0016020C
		internal bool u()
		{
			return this.b < this.c;
		}

		// Token: 0x060025B1 RID: 9649 RVA: 0x0016122C File Offset: 0x0016022C
		internal bool v()
		{
			return this.b >= this.c;
		}

		// Token: 0x060025B2 RID: 9650 RVA: 0x00161250 File Offset: 0x00160250
		internal bool w()
		{
			return this.i;
		}

		// Token: 0x060025B3 RID: 9651 RVA: 0x00161268 File Offset: 0x00160268
		internal char c(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060025B4 RID: 9652 RVA: 0x00161284 File Offset: 0x00160284
		internal int x()
		{
			return this.c;
		}

		// Token: 0x060025B5 RID: 9653 RVA: 0x0016129C File Offset: 0x0016029C
		internal bool y()
		{
			return this.h;
		}

		// Token: 0x060025B6 RID: 9654 RVA: 0x001612B4 File Offset: 0x001602B4
		internal void d(bool A_0)
		{
			this.h = A_0;
		}

		// Token: 0x0400108B RID: 4235
		private char[] a;

		// Token: 0x0400108C RID: 4236
		private int b;

		// Token: 0x0400108D RID: 4237
		private int c;

		// Token: 0x0400108E RID: 4238
		private sz d;

		// Token: 0x0400108F RID: 4239
		private bool e;

		// Token: 0x04001090 RID: 4240
		private string f;

		// Token: 0x04001091 RID: 4241
		private string g;

		// Token: 0x04001092 RID: 4242
		private bool h;

		// Token: 0x04001093 RID: 4243
		private bool i = false;
	}
}
