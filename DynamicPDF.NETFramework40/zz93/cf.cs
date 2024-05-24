using System;
using ceTe.DynamicPDF.Imaging;

namespace zz93
{
	// Token: 0x0200006E RID: 110
	internal class cf
	{
		// Token: 0x0600047D RID: 1149 RVA: 0x0004AD40 File Offset: 0x00049D40
		internal cf(byte[] A_0, int A_1, int A_2, byte[] A_3, int A_4, int A_5)
		{
			this.n = A_3;
			this.l = A_4;
			this.m = A_5;
			this.a = A_0;
			this.g = A_1;
			this.i = A_2;
			this.h();
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0004ADD0 File Offset: 0x00049DD0
		internal int i()
		{
			return this.l;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0004ADE8 File Offset: 0x00049DE8
		internal int j()
		{
			return this.m;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0004AE00 File Offset: 0x00049E00
		private void h()
		{
			for (int i = 0; i < this.i; i++)
			{
				this.j = 0;
				this.g();
				while (this.j < this.g)
				{
					if (this.h)
					{
						this.g();
						if (this.j == this.g)
						{
							break;
						}
						this.f();
					}
					else
					{
						this.f();
						this.g();
					}
					if (this.b > this.a.Length)
					{
						break;
					}
				}
				if (this.b > this.a.Length)
				{
					if (i < this.i)
					{
						for (int j = i; j < this.i; j++)
						{
							this.b(this.g);
							this.b(0);
						}
					}
					break;
				}
				this.h = true;
				if (this.j != this.g)
				{
					throw new ImageParsingException("Invalid Group3 Fax Line. Invalid line width.");
				}
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0004AF2C File Offset: 0x00049F2C
		private void g()
		{
			this.d();
			this.e();
			this.e();
			this.e();
			this.e();
			int num = this.d;
			switch (num)
			{
			case 1:
				this.c(3);
				return;
			case 2:
				break;
			case 3:
				this.c(5);
				return;
			default:
				if (num == 7)
				{
					this.c(6);
					return;
				}
				switch (num)
				{
				case 13:
					this.c(4);
					return;
				case 14:
					this.c(2);
					return;
				case 15:
					this.c(7);
					return;
				}
				break;
			}
			this.e();
			num = this.d;
			if (num <= 5)
			{
				if (num == 2)
				{
					this.c(11);
					return;
				}
				if (num == 5)
				{
					this.c(9);
					return;
				}
			}
			else
			{
				if (num == 9)
				{
					this.d(128);
					return;
				}
				switch (num)
				{
				case 25:
					this.c(8);
					return;
				case 27:
					this.d(64);
					return;
				case 28:
					this.c(10);
					return;
				}
			}
			this.e();
			num = this.d;
			if (num <= 21)
			{
				switch (num)
				{
				case 4:
					this.c(12);
					return;
				case 5:
					break;
				case 6:
					this.d(1664);
					return;
				default:
					if (num == 11)
					{
						this.c(14);
						return;
					}
					if (num == 21)
					{
						this.c(16);
						return;
					}
					break;
				}
			}
			else if (num <= 48)
			{
				if (num == 43)
				{
					this.c(15);
					return;
				}
				if (num == 48)
				{
					this.c(13);
					return;
				}
			}
			else
			{
				if (num == 53)
				{
					this.c(17);
					return;
				}
				switch (num)
				{
				case 56:
					this.c(1);
					return;
				case 58:
					this.d(192);
					return;
				}
			}
			this.e();
			num = this.d;
			if (num <= 24)
			{
				switch (num)
				{
				case 8:
					this.c(20);
					return;
				case 9:
				case 11:
					break;
				case 10:
					this.c(24);
					return;
				case 12:
					this.c(28);
					return;
				default:
					switch (num)
					{
					case 16:
						this.c(23);
						return;
					case 17:
						break;
					case 18:
						this.c(27);
						return;
					default:
						if (num == 24)
						{
							this.c(19);
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
					this.c(22);
					return;
				}
				if (num == 100)
				{
					this.c(26);
					return;
				}
			}
			else
			{
				if (num == 106)
				{
					this.c(25);
					return;
				}
				switch (num)
				{
				case 114:
					this.c(18);
					return;
				case 116:
					this.c(21);
					return;
				case 118:
					this.d(256);
					return;
				}
			}
			this.e();
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
							this.c(39);
							return;
						case 21:
							break;
						case 22:
							this.d(576);
							return;
						default:
							if (num == 26)
							{
								this.c(55);
								return;
							}
							break;
						}
					}
					else
					{
						if (num == 32)
						{
							this.c(45);
							return;
						}
						switch (num)
						{
						case 36:
							this.c(53);
							return;
						case 37:
						case 39:
						case 41:
						case 43:
							break;
						case 38:
							this.d(448);
							return;
						case 40:
							this.c(35);
							return;
						case 42:
							this.c(51);
							return;
						case 44:
							this.c(63);
							return;
						default:
							if (num == 52)
							{
								this.c(43);
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
						this.c(29);
						return;
					}
					switch (num)
					{
					case 72:
						this.c(33);
						return;
					case 73:
					case 75:
						break;
					case 74:
						this.c(49);
						return;
					case 76:
						this.c(61);
						return;
					default:
						switch (num)
						{
						case 80:
							this.c(47);
							return;
						case 82:
							this.c(59);
							return;
						case 84:
							this.c(41);
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
						this.c(31);
						return;
					case 89:
						break;
					case 90:
						this.c(57);
						return;
					default:
						if (num == 104)
						{
							this.c(37);
							return;
						}
						if (num == 108)
						{
							this.d(320);
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
						this.c(40);
						return;
					}
					if (num == 154)
					{
						this.c(56);
						return;
					}
				}
				else
				{
					if (num == 160)
					{
						this.c(46);
						return;
					}
					switch (num)
					{
					case 164:
						this.c(54);
						return;
					case 165:
					case 167:
					case 169:
					case 171:
						break;
					case 166:
						this.d(512);
						return;
					case 168:
						this.c(36);
						return;
					case 170:
						this.c(52);
						return;
					case 172:
						this.c(0);
						return;
					default:
						if (num == 180)
						{
							this.c(44);
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
					this.c(30);
					return;
				}
				switch (num)
				{
				case 200:
					this.c(34);
					return;
				case 201:
				case 203:
					break;
				case 202:
					this.c(50);
					return;
				case 204:
					this.c(62);
					return;
				default:
					switch (num)
					{
					case 208:
						this.c(48);
						return;
					case 210:
						this.c(60);
						return;
					case 212:
						this.c(42);
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
					this.c(32);
					return;
				case 217:
					break;
				case 218:
					this.c(58);
					return;
				default:
					switch (num)
					{
					case 230:
						this.d(640);
						return;
					case 231:
						break;
					case 232:
						this.c(38);
						return;
					default:
						if (num == 236)
						{
							this.d(384);
							return;
						}
						break;
					}
					break;
				}
			}
			this.e();
			num = this.d;
			if (num <= 214)
			{
				if (num <= 102)
				{
					if (num <= 54)
					{
						if (num == 50)
						{
							this.d(1472);
							return;
						}
						if (num == 54)
						{
							this.d(1216);
							return;
						}
					}
					else
					{
						if (num == 86)
						{
							this.d(960);
							return;
						}
						if (num == 102)
						{
							this.d(704);
							return;
						}
					}
				}
				else if (num <= 178)
				{
					if (num == 150)
					{
						this.d(832);
						return;
					}
					if (num == 178)
					{
						this.d(1600);
						return;
					}
				}
				else
				{
					if (num == 182)
					{
						this.d(1344);
						return;
					}
					if (num == 214)
					{
						this.d(1088);
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
						this.d(1536);
						return;
					}
					if (num == 310)
					{
						this.d(1280);
						return;
					}
				}
				else
				{
					if (num == 342)
					{
						this.d(1024);
						return;
					}
					if (num == 358)
					{
						this.d(768);
						return;
					}
				}
			}
			else if (num <= 434)
			{
				if (num == 406)
				{
					this.d(896);
					return;
				}
				if (num == 434)
				{
					this.d(1728);
					return;
				}
			}
			else
			{
				if (num == 438)
				{
					this.d(1408);
					return;
				}
				if (num == 470)
				{
					this.d(1152);
					return;
				}
			}
			this.e();
			this.e();
			num = this.d;
			if (num != 128)
			{
				if (num != 384)
				{
					if (num != 1408)
					{
						this.e();
						num = this.d;
						if (num <= 1920)
						{
							if (num <= 896)
							{
								if (num == 640)
								{
									this.d(2112);
									return;
								}
								if (num == 896)
								{
									this.d(2368);
									return;
								}
							}
							else
							{
								if (num == 1152)
								{
									this.d(1984);
									return;
								}
								if (num == 1664)
								{
									this.d(2240);
									return;
								}
								if (num == 1920)
								{
									this.d(2496);
									return;
								}
							}
						}
						else if (num <= 2944)
						{
							if (num == 2048)
							{
								return;
							}
							if (num == 2688)
							{
								this.d(2176);
								return;
							}
							if (num == 2944)
							{
								this.d(2432);
								return;
							}
						}
						else
						{
							if (num == 3200)
							{
								this.d(2048);
								return;
							}
							if (num == 3712)
							{
								this.d(2304);
								return;
							}
							if (num == 3968)
							{
								this.d(2560);
								return;
							}
						}
						this.e();
						if (this.d != this.f >> 1)
						{
							this.e();
							if (this.d != this.f >> 1)
							{
								this.e();
								if (this.d != this.f >> 1)
								{
									this.e();
									if (this.d != this.f >> 1)
									{
										this.e();
										if (this.d != this.f >> 1)
										{
											this.e();
											if (this.d != this.f >> 1)
											{
												this.e();
												if (this.d != this.f >> 1)
												{
													this.e();
													if (this.d != this.f >> 1)
													{
														this.e();
														if (this.d != this.f >> 1)
														{
															this.e();
															if (this.d != this.f >> 1)
															{
																this.e();
																if (this.d == this.f >> 1)
																{
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					else
					{
						this.d(1920);
					}
				}
				else
				{
					this.d(1856);
				}
			}
			else
			{
				this.d(1792);
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0004BC58 File Offset: 0x0004AC58
		private void f()
		{
			this.d();
			this.e();
			this.e();
			switch (this.d)
			{
			case 1:
				this.c(3);
				return;
			case 3:
				this.c(2);
				return;
			}
			this.e();
			int num = this.d;
			if (num != 2)
			{
				if (num != 6)
				{
					this.e();
					num = this.d;
					if (num != 4)
					{
						if (num != 12)
						{
							this.e();
							num = this.d;
							if (num != 24)
							{
								this.e();
								num = this.d;
								if (num != 8)
								{
									if (num != 40)
									{
										this.e();
										num = this.d;
										if (num != 16)
										{
											if (num != 80)
											{
												if (num != 112)
												{
													this.e();
													num = this.d;
													if (num != 32)
													{
														if (num != 224)
														{
															this.e();
															num = this.d;
															if (num != 48)
															{
																this.e();
																num = this.d;
																if (num <= 96)
																{
																	if (num == 64)
																	{
																		this.c(18);
																		return;
																	}
																	if (num == 96)
																	{
																		this.c(17);
																		return;
																	}
																}
																else
																{
																	if (num == 928)
																	{
																		this.c(16);
																		return;
																	}
																	if (num == 944)
																	{
																		this.c(0);
																		return;
																	}
																	if (num == 960)
																	{
																		this.d(64);
																		return;
																	}
																}
																this.e();
																num = this.d;
																if (num <= 384)
																{
																	if (num <= 160)
																	{
																		if (num == 128)
																		{
																			this.d(1792);
																			return;
																		}
																		if (num == 160)
																		{
																			this.c(23);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 176)
																		{
																			this.c(20);
																			return;
																		}
																		if (num == 192)
																		{
																			this.c(25);
																			return;
																		}
																		if (num == 384)
																		{
																			this.d(1856);
																			return;
																		}
																	}
																}
																else if (num <= 1408)
																{
																	if (num == 432)
																	{
																		this.c(21);
																		return;
																	}
																	if (num == 1408)
																	{
																		this.d(1920);
																		return;
																	}
																}
																else
																{
																	if (num == 1840)
																	{
																		this.c(19);
																		return;
																	}
																	if (num == 1856)
																	{
																		this.c(24);
																		return;
																	}
																	if (num == 1888)
																	{
																		this.c(22);
																		return;
																	}
																}
																this.e();
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
																					this.d(128);
																					return;
																				}
																				if (num == 320)
																				{
																					this.c(56);
																					return;
																				}
																				if (num == 352)
																				{
																					this.c(30);
																					return;
																				}
																			}
																			else
																			{
																				if (num == 416)
																				{
																					this.c(57);
																					return;
																				}
																				if (num == 448)
																				{
																					this.c(54);
																					return;
																				}
																				if (num == 576)
																				{
																					this.c(52);
																					return;
																				}
																			}
																		}
																		else if (num <= 672)
																		{
																			if (num == 608)
																			{
																				this.c(48);
																				return;
																			}
																			if (num == 640)
																			{
																				this.d(2112);
																				return;
																			}
																			if (num == 672)
																			{
																				this.c(44);
																				return;
																			}
																		}
																		else if (num <= 704)
																		{
																			if (num == 688)
																			{
																				this.c(36);
																				return;
																			}
																			if (num == 704)
																			{
																				this.d(384);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 816)
																			{
																				this.c(28);
																				return;
																			}
																			if (num == 832)
																			{
																				this.c(60);
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
																				this.c(40);
																				return;
																			}
																			if (num == 896)
																			{
																				this.d(2368);
																				return;
																			}
																			if (num == 1152)
																			{
																				this.d(1984);
																				return;
																			}
																		}
																		else if (num <= 1200)
																		{
																			if (num == 1184)
																			{
																				this.c(50);
																				return;
																			}
																			if (num == 1200)
																			{
																				this.c(34);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 1328)
																			{
																				this.c(26);
																				return;
																			}
																			if (num == 1376)
																			{
																				this.c(32);
																				return;
																			}
																		}
																	}
																	else if (num <= 1632)
																	{
																		if (num == 1440)
																		{
																			this.c(61);
																			return;
																		}
																		if (num == 1456)
																		{
																			this.c(42);
																			return;
																		}
																		if (num == 1632)
																		{
																			this.c(62);
																			return;
																		}
																	}
																	else if (num <= 1696)
																	{
																		if (num == 1664)
																		{
																			this.d(2240);
																			return;
																		}
																		if (num == 1696)
																		{
																			this.c(46);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 1712)
																		{
																			this.c(38);
																			return;
																		}
																		if (num == 1920)
																		{
																			this.d(2496);
																			return;
																		}
																	}
																}
																else if (num <= 3232)
																{
																	if (num <= 2720)
																	{
																		if (num <= 2400)
																		{
																			if (num == 2048)
																			{
																				return;
																			}
																			if (num == 2352)
																			{
																				this.d(192);
																				return;
																			}
																			if (num == 2400)
																			{
																				this.c(31);
																				return;
																			}
																		}
																		else if (num <= 2656)
																		{
																			if (num == 2464)
																			{
																				this.c(58);
																				return;
																			}
																			if (num == 2656)
																			{
																				this.c(49);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 2688)
																			{
																				this.d(2176);
																				return;
																			}
																			if (num == 2720)
																			{
																				this.c(45);
																				return;
																			}
																		}
																	}
																	else if (num <= 2864)
																	{
																		if (num == 2736)
																		{
																			this.c(37);
																			return;
																		}
																		if (num == 2752)
																		{
																			this.d(448);
																			return;
																		}
																		if (num == 2864)
																		{
																			this.c(29);
																			return;
																		}
																	}
																	else if (num <= 2944)
																	{
																		if (num == 2912)
																		{
																			this.c(41);
																			return;
																		}
																		if (num == 2944)
																		{
																			this.d(2432);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 3200)
																		{
																			this.d(2048);
																			return;
																		}
																		if (num == 3232)
																		{
																			this.c(51);
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
																			this.c(35);
																			return;
																		}
																		if (num == 3264)
																		{
																			this.d(320);
																			return;
																		}
																		if (num == 3376)
																		{
																			this.c(27);
																			return;
																		}
																	}
																	else if (num <= 3424)
																	{
																		if (num == 3392)
																		{
																			this.c(59);
																			return;
																		}
																		if (num == 3424)
																		{
																			this.c(33);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 3488)
																		{
																			this.d(256);
																			return;
																		}
																		if (num == 3504)
																		{
																			this.c(43);
																			return;
																		}
																	}
																}
																else if (num <= 3712)
																{
																	if (num == 3648)
																	{
																		this.c(55);
																		return;
																	}
																	if (num == 3680)
																	{
																		this.c(63);
																		return;
																	}
																	if (num == 3712)
																	{
																		this.d(2304);
																		return;
																	}
																}
																else if (num <= 3760)
																{
																	if (num == 3744)
																	{
																		this.c(47);
																		return;
																	}
																	if (num == 3760)
																	{
																		this.c(39);
																		return;
																	}
																}
																else
																{
																	if (num == 3776)
																	{
																		this.c(53);
																		return;
																	}
																	if (num == 3968)
																	{
																		this.d(2560);
																		return;
																	}
																}
																this.e();
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
																					this.d(1408);
																				}
																			}
																			else
																			{
																				this.d(1664);
																			}
																		}
																		else if (num != 1472)
																		{
																			if (num != 1600)
																			{
																				if (num == 1728)
																				{
																					this.d(512);
																				}
																			}
																			else
																			{
																				this.d(768);
																			}
																		}
																		else
																		{
																			this.d(1024);
																		}
																	}
																	else if (num <= 2496)
																	{
																		if (num != 2368)
																		{
																			if (num == 2496)
																			{
																				this.d(896);
																			}
																		}
																		else
																		{
																			this.d(1280);
																		}
																	}
																	else if (num != 2624)
																	{
																		if (num != 2880)
																		{
																			if (num == 3520)
																			{
																				this.d(1152);
																			}
																		}
																		else
																		{
																			this.d(1536);
																		}
																	}
																	else
																	{
																		this.d(640);
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
																				this.d(1472);
																			}
																		}
																		else
																		{
																			this.d(1728);
																		}
																	}
																	else if (num != 5568)
																	{
																		if (num != 5696)
																		{
																			if (num == 5824)
																			{
																				this.d(576);
																			}
																		}
																		else
																		{
																			this.d(832);
																		}
																	}
																	else
																	{
																		this.d(1088);
																	}
																}
																else if (num <= 6592)
																{
																	if (num != 6464)
																	{
																		if (num == 6592)
																		{
																			this.d(960);
																		}
																	}
																	else
																	{
																		this.d(1344);
																	}
																}
																else if (num != 6720)
																{
																	if (num != 6976)
																	{
																		if (num == 7616)
																		{
																			this.d(1216);
																		}
																	}
																	else
																	{
																		this.d(1600);
																	}
																}
																else
																{
																	this.d(704);
																}
															}
															else
															{
																this.c(15);
															}
														}
														else
														{
															this.c(14);
														}
													}
													else
													{
														this.c(13);
													}
												}
												else
												{
													this.c(12);
												}
											}
											else
											{
												this.c(11);
											}
										}
										else
										{
											this.c(10);
										}
									}
									else
									{
										this.c(8);
									}
								}
								else
								{
									this.c(9);
								}
							}
							else
							{
								this.c(7);
							}
						}
						else
						{
							this.c(5);
						}
					}
					else
					{
						this.c(6);
					}
				}
				else
				{
					this.c(4);
				}
			}
			else
			{
				this.c(1);
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0004C910 File Offset: 0x0004B910
		private void d(int A_0)
		{
			this.k += A_0;
			if (this.h)
			{
				this.b(A_0);
				this.d();
				this.g();
			}
			else
			{
				this.a(A_0);
				this.d();
				this.f();
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0004C96C File Offset: 0x0004B96C
		private void c(int A_0)
		{
			this.j += this.k + A_0;
			if (this.h)
			{
				this.b(A_0);
			}
			else
			{
				this.a(A_0);
			}
			this.k = 0;
			this.h = !this.h;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0004C9C4 File Offset: 0x0004B9C4
		private void e()
		{
			if (this.c())
			{
				this.d += this.f;
			}
			this.c++;
			if (this.c == 8)
			{
				this.c = 0;
				this.b++;
			}
			this.f <<= 1;
			this.e++;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0004CA43 File Offset: 0x0004BA43
		private void d()
		{
			this.d = 0;
			this.e = 0;
			this.f = 1;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0004CA5C File Offset: 0x0004BA5C
		private bool c()
		{
			bool result;
			if (this.b < this.a.Length)
			{
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
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0004CB74 File Offset: 0x0004BB74
		private void b(int A_0)
		{
			if (A_0 < 64)
			{
				switch (A_0)
				{
				case 0:
					this.a(1696, 8);
					break;
				case 1:
					this.a(896, 6);
					break;
				case 2:
					this.a(3584, 4);
					break;
				case 3:
					this.a(4096, 4);
					break;
				case 4:
					this.a(5632, 4);
					break;
				case 5:
					this.a(6144, 4);
					break;
				case 6:
					this.a(7168, 4);
					break;
				case 7:
					this.a(7680, 4);
					break;
				case 8:
					this.a(4864, 5);
					break;
				case 9:
					this.a(5120, 5);
					break;
				case 10:
					this.a(1792, 5);
					break;
				case 11:
					this.a(2048, 5);
					break;
				case 12:
					this.a(1024, 6);
					break;
				case 13:
					this.a(384, 6);
					break;
				case 14:
					this.a(6656, 6);
					break;
				case 15:
					this.a(6784, 6);
					break;
				case 16:
					this.a(5376, 6);
					break;
				case 17:
					this.a(5504, 6);
					break;
				case 18:
					this.a(2496, 7);
					break;
				case 19:
					this.a(768, 7);
					break;
				case 20:
					this.a(512, 7);
					break;
				case 21:
					this.a(1472, 7);
					break;
				case 22:
					this.a(192, 7);
					break;
				case 23:
					this.a(256, 7);
					break;
				case 24:
					this.a(2560, 7);
					break;
				case 25:
					this.a(2752, 7);
					break;
				case 26:
					this.a(1216, 7);
					break;
				case 27:
					this.a(2304, 7);
					break;
				case 28:
					this.a(1536, 7);
					break;
				case 29:
					this.a(64, 8);
					break;
				case 30:
					this.a(96, 8);
					break;
				case 31:
					this.a(832, 8);
					break;
				case 32:
					this.a(864, 8);
					break;
				case 33:
					this.a(576, 8);
					break;
				case 34:
					this.a(608, 8);
					break;
				case 35:
					this.a(640, 8);
					break;
				case 36:
					this.a(672, 8);
					break;
				case 37:
					this.a(704, 8);
					break;
				case 38:
					this.a(736, 8);
					break;
				case 39:
					this.a(1280, 8);
					break;
				case 40:
					this.a(1312, 8);
					break;
				case 41:
					this.a(1344, 8);
					break;
				case 42:
					this.a(1376, 8);
					break;
				case 43:
					this.a(1408, 8);
					break;
				case 44:
					this.a(1440, 8);
					break;
				case 45:
					this.a(128, 8);
					break;
				case 46:
					this.a(160, 8);
					break;
				case 47:
					this.a(320, 8);
					break;
				case 48:
					this.a(352, 8);
					break;
				case 49:
					this.a(2624, 8);
					break;
				case 50:
					this.a(2656, 8);
					break;
				case 51:
					this.a(2688, 8);
					break;
				case 52:
					this.a(2720, 8);
					break;
				case 53:
					this.a(1152, 8);
					break;
				case 54:
					this.a(1184, 8);
					break;
				case 55:
					this.a(2816, 8);
					break;
				case 56:
					this.a(2848, 8);
					break;
				case 57:
					this.a(2880, 8);
					break;
				case 58:
					this.a(2912, 8);
					break;
				case 59:
					this.a(2368, 8);
					break;
				case 60:
					this.a(2400, 8);
					break;
				case 61:
					this.a(1600, 8);
					break;
				case 62:
					this.a(1632, 8);
					break;
				default:
					this.a(1664, 8);
					break;
				}
			}
			else
			{
				switch (A_0 / 64)
				{
				case 1:
					this.a(6912, 5);
					break;
				case 2:
					this.a(4608, 5);
					break;
				case 3:
					this.a(2944, 6);
					break;
				case 4:
					this.a(3520, 7);
					break;
				case 5:
					this.a(1728, 8);
					break;
				case 6:
					this.a(1760, 8);
					break;
				case 7:
					this.a(3200, 8);
					break;
				case 8:
					this.a(3232, 8);
					break;
				case 9:
					this.a(3328, 8);
					break;
				case 10:
					this.a(3296, 8);
					break;
				case 11:
					this.a(3264, 9);
					break;
				case 12:
					this.a(3280, 9);
					break;
				case 13:
					this.a(3360, 9);
					break;
				case 14:
					this.a(3376, 9);
					break;
				case 15:
					this.a(3392, 9);
					break;
				case 16:
					this.a(3408, 9);
					break;
				case 17:
					this.a(3424, 9);
					break;
				case 18:
					this.a(3440, 9);
					break;
				case 19:
					this.a(3456, 9);
					break;
				case 20:
					this.a(3472, 9);
					break;
				case 21:
					this.a(3488, 9);
					break;
				case 22:
					this.a(3504, 9);
					break;
				case 23:
					this.a(2432, 9);
					break;
				case 24:
					this.a(2448, 9);
					break;
				case 25:
					this.a(2464, 9);
					break;
				case 26:
					this.a(3072, 6);
					break;
				case 27:
					this.a(2480, 9);
					break;
				case 28:
					this.a(32, 11);
					break;
				case 29:
					this.a(48, 11);
					break;
				case 30:
					this.a(52, 11);
					break;
				case 31:
					this.a(36, 12);
					break;
				case 32:
					this.a(38, 12);
					break;
				case 33:
					this.a(40, 12);
					break;
				case 34:
					this.a(42, 12);
					break;
				case 35:
					this.a(44, 12);
					break;
				case 36:
					this.a(46, 12);
					break;
				case 37:
					this.a(56, 12);
					break;
				case 38:
					this.a(58, 12);
					break;
				case 39:
					this.a(60, 12);
					break;
				default:
					this.a(62, 12);
					break;
				}
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0004D46C File Offset: 0x0004C46C
		private void a(int A_0)
		{
			if (A_0 < 64)
			{
				switch (A_0)
				{
				case 0:
					this.a(440, 10);
					break;
				case 1:
					this.a(2048, 3);
					break;
				case 2:
					this.a(6144, 2);
					break;
				case 3:
					this.a(4096, 2);
					break;
				case 4:
					this.a(3072, 3);
					break;
				case 5:
					this.a(1536, 4);
					break;
				case 6:
					this.a(1024, 4);
					break;
				case 7:
					this.a(768, 5);
					break;
				case 8:
					this.a(640, 6);
					break;
				case 9:
					this.a(512, 6);
					break;
				case 10:
					this.a(256, 7);
					break;
				case 11:
					this.a(320, 7);
					break;
				case 12:
					this.a(448, 7);
					break;
				case 13:
					this.a(128, 8);
					break;
				case 14:
					this.a(224, 8);
					break;
				case 15:
					this.a(384, 9);
					break;
				case 16:
					this.a(184, 10);
					break;
				case 17:
					this.a(192, 10);
					break;
				case 18:
					this.a(64, 10);
					break;
				case 19:
					this.a(412, 11);
					break;
				case 20:
					this.a(416, 11);
					break;
				case 21:
					this.a(432, 11);
					break;
				case 22:
					this.a(220, 11);
					break;
				case 23:
					this.a(160, 11);
					break;
				case 24:
					this.a(92, 11);
					break;
				case 25:
					this.a(96, 11);
					break;
				case 26:
					this.a(404, 12);
					break;
				case 27:
					this.a(406, 12);
					break;
				case 28:
					this.a(408, 12);
					break;
				case 29:
					this.a(410, 12);
					break;
				case 30:
					this.a(208, 12);
					break;
				case 31:
					this.a(210, 12);
					break;
				case 32:
					this.a(212, 12);
					break;
				case 33:
					this.a(214, 12);
					break;
				case 34:
					this.a(420, 12);
					break;
				case 35:
					this.a(422, 12);
					break;
				case 36:
					this.a(424, 12);
					break;
				case 37:
					this.a(426, 12);
					break;
				case 38:
					this.a(428, 12);
					break;
				case 39:
					this.a(430, 12);
					break;
				case 40:
					this.a(216, 12);
					break;
				case 41:
					this.a(218, 12);
					break;
				case 42:
					this.a(436, 12);
					break;
				case 43:
					this.a(438, 12);
					break;
				case 44:
					this.a(168, 12);
					break;
				case 45:
					this.a(170, 12);
					break;
				case 46:
					this.a(172, 12);
					break;
				case 47:
					this.a(174, 12);
					break;
				case 48:
					this.a(200, 12);
					break;
				case 49:
					this.a(202, 12);
					break;
				case 50:
					this.a(164, 12);
					break;
				case 51:
					this.a(166, 12);
					break;
				case 52:
					this.a(72, 12);
					break;
				case 53:
					this.a(110, 12);
					break;
				case 54:
					this.a(112, 12);
					break;
				case 55:
					this.a(78, 12);
					break;
				case 56:
					this.a(80, 12);
					break;
				case 57:
					this.a(176, 12);
					break;
				case 58:
					this.a(178, 12);
					break;
				case 59:
					this.a(86, 12);
					break;
				case 60:
					this.a(88, 12);
					break;
				case 61:
					this.a(180, 12);
					break;
				case 62:
					this.a(204, 12);
					break;
				default:
					this.a(206, 12);
					break;
				}
			}
			else
			{
				switch (A_0 / 64)
				{
				case 1:
					this.a(120, 10);
					break;
				case 2:
					this.a(400, 12);
					break;
				case 3:
					this.a(402, 12);
					break;
				case 4:
					this.a(182, 12);
					break;
				case 5:
					this.a(102, 12);
					break;
				case 6:
					this.a(104, 12);
					break;
				case 7:
					this.a(106, 12);
					break;
				case 8:
					this.a(108, 13);
					break;
				case 9:
					this.a(109, 13);
					break;
				case 10:
					this.a(74, 13);
					break;
				case 11:
					this.a(75, 13);
					break;
				case 12:
					this.a(76, 13);
					break;
				case 13:
					this.a(77, 13);
					break;
				case 14:
					this.a(114, 13);
					break;
				case 15:
					this.a(115, 13);
					break;
				case 16:
					this.a(116, 13);
					break;
				case 17:
					this.a(117, 13);
					break;
				case 18:
					this.a(118, 13);
					break;
				case 19:
					this.a(119, 13);
					break;
				case 20:
					this.a(82, 13);
					break;
				case 21:
					this.a(83, 13);
					break;
				case 22:
					this.a(84, 13);
					break;
				case 23:
					this.a(85, 13);
					break;
				case 24:
					this.a(90, 13);
					break;
				case 25:
					this.a(91, 13);
					break;
				case 26:
					this.a(100, 13);
					break;
				case 27:
					this.a(101, 13);
					break;
				case 28:
					this.a(32, 11);
					break;
				case 29:
					this.a(48, 11);
					break;
				case 30:
					this.a(52, 11);
					break;
				case 31:
					this.a(36, 12);
					break;
				case 32:
					this.a(38, 12);
					break;
				case 33:
					this.a(40, 12);
					break;
				case 34:
					this.a(42, 12);
					break;
				case 35:
					this.a(44, 12);
					break;
				case 36:
					this.a(46, 12);
					break;
				case 37:
					this.a(56, 12);
					break;
				case 38:
					this.a(58, 12);
					break;
				case 39:
					this.a(60, 12);
					break;
				default:
					this.a(62, 12);
					break;
				}
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0004DD44 File Offset: 0x0004CD44
		private void a(int A_0, int A_1)
		{
			int num = 4096;
			for (int i = 0; i < A_1; i++)
			{
				int num2 = A_0 - num;
				if (num2 >= 0)
				{
					A_0 = num2;
					this.b();
				}
				else
				{
					this.a();
				}
				num >>= 1;
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0004DD94 File Offset: 0x0004CD94
		private void b()
		{
			switch (this.m)
			{
			case 0:
			{
				byte[] array = this.n;
				int num = this.l;
				array[num] |= 128;
				this.m++;
				break;
			}
			case 1:
			{
				byte[] array2 = this.n;
				int num2 = this.l;
				array2[num2] |= 64;
				this.m++;
				break;
			}
			case 2:
			{
				byte[] array3 = this.n;
				int num3 = this.l;
				array3[num3] |= 32;
				this.m++;
				break;
			}
			case 3:
			{
				byte[] array4 = this.n;
				int num4 = this.l;
				array4[num4] |= 16;
				this.m++;
				break;
			}
			case 4:
			{
				byte[] array5 = this.n;
				int num5 = this.l;
				array5[num5] |= 8;
				this.m++;
				break;
			}
			case 5:
			{
				byte[] array6 = this.n;
				int num6 = this.l;
				array6[num6] |= 4;
				this.m++;
				break;
			}
			case 6:
			{
				byte[] array7 = this.n;
				int num7 = this.l;
				array7[num7] |= 2;
				this.m++;
				break;
			}
			default:
			{
				byte[] array8 = this.n;
				int num8 = this.l;
				array8[num8] |= 1;
				this.l++;
				this.m = 0;
				break;
			}
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0004DF68 File Offset: 0x0004CF68
		private void a()
		{
			this.m++;
			if (this.m == 8)
			{
				this.m = 0;
				this.l++;
			}
		}

		// Token: 0x040002A4 RID: 676
		private byte[] a;

		// Token: 0x040002A5 RID: 677
		private int b = 0;

		// Token: 0x040002A6 RID: 678
		private int c = 0;

		// Token: 0x040002A7 RID: 679
		private int d = 0;

		// Token: 0x040002A8 RID: 680
		private int e = 0;

		// Token: 0x040002A9 RID: 681
		private int f = 1;

		// Token: 0x040002AA RID: 682
		private int g = 1728;

		// Token: 0x040002AB RID: 683
		private bool h = true;

		// Token: 0x040002AC RID: 684
		private int i;

		// Token: 0x040002AD RID: 685
		private int j;

		// Token: 0x040002AE RID: 686
		private int k;

		// Token: 0x040002AF RID: 687
		private int l = 0;

		// Token: 0x040002B0 RID: 688
		private int m = 0;

		// Token: 0x040002B1 RID: 689
		private byte[] n;
	}
}
