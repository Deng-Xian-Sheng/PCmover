using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000023 RID: 35
	internal class ag
	{
		// Token: 0x06000150 RID: 336 RVA: 0x00027284 File Offset: 0x00026284
		internal ag(string A_0, int A_1, bool A_2, int A_3, bool A_4)
		{
			this.a = A_0;
			this.d = A_4;
			if (A_4)
			{
				this.c = (a6)A_1;
			}
			else
			{
				this.b = (ai)A_1;
			}
			this.g = A_2;
			this.h = A_3;
			if (A_4)
			{
				switch (this.c)
				{
				case a6.a:
				case a6.b:
					this.b();
					this.a(4);
					this.f = new ah(this.a, this.g);
					break;
				case a6.c:
					this.a();
					this.e = this.c();
					this.f = new ah(this.a, this.g, this.e);
					break;
				}
			}
			else
			{
				switch (this.b)
				{
				case ai.a:
				case ai.b:
					this.b();
					this.a(4);
					this.f = new ah(this.a, this.g);
					break;
				case ai.c:
					this.a();
					this.e = this.c();
					this.f = new ah(this.a, this.g, this.e);
					break;
				}
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000273D4 File Offset: 0x000263D4
		internal bool d()
		{
			return this.g;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000273EC File Offset: 0x000263EC
		internal void a(bool A_0)
		{
			this.g = A_0;
			this.f.a(A_0);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00027404 File Offset: 0x00026404
		internal int e()
		{
			return (int)this.c;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0002741C File Offset: 0x0002641C
		internal void d(int A_0)
		{
			this.c = (a6)A_0;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00027428 File Offset: 0x00026428
		internal int f()
		{
			return this.h;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00027440 File Offset: 0x00026440
		internal void e(int A_0)
		{
			if (A_0 % 2 != 0)
			{
				throw new an("Please specify even values for segment count from 2 to 22");
			}
			this.h = A_0;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0002746C File Offset: 0x0002646C
		internal int g()
		{
			if (this.d)
			{
				switch (this.c)
				{
				case a6.a:
				case a6.b:
					return 2;
				case a6.c:
					return (this.j().Length + 1) / 2;
				}
			}
			else
			{
				switch (this.b)
				{
				case ai.a:
				case ai.b:
				case ai.c:
					return 1;
				}
			}
			return 0;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000274E0 File Offset: 0x000264E0
		internal string h()
		{
			return this.a;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000274F8 File Offset: 0x000264F8
		internal void b(string A_0)
		{
			this.a = A_0;
			this.f.b(A_0);
			this.f.b(this.c());
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00027524 File Offset: 0x00026524
		internal int i()
		{
			int result;
			switch (this.c)
			{
			case a6.a:
				result = 1;
				break;
			case a6.b:
			case a6.c:
				result = 3;
				break;
			default:
				result = 0;
				break;
			}
			return result;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0002755C File Offset: 0x0002655C
		internal BitArray[] j()
		{
			BitArray[] result = null;
			if (this.d)
			{
				switch (this.c)
				{
				case a6.a:
					result = new BitArray[]
					{
						this.f.f(),
						this.f.h(),
						this.f.g()
					};
					break;
				case a6.b:
					result = new BitArray[]
					{
						this.f.f(),
						this.f.i(),
						this.f.g()
					};
					break;
				case a6.c:
					result = this.f.b(this.h);
					break;
				}
			}
			else
			{
				switch (this.b)
				{
				case ai.a:
					result = new BitArray[]
					{
						this.f.e()
					};
					break;
				case ai.b:
					result = new BitArray[]
					{
						this.f.j()
					};
					break;
				case ai.c:
					result = new BitArray[]
					{
						this.f.k()
					};
					break;
				}
			}
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00027680 File Offset: 0x00026680
		internal float k()
		{
			if (this.d)
			{
				switch (this.c)
				{
				case a6.a:
				case a6.b:
					return 50f;
				case a6.c:
					return (float)this.f.b(this.h)[0].Length;
				}
			}
			else
			{
				switch (this.b)
				{
				case ai.a:
					return 96f;
				case ai.b:
					return 79f;
				case ai.c:
					return (float)this.f.k().Length;
				}
			}
			return 0f;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00027728 File Offset: 0x00026728
		private aj c()
		{
			int num = 0;
			aj result;
			if (!this.a.StartsWith("(01)"))
			{
				result = aj.b;
			}
			else
			{
				num += 4;
				int num2 = this.a.IndexOf('(', num);
				if (num2 > 0 && num2 < 19)
				{
					int num3 = 0;
					int.TryParse(this.a.Substring(num2 + 1, 4), out num3);
					if (num3 >= 3920 && num3 <= 3923 && this.a[num] == '9' && this.a[num2 + 5] == ')')
					{
						this.a(5);
						return aj.e;
					}
					if (num3 >= 3930 && num3 <= 3933 && this.a[num] == '9' && this.a[num2 + 5] == ')')
					{
						this.a(5);
						num += 20;
						if (this.a(this.a.Substring(num, 3)))
						{
							return aj.f;
						}
					}
					else if (num3 >= 3200 && num3 <= 3209 && this.a[num] == '9' && this.a[num2 + 5] == ')')
					{
						this.a(5);
						num += 20;
						this.b(num);
						int num4 = int.Parse(this.a.Substring(num, 6));
						num2 = this.a.IndexOf('(', num);
						if (num2 == 30)
						{
							string text = this.a.Substring(num2, 4);
							num += 10;
							if (num4 < 100000 && this.c(num) && this.a.Length == 40)
							{
								string text2 = text;
								if (text2 != null)
								{
									if (text2 == "(11)")
									{
										return aj.h;
									}
									if (text2 == "(13)")
									{
										return aj.j;
									}
									if (text2 == "(15)")
									{
										return aj.l;
									}
									if (text2 == "(17)")
									{
										return aj.n;
									}
								}
							}
						}
						if (this.a.Length == 30 && ((num3 == 3202 && num4 < 10000) || (num3 == 3203 && num4 < 22768)))
						{
							return aj.d;
						}
					}
					else if (num3 >= 3100 && num3 <= 3109 && this.a[num] == '9' && this.a[num2 + 5] == ')')
					{
						this.a(5);
						num += 20;
						this.b(num);
						int num4 = int.Parse(this.a.Substring(num, 6));
						num2 = this.a.IndexOf('(', num);
						if (num2 == 30)
						{
							string text = this.a.Substring(num2, 4);
							num += 10;
							if (num4 < 100000 && this.c(num) && this.a.Length == 40)
							{
								string text2 = text;
								if (text2 != null)
								{
									if (text2 == "(11)")
									{
										return aj.g;
									}
									if (text2 == "(13)")
									{
										return aj.i;
									}
									if (text2 == "(15)")
									{
										return aj.k;
									}
									if (text2 == "(17)")
									{
										return aj.m;
									}
								}
							}
						}
						if (num3 == 3103 && this.a.Length == 30 && num4 < 32768)
						{
							return aj.c;
						}
					}
				}
				this.a(4);
				result = aj.a;
			}
			return result;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00027B58 File Offset: 0x00026B58
		private bool c(int A_0)
		{
			string text = this.a.Substring(A_0);
			bool result;
			if (text.Length != 6)
			{
				result = false;
			}
			else
			{
				if (this.a(text))
				{
					int num = int.Parse(this.a.Substring(A_0, 2)) * 384 + (int.Parse(this.a.Substring(A_0 + 2, 2)) - 1) * 32 + int.Parse(this.a.Substring(A_0 + 4, 2));
					if (num < 38401)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00027BF4 File Offset: 0x00026BF4
		private void b(int A_0)
		{
			int i = 0;
			for (int j = A_0; j < this.a.Length; j++)
			{
				if ((byte)this.a[j] > 57 || (byte)this.a[j] < 48)
				{
					break;
				}
				i++;
				if (i == 6)
				{
					break;
				}
			}
			while (i < 6)
			{
				this.a = this.a.Insert(A_0, "0");
				i++;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00027C88 File Offset: 0x00026C88
		private bool a(string A_0)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				if ((byte)A_0[i] > 57 || (byte)A_0[i] < 48)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00027CD8 File Offset: 0x00026CD8
		private void b()
		{
			string text = string.Empty;
			bool flag = false;
			if (this.a.IndexOf("(01)") == 0)
			{
				flag = true;
				text = this.a.Substring(4);
			}
			else
			{
				text = this.a;
			}
			if (text.Length > 14)
			{
				throw new ap("Invalid data, please give correct GTIN-14 number.");
			}
			if (!this.a(text))
			{
				throw new ap("Invalid data, only digits are allowed in a GTIN-14.");
			}
			if (!flag)
			{
				this.a = "(01)" + this.a;
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00027D70 File Offset: 0x00026D70
		private void a()
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (((byte)this.a[i] < 48 || (byte)this.a[i] > 63) && ((byte)this.a[i] < 65 || (byte)this.a[i] > 90) && ((byte)this.a[i] < 97 || (byte)this.a[i] > 122) && ((byte)this.a[i] < 37 || (byte)this.a[i] > 47) && ((byte)this.a[i] < 32 || (byte)this.a[i] > 34) && (byte)this.a[i] != 95)
				{
					if ((byte)this.a[i] != 126)
					{
						throw new ap("Invalid data, some characters are not supported by the barcode.");
					}
					if (i + 1 >= this.a.Length)
					{
						throw new an("Invalid data, ~ alone is not allowed. Use ~1 to add FNC1 character.");
					}
					if ((byte)this.a[i + 1] != 49)
					{
						throw new an("Invalid data, ~ alone is not allowed. Use ~1 to add FNC1 character.");
					}
					i++;
				}
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00027ED8 File Offset: 0x00026ED8
		private void a(int A_0)
		{
			if (!this.a.StartsWith("(01)"))
			{
				throw new an("Data should start with (01)");
			}
			int num = 13;
			if (A_0 == 5)
			{
				num = 12;
			}
			int i = 0;
			for (int j = A_0; j < this.a.Length; j++)
			{
				if ((byte)this.a[j] > 57 || (byte)this.a[j] < 48)
				{
					break;
				}
				i++;
				if (i > num + 1)
				{
					break;
				}
			}
			while (i < num)
			{
				this.a = this.a.Insert(A_0, "0");
				i++;
			}
			int num2 = 0;
			for (int j = 0; j < 13; j++)
			{
				if (j % 2 == 0)
				{
					num2 += int.Parse(this.a[4 + j].ToString()) * 3;
				}
				else
				{
					num2 += int.Parse(this.a[4 + j].ToString());
				}
			}
			int num3 = (num2 % 10 > 0) ? (10 - num2 % 10) : 0;
			if (A_0 + num < this.a.Length)
			{
				if ((byte)this.a[A_0 + num] <= 57 && (byte)this.a[A_0 + num] >= 48)
				{
					if (int.Parse(this.a[A_0 + num].ToString()) != num3)
					{
						throw new ap("Wrong check digit was given");
					}
				}
				else
				{
					this.a = this.a.Insert(A_0 + num, num3.ToString());
				}
			}
			if (A_0 + num == this.a.Length)
			{
				this.a += num3.ToString();
			}
		}

		// Token: 0x040000BA RID: 186
		private string a;

		// Token: 0x040000BB RID: 187
		private ai b;

		// Token: 0x040000BC RID: 188
		private a6 c;

		// Token: 0x040000BD RID: 189
		private bool d = false;

		// Token: 0x040000BE RID: 190
		private aj e;

		// Token: 0x040000BF RID: 191
		private ah f;

		// Token: 0x040000C0 RID: 192
		private bool g;

		// Token: 0x040000C1 RID: 193
		private int h;
	}
}
