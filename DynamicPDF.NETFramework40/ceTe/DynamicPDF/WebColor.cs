using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006BB RID: 1723
	public class WebColor : RgbColor
	{
		// Token: 0x06004289 RID: 17033 RVA: 0x00229CD0 File Offset: 0x00228CD0
		public WebColor(string webColor) : base(0, 0, 0)
		{
			if (webColor[0] == '#')
			{
				webColor = webColor.Replace("#", "");
				string value = webColor.Substring(0, 2);
				string value2 = webColor.Substring(2, 2);
				string value3 = webColor.Substring(4, 2);
				base.SetColor((byte)Convert.ToInt32(value, 16), (byte)Convert.ToInt32(value2, 16), (byte)Convert.ToInt32(value3, 16));
			}
			else if (this.c(webColor))
			{
				string value = webColor.Substring(0, 2);
				string value2 = webColor.Substring(2, 2);
				string value3 = webColor.Substring(4, 2);
				base.SetColor((byte)Convert.ToInt32(value, 16), (byte)Convert.ToInt32(value2, 16), (byte)Convert.ToInt32(value3, 16));
			}
			else
			{
				this.b(webColor);
			}
		}

		// Token: 0x0600428A RID: 17034 RVA: 0x00229DAC File Offset: 0x00228DAC
		private bool c(string A_0)
		{
			bool result;
			if (A_0.Length != 6)
			{
				result = false;
			}
			else
			{
				foreach (char c in A_0)
				{
					if ((c < '0' || c > '9') && (c < ')' || c > 'F') && (c < 'a' || c > 'f'))
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600428B RID: 17035 RVA: 0x00229E2C File Offset: 0x00228E2C
		internal override RgbColor m()
		{
			return new RgbColor(base.R, base.G, base.B);
		}

		// Token: 0x0600428C RID: 17036 RVA: 0x00229E58 File Offset: 0x00228E58
		private void b(string A_0)
		{
			int num = this.a(A_0);
			if (num <= 251826230)
			{
				if (num <= 91457417)
				{
					if (num <= 2491499)
					{
						if (num <= 402853)
						{
							if (num <= 78501)
							{
								if (num <= 20526)
								{
									if (num == 18596)
									{
										base.SetColor(byte.MaxValue, 0, 0);
										return;
									}
									if (num == 20526)
									{
										base.SetColor(210, 180, 140);
										return;
									}
								}
								else
								{
									if (num == 50849)
									{
										base.SetColor(0, byte.MaxValue, byte.MaxValue);
										return;
									}
									if (num == 78501)
									{
										base.SetColor(0, 0, byte.MaxValue);
										return;
									}
								}
							}
							else if (num <= 245124)
							{
								if (num == 123950)
								{
									base.SetColor(0, byte.MaxValue, byte.MaxValue);
									return;
								}
								if (num == 245124)
								{
									base.SetColor(byte.MaxValue, 215, 0);
									return;
								}
							}
							else
							{
								if (num == 247865)
								{
									base.SetColor(190, 190, 190);
									return;
								}
								if (num == 402853)
								{
									base.SetColor(0, byte.MaxValue, 0);
									return;
								}
							}
						}
						else if (num <= 537261)
						{
							if (num <= 530005)
							{
								if (num == 460505)
								{
									base.SetColor(0, 0, 128);
									return;
								}
								if (num == 530005)
								{
									base.SetColor(205, 133, 63);
									return;
								}
							}
							else
							{
								if (num == 533963)
								{
									base.SetColor(byte.MaxValue, 192, 203);
									return;
								}
								if (num == 537261)
								{
									base.SetColor(221, 160, 221);
									return;
								}
							}
						}
						else if (num <= 660524)
						{
							if (num == 637431)
							{
								base.SetColor(byte.MaxValue, 250, 250);
								return;
							}
							if (num == 660524)
							{
								base.SetColor(0, 128, 128);
								return;
							}
						}
						else
						{
							if (num == 1922629)
							{
								base.SetColor(240, byte.MaxValue, byte.MaxValue);
								return;
							}
							if (num == 2270437)
							{
								base.SetColor(245, 245, 220);
								return;
							}
							if (num == 2491499)
							{
								base.SetColor(0, 0, 0);
								return;
							}
						}
					}
					else if (num <= 16131781)
					{
						if (num <= 9024634)
						{
							if (num <= 3655724)
							{
								if (num == 2703086)
								{
									base.SetColor(165, 42, 42);
									return;
								}
								if (num == 3655724)
								{
									base.SetColor(byte.MaxValue, 127, 80);
									return;
								}
							}
							else
							{
								if (num == 7935150)
								{
									base.SetColor(0, 128, 0);
									return;
								}
								if (num == 9024634)
								{
									base.SetColor(132, 112, byte.MaxValue);
									return;
								}
							}
						}
						else if (num <= 10174041)
						{
							if (num == 9025112)
							{
								base.SetColor(119, 136, 153);
								return;
							}
							if (num == 10174041)
							{
								base.SetColor(byte.MaxValue, byte.MaxValue, 240);
								return;
							}
						}
						else
						{
							if (num == 11797865)
							{
								base.SetColor(240, 230, 140);
								return;
							}
							if (num == 12892334)
							{
								base.SetColor(250, 240, 230);
								return;
							}
							if (num == 16131781)
							{
								base.SetColor(128, 128, 0);
								return;
							}
						}
					}
					else if (num <= 51617892)
					{
						if (num <= 24389253)
						{
							if (num == 24384564)
							{
								base.SetColor(245, 222, 179);
								return;
							}
							if (num == 24389253)
							{
								base.SetColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
								return;
							}
						}
						else
						{
							if (num == 46448135)
							{
								base.SetColor(240, 248, byte.MaxValue);
								return;
							}
							if (num == 51617892)
							{
								base.SetColor(127, byte.MaxValue, 212);
								return;
							}
						}
					}
					else if (num <= 80553597)
					{
						if (num == 77186725)
						{
							base.SetColor(byte.MaxValue, 228, 196);
							return;
						}
						if (num == 80553597)
						{
							base.SetColor(138, 43, 226);
							return;
						}
					}
					else
					{
						if (num == 84716451)
						{
							base.SetColor(175, 238, 238);
							return;
						}
						if (num == 89722579)
						{
							base.SetColor(222, 184, 135);
							return;
						}
						if (num == 91457417)
						{
							base.SetColor(186, 85, 211);
							return;
						}
					}
				}
				else if (num <= 144088664)
				{
					if (num <= 135867595)
					{
						if (num <= 116997090)
						{
							if (num <= 109190391)
							{
								if (num == 101852199)
								{
									base.SetColor(95, 158, 160);
									return;
								}
								if (num == 109190391)
								{
									base.SetColor(127, byte.MaxValue, 0);
									return;
								}
							}
							else
							{
								if (num == 109546345)
								{
									base.SetColor(210, 105, 30);
									return;
								}
								if (num == 116997090)
								{
									base.SetColor(byte.MaxValue, 248, 220);
									return;
								}
							}
						}
						else if (num <= 135826646)
						{
							if (num == 119846497)
							{
								base.SetColor(237, 164, 61);
								return;
							}
							if (num == 135826646)
							{
								base.SetColor(153, 50, 204);
								return;
							}
						}
						else
						{
							if (num == 135866369)
							{
								base.SetColor(189, 183, 107);
								return;
							}
							if (num == 135867479)
							{
								base.SetColor(0, 139, 139);
								return;
							}
							if (num == 135867595)
							{
								base.SetColor(167, 167, 167);
								return;
							}
						}
					}
					else if (num <= 135894295)
					{
						if (num <= 135868137)
						{
							if (num == 135867969)
							{
								base.SetColor(139, 0, 0);
								return;
							}
							if (num == 135868137)
							{
								base.SetColor(0, 0, 139);
								return;
							}
						}
						else
						{
							if (num == 135870556)
							{
								base.SetColor(0, 100, 0);
								return;
							}
							if (num == 135894295)
							{
								base.SetColor(byte.MaxValue, 140, 0);
								return;
							}
						}
					}
					else if (num <= 136256399)
					{
						if (num == 136224381)
						{
							base.SetColor(148, 0, 211);
							return;
						}
						if (num == 136256399)
						{
							base.SetColor(233, 150, 122);
							return;
						}
					}
					else
					{
						if (num == 139641794)
						{
							base.SetColor(byte.MaxValue, 20, 147);
							return;
						}
						if (num == 141268768)
						{
							base.SetColor(139, 0, 139);
							return;
						}
						if (num == 144088664)
						{
							base.SetColor(105, 105, 105);
							return;
						}
					}
				}
				else if (num <= 206967362)
				{
					if (num <= 163836110)
					{
						if (num <= 150154775)
						{
							if (num == 147170349)
							{
								base.SetColor(byte.MaxValue, 250, 205);
								return;
							}
							if (num == 150154775)
							{
								base.SetColor(30, 144, byte.MaxValue);
								return;
							}
						}
						else
						{
							if (num == 161349808)
							{
								base.SetColor(250, 235, 215);
								return;
							}
							if (num == 163836110)
							{
								base.SetColor(0, 191, byte.MaxValue);
								return;
							}
						}
					}
					else if (num <= 190556156)
					{
						if (num == 174078667)
						{
							base.SetColor(143, 188, 143);
							return;
						}
						if (num == 190556156)
						{
							base.SetColor(72, 61, 139);
							return;
						}
					}
					else
					{
						if (num == 190558260)
						{
							base.SetColor(47, 79, 79);
							return;
						}
						if (num == 198380418)
						{
							base.SetColor(25, 25, 112);
							return;
						}
						if (num == 206967362)
						{
							base.SetColor(209, 146, 117);
							return;
						}
					}
				}
				else if (num <= 229895849)
				{
					if (num <= 211365945)
					{
						if (num == 209715930)
						{
							base.SetColor(34, 139, 34);
							return;
						}
						if (num == 211365945)
						{
							base.SetColor(178, 34, 34);
							return;
						}
					}
					else
					{
						if (num == 223453800)
						{
							base.SetColor(byte.MaxValue, 0, byte.MaxValue);
							return;
						}
						if (num == 229895849)
						{
							base.SetColor(byte.MaxValue, 250, 240);
							return;
						}
					}
				}
				else if (num <= 243271683)
				{
					if (num == 236225581)
					{
						base.SetColor(220, 220, 220);
						return;
					}
					if (num == 243271683)
					{
						base.SetColor(byte.MaxValue, 235, 205);
						return;
					}
				}
				else
				{
					if (num == 243525650)
					{
						base.SetColor(248, 248, byte.MaxValue);
						return;
					}
					if (num == 251025738)
					{
						base.SetColor(218, 165, 32);
						return;
					}
					if (num == 251826230)
					{
						base.SetColor(135, 206, 250);
						return;
					}
				}
			}
			else if (num <= 538158609)
			{
				if (num <= 412516444)
				{
					if (num <= 404428150)
					{
						if (num <= 284836133)
						{
							if (num <= 274437796)
							{
								if (num == 259302446)
								{
									base.SetColor(173, byte.MaxValue, 47);
									return;
								}
								if (num == 274437796)
								{
									base.SetColor(184, 134, 11);
									return;
								}
							}
							else
							{
								if (num == 284628883)
								{
									base.SetColor(240, byte.MaxValue, 240);
									return;
								}
								if (num == 284836133)
								{
									base.SetColor(byte.MaxValue, 105, 180);
									return;
								}
							}
						}
						else if (num <= 316810479)
						{
							if (num == 310405688)
							{
								base.SetColor(32, 178, 170);
								return;
							}
							if (num == 316810479)
							{
								base.SetColor(75, 0, 130);
								return;
							}
						}
						else
						{
							if (num == 316828810)
							{
								base.SetColor(205, 92, 92);
								return;
							}
							if (num == 322578303)
							{
								base.SetColor(byte.MaxValue, 240, 245);
								return;
							}
							if (num == 404428150)
							{
								base.SetColor(230, 230, 250);
								return;
							}
						}
					}
					else if (num <= 412321627)
					{
						if (num <= 404562734)
						{
							if (num == 404466780)
							{
								base.SetColor(124, 252, 0);
								return;
							}
							if (num == 404562734)
							{
								base.SetColor(250, 250, 210);
								return;
							}
						}
						else
						{
							if (num == 411408253)
							{
								base.SetColor(byte.MaxValue, 160, 122);
								return;
							}
							if (num == 412321627)
							{
								base.SetColor(byte.MaxValue, 182, 193);
								return;
							}
						}
					}
					else if (num <= 412337837)
					{
						if (num == 412323879)
						{
							base.SetColor(173, 216, 230);
							return;
						}
						if (num == 412337837)
						{
							base.SetColor(224, byte.MaxValue, byte.MaxValue);
							return;
						}
					}
					else
					{
						if (num == 412346942)
						{
							base.SetColor(211, 211, 211);
							return;
						}
						if (num == 412379823)
						{
							base.SetColor(240, 128, 128);
							return;
						}
						if (num == 412516444)
						{
							base.SetColor(50, 205, 50);
							return;
						}
					}
				}
				else if (num <= 446295383)
				{
					if (num <= 428601893)
					{
						if (num <= 415601518)
						{
							if (num == 412792361)
							{
								base.SetColor(144, 238, 144);
								return;
							}
							if (num == 415601518)
							{
								base.SetColor(byte.MaxValue, byte.MaxValue, 224);
								return;
							}
						}
						else
						{
							if (num == 423724745)
							{
								base.SetColor(102, 205, 170);
								return;
							}
							if (num == 428601893)
							{
								base.SetColor(100, 149, 237);
								return;
							}
						}
					}
					else if (num <= 437861870)
					{
						if (num == 437491157)
						{
							base.SetColor(byte.MaxValue, 0, byte.MaxValue);
							return;
						}
						if (num == 437861870)
						{
							base.SetColor(128, 0, 0);
							return;
						}
					}
					else
					{
						if (num == 441652232)
						{
							base.SetColor(0, 0, 205);
							return;
						}
						if (num == 446121055)
						{
							base.SetColor(245, byte.MaxValue, 250);
							return;
						}
						if (num == 446295383)
						{
							base.SetColor(byte.MaxValue, 228, 225);
							return;
						}
					}
				}
				else if (num <= 516042790)
				{
					if (num <= 461091591)
					{
						if (num == 452037917)
						{
							base.SetColor(byte.MaxValue, 228, 181);
							return;
						}
						if (num == 461091591)
						{
							base.SetColor(85, 107, 47);
							return;
						}
					}
					else
					{
						if (num == 493822922)
						{
							base.SetColor(byte.MaxValue, 222, 173);
							return;
						}
						if (num == 516042790)
						{
							base.SetColor(253, 245, 230);
							return;
						}
					}
				}
				else if (num <= 522238181)
				{
					if (num == 516198534)
					{
						base.SetColor(107, 142, 35);
						return;
					}
					if (num == 522238181)
					{
						base.SetColor(byte.MaxValue, 165, 0);
						return;
					}
				}
				else
				{
					if (num == 522252353)
					{
						base.SetColor(byte.MaxValue, 69, 0);
						return;
					}
					if (num == 522297636)
					{
						base.SetColor(218, 112, 214);
						return;
					}
					if (num == 538158609)
					{
						base.SetColor(byte.MaxValue, 239, 213);
						return;
					}
				}
			}
			else if (num <= 661664105)
			{
				if (num <= 641412971)
				{
					if (num <= 559497605)
					{
						if (num <= 542169558)
						{
							if (num == 538312796)
							{
								base.SetColor(152, 251, 152);
								return;
							}
							if (num == 542169558)
							{
								base.SetColor(byte.MaxValue, 218, 185);
								return;
							}
						}
						else
						{
							if (num == 553296407)
							{
								base.SetColor(176, 224, 230);
								return;
							}
							if (num == 559497605)
							{
								base.SetColor(128, 0, 128);
								return;
							}
						}
					}
					else if (num <= 620541735)
					{
						if (num == 620354236)
						{
							base.SetColor(188, 143, 143);
							return;
						}
						if (num == 620541735)
						{
							base.SetColor(65, 105, 225);
							return;
						}
					}
					else
					{
						if (num == 638989806)
						{
							base.SetColor(250, 128, 114);
							return;
						}
						if (num == 639512012)
						{
							base.SetColor(244, 164, 96);
							return;
						}
						if (num == 641412971)
						{
							base.SetColor(139, 69, 19);
							return;
						}
					}
				}
				else if (num <= 647387314)
				{
					if (num <= 642829449)
					{
						if (num == 642817771)
						{
							base.SetColor(46, 139, 87);
							return;
						}
						if (num == 642829449)
						{
							base.SetColor(byte.MaxValue, 245, 238);
							return;
						}
					}
					else
					{
						if (num == 647150017)
						{
							base.SetColor(160, 82, 45);
							return;
						}
						if (num == 647387314)
						{
							base.SetColor(192, 192, 192);
							return;
						}
					}
				}
				else if (num <= 650156190)
				{
					if (num == 649890192)
					{
						base.SetColor(135, 206, 235);
						return;
					}
					if (num == 650156190)
					{
						base.SetColor(112, 128, 144);
						return;
					}
				}
				else
				{
					if (num == 650174983)
					{
						base.SetColor(106, 90, 205);
						return;
					}
					if (num == 658679591)
					{
						base.SetColor(70, 130, 180);
						return;
					}
					if (num == 661664105)
					{
						base.SetColor(0, byte.MaxValue, 127);
						return;
					}
				}
			}
			else if (num <= 841950553)
			{
				if (num <= 748138676)
				{
					if (num <= 687244943)
					{
						if (num == 679792265)
						{
							base.SetColor(216, 191, 216);
							return;
						}
						if (num == 687244943)
						{
							base.SetColor(byte.MaxValue, 99, 71);
							return;
						}
					}
					else
					{
						if (num == 693723338)
						{
							base.SetColor(64, 224, 208);
							return;
						}
						if (num == 748138676)
						{
							base.SetColor(238, 130, 238);
							return;
						}
					}
				}
				else if (num <= 755209123)
				{
					if (num == 748156944)
					{
						base.SetColor(208, 32, 144);
						return;
					}
					if (num == 755209123)
					{
						base.SetColor(0, 206, 209);
						return;
					}
				}
				else
				{
					if (num == 780299734)
					{
						base.SetColor(245, 245, 245);
						return;
					}
					if (num == 817959034)
					{
						base.SetColor(176, 196, 222);
						return;
					}
					if (num == 841950553)
					{
						base.SetColor(154, 205, 50);
						return;
					}
				}
			}
			else if (num <= 945073828)
			{
				if (num <= 856376935)
				{
					if (num == 844509687)
					{
						base.SetColor(byte.MaxValue, byte.MaxValue, 0);
						return;
					}
					if (num == 856376935)
					{
						base.SetColor(72, 209, 204);
						return;
					}
				}
				else
				{
					if (num == 918937277)
					{
						base.SetColor(199, 21, 133);
						return;
					}
					if (num == 945073828)
					{
						base.SetColor(238, 232, 170);
						return;
					}
				}
			}
			else if (num <= 1006811206)
			{
				if (num == 990603048)
				{
					base.SetColor(147, 112, 219);
					return;
				}
				if (num == 1006811206)
				{
					base.SetColor(60, 179, 113);
					return;
				}
			}
			else
			{
				if (num == 1016251562)
				{
					base.SetColor(123, 104, 238);
					return;
				}
				if (num == 1025644484)
				{
					base.SetColor(0, 250, 154);
					return;
				}
				if (num == 1054131336)
				{
					base.SetColor(219, 112, 147);
					return;
				}
			}
			base.SetColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}

		// Token: 0x0600428D RID: 17037 RVA: 0x0022B560 File Offset: 0x0022A560
		private new int a(string A_0)
		{
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < A_0.Length; i++)
			{
				num2 <<= 5;
				num2 |= (int)(A_0[i] % ' ');
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
	}
}
