using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200008A RID: 138
	public abstract class Font : Resource
	{
		// Token: 0x0600065A RID: 1626 RVA: 0x0005C815 File Offset: 0x0005B815
		protected Font(Encoder encoder, long uid) : base(uid)
		{
			this.ax = encoder;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0005C833 File Offset: 0x0005B833
		protected Font(Encoder encoder) : this(encoder, Resource.NewUid())
		{
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0005C844 File Offset: 0x0005B844
		internal virtual string bg()
		{
			return this.FormFontName;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0005C85C File Offset: 0x0005B85C
		internal virtual bool bk()
		{
			return false;
		}

		// Token: 0x0600065E RID: 1630
		internal abstract short bh();

		// Token: 0x0600065F RID: 1631
		internal abstract short bi();

		// Token: 0x06000660 RID: 1632 RVA: 0x0005C86F File Offset: 0x0005B86F
		internal virtual void bj(DocumentWriter A_0)
		{
			A_0.WriteReference(this);
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x0005C87C File Offset: 0x0005B87C
		public virtual string FormFontName
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000662 RID: 1634
		public abstract short Descender { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000663 RID: 1635
		public abstract short Ascender { get; }

		// Token: 0x06000664 RID: 1636
		internal abstract short bc();

		// Token: 0x06000665 RID: 1637
		internal abstract short bd();

		// Token: 0x06000666 RID: 1638
		internal abstract short be();

		// Token: 0x06000667 RID: 1639
		internal abstract short bf();

		// Token: 0x06000668 RID: 1640 RVA: 0x0005C894 File Offset: 0x0005B894
		internal virtual short jg()
		{
			return 0;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0005C8A8 File Offset: 0x0005B8A8
		internal virtual short jh()
		{
			return 0;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0005C8BC File Offset: 0x0005B8BC
		internal virtual short ji()
		{
			return 0;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0005C8D0 File Offset: 0x0005B8D0
		internal virtual short jj()
		{
			return 0;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0005C8E4 File Offset: 0x0005B8E4
		internal virtual short jk()
		{
			return 0;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0005C8F8 File Offset: 0x0005B8F8
		internal virtual short jl()
		{
			return 0;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0005C90C File Offset: 0x0005B90C
		internal virtual short jm()
		{
			return 0;
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0005C920 File Offset: 0x0005B920
		internal virtual short jn()
		{
			return 0;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x0005C934 File Offset: 0x0005B934
		public virtual short LineGap
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000671 RID: 1649
		public abstract LineBreaker LineBreaker { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0005C948 File Offset: 0x0005B948
		public Encoder Encoder
		{
			get
			{
				return this.ax;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000673 RID: 1651
		public abstract string Name { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0005C960 File Offset: 0x0005B960
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.Font;
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0005C974 File Offset: 0x0005B974
		internal string j()
		{
			return this.ay;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0005C98C File Offset: 0x0005B98C
		internal new void d(string A_0)
		{
			this.ay = A_0;
		}

		// Token: 0x06000677 RID: 1655
		public abstract short GetGlyphWidth(char glyph);

		// Token: 0x06000678 RID: 1656 RVA: 0x0005C998 File Offset: 0x0005B998
		internal virtual short jf(agc A_0)
		{
			return 0;
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0005C9AC File Offset: 0x0005B9AC
		public TextLineList GetTextLines(char[] text, float width, float height, float fontSize)
		{
			return this.LineBreaker.GetLines(text, width, height, this, fontSize);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0005C9D0 File Offset: 0x0005B9D0
		internal new TextLineList a(char[] A_0, float A_1, float A_2, float A_3, float A_4)
		{
			return this.LineBreaker.jd(A_0, 0, A_0.Length, A_1, A_2, this, A_3, A_4);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0005C9FC File Offset: 0x0005B9FC
		public TextLineList GetTextLines(char[] text, float width, float fontSize)
		{
			return this.LineBreaker.GetLines(text, width, this, fontSize);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0005CA20 File Offset: 0x0005BA20
		internal new TextLineList a(TextLineList A_0)
		{
			return this.LineBreaker.je(A_0);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0005CA40 File Offset: 0x0005BA40
		internal new TextLineList b(TextLineList A_0)
		{
			return this.LineBreaker.a(A_0);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0005CA60 File Offset: 0x0005BA60
		internal new float a(char[] A_0, int A_1, int A_2, float A_3)
		{
			float num = 0f;
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				num += (float)this.GetGlyphWidth(A_0[i]);
			}
			return num * A_3 / 1000f + 0.001f;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0005CAAC File Offset: 0x0005BAAC
		public float GetTextWidth(char[] text, float fontSize)
		{
			float num = 0f;
			foreach (char glyph in text)
			{
				num += (float)this.GetGlyphWidth(glyph);
			}
			return num * fontSize / 1000f + 0.001f;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0005CB00 File Offset: 0x0005BB00
		public float GetTextWidth(string text, float fontSize)
		{
			return this.GetTextWidth(text.ToCharArray(), fontSize);
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0005CB20 File Offset: 0x0005BB20
		public virtual float GetDescender(float fontSize)
		{
			return (float)this.Descender * fontSize / 1000f;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0005CB44 File Offset: 0x0005BB44
		public virtual float GetAscender(float fontSize)
		{
			return (float)this.Ascender * fontSize / 1000f;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0005CB68 File Offset: 0x0005BB68
		public virtual float GetLineGap(float fontSize)
		{
			return (float)this.LineGap * fontSize / 1000f;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0005CB8C File Offset: 0x0005BB8C
		public virtual float GetDefaultLeading(float fontSize)
		{
			return (float)(this.Ascender - this.Descender + this.LineGap) * fontSize / 1000f;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0005CBBC File Offset: 0x0005BBBC
		public virtual float GetBaseLine(float fontSize, float leading)
		{
			return leading - this.GetDefaultLeading(fontSize) + this.GetAscender(fontSize);
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0005CBE0 File Offset: 0x0005BBE0
		public virtual bool HasKerning()
		{
			return false;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0005CBF4 File Offset: 0x0005BBF4
		internal new virtual float a(float A_0)
		{
			return (float)this.bc() * A_0 / 1000f;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0005CC18 File Offset: 0x0005BC18
		internal new virtual float b(float A_0)
		{
			return (float)this.bd() * A_0 / 1000f;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0005CC3C File Offset: 0x0005BC3C
		internal new virtual float c(float A_0)
		{
			return (float)this.be() * A_0 / 1000f;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0005CC60 File Offset: 0x0005BC60
		internal new virtual float d(float A_0)
		{
			return (float)this.bf() * A_0 / 1000f;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0005CC84 File Offset: 0x0005BC84
		public virtual float GetKernValue(char left, char right)
		{
			return 0f;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x0005CC9C File Offset: 0x0005BC9C
		public static Font TimesRoman
		{
			get
			{
				if (Font.ab == null)
				{
					Font.ab = new TimesRoman(Encoder.Latin1);
				}
				return Font.ab;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0005CCD4 File Offset: 0x0005BCD4
		public static Font TimesBold
		{
			get
			{
				if (Font.ac == null)
				{
					Font.ac = new TimesBold(Encoder.Latin1);
				}
				return Font.ac;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x0005CD0C File Offset: 0x0005BD0C
		public static Font TimesItalic
		{
			get
			{
				if (Font.ad == null)
				{
					Font.ad = new TimesItalic(Encoder.Latin1);
				}
				return Font.ad;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x0005CD44 File Offset: 0x0005BD44
		public static Font TimesBoldItalic
		{
			get
			{
				if (Font.ae == null)
				{
					Font.ae = new TimesBoldItalic(Encoder.Latin1);
				}
				return Font.ae;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x0005CD7C File Offset: 0x0005BD7C
		public static Font Helvetica
		{
			get
			{
				if (Font.af == null)
				{
					Font.af = new Helvetica(Encoder.Latin1);
				}
				return Font.af;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0005CDB4 File Offset: 0x0005BDB4
		public static Font HelveticaBold
		{
			get
			{
				if (Font.ag == null)
				{
					Font.ag = new HelveticaBold(Encoder.Latin1);
				}
				return Font.ag;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x0005CDEC File Offset: 0x0005BDEC
		public static Font HelveticaOblique
		{
			get
			{
				if (Font.ah == null)
				{
					Font.ah = new HelveticaOblique(Encoder.Latin1);
				}
				return Font.ah;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0005CE24 File Offset: 0x0005BE24
		public static Font HelveticaBoldOblique
		{
			get
			{
				if (Font.ai == null)
				{
					Font.ai = new HelveticaBoldOblique(Encoder.Latin1);
				}
				return Font.ai;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x0005CE5C File Offset: 0x0005BE5C
		public static Font Courier
		{
			get
			{
				if (Font.aj == null)
				{
					Font.aj = new Courier(Encoder.Latin1);
				}
				return Font.aj;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0005CE94 File Offset: 0x0005BE94
		public static Font CourierBold
		{
			get
			{
				if (Font.ak == null)
				{
					Font.ak = new CourierBold(Encoder.Latin1);
				}
				return Font.ak;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000696 RID: 1686 RVA: 0x0005CECC File Offset: 0x0005BECC
		public static Font CourierOblique
		{
			get
			{
				if (Font.al == null)
				{
					Font.al = new CourierOblique(Encoder.Latin1);
				}
				return Font.al;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0005CF04 File Offset: 0x0005BF04
		public static Font CourierBoldOblique
		{
			get
			{
				if (Font.am == null)
				{
					Font.am = new CourierBoldOblique(Encoder.Latin1);
				}
				return Font.am;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x0005CF3C File Offset: 0x0005BF3C
		public static Font Symbol
		{
			get
			{
				if (Font.an == null)
				{
					Font.an = new Symbol();
				}
				return Font.an;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x0005CF70 File Offset: 0x0005BF70
		public static Font ZapfDingbats
		{
			get
			{
				if (Font.ao == null)
				{
					Font.ao = new aee();
				}
				return Font.ao;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x0005CFA4 File Offset: 0x0005BFA4
		public static Font HeiseiKakuGothicW5
		{
			get
			{
				if (Font.ap == null)
				{
					Font.ap = new ac4();
				}
				return Font.ap;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0005CFD8 File Offset: 0x0005BFD8
		public static Font HeiseiMinchoW3
		{
			get
			{
				if (Font.aq == null)
				{
					Font.aq = new ac5();
				}
				return Font.aq;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0005D00C File Offset: 0x0005C00C
		public static Font HanyangSystemsGothicMedium
		{
			get
			{
				if (Font.ar == null)
				{
					Font.ar = new ac2();
				}
				return Font.ar;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0005D040 File Offset: 0x0005C040
		public static Font HanyangSystemsShinMyeongJoMedium
		{
			get
			{
				if (Font.@as == null)
				{
					Font.@as = new ac3();
				}
				return Font.@as;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0005D074 File Offset: 0x0005C074
		public static Font MonotypeHeiMedium
		{
			get
			{
				if (Font.at == null)
				{
					Font.at = new ada();
				}
				return Font.at;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x0005D0A8 File Offset: 0x0005C0A8
		public static Font MonotypeSungLight
		{
			get
			{
				if (Font.au == null)
				{
					Font.au = new adb();
				}
				return Font.au;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0005D0DC File Offset: 0x0005C0DC
		public static Font SinoTypeSongLight
		{
			get
			{
				if (Font.av == null)
				{
					Font.av = new aea();
				}
				return Font.av;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x0005D110 File Offset: 0x0005C110
		public static Font CeTeBullets
		{
			get
			{
				if (Font.aw == null)
				{
					Font.aw = new CeTeBullets();
				}
				return Font.aw;
			}
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0005D144 File Offset: 0x0005C144
		public static bool CanLoadSystemFont(Font font)
		{
			return r8.a(font.Name, font.Bold, font.Italic, false) != null;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0005D17C File Offset: 0x0005C17C
		[Obsolete("This method is obsolete. Use LoadSystemFont(string name) method instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool CanLoadSystemFont(string systemFontName)
		{
			return r8.a(systemFontName, false, false, false) != null;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0005D1A4 File Offset: 0x0005C1A4
		[SecurityCritical]
		public static Font LoadSystemFont(Font font)
		{
			string a_ = r3.a(font);
			return r8.c(a_, false);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0005D1C4 File Offset: 0x0005C1C4
		[SecurityCritical]
		public static Font LoadSystemFont(Font font, bool useCharacterShaping)
		{
			string a_ = r3.a(font);
			return r8.c(a_, useCharacterShaping);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0005D1E4 File Offset: 0x0005C1E4
		public static Font LoadSystemFont(string systemFontName)
		{
			return r8.a(systemFontName, false, false, false);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0005D200 File Offset: 0x0005C200
		public static Font LoadSystemFont(string systemFontName, bool useCharacterShaping)
		{
			return r8.a(systemFontName, false, false, useCharacterShaping);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0005D21B File Offset: 0x0005C21B
		internal new void a(Encoder A_0)
		{
			this.ax = A_0;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0005D228 File Offset: 0x0005C228
		internal virtual bool jo()
		{
			return false;
		}

		// Token: 0x0400035A RID: 858
		internal new static byte[] a = new byte[]
		{
			84,
			121,
			112,
			101,
			49
		};

		// Token: 0x0400035B RID: 859
		internal new static byte[] b = new byte[]
		{
			84,
			121,
			112,
			101,
			48
		};

		// Token: 0x0400035C RID: 860
		internal new static byte[] c = new byte[]
		{
			66,
			97,
			115,
			101,
			70,
			111,
			110,
			116
		};

		// Token: 0x0400035D RID: 861
		internal new static byte[] d = new byte[]
		{
			70,
			105,
			114,
			115,
			116,
			67,
			104,
			97,
			114
		};

		// Token: 0x0400035E RID: 862
		internal new static byte[] e = new byte[]
		{
			76,
			97,
			115,
			116,
			67,
			104,
			97,
			114
		};

		// Token: 0x0400035F RID: 863
		internal new static byte[] f = new byte[]
		{
			87,
			105,
			100,
			116,
			104,
			115
		};

		// Token: 0x04000360 RID: 864
		internal new static byte[] g = new byte[]
		{
			69,
			110,
			99,
			111,
			100,
			105,
			110,
			103
		};

		// Token: 0x04000361 RID: 865
		internal new static byte[] h = new byte[]
		{
			68,
			101,
			115,
			99,
			101,
			110,
			100,
			97,
			110,
			116,
			70,
			111,
			110,
			116,
			115
		};

		// Token: 0x04000362 RID: 866
		internal new static byte[] i = new byte[]
		{
			67,
			73,
			68,
			70,
			111,
			110,
			116,
			84,
			121,
			112,
			101,
			50
		};

		// Token: 0x04000363 RID: 867
		internal static byte[] j = new byte[]
		{
			67,
			73,
			68,
			70,
			111,
			110,
			116,
			84,
			121,
			112,
			101,
			48
		};

		// Token: 0x04000364 RID: 868
		internal static byte[] k = new byte[]
		{
			67,
			73,
			68,
			83,
			121,
			115,
			116,
			101,
			109,
			73,
			110,
			102,
			111
		};

		// Token: 0x04000365 RID: 869
		internal static byte[] l = new byte[]
		{
			82,
			101,
			103,
			105,
			115,
			116,
			114,
			121
		};

		// Token: 0x04000366 RID: 870
		internal static byte[] m = new byte[]
		{
			83,
			117,
			112,
			112,
			108,
			101,
			109,
			101,
			110,
			116
		};

		// Token: 0x04000367 RID: 871
		internal static byte[] n = new byte[]
		{
			70,
			111,
			110,
			116,
			68,
			101,
			115,
			99,
			114,
			105,
			112,
			116,
			111,
			114
		};

		// Token: 0x04000368 RID: 872
		internal static byte[] o = new byte[]
		{
			79,
			114,
			100,
			101,
			114,
			105,
			110,
			103
		};

		// Token: 0x04000369 RID: 873
		internal static byte[] p = new byte[]
		{
			70,
			111,
			110,
			116,
			66,
			66,
			111,
			120
		};

		// Token: 0x0400036A RID: 874
		internal static byte[] q = new byte[]
		{
			68,
			87
		};

		// Token: 0x0400036B RID: 875
		internal static byte[] r = new byte[]
		{
			70,
			111,
			110,
			116,
			78,
			97,
			109,
			101
		};

		// Token: 0x0400036C RID: 876
		internal static byte[] s = new byte[]
		{
			85,
			110,
			105,
			74,
			73,
			83,
			45,
			85,
			67,
			83,
			50,
			45,
			72
		};

		// Token: 0x0400036D RID: 877
		internal static byte[] t = new byte[]
		{
			83,
			116,
			101,
			109,
			86
		};

		// Token: 0x0400036E RID: 878
		internal static byte[] u = new byte[]
		{
			67,
			97,
			112,
			72,
			101,
			105,
			103,
			104,
			116
		};

		// Token: 0x0400036F RID: 879
		internal static byte[] v = new byte[]
		{
			65,
			115,
			99,
			101,
			110,
			116
		};

		// Token: 0x04000370 RID: 880
		internal static byte[] w = new byte[]
		{
			68,
			101,
			115,
			99,
			101,
			110,
			116
		};

		// Token: 0x04000371 RID: 881
		internal static byte[] x = new byte[]
		{
			73,
			116,
			97,
			108,
			105,
			99,
			65,
			110,
			103,
			108,
			101
		};

		// Token: 0x04000372 RID: 882
		internal static byte[] y = new byte[]
		{
			70,
			108,
			97,
			103,
			115
		};

		// Token: 0x04000373 RID: 883
		internal static byte[] z = new byte[]
		{
			67,
			73,
			68,
			84,
			111,
			71,
			73,
			68,
			77,
			97,
			112
		};

		// Token: 0x04000374 RID: 884
		internal static byte[] aa = new byte[]
		{
			67,
			73,
			68,
			83,
			101,
			116
		};

		// Token: 0x04000375 RID: 885
		private static Font ab = null;

		// Token: 0x04000376 RID: 886
		private static Font ac = null;

		// Token: 0x04000377 RID: 887
		private static Font ad = null;

		// Token: 0x04000378 RID: 888
		private static Font ae = null;

		// Token: 0x04000379 RID: 889
		private static Font af = null;

		// Token: 0x0400037A RID: 890
		private static Font ag = null;

		// Token: 0x0400037B RID: 891
		private static Font ah = null;

		// Token: 0x0400037C RID: 892
		private static Font ai = null;

		// Token: 0x0400037D RID: 893
		private static Font aj = null;

		// Token: 0x0400037E RID: 894
		private static Font ak = null;

		// Token: 0x0400037F RID: 895
		private static Font al = null;

		// Token: 0x04000380 RID: 896
		private static Font am = null;

		// Token: 0x04000381 RID: 897
		private static Font an = null;

		// Token: 0x04000382 RID: 898
		private static Font ao = null;

		// Token: 0x04000383 RID: 899
		private static Font ap = null;

		// Token: 0x04000384 RID: 900
		private static Font aq = null;

		// Token: 0x04000385 RID: 901
		private static Font ar = null;

		// Token: 0x04000386 RID: 902
		private static Font @as = null;

		// Token: 0x04000387 RID: 903
		private static Font at = null;

		// Token: 0x04000388 RID: 904
		private static Font au = null;

		// Token: 0x04000389 RID: 905
		private static Font av = null;

		// Token: 0x0400038A RID: 906
		private static Font aw = null;

		// Token: 0x0400038B RID: 907
		private Encoder ax;

		// Token: 0x0400038C RID: 908
		private string ay = string.Empty;
	}
}
