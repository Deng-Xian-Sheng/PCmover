using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200064D RID: 1613
	public abstract class Color
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06003D18 RID: 15640
		public abstract ColorSpace ColorSpace { get; }

		// Token: 0x06003D19 RID: 15641
		public abstract override bool Equals(object obj);

		// Token: 0x06003D1A RID: 15642
		public abstract override int GetHashCode();

		// Token: 0x06003D1B RID: 15643
		public abstract void DrawStroke(PageWriter writer);

		// Token: 0x06003D1C RID: 15644 RVA: 0x00211E10 File Offset: 0x00210E10
		public virtual void DrawStroke(OperatorWriter writer)
		{
			if (writer is PageWriter)
			{
				this.DrawStroke((PageWriter)writer);
				return;
			}
			throw new GeneratorException("Color cannot be drawn in this context.");
		}

		// Token: 0x06003D1D RID: 15645
		public abstract void DrawFill(PageWriter writer);

		// Token: 0x06003D1E RID: 15646 RVA: 0x00211E48 File Offset: 0x00210E48
		public virtual void DrawFill(OperatorWriter writer)
		{
			if (writer is PageWriter)
			{
				this.DrawFill((PageWriter)writer);
				return;
			}
			throw new GeneratorException("Color cannot be drawn in this context.");
		}

		// Token: 0x06003D1F RID: 15647 RVA: 0x00211E80 File Offset: 0x00210E80
		internal virtual RgbColor m()
		{
			return null;
		}

		// Token: 0x06003D20 RID: 15648 RVA: 0x00211E94 File Offset: 0x00210E94
		internal static Color d(string A_0)
		{
			Color result;
			try
			{
				A_0 = A_0.Trim();
				if (A_0[0] == '#')
				{
					A_0 = A_0.Replace("#", "");
					if (Color.c(A_0))
					{
						result = new WebColor(A_0);
					}
					else
					{
						result = Grayscale.Black;
					}
				}
				else if (Color.c(A_0))
				{
					result = new WebColor(A_0);
				}
				else if (A_0.Trim().IndexOf("(") >= 0)
				{
					int num = A_0.Trim().IndexOf(")");
					if (num < 0)
					{
						result = Grayscale.Black;
					}
					else
					{
						char[] array = A_0.Trim().ToCharArray();
						Color.a a = new Color.a(array);
						for (int i = 0; i <= array.Length - 1; i++)
						{
							if (array[i] != ',' && array[i] != '.' && array[i] != '(' && array[i] != ')' && array[i] != ' ' && array[i] != '-' && array[i] != 'r' && array[i] != 'R' && array[i] != 'g' && array[i] != 'G' && array[i] != 'b' && array[i] != 'B' && array[i] != 'c' && array[i] != 'C' && array[i] != 'm' && array[i] != 'M' && array[i] != 'y' && array[i] != 'Y' && array[i] != 'k' && array[i] != 'K' && array[i] != 'g' && array[i] != 'G' && array[i] != 'r' && array[i] != 'R' && array[i] != 'a' && array[i] != 'A' && array[i] != 'y' && array[i] != 'Y' && !a.a(array[i]))
							{
								return Grayscale.Black;
							}
						}
						if (a.a())
						{
							result = a.d();
						}
						else if (a.c())
						{
							result = a.f();
						}
						else if (a.b())
						{
							result = a.e();
						}
						else
						{
							result = Grayscale.Black;
						}
					}
				}
				else
				{
					for (int i = 0; i <= A_0.Length - 1; i++)
					{
						if (!char.IsLetter(A_0, i))
						{
							return Grayscale.Black;
						}
					}
					result = Color.b(A_0);
				}
			}
			catch
			{
				result = Grayscale.Black;
			}
			return result;
		}

		// Token: 0x06003D21 RID: 15649 RVA: 0x00212164 File Offset: 0x00211164
		internal static bool c(string A_0)
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

		// Token: 0x06003D22 RID: 15650 RVA: 0x002121E4 File Offset: 0x002111E4
		internal static Color b(string A_0)
		{
			int num = Color.a(A_0);
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
										return RgbColor.Red;
									}
									if (num == 20526)
									{
										return RgbColor.Tan;
									}
								}
								else
								{
									if (num == 50849)
									{
										return RgbColor.Aqua;
									}
									if (num == 78501)
									{
										return RgbColor.Blue;
									}
								}
							}
							else if (num <= 245124)
							{
								if (num == 123950)
								{
									return CmykColor.Cyan;
								}
								if (num == 245124)
								{
									return RgbColor.Gold;
								}
							}
							else
							{
								if (num == 247865)
								{
									return Grayscale.Gray;
								}
								if (num == 402853)
								{
									return RgbColor.Lime;
								}
							}
						}
						else if (num <= 537261)
						{
							if (num <= 530005)
							{
								if (num == 460505)
								{
									return RgbColor.Navy;
								}
								if (num == 530005)
								{
									return RgbColor.Peru;
								}
							}
							else
							{
								if (num == 533963)
								{
									return RgbColor.Pink;
								}
								if (num == 537261)
								{
									return RgbColor.Plum;
								}
							}
						}
						else if (num <= 660524)
						{
							if (num == 637431)
							{
								return RgbColor.Snow;
							}
							if (num == 660524)
							{
								return RgbColor.Teal;
							}
						}
						else
						{
							if (num == 1922629)
							{
								return RgbColor.Azure;
							}
							if (num == 2270437)
							{
								return RgbColor.Beige;
							}
							if (num == 2491499)
							{
								return Grayscale.Black;
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
									return RgbColor.Brown;
								}
								if (num == 3655724)
								{
									return RgbColor.Coral;
								}
							}
							else
							{
								if (num == 7935150)
								{
									return RgbColor.Green;
								}
								if (num == 9024634)
								{
									return RgbColor.LightSlateBlue;
								}
							}
						}
						else if (num <= 10174041)
						{
							if (num == 9025112)
							{
								return RgbColor.LightSlateGray;
							}
							if (num == 10174041)
							{
								return RgbColor.Ivory;
							}
						}
						else
						{
							if (num == 11797865)
							{
								return RgbColor.Khaki;
							}
							if (num == 12892334)
							{
								return RgbColor.Linen;
							}
							if (num == 16131781)
							{
								return RgbColor.Olive;
							}
						}
					}
					else if (num <= 51617892)
					{
						if (num <= 24389253)
						{
							if (num == 24384564)
							{
								return RgbColor.Wheat;
							}
							if (num == 24389253)
							{
								return Grayscale.White;
							}
						}
						else
						{
							if (num == 46448135)
							{
								return RgbColor.AliceBlue;
							}
							if (num == 51617892)
							{
								return RgbColor.Aquamarine;
							}
						}
					}
					else if (num <= 80553597)
					{
						if (num == 77186725)
						{
							return RgbColor.Bisque;
						}
						if (num == 80553597)
						{
							return RgbColor.BlueViolet;
						}
					}
					else
					{
						if (num == 84716451)
						{
							return RgbColor.PaleTurquoise;
						}
						if (num == 89722579)
						{
							return RgbColor.BurlyWood;
						}
						if (num == 91457417)
						{
							return RgbColor.MediumOrchid;
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
									return RgbColor.CadetBlue;
								}
								if (num == 109190391)
								{
									return RgbColor.Chartreuse;
								}
							}
							else
							{
								if (num == 109546345)
								{
									return RgbColor.Chocolate;
								}
								if (num == 116997090)
								{
									return RgbColor.Cornsilk;
								}
							}
						}
						else if (num <= 135826646)
						{
							if (num == 119846497)
							{
								return RgbColor.Crimson;
							}
							if (num == 135826646)
							{
								return RgbColor.DarkOrchid;
							}
						}
						else
						{
							if (num == 135866369)
							{
								return RgbColor.DarkKhaki;
							}
							if (num == 135867479)
							{
								return RgbColor.DarkCyan;
							}
							if (num == 135867595)
							{
								return Grayscale.DarkGray;
							}
						}
					}
					else if (num <= 135894295)
					{
						if (num <= 135868137)
						{
							if (num == 135867969)
							{
								return RgbColor.DarkRed;
							}
							if (num == 135868137)
							{
								return RgbColor.DarkBlue;
							}
						}
						else
						{
							if (num == 135870556)
							{
								return RgbColor.DarkGreen;
							}
							if (num == 135894295)
							{
								return RgbColor.DarkOrange;
							}
						}
					}
					else if (num <= 136256399)
					{
						if (num == 136224381)
						{
							return RgbColor.DarkViolet;
						}
						if (num == 136256399)
						{
							return RgbColor.DarkSalmon;
						}
					}
					else
					{
						if (num == 139641794)
						{
							return RgbColor.DeepPink;
						}
						if (num == 141268768)
						{
							return RgbColor.DarkMagenta;
						}
						if (num == 144088664)
						{
							return Grayscale.DimGray;
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
								return RgbColor.LemonChiffon;
							}
							if (num == 150154775)
							{
								return RgbColor.DodgerBlue;
							}
						}
						else
						{
							if (num == 161349808)
							{
								return RgbColor.AntiqueWhite;
							}
							if (num == 163836110)
							{
								return RgbColor.DeepSkyBlue;
							}
						}
					}
					else if (num <= 190556156)
					{
						if (num == 174078667)
						{
							return RgbColor.DarkSeaGreen;
						}
						if (num == 190556156)
						{
							return RgbColor.DarkSlateBlue;
						}
					}
					else
					{
						if (num == 190558260)
						{
							return RgbColor.DarkSlateGray;
						}
						if (num == 198380418)
						{
							return RgbColor.MidnightBlue;
						}
						if (num == 206967362)
						{
							return RgbColor.Feldspar;
						}
					}
				}
				else if (num <= 229895849)
				{
					if (num <= 211365945)
					{
						if (num == 209715930)
						{
							return RgbColor.ForestGreen;
						}
						if (num == 211365945)
						{
							return RgbColor.FireBrick;
						}
					}
					else
					{
						if (num == 223453800)
						{
							return RgbColor.Fuchsia;
						}
						if (num == 229895849)
						{
							return RgbColor.FloralWhite;
						}
					}
				}
				else if (num <= 243271683)
				{
					if (num == 236225581)
					{
						return RgbColor.Gainsboro;
					}
					if (num == 243271683)
					{
						return RgbColor.BlanchedAlmond;
					}
				}
				else
				{
					if (num == 243525650)
					{
						return RgbColor.GhostWhite;
					}
					if (num == 251025738)
					{
						return RgbColor.GoldenRod;
					}
					if (num == 251826230)
					{
						return RgbColor.LightSkyBlue;
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
									return RgbColor.GreenYellow;
								}
								if (num == 274437796)
								{
									return RgbColor.DarkGoldenRod;
								}
							}
							else
							{
								if (num == 284628883)
								{
									return RgbColor.HoneyDew;
								}
								if (num == 284836133)
								{
									return RgbColor.HotPink;
								}
							}
						}
						else if (num <= 316810479)
						{
							if (num == 310405688)
							{
								return RgbColor.LightSeaGreen;
							}
							if (num == 316810479)
							{
								return RgbColor.Indigo;
							}
						}
						else
						{
							if (num == 316828810)
							{
								return RgbColor.IndianRed;
							}
							if (num == 322578303)
							{
								return RgbColor.LavenderBlush;
							}
							if (num == 404428150)
							{
								return RgbColor.Lavender;
							}
						}
					}
					else if (num <= 412321627)
					{
						if (num <= 404562734)
						{
							if (num == 404466780)
							{
								return RgbColor.LawnGreen;
							}
							if (num == 404562734)
							{
								return RgbColor.LightGoldenRodYellow;
							}
						}
						else
						{
							if (num == 411408253)
							{
								return RgbColor.LightSalmon;
							}
							if (num == 412321627)
							{
								return RgbColor.LightPink;
							}
						}
					}
					else if (num <= 412337837)
					{
						if (num == 412323879)
						{
							return RgbColor.LightBlue;
						}
						if (num == 412337837)
						{
							return RgbColor.LightCyan;
						}
					}
					else
					{
						if (num == 412346942)
						{
							return Grayscale.LightGrey;
						}
						if (num == 412379823)
						{
							return RgbColor.LightCoral;
						}
						if (num == 412516444)
						{
							return RgbColor.LimeGreen;
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
								return RgbColor.LightGreen;
							}
							if (num == 415601518)
							{
								return RgbColor.LightYellow;
							}
						}
						else
						{
							if (num == 423724745)
							{
								return RgbColor.MediumAquaMarine;
							}
							if (num == 428601893)
							{
								return RgbColor.CornflowerBlue;
							}
						}
					}
					else if (num <= 437861870)
					{
						if (num == 437491157)
						{
							return CmykColor.Magenta;
						}
						if (num == 437861870)
						{
							return RgbColor.Maroon;
						}
					}
					else
					{
						if (num == 441652232)
						{
							return RgbColor.MediumBlue;
						}
						if (num == 446121055)
						{
							return RgbColor.MintCream;
						}
						if (num == 446295383)
						{
							return RgbColor.MistyRose;
						}
					}
				}
				else if (num <= 516042790)
				{
					if (num <= 461091591)
					{
						if (num == 452037917)
						{
							return RgbColor.Moccasin;
						}
						if (num == 461091591)
						{
							return RgbColor.DarkOliveGreen;
						}
					}
					else
					{
						if (num == 493822922)
						{
							return RgbColor.NavajoWhite;
						}
						if (num == 516042790)
						{
							return RgbColor.OldLace;
						}
					}
				}
				else if (num <= 522238181)
				{
					if (num == 516198534)
					{
						return RgbColor.OliveDrab;
					}
					if (num == 522238181)
					{
						return RgbColor.Orange;
					}
				}
				else
				{
					if (num == 522252353)
					{
						return RgbColor.OrangeRed;
					}
					if (num == 522297636)
					{
						return RgbColor.Orchid;
					}
					if (num == 538158609)
					{
						return RgbColor.PapayaWhip;
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
								return RgbColor.PaleGreen;
							}
							if (num == 542169558)
							{
								return RgbColor.PeachPuff;
							}
						}
						else
						{
							if (num == 553296407)
							{
								return RgbColor.PowderBlue;
							}
							if (num == 559497605)
							{
								return RgbColor.Purple;
							}
						}
					}
					else if (num <= 620541735)
					{
						if (num == 620354236)
						{
							return RgbColor.RosyBrown;
						}
						if (num == 620541735)
						{
							return RgbColor.RoyalBlue;
						}
					}
					else
					{
						if (num == 638989806)
						{
							return RgbColor.Salmon;
						}
						if (num == 639512012)
						{
							return RgbColor.SandyBrown;
						}
						if (num == 641412971)
						{
							return RgbColor.SaddleBrown;
						}
					}
				}
				else if (num <= 647387314)
				{
					if (num <= 642829449)
					{
						if (num == 642817771)
						{
							return RgbColor.SeaGreen;
						}
						if (num == 642829449)
						{
							return RgbColor.SeaShell;
						}
					}
					else
					{
						if (num == 647150017)
						{
							return RgbColor.Sienna;
						}
						if (num == 647387314)
						{
							return Grayscale.Silver;
						}
					}
				}
				else if (num <= 650156190)
				{
					if (num == 649890192)
					{
						return RgbColor.SkyBlue;
					}
					if (num == 650156190)
					{
						return RgbColor.SlateGray;
					}
				}
				else
				{
					if (num == 650174983)
					{
						return RgbColor.SlateBlue;
					}
					if (num == 658679591)
					{
						return RgbColor.SteelBlue;
					}
					if (num == 661664105)
					{
						return RgbColor.SpringGreen;
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
							return RgbColor.Thistle;
						}
						if (num == 687244943)
						{
							return RgbColor.Tomato;
						}
					}
					else
					{
						if (num == 693723338)
						{
							return RgbColor.Turquoise;
						}
						if (num == 748138676)
						{
							return RgbColor.Violet;
						}
					}
				}
				else if (num <= 755209123)
				{
					if (num == 748156944)
					{
						return RgbColor.VioletRed;
					}
					if (num == 755209123)
					{
						return RgbColor.DarkTurquoise;
					}
				}
				else
				{
					if (num == 780299734)
					{
						return RgbColor.WhiteSmoke;
					}
					if (num == 817959034)
					{
						return RgbColor.LightSteelBlue;
					}
					if (num == 841950553)
					{
						return RgbColor.YellowGreen;
					}
				}
			}
			else if (num <= 945073828)
			{
				if (num <= 856376935)
				{
					if (num == 844509687)
					{
						return CmykColor.Yellow;
					}
					if (num == 856376935)
					{
						return RgbColor.MediumTurquoise;
					}
				}
				else
				{
					if (num == 918937277)
					{
						return RgbColor.MediumVioletRed;
					}
					if (num == 945073828)
					{
						return RgbColor.PaleGoldenRod;
					}
				}
			}
			else if (num <= 1006811206)
			{
				if (num == 990603048)
				{
					return RgbColor.MediumPurple;
				}
				if (num == 1006811206)
				{
					return RgbColor.MediumSeaGreen;
				}
			}
			else
			{
				if (num == 1016251562)
				{
					return RgbColor.MediumSlateBlue;
				}
				if (num == 1025644484)
				{
					return RgbColor.MediumSpringGreen;
				}
				if (num == 1054131336)
				{
					return RgbColor.PaleVioletRed;
				}
			}
			return Grayscale.White;
		}

		// Token: 0x06003D23 RID: 15651 RVA: 0x00213184 File Offset: 0x00212184
		internal static int a(string A_0)
		{
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < A_0.Trim().Length; i++)
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

		// Token: 0x0200064E RID: 1614
		internal class a
		{
			// Token: 0x06003D24 RID: 15652 RVA: 0x002131F3 File Offset: 0x002121F3
			internal a(char[] A_0)
			{
				this.b = A_0;
				this.a = 0;
			}

			// Token: 0x06003D25 RID: 15653 RVA: 0x0021320C File Offset: 0x0021220C
			internal bool a()
			{
				int num = 0;
				for (int i = 0; i <= this.b.Length - 1; i++)
				{
					if ((this.b[i] == 'c' || this.b[i] == 'C') && i == 0)
					{
						num++;
					}
					else if ((this.b[i] == 'm' || this.b[i] == 'M') && num == 1)
					{
						num++;
					}
					else if ((this.b[i] == 'y' || this.b[i] == 'Y') && num == 2)
					{
						num++;
					}
					else
					{
						if ((this.b[i] == 'k' || this.b[i] == 'K') && num == 3)
						{
							num++;
							break;
						}
						return false;
					}
				}
				return true;
			}

			// Token: 0x06003D26 RID: 15654 RVA: 0x00213308 File Offset: 0x00212308
			internal bool b()
			{
				int num = 0;
				for (int i = 0; i <= this.b.Length - 1; i++)
				{
					if ((this.b[i] == 'r' || this.b[i] == 'R') && i == 0)
					{
						num++;
					}
					else if ((this.b[i] == 'g' || this.b[i] == 'G') && num == 1)
					{
						num++;
					}
					else
					{
						if ((this.b[i] == 'b' || this.b[i] == 'B') && num == 2)
						{
							num++;
							break;
						}
						return false;
					}
				}
				return true;
			}

			// Token: 0x06003D27 RID: 15655 RVA: 0x002133D4 File Offset: 0x002123D4
			internal bool c()
			{
				int num = 0;
				for (int i = 0; i <= this.b.Length - 1; i++)
				{
					if ((this.b[i] == 'g' || this.b[i] == 'G') && i == 0)
					{
						num++;
					}
					else if ((this.b[i] == 'r' || this.b[i] == 'R') && num == 1)
					{
						num++;
					}
					else if ((this.b[i] == 'a' || this.b[i] == 'A') && num == 2)
					{
						num++;
					}
					else
					{
						if ((this.b[i] == 'y' || this.b[i] == 'Y') && num == 3)
						{
							num++;
							break;
						}
						return false;
					}
				}
				return true;
			}

			// Token: 0x06003D28 RID: 15656 RVA: 0x002134D0 File Offset: 0x002124D0
			internal float a(char[] A_0, int A_1)
			{
				int num = 0;
				while (A_0[A_1] == '0')
				{
					if (A_1 < A_0.Length - 1)
					{
						A_1++;
					}
				}
				while (this.a(A_0[A_1]))
				{
					num = num * 10 + (int)A_0[A_1] - 48;
					if (A_1 >= A_0.Length - 1)
					{
						break;
					}
					A_1++;
				}
				float result;
				if (A_0[A_1] == '.')
				{
					if (A_1 < A_0.Length - 1)
					{
						A_1++;
					}
					int num2 = 1;
					while (this.a(A_0[A_1]))
					{
						num = num * 10 + (int)A_0[A_1] - 48;
						num2 *= 10;
						if (A_1 >= A_0.Length - 1)
						{
							break;
						}
						A_1++;
					}
					this.a = A_1;
					result = (float)num / (float)num2;
				}
				else
				{
					this.a = A_1;
					result = (float)num;
				}
				return result;
			}

			// Token: 0x06003D29 RID: 15657 RVA: 0x002135B4 File Offset: 0x002125B4
			internal bool a(char A_0)
			{
				return A_0 >= '0' && A_0 <= '9';
			}

			// Token: 0x06003D2A RID: 15658 RVA: 0x002135D8 File Offset: 0x002125D8
			internal Color d()
			{
				int num = 0;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				this.a = 0;
				while (this.a <= this.b.Length - 1)
				{
					if (this.a(this.b[this.a]) || this.b[this.a] == '.')
					{
						if (num == 0)
						{
							if (this.b[this.a - 1] == '-')
							{
								num2 = this.a(this.b, this.a);
								num2 = 0f;
							}
							else
							{
								num2 = this.a(this.b, this.a);
								if ((double)num2 > 1.0)
								{
									num2 = 1f;
								}
							}
							num++;
						}
						else if (num == 1)
						{
							if (this.b[this.a - 1] == '-')
							{
								num3 = this.a(this.b, this.a);
								num3 = 0f;
							}
							else
							{
								num3 = this.a(this.b, this.a);
								if ((double)num3 > 1.0)
								{
									num3 = 1f;
								}
							}
							num++;
						}
						else if (num == 2)
						{
							if (this.b[this.a - 1] == '-')
							{
								num4 = this.a(this.b, this.a);
								num4 = 0f;
							}
							else
							{
								num4 = this.a(this.b, this.a);
								if ((double)num4 > 1.0)
								{
									num4 = 1f;
								}
							}
							num++;
						}
						else
						{
							if (num != 3)
							{
								return CmykColor.Black;
							}
							if (this.b[this.a - 1] == '-')
							{
								num5 = this.a(this.b, this.a);
								num5 = 0f;
							}
							else
							{
								num5 = this.a(this.b, this.a);
								if ((double)num5 > 1.0)
								{
									num5 = 1f;
								}
							}
							num++;
						}
					}
					this.a++;
				}
				return new CmykColor(num2, num3, num4, num5);
			}

			// Token: 0x06003D2B RID: 15659 RVA: 0x002138A8 File Offset: 0x002128A8
			internal Color e()
			{
				int num = 0;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				this.a = 0;
				while (this.a <= this.b.Length - 1)
				{
					if (this.a(this.b[this.a]) || this.b[this.a] == '.')
					{
						if (num == 0)
						{
							if (this.b[this.a - 1] == '-')
							{
								num2 = this.a(this.b, this.a);
								num2 = 0f;
							}
							else
							{
								num2 = this.a(this.b, this.a);
								if ((double)num2 > 1.0)
								{
									num2 = 1f;
								}
							}
							num++;
						}
						else if (num == 1)
						{
							if (this.b[this.a - 1] == '-')
							{
								num3 = this.a(this.b, this.a);
								num3 = 0f;
							}
							else
							{
								num3 = this.a(this.b, this.a);
								if ((double)num3 > 1.0)
								{
									num3 = 1f;
								}
							}
							num++;
						}
						else
						{
							if (num != 2)
							{
								return RgbColor.Black;
							}
							if (this.b[this.a - 1] == '-')
							{
								num4 = this.a(this.b, this.a);
								num4 = 0f;
							}
							else
							{
								num4 = this.a(this.b, this.a);
								if ((double)num4 > 1.0)
								{
									num4 = 1f;
								}
							}
							num++;
						}
					}
					this.a++;
				}
				return new RgbColor(num2, num3, num4);
			}

			// Token: 0x06003D2C RID: 15660 RVA: 0x00213AE0 File Offset: 0x00212AE0
			internal Color f()
			{
				int num = 0;
				float num2 = 0f;
				this.a = 0;
				while (this.a <= this.b.Length - 1)
				{
					if (this.a(this.b[this.a]) || this.b[this.a] == '.')
					{
						if (num != 0)
						{
							return Grayscale.Black;
						}
						if (this.b[this.a - 1] == '-')
						{
							num2 = 0f;
						}
						else
						{
							num2 = this.a(this.b, this.a);
							if ((double)num2 > 1.0)
							{
								num2 = 1f;
							}
							num++;
						}
					}
					this.a++;
				}
				return new Grayscale(num2);
			}

			// Token: 0x040020E6 RID: 8422
			private int a;

			// Token: 0x040020E7 RID: 8423
			private char[] b;
		}
	}
}
