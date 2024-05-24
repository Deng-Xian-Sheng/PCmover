using System;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200066D RID: 1645
	public class CmykColor : DeviceColor
	{
		// Token: 0x06003E0F RID: 15887 RVA: 0x002175AC File Offset: 0x002165AC
		public CmykColor(float cyan, float magenta, float yellow, float black)
		{
			if (cyan < 0f || cyan > 1f || magenta < 0f || magenta > 1f || yellow < 0f || yellow > 1f || black < 0f || black > 1f)
			{
				throw new GeneratorException("CMYK values must be from 0.0 to 1.0.");
			}
			this.a = cyan;
			this.b = magenta;
			this.c = yellow;
			this.d = black;
		}

		// Token: 0x06003E10 RID: 15888 RVA: 0x00217664 File Offset: 0x00216664
		public CmykColor(byte cyan, byte magenta, byte yellow, byte black)
		{
			this.a = (float)cyan / 255f;
			this.b = (float)magenta / 255f;
			this.c = (float)yellow / 255f;
			this.d = (float)black / 255f;
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06003E11 RID: 15889 RVA: 0x002176E0 File Offset: 0x002166E0
		public override int Components
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06003E12 RID: 15890 RVA: 0x002176F4 File Offset: 0x002166F4
		public override ColorSpace ColorSpace
		{
			get
			{
				return ColorSpace.DeviceCmyk;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06003E13 RID: 15891 RVA: 0x0021770C File Offset: 0x0021670C
		public float C
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06003E14 RID: 15892 RVA: 0x00217724 File Offset: 0x00216724
		public float M
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06003E15 RID: 15893 RVA: 0x0021773C File Offset: 0x0021673C
		public float Y
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06003E16 RID: 15894 RVA: 0x00217754 File Offset: 0x00216754
		public float K
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x06003E17 RID: 15895 RVA: 0x0021776C File Offset: 0x0021676C
		public override bool Equals(object obj)
		{
			return obj is CmykColor && this.C == ((CmykColor)obj).C && this.M == ((CmykColor)obj).M && this.Y == ((CmykColor)obj).Y && this.K == ((CmykColor)obj).K;
		}

		// Token: 0x06003E18 RID: 15896 RVA: 0x002177D8 File Offset: 0x002167D8
		public override int GetHashCode()
		{
			return this.a.GetHashCode() ^ this.b.GetHashCode() ^ this.c.GetHashCode() ^ this.d.GetHashCode();
		}

		// Token: 0x06003E19 RID: 15897 RVA: 0x0021781C File Offset: 0x0021681C
		public override void ToStringBuilder(StringBuilder stringBuilder)
		{
			base.a(stringBuilder, this.a);
			stringBuilder.Append(' ');
			base.a(stringBuilder, this.b);
			stringBuilder.Append(' ');
			base.a(stringBuilder, this.c);
			stringBuilder.Append(' ');
			base.a(stringBuilder, this.d);
			stringBuilder.Append(" k");
		}

		// Token: 0x06003E1A RID: 15898 RVA: 0x00217889 File Offset: 0x00216889
		public override void DrawStroke(OperatorWriter writer)
		{
			writer.Write_K(this);
		}

		// Token: 0x06003E1B RID: 15899 RVA: 0x00217894 File Offset: 0x00216894
		public override void DrawFill(OperatorWriter writer)
		{
			writer.Write_k_(this);
		}

		// Token: 0x06003E1C RID: 15900 RVA: 0x002178A0 File Offset: 0x002168A0
		internal override void gr(DocumentWriter A_0)
		{
			A_0.WriteArrayOpen();
			A_0.WriteNumberColor(this.a);
			A_0.WriteNumberColor(this.b);
			A_0.WriteNumberColor(this.c);
			A_0.WriteNumberColor(this.d);
			A_0.WriteArrayClose();
		}

		// Token: 0x06003E1D RID: 15901 RVA: 0x002178F0 File Offset: 0x002168F0
		internal new static CmykColor a(byte A_0, byte A_1, byte A_2)
		{
			float num = (float)A_0 / 255f;
			float num2 = (float)A_1 / 255f;
			float num3 = (float)A_2 / 255f;
			float num4 = Math.Min(Math.Min(1f - num, 1f - num2), 1f - num3);
			float num5;
			float num6;
			float num7;
			if (num4 >= 1f)
			{
				num5 = 1f;
				num6 = 1f;
				num7 = 1f;
				num4 = 1f;
			}
			else
			{
				num5 = (1f - num - num4) / (1f - num4);
				num6 = (1f - num2 - num4) / (1f - num4);
				num7 = (1f - num3 - num4) / (1f - num4);
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				else if (num5 > 1f)
				{
					num5 = 1f;
				}
				if (num6 < 0f)
				{
					num6 = 0f;
				}
				else if (num6 > 1f)
				{
					num6 = 1f;
				}
				if (num7 < 0f)
				{
					num7 = 0f;
				}
				else if (num7 > 1f)
				{
					num7 = 1f;
				}
				if (num4 < 0f)
				{
					num4 = 0f;
				}
				else if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			return new CmykColor(num5, num6, num7, num4);
		}

		// Token: 0x06003E1E RID: 15902 RVA: 0x00217A8C File Offset: 0x00216A8C
		internal override RgbColor m()
		{
			float num = this.C;
			float num2 = this.M;
			float num3 = this.Y;
			float num4 = this.K;
			float red = -(num * (1f - num4) - 1f + num4);
			float green = -(num2 * (1f - num4) - 1f + num4);
			float blue = -(num3 * (1f - num4) - 1f + num4);
			return new RgbColor(red, green, blue);
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06003E1F RID: 15903 RVA: 0x00217B04 File Offset: 0x00216B04
		public static CmykColor Black
		{
			get
			{
				CmykColor.dj();
				return CmykColor.e;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06003E20 RID: 15904 RVA: 0x00217B24 File Offset: 0x00216B24
		public static CmykColor Silver
		{
			get
			{
				CmykColor.di();
				return CmykColor.f;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06003E21 RID: 15905 RVA: 0x00217B44 File Offset: 0x00216B44
		public static CmykColor DarkGray
		{
			get
			{
				CmykColor.dh();
				return CmykColor.g;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06003E22 RID: 15906 RVA: 0x00217B64 File Offset: 0x00216B64
		public static CmykColor Gray
		{
			get
			{
				CmykColor.dg();
				return CmykColor.h;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06003E23 RID: 15907 RVA: 0x00217B84 File Offset: 0x00216B84
		public static CmykColor DimGray
		{
			get
			{
				CmykColor.df();
				return CmykColor.i;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06003E24 RID: 15908 RVA: 0x00217BA4 File Offset: 0x00216BA4
		public static CmykColor White
		{
			get
			{
				CmykColor.de();
				return CmykColor.j;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06003E25 RID: 15909 RVA: 0x00217BC4 File Offset: 0x00216BC4
		public static CmykColor Red
		{
			get
			{
				CmykColor.dd();
				return CmykColor.k;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06003E26 RID: 15910 RVA: 0x00217BE4 File Offset: 0x00216BE4
		public static CmykColor Green
		{
			get
			{
				CmykColor.dc();
				return CmykColor.l;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06003E27 RID: 15911 RVA: 0x00217C04 File Offset: 0x00216C04
		public static CmykColor Lime
		{
			get
			{
				CmykColor.db();
				return CmykColor.m;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06003E28 RID: 15912 RVA: 0x00217C24 File Offset: 0x00216C24
		public static CmykColor Aqua
		{
			get
			{
				CmykColor.da();
				return CmykColor.n;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06003E29 RID: 15913 RVA: 0x00217C44 File Offset: 0x00216C44
		public static CmykColor Purple
		{
			get
			{
				CmykColor.c9();
				return CmykColor.o;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06003E2A RID: 15914 RVA: 0x00217C64 File Offset: 0x00216C64
		public static CmykColor Blue
		{
			get
			{
				CmykColor.c8();
				return CmykColor.p;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06003E2B RID: 15915 RVA: 0x00217C84 File Offset: 0x00216C84
		public static CmykColor Cyan
		{
			get
			{
				CmykColor.c7();
				return CmykColor.q;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06003E2C RID: 15916 RVA: 0x00217CA4 File Offset: 0x00216CA4
		public static CmykColor Magenta
		{
			get
			{
				CmykColor.c6();
				return CmykColor.r;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06003E2D RID: 15917 RVA: 0x00217CC4 File Offset: 0x00216CC4
		public static CmykColor Yellow
		{
			get
			{
				CmykColor.c5();
				return CmykColor.s;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06003E2E RID: 15918 RVA: 0x00217CE4 File Offset: 0x00216CE4
		public static CmykColor AliceBlue
		{
			get
			{
				CmykColor.c4();
				return CmykColor.t;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06003E2F RID: 15919 RVA: 0x00217D04 File Offset: 0x00216D04
		public static CmykColor AntiqueWhite
		{
			get
			{
				CmykColor.c3();
				return CmykColor.u;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06003E30 RID: 15920 RVA: 0x00217D24 File Offset: 0x00216D24
		public static CmykColor Aquamarine
		{
			get
			{
				CmykColor.c2();
				return CmykColor.v;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06003E31 RID: 15921 RVA: 0x00217D44 File Offset: 0x00216D44
		public static CmykColor Azure
		{
			get
			{
				CmykColor.c1();
				return CmykColor.w;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06003E32 RID: 15922 RVA: 0x00217D64 File Offset: 0x00216D64
		public static CmykColor Beige
		{
			get
			{
				CmykColor.c0();
				return CmykColor.x;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06003E33 RID: 15923 RVA: 0x00217D84 File Offset: 0x00216D84
		public static CmykColor Bisque
		{
			get
			{
				CmykColor.cz();
				return CmykColor.y;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06003E34 RID: 15924 RVA: 0x00217DA4 File Offset: 0x00216DA4
		public static CmykColor BlanchedAlmond
		{
			get
			{
				CmykColor.cy();
				return CmykColor.z;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06003E35 RID: 15925 RVA: 0x00217DC4 File Offset: 0x00216DC4
		public static CmykColor BlueViolet
		{
			get
			{
				CmykColor.cx();
				return CmykColor.aa;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06003E36 RID: 15926 RVA: 0x00217DE4 File Offset: 0x00216DE4
		public static CmykColor Brown
		{
			get
			{
				CmykColor.cw();
				return CmykColor.ab;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06003E37 RID: 15927 RVA: 0x00217E04 File Offset: 0x00216E04
		public static CmykColor BurlyWood
		{
			get
			{
				CmykColor.cv();
				return CmykColor.ac;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06003E38 RID: 15928 RVA: 0x00217E24 File Offset: 0x00216E24
		public static CmykColor CadetBlue
		{
			get
			{
				CmykColor.cu();
				return CmykColor.ad;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06003E39 RID: 15929 RVA: 0x00217E44 File Offset: 0x00216E44
		public static CmykColor Chartreuse
		{
			get
			{
				CmykColor.ct();
				return CmykColor.ae;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06003E3A RID: 15930 RVA: 0x00217E64 File Offset: 0x00216E64
		public static CmykColor Chocolate
		{
			get
			{
				CmykColor.cs();
				return CmykColor.af;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06003E3B RID: 15931 RVA: 0x00217E84 File Offset: 0x00216E84
		public static CmykColor Coral
		{
			get
			{
				CmykColor.cr();
				return CmykColor.ag;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06003E3C RID: 15932 RVA: 0x00217EA4 File Offset: 0x00216EA4
		public static CmykColor CornflowerBlue
		{
			get
			{
				CmykColor.cq();
				return CmykColor.ah;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06003E3D RID: 15933 RVA: 0x00217EC4 File Offset: 0x00216EC4
		public static CmykColor Cornsilk
		{
			get
			{
				CmykColor.cp();
				return CmykColor.ai;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06003E3E RID: 15934 RVA: 0x00217EE4 File Offset: 0x00216EE4
		public static CmykColor Crimson
		{
			get
			{
				CmykColor.co();
				return CmykColor.aj;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06003E3F RID: 15935 RVA: 0x00217F04 File Offset: 0x00216F04
		public static CmykColor DarkBlue
		{
			get
			{
				CmykColor.cn();
				return CmykColor.ak;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06003E40 RID: 15936 RVA: 0x00217F24 File Offset: 0x00216F24
		public static CmykColor DarkCyan
		{
			get
			{
				CmykColor.cm();
				return CmykColor.al;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06003E41 RID: 15937 RVA: 0x00217F44 File Offset: 0x00216F44
		public static CmykColor DarkGoldenRod
		{
			get
			{
				CmykColor.cl();
				return CmykColor.am;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06003E42 RID: 15938 RVA: 0x00217F64 File Offset: 0x00216F64
		public static CmykColor DarkGreen
		{
			get
			{
				CmykColor.ck();
				return CmykColor.an;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06003E43 RID: 15939 RVA: 0x00217F84 File Offset: 0x00216F84
		public static CmykColor DarkKhaki
		{
			get
			{
				CmykColor.cj();
				return CmykColor.ao;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06003E44 RID: 15940 RVA: 0x00217FA4 File Offset: 0x00216FA4
		public static CmykColor DarkMagenta
		{
			get
			{
				CmykColor.ci();
				return CmykColor.ap;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06003E45 RID: 15941 RVA: 0x00217FC4 File Offset: 0x00216FC4
		public static CmykColor DarkOliveGreen
		{
			get
			{
				CmykColor.ch();
				return CmykColor.aq;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06003E46 RID: 15942 RVA: 0x00217FE4 File Offset: 0x00216FE4
		public static CmykColor DarkOrange
		{
			get
			{
				CmykColor.cg();
				return CmykColor.ar;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06003E47 RID: 15943 RVA: 0x00218004 File Offset: 0x00217004
		public static CmykColor DarkOrchid
		{
			get
			{
				CmykColor.cf();
				return CmykColor.@as;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06003E48 RID: 15944 RVA: 0x00218024 File Offset: 0x00217024
		public static CmykColor DarkRed
		{
			get
			{
				CmykColor.ce();
				return CmykColor.at;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06003E49 RID: 15945 RVA: 0x00218044 File Offset: 0x00217044
		public static CmykColor DarkSalmon
		{
			get
			{
				CmykColor.cd();
				return CmykColor.au;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06003E4A RID: 15946 RVA: 0x00218064 File Offset: 0x00217064
		public static CmykColor DarkSeaGreen
		{
			get
			{
				CmykColor.cc();
				return CmykColor.av;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06003E4B RID: 15947 RVA: 0x00218084 File Offset: 0x00217084
		public static CmykColor DarkSlateBlue
		{
			get
			{
				CmykColor.cb();
				return CmykColor.aw;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06003E4C RID: 15948 RVA: 0x002180A4 File Offset: 0x002170A4
		public static CmykColor DarkSlateGray
		{
			get
			{
				CmykColor.ca();
				return CmykColor.ax;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06003E4D RID: 15949 RVA: 0x002180C4 File Offset: 0x002170C4
		public static CmykColor DarkTurquoise
		{
			get
			{
				CmykColor.b9();
				return CmykColor.ay;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06003E4E RID: 15950 RVA: 0x002180E4 File Offset: 0x002170E4
		public static CmykColor DarkViolet
		{
			get
			{
				CmykColor.b8();
				return CmykColor.az;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06003E4F RID: 15951 RVA: 0x00218104 File Offset: 0x00217104
		public static CmykColor DeepPink
		{
			get
			{
				CmykColor.b7();
				return CmykColor.a0;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06003E50 RID: 15952 RVA: 0x00218124 File Offset: 0x00217124
		public static CmykColor DeepSkyBlue
		{
			get
			{
				CmykColor.b6();
				return CmykColor.a1;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06003E51 RID: 15953 RVA: 0x00218144 File Offset: 0x00217144
		public static CmykColor DodgerBlue
		{
			get
			{
				CmykColor.b5();
				return CmykColor.a2;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06003E52 RID: 15954 RVA: 0x00218164 File Offset: 0x00217164
		public static CmykColor Feldspar
		{
			get
			{
				CmykColor.b4();
				return CmykColor.a3;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06003E53 RID: 15955 RVA: 0x00218184 File Offset: 0x00217184
		public static CmykColor FireBrick
		{
			get
			{
				CmykColor.b3();
				return CmykColor.a4;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06003E54 RID: 15956 RVA: 0x002181A4 File Offset: 0x002171A4
		public static CmykColor FloralWhite
		{
			get
			{
				CmykColor.b2();
				return CmykColor.a5;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06003E55 RID: 15957 RVA: 0x002181C4 File Offset: 0x002171C4
		public static CmykColor ForestGreen
		{
			get
			{
				CmykColor.b1();
				return CmykColor.a6;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06003E56 RID: 15958 RVA: 0x002181E4 File Offset: 0x002171E4
		public static CmykColor Fuchsia
		{
			get
			{
				CmykColor.b0();
				return CmykColor.a7;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06003E57 RID: 15959 RVA: 0x00218204 File Offset: 0x00217204
		public static CmykColor Gainsboro
		{
			get
			{
				CmykColor.bz();
				return CmykColor.a8;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06003E58 RID: 15960 RVA: 0x00218224 File Offset: 0x00217224
		public static CmykColor GhostWhite
		{
			get
			{
				CmykColor.by();
				return CmykColor.a9;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06003E59 RID: 15961 RVA: 0x00218244 File Offset: 0x00217244
		public static CmykColor Gold
		{
			get
			{
				CmykColor.bx();
				return CmykColor.ba;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06003E5A RID: 15962 RVA: 0x00218264 File Offset: 0x00217264
		public static CmykColor GoldenRod
		{
			get
			{
				CmykColor.bw();
				return CmykColor.bb;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06003E5B RID: 15963 RVA: 0x00218284 File Offset: 0x00217284
		public static CmykColor GreenYellow
		{
			get
			{
				CmykColor.bv();
				return CmykColor.bc;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06003E5C RID: 15964 RVA: 0x002182A4 File Offset: 0x002172A4
		public static CmykColor HoneyDew
		{
			get
			{
				CmykColor.bu();
				return CmykColor.bd;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06003E5D RID: 15965 RVA: 0x002182C4 File Offset: 0x002172C4
		public static CmykColor HotPink
		{
			get
			{
				CmykColor.bt();
				return CmykColor.be;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06003E5E RID: 15966 RVA: 0x002182E4 File Offset: 0x002172E4
		public static CmykColor IndianRed
		{
			get
			{
				CmykColor.bs();
				return CmykColor.bf;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06003E5F RID: 15967 RVA: 0x00218304 File Offset: 0x00217304
		public static CmykColor Indigo
		{
			get
			{
				CmykColor.br();
				return CmykColor.bg;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06003E60 RID: 15968 RVA: 0x00218324 File Offset: 0x00217324
		public static CmykColor Ivory
		{
			get
			{
				CmykColor.bq();
				return CmykColor.bh;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06003E61 RID: 15969 RVA: 0x00218344 File Offset: 0x00217344
		public static CmykColor Khaki
		{
			get
			{
				CmykColor.bp();
				return CmykColor.bi;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06003E62 RID: 15970 RVA: 0x00218364 File Offset: 0x00217364
		public static CmykColor Lavender
		{
			get
			{
				CmykColor.bo();
				return CmykColor.bj;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06003E63 RID: 15971 RVA: 0x00218384 File Offset: 0x00217384
		public static CmykColor LavenderBlush
		{
			get
			{
				CmykColor.bn();
				return CmykColor.bk;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06003E64 RID: 15972 RVA: 0x002183A4 File Offset: 0x002173A4
		public static CmykColor LawnGreen
		{
			get
			{
				CmykColor.bm();
				return CmykColor.bl;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06003E65 RID: 15973 RVA: 0x002183C4 File Offset: 0x002173C4
		public static CmykColor LemonChiffon
		{
			get
			{
				CmykColor.bl();
				return CmykColor.bm;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06003E66 RID: 15974 RVA: 0x002183E4 File Offset: 0x002173E4
		public static CmykColor LightBlue
		{
			get
			{
				CmykColor.bk();
				return CmykColor.bn;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06003E67 RID: 15975 RVA: 0x00218404 File Offset: 0x00217404
		public static CmykColor LightCoral
		{
			get
			{
				CmykColor.bj();
				return CmykColor.bo;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06003E68 RID: 15976 RVA: 0x00218424 File Offset: 0x00217424
		public static CmykColor LightCyan
		{
			get
			{
				CmykColor.bi();
				return CmykColor.bp;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06003E69 RID: 15977 RVA: 0x00218444 File Offset: 0x00217444
		public static CmykColor LightGoldenRodYellow
		{
			get
			{
				CmykColor.bh();
				return CmykColor.bq;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06003E6A RID: 15978 RVA: 0x00218464 File Offset: 0x00217464
		public static CmykColor LightGrey
		{
			get
			{
				CmykColor.bg();
				return CmykColor.br;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06003E6B RID: 15979 RVA: 0x00218484 File Offset: 0x00217484
		public static CmykColor LightGreen
		{
			get
			{
				CmykColor.bf();
				return CmykColor.bs;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06003E6C RID: 15980 RVA: 0x002184A4 File Offset: 0x002174A4
		public static CmykColor LightPink
		{
			get
			{
				CmykColor.be();
				return CmykColor.bt;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06003E6D RID: 15981 RVA: 0x002184C4 File Offset: 0x002174C4
		public static CmykColor LightSalmon
		{
			get
			{
				CmykColor.bd();
				return CmykColor.bu;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06003E6E RID: 15982 RVA: 0x002184E4 File Offset: 0x002174E4
		public static CmykColor LightSeaGreen
		{
			get
			{
				CmykColor.bc();
				return CmykColor.bv;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06003E6F RID: 15983 RVA: 0x00218504 File Offset: 0x00217504
		public static CmykColor LightSkyBlue
		{
			get
			{
				CmykColor.bb();
				return CmykColor.bw;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06003E70 RID: 15984 RVA: 0x00218524 File Offset: 0x00217524
		public static CmykColor LightSlateBlue
		{
			get
			{
				CmykColor.ba();
				return CmykColor.bx;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06003E71 RID: 15985 RVA: 0x00218544 File Offset: 0x00217544
		public static CmykColor LightSlateGray
		{
			get
			{
				CmykColor.a9();
				return CmykColor.by;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06003E72 RID: 15986 RVA: 0x00218564 File Offset: 0x00217564
		public static CmykColor LightSteelBlue
		{
			get
			{
				CmykColor.a8();
				return CmykColor.bz;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06003E73 RID: 15987 RVA: 0x00218584 File Offset: 0x00217584
		public static CmykColor LightYellow
		{
			get
			{
				CmykColor.a7();
				return CmykColor.b0;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06003E74 RID: 15988 RVA: 0x002185A4 File Offset: 0x002175A4
		public static CmykColor LimeGreen
		{
			get
			{
				CmykColor.a6();
				return CmykColor.b1;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06003E75 RID: 15989 RVA: 0x002185C4 File Offset: 0x002175C4
		public static CmykColor Linen
		{
			get
			{
				CmykColor.a5();
				return CmykColor.b2;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06003E76 RID: 15990 RVA: 0x002185E4 File Offset: 0x002175E4
		public static CmykColor Maroon
		{
			get
			{
				CmykColor.a4();
				return CmykColor.b3;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06003E77 RID: 15991 RVA: 0x00218604 File Offset: 0x00217604
		public static CmykColor MediumAquaMarine
		{
			get
			{
				CmykColor.a3();
				return CmykColor.b4;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06003E78 RID: 15992 RVA: 0x00218624 File Offset: 0x00217624
		public static CmykColor MediumBlue
		{
			get
			{
				CmykColor.a2();
				return CmykColor.b5;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06003E79 RID: 15993 RVA: 0x00218644 File Offset: 0x00217644
		public static CmykColor MediumOrchid
		{
			get
			{
				CmykColor.a1();
				return CmykColor.b6;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06003E7A RID: 15994 RVA: 0x00218664 File Offset: 0x00217664
		public static CmykColor MediumPurple
		{
			get
			{
				CmykColor.a0();
				return CmykColor.b7;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06003E7B RID: 15995 RVA: 0x00218684 File Offset: 0x00217684
		public static CmykColor MediumSeaGreen
		{
			get
			{
				CmykColor.az();
				return CmykColor.b8;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06003E7C RID: 15996 RVA: 0x002186A4 File Offset: 0x002176A4
		public static CmykColor MediumSlateBlue
		{
			get
			{
				CmykColor.ay();
				return CmykColor.b9;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06003E7D RID: 15997 RVA: 0x002186C4 File Offset: 0x002176C4
		public static CmykColor MediumSpringGreen
		{
			get
			{
				CmykColor.ax();
				return CmykColor.ca;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06003E7E RID: 15998 RVA: 0x002186E4 File Offset: 0x002176E4
		public static CmykColor MediumTurquoise
		{
			get
			{
				CmykColor.aw();
				return CmykColor.cb;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06003E7F RID: 15999 RVA: 0x00218704 File Offset: 0x00217704
		public static CmykColor MediumVioletRed
		{
			get
			{
				CmykColor.av();
				return CmykColor.cc;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06003E80 RID: 16000 RVA: 0x00218724 File Offset: 0x00217724
		public static CmykColor MidnightBlue
		{
			get
			{
				CmykColor.au();
				return CmykColor.cd;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06003E81 RID: 16001 RVA: 0x00218744 File Offset: 0x00217744
		public static CmykColor MintCream
		{
			get
			{
				CmykColor.at();
				return CmykColor.ce;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06003E82 RID: 16002 RVA: 0x00218764 File Offset: 0x00217764
		public static CmykColor MistyRose
		{
			get
			{
				CmykColor.@as();
				return CmykColor.cf;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06003E83 RID: 16003 RVA: 0x00218784 File Offset: 0x00217784
		public static CmykColor Moccasin
		{
			get
			{
				CmykColor.ar();
				return CmykColor.cg;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06003E84 RID: 16004 RVA: 0x002187A4 File Offset: 0x002177A4
		public static CmykColor NavajoWhite
		{
			get
			{
				CmykColor.aq();
				return CmykColor.ch;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06003E85 RID: 16005 RVA: 0x002187C4 File Offset: 0x002177C4
		public static CmykColor Navy
		{
			get
			{
				CmykColor.ap();
				return CmykColor.ci;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06003E86 RID: 16006 RVA: 0x002187E4 File Offset: 0x002177E4
		public static CmykColor OldLace
		{
			get
			{
				CmykColor.ao();
				return CmykColor.cj;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06003E87 RID: 16007 RVA: 0x00218804 File Offset: 0x00217804
		public static CmykColor Olive
		{
			get
			{
				CmykColor.an();
				return CmykColor.ck;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06003E88 RID: 16008 RVA: 0x00218824 File Offset: 0x00217824
		public static CmykColor OliveDrab
		{
			get
			{
				CmykColor.am();
				return CmykColor.cl;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06003E89 RID: 16009 RVA: 0x00218844 File Offset: 0x00217844
		public static CmykColor Orange
		{
			get
			{
				CmykColor.al();
				return CmykColor.cm;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06003E8A RID: 16010 RVA: 0x00218864 File Offset: 0x00217864
		public static CmykColor OrangeRed
		{
			get
			{
				CmykColor.ak();
				return CmykColor.cn;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06003E8B RID: 16011 RVA: 0x00218884 File Offset: 0x00217884
		public static CmykColor Orchid
		{
			get
			{
				CmykColor.aj();
				return CmykColor.co;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06003E8C RID: 16012 RVA: 0x002188A4 File Offset: 0x002178A4
		public static CmykColor PaleGoldenRod
		{
			get
			{
				CmykColor.ai();
				return CmykColor.cp;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06003E8D RID: 16013 RVA: 0x002188C4 File Offset: 0x002178C4
		public static CmykColor PaleGreen
		{
			get
			{
				CmykColor.ah();
				return CmykColor.cq;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06003E8E RID: 16014 RVA: 0x002188E4 File Offset: 0x002178E4
		public static CmykColor PaleTurquoise
		{
			get
			{
				CmykColor.ag();
				return CmykColor.cr;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06003E8F RID: 16015 RVA: 0x00218904 File Offset: 0x00217904
		public static CmykColor PaleVioletRed
		{
			get
			{
				CmykColor.af();
				return CmykColor.cs;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06003E90 RID: 16016 RVA: 0x00218924 File Offset: 0x00217924
		public static CmykColor PapayaWhip
		{
			get
			{
				CmykColor.ae();
				return CmykColor.ct;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06003E91 RID: 16017 RVA: 0x00218944 File Offset: 0x00217944
		public static CmykColor PeachPuff
		{
			get
			{
				CmykColor.ad();
				return CmykColor.cu;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06003E92 RID: 16018 RVA: 0x00218964 File Offset: 0x00217964
		public static CmykColor Peru
		{
			get
			{
				CmykColor.ac();
				return CmykColor.cv;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06003E93 RID: 16019 RVA: 0x00218984 File Offset: 0x00217984
		public static CmykColor Pink
		{
			get
			{
				CmykColor.ab();
				return CmykColor.cw;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06003E94 RID: 16020 RVA: 0x002189A4 File Offset: 0x002179A4
		public static CmykColor Plum
		{
			get
			{
				CmykColor.aa();
				return CmykColor.cx;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06003E95 RID: 16021 RVA: 0x002189C4 File Offset: 0x002179C4
		public static CmykColor PowderBlue
		{
			get
			{
				CmykColor.z();
				return CmykColor.cy;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06003E96 RID: 16022 RVA: 0x002189E4 File Offset: 0x002179E4
		public static CmykColor RosyBrown
		{
			get
			{
				CmykColor.y();
				return CmykColor.cz;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06003E97 RID: 16023 RVA: 0x00218A04 File Offset: 0x00217A04
		public static CmykColor RoyalBlue
		{
			get
			{
				CmykColor.x();
				return CmykColor.c0;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06003E98 RID: 16024 RVA: 0x00218A24 File Offset: 0x00217A24
		public static CmykColor SaddleBrown
		{
			get
			{
				CmykColor.w();
				return CmykColor.c1;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06003E99 RID: 16025 RVA: 0x00218A44 File Offset: 0x00217A44
		public static CmykColor Salmon
		{
			get
			{
				CmykColor.v();
				return CmykColor.c2;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06003E9A RID: 16026 RVA: 0x00218A64 File Offset: 0x00217A64
		public static CmykColor SandyBrown
		{
			get
			{
				CmykColor.u();
				return CmykColor.c3;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06003E9B RID: 16027 RVA: 0x00218A84 File Offset: 0x00217A84
		public static CmykColor SeaGreen
		{
			get
			{
				CmykColor.t();
				return CmykColor.c4;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06003E9C RID: 16028 RVA: 0x00218AA4 File Offset: 0x00217AA4
		public static CmykColor SeaShell
		{
			get
			{
				CmykColor.s();
				return CmykColor.c5;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06003E9D RID: 16029 RVA: 0x00218AC4 File Offset: 0x00217AC4
		public static CmykColor Sienna
		{
			get
			{
				CmykColor.r();
				return CmykColor.c6;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06003E9E RID: 16030 RVA: 0x00218AE4 File Offset: 0x00217AE4
		public static CmykColor SkyBlue
		{
			get
			{
				CmykColor.q();
				return CmykColor.c7;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06003E9F RID: 16031 RVA: 0x00218B04 File Offset: 0x00217B04
		public static CmykColor SlateBlue
		{
			get
			{
				CmykColor.p();
				return CmykColor.c8;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06003EA0 RID: 16032 RVA: 0x00218B24 File Offset: 0x00217B24
		public static CmykColor SlateGray
		{
			get
			{
				CmykColor.o();
				return CmykColor.c9;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06003EA1 RID: 16033 RVA: 0x00218B44 File Offset: 0x00217B44
		public static CmykColor Snow
		{
			get
			{
				CmykColor.n();
				return CmykColor.da;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06003EA2 RID: 16034 RVA: 0x00218B64 File Offset: 0x00217B64
		public static CmykColor SpringGreen
		{
			get
			{
				CmykColor.l();
				return CmykColor.db;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06003EA3 RID: 16035 RVA: 0x00218B84 File Offset: 0x00217B84
		public static CmykColor SteelBlue
		{
			get
			{
				CmykColor.k();
				return CmykColor.dc;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06003EA4 RID: 16036 RVA: 0x00218BA4 File Offset: 0x00217BA4
		public static CmykColor Tan
		{
			get
			{
				CmykColor.j();
				return CmykColor.dd;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06003EA5 RID: 16037 RVA: 0x00218BC4 File Offset: 0x00217BC4
		public static CmykColor Teal
		{
			get
			{
				CmykColor.i();
				return CmykColor.de;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06003EA6 RID: 16038 RVA: 0x00218BE4 File Offset: 0x00217BE4
		public static CmykColor Thistle
		{
			get
			{
				CmykColor.h();
				return CmykColor.df;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06003EA7 RID: 16039 RVA: 0x00218C04 File Offset: 0x00217C04
		public static CmykColor Tomato
		{
			get
			{
				CmykColor.g();
				return CmykColor.dg;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06003EA8 RID: 16040 RVA: 0x00218C24 File Offset: 0x00217C24
		public static CmykColor Turquoise
		{
			get
			{
				CmykColor.f();
				return CmykColor.dh;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06003EA9 RID: 16041 RVA: 0x00218C44 File Offset: 0x00217C44
		public static CmykColor Violet
		{
			get
			{
				CmykColor.e();
				return CmykColor.di;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06003EAA RID: 16042 RVA: 0x00218C64 File Offset: 0x00217C64
		public static CmykColor VioletRed
		{
			get
			{
				CmykColor.d();
				return CmykColor.dj;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06003EAB RID: 16043 RVA: 0x00218C84 File Offset: 0x00217C84
		public static CmykColor Wheat
		{
			get
			{
				CmykColor.c();
				return CmykColor.dk;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06003EAC RID: 16044 RVA: 0x00218CA4 File Offset: 0x00217CA4
		public static CmykColor WhiteSmoke
		{
			get
			{
				CmykColor.b();
				return CmykColor.dl;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06003EAD RID: 16045 RVA: 0x00218CC4 File Offset: 0x00217CC4
		public static CmykColor YellowGreen
		{
			get
			{
				CmykColor.a();
				return CmykColor.dm;
			}
		}

		// Token: 0x06003EAE RID: 16046 RVA: 0x00218CE4 File Offset: 0x00217CE4
		private static void dj()
		{
			if (CmykColor.e == null)
			{
				CmykColor.e = CmykColor.a(0, 0, 0);
			}
		}

		// Token: 0x06003EAF RID: 16047 RVA: 0x00218D10 File Offset: 0x00217D10
		private static void di()
		{
			if (CmykColor.f == null)
			{
				CmykColor.f = CmykColor.a(192, 192, 192);
			}
		}

		// Token: 0x06003EB0 RID: 16048 RVA: 0x00218D48 File Offset: 0x00217D48
		private static void dh()
		{
			if (CmykColor.g == null)
			{
				CmykColor.g = CmykColor.a(167, 167, 167);
			}
		}

		// Token: 0x06003EB1 RID: 16049 RVA: 0x00218D80 File Offset: 0x00217D80
		private static void dg()
		{
			if (CmykColor.h == null)
			{
				CmykColor.h = CmykColor.a(190, 190, 190);
			}
		}

		// Token: 0x06003EB2 RID: 16050 RVA: 0x00218DB8 File Offset: 0x00217DB8
		private static void df()
		{
			if (CmykColor.i == null)
			{
				CmykColor.i = CmykColor.a(105, 105, 105);
			}
		}

		// Token: 0x06003EB3 RID: 16051 RVA: 0x00218DE8 File Offset: 0x00217DE8
		private static void de()
		{
			if (CmykColor.j == null)
			{
				CmykColor.j = CmykColor.a(byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06003EB4 RID: 16052 RVA: 0x00218E20 File Offset: 0x00217E20
		private static void dd()
		{
			if (CmykColor.k == null)
			{
				CmykColor.k = CmykColor.a(byte.MaxValue, 0, 0);
			}
		}

		// Token: 0x06003EB5 RID: 16053 RVA: 0x00218E50 File Offset: 0x00217E50
		private static void dc()
		{
			if (CmykColor.l == null)
			{
				CmykColor.l = CmykColor.a(0, 128, 0);
			}
		}

		// Token: 0x06003EB6 RID: 16054 RVA: 0x00218E80 File Offset: 0x00217E80
		private static void db()
		{
			if (CmykColor.m == null)
			{
				CmykColor.m = CmykColor.a(0, byte.MaxValue, 0);
			}
		}

		// Token: 0x06003EB7 RID: 16055 RVA: 0x00218EB0 File Offset: 0x00217EB0
		private static void da()
		{
			if (CmykColor.n == null)
			{
				CmykColor.n = CmykColor.a(0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06003EB8 RID: 16056 RVA: 0x00218EE4 File Offset: 0x00217EE4
		private static void c9()
		{
			if (CmykColor.o == null)
			{
				CmykColor.o = CmykColor.a(128, 0, 128);
			}
		}

		// Token: 0x06003EB9 RID: 16057 RVA: 0x00218F18 File Offset: 0x00217F18
		private static void c8()
		{
			if (CmykColor.p == null)
			{
				CmykColor.p = CmykColor.a(0, 0, byte.MaxValue);
			}
		}

		// Token: 0x06003EBA RID: 16058 RVA: 0x00218F48 File Offset: 0x00217F48
		private static void c7()
		{
			if (CmykColor.q == null)
			{
				CmykColor.q = CmykColor.a(0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06003EBB RID: 16059 RVA: 0x00218F7C File Offset: 0x00217F7C
		private static void c6()
		{
			if (CmykColor.r == null)
			{
				CmykColor.r = CmykColor.a(byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x06003EBC RID: 16060 RVA: 0x00218FB0 File Offset: 0x00217FB0
		private static void c5()
		{
			if (CmykColor.s == null)
			{
				CmykColor.s = CmykColor.a(byte.MaxValue, byte.MaxValue, 0);
			}
		}

		// Token: 0x06003EBD RID: 16061 RVA: 0x00218FE4 File Offset: 0x00217FE4
		private static void c4()
		{
			if (CmykColor.t == null)
			{
				CmykColor.t = CmykColor.a(240, 248, byte.MaxValue);
			}
		}

		// Token: 0x06003EBE RID: 16062 RVA: 0x0021901C File Offset: 0x0021801C
		private static void c3()
		{
			if (CmykColor.u == null)
			{
				CmykColor.u = CmykColor.a(250, 235, 215);
			}
		}

		// Token: 0x06003EBF RID: 16063 RVA: 0x00219054 File Offset: 0x00218054
		private static void c2()
		{
			if (CmykColor.v == null)
			{
				CmykColor.v = CmykColor.a(127, byte.MaxValue, 212);
			}
		}

		// Token: 0x06003EC0 RID: 16064 RVA: 0x00219088 File Offset: 0x00218088
		private static void c1()
		{
			if (CmykColor.w == null)
			{
				CmykColor.w = CmykColor.a(240, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06003EC1 RID: 16065 RVA: 0x002190C0 File Offset: 0x002180C0
		private static void c0()
		{
			if (CmykColor.x == null)
			{
				CmykColor.x = CmykColor.a(245, 245, 220);
			}
		}

		// Token: 0x06003EC2 RID: 16066 RVA: 0x002190F8 File Offset: 0x002180F8
		private static void cz()
		{
			if (CmykColor.y == null)
			{
				CmykColor.y = CmykColor.a(byte.MaxValue, 228, 196);
			}
		}

		// Token: 0x06003EC3 RID: 16067 RVA: 0x00219130 File Offset: 0x00218130
		private static void cy()
		{
			if (CmykColor.z == null)
			{
				CmykColor.z = CmykColor.a(byte.MaxValue, 235, 205);
			}
		}

		// Token: 0x06003EC4 RID: 16068 RVA: 0x00219168 File Offset: 0x00218168
		private static void cx()
		{
			if (CmykColor.aa == null)
			{
				CmykColor.aa = CmykColor.a(138, 43, 226);
			}
		}

		// Token: 0x06003EC5 RID: 16069 RVA: 0x0021919C File Offset: 0x0021819C
		private static void cw()
		{
			if (CmykColor.ab == null)
			{
				CmykColor.ab = CmykColor.a(165, 42, 42);
			}
		}

		// Token: 0x06003EC6 RID: 16070 RVA: 0x002191CC File Offset: 0x002181CC
		private static void cv()
		{
			if (CmykColor.ac == null)
			{
				CmykColor.ac = CmykColor.a(222, 184, 135);
			}
		}

		// Token: 0x06003EC7 RID: 16071 RVA: 0x00219204 File Offset: 0x00218204
		private static void cu()
		{
			if (CmykColor.ad == null)
			{
				CmykColor.ad = CmykColor.a(95, 158, 160);
			}
		}

		// Token: 0x06003EC8 RID: 16072 RVA: 0x00219238 File Offset: 0x00218238
		private static void ct()
		{
			if (CmykColor.ae == null)
			{
				CmykColor.ae = CmykColor.a(127, byte.MaxValue, 0);
			}
		}

		// Token: 0x06003EC9 RID: 16073 RVA: 0x00219268 File Offset: 0x00218268
		private static void cs()
		{
			if (CmykColor.af == null)
			{
				CmykColor.af = CmykColor.a(210, 105, 30);
			}
		}

		// Token: 0x06003ECA RID: 16074 RVA: 0x00219298 File Offset: 0x00218298
		private static void cr()
		{
			if (CmykColor.ag == null)
			{
				CmykColor.ag = CmykColor.a(byte.MaxValue, 127, 80);
			}
		}

		// Token: 0x06003ECB RID: 16075 RVA: 0x002192C8 File Offset: 0x002182C8
		private static void cq()
		{
			if (CmykColor.ah == null)
			{
				CmykColor.ah = CmykColor.a(100, 149, 237);
			}
		}

		// Token: 0x06003ECC RID: 16076 RVA: 0x002192FC File Offset: 0x002182FC
		private static void cp()
		{
			if (CmykColor.ai == null)
			{
				CmykColor.ai = CmykColor.a(byte.MaxValue, 248, 220);
			}
		}

		// Token: 0x06003ECD RID: 16077 RVA: 0x00219334 File Offset: 0x00218334
		private static void co()
		{
			if (CmykColor.aj == null)
			{
				CmykColor.aj = CmykColor.a(237, 164, 61);
			}
		}

		// Token: 0x06003ECE RID: 16078 RVA: 0x00219368 File Offset: 0x00218368
		private static void cn()
		{
			if (CmykColor.ak == null)
			{
				CmykColor.ak = CmykColor.a(0, 0, 139);
			}
		}

		// Token: 0x06003ECF RID: 16079 RVA: 0x00219398 File Offset: 0x00218398
		private static void cm()
		{
			if (CmykColor.al == null)
			{
				CmykColor.al = CmykColor.a(0, 139, 139);
			}
		}

		// Token: 0x06003ED0 RID: 16080 RVA: 0x002193CC File Offset: 0x002183CC
		private static void cl()
		{
			if (CmykColor.am == null)
			{
				CmykColor.am = CmykColor.a(184, 134, 11);
			}
		}

		// Token: 0x06003ED1 RID: 16081 RVA: 0x00219400 File Offset: 0x00218400
		private static void ck()
		{
			if (CmykColor.an == null)
			{
				CmykColor.an = CmykColor.a(0, 100, 0);
			}
		}

		// Token: 0x06003ED2 RID: 16082 RVA: 0x0021942C File Offset: 0x0021842C
		private static void cj()
		{
			if (CmykColor.ao == null)
			{
				CmykColor.ao = CmykColor.a(189, 183, 107);
			}
		}

		// Token: 0x06003ED3 RID: 16083 RVA: 0x00219460 File Offset: 0x00218460
		private static void ci()
		{
			if (CmykColor.ap == null)
			{
				CmykColor.ap = CmykColor.a(139, 0, 139);
			}
		}

		// Token: 0x06003ED4 RID: 16084 RVA: 0x00219494 File Offset: 0x00218494
		private static void ch()
		{
			if (CmykColor.aq == null)
			{
				CmykColor.aq = CmykColor.a(85, 107, 47);
			}
		}

		// Token: 0x06003ED5 RID: 16085 RVA: 0x002194C4 File Offset: 0x002184C4
		private static void cg()
		{
			if (CmykColor.ar == null)
			{
				CmykColor.ar = CmykColor.a(byte.MaxValue, 140, 0);
			}
		}

		// Token: 0x06003ED6 RID: 16086 RVA: 0x002194F8 File Offset: 0x002184F8
		private static void cf()
		{
			if (CmykColor.@as == null)
			{
				CmykColor.@as = CmykColor.a(153, 50, 204);
			}
		}

		// Token: 0x06003ED7 RID: 16087 RVA: 0x0021952C File Offset: 0x0021852C
		private static void ce()
		{
			if (CmykColor.at == null)
			{
				CmykColor.at = CmykColor.a(139, 0, 0);
			}
		}

		// Token: 0x06003ED8 RID: 16088 RVA: 0x0021955C File Offset: 0x0021855C
		private static void cd()
		{
			if (CmykColor.au == null)
			{
				CmykColor.au = CmykColor.a(233, 150, 122);
			}
		}

		// Token: 0x06003ED9 RID: 16089 RVA: 0x00219590 File Offset: 0x00218590
		private static void cc()
		{
			if (CmykColor.av == null)
			{
				CmykColor.av = CmykColor.a(143, 188, 143);
			}
		}

		// Token: 0x06003EDA RID: 16090 RVA: 0x002195C8 File Offset: 0x002185C8
		private static void cb()
		{
			if (CmykColor.aw == null)
			{
				CmykColor.aw = CmykColor.a(72, 61, 139);
			}
		}

		// Token: 0x06003EDB RID: 16091 RVA: 0x002195F8 File Offset: 0x002185F8
		private static void ca()
		{
			if (CmykColor.ax == null)
			{
				CmykColor.ax = CmykColor.a(47, 79, 79);
			}
		}

		// Token: 0x06003EDC RID: 16092 RVA: 0x00219628 File Offset: 0x00218628
		private static void b9()
		{
			if (CmykColor.ay == null)
			{
				CmykColor.ay = CmykColor.a(0, 206, 209);
			}
		}

		// Token: 0x06003EDD RID: 16093 RVA: 0x0021965C File Offset: 0x0021865C
		private static void b8()
		{
			if (CmykColor.az == null)
			{
				CmykColor.az = CmykColor.a(148, 0, 211);
			}
		}

		// Token: 0x06003EDE RID: 16094 RVA: 0x00219690 File Offset: 0x00218690
		private static void b7()
		{
			if (CmykColor.a0 == null)
			{
				CmykColor.a0 = CmykColor.a(byte.MaxValue, 20, 147);
			}
		}

		// Token: 0x06003EDF RID: 16095 RVA: 0x002196C4 File Offset: 0x002186C4
		private static void b6()
		{
			if (CmykColor.a1 == null)
			{
				CmykColor.a1 = CmykColor.a(0, 191, byte.MaxValue);
			}
		}

		// Token: 0x06003EE0 RID: 16096 RVA: 0x002196F8 File Offset: 0x002186F8
		private static void b5()
		{
			if (CmykColor.a2 == null)
			{
				CmykColor.a2 = CmykColor.a(30, 144, byte.MaxValue);
			}
		}

		// Token: 0x06003EE1 RID: 16097 RVA: 0x0021972C File Offset: 0x0021872C
		private static void b4()
		{
			if (CmykColor.a3 == null)
			{
				CmykColor.a3 = CmykColor.a(209, 146, 117);
			}
		}

		// Token: 0x06003EE2 RID: 16098 RVA: 0x00219760 File Offset: 0x00218760
		private static void b3()
		{
			if (CmykColor.a4 == null)
			{
				CmykColor.a4 = CmykColor.a(178, 34, 34);
			}
		}

		// Token: 0x06003EE3 RID: 16099 RVA: 0x00219790 File Offset: 0x00218790
		private static void b2()
		{
			if (CmykColor.a5 == null)
			{
				CmykColor.a5 = CmykColor.a(byte.MaxValue, 250, 240);
			}
		}

		// Token: 0x06003EE4 RID: 16100 RVA: 0x002197C8 File Offset: 0x002187C8
		private static void b1()
		{
			if (CmykColor.a6 == null)
			{
				CmykColor.a6 = CmykColor.a(34, 139, 34);
			}
		}

		// Token: 0x06003EE5 RID: 16101 RVA: 0x002197F8 File Offset: 0x002187F8
		private static void b0()
		{
			if (CmykColor.a7 == null)
			{
				CmykColor.a7 = CmykColor.a(byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x06003EE6 RID: 16102 RVA: 0x0021982C File Offset: 0x0021882C
		private static void bz()
		{
			if (CmykColor.a8 == null)
			{
				CmykColor.a8 = CmykColor.a(220, 220, 220);
			}
		}

		// Token: 0x06003EE7 RID: 16103 RVA: 0x00219864 File Offset: 0x00218864
		private static void by()
		{
			if (CmykColor.a9 == null)
			{
				CmykColor.a9 = CmykColor.a(248, 248, byte.MaxValue);
			}
		}

		// Token: 0x06003EE8 RID: 16104 RVA: 0x0021989C File Offset: 0x0021889C
		private static void bx()
		{
			if (CmykColor.ba == null)
			{
				CmykColor.ba = CmykColor.a(byte.MaxValue, 215, 0);
			}
		}

		// Token: 0x06003EE9 RID: 16105 RVA: 0x002198D0 File Offset: 0x002188D0
		private static void bw()
		{
			if (CmykColor.bb == null)
			{
				CmykColor.bb = CmykColor.a(218, 165, 32);
			}
		}

		// Token: 0x06003EEA RID: 16106 RVA: 0x00219904 File Offset: 0x00218904
		private static void bv()
		{
			if (CmykColor.bc == null)
			{
				CmykColor.bc = CmykColor.a(173, byte.MaxValue, 47);
			}
		}

		// Token: 0x06003EEB RID: 16107 RVA: 0x00219938 File Offset: 0x00218938
		private static void bu()
		{
			if (CmykColor.bd == null)
			{
				CmykColor.bd = CmykColor.a(240, byte.MaxValue, 240);
			}
		}

		// Token: 0x06003EEC RID: 16108 RVA: 0x00219970 File Offset: 0x00218970
		private static void bt()
		{
			if (CmykColor.be == null)
			{
				CmykColor.be = CmykColor.a(byte.MaxValue, 105, 180);
			}
		}

		// Token: 0x06003EED RID: 16109 RVA: 0x002199A4 File Offset: 0x002189A4
		private static void bs()
		{
			if (CmykColor.bf == null)
			{
				CmykColor.bf = CmykColor.a(205, 92, 92);
			}
		}

		// Token: 0x06003EEE RID: 16110 RVA: 0x002199D4 File Offset: 0x002189D4
		private static void br()
		{
			if (CmykColor.bg == null)
			{
				CmykColor.bg = CmykColor.a(75, 0, 130);
			}
		}

		// Token: 0x06003EEF RID: 16111 RVA: 0x00219A04 File Offset: 0x00218A04
		private static void bq()
		{
			if (CmykColor.bh == null)
			{
				CmykColor.bh = CmykColor.a(byte.MaxValue, byte.MaxValue, 240);
			}
		}

		// Token: 0x06003EF0 RID: 16112 RVA: 0x00219A3C File Offset: 0x00218A3C
		private static void bp()
		{
			if (CmykColor.bi == null)
			{
				CmykColor.bi = CmykColor.a(240, 230, 140);
			}
		}

		// Token: 0x06003EF1 RID: 16113 RVA: 0x00219A74 File Offset: 0x00218A74
		private static void bo()
		{
			if (CmykColor.bj == null)
			{
				CmykColor.bj = CmykColor.a(230, 230, 250);
			}
		}

		// Token: 0x06003EF2 RID: 16114 RVA: 0x00219AAC File Offset: 0x00218AAC
		private static void bn()
		{
			if (CmykColor.bk == null)
			{
				CmykColor.bk = CmykColor.a(byte.MaxValue, 240, 245);
			}
		}

		// Token: 0x06003EF3 RID: 16115 RVA: 0x00219AE4 File Offset: 0x00218AE4
		private static void bm()
		{
			if (CmykColor.bl == null)
			{
				CmykColor.bl = CmykColor.a(124, 252, 0);
			}
		}

		// Token: 0x06003EF4 RID: 16116 RVA: 0x00219B14 File Offset: 0x00218B14
		private static void bl()
		{
			if (CmykColor.bm == null)
			{
				CmykColor.bm = CmykColor.a(byte.MaxValue, 250, 205);
			}
		}

		// Token: 0x06003EF5 RID: 16117 RVA: 0x00219B4C File Offset: 0x00218B4C
		private static void bk()
		{
			if (CmykColor.bn == null)
			{
				CmykColor.bn = CmykColor.a(173, 216, 230);
			}
		}

		// Token: 0x06003EF6 RID: 16118 RVA: 0x00219B84 File Offset: 0x00218B84
		private static void bj()
		{
			if (CmykColor.bo == null)
			{
				CmykColor.bo = CmykColor.a(240, 128, 128);
			}
		}

		// Token: 0x06003EF7 RID: 16119 RVA: 0x00219BBC File Offset: 0x00218BBC
		private static void bi()
		{
			if (CmykColor.bp == null)
			{
				CmykColor.bp = CmykColor.a(224, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x06003EF8 RID: 16120 RVA: 0x00219BF4 File Offset: 0x00218BF4
		private static void bh()
		{
			if (CmykColor.bq == null)
			{
				CmykColor.bq = CmykColor.a(250, 250, 210);
			}
		}

		// Token: 0x06003EF9 RID: 16121 RVA: 0x00219C2C File Offset: 0x00218C2C
		private static void bg()
		{
			if (CmykColor.br == null)
			{
				CmykColor.br = CmykColor.a(211, 211, 211);
			}
		}

		// Token: 0x06003EFA RID: 16122 RVA: 0x00219C64 File Offset: 0x00218C64
		private static void bf()
		{
			if (CmykColor.bs == null)
			{
				CmykColor.bs = CmykColor.a(144, 238, 144);
			}
		}

		// Token: 0x06003EFB RID: 16123 RVA: 0x00219C9C File Offset: 0x00218C9C
		private static void be()
		{
			if (CmykColor.bt == null)
			{
				CmykColor.bt = CmykColor.a(byte.MaxValue, 182, 193);
			}
		}

		// Token: 0x06003EFC RID: 16124 RVA: 0x00219CD4 File Offset: 0x00218CD4
		private static void bd()
		{
			if (CmykColor.bu == null)
			{
				CmykColor.bu = CmykColor.a(byte.MaxValue, 160, 122);
			}
		}

		// Token: 0x06003EFD RID: 16125 RVA: 0x00219D08 File Offset: 0x00218D08
		private static void bc()
		{
			if (CmykColor.bv == null)
			{
				CmykColor.bv = CmykColor.a(32, 178, 170);
			}
		}

		// Token: 0x06003EFE RID: 16126 RVA: 0x00219D3C File Offset: 0x00218D3C
		private static void bb()
		{
			if (CmykColor.bw == null)
			{
				CmykColor.bw = CmykColor.a(135, 206, 250);
			}
		}

		// Token: 0x06003EFF RID: 16127 RVA: 0x00219D74 File Offset: 0x00218D74
		private static void ba()
		{
			if (CmykColor.bx == null)
			{
				CmykColor.bx = CmykColor.a(132, 112, byte.MaxValue);
			}
		}

		// Token: 0x06003F00 RID: 16128 RVA: 0x00219DA8 File Offset: 0x00218DA8
		private static void a9()
		{
			if (CmykColor.by == null)
			{
				CmykColor.by = CmykColor.a(119, 136, 153);
			}
		}

		// Token: 0x06003F01 RID: 16129 RVA: 0x00219DDC File Offset: 0x00218DDC
		private static void a8()
		{
			if (CmykColor.bz == null)
			{
				CmykColor.bz = CmykColor.a(176, 196, 222);
			}
		}

		// Token: 0x06003F02 RID: 16130 RVA: 0x00219E14 File Offset: 0x00218E14
		private static void a7()
		{
			if (CmykColor.b0 == null)
			{
				CmykColor.b0 = CmykColor.a(byte.MaxValue, byte.MaxValue, 224);
			}
		}

		// Token: 0x06003F03 RID: 16131 RVA: 0x00219E4C File Offset: 0x00218E4C
		private static void a6()
		{
			if (CmykColor.b1 == null)
			{
				CmykColor.b1 = CmykColor.a(50, 205, 50);
			}
		}

		// Token: 0x06003F04 RID: 16132 RVA: 0x00219E7C File Offset: 0x00218E7C
		private static void a5()
		{
			if (CmykColor.b2 == null)
			{
				CmykColor.b2 = CmykColor.a(250, 240, 230);
			}
		}

		// Token: 0x06003F05 RID: 16133 RVA: 0x00219EB4 File Offset: 0x00218EB4
		private static void a4()
		{
			if (CmykColor.b3 == null)
			{
				CmykColor.b3 = CmykColor.a(128, 0, 0);
			}
		}

		// Token: 0x06003F06 RID: 16134 RVA: 0x00219EE4 File Offset: 0x00218EE4
		private static void a3()
		{
			if (CmykColor.b4 == null)
			{
				CmykColor.b4 = CmykColor.a(102, 205, 170);
			}
		}

		// Token: 0x06003F07 RID: 16135 RVA: 0x00219F18 File Offset: 0x00218F18
		private static void a2()
		{
			if (CmykColor.b5 == null)
			{
				CmykColor.b5 = CmykColor.a(0, 0, 205);
			}
		}

		// Token: 0x06003F08 RID: 16136 RVA: 0x00219F48 File Offset: 0x00218F48
		private static void a1()
		{
			if (CmykColor.b6 == null)
			{
				CmykColor.b6 = CmykColor.a(186, 85, 211);
			}
		}

		// Token: 0x06003F09 RID: 16137 RVA: 0x00219F7C File Offset: 0x00218F7C
		private static void a0()
		{
			if (CmykColor.b7 == null)
			{
				CmykColor.b7 = CmykColor.a(147, 112, 219);
			}
		}

		// Token: 0x06003F0A RID: 16138 RVA: 0x00219FB0 File Offset: 0x00218FB0
		private static void az()
		{
			if (CmykColor.b8 == null)
			{
				CmykColor.b8 = CmykColor.a(60, 179, 113);
			}
		}

		// Token: 0x06003F0B RID: 16139 RVA: 0x00219FE0 File Offset: 0x00218FE0
		private static void ay()
		{
			if (CmykColor.b9 == null)
			{
				CmykColor.b9 = CmykColor.a(123, 104, 238);
			}
		}

		// Token: 0x06003F0C RID: 16140 RVA: 0x0021A010 File Offset: 0x00219010
		private static void ax()
		{
			if (CmykColor.ca == null)
			{
				CmykColor.ca = CmykColor.a(0, 250, 154);
			}
		}

		// Token: 0x06003F0D RID: 16141 RVA: 0x0021A044 File Offset: 0x00219044
		private static void aw()
		{
			if (CmykColor.cb == null)
			{
				CmykColor.cb = CmykColor.a(72, 209, 204);
			}
		}

		// Token: 0x06003F0E RID: 16142 RVA: 0x0021A078 File Offset: 0x00219078
		private static void av()
		{
			if (CmykColor.cc == null)
			{
				CmykColor.cc = CmykColor.a(199, 21, 133);
			}
		}

		// Token: 0x06003F0F RID: 16143 RVA: 0x0021A0AC File Offset: 0x002190AC
		private static void au()
		{
			if (CmykColor.cd == null)
			{
				CmykColor.cd = CmykColor.a(25, 25, 112);
			}
		}

		// Token: 0x06003F10 RID: 16144 RVA: 0x0021A0DC File Offset: 0x002190DC
		private static void at()
		{
			if (CmykColor.ce == null)
			{
				CmykColor.ce = CmykColor.a(245, byte.MaxValue, 250);
			}
		}

		// Token: 0x06003F11 RID: 16145 RVA: 0x0021A114 File Offset: 0x00219114
		private static void @as()
		{
			if (CmykColor.cf == null)
			{
				CmykColor.cf = CmykColor.a(byte.MaxValue, 228, 225);
			}
		}

		// Token: 0x06003F12 RID: 16146 RVA: 0x0021A14C File Offset: 0x0021914C
		private static void ar()
		{
			if (CmykColor.cg == null)
			{
				CmykColor.cg = CmykColor.a(byte.MaxValue, 228, 181);
			}
		}

		// Token: 0x06003F13 RID: 16147 RVA: 0x0021A184 File Offset: 0x00219184
		private static void aq()
		{
			if (CmykColor.ch == null)
			{
				CmykColor.ch = CmykColor.a(byte.MaxValue, 222, 173);
			}
		}

		// Token: 0x06003F14 RID: 16148 RVA: 0x0021A1BC File Offset: 0x002191BC
		private static void ap()
		{
			if (CmykColor.ci == null)
			{
				CmykColor.ci = CmykColor.a(0, 0, 128);
			}
		}

		// Token: 0x06003F15 RID: 16149 RVA: 0x0021A1EC File Offset: 0x002191EC
		private static void ao()
		{
			if (CmykColor.cj == null)
			{
				CmykColor.cj = CmykColor.a(253, 245, 230);
			}
		}

		// Token: 0x06003F16 RID: 16150 RVA: 0x0021A224 File Offset: 0x00219224
		private static void an()
		{
			if (CmykColor.ck == null)
			{
				CmykColor.ck = CmykColor.a(128, 128, 0);
			}
		}

		// Token: 0x06003F17 RID: 16151 RVA: 0x0021A258 File Offset: 0x00219258
		private static void am()
		{
			if (CmykColor.cl == null)
			{
				CmykColor.cl = CmykColor.a(107, 142, 35);
			}
		}

		// Token: 0x06003F18 RID: 16152 RVA: 0x0021A288 File Offset: 0x00219288
		private static void al()
		{
			if (CmykColor.cm == null)
			{
				CmykColor.cm = CmykColor.a(byte.MaxValue, 165, 0);
			}
		}

		// Token: 0x06003F19 RID: 16153 RVA: 0x0021A2BC File Offset: 0x002192BC
		private static void ak()
		{
			if (CmykColor.cn == null)
			{
				CmykColor.cn = CmykColor.a(byte.MaxValue, 69, 0);
			}
		}

		// Token: 0x06003F1A RID: 16154 RVA: 0x0021A2EC File Offset: 0x002192EC
		private static void aj()
		{
			if (CmykColor.co == null)
			{
				CmykColor.co = CmykColor.a(218, 112, 214);
			}
		}

		// Token: 0x06003F1B RID: 16155 RVA: 0x0021A320 File Offset: 0x00219320
		private static void ai()
		{
			if (CmykColor.cp == null)
			{
				CmykColor.cp = CmykColor.a(238, 232, 170);
			}
		}

		// Token: 0x06003F1C RID: 16156 RVA: 0x0021A358 File Offset: 0x00219358
		private static void ah()
		{
			if (CmykColor.cq == null)
			{
				CmykColor.cq = CmykColor.a(152, 251, 152);
			}
		}

		// Token: 0x06003F1D RID: 16157 RVA: 0x0021A390 File Offset: 0x00219390
		private static void ag()
		{
			if (CmykColor.cr == null)
			{
				CmykColor.cr = CmykColor.a(175, 238, 238);
			}
		}

		// Token: 0x06003F1E RID: 16158 RVA: 0x0021A3C8 File Offset: 0x002193C8
		private static void af()
		{
			if (CmykColor.cs == null)
			{
				CmykColor.cs = CmykColor.a(219, 112, 147);
			}
		}

		// Token: 0x06003F1F RID: 16159 RVA: 0x0021A3FC File Offset: 0x002193FC
		private static void ae()
		{
			if (CmykColor.ct == null)
			{
				CmykColor.ct = CmykColor.a(byte.MaxValue, 239, 213);
			}
		}

		// Token: 0x06003F20 RID: 16160 RVA: 0x0021A434 File Offset: 0x00219434
		private static void ad()
		{
			if (CmykColor.cu == null)
			{
				CmykColor.cu = CmykColor.a(byte.MaxValue, 218, 185);
			}
		}

		// Token: 0x06003F21 RID: 16161 RVA: 0x0021A46C File Offset: 0x0021946C
		private static void ac()
		{
			if (CmykColor.cv == null)
			{
				CmykColor.cv = CmykColor.a(205, 133, 63);
			}
		}

		// Token: 0x06003F22 RID: 16162 RVA: 0x0021A4A0 File Offset: 0x002194A0
		private static void ab()
		{
			if (CmykColor.cw == null)
			{
				CmykColor.cw = CmykColor.a(byte.MaxValue, 192, 203);
			}
		}

		// Token: 0x06003F23 RID: 16163 RVA: 0x0021A4D8 File Offset: 0x002194D8
		private static void aa()
		{
			if (CmykColor.cx == null)
			{
				CmykColor.cx = CmykColor.a(221, 160, 221);
			}
		}

		// Token: 0x06003F24 RID: 16164 RVA: 0x0021A510 File Offset: 0x00219510
		private static void z()
		{
			if (CmykColor.cy == null)
			{
				CmykColor.cy = CmykColor.a(176, 224, 230);
			}
		}

		// Token: 0x06003F25 RID: 16165 RVA: 0x0021A548 File Offset: 0x00219548
		private static void y()
		{
			if (CmykColor.cz == null)
			{
				CmykColor.cz = CmykColor.a(188, 143, 143);
			}
		}

		// Token: 0x06003F26 RID: 16166 RVA: 0x0021A580 File Offset: 0x00219580
		private static void x()
		{
			if (CmykColor.c0 == null)
			{
				CmykColor.c0 = CmykColor.a(65, 105, 225);
			}
		}

		// Token: 0x06003F27 RID: 16167 RVA: 0x0021A5B0 File Offset: 0x002195B0
		private static void w()
		{
			if (CmykColor.c1 == null)
			{
				CmykColor.c1 = CmykColor.a(139, 69, 19);
			}
		}

		// Token: 0x06003F28 RID: 16168 RVA: 0x0021A5E0 File Offset: 0x002195E0
		private static void v()
		{
			if (CmykColor.c2 == null)
			{
				CmykColor.c2 = CmykColor.a(250, 128, 114);
			}
		}

		// Token: 0x06003F29 RID: 16169 RVA: 0x0021A614 File Offset: 0x00219614
		private static void u()
		{
			if (CmykColor.c3 == null)
			{
				CmykColor.c3 = CmykColor.a(244, 164, 96);
			}
		}

		// Token: 0x06003F2A RID: 16170 RVA: 0x0021A648 File Offset: 0x00219648
		private static void t()
		{
			if (CmykColor.c4 == null)
			{
				CmykColor.c4 = CmykColor.a(46, 139, 87);
			}
		}

		// Token: 0x06003F2B RID: 16171 RVA: 0x0021A678 File Offset: 0x00219678
		private static void s()
		{
			if (CmykColor.c5 == null)
			{
				CmykColor.c5 = CmykColor.a(byte.MaxValue, 245, 238);
			}
		}

		// Token: 0x06003F2C RID: 16172 RVA: 0x0021A6B0 File Offset: 0x002196B0
		private static void r()
		{
			if (CmykColor.c6 == null)
			{
				CmykColor.c6 = CmykColor.a(160, 82, 45);
			}
		}

		// Token: 0x06003F2D RID: 16173 RVA: 0x0021A6E0 File Offset: 0x002196E0
		private static void q()
		{
			if (CmykColor.c7 == null)
			{
				CmykColor.c7 = CmykColor.a(135, 206, 235);
			}
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x0021A718 File Offset: 0x00219718
		private static void p()
		{
			if (CmykColor.c8 == null)
			{
				CmykColor.c8 = CmykColor.a(106, 90, 205);
			}
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x0021A748 File Offset: 0x00219748
		private static void o()
		{
			if (CmykColor.c9 == null)
			{
				CmykColor.c9 = CmykColor.a(112, 128, 144);
			}
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x0021A77C File Offset: 0x0021977C
		private static void n()
		{
			if (CmykColor.da == null)
			{
				CmykColor.da = CmykColor.a(byte.MaxValue, 250, 250);
			}
		}

		// Token: 0x06003F31 RID: 16177 RVA: 0x0021A7B4 File Offset: 0x002197B4
		private static void l()
		{
			if (CmykColor.db == null)
			{
				CmykColor.db = CmykColor.a(0, byte.MaxValue, 127);
			}
		}

		// Token: 0x06003F32 RID: 16178 RVA: 0x0021A7E4 File Offset: 0x002197E4
		private static void k()
		{
			if (CmykColor.dc == null)
			{
				CmykColor.dc = CmykColor.a(70, 130, 180);
			}
		}

		// Token: 0x06003F33 RID: 16179 RVA: 0x0021A818 File Offset: 0x00219818
		private static void j()
		{
			if (CmykColor.dd == null)
			{
				CmykColor.dd = CmykColor.a(210, 180, 140);
			}
		}

		// Token: 0x06003F34 RID: 16180 RVA: 0x0021A850 File Offset: 0x00219850
		private static void i()
		{
			if (CmykColor.de == null)
			{
				CmykColor.de = CmykColor.a(0, 128, 128);
			}
		}

		// Token: 0x06003F35 RID: 16181 RVA: 0x0021A884 File Offset: 0x00219884
		private static void h()
		{
			if (CmykColor.df == null)
			{
				CmykColor.df = CmykColor.a(216, 191, 216);
			}
		}

		// Token: 0x06003F36 RID: 16182 RVA: 0x0021A8BC File Offset: 0x002198BC
		private static void g()
		{
			if (CmykColor.dg == null)
			{
				CmykColor.dg = CmykColor.a(byte.MaxValue, 99, 71);
			}
		}

		// Token: 0x06003F37 RID: 16183 RVA: 0x0021A8EC File Offset: 0x002198EC
		private static void f()
		{
			if (CmykColor.dh == null)
			{
				CmykColor.dh = CmykColor.a(64, 224, 208);
			}
		}

		// Token: 0x06003F38 RID: 16184 RVA: 0x0021A920 File Offset: 0x00219920
		private static void e()
		{
			if (CmykColor.di == null)
			{
				CmykColor.di = CmykColor.a(238, 130, 238);
			}
		}

		// Token: 0x06003F39 RID: 16185 RVA: 0x0021A958 File Offset: 0x00219958
		private static void d()
		{
			if (CmykColor.dj == null)
			{
				CmykColor.dj = CmykColor.a(208, 32, 144);
			}
		}

		// Token: 0x06003F3A RID: 16186 RVA: 0x0021A98C File Offset: 0x0021998C
		private static void c()
		{
			if (CmykColor.dk == null)
			{
				CmykColor.dk = CmykColor.a(245, 222, 179);
			}
		}

		// Token: 0x06003F3B RID: 16187 RVA: 0x0021A9C4 File Offset: 0x002199C4
		private static void b()
		{
			if (CmykColor.dl == null)
			{
				CmykColor.dl = CmykColor.a(245, 245, 245);
			}
		}

		// Token: 0x06003F3C RID: 16188 RVA: 0x0021A9FC File Offset: 0x002199FC
		private new static void a()
		{
			if (CmykColor.dm == null)
			{
				CmykColor.dm = CmykColor.a(154, 205, 50);
			}
		}

		// Token: 0x0400217A RID: 8570
		private new float a = 0f;

		// Token: 0x0400217B RID: 8571
		private new float b = 0f;

		// Token: 0x0400217C RID: 8572
		private new float c = 0f;

		// Token: 0x0400217D RID: 8573
		private new float d = 0f;

		// Token: 0x0400217E RID: 8574
		private static CmykColor e = null;

		// Token: 0x0400217F RID: 8575
		private static CmykColor f = null;

		// Token: 0x04002180 RID: 8576
		private static CmykColor g = null;

		// Token: 0x04002181 RID: 8577
		private static CmykColor h = null;

		// Token: 0x04002182 RID: 8578
		private static CmykColor i = null;

		// Token: 0x04002183 RID: 8579
		private static CmykColor j = null;

		// Token: 0x04002184 RID: 8580
		private static CmykColor k = null;

		// Token: 0x04002185 RID: 8581
		private static CmykColor l = null;

		// Token: 0x04002186 RID: 8582
		private new static CmykColor m = null;

		// Token: 0x04002187 RID: 8583
		private static CmykColor n = null;

		// Token: 0x04002188 RID: 8584
		private static CmykColor o = null;

		// Token: 0x04002189 RID: 8585
		private static CmykColor p = null;

		// Token: 0x0400218A RID: 8586
		private static CmykColor q = null;

		// Token: 0x0400218B RID: 8587
		private static CmykColor r = null;

		// Token: 0x0400218C RID: 8588
		private static CmykColor s = null;

		// Token: 0x0400218D RID: 8589
		private static CmykColor t = null;

		// Token: 0x0400218E RID: 8590
		private static CmykColor u = null;

		// Token: 0x0400218F RID: 8591
		private static CmykColor v = null;

		// Token: 0x04002190 RID: 8592
		private static CmykColor w = null;

		// Token: 0x04002191 RID: 8593
		private static CmykColor x = null;

		// Token: 0x04002192 RID: 8594
		private static CmykColor y = null;

		// Token: 0x04002193 RID: 8595
		private static CmykColor z = null;

		// Token: 0x04002194 RID: 8596
		private static CmykColor aa = null;

		// Token: 0x04002195 RID: 8597
		private static CmykColor ab = null;

		// Token: 0x04002196 RID: 8598
		private static CmykColor ac = null;

		// Token: 0x04002197 RID: 8599
		private static CmykColor ad = null;

		// Token: 0x04002198 RID: 8600
		private static CmykColor ae = null;

		// Token: 0x04002199 RID: 8601
		private static CmykColor af = null;

		// Token: 0x0400219A RID: 8602
		private static CmykColor ag = null;

		// Token: 0x0400219B RID: 8603
		private static CmykColor ah = null;

		// Token: 0x0400219C RID: 8604
		private static CmykColor ai = null;

		// Token: 0x0400219D RID: 8605
		private static CmykColor aj = null;

		// Token: 0x0400219E RID: 8606
		private static CmykColor ak = null;

		// Token: 0x0400219F RID: 8607
		private static CmykColor al = null;

		// Token: 0x040021A0 RID: 8608
		private static CmykColor am = null;

		// Token: 0x040021A1 RID: 8609
		private static CmykColor an = null;

		// Token: 0x040021A2 RID: 8610
		private static CmykColor ao = null;

		// Token: 0x040021A3 RID: 8611
		private static CmykColor ap = null;

		// Token: 0x040021A4 RID: 8612
		private static CmykColor aq = null;

		// Token: 0x040021A5 RID: 8613
		private static CmykColor ar = null;

		// Token: 0x040021A6 RID: 8614
		private static CmykColor @as = null;

		// Token: 0x040021A7 RID: 8615
		private static CmykColor at = null;

		// Token: 0x040021A8 RID: 8616
		private static CmykColor au = null;

		// Token: 0x040021A9 RID: 8617
		private static CmykColor av = null;

		// Token: 0x040021AA RID: 8618
		private static CmykColor aw = null;

		// Token: 0x040021AB RID: 8619
		private static CmykColor ax = null;

		// Token: 0x040021AC RID: 8620
		private static CmykColor ay = null;

		// Token: 0x040021AD RID: 8621
		private static CmykColor az = null;

		// Token: 0x040021AE RID: 8622
		private static CmykColor a0 = null;

		// Token: 0x040021AF RID: 8623
		private static CmykColor a1 = null;

		// Token: 0x040021B0 RID: 8624
		private static CmykColor a2 = null;

		// Token: 0x040021B1 RID: 8625
		private static CmykColor a3 = null;

		// Token: 0x040021B2 RID: 8626
		private static CmykColor a4 = null;

		// Token: 0x040021B3 RID: 8627
		private static CmykColor a5 = null;

		// Token: 0x040021B4 RID: 8628
		private static CmykColor a6 = null;

		// Token: 0x040021B5 RID: 8629
		private static CmykColor a7 = null;

		// Token: 0x040021B6 RID: 8630
		private static CmykColor a8 = null;

		// Token: 0x040021B7 RID: 8631
		private static CmykColor a9 = null;

		// Token: 0x040021B8 RID: 8632
		private static CmykColor ba = null;

		// Token: 0x040021B9 RID: 8633
		private static CmykColor bb = null;

		// Token: 0x040021BA RID: 8634
		private static CmykColor bc = null;

		// Token: 0x040021BB RID: 8635
		private static CmykColor bd = null;

		// Token: 0x040021BC RID: 8636
		private static CmykColor be = null;

		// Token: 0x040021BD RID: 8637
		private static CmykColor bf = null;

		// Token: 0x040021BE RID: 8638
		private static CmykColor bg = null;

		// Token: 0x040021BF RID: 8639
		private static CmykColor bh = null;

		// Token: 0x040021C0 RID: 8640
		private static CmykColor bi = null;

		// Token: 0x040021C1 RID: 8641
		private static CmykColor bj = null;

		// Token: 0x040021C2 RID: 8642
		private static CmykColor bk = null;

		// Token: 0x040021C3 RID: 8643
		private static CmykColor bl = null;

		// Token: 0x040021C4 RID: 8644
		private static CmykColor bm = null;

		// Token: 0x040021C5 RID: 8645
		private static CmykColor bn = null;

		// Token: 0x040021C6 RID: 8646
		private static CmykColor bo = null;

		// Token: 0x040021C7 RID: 8647
		private static CmykColor bp = null;

		// Token: 0x040021C8 RID: 8648
		private static CmykColor bq = null;

		// Token: 0x040021C9 RID: 8649
		private static CmykColor br = null;

		// Token: 0x040021CA RID: 8650
		private static CmykColor bs = null;

		// Token: 0x040021CB RID: 8651
		private static CmykColor bt = null;

		// Token: 0x040021CC RID: 8652
		private static CmykColor bu = null;

		// Token: 0x040021CD RID: 8653
		private static CmykColor bv = null;

		// Token: 0x040021CE RID: 8654
		private static CmykColor bw = null;

		// Token: 0x040021CF RID: 8655
		private static CmykColor bx = null;

		// Token: 0x040021D0 RID: 8656
		private static CmykColor by = null;

		// Token: 0x040021D1 RID: 8657
		private static CmykColor bz = null;

		// Token: 0x040021D2 RID: 8658
		private static CmykColor b0 = null;

		// Token: 0x040021D3 RID: 8659
		private static CmykColor b1 = null;

		// Token: 0x040021D4 RID: 8660
		private static CmykColor b2 = null;

		// Token: 0x040021D5 RID: 8661
		private static CmykColor b3 = null;

		// Token: 0x040021D6 RID: 8662
		private static CmykColor b4 = null;

		// Token: 0x040021D7 RID: 8663
		private static CmykColor b5 = null;

		// Token: 0x040021D8 RID: 8664
		private static CmykColor b6 = null;

		// Token: 0x040021D9 RID: 8665
		private static CmykColor b7 = null;

		// Token: 0x040021DA RID: 8666
		private static CmykColor b8 = null;

		// Token: 0x040021DB RID: 8667
		private static CmykColor b9 = null;

		// Token: 0x040021DC RID: 8668
		private static CmykColor ca = null;

		// Token: 0x040021DD RID: 8669
		private static CmykColor cb = null;

		// Token: 0x040021DE RID: 8670
		private static CmykColor cc = null;

		// Token: 0x040021DF RID: 8671
		private static CmykColor cd = null;

		// Token: 0x040021E0 RID: 8672
		private static CmykColor ce = null;

		// Token: 0x040021E1 RID: 8673
		private static CmykColor cf = null;

		// Token: 0x040021E2 RID: 8674
		private static CmykColor cg = null;

		// Token: 0x040021E3 RID: 8675
		private static CmykColor ch = null;

		// Token: 0x040021E4 RID: 8676
		private static CmykColor ci = null;

		// Token: 0x040021E5 RID: 8677
		private static CmykColor cj = null;

		// Token: 0x040021E6 RID: 8678
		private static CmykColor ck = null;

		// Token: 0x040021E7 RID: 8679
		private static CmykColor cl = null;

		// Token: 0x040021E8 RID: 8680
		private static CmykColor cm = null;

		// Token: 0x040021E9 RID: 8681
		private static CmykColor cn = null;

		// Token: 0x040021EA RID: 8682
		private static CmykColor co = null;

		// Token: 0x040021EB RID: 8683
		private static CmykColor cp = null;

		// Token: 0x040021EC RID: 8684
		private static CmykColor cq = null;

		// Token: 0x040021ED RID: 8685
		private static CmykColor cr = null;

		// Token: 0x040021EE RID: 8686
		private static CmykColor cs = null;

		// Token: 0x040021EF RID: 8687
		private static CmykColor ct = null;

		// Token: 0x040021F0 RID: 8688
		private static CmykColor cu = null;

		// Token: 0x040021F1 RID: 8689
		private static CmykColor cv = null;

		// Token: 0x040021F2 RID: 8690
		private static CmykColor cw = null;

		// Token: 0x040021F3 RID: 8691
		private static CmykColor cx = null;

		// Token: 0x040021F4 RID: 8692
		private static CmykColor cy = null;

		// Token: 0x040021F5 RID: 8693
		private static CmykColor cz = null;

		// Token: 0x040021F6 RID: 8694
		private static CmykColor c0 = null;

		// Token: 0x040021F7 RID: 8695
		private static CmykColor c1 = null;

		// Token: 0x040021F8 RID: 8696
		private static CmykColor c2 = null;

		// Token: 0x040021F9 RID: 8697
		private static CmykColor c3 = null;

		// Token: 0x040021FA RID: 8698
		private static CmykColor c4 = null;

		// Token: 0x040021FB RID: 8699
		private static CmykColor c5 = null;

		// Token: 0x040021FC RID: 8700
		private static CmykColor c6 = null;

		// Token: 0x040021FD RID: 8701
		private static CmykColor c7 = null;

		// Token: 0x040021FE RID: 8702
		private static CmykColor c8 = null;

		// Token: 0x040021FF RID: 8703
		private static CmykColor c9 = null;

		// Token: 0x04002200 RID: 8704
		private static CmykColor da = null;

		// Token: 0x04002201 RID: 8705
		private static CmykColor db = null;

		// Token: 0x04002202 RID: 8706
		private static CmykColor dc = null;

		// Token: 0x04002203 RID: 8707
		private static CmykColor dd = null;

		// Token: 0x04002204 RID: 8708
		private static CmykColor de = null;

		// Token: 0x04002205 RID: 8709
		private static CmykColor df = null;

		// Token: 0x04002206 RID: 8710
		private static CmykColor dg = null;

		// Token: 0x04002207 RID: 8711
		private static CmykColor dh = null;

		// Token: 0x04002208 RID: 8712
		private static CmykColor di = null;

		// Token: 0x04002209 RID: 8713
		private static CmykColor dj = null;

		// Token: 0x0400220A RID: 8714
		private static CmykColor dk = null;

		// Token: 0x0400220B RID: 8715
		private static CmykColor dl = null;

		// Token: 0x0400220C RID: 8716
		private static CmykColor dm = null;
	}
}
