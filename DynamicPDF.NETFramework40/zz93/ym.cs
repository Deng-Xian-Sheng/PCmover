using System;
using System.Reflection;
using ceTe.DynamicPDF.Imaging;

namespace zz93
{
	// Token: 0x020003AC RID: 940
	[DefaultMember("Item")]
	internal class ym
	{
		// Token: 0x060027E3 RID: 10211 RVA: 0x0016D65C File Offset: 0x0016C65C
		internal ym(byte[] A_0, int A_1, int A_2, bool A_3, int A_4)
		{
			this.a = A_0;
			this.g = A_1;
			this.i = A_2;
			this.w = A_3;
			this.ab = A_4;
			if (A_3)
			{
				this.m();
			}
			this.n();
			this.x = this.b;
			this.y = this.c;
			this.b = this.t;
			this.c = this.u;
		}

		// Token: 0x060027E4 RID: 10212 RVA: 0x0016D74C File Offset: 0x0016C74C
		internal int o()
		{
			return this.s;
		}

		// Token: 0x060027E5 RID: 10213 RVA: 0x0016D764 File Offset: 0x0016C764
		internal int d(int A_0)
		{
			return this.r[A_0];
		}

		// Token: 0x060027E6 RID: 10214 RVA: 0x0016D780 File Offset: 0x0016C780
		internal bool p()
		{
			return this.z;
		}

		// Token: 0x060027E7 RID: 10215 RVA: 0x0016D798 File Offset: 0x0016C798
		internal int q()
		{
			return this.aa;
		}

		// Token: 0x060027E8 RID: 10216 RVA: 0x0016D7B0 File Offset: 0x0016C7B0
		internal byte e(int A_0)
		{
			this.c += A_0;
			int num;
			if (this.c == 8)
			{
				num = (int)this.a[this.b];
				this.c = 0;
				this.b++;
			}
			else if (this.c < 8)
			{
				num = this.a[this.b] >> 8 - this.c;
			}
			else
			{
				this.c -= 8;
				this.b++;
				num = (this.a[this.b] >> 8 - this.c | (int)this.a[this.b - 1] << this.c);
			}
			return (byte)(num & 255 >> 8 - A_0);
		}

		// Token: 0x060027E9 RID: 10217 RVA: 0x0016D89C File Offset: 0x0016C89C
		internal int a(byte[] A_0, int A_1)
		{
			int result;
			if (this.c == 0)
			{
				int num = this.x - this.b;
				if (num > 0)
				{
					Array.Copy(this.a, this.b, A_0, A_1, num);
					A_1 += num;
				}
				if (this.y != 0)
				{
					A_0[A_1++] = (byte)((int)this.a[this.x] & 255 << 8 - this.y);
				}
				result = num * 8 + this.y;
			}
			else
			{
				int num = this.x - this.b;
				int num2 = this.c;
				int num3 = 8 - this.c;
				int i;
				for (i = this.b; i < this.x; i++)
				{
					A_0[A_1++] = (byte)((int)this.a[i] << num2 | this.a[i + 1] >> num3);
				}
				A_0[A_1++] = (byte)(this.a[i] << num2);
				result = num * 8 + this.y + num3 - 8;
			}
			return result;
		}

		// Token: 0x060027EA RID: 10218 RVA: 0x0016D9D0 File Offset: 0x0016C9D0
		private void n()
		{
			int num = this.a.Length - 1;
			while (this.a[num] == 0)
			{
				num--;
			}
			byte b = this.a[num];
			if (b <= 16)
			{
				switch (b)
				{
				case 1:
					if (num > 2 && (this.a[num - 1] == 16 || this.a[num - 2] == 0) && this.ab != 1)
					{
						this.c = 0;
						this.b = num - 2;
						return;
					}
					break;
				case 2:
					if (num > 3 && (this.a[num - 1] == 32 || this.a[num - 2] == 0) && (this.a[num - 3] | 254) == 254 && this.ab != 1)
					{
						this.c = 7;
						this.b = num - 3;
						return;
					}
					break;
				case 3:
					break;
				case 4:
					if (num > 3 && (this.a[num - 1] == 64 || this.a[num - 2] == 0) && (this.a[num - 3] | 252) == 252 && this.ab != 1)
					{
						this.c = 6;
						this.b = num - 3;
						return;
					}
					break;
				default:
					if (b != 8)
					{
						if (b == 16)
						{
							if (num > 3 && (this.a[num - 1] == 0 || this.a[num - 2] == 1) && (this.a[num - 3] | 240) == 240 && this.ab != 1)
							{
								this.c = 4;
								this.b = num - 3;
								return;
							}
						}
					}
					else if (num > 3 && (this.a[num - 1] == 128 || this.a[num - 2] == 0) && (this.a[num - 3] | 248) == 248 && this.ab != 1)
					{
						this.c = 5;
						this.b = num - 3;
						return;
					}
					break;
				}
			}
			else if (b != 32)
			{
				if (b != 64)
				{
					if (b == 128)
					{
						if (num > 3 && (this.a[num - 1] == 0 || this.a[num - 2] == 8) && (this.a[num - 3] | 128) == 128 && this.ab != 1)
						{
							this.c = 1;
							this.b = num - 3;
							return;
						}
					}
				}
				else if (num > 3 && (this.a[num - 1] == 0 || this.a[num - 2] == 4) && (this.a[num - 3] | 192) == 192 && this.ab != 1)
				{
					this.c = 2;
					this.b = num - 3;
					return;
				}
			}
			else if (num > 3 && (this.a[num - 1] == 0 || this.a[num - 2] == 2) && (this.a[num - 3] | 224) == 224 && this.ab != 1)
			{
				this.c = 3;
				this.b = num - 3;
				return;
			}
			this.l();
		}

		// Token: 0x060027EB RID: 10219 RVA: 0x0016DD58 File Offset: 0x0016CD58
		private void m()
		{
			if (this.r == null)
			{
				this.m = new int[2];
				this.o = 2;
				this.m[0] = this.g;
				this.m[1] = 0;
				this.k();
				while (this.m[this.o - 1] == 0 && this.m[this.o - 2] == 0)
				{
					this.o -= 2;
				}
				this.r = this.m;
				this.s = this.o;
				if (this.w)
				{
					this.t = this.b;
					this.u = this.c;
				}
			}
		}

		// Token: 0x060027EC RID: 10220 RVA: 0x0016DE24 File Offset: 0x0016CE24
		private void l()
		{
			this.m();
			while (this.j < this.i)
			{
				this.k();
			}
		}

		// Token: 0x060027ED RID: 10221 RVA: 0x0016DE54 File Offset: 0x0016CE54
		private void k()
		{
			this.n = this.m;
			this.p = 1;
			this.k = this.n[0];
			this.m = new int[16];
			this.o = 0;
			this.k = this.n[0];
			this.p = 1;
			this.l = 0;
			while (this.l < this.g)
			{
				this.i();
				this.j();
			}
			if (!this.h)
			{
				this.a(0);
			}
			if (this.l != this.g)
			{
				throw new ImageParsingException("Invalid Group4 Fax Line. Invalid line width.");
			}
			this.j++;
		}

		// Token: 0x060027EE RID: 10222 RVA: 0x0016DF14 File Offset: 0x0016CF14
		private void j()
		{
			while (this.k <= this.l && this.k < this.g)
			{
				this.k += this.n[this.p++];
				if (this.k < this.g)
				{
					this.k += this.n[this.p++];
				}
			}
		}

		// Token: 0x060027EF RID: 10223 RVA: 0x0016DFAC File Offset: 0x0016CFAC
		private void i()
		{
			this.b();
			this.c();
			if (this.d == 1)
			{
				this.c(0);
			}
			else
			{
				this.c();
				this.c();
				switch (this.d)
				{
				case 2:
					this.c(-1);
					return;
				case 4:
					this.h();
					return;
				case 6:
					this.c(1);
					return;
				}
				this.c();
				if (this.d == 8)
				{
					this.e();
				}
				else
				{
					this.c();
					this.c();
					int num = this.d;
					if (num != 16)
					{
						if (num != 48)
						{
							this.c();
							num = this.d;
							if (num != 32)
							{
								if (num != 96)
								{
									this.c();
									this.c();
									this.c();
									if (this.d == 960)
									{
										this.d();
									}
									else
									{
										if (this.d != 0)
										{
											throw new ImageParsingException("Invalid Group4 Fax Mode Mark");
										}
										this.z = true;
										this.aa = this.j;
										this.j = this.i;
										this.l = this.g;
									}
								}
								else
								{
									this.c(3);
								}
							}
							else
							{
								this.c(-3);
							}
						}
						else
						{
							this.c(2);
						}
					}
					else
					{
						this.c(-2);
					}
				}
			}
		}

		// Token: 0x060027F0 RID: 10224 RVA: 0x0016E150 File Offset: 0x0016D150
		private void c(int A_0)
		{
			int num = this.k - this.l + A_0;
			this.a(num - this.q);
			if (this.p > 0)
			{
				this.k -= this.n[--this.p];
			}
			else
			{
				this.k += this.n[this.p++];
			}
		}

		// Token: 0x060027F1 RID: 10225 RVA: 0x0016E1E0 File Offset: 0x0016D1E0
		private void h()
		{
			if (this.h)
			{
				this.g();
				this.f();
			}
			else
			{
				this.f();
				this.g();
			}
		}

		// Token: 0x060027F2 RID: 10226 RVA: 0x0016E220 File Offset: 0x0016D220
		private void g()
		{
			this.b();
			this.c();
			this.c();
			this.c();
			this.c();
			int num = this.d;
			switch (num)
			{
			case 1:
				this.a(3);
				return;
			case 2:
				break;
			case 3:
				this.a(5);
				return;
			default:
				if (num == 7)
				{
					this.a(6);
					return;
				}
				switch (num)
				{
				case 13:
					this.a(4);
					return;
				case 14:
					this.a(2);
					return;
				case 15:
					this.a(7);
					return;
				}
				break;
			}
			this.c();
			num = this.d;
			if (num <= 5)
			{
				if (num == 2)
				{
					this.a(11);
					return;
				}
				if (num == 5)
				{
					this.a(9);
					return;
				}
			}
			else
			{
				if (num == 9)
				{
					this.b(128);
					return;
				}
				switch (num)
				{
				case 25:
					this.a(8);
					return;
				case 27:
					this.b(64);
					return;
				case 28:
					this.a(10);
					return;
				}
			}
			this.c();
			num = this.d;
			if (num <= 21)
			{
				switch (num)
				{
				case 4:
					this.a(12);
					return;
				case 5:
					break;
				case 6:
					this.b(1664);
					return;
				default:
					if (num == 11)
					{
						this.a(14);
						return;
					}
					if (num == 21)
					{
						this.a(16);
						return;
					}
					break;
				}
			}
			else if (num <= 48)
			{
				if (num == 43)
				{
					this.a(15);
					return;
				}
				if (num == 48)
				{
					this.a(13);
					return;
				}
			}
			else
			{
				if (num == 53)
				{
					this.a(17);
					return;
				}
				switch (num)
				{
				case 56:
					this.a(1);
					return;
				case 58:
					this.b(192);
					return;
				}
			}
			this.c();
			num = this.d;
			if (num <= 24)
			{
				switch (num)
				{
				case 8:
					this.a(20);
					return;
				case 9:
				case 11:
					break;
				case 10:
					this.a(24);
					return;
				case 12:
					this.a(28);
					return;
				default:
					switch (num)
					{
					case 16:
						this.a(23);
						return;
					case 17:
						break;
					case 18:
						this.a(27);
						return;
					default:
						if (num == 24)
						{
							this.a(19);
							return;
						}
						break;
					}
					break;
				}
			}
			else if (num <= 100)
			{
				if (num == 96)
				{
					this.a(22);
					return;
				}
				if (num == 100)
				{
					this.a(26);
					return;
				}
			}
			else
			{
				if (num == 106)
				{
					this.a(25);
					return;
				}
				switch (num)
				{
				case 114:
					this.a(18);
					return;
				case 116:
					this.a(21);
					return;
				case 118:
					this.b(256);
					return;
				}
			}
			this.c();
			num = this.d;
			if (num <= 108)
			{
				if (num <= 52)
				{
					if (num <= 26)
					{
						switch (num)
						{
						case 20:
							this.a(39);
							return;
						case 21:
							break;
						case 22:
							this.b(576);
							return;
						default:
							if (num == 26)
							{
								this.a(55);
								return;
							}
							break;
						}
					}
					else
					{
						if (num == 32)
						{
							this.a(45);
							return;
						}
						switch (num)
						{
						case 36:
							this.a(53);
							return;
						case 37:
						case 39:
						case 41:
						case 43:
							break;
						case 38:
							this.b(448);
							return;
						case 40:
							this.a(35);
							return;
						case 42:
							this.a(51);
							return;
						case 44:
							this.a(63);
							return;
						default:
							if (num == 52)
							{
								this.a(43);
								return;
							}
							break;
						}
					}
				}
				else if (num <= 84)
				{
					if (num == 64)
					{
						this.a(29);
						return;
					}
					switch (num)
					{
					case 72:
						this.a(33);
						return;
					case 73:
					case 75:
						break;
					case 74:
						this.a(49);
						return;
					case 76:
						this.a(61);
						return;
					default:
						switch (num)
						{
						case 80:
							this.a(47);
							return;
						case 82:
							this.a(59);
							return;
						case 84:
							this.a(41);
							return;
						}
						break;
					}
				}
				else
				{
					switch (num)
					{
					case 88:
						this.a(31);
						return;
					case 89:
						break;
					case 90:
						this.a(57);
						return;
					default:
						if (num == 104)
						{
							this.a(37);
							return;
						}
						if (num == 108)
						{
							this.b(320);
							return;
						}
						break;
					}
				}
			}
			else if (num <= 180)
			{
				if (num <= 154)
				{
					if (num == 148)
					{
						this.a(40);
						return;
					}
					if (num == 154)
					{
						this.a(56);
						return;
					}
				}
				else
				{
					if (num == 160)
					{
						this.a(46);
						return;
					}
					switch (num)
					{
					case 164:
						this.a(54);
						return;
					case 165:
					case 167:
					case 169:
					case 171:
						break;
					case 166:
						this.b(512);
						return;
					case 168:
						this.a(36);
						return;
					case 170:
						this.a(52);
						return;
					case 172:
						this.a(0);
						return;
					default:
						if (num == 180)
						{
							this.a(44);
							return;
						}
						break;
					}
				}
			}
			else if (num <= 212)
			{
				if (num == 192)
				{
					this.a(30);
					return;
				}
				switch (num)
				{
				case 200:
					this.a(34);
					return;
				case 201:
				case 203:
					break;
				case 202:
					this.a(50);
					return;
				case 204:
					this.a(62);
					return;
				default:
					switch (num)
					{
					case 208:
						this.a(48);
						return;
					case 210:
						this.a(60);
						return;
					case 212:
						this.a(42);
						return;
					}
					break;
				}
			}
			else
			{
				switch (num)
				{
				case 216:
					this.a(32);
					return;
				case 217:
					break;
				case 218:
					this.a(58);
					return;
				default:
					switch (num)
					{
					case 230:
						this.b(640);
						return;
					case 231:
						break;
					case 232:
						this.a(38);
						return;
					default:
						if (num == 236)
						{
							this.b(384);
							return;
						}
						break;
					}
					break;
				}
			}
			this.c();
			num = this.d;
			if (num <= 214)
			{
				if (num <= 102)
				{
					if (num <= 54)
					{
						if (num == 50)
						{
							this.b(1472);
							return;
						}
						if (num == 54)
						{
							this.b(1216);
							return;
						}
					}
					else
					{
						if (num == 86)
						{
							this.b(960);
							return;
						}
						if (num == 102)
						{
							this.b(704);
							return;
						}
					}
				}
				else if (num <= 178)
				{
					if (num == 150)
					{
						this.b(832);
						return;
					}
					if (num == 178)
					{
						this.b(1600);
						return;
					}
				}
				else
				{
					if (num == 182)
					{
						this.b(1344);
						return;
					}
					if (num == 214)
					{
						this.b(1088);
						return;
					}
				}
			}
			else if (num <= 358)
			{
				if (num <= 310)
				{
					if (num == 306)
					{
						this.b(1536);
						return;
					}
					if (num == 310)
					{
						this.b(1280);
						return;
					}
				}
				else
				{
					if (num == 342)
					{
						this.b(1024);
						return;
					}
					if (num == 358)
					{
						this.b(768);
						return;
					}
				}
			}
			else if (num <= 434)
			{
				if (num == 406)
				{
					this.b(896);
					return;
				}
				if (num == 434)
				{
					this.b(1728);
					return;
				}
			}
			else
			{
				if (num == 438)
				{
					this.b(1408);
					return;
				}
				if (num == 470)
				{
					this.b(1152);
					return;
				}
			}
			this.c();
			this.c();
			num = this.d;
			if (num != 128)
			{
				if (num != 384)
				{
					if (num != 1408)
					{
						this.c();
						num = this.d;
						if (num <= 1920)
						{
							if (num <= 896)
							{
								if (num != 640)
								{
									if (num == 896)
									{
										this.b(2368);
									}
								}
								else
								{
									this.b(2112);
								}
							}
							else if (num != 1152)
							{
								if (num != 1664)
								{
									if (num == 1920)
									{
										this.b(2496);
									}
								}
								else
								{
									this.b(2240);
								}
							}
							else
							{
								this.b(1984);
							}
						}
						else if (num <= 2944)
						{
							if (num != 2688)
							{
								if (num == 2944)
								{
									this.b(2432);
								}
							}
							else
							{
								this.b(2176);
							}
						}
						else if (num != 3200)
						{
							if (num != 3712)
							{
								if (num == 3968)
								{
									this.b(2560);
								}
							}
							else
							{
								this.b(2304);
							}
						}
						else
						{
							this.b(2048);
						}
					}
					else
					{
						this.b(1920);
					}
				}
				else
				{
					this.b(1856);
				}
			}
			else
			{
				this.b(1792);
			}
		}

		// Token: 0x060027F3 RID: 10227 RVA: 0x0016ED94 File Offset: 0x0016DD94
		private void f()
		{
			this.b();
			this.c();
			this.c();
			switch (this.d)
			{
			case 1:
				this.a(3);
				return;
			case 3:
				this.a(2);
				return;
			}
			this.c();
			int num = this.d;
			if (num != 2)
			{
				if (num != 6)
				{
					this.c();
					num = this.d;
					if (num != 4)
					{
						if (num != 12)
						{
							this.c();
							num = this.d;
							if (num != 24)
							{
								this.c();
								num = this.d;
								if (num != 8)
								{
									if (num != 40)
									{
										this.c();
										num = this.d;
										if (num != 16)
										{
											if (num != 80)
											{
												if (num != 112)
												{
													this.c();
													num = this.d;
													if (num != 32)
													{
														if (num != 224)
														{
															this.c();
															num = this.d;
															if (num != 48)
															{
																this.c();
																num = this.d;
																if (num <= 96)
																{
																	if (num == 64)
																	{
																		this.a(18);
																		return;
																	}
																	if (num == 96)
																	{
																		this.a(17);
																		return;
																	}
																}
																else
																{
																	if (num == 928)
																	{
																		this.a(16);
																		return;
																	}
																	if (num == 944)
																	{
																		this.a(0);
																		return;
																	}
																	if (num == 960)
																	{
																		this.b(64);
																		return;
																	}
																}
																this.c();
																num = this.d;
																if (num <= 384)
																{
																	if (num <= 160)
																	{
																		if (num == 128)
																		{
																			this.b(1792);
																			return;
																		}
																		if (num == 160)
																		{
																			this.a(23);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 176)
																		{
																			this.a(20);
																			return;
																		}
																		if (num == 192)
																		{
																			this.a(25);
																			return;
																		}
																		if (num == 384)
																		{
																			this.b(1856);
																			return;
																		}
																	}
																}
																else if (num <= 1408)
																{
																	if (num == 432)
																	{
																		this.a(21);
																		return;
																	}
																	if (num == 1408)
																	{
																		this.b(1920);
																		return;
																	}
																}
																else
																{
																	if (num == 1840)
																	{
																		this.a(19);
																		return;
																	}
																	if (num == 1856)
																	{
																		this.a(24);
																		return;
																	}
																	if (num == 1888)
																	{
																		this.a(22);
																		return;
																	}
																}
																this.c();
																num = this.d;
																if (num <= 1920)
																{
																	if (num <= 832)
																	{
																		if (num <= 576)
																		{
																			if (num <= 352)
																			{
																				if (num == 304)
																				{
																					this.b(128);
																					return;
																				}
																				if (num == 320)
																				{
																					this.a(56);
																					return;
																				}
																				if (num == 352)
																				{
																					this.a(30);
																					return;
																				}
																			}
																			else
																			{
																				if (num == 416)
																				{
																					this.a(57);
																					return;
																				}
																				if (num == 448)
																				{
																					this.a(54);
																					return;
																				}
																				if (num == 576)
																				{
																					this.a(52);
																					return;
																				}
																			}
																		}
																		else if (num <= 672)
																		{
																			if (num == 608)
																			{
																				this.a(48);
																				return;
																			}
																			if (num == 640)
																			{
																				this.b(2112);
																				return;
																			}
																			if (num == 672)
																			{
																				this.a(44);
																				return;
																			}
																		}
																		else if (num <= 704)
																		{
																			if (num == 688)
																			{
																				this.a(36);
																				return;
																			}
																			if (num == 704)
																			{
																				this.b(384);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 816)
																			{
																				this.a(28);
																				return;
																			}
																			if (num == 832)
																			{
																				this.a(60);
																				return;
																			}
																		}
																	}
																	else if (num <= 1376)
																	{
																		if (num <= 1152)
																		{
																			if (num == 864)
																			{
																				this.a(40);
																				return;
																			}
																			if (num == 896)
																			{
																				this.b(2368);
																				return;
																			}
																			if (num == 1152)
																			{
																				this.b(1984);
																				return;
																			}
																		}
																		else if (num <= 1200)
																		{
																			if (num == 1184)
																			{
																				this.a(50);
																				return;
																			}
																			if (num == 1200)
																			{
																				this.a(34);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 1328)
																			{
																				this.a(26);
																				return;
																			}
																			if (num == 1376)
																			{
																				this.a(32);
																				return;
																			}
																		}
																	}
																	else if (num <= 1632)
																	{
																		if (num == 1440)
																		{
																			this.a(61);
																			return;
																		}
																		if (num == 1456)
																		{
																			this.a(42);
																			return;
																		}
																		if (num == 1632)
																		{
																			this.a(62);
																			return;
																		}
																	}
																	else if (num <= 1696)
																	{
																		if (num == 1664)
																		{
																			this.b(2240);
																			return;
																		}
																		if (num == 1696)
																		{
																			this.a(46);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 1712)
																		{
																			this.a(38);
																			return;
																		}
																		if (num == 1920)
																		{
																			this.b(2496);
																			return;
																		}
																	}
																}
																else if (num <= 3232)
																{
																	if (num <= 2720)
																	{
																		if (num <= 2464)
																		{
																			if (num == 2352)
																			{
																				this.b(192);
																				return;
																			}
																			if (num == 2400)
																			{
																				this.a(31);
																				return;
																			}
																			if (num == 2464)
																			{
																				this.a(58);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 2656)
																			{
																				this.a(49);
																				return;
																			}
																			if (num == 2688)
																			{
																				this.b(2176);
																				return;
																			}
																			if (num == 2720)
																			{
																				this.a(45);
																				return;
																			}
																		}
																	}
																	else if (num <= 2864)
																	{
																		if (num == 2736)
																		{
																			this.a(37);
																			return;
																		}
																		if (num == 2752)
																		{
																			this.b(448);
																			return;
																		}
																		if (num == 2864)
																		{
																			this.a(29);
																			return;
																		}
																	}
																	else if (num <= 2944)
																	{
																		if (num == 2912)
																		{
																			this.a(41);
																			return;
																		}
																		if (num == 2944)
																		{
																			this.b(2432);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 3200)
																		{
																			this.b(2048);
																			return;
																		}
																		if (num == 3232)
																		{
																			this.a(51);
																			return;
																		}
																	}
																}
																else if (num <= 3504)
																{
																	if (num <= 3376)
																	{
																		if (num == 3248)
																		{
																			this.a(35);
																			return;
																		}
																		if (num == 3264)
																		{
																			this.b(320);
																			return;
																		}
																		if (num == 3376)
																		{
																			this.a(27);
																			return;
																		}
																	}
																	else if (num <= 3424)
																	{
																		if (num == 3392)
																		{
																			this.a(59);
																			return;
																		}
																		if (num == 3424)
																		{
																			this.a(33);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 3488)
																		{
																			this.b(256);
																			return;
																		}
																		if (num == 3504)
																		{
																			this.a(43);
																			return;
																		}
																	}
																}
																else if (num <= 3712)
																{
																	if (num == 3648)
																	{
																		this.a(55);
																		return;
																	}
																	if (num == 3680)
																	{
																		this.a(63);
																		return;
																	}
																	if (num == 3712)
																	{
																		this.b(2304);
																		return;
																	}
																}
																else if (num <= 3760)
																{
																	if (num == 3744)
																	{
																		this.a(47);
																		return;
																	}
																	if (num == 3760)
																	{
																		this.a(39);
																		return;
																	}
																}
																else
																{
																	if (num == 3776)
																	{
																		this.a(53);
																		return;
																	}
																	if (num == 3968)
																	{
																		this.b(2560);
																		return;
																	}
																}
																this.c();
																num = this.d;
																if (num <= 3520)
																{
																	if (num <= 1728)
																	{
																		if (num <= 1344)
																		{
																			if (num != 1216)
																			{
																				if (num == 1344)
																				{
																					this.b(1408);
																				}
																			}
																			else
																			{
																				this.b(1664);
																			}
																		}
																		else if (num != 1472)
																		{
																			if (num != 1600)
																			{
																				if (num == 1728)
																				{
																					this.b(512);
																				}
																			}
																			else
																			{
																				this.b(768);
																			}
																		}
																		else
																		{
																			this.b(1024);
																		}
																	}
																	else if (num <= 2496)
																	{
																		if (num != 2368)
																		{
																			if (num == 2496)
																			{
																				this.b(896);
																			}
																		}
																		else
																		{
																			this.b(1280);
																		}
																	}
																	else if (num != 2624)
																	{
																		if (num != 2880)
																		{
																			if (num == 3520)
																			{
																				this.b(1152);
																			}
																		}
																		else
																		{
																			this.b(1536);
																		}
																	}
																	else
																	{
																		this.b(640);
																	}
																}
																else if (num <= 5824)
																{
																	if (num <= 5440)
																	{
																		if (num != 5312)
																		{
																			if (num == 5440)
																			{
																				this.b(1472);
																			}
																		}
																		else
																		{
																			this.b(1728);
																		}
																	}
																	else if (num != 5568)
																	{
																		if (num != 5696)
																		{
																			if (num == 5824)
																			{
																				this.b(576);
																			}
																		}
																		else
																		{
																			this.b(832);
																		}
																	}
																	else
																	{
																		this.b(1088);
																	}
																}
																else if (num <= 6592)
																{
																	if (num != 6464)
																	{
																		if (num == 6592)
																		{
																			this.b(960);
																		}
																	}
																	else
																	{
																		this.b(1344);
																	}
																}
																else if (num != 6720)
																{
																	if (num != 6976)
																	{
																		if (num == 7616)
																		{
																			this.b(1216);
																		}
																	}
																	else
																	{
																		this.b(1600);
																	}
																}
																else
																{
																	this.b(704);
																}
															}
															else
															{
																this.a(15);
															}
														}
														else
														{
															this.a(14);
														}
													}
													else
													{
														this.a(13);
													}
												}
												else
												{
													this.a(12);
												}
											}
											else
											{
												this.a(11);
											}
										}
										else
										{
											this.a(10);
										}
									}
									else
									{
										this.a(8);
									}
								}
								else
								{
									this.a(9);
								}
							}
							else
							{
								this.a(7);
							}
						}
						else
						{
							this.a(5);
						}
					}
					else
					{
						this.a(6);
					}
				}
				else
				{
					this.a(4);
				}
			}
			else
			{
				this.a(1);
			}
		}

		// Token: 0x060027F4 RID: 10228 RVA: 0x0016FA2C File Offset: 0x0016EA2C
		private void b(int A_0)
		{
			this.q += A_0;
			this.b();
			if (this.h)
			{
				this.g();
			}
			else
			{
				this.f();
			}
		}

		// Token: 0x060027F5 RID: 10229 RVA: 0x0016FA6C File Offset: 0x0016EA6C
		private void a(int A_0)
		{
			if (this.o >= this.m.Length)
			{
				int[] array = new int[this.m.Length * 4];
				this.m.CopyTo(array, 0);
				this.m = array;
			}
			this.m[this.o++] = this.v + this.q + A_0;
			this.l += this.q + A_0;
			this.v = 0;
			this.q = 0;
			this.h = !this.h;
		}

		// Token: 0x060027F6 RID: 10230 RVA: 0x0016FB10 File Offset: 0x0016EB10
		private void e()
		{
			int num = this.k + this.n[this.p];
			this.v += num - this.l;
			this.l = num;
		}

		// Token: 0x060027F7 RID: 10231 RVA: 0x0016FB4F File Offset: 0x0016EB4F
		private void d()
		{
			this.b = 0;
			this.c = 0;
			this.l += this.g;
		}

		// Token: 0x060027F8 RID: 10232 RVA: 0x0016FB74 File Offset: 0x0016EB74
		private void c()
		{
			if (this.a())
			{
				this.d += this.f;
			}
			this.c++;
			if (this.c == 8)
			{
				this.c = 0;
				this.b++;
			}
			this.f *= 2;
			this.e++;
		}

		// Token: 0x060027F9 RID: 10233 RVA: 0x0016FBF3 File Offset: 0x0016EBF3
		private void b()
		{
			this.d = 0;
			this.e = 0;
			this.f = 1;
		}

		// Token: 0x060027FA RID: 10234 RVA: 0x0016FC0C File Offset: 0x0016EC0C
		private bool a()
		{
			bool result;
			switch (this.c)
			{
			case 0:
				result = ((this.a[this.b] & 128) == 128);
				break;
			case 1:
				result = ((this.a[this.b] & 64) == 64);
				break;
			case 2:
				result = ((this.a[this.b] & 32) == 32);
				break;
			case 3:
				result = ((this.a[this.b] & 16) == 16);
				break;
			case 4:
				result = ((this.a[this.b] & 8) == 8);
				break;
			case 5:
				result = ((this.a[this.b] & 4) == 4);
				break;
			case 6:
				result = ((this.a[this.b] & 2) == 2);
				break;
			default:
				result = ((this.a[this.b] & 1) == 1);
				break;
			}
			return result;
		}

		// Token: 0x0400115C RID: 4444
		private byte[] a;

		// Token: 0x0400115D RID: 4445
		private int b = 0;

		// Token: 0x0400115E RID: 4446
		private int c = 0;

		// Token: 0x0400115F RID: 4447
		private int d = 0;

		// Token: 0x04001160 RID: 4448
		private int e = 0;

		// Token: 0x04001161 RID: 4449
		private int f = 1;

		// Token: 0x04001162 RID: 4450
		private int g = 1728;

		// Token: 0x04001163 RID: 4451
		private bool h = true;

		// Token: 0x04001164 RID: 4452
		private int i;

		// Token: 0x04001165 RID: 4453
		private int j = 0;

		// Token: 0x04001166 RID: 4454
		private int k;

		// Token: 0x04001167 RID: 4455
		private int l;

		// Token: 0x04001168 RID: 4456
		private int[] m;

		// Token: 0x04001169 RID: 4457
		private int[] n = null;

		// Token: 0x0400116A RID: 4458
		private int o;

		// Token: 0x0400116B RID: 4459
		private int p;

		// Token: 0x0400116C RID: 4460
		private int q;

		// Token: 0x0400116D RID: 4461
		private int[] r;

		// Token: 0x0400116E RID: 4462
		private int s;

		// Token: 0x0400116F RID: 4463
		private int t = 0;

		// Token: 0x04001170 RID: 4464
		private int u = 0;

		// Token: 0x04001171 RID: 4465
		private int v = 0;

		// Token: 0x04001172 RID: 4466
		private bool w;

		// Token: 0x04001173 RID: 4467
		private int x = 0;

		// Token: 0x04001174 RID: 4468
		private int y = 0;

		// Token: 0x04001175 RID: 4469
		private bool z = false;

		// Token: 0x04001176 RID: 4470
		private int aa;

		// Token: 0x04001177 RID: 4471
		private int ab;
	}
}
