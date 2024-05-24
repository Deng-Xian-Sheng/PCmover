using System;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006AE RID: 1710
	public class RgbColor : DeviceColor
	{
		// Token: 0x060040A5 RID: 16549 RVA: 0x00222994 File Offset: 0x00221994
		public RgbColor(float red, float green, float blue)
		{
			if (red < 0f || red > 1f || green < 0f || green > 1f || blue < 0f || blue > 1f)
			{
				throw new GeneratorException("RGB values must be from 0.0 to 1.0.");
			}
			this.a = red;
			this.b = green;
			this.c = blue;
		}

		// Token: 0x060040A6 RID: 16550 RVA: 0x00222A06 File Offset: 0x00221A06
		public RgbColor(byte red, byte green, byte blue)
		{
			this.a = (float)red / 255f;
			this.b = (float)green / 255f;
			this.c = (float)blue / 255f;
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060040A7 RID: 16551 RVA: 0x00222A3C File Offset: 0x00221A3C
		public override int Components
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060040A8 RID: 16552 RVA: 0x00222A50 File Offset: 0x00221A50
		public override ColorSpace ColorSpace
		{
			get
			{
				return ColorSpace.DeviceRgb;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060040A9 RID: 16553 RVA: 0x00222A68 File Offset: 0x00221A68
		public float R
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060040AA RID: 16554 RVA: 0x00222A80 File Offset: 0x00221A80
		public float G
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060040AB RID: 16555 RVA: 0x00222A98 File Offset: 0x00221A98
		public float B
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x060040AC RID: 16556 RVA: 0x00222AB0 File Offset: 0x00221AB0
		public override bool Equals(object obj)
		{
			return obj is RgbColor && this.R == ((RgbColor)obj).R && this.G == ((RgbColor)obj).G && this.B == ((RgbColor)obj).B;
		}

		// Token: 0x060040AD RID: 16557 RVA: 0x00222B08 File Offset: 0x00221B08
		public override int GetHashCode()
		{
			return this.a.GetHashCode() ^ this.b.GetHashCode() ^ this.c.GetHashCode();
		}

		// Token: 0x060040AE RID: 16558 RVA: 0x00222B40 File Offset: 0x00221B40
		public override void ToStringBuilder(StringBuilder stringBuilder)
		{
			base.a(stringBuilder, this.a);
			stringBuilder.Append(' ');
			base.a(stringBuilder, this.b);
			stringBuilder.Append(' ');
			base.a(stringBuilder, this.c);
			stringBuilder.Append(" rg");
		}

		// Token: 0x060040AF RID: 16559 RVA: 0x00222B96 File Offset: 0x00221B96
		public override void DrawStroke(OperatorWriter writer)
		{
			writer.Write_RG(this);
		}

		// Token: 0x060040B0 RID: 16560 RVA: 0x00222BA1 File Offset: 0x00221BA1
		public override void DrawFill(OperatorWriter writer)
		{
			writer.Write_rg_(this);
		}

		// Token: 0x060040B1 RID: 16561 RVA: 0x00222BAC File Offset: 0x00221BAC
		protected void SetColor(float red, float green, float blue)
		{
			if (this.a < 0f || this.a > 1f || this.b < 0f || this.b > 1f || this.c < 0f || this.c > 1f)
			{
				throw new GeneratorException("RBG values must be from 0.0 to 1.0.");
			}
			this.a = red;
			this.b = green;
			this.c = blue;
		}

		// Token: 0x060040B2 RID: 16562 RVA: 0x00222C34 File Offset: 0x00221C34
		protected void SetColor(byte red, byte green, byte blue)
		{
			this.a = (float)red / 255f;
			this.b = (float)green / 255f;
			this.c = (float)blue / 255f;
		}

		// Token: 0x060040B3 RID: 16563 RVA: 0x00222C61 File Offset: 0x00221C61
		internal override void gr(DocumentWriter A_0)
		{
			A_0.WriteArrayOpen();
			A_0.WriteNumberColor(this.a);
			A_0.WriteNumberColor(this.b);
			A_0.WriteNumberColor(this.c);
			A_0.WriteArrayClose();
		}

		// Token: 0x060040B4 RID: 16564 RVA: 0x00222C9C File Offset: 0x00221C9C
		internal override RgbColor m()
		{
			return this;
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060040B5 RID: 16565 RVA: 0x00222CB0 File Offset: 0x00221CB0
		public static RgbColor Black
		{
			get
			{
				RgbColor.dj();
				return RgbColor.d;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060040B6 RID: 16566 RVA: 0x00222CD0 File Offset: 0x00221CD0
		public static RgbColor Silver
		{
			get
			{
				RgbColor.di();
				return RgbColor.e;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060040B7 RID: 16567 RVA: 0x00222CF0 File Offset: 0x00221CF0
		public static RgbColor DarkGray
		{
			get
			{
				RgbColor.dh();
				return RgbColor.f;
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060040B8 RID: 16568 RVA: 0x00222D10 File Offset: 0x00221D10
		public static RgbColor Gray
		{
			get
			{
				RgbColor.dg();
				return RgbColor.g;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060040B9 RID: 16569 RVA: 0x00222D30 File Offset: 0x00221D30
		public static RgbColor DimGray
		{
			get
			{
				RgbColor.df();
				return RgbColor.h;
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060040BA RID: 16570 RVA: 0x00222D50 File Offset: 0x00221D50
		public static RgbColor White
		{
			get
			{
				RgbColor.de();
				return RgbColor.i;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060040BB RID: 16571 RVA: 0x00222D70 File Offset: 0x00221D70
		public static RgbColor Red
		{
			get
			{
				RgbColor.dd();
				return RgbColor.j;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060040BC RID: 16572 RVA: 0x00222D90 File Offset: 0x00221D90
		public static RgbColor Green
		{
			get
			{
				RgbColor.dc();
				return RgbColor.k;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x060040BD RID: 16573 RVA: 0x00222DB0 File Offset: 0x00221DB0
		public static RgbColor Lime
		{
			get
			{
				RgbColor.db();
				return RgbColor.l;
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060040BE RID: 16574 RVA: 0x00222DD0 File Offset: 0x00221DD0
		public static RgbColor Aqua
		{
			get
			{
				RgbColor.da();
				return RgbColor.m;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060040BF RID: 16575 RVA: 0x00222DF0 File Offset: 0x00221DF0
		public static RgbColor Purple
		{
			get
			{
				RgbColor.c9();
				return RgbColor.n;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x060040C0 RID: 16576 RVA: 0x00222E10 File Offset: 0x00221E10
		public static RgbColor Blue
		{
			get
			{
				RgbColor.c8();
				return RgbColor.o;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x060040C1 RID: 16577 RVA: 0x00222E30 File Offset: 0x00221E30
		public static RgbColor Cyan
		{
			get
			{
				RgbColor.c7();
				return RgbColor.p;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x060040C2 RID: 16578 RVA: 0x00222E50 File Offset: 0x00221E50
		public static RgbColor Magenta
		{
			get
			{
				RgbColor.c6();
				return RgbColor.q;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060040C3 RID: 16579 RVA: 0x00222E70 File Offset: 0x00221E70
		public static RgbColor Yellow
		{
			get
			{
				RgbColor.c5();
				return RgbColor.r;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060040C4 RID: 16580 RVA: 0x00222E90 File Offset: 0x00221E90
		public static RgbColor AliceBlue
		{
			get
			{
				RgbColor.c4();
				return RgbColor.s;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060040C5 RID: 16581 RVA: 0x00222EB0 File Offset: 0x00221EB0
		public static RgbColor AntiqueWhite
		{
			get
			{
				RgbColor.c3();
				return RgbColor.t;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060040C6 RID: 16582 RVA: 0x00222ED0 File Offset: 0x00221ED0
		public static RgbColor Aquamarine
		{
			get
			{
				RgbColor.c2();
				return RgbColor.u;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060040C7 RID: 16583 RVA: 0x00222EF0 File Offset: 0x00221EF0
		public static RgbColor Azure
		{
			get
			{
				RgbColor.c1();
				return RgbColor.v;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060040C8 RID: 16584 RVA: 0x00222F10 File Offset: 0x00221F10
		public static RgbColor Beige
		{
			get
			{
				RgbColor.c0();
				return RgbColor.w;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060040C9 RID: 16585 RVA: 0x00222F30 File Offset: 0x00221F30
		public static RgbColor Bisque
		{
			get
			{
				RgbColor.cz();
				return RgbColor.x;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060040CA RID: 16586 RVA: 0x00222F50 File Offset: 0x00221F50
		public static RgbColor BlanchedAlmond
		{
			get
			{
				RgbColor.cy();
				return RgbColor.y;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060040CB RID: 16587 RVA: 0x00222F70 File Offset: 0x00221F70
		public static RgbColor BlueViolet
		{
			get
			{
				RgbColor.cx();
				return RgbColor.z;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060040CC RID: 16588 RVA: 0x00222F90 File Offset: 0x00221F90
		public static RgbColor Brown
		{
			get
			{
				RgbColor.cw();
				return RgbColor.aa;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060040CD RID: 16589 RVA: 0x00222FB0 File Offset: 0x00221FB0
		public static RgbColor BurlyWood
		{
			get
			{
				RgbColor.cv();
				return RgbColor.ab;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060040CE RID: 16590 RVA: 0x00222FD0 File Offset: 0x00221FD0
		public static RgbColor CadetBlue
		{
			get
			{
				RgbColor.cu();
				return RgbColor.ac;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060040CF RID: 16591 RVA: 0x00222FF0 File Offset: 0x00221FF0
		public static RgbColor Chartreuse
		{
			get
			{
				RgbColor.ct();
				return RgbColor.ad;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060040D0 RID: 16592 RVA: 0x00223010 File Offset: 0x00222010
		public static RgbColor Chocolate
		{
			get
			{
				RgbColor.cs();
				return RgbColor.ae;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060040D1 RID: 16593 RVA: 0x00223030 File Offset: 0x00222030
		public static RgbColor Coral
		{
			get
			{
				RgbColor.cr();
				return RgbColor.af;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060040D2 RID: 16594 RVA: 0x00223050 File Offset: 0x00222050
		public static RgbColor CornflowerBlue
		{
			get
			{
				RgbColor.cq();
				return RgbColor.ag;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060040D3 RID: 16595 RVA: 0x00223070 File Offset: 0x00222070
		public static RgbColor Cornsilk
		{
			get
			{
				RgbColor.cp();
				return RgbColor.ah;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060040D4 RID: 16596 RVA: 0x00223090 File Offset: 0x00222090
		public static RgbColor Crimson
		{
			get
			{
				RgbColor.co();
				return RgbColor.ai;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060040D5 RID: 16597 RVA: 0x002230B0 File Offset: 0x002220B0
		public static RgbColor DarkBlue
		{
			get
			{
				RgbColor.cn();
				return RgbColor.aj;
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060040D6 RID: 16598 RVA: 0x002230D0 File Offset: 0x002220D0
		public static RgbColor DarkCyan
		{
			get
			{
				RgbColor.cm();
				return RgbColor.ak;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060040D7 RID: 16599 RVA: 0x002230F0 File Offset: 0x002220F0
		public static RgbColor DarkGoldenRod
		{
			get
			{
				RgbColor.cl();
				return RgbColor.al;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060040D8 RID: 16600 RVA: 0x00223110 File Offset: 0x00222110
		public static RgbColor DarkGreen
		{
			get
			{
				RgbColor.ck();
				return RgbColor.am;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060040D9 RID: 16601 RVA: 0x00223130 File Offset: 0x00222130
		public static RgbColor DarkKhaki
		{
			get
			{
				RgbColor.cj();
				return RgbColor.an;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060040DA RID: 16602 RVA: 0x00223150 File Offset: 0x00222150
		public static RgbColor DarkMagenta
		{
			get
			{
				RgbColor.ci();
				return RgbColor.ao;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060040DB RID: 16603 RVA: 0x00223170 File Offset: 0x00222170
		public static RgbColor DarkOliveGreen
		{
			get
			{
				RgbColor.ch();
				return RgbColor.ap;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060040DC RID: 16604 RVA: 0x00223190 File Offset: 0x00222190
		public static RgbColor DarkOrange
		{
			get
			{
				RgbColor.cg();
				return RgbColor.aq;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060040DD RID: 16605 RVA: 0x002231B0 File Offset: 0x002221B0
		public static RgbColor DarkOrchid
		{
			get
			{
				RgbColor.cf();
				return RgbColor.ar;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060040DE RID: 16606 RVA: 0x002231D0 File Offset: 0x002221D0
		public static RgbColor DarkRed
		{
			get
			{
				RgbColor.ce();
				return RgbColor.@as;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060040DF RID: 16607 RVA: 0x002231F0 File Offset: 0x002221F0
		public static RgbColor DarkSalmon
		{
			get
			{
				RgbColor.cd();
				return RgbColor.at;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060040E0 RID: 16608 RVA: 0x00223210 File Offset: 0x00222210
		public static RgbColor DarkSeaGreen
		{
			get
			{
				RgbColor.cc();
				return RgbColor.au;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060040E1 RID: 16609 RVA: 0x00223230 File Offset: 0x00222230
		public static RgbColor DarkSlateBlue
		{
			get
			{
				RgbColor.cb();
				return RgbColor.av;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060040E2 RID: 16610 RVA: 0x00223250 File Offset: 0x00222250
		public static RgbColor DarkSlateGray
		{
			get
			{
				RgbColor.ca();
				return RgbColor.aw;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060040E3 RID: 16611 RVA: 0x00223270 File Offset: 0x00222270
		public static RgbColor DarkTurquoise
		{
			get
			{
				RgbColor.b9();
				return RgbColor.ax;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060040E4 RID: 16612 RVA: 0x00223290 File Offset: 0x00222290
		public static RgbColor DarkViolet
		{
			get
			{
				RgbColor.b8();
				return RgbColor.ay;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060040E5 RID: 16613 RVA: 0x002232B0 File Offset: 0x002222B0
		public static RgbColor DeepPink
		{
			get
			{
				RgbColor.b7();
				return RgbColor.az;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060040E6 RID: 16614 RVA: 0x002232D0 File Offset: 0x002222D0
		public static RgbColor DeepSkyBlue
		{
			get
			{
				RgbColor.b6();
				return RgbColor.a0;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060040E7 RID: 16615 RVA: 0x002232F0 File Offset: 0x002222F0
		public static RgbColor DodgerBlue
		{
			get
			{
				RgbColor.b5();
				return RgbColor.a1;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060040E8 RID: 16616 RVA: 0x00223310 File Offset: 0x00222310
		public static RgbColor Feldspar
		{
			get
			{
				RgbColor.b4();
				return RgbColor.a2;
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060040E9 RID: 16617 RVA: 0x00223330 File Offset: 0x00222330
		public static RgbColor FireBrick
		{
			get
			{
				RgbColor.b3();
				return RgbColor.a3;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060040EA RID: 16618 RVA: 0x00223350 File Offset: 0x00222350
		public static RgbColor FloralWhite
		{
			get
			{
				RgbColor.b2();
				return RgbColor.a4;
			}
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060040EB RID: 16619 RVA: 0x00223370 File Offset: 0x00222370
		public static RgbColor ForestGreen
		{
			get
			{
				RgbColor.b1();
				return RgbColor.a5;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060040EC RID: 16620 RVA: 0x00223390 File Offset: 0x00222390
		public static RgbColor Fuchsia
		{
			get
			{
				RgbColor.b0();
				return RgbColor.a6;
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060040ED RID: 16621 RVA: 0x002233B0 File Offset: 0x002223B0
		public static RgbColor Gainsboro
		{
			get
			{
				RgbColor.bz();
				return RgbColor.a7;
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060040EE RID: 16622 RVA: 0x002233D0 File Offset: 0x002223D0
		public static RgbColor GhostWhite
		{
			get
			{
				RgbColor.by();
				return RgbColor.a8;
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x060040EF RID: 16623 RVA: 0x002233F0 File Offset: 0x002223F0
		public static RgbColor Gold
		{
			get
			{
				RgbColor.bx();
				return RgbColor.a9;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x060040F0 RID: 16624 RVA: 0x00223410 File Offset: 0x00222410
		public static RgbColor GoldenRod
		{
			get
			{
				RgbColor.bw();
				return RgbColor.ba;
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x060040F1 RID: 16625 RVA: 0x00223430 File Offset: 0x00222430
		public static RgbColor GreenYellow
		{
			get
			{
				RgbColor.bv();
				return RgbColor.bb;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x060040F2 RID: 16626 RVA: 0x00223450 File Offset: 0x00222450
		public static RgbColor HoneyDew
		{
			get
			{
				RgbColor.bu();
				return RgbColor.bc;
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x060040F3 RID: 16627 RVA: 0x00223470 File Offset: 0x00222470
		public static RgbColor HotPink
		{
			get
			{
				RgbColor.bt();
				return RgbColor.bd;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x060040F4 RID: 16628 RVA: 0x00223490 File Offset: 0x00222490
		public static RgbColor IndianRed
		{
			get
			{
				RgbColor.bs();
				return RgbColor.be;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x060040F5 RID: 16629 RVA: 0x002234B0 File Offset: 0x002224B0
		public static RgbColor Indigo
		{
			get
			{
				RgbColor.br();
				return RgbColor.bf;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x060040F6 RID: 16630 RVA: 0x002234D0 File Offset: 0x002224D0
		public static RgbColor Ivory
		{
			get
			{
				RgbColor.bq();
				return RgbColor.bg;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x060040F7 RID: 16631 RVA: 0x002234F0 File Offset: 0x002224F0
		public static RgbColor Khaki
		{
			get
			{
				RgbColor.bp();
				return RgbColor.bh;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x060040F8 RID: 16632 RVA: 0x00223510 File Offset: 0x00222510
		public static RgbColor Lavender
		{
			get
			{
				RgbColor.bo();
				return RgbColor.bi;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060040F9 RID: 16633 RVA: 0x00223530 File Offset: 0x00222530
		public static RgbColor LavenderBlush
		{
			get
			{
				RgbColor.bn();
				return RgbColor.bj;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060040FA RID: 16634 RVA: 0x00223550 File Offset: 0x00222550
		public static RgbColor LawnGreen
		{
			get
			{
				RgbColor.bm();
				return RgbColor.bk;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060040FB RID: 16635 RVA: 0x00223570 File Offset: 0x00222570
		public static RgbColor LemonChiffon
		{
			get
			{
				RgbColor.bl();
				return RgbColor.bl;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060040FC RID: 16636 RVA: 0x00223590 File Offset: 0x00222590
		public static RgbColor LightBlue
		{
			get
			{
				RgbColor.bk();
				return RgbColor.bm;
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060040FD RID: 16637 RVA: 0x002235B0 File Offset: 0x002225B0
		public static RgbColor LightCoral
		{
			get
			{
				RgbColor.bj();
				return RgbColor.bn;
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060040FE RID: 16638 RVA: 0x002235D0 File Offset: 0x002225D0
		public static RgbColor LightCyan
		{
			get
			{
				RgbColor.bi();
				return RgbColor.bo;
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060040FF RID: 16639 RVA: 0x002235F0 File Offset: 0x002225F0
		public static RgbColor LightGoldenRodYellow
		{
			get
			{
				RgbColor.bh();
				return RgbColor.bp;
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06004100 RID: 16640 RVA: 0x00223610 File Offset: 0x00222610
		public static RgbColor LightGrey
		{
			get
			{
				RgbColor.bg();
				return RgbColor.bq;
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06004101 RID: 16641 RVA: 0x00223630 File Offset: 0x00222630
		public static RgbColor LightGreen
		{
			get
			{
				RgbColor.bf();
				return RgbColor.br;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06004102 RID: 16642 RVA: 0x00223650 File Offset: 0x00222650
		public static RgbColor LightPink
		{
			get
			{
				RgbColor.be();
				return RgbColor.bs;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06004103 RID: 16643 RVA: 0x00223670 File Offset: 0x00222670
		public static RgbColor LightSalmon
		{
			get
			{
				RgbColor.bd();
				return RgbColor.bt;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06004104 RID: 16644 RVA: 0x00223690 File Offset: 0x00222690
		public static RgbColor LightSeaGreen
		{
			get
			{
				RgbColor.bc();
				return RgbColor.bu;
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06004105 RID: 16645 RVA: 0x002236B0 File Offset: 0x002226B0
		public static RgbColor LightSkyBlue
		{
			get
			{
				RgbColor.bb();
				return RgbColor.bv;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06004106 RID: 16646 RVA: 0x002236D0 File Offset: 0x002226D0
		public static RgbColor LightSlateBlue
		{
			get
			{
				RgbColor.ba();
				return RgbColor.bw;
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06004107 RID: 16647 RVA: 0x002236F0 File Offset: 0x002226F0
		public static RgbColor LightSlateGray
		{
			get
			{
				RgbColor.a9();
				return RgbColor.bx;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06004108 RID: 16648 RVA: 0x00223710 File Offset: 0x00222710
		public static RgbColor LightSteelBlue
		{
			get
			{
				RgbColor.a8();
				return RgbColor.by;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06004109 RID: 16649 RVA: 0x00223730 File Offset: 0x00222730
		public static RgbColor LightYellow
		{
			get
			{
				RgbColor.a7();
				return RgbColor.bz;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x0600410A RID: 16650 RVA: 0x00223750 File Offset: 0x00222750
		public static RgbColor LimeGreen
		{
			get
			{
				RgbColor.a6();
				return RgbColor.b0;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600410B RID: 16651 RVA: 0x00223770 File Offset: 0x00222770
		public static RgbColor Linen
		{
			get
			{
				RgbColor.a5();
				return RgbColor.b1;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x0600410C RID: 16652 RVA: 0x00223790 File Offset: 0x00222790
		public static RgbColor Maroon
		{
			get
			{
				RgbColor.a4();
				return RgbColor.b2;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600410D RID: 16653 RVA: 0x002237B0 File Offset: 0x002227B0
		public static RgbColor MediumAquaMarine
		{
			get
			{
				RgbColor.a3();
				return RgbColor.b3;
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x0600410E RID: 16654 RVA: 0x002237D0 File Offset: 0x002227D0
		public static RgbColor MediumBlue
		{
			get
			{
				RgbColor.a2();
				return RgbColor.b4;
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x0600410F RID: 16655 RVA: 0x002237F0 File Offset: 0x002227F0
		public static RgbColor MediumOrchid
		{
			get
			{
				RgbColor.a1();
				return RgbColor.b5;
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06004110 RID: 16656 RVA: 0x00223810 File Offset: 0x00222810
		public static RgbColor MediumPurple
		{
			get
			{
				RgbColor.a0();
				return RgbColor.b6;
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06004111 RID: 16657 RVA: 0x00223830 File Offset: 0x00222830
		public static RgbColor MediumSeaGreen
		{
			get
			{
				RgbColor.az();
				return RgbColor.b7;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06004112 RID: 16658 RVA: 0x00223850 File Offset: 0x00222850
		public static RgbColor MediumSlateBlue
		{
			get
			{
				RgbColor.ay();
				return RgbColor.b8;
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06004113 RID: 16659 RVA: 0x00223870 File Offset: 0x00222870
		public static RgbColor MediumSpringGreen
		{
			get
			{
				RgbColor.ax();
				return RgbColor.b9;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06004114 RID: 16660 RVA: 0x00223890 File Offset: 0x00222890
		public static RgbColor MediumTurquoise
		{
			get
			{
				RgbColor.aw();
				return RgbColor.ca;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06004115 RID: 16661 RVA: 0x002238B0 File Offset: 0x002228B0
		public static RgbColor MediumVioletRed
		{
			get
			{
				RgbColor.av();
				return RgbColor.cb;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06004116 RID: 16662 RVA: 0x002238D0 File Offset: 0x002228D0
		public static RgbColor MidnightBlue
		{
			get
			{
				RgbColor.au();
				return RgbColor.cc;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06004117 RID: 16663 RVA: 0x002238F0 File Offset: 0x002228F0
		public static RgbColor MintCream
		{
			get
			{
				RgbColor.at();
				return RgbColor.cd;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06004118 RID: 16664 RVA: 0x00223910 File Offset: 0x00222910
		public static RgbColor MistyRose
		{
			get
			{
				RgbColor.@as();
				return RgbColor.ce;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06004119 RID: 16665 RVA: 0x00223930 File Offset: 0x00222930
		public static RgbColor Moccasin
		{
			get
			{
				RgbColor.ar();
				return RgbColor.cf;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x0600411A RID: 16666 RVA: 0x00223950 File Offset: 0x00222950
		public static RgbColor NavajoWhite
		{
			get
			{
				RgbColor.aq();
				return RgbColor.cg;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x0600411B RID: 16667 RVA: 0x00223970 File Offset: 0x00222970
		public static RgbColor Navy
		{
			get
			{
				RgbColor.ap();
				return RgbColor.ch;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x0600411C RID: 16668 RVA: 0x00223990 File Offset: 0x00222990
		public static RgbColor OldLace
		{
			get
			{
				RgbColor.ao();
				return RgbColor.ci;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x0600411D RID: 16669 RVA: 0x002239B0 File Offset: 0x002229B0
		public static RgbColor Olive
		{
			get
			{
				RgbColor.an();
				return RgbColor.cj;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x0600411E RID: 16670 RVA: 0x002239D0 File Offset: 0x002229D0
		public static RgbColor OliveDrab
		{
			get
			{
				RgbColor.am();
				return RgbColor.ck;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x0600411F RID: 16671 RVA: 0x002239F0 File Offset: 0x002229F0
		public static RgbColor Orange
		{
			get
			{
				RgbColor.al();
				return RgbColor.cl;
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06004120 RID: 16672 RVA: 0x00223A10 File Offset: 0x00222A10
		public static RgbColor OrangeRed
		{
			get
			{
				RgbColor.ak();
				return RgbColor.cm;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06004121 RID: 16673 RVA: 0x00223A30 File Offset: 0x00222A30
		public static RgbColor Orchid
		{
			get
			{
				RgbColor.aj();
				return RgbColor.cn;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06004122 RID: 16674 RVA: 0x00223A50 File Offset: 0x00222A50
		public static RgbColor PaleGoldenRod
		{
			get
			{
				RgbColor.ai();
				return RgbColor.co;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06004123 RID: 16675 RVA: 0x00223A70 File Offset: 0x00222A70
		public static RgbColor PaleGreen
		{
			get
			{
				RgbColor.ah();
				return RgbColor.cp;
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06004124 RID: 16676 RVA: 0x00223A90 File Offset: 0x00222A90
		public static RgbColor PaleTurquoise
		{
			get
			{
				RgbColor.ag();
				return RgbColor.cq;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06004125 RID: 16677 RVA: 0x00223AB0 File Offset: 0x00222AB0
		public static RgbColor PaleVioletRed
		{
			get
			{
				RgbColor.af();
				return RgbColor.cr;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06004126 RID: 16678 RVA: 0x00223AD0 File Offset: 0x00222AD0
		public static RgbColor PapayaWhip
		{
			get
			{
				RgbColor.ae();
				return RgbColor.cs;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06004127 RID: 16679 RVA: 0x00223AF0 File Offset: 0x00222AF0
		public static RgbColor PeachPuff
		{
			get
			{
				RgbColor.ad();
				return RgbColor.ct;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06004128 RID: 16680 RVA: 0x00223B10 File Offset: 0x00222B10
		public static RgbColor Peru
		{
			get
			{
				RgbColor.ac();
				return RgbColor.cu;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06004129 RID: 16681 RVA: 0x00223B30 File Offset: 0x00222B30
		public static RgbColor Pink
		{
			get
			{
				RgbColor.ab();
				return RgbColor.cv;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600412A RID: 16682 RVA: 0x00223B50 File Offset: 0x00222B50
		public static RgbColor Plum
		{
			get
			{
				RgbColor.aa();
				return RgbColor.cw;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x0600412B RID: 16683 RVA: 0x00223B70 File Offset: 0x00222B70
		public static RgbColor PowderBlue
		{
			get
			{
				RgbColor.z();
				return RgbColor.cx;
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x0600412C RID: 16684 RVA: 0x00223B90 File Offset: 0x00222B90
		public static RgbColor RosyBrown
		{
			get
			{
				RgbColor.y();
				return RgbColor.cy;
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x0600412D RID: 16685 RVA: 0x00223BB0 File Offset: 0x00222BB0
		public static RgbColor RoyalBlue
		{
			get
			{
				RgbColor.x();
				return RgbColor.cz;
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x0600412E RID: 16686 RVA: 0x00223BD0 File Offset: 0x00222BD0
		public static RgbColor SaddleBrown
		{
			get
			{
				RgbColor.w();
				return RgbColor.c0;
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x0600412F RID: 16687 RVA: 0x00223BF0 File Offset: 0x00222BF0
		public static RgbColor Salmon
		{
			get
			{
				RgbColor.v();
				return RgbColor.c1;
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06004130 RID: 16688 RVA: 0x00223C10 File Offset: 0x00222C10
		public static RgbColor SandyBrown
		{
			get
			{
				RgbColor.u();
				return RgbColor.c2;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06004131 RID: 16689 RVA: 0x00223C30 File Offset: 0x00222C30
		public static RgbColor SeaGreen
		{
			get
			{
				RgbColor.t();
				return RgbColor.c3;
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06004132 RID: 16690 RVA: 0x00223C50 File Offset: 0x00222C50
		public static RgbColor SeaShell
		{
			get
			{
				RgbColor.s();
				return RgbColor.c4;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06004133 RID: 16691 RVA: 0x00223C70 File Offset: 0x00222C70
		public static RgbColor Sienna
		{
			get
			{
				RgbColor.r();
				return RgbColor.c5;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06004134 RID: 16692 RVA: 0x00223C90 File Offset: 0x00222C90
		public static RgbColor SkyBlue
		{
			get
			{
				RgbColor.q();
				return RgbColor.c6;
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06004135 RID: 16693 RVA: 0x00223CB0 File Offset: 0x00222CB0
		public static RgbColor SlateBlue
		{
			get
			{
				RgbColor.p();
				return RgbColor.c7;
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06004136 RID: 16694 RVA: 0x00223CD0 File Offset: 0x00222CD0
		public static RgbColor SlateGray
		{
			get
			{
				RgbColor.o();
				return RgbColor.c8;
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06004137 RID: 16695 RVA: 0x00223CF0 File Offset: 0x00222CF0
		public static RgbColor Snow
		{
			get
			{
				RgbColor.n();
				return RgbColor.c9;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06004138 RID: 16696 RVA: 0x00223D10 File Offset: 0x00222D10
		public static RgbColor SpringGreen
		{
			get
			{
				RgbColor.l();
				return RgbColor.da;
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06004139 RID: 16697 RVA: 0x00223D30 File Offset: 0x00222D30
		public static RgbColor SteelBlue
		{
			get
			{
				RgbColor.k();
				return RgbColor.db;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x0600413A RID: 16698 RVA: 0x00223D50 File Offset: 0x00222D50
		public static RgbColor Tan
		{
			get
			{
				RgbColor.j();
				return RgbColor.dc;
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x0600413B RID: 16699 RVA: 0x00223D70 File Offset: 0x00222D70
		public static RgbColor Teal
		{
			get
			{
				RgbColor.i();
				return RgbColor.dd;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600413C RID: 16700 RVA: 0x00223D90 File Offset: 0x00222D90
		public static RgbColor Thistle
		{
			get
			{
				RgbColor.h();
				return RgbColor.de;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x0600413D RID: 16701 RVA: 0x00223DB0 File Offset: 0x00222DB0
		public static RgbColor Tomato
		{
			get
			{
				RgbColor.g();
				return RgbColor.df;
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x0600413E RID: 16702 RVA: 0x00223DD0 File Offset: 0x00222DD0
		public static RgbColor Turquoise
		{
			get
			{
				RgbColor.f();
				return RgbColor.dg;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x0600413F RID: 16703 RVA: 0x00223DF0 File Offset: 0x00222DF0
		public static RgbColor Violet
		{
			get
			{
				RgbColor.e();
				return RgbColor.dh;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06004140 RID: 16704 RVA: 0x00223E10 File Offset: 0x00222E10
		public static RgbColor VioletRed
		{
			get
			{
				RgbColor.d();
				return RgbColor.di;
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06004141 RID: 16705 RVA: 0x00223E30 File Offset: 0x00222E30
		public static RgbColor Wheat
		{
			get
			{
				RgbColor.c();
				return RgbColor.dj;
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06004142 RID: 16706 RVA: 0x00223E50 File Offset: 0x00222E50
		public static RgbColor WhiteSmoke
		{
			get
			{
				RgbColor.b();
				return RgbColor.dk;
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06004143 RID: 16707 RVA: 0x00223E70 File Offset: 0x00222E70
		public static RgbColor YellowGreen
		{
			get
			{
				RgbColor.a();
				return RgbColor.dl;
			}
		}

		// Token: 0x06004144 RID: 16708 RVA: 0x00223E90 File Offset: 0x00222E90
		private static void dj()
		{
			if (RgbColor.d == null)
			{
				RgbColor.d = new RgbColor(0, 0, 0);
			}
		}

		// Token: 0x06004145 RID: 16709 RVA: 0x00223EBC File Offset: 0x00222EBC
		private static void di()
		{
			if (RgbColor.e == null)
			{
				RgbColor.e = new RgbColor(192, 192, 192);
			}
		}

		// Token: 0x06004146 RID: 16710 RVA: 0x00223EF4 File Offset: 0x00222EF4
		private static void dh()
		{
			if (RgbColor.f == null)
			{
				RgbColor.f = new RgbColor(167, 167, 167);
			}
		}

		// Token: 0x06004147 RID: 16711 RVA: 0x00223F2C File Offset: 0x00222F2C
		private static void dg()
		{
			if (RgbColor.g == null)
			{
				RgbColor.g = new RgbColor(190, 190, 190);
			}
		}

		// Token: 0x06004148 RID: 16712 RVA: 0x00223F64 File Offset: 0x00222F64
		private static void df()
		{
			if (RgbColor.h == null)
			{
				RgbColor.h = new RgbColor(105, 105, 105);
			}
		}

		// Token: 0x06004149 RID: 16713 RVA: 0x00223F94 File Offset: 0x00222F94
		private static void de()
		{
			if (RgbColor.i == null)
			{
				RgbColor.i = new RgbColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x0600414A RID: 16714 RVA: 0x00223FCC File Offset: 0x00222FCC
		private static void dd()
		{
			if (RgbColor.j == null)
			{
				RgbColor.j = new RgbColor(byte.MaxValue, 0, 0);
			}
		}

		// Token: 0x0600414B RID: 16715 RVA: 0x00223FFC File Offset: 0x00222FFC
		private static void dc()
		{
			if (RgbColor.k == null)
			{
				RgbColor.k = new RgbColor(0, 128, 0);
			}
		}

		// Token: 0x0600414C RID: 16716 RVA: 0x0022402C File Offset: 0x0022302C
		private static void db()
		{
			if (RgbColor.l == null)
			{
				RgbColor.l = new RgbColor(0, byte.MaxValue, 0);
			}
		}

		// Token: 0x0600414D RID: 16717 RVA: 0x0022405C File Offset: 0x0022305C
		private static void da()
		{
			if (RgbColor.m == null)
			{
				RgbColor.m = new RgbColor(0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x0600414E RID: 16718 RVA: 0x00224090 File Offset: 0x00223090
		private static void c9()
		{
			if (RgbColor.n == null)
			{
				RgbColor.n = new RgbColor(128, 0, 128);
			}
		}

		// Token: 0x0600414F RID: 16719 RVA: 0x002240C4 File Offset: 0x002230C4
		private static void c8()
		{
			if (RgbColor.o == null)
			{
				RgbColor.o = new RgbColor(0, 0, byte.MaxValue);
			}
		}

		// Token: 0x06004150 RID: 16720 RVA: 0x002240F4 File Offset: 0x002230F4
		private static void c7()
		{
			if (RgbColor.p == null)
			{
				RgbColor.p = new RgbColor(0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06004151 RID: 16721 RVA: 0x00224128 File Offset: 0x00223128
		private static void c6()
		{
			if (RgbColor.q == null)
			{
				RgbColor.q = new RgbColor(byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x06004152 RID: 16722 RVA: 0x0022415C File Offset: 0x0022315C
		private static void c5()
		{
			if (RgbColor.r == null)
			{
				RgbColor.r = new RgbColor(byte.MaxValue, byte.MaxValue, 0);
			}
		}

		// Token: 0x06004153 RID: 16723 RVA: 0x00224190 File Offset: 0x00223190
		private static void c4()
		{
			if (RgbColor.s == null)
			{
				RgbColor.s = new RgbColor(240, 248, byte.MaxValue);
			}
		}

		// Token: 0x06004154 RID: 16724 RVA: 0x002241C8 File Offset: 0x002231C8
		private static void c3()
		{
			if (RgbColor.t == null)
			{
				RgbColor.t = new RgbColor(250, 235, 215);
			}
		}

		// Token: 0x06004155 RID: 16725 RVA: 0x00224200 File Offset: 0x00223200
		private static void c2()
		{
			if (RgbColor.u == null)
			{
				RgbColor.u = new RgbColor(127, byte.MaxValue, 212);
			}
		}

		// Token: 0x06004156 RID: 16726 RVA: 0x00224234 File Offset: 0x00223234
		private static void c1()
		{
			if (RgbColor.v == null)
			{
				RgbColor.v = new RgbColor(240, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06004157 RID: 16727 RVA: 0x0022426C File Offset: 0x0022326C
		private static void c0()
		{
			if (RgbColor.w == null)
			{
				RgbColor.w = new RgbColor(245, 245, 220);
			}
		}

		// Token: 0x06004158 RID: 16728 RVA: 0x002242A4 File Offset: 0x002232A4
		private static void cz()
		{
			if (RgbColor.x == null)
			{
				RgbColor.x = new RgbColor(byte.MaxValue, 228, 196);
			}
		}

		// Token: 0x06004159 RID: 16729 RVA: 0x002242DC File Offset: 0x002232DC
		private static void cy()
		{
			if (RgbColor.y == null)
			{
				RgbColor.y = new RgbColor(byte.MaxValue, 235, 205);
			}
		}

		// Token: 0x0600415A RID: 16730 RVA: 0x00224314 File Offset: 0x00223314
		private static void cx()
		{
			if (RgbColor.z == null)
			{
				RgbColor.z = new RgbColor(138, 43, 226);
			}
		}

		// Token: 0x0600415B RID: 16731 RVA: 0x00224348 File Offset: 0x00223348
		private static void cw()
		{
			if (RgbColor.aa == null)
			{
				RgbColor.aa = new RgbColor(165, 42, 42);
			}
		}

		// Token: 0x0600415C RID: 16732 RVA: 0x00224378 File Offset: 0x00223378
		private static void cv()
		{
			if (RgbColor.ab == null)
			{
				RgbColor.ab = new RgbColor(222, 184, 135);
			}
		}

		// Token: 0x0600415D RID: 16733 RVA: 0x002243B0 File Offset: 0x002233B0
		private static void cu()
		{
			if (RgbColor.ac == null)
			{
				RgbColor.ac = new RgbColor(95, 158, 160);
			}
		}

		// Token: 0x0600415E RID: 16734 RVA: 0x002243E4 File Offset: 0x002233E4
		private static void ct()
		{
			if (RgbColor.ad == null)
			{
				RgbColor.ad = new RgbColor(127, byte.MaxValue, 0);
			}
		}

		// Token: 0x0600415F RID: 16735 RVA: 0x00224414 File Offset: 0x00223414
		private static void cs()
		{
			if (RgbColor.ae == null)
			{
				RgbColor.ae = new RgbColor(210, 105, 30);
			}
		}

		// Token: 0x06004160 RID: 16736 RVA: 0x00224444 File Offset: 0x00223444
		private static void cr()
		{
			if (RgbColor.af == null)
			{
				RgbColor.af = new RgbColor(byte.MaxValue, 127, 80);
			}
		}

		// Token: 0x06004161 RID: 16737 RVA: 0x00224474 File Offset: 0x00223474
		private static void cq()
		{
			if (RgbColor.ag == null)
			{
				RgbColor.ag = new RgbColor(100, 149, 237);
			}
		}

		// Token: 0x06004162 RID: 16738 RVA: 0x002244A8 File Offset: 0x002234A8
		private static void cp()
		{
			if (RgbColor.ah == null)
			{
				RgbColor.ah = new RgbColor(byte.MaxValue, 248, 220);
			}
		}

		// Token: 0x06004163 RID: 16739 RVA: 0x002244E0 File Offset: 0x002234E0
		private static void co()
		{
			if (RgbColor.ai == null)
			{
				RgbColor.ai = new RgbColor(237, 164, 61);
			}
		}

		// Token: 0x06004164 RID: 16740 RVA: 0x00224514 File Offset: 0x00223514
		private static void cn()
		{
			if (RgbColor.aj == null)
			{
				RgbColor.aj = new RgbColor(0, 0, 139);
			}
		}

		// Token: 0x06004165 RID: 16741 RVA: 0x00224544 File Offset: 0x00223544
		private static void cm()
		{
			if (RgbColor.ak == null)
			{
				RgbColor.ak = new RgbColor(0, 139, 139);
			}
		}

		// Token: 0x06004166 RID: 16742 RVA: 0x00224578 File Offset: 0x00223578
		private static void cl()
		{
			if (RgbColor.al == null)
			{
				RgbColor.al = new RgbColor(184, 134, 11);
			}
		}

		// Token: 0x06004167 RID: 16743 RVA: 0x002245AC File Offset: 0x002235AC
		private static void ck()
		{
			if (RgbColor.am == null)
			{
				RgbColor.am = new RgbColor(0, 100, 0);
			}
		}

		// Token: 0x06004168 RID: 16744 RVA: 0x002245D8 File Offset: 0x002235D8
		private static void cj()
		{
			if (RgbColor.an == null)
			{
				RgbColor.an = new RgbColor(189, 183, 107);
			}
		}

		// Token: 0x06004169 RID: 16745 RVA: 0x0022460C File Offset: 0x0022360C
		private static void ci()
		{
			if (RgbColor.ao == null)
			{
				RgbColor.ao = new RgbColor(139, 0, 139);
			}
		}

		// Token: 0x0600416A RID: 16746 RVA: 0x00224640 File Offset: 0x00223640
		private static void ch()
		{
			if (RgbColor.ap == null)
			{
				RgbColor.ap = new RgbColor(85, 107, 47);
			}
		}

		// Token: 0x0600416B RID: 16747 RVA: 0x00224670 File Offset: 0x00223670
		private static void cg()
		{
			if (RgbColor.aq == null)
			{
				RgbColor.aq = new RgbColor(byte.MaxValue, 140, 0);
			}
		}

		// Token: 0x0600416C RID: 16748 RVA: 0x002246A4 File Offset: 0x002236A4
		private static void cf()
		{
			if (RgbColor.ar == null)
			{
				RgbColor.ar = new RgbColor(153, 50, 204);
			}
		}

		// Token: 0x0600416D RID: 16749 RVA: 0x002246D8 File Offset: 0x002236D8
		private static void ce()
		{
			if (RgbColor.@as == null)
			{
				RgbColor.@as = new RgbColor(139, 0, 0);
			}
		}

		// Token: 0x0600416E RID: 16750 RVA: 0x00224708 File Offset: 0x00223708
		private static void cd()
		{
			if (RgbColor.at == null)
			{
				RgbColor.at = new RgbColor(233, 150, 122);
			}
		}

		// Token: 0x0600416F RID: 16751 RVA: 0x0022473C File Offset: 0x0022373C
		private static void cc()
		{
			if (RgbColor.au == null)
			{
				RgbColor.au = new RgbColor(143, 188, 143);
			}
		}

		// Token: 0x06004170 RID: 16752 RVA: 0x00224774 File Offset: 0x00223774
		private static void cb()
		{
			if (RgbColor.av == null)
			{
				RgbColor.av = new RgbColor(72, 61, 139);
			}
		}

		// Token: 0x06004171 RID: 16753 RVA: 0x002247A4 File Offset: 0x002237A4
		private static void ca()
		{
			if (RgbColor.aw == null)
			{
				RgbColor.aw = new RgbColor(47, 79, 79);
			}
		}

		// Token: 0x06004172 RID: 16754 RVA: 0x002247D4 File Offset: 0x002237D4
		private static void b9()
		{
			if (RgbColor.ax == null)
			{
				RgbColor.ax = new RgbColor(0, 206, 209);
			}
		}

		// Token: 0x06004173 RID: 16755 RVA: 0x00224808 File Offset: 0x00223808
		private static void b8()
		{
			if (RgbColor.ay == null)
			{
				RgbColor.ay = new RgbColor(148, 0, 211);
			}
		}

		// Token: 0x06004174 RID: 16756 RVA: 0x0022483C File Offset: 0x0022383C
		private static void b7()
		{
			if (RgbColor.az == null)
			{
				RgbColor.az = new RgbColor(byte.MaxValue, 20, 147);
			}
		}

		// Token: 0x06004175 RID: 16757 RVA: 0x00224870 File Offset: 0x00223870
		private static void b6()
		{
			if (RgbColor.a0 == null)
			{
				RgbColor.a0 = new RgbColor(0, 191, byte.MaxValue);
			}
		}

		// Token: 0x06004176 RID: 16758 RVA: 0x002248A4 File Offset: 0x002238A4
		private static void b5()
		{
			if (RgbColor.a1 == null)
			{
				RgbColor.a1 = new RgbColor(30, 144, byte.MaxValue);
			}
		}

		// Token: 0x06004177 RID: 16759 RVA: 0x002248D8 File Offset: 0x002238D8
		private static void b4()
		{
			if (RgbColor.a2 == null)
			{
				RgbColor.a2 = new RgbColor(209, 146, 117);
			}
		}

		// Token: 0x06004178 RID: 16760 RVA: 0x0022490C File Offset: 0x0022390C
		private static void b3()
		{
			if (RgbColor.a3 == null)
			{
				RgbColor.a3 = new RgbColor(178, 34, 34);
			}
		}

		// Token: 0x06004179 RID: 16761 RVA: 0x0022493C File Offset: 0x0022393C
		private static void b2()
		{
			if (RgbColor.a4 == null)
			{
				RgbColor.a4 = new RgbColor(byte.MaxValue, 250, 240);
			}
		}

		// Token: 0x0600417A RID: 16762 RVA: 0x00224974 File Offset: 0x00223974
		private static void b1()
		{
			if (RgbColor.a5 == null)
			{
				RgbColor.a5 = new RgbColor(34, 139, 34);
			}
		}

		// Token: 0x0600417B RID: 16763 RVA: 0x002249A4 File Offset: 0x002239A4
		private static void b0()
		{
			if (RgbColor.a6 == null)
			{
				RgbColor.a6 = new RgbColor(byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x0600417C RID: 16764 RVA: 0x002249D8 File Offset: 0x002239D8
		private static void bz()
		{
			if (RgbColor.a7 == null)
			{
				RgbColor.a7 = new RgbColor(220, 220, 220);
			}
		}

		// Token: 0x0600417D RID: 16765 RVA: 0x00224A10 File Offset: 0x00223A10
		private static void by()
		{
			if (RgbColor.a8 == null)
			{
				RgbColor.a8 = new RgbColor(248, 248, byte.MaxValue);
			}
		}

		// Token: 0x0600417E RID: 16766 RVA: 0x00224A48 File Offset: 0x00223A48
		private static void bx()
		{
			if (RgbColor.a9 == null)
			{
				RgbColor.a9 = new RgbColor(byte.MaxValue, 215, 0);
			}
		}

		// Token: 0x0600417F RID: 16767 RVA: 0x00224A7C File Offset: 0x00223A7C
		private static void bw()
		{
			if (RgbColor.ba == null)
			{
				RgbColor.ba = new RgbColor(218, 165, 32);
			}
		}

		// Token: 0x06004180 RID: 16768 RVA: 0x00224AB0 File Offset: 0x00223AB0
		private static void bv()
		{
			if (RgbColor.bb == null)
			{
				RgbColor.bb = new RgbColor(173, byte.MaxValue, 47);
			}
		}

		// Token: 0x06004181 RID: 16769 RVA: 0x00224AE4 File Offset: 0x00223AE4
		private static void bu()
		{
			if (RgbColor.bc == null)
			{
				RgbColor.bc = new RgbColor(240, byte.MaxValue, 240);
			}
		}

		// Token: 0x06004182 RID: 16770 RVA: 0x00224B1C File Offset: 0x00223B1C
		private static void bt()
		{
			if (RgbColor.bd == null)
			{
				RgbColor.bd = new RgbColor(byte.MaxValue, 105, 180);
			}
		}

		// Token: 0x06004183 RID: 16771 RVA: 0x00224B50 File Offset: 0x00223B50
		private static void bs()
		{
			if (RgbColor.be == null)
			{
				RgbColor.be = new RgbColor(205, 92, 92);
			}
		}

		// Token: 0x06004184 RID: 16772 RVA: 0x00224B80 File Offset: 0x00223B80
		private static void br()
		{
			if (RgbColor.bf == null)
			{
				RgbColor.bf = new RgbColor(75, 0, 130);
			}
		}

		// Token: 0x06004185 RID: 16773 RVA: 0x00224BB0 File Offset: 0x00223BB0
		private static void bq()
		{
			if (RgbColor.bg == null)
			{
				RgbColor.bg = new RgbColor(byte.MaxValue, byte.MaxValue, 240);
			}
		}

		// Token: 0x06004186 RID: 16774 RVA: 0x00224BE8 File Offset: 0x00223BE8
		private static void bp()
		{
			if (RgbColor.bh == null)
			{
				RgbColor.bh = new RgbColor(240, 230, 140);
			}
		}

		// Token: 0x06004187 RID: 16775 RVA: 0x00224C20 File Offset: 0x00223C20
		private static void bo()
		{
			if (RgbColor.bi == null)
			{
				RgbColor.bi = new RgbColor(230, 230, 250);
			}
		}

		// Token: 0x06004188 RID: 16776 RVA: 0x00224C58 File Offset: 0x00223C58
		private static void bn()
		{
			if (RgbColor.bj == null)
			{
				RgbColor.bj = new RgbColor(byte.MaxValue, 240, 245);
			}
		}

		// Token: 0x06004189 RID: 16777 RVA: 0x00224C90 File Offset: 0x00223C90
		private static void bm()
		{
			if (RgbColor.bk == null)
			{
				RgbColor.bk = new RgbColor(124, 252, 0);
			}
		}

		// Token: 0x0600418A RID: 16778 RVA: 0x00224CC0 File Offset: 0x00223CC0
		private static void bl()
		{
			if (RgbColor.bl == null)
			{
				RgbColor.bl = new RgbColor(byte.MaxValue, 250, 205);
			}
		}

		// Token: 0x0600418B RID: 16779 RVA: 0x00224CF8 File Offset: 0x00223CF8
		private static void bk()
		{
			if (RgbColor.bm == null)
			{
				RgbColor.bm = new RgbColor(173, 216, 230);
			}
		}

		// Token: 0x0600418C RID: 16780 RVA: 0x00224D30 File Offset: 0x00223D30
		private static void bj()
		{
			if (RgbColor.bn == null)
			{
				RgbColor.bn = new RgbColor(240, 128, 128);
			}
		}

		// Token: 0x0600418D RID: 16781 RVA: 0x00224D68 File Offset: 0x00223D68
		private static void bi()
		{
			if (RgbColor.bo == null)
			{
				RgbColor.bo = new RgbColor(224, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x0600418E RID: 16782 RVA: 0x00224DA0 File Offset: 0x00223DA0
		private static void bh()
		{
			if (RgbColor.bp == null)
			{
				RgbColor.bp = new RgbColor(250, 250, 210);
			}
		}

		// Token: 0x0600418F RID: 16783 RVA: 0x00224DD8 File Offset: 0x00223DD8
		private static void bg()
		{
			if (RgbColor.bq == null)
			{
				RgbColor.bq = new RgbColor(211, 211, 211);
			}
		}

		// Token: 0x06004190 RID: 16784 RVA: 0x00224E10 File Offset: 0x00223E10
		private static void bf()
		{
			if (RgbColor.br == null)
			{
				RgbColor.br = new RgbColor(144, 238, 144);
			}
		}

		// Token: 0x06004191 RID: 16785 RVA: 0x00224E48 File Offset: 0x00223E48
		private static void be()
		{
			if (RgbColor.bs == null)
			{
				RgbColor.bs = new RgbColor(byte.MaxValue, 182, 193);
			}
		}

		// Token: 0x06004192 RID: 16786 RVA: 0x00224E80 File Offset: 0x00223E80
		private static void bd()
		{
			if (RgbColor.bt == null)
			{
				RgbColor.bt = new RgbColor(byte.MaxValue, 160, 122);
			}
		}

		// Token: 0x06004193 RID: 16787 RVA: 0x00224EB4 File Offset: 0x00223EB4
		private static void bc()
		{
			if (RgbColor.bu == null)
			{
				RgbColor.bu = new RgbColor(32, 178, 170);
			}
		}

		// Token: 0x06004194 RID: 16788 RVA: 0x00224EE8 File Offset: 0x00223EE8
		private static void bb()
		{
			if (RgbColor.bv == null)
			{
				RgbColor.bv = new RgbColor(135, 206, 250);
			}
		}

		// Token: 0x06004195 RID: 16789 RVA: 0x00224F20 File Offset: 0x00223F20
		private static void ba()
		{
			if (RgbColor.bw == null)
			{
				RgbColor.bw = new RgbColor(132, 112, byte.MaxValue);
			}
		}

		// Token: 0x06004196 RID: 16790 RVA: 0x00224F54 File Offset: 0x00223F54
		private static void a9()
		{
			if (RgbColor.bx == null)
			{
				RgbColor.bx = new RgbColor(119, 136, 153);
			}
		}

		// Token: 0x06004197 RID: 16791 RVA: 0x00224F88 File Offset: 0x00223F88
		private static void a8()
		{
			if (RgbColor.by == null)
			{
				RgbColor.by = new RgbColor(176, 196, 222);
			}
		}

		// Token: 0x06004198 RID: 16792 RVA: 0x00224FC0 File Offset: 0x00223FC0
		private static void a7()
		{
			if (RgbColor.bz == null)
			{
				RgbColor.bz = new RgbColor(byte.MaxValue, byte.MaxValue, 224);
			}
		}

		// Token: 0x06004199 RID: 16793 RVA: 0x00224FF8 File Offset: 0x00223FF8
		private static void a6()
		{
			if (RgbColor.b0 == null)
			{
				RgbColor.b0 = new RgbColor(50, 205, 50);
			}
		}

		// Token: 0x0600419A RID: 16794 RVA: 0x00225028 File Offset: 0x00224028
		private static void a5()
		{
			if (RgbColor.b1 == null)
			{
				RgbColor.b1 = new RgbColor(250, 240, 230);
			}
		}

		// Token: 0x0600419B RID: 16795 RVA: 0x00225060 File Offset: 0x00224060
		private static void a4()
		{
			if (RgbColor.b2 == null)
			{
				RgbColor.b2 = new RgbColor(128, 0, 0);
			}
		}

		// Token: 0x0600419C RID: 16796 RVA: 0x00225090 File Offset: 0x00224090
		private static void a3()
		{
			if (RgbColor.b3 == null)
			{
				RgbColor.b3 = new RgbColor(102, 205, 170);
			}
		}

		// Token: 0x0600419D RID: 16797 RVA: 0x002250C4 File Offset: 0x002240C4
		private static void a2()
		{
			if (RgbColor.b4 == null)
			{
				RgbColor.b4 = new RgbColor(0, 0, 205);
			}
		}

		// Token: 0x0600419E RID: 16798 RVA: 0x002250F4 File Offset: 0x002240F4
		private static void a1()
		{
			if (RgbColor.b5 == null)
			{
				RgbColor.b5 = new RgbColor(186, 85, 211);
			}
		}

		// Token: 0x0600419F RID: 16799 RVA: 0x00225128 File Offset: 0x00224128
		private static void a0()
		{
			if (RgbColor.b6 == null)
			{
				RgbColor.b6 = new RgbColor(147, 112, 219);
			}
		}

		// Token: 0x060041A0 RID: 16800 RVA: 0x0022515C File Offset: 0x0022415C
		private static void az()
		{
			if (RgbColor.b7 == null)
			{
				RgbColor.b7 = new RgbColor(60, 179, 113);
			}
		}

		// Token: 0x060041A1 RID: 16801 RVA: 0x0022518C File Offset: 0x0022418C
		private static void ay()
		{
			if (RgbColor.b8 == null)
			{
				RgbColor.b8 = new RgbColor(123, 104, 238);
			}
		}

		// Token: 0x060041A2 RID: 16802 RVA: 0x002251BC File Offset: 0x002241BC
		private static void ax()
		{
			if (RgbColor.b9 == null)
			{
				RgbColor.b9 = new RgbColor(0, 250, 154);
			}
		}

		// Token: 0x060041A3 RID: 16803 RVA: 0x002251F0 File Offset: 0x002241F0
		private static void aw()
		{
			if (RgbColor.ca == null)
			{
				RgbColor.ca = new RgbColor(72, 209, 204);
			}
		}

		// Token: 0x060041A4 RID: 16804 RVA: 0x00225224 File Offset: 0x00224224
		private static void av()
		{
			if (RgbColor.cb == null)
			{
				RgbColor.cb = new RgbColor(199, 21, 133);
			}
		}

		// Token: 0x060041A5 RID: 16805 RVA: 0x00225258 File Offset: 0x00224258
		private static void au()
		{
			if (RgbColor.cc == null)
			{
				RgbColor.cc = new RgbColor(25, 25, 112);
			}
		}

		// Token: 0x060041A6 RID: 16806 RVA: 0x00225288 File Offset: 0x00224288
		private static void at()
		{
			if (RgbColor.cd == null)
			{
				RgbColor.cd = new RgbColor(245, byte.MaxValue, 250);
			}
		}

		// Token: 0x060041A7 RID: 16807 RVA: 0x002252C0 File Offset: 0x002242C0
		private static void @as()
		{
			if (RgbColor.ce == null)
			{
				RgbColor.ce = new RgbColor(byte.MaxValue, 228, 225);
			}
		}

		// Token: 0x060041A8 RID: 16808 RVA: 0x002252F8 File Offset: 0x002242F8
		private static void ar()
		{
			if (RgbColor.cf == null)
			{
				RgbColor.cf = new RgbColor(byte.MaxValue, 228, 181);
			}
		}

		// Token: 0x060041A9 RID: 16809 RVA: 0x00225330 File Offset: 0x00224330
		private static void aq()
		{
			if (RgbColor.cg == null)
			{
				RgbColor.cg = new RgbColor(byte.MaxValue, 222, 173);
			}
		}

		// Token: 0x060041AA RID: 16810 RVA: 0x00225368 File Offset: 0x00224368
		private static void ap()
		{
			if (RgbColor.ch == null)
			{
				RgbColor.ch = new RgbColor(0, 0, 128);
			}
		}

		// Token: 0x060041AB RID: 16811 RVA: 0x00225398 File Offset: 0x00224398
		private static void ao()
		{
			if (RgbColor.ci == null)
			{
				RgbColor.ci = new RgbColor(253, 245, 230);
			}
		}

		// Token: 0x060041AC RID: 16812 RVA: 0x002253D0 File Offset: 0x002243D0
		private static void an()
		{
			if (RgbColor.cj == null)
			{
				RgbColor.cj = new RgbColor(128, 128, 0);
			}
		}

		// Token: 0x060041AD RID: 16813 RVA: 0x00225404 File Offset: 0x00224404
		private static void am()
		{
			if (RgbColor.ck == null)
			{
				RgbColor.ck = new RgbColor(107, 142, 35);
			}
		}

		// Token: 0x060041AE RID: 16814 RVA: 0x00225434 File Offset: 0x00224434
		private static void al()
		{
			if (RgbColor.cl == null)
			{
				RgbColor.cl = new RgbColor(byte.MaxValue, 165, 0);
			}
		}

		// Token: 0x060041AF RID: 16815 RVA: 0x00225468 File Offset: 0x00224468
		private static void ak()
		{
			if (RgbColor.cm == null)
			{
				RgbColor.cm = new RgbColor(byte.MaxValue, 69, 0);
			}
		}

		// Token: 0x060041B0 RID: 16816 RVA: 0x00225498 File Offset: 0x00224498
		private static void aj()
		{
			if (RgbColor.cn == null)
			{
				RgbColor.cn = new RgbColor(218, 112, 214);
			}
		}

		// Token: 0x060041B1 RID: 16817 RVA: 0x002254CC File Offset: 0x002244CC
		private static void ai()
		{
			if (RgbColor.co == null)
			{
				RgbColor.co = new RgbColor(238, 232, 170);
			}
		}

		// Token: 0x060041B2 RID: 16818 RVA: 0x00225504 File Offset: 0x00224504
		private static void ah()
		{
			if (RgbColor.cp == null)
			{
				RgbColor.cp = new RgbColor(152, 251, 152);
			}
		}

		// Token: 0x060041B3 RID: 16819 RVA: 0x0022553C File Offset: 0x0022453C
		private static void ag()
		{
			if (RgbColor.cq == null)
			{
				RgbColor.cq = new RgbColor(175, 238, 238);
			}
		}

		// Token: 0x060041B4 RID: 16820 RVA: 0x00225574 File Offset: 0x00224574
		private static void af()
		{
			if (RgbColor.cr == null)
			{
				RgbColor.cr = new RgbColor(219, 112, 147);
			}
		}

		// Token: 0x060041B5 RID: 16821 RVA: 0x002255A8 File Offset: 0x002245A8
		private static void ae()
		{
			if (RgbColor.cs == null)
			{
				RgbColor.cs = new RgbColor(byte.MaxValue, 239, 213);
			}
		}

		// Token: 0x060041B6 RID: 16822 RVA: 0x002255E0 File Offset: 0x002245E0
		private static void ad()
		{
			if (RgbColor.ct == null)
			{
				RgbColor.ct = new RgbColor(byte.MaxValue, 218, 185);
			}
		}

		// Token: 0x060041B7 RID: 16823 RVA: 0x00225618 File Offset: 0x00224618
		private static void ac()
		{
			if (RgbColor.cu == null)
			{
				RgbColor.cu = new RgbColor(205, 133, 63);
			}
		}

		// Token: 0x060041B8 RID: 16824 RVA: 0x0022564C File Offset: 0x0022464C
		private static void ab()
		{
			if (RgbColor.cv == null)
			{
				RgbColor.cv = new RgbColor(byte.MaxValue, 192, 203);
			}
		}

		// Token: 0x060041B9 RID: 16825 RVA: 0x00225684 File Offset: 0x00224684
		private static void aa()
		{
			if (RgbColor.cw == null)
			{
				RgbColor.cw = new RgbColor(221, 160, 221);
			}
		}

		// Token: 0x060041BA RID: 16826 RVA: 0x002256BC File Offset: 0x002246BC
		private static void z()
		{
			if (RgbColor.cx == null)
			{
				RgbColor.cx = new RgbColor(176, 224, 230);
			}
		}

		// Token: 0x060041BB RID: 16827 RVA: 0x002256F4 File Offset: 0x002246F4
		private static void y()
		{
			if (RgbColor.cy == null)
			{
				RgbColor.cy = new RgbColor(188, 143, 143);
			}
		}

		// Token: 0x060041BC RID: 16828 RVA: 0x0022572C File Offset: 0x0022472C
		private static void x()
		{
			if (RgbColor.cz == null)
			{
				RgbColor.cz = new RgbColor(65, 105, 225);
			}
		}

		// Token: 0x060041BD RID: 16829 RVA: 0x0022575C File Offset: 0x0022475C
		private static void w()
		{
			if (RgbColor.c0 == null)
			{
				RgbColor.c0 = new RgbColor(139, 69, 19);
			}
		}

		// Token: 0x060041BE RID: 16830 RVA: 0x0022578C File Offset: 0x0022478C
		private static void v()
		{
			if (RgbColor.c1 == null)
			{
				RgbColor.c1 = new RgbColor(250, 128, 114);
			}
		}

		// Token: 0x060041BF RID: 16831 RVA: 0x002257C0 File Offset: 0x002247C0
		private static void u()
		{
			if (RgbColor.c2 == null)
			{
				RgbColor.c2 = new RgbColor(244, 164, 96);
			}
		}

		// Token: 0x060041C0 RID: 16832 RVA: 0x002257F4 File Offset: 0x002247F4
		private static void t()
		{
			if (RgbColor.c3 == null)
			{
				RgbColor.c3 = new RgbColor(46, 139, 87);
			}
		}

		// Token: 0x060041C1 RID: 16833 RVA: 0x00225824 File Offset: 0x00224824
		private static void s()
		{
			if (RgbColor.c4 == null)
			{
				RgbColor.c4 = new RgbColor(byte.MaxValue, 245, 238);
			}
		}

		// Token: 0x060041C2 RID: 16834 RVA: 0x0022585C File Offset: 0x0022485C
		private static void r()
		{
			if (RgbColor.c5 == null)
			{
				RgbColor.c5 = new RgbColor(160, 82, 45);
			}
		}

		// Token: 0x060041C3 RID: 16835 RVA: 0x0022588C File Offset: 0x0022488C
		private static void q()
		{
			if (RgbColor.c6 == null)
			{
				RgbColor.c6 = new RgbColor(135, 206, 235);
			}
		}

		// Token: 0x060041C4 RID: 16836 RVA: 0x002258C4 File Offset: 0x002248C4
		private static void p()
		{
			if (RgbColor.c7 == null)
			{
				RgbColor.c7 = new RgbColor(106, 90, 205);
			}
		}

		// Token: 0x060041C5 RID: 16837 RVA: 0x002258F4 File Offset: 0x002248F4
		private static void o()
		{
			if (RgbColor.c8 == null)
			{
				RgbColor.c8 = new RgbColor(112, 128, 144);
			}
		}

		// Token: 0x060041C6 RID: 16838 RVA: 0x00225928 File Offset: 0x00224928
		private static void n()
		{
			if (RgbColor.c9 == null)
			{
				RgbColor.c9 = new RgbColor(byte.MaxValue, 250, 250);
			}
		}

		// Token: 0x060041C7 RID: 16839 RVA: 0x00225960 File Offset: 0x00224960
		private static void l()
		{
			if (RgbColor.da == null)
			{
				RgbColor.da = new RgbColor(0, byte.MaxValue, 127);
			}
		}

		// Token: 0x060041C8 RID: 16840 RVA: 0x00225990 File Offset: 0x00224990
		private static void k()
		{
			if (RgbColor.db == null)
			{
				RgbColor.db = new RgbColor(70, 130, 180);
			}
		}

		// Token: 0x060041C9 RID: 16841 RVA: 0x002259C4 File Offset: 0x002249C4
		private static void j()
		{
			if (RgbColor.dc == null)
			{
				RgbColor.dc = new RgbColor(210, 180, 140);
			}
		}

		// Token: 0x060041CA RID: 16842 RVA: 0x002259FC File Offset: 0x002249FC
		private static void i()
		{
			if (RgbColor.dd == null)
			{
				RgbColor.dd = new RgbColor(0, 128, 128);
			}
		}

		// Token: 0x060041CB RID: 16843 RVA: 0x00225A30 File Offset: 0x00224A30
		private static void h()
		{
			if (RgbColor.de == null)
			{
				RgbColor.de = new RgbColor(216, 191, 216);
			}
		}

		// Token: 0x060041CC RID: 16844 RVA: 0x00225A68 File Offset: 0x00224A68
		private static void g()
		{
			if (RgbColor.df == null)
			{
				RgbColor.df = new RgbColor(byte.MaxValue, 99, 71);
			}
		}

		// Token: 0x060041CD RID: 16845 RVA: 0x00225A98 File Offset: 0x00224A98
		private static void f()
		{
			if (RgbColor.dg == null)
			{
				RgbColor.dg = new RgbColor(64, 224, 208);
			}
		}

		// Token: 0x060041CE RID: 16846 RVA: 0x00225ACC File Offset: 0x00224ACC
		private static void e()
		{
			if (RgbColor.dh == null)
			{
				RgbColor.dh = new RgbColor(238, 130, 238);
			}
		}

		// Token: 0x060041CF RID: 16847 RVA: 0x00225B04 File Offset: 0x00224B04
		private static void d()
		{
			if (RgbColor.di == null)
			{
				RgbColor.di = new RgbColor(208, 32, 144);
			}
		}

		// Token: 0x060041D0 RID: 16848 RVA: 0x00225B38 File Offset: 0x00224B38
		private static void c()
		{
			if (RgbColor.dj == null)
			{
				RgbColor.dj = new RgbColor(245, 222, 179);
			}
		}

		// Token: 0x060041D1 RID: 16849 RVA: 0x00225B70 File Offset: 0x00224B70
		private static void b()
		{
			if (RgbColor.dk == null)
			{
				RgbColor.dk = new RgbColor(245, 245, 245);
			}
		}

		// Token: 0x060041D2 RID: 16850 RVA: 0x00225BA8 File Offset: 0x00224BA8
		private new static void a()
		{
			if (RgbColor.dl == null)
			{
				RgbColor.dl = new RgbColor(154, 205, 50);
			}
		}

		// Token: 0x04002404 RID: 9220
		private new float a;

		// Token: 0x04002405 RID: 9221
		private new float b;

		// Token: 0x04002406 RID: 9222
		private new float c;

		// Token: 0x04002407 RID: 9223
		private new static RgbColor d = null;

		// Token: 0x04002408 RID: 9224
		private static RgbColor e = null;

		// Token: 0x04002409 RID: 9225
		private static RgbColor f = null;

		// Token: 0x0400240A RID: 9226
		private static RgbColor g = null;

		// Token: 0x0400240B RID: 9227
		private static RgbColor h = null;

		// Token: 0x0400240C RID: 9228
		private static RgbColor i = null;

		// Token: 0x0400240D RID: 9229
		private static RgbColor j = null;

		// Token: 0x0400240E RID: 9230
		private static RgbColor k = null;

		// Token: 0x0400240F RID: 9231
		private static RgbColor l = null;

		// Token: 0x04002410 RID: 9232
		private new static RgbColor m = null;

		// Token: 0x04002411 RID: 9233
		private static RgbColor n = null;

		// Token: 0x04002412 RID: 9234
		private static RgbColor o = null;

		// Token: 0x04002413 RID: 9235
		private static RgbColor p = null;

		// Token: 0x04002414 RID: 9236
		private static RgbColor q = null;

		// Token: 0x04002415 RID: 9237
		private static RgbColor r = null;

		// Token: 0x04002416 RID: 9238
		private static RgbColor s = null;

		// Token: 0x04002417 RID: 9239
		private static RgbColor t = null;

		// Token: 0x04002418 RID: 9240
		private static RgbColor u = null;

		// Token: 0x04002419 RID: 9241
		private static RgbColor v = null;

		// Token: 0x0400241A RID: 9242
		private static RgbColor w = null;

		// Token: 0x0400241B RID: 9243
		private static RgbColor x = null;

		// Token: 0x0400241C RID: 9244
		private static RgbColor y = null;

		// Token: 0x0400241D RID: 9245
		private static RgbColor z = null;

		// Token: 0x0400241E RID: 9246
		private static RgbColor aa = null;

		// Token: 0x0400241F RID: 9247
		private static RgbColor ab = null;

		// Token: 0x04002420 RID: 9248
		private static RgbColor ac = null;

		// Token: 0x04002421 RID: 9249
		private static RgbColor ad = null;

		// Token: 0x04002422 RID: 9250
		private static RgbColor ae = null;

		// Token: 0x04002423 RID: 9251
		private static RgbColor af = null;

		// Token: 0x04002424 RID: 9252
		private static RgbColor ag = null;

		// Token: 0x04002425 RID: 9253
		private static RgbColor ah = null;

		// Token: 0x04002426 RID: 9254
		private static RgbColor ai = null;

		// Token: 0x04002427 RID: 9255
		private static RgbColor aj = null;

		// Token: 0x04002428 RID: 9256
		private static RgbColor ak = null;

		// Token: 0x04002429 RID: 9257
		private static RgbColor al = null;

		// Token: 0x0400242A RID: 9258
		private static RgbColor am = null;

		// Token: 0x0400242B RID: 9259
		private static RgbColor an = null;

		// Token: 0x0400242C RID: 9260
		private static RgbColor ao = null;

		// Token: 0x0400242D RID: 9261
		private static RgbColor ap = null;

		// Token: 0x0400242E RID: 9262
		private static RgbColor aq = null;

		// Token: 0x0400242F RID: 9263
		private static RgbColor ar = null;

		// Token: 0x04002430 RID: 9264
		private static RgbColor @as = null;

		// Token: 0x04002431 RID: 9265
		private static RgbColor at = null;

		// Token: 0x04002432 RID: 9266
		private static RgbColor au = null;

		// Token: 0x04002433 RID: 9267
		private static RgbColor av = null;

		// Token: 0x04002434 RID: 9268
		private static RgbColor aw = null;

		// Token: 0x04002435 RID: 9269
		private static RgbColor ax = null;

		// Token: 0x04002436 RID: 9270
		private static RgbColor ay = null;

		// Token: 0x04002437 RID: 9271
		private static RgbColor az = null;

		// Token: 0x04002438 RID: 9272
		private static RgbColor a0 = null;

		// Token: 0x04002439 RID: 9273
		private static RgbColor a1 = null;

		// Token: 0x0400243A RID: 9274
		private static RgbColor a2 = null;

		// Token: 0x0400243B RID: 9275
		private static RgbColor a3 = null;

		// Token: 0x0400243C RID: 9276
		private static RgbColor a4 = null;

		// Token: 0x0400243D RID: 9277
		private static RgbColor a5 = null;

		// Token: 0x0400243E RID: 9278
		private static RgbColor a6 = null;

		// Token: 0x0400243F RID: 9279
		private static RgbColor a7 = null;

		// Token: 0x04002440 RID: 9280
		private static RgbColor a8 = null;

		// Token: 0x04002441 RID: 9281
		private static RgbColor a9 = null;

		// Token: 0x04002442 RID: 9282
		private static RgbColor ba = null;

		// Token: 0x04002443 RID: 9283
		private static RgbColor bb = null;

		// Token: 0x04002444 RID: 9284
		private static RgbColor bc = null;

		// Token: 0x04002445 RID: 9285
		private static RgbColor bd = null;

		// Token: 0x04002446 RID: 9286
		private static RgbColor be = null;

		// Token: 0x04002447 RID: 9287
		private static RgbColor bf = null;

		// Token: 0x04002448 RID: 9288
		private static RgbColor bg = null;

		// Token: 0x04002449 RID: 9289
		private static RgbColor bh = null;

		// Token: 0x0400244A RID: 9290
		private static RgbColor bi = null;

		// Token: 0x0400244B RID: 9291
		private static RgbColor bj = null;

		// Token: 0x0400244C RID: 9292
		private static RgbColor bk = null;

		// Token: 0x0400244D RID: 9293
		private static RgbColor bl = null;

		// Token: 0x0400244E RID: 9294
		private static RgbColor bm = null;

		// Token: 0x0400244F RID: 9295
		private static RgbColor bn = null;

		// Token: 0x04002450 RID: 9296
		private static RgbColor bo = null;

		// Token: 0x04002451 RID: 9297
		private static RgbColor bp = null;

		// Token: 0x04002452 RID: 9298
		private static RgbColor bq = null;

		// Token: 0x04002453 RID: 9299
		private static RgbColor br = null;

		// Token: 0x04002454 RID: 9300
		private static RgbColor bs = null;

		// Token: 0x04002455 RID: 9301
		private static RgbColor bt = null;

		// Token: 0x04002456 RID: 9302
		private static RgbColor bu = null;

		// Token: 0x04002457 RID: 9303
		private static RgbColor bv = null;

		// Token: 0x04002458 RID: 9304
		private static RgbColor bw = null;

		// Token: 0x04002459 RID: 9305
		private static RgbColor bx = null;

		// Token: 0x0400245A RID: 9306
		private static RgbColor by = null;

		// Token: 0x0400245B RID: 9307
		private static RgbColor bz = null;

		// Token: 0x0400245C RID: 9308
		private static RgbColor b0 = null;

		// Token: 0x0400245D RID: 9309
		private static RgbColor b1 = null;

		// Token: 0x0400245E RID: 9310
		private static RgbColor b2 = null;

		// Token: 0x0400245F RID: 9311
		private static RgbColor b3 = null;

		// Token: 0x04002460 RID: 9312
		private static RgbColor b4 = null;

		// Token: 0x04002461 RID: 9313
		private static RgbColor b5 = null;

		// Token: 0x04002462 RID: 9314
		private static RgbColor b6 = null;

		// Token: 0x04002463 RID: 9315
		private static RgbColor b7 = null;

		// Token: 0x04002464 RID: 9316
		private static RgbColor b8 = null;

		// Token: 0x04002465 RID: 9317
		private static RgbColor b9 = null;

		// Token: 0x04002466 RID: 9318
		private static RgbColor ca = null;

		// Token: 0x04002467 RID: 9319
		private static RgbColor cb = null;

		// Token: 0x04002468 RID: 9320
		private static RgbColor cc = null;

		// Token: 0x04002469 RID: 9321
		private static RgbColor cd = null;

		// Token: 0x0400246A RID: 9322
		private static RgbColor ce = null;

		// Token: 0x0400246B RID: 9323
		private static RgbColor cf = null;

		// Token: 0x0400246C RID: 9324
		private static RgbColor cg = null;

		// Token: 0x0400246D RID: 9325
		private static RgbColor ch = null;

		// Token: 0x0400246E RID: 9326
		private static RgbColor ci = null;

		// Token: 0x0400246F RID: 9327
		private static RgbColor cj = null;

		// Token: 0x04002470 RID: 9328
		private static RgbColor ck = null;

		// Token: 0x04002471 RID: 9329
		private static RgbColor cl = null;

		// Token: 0x04002472 RID: 9330
		private static RgbColor cm = null;

		// Token: 0x04002473 RID: 9331
		private static RgbColor cn = null;

		// Token: 0x04002474 RID: 9332
		private static RgbColor co = null;

		// Token: 0x04002475 RID: 9333
		private static RgbColor cp = null;

		// Token: 0x04002476 RID: 9334
		private static RgbColor cq = null;

		// Token: 0x04002477 RID: 9335
		private static RgbColor cr = null;

		// Token: 0x04002478 RID: 9336
		private static RgbColor cs = null;

		// Token: 0x04002479 RID: 9337
		private static RgbColor ct = null;

		// Token: 0x0400247A RID: 9338
		private static RgbColor cu = null;

		// Token: 0x0400247B RID: 9339
		private static RgbColor cv = null;

		// Token: 0x0400247C RID: 9340
		private static RgbColor cw = null;

		// Token: 0x0400247D RID: 9341
		private static RgbColor cx = null;

		// Token: 0x0400247E RID: 9342
		private static RgbColor cy = null;

		// Token: 0x0400247F RID: 9343
		private static RgbColor cz = null;

		// Token: 0x04002480 RID: 9344
		private static RgbColor c0 = null;

		// Token: 0x04002481 RID: 9345
		private static RgbColor c1 = null;

		// Token: 0x04002482 RID: 9346
		private static RgbColor c2 = null;

		// Token: 0x04002483 RID: 9347
		private static RgbColor c3 = null;

		// Token: 0x04002484 RID: 9348
		private static RgbColor c4 = null;

		// Token: 0x04002485 RID: 9349
		private static RgbColor c5 = null;

		// Token: 0x04002486 RID: 9350
		private static RgbColor c6 = null;

		// Token: 0x04002487 RID: 9351
		private static RgbColor c7 = null;

		// Token: 0x04002488 RID: 9352
		private static RgbColor c8 = null;

		// Token: 0x04002489 RID: 9353
		private static RgbColor c9 = null;

		// Token: 0x0400248A RID: 9354
		private static RgbColor da = null;

		// Token: 0x0400248B RID: 9355
		private static RgbColor db = null;

		// Token: 0x0400248C RID: 9356
		private static RgbColor dc = null;

		// Token: 0x0400248D RID: 9357
		private static RgbColor dd = null;

		// Token: 0x0400248E RID: 9358
		private static RgbColor de = null;

		// Token: 0x0400248F RID: 9359
		private static RgbColor df = null;

		// Token: 0x04002490 RID: 9360
		private static RgbColor dg = null;

		// Token: 0x04002491 RID: 9361
		private static RgbColor dh = null;

		// Token: 0x04002492 RID: 9362
		private static RgbColor di = null;

		// Token: 0x04002493 RID: 9363
		private static RgbColor dj = null;

		// Token: 0x04002494 RID: 9364
		private static RgbColor dk = null;

		// Token: 0x04002495 RID: 9365
		private static RgbColor dl = null;
	}
}
