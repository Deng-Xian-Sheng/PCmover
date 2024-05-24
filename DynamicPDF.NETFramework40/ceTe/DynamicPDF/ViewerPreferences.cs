using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006BA RID: 1722
	public class ViewerPreferences
	{
		// Token: 0x0600425F RID: 16991 RVA: 0x00228D20 File Offset: 0x00227D20
		internal ViewerPreferences()
		{
		}

		// Token: 0x06004260 RID: 16992 RVA: 0x00228DBC File Offset: 0x00227DBC
		public void Draw(DocumentWriter writer)
		{
			if (this.b)
			{
				writer.WriteName(ViewerPreferences.t);
				writer.WriteDictionaryOpen();
				if (this.c)
				{
					writer.WriteName(ViewerPreferences.u);
					writer.WriteBoolean(true);
				}
				if (this.d)
				{
					writer.WriteName(ViewerPreferences.v);
					writer.WriteBoolean(true);
				}
				if (this.e)
				{
					writer.WriteName(ViewerPreferences.w);
					writer.WriteBoolean(true);
				}
				if (this.f)
				{
					writer.WriteName(ViewerPreferences.x);
					writer.WriteBoolean(true);
				}
				if (this.g)
				{
					writer.WriteName(ViewerPreferences.y);
					writer.WriteBoolean(true);
				}
				if (this.h)
				{
					writer.WriteName(ViewerPreferences.z);
					writer.WriteBoolean(true);
				}
				if (writer.Document.InitialPageMode == PageMode.FullScreen && this.i != NonFullScreenPageMode.ShowNone)
				{
					writer.WriteName(ViewerPreferences.aa);
					switch (this.i)
					{
					case NonFullScreenPageMode.ShowOutlines:
						writer.WriteName(ViewerPreferences.ac);
						break;
					case NonFullScreenPageMode.ShowThumbnails:
						writer.WriteName(ViewerPreferences.ad);
						break;
					case NonFullScreenPageMode.ShowOptionalContent:
						writer.WriteName(ViewerPreferences.ae);
						break;
					}
				}
				if (this.j)
				{
					writer.WriteName(ViewerPreferences.af);
					writer.WriteName(ViewerPreferences.ag);
				}
				if (this.k != PageBoundary.CropBox)
				{
					writer.WriteName(ViewerPreferences.ah);
					this.a(this.k, writer);
				}
				if (this.l != PageBoundary.CropBox)
				{
					writer.WriteName(ViewerPreferences.ai);
					this.a(this.l, writer);
				}
				if (this.m != PageBoundary.CropBox)
				{
					writer.WriteName(ViewerPreferences.aj);
					this.a(this.m, writer);
				}
				if (this.n != PageBoundary.CropBox)
				{
					writer.WriteName(ViewerPreferences.ak);
					this.a(this.n, writer);
				}
				if (this.o)
				{
					writer.WriteName(ViewerPreferences.al);
					writer.WriteName(ViewerPreferences.aq);
				}
				if (this.p != Duplex.None)
				{
					writer.WriteName(ViewerPreferences.ar);
					switch (this.p)
					{
					case Duplex.Simplex:
						writer.WriteName(ViewerPreferences.@as);
						break;
					case Duplex.DuplexFlipShortEdge:
						writer.WriteName(ViewerPreferences.at);
						break;
					case Duplex.DuplexFlipLongEdge:
						writer.WriteName(ViewerPreferences.au);
						break;
					}
				}
				if (this.q != PickTrayByPdfSize.ViewerDefault)
				{
					writer.WriteName(ViewerPreferences.av);
					writer.WriteBoolean(this.q == PickTrayByPdfSize.Yes);
				}
				if (this.s != null)
				{
					writer.WriteName(ViewerPreferences.aw);
					writer.WriteArrayOpen();
					for (int i = 0; i < this.s.Length; i++)
					{
						writer.WriteNumber(this.s[i]);
					}
					writer.WriteArrayClose();
				}
				if (this.r != 1)
				{
					writer.WriteName(ViewerPreferences.ax);
					writer.WriteNumber(this.r);
				}
				if (this.a != null)
				{
					this.a.b(writer);
				}
				writer.WriteDictionaryClose();
			}
		}

		// Token: 0x06004261 RID: 16993 RVA: 0x00229150 File Offset: 0x00228150
		private void a(PageBoundary A_0, DocumentWriter A_1)
		{
			switch (A_0)
			{
			case PageBoundary.MediaBox:
				A_1.WriteName(ViewerPreferences.am);
				break;
			case PageBoundary.BleedBox:
				A_1.WriteName(ViewerPreferences.an);
				break;
			case PageBoundary.TrimBox:
				A_1.WriteName(ViewerPreferences.ao);
				break;
			case PageBoundary.ArtBox:
				A_1.WriteName(ViewerPreferences.ap);
				break;
			}
		}

		// Token: 0x06004262 RID: 16994 RVA: 0x002291B4 File Offset: 0x002281B4
		internal void a(abj A_0)
		{
			this.a = A_0;
			this.b = true;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 281916117)
				{
					if (num <= 81201949)
					{
						if (num <= 54823738)
						{
							if (num != 13241091)
							{
								if (num == 54823738)
								{
									abk.a(false);
									this.o = (((abu)abk.c()).j8() == 3865509);
								}
							}
							else
							{
								abk.a(false);
								abe abe;
								if (abk.c().hy() == ag9.j)
								{
									abe = (abe)abk.c().h6();
								}
								else
								{
									abe = (abe)abk.c();
								}
								this.s = new int[abe.a()];
								for (int i = 0; i < abe.a(); i++)
								{
									this.s[i] = ((abw)abe.a(i)).kd();
								}
							}
						}
						else if (num != 74822285)
						{
							if (num == 81201949)
							{
								abk.a(false);
								this.p = this.a((abu)abk.c());
							}
						}
						else
						{
							abk.a(false);
							this.j = (((abu)abk.c()).j8() == 76940);
						}
					}
					else if (num <= 236210588)
					{
						if (num != 102567454)
						{
							if (num == 236210588)
							{
								abk.a(false);
								this.r = ((abw)abk.c()).kd();
							}
						}
						else
						{
							abk.a(false);
							this.f = ((abf)abk.c()).a();
						}
					}
					else if (num != 281301444)
					{
						if (num == 281916117)
						{
							abk.a(false);
							this.m = this.c((abu)abk.c());
						}
					}
					else
					{
						abk.a(false);
						this.n = this.c((abu)abk.c());
					}
				}
				else if (num <= 555485161)
				{
					if (num <= 379942048)
					{
						if (num != 379885491)
						{
							if (num == 379942048)
							{
								abk.a(false);
								this.k = this.c((abu)abk.c());
							}
						}
						else
						{
							abk.a(false);
							this.l = this.c((abu)abk.c());
						}
					}
					else if (num != 537781927)
					{
						if (num == 555485161)
						{
							abk.a(false);
							this.e = ((abf)abk.c()).a();
						}
					}
					else
					{
						abk.a(false);
						this.i = this.b((abu)abk.c());
					}
				}
				else if (num <= 756879838)
				{
					if (num != 655917511)
					{
						if (num == 756879838)
						{
							abk.a(false);
							this.d = ((abf)abk.c()).a();
						}
					}
					else
					{
						abk.a(false);
						this.c = ((abf)abk.c()).a();
					}
				}
				else if (num != 835222902)
				{
					if (num != 837041386)
					{
						if (num == 842121249)
						{
							abk.a(false);
							if (((abf)abk.c()).a())
							{
								this.q = PickTrayByPdfSize.Yes;
							}
							else
							{
								this.q = PickTrayByPdfSize.No;
							}
						}
					}
					else
					{
						abk.a(false);
						abd abd = abk.c().h6();
						this.h = ((abf)abd).a();
					}
				}
				else
				{
					abk.a(false);
					this.g = ((abf)abk.c()).a();
				}
			}
		}

		// Token: 0x06004263 RID: 16995 RVA: 0x0022961C File Offset: 0x0022861C
		private PageBoundary c(abu A_0)
		{
			int num = A_0.j8();
			if (num <= 45249180)
			{
				if (num == 30097559)
				{
					return PageBoundary.ArtBox;
				}
				if (num == 45249180)
				{
					return PageBoundary.BleedBox;
				}
			}
			else
			{
				if (num == 63633402)
				{
					return PageBoundary.CropBox;
				}
				if (num == 227959193)
				{
					return PageBoundary.MediaBox;
				}
				if (num == 348819642)
				{
					return PageBoundary.TrimBox;
				}
			}
			return PageBoundary.CropBox;
		}

		// Token: 0x06004264 RID: 16996 RVA: 0x00229680 File Offset: 0x00228680
		private NonFullScreenPageMode b(abu A_0)
		{
			int num = A_0.j8();
			if (num <= 365843395)
			{
				if (num == 353930651)
				{
					return NonFullScreenPageMode.ShowThumbnails;
				}
				if (num == 365843395)
				{
					return NonFullScreenPageMode.ShowOptionalContent;
				}
			}
			else
			{
				if (num == 365844490)
				{
					return NonFullScreenPageMode.ShowNone;
				}
				if (num == 561825891)
				{
					return NonFullScreenPageMode.ShowOutlines;
				}
			}
			return NonFullScreenPageMode.ShowNone;
		}

		// Token: 0x06004265 RID: 16997 RVA: 0x002296D8 File Offset: 0x002286D8
		private Duplex a(abu A_0)
		{
			int num = A_0.j8();
			Duplex result;
			if (num != 329700692)
			{
				if (num != 796488708)
				{
					if (num != 812736885)
					{
						result = Duplex.None;
					}
					else
					{
						result = Duplex.DuplexFlipLongEdge;
					}
				}
				else
				{
					result = Duplex.DuplexFlipShortEdge;
				}
			}
			else
			{
				result = Duplex.Simplex;
			}
			return result;
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06004266 RID: 16998 RVA: 0x00229718 File Offset: 0x00228718
		// (set) Token: 0x06004267 RID: 16999 RVA: 0x00229730 File Offset: 0x00228730
		public bool HideToolbar
		{
			get
			{
				return this.c;
			}
			set
			{
				this.b = true;
				this.c = value;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06004268 RID: 17000 RVA: 0x00229744 File Offset: 0x00228744
		// (set) Token: 0x06004269 RID: 17001 RVA: 0x0022975C File Offset: 0x0022875C
		public bool HideMenubar
		{
			get
			{
				return this.d;
			}
			set
			{
				this.b = true;
				this.d = value;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x0600426A RID: 17002 RVA: 0x00229770 File Offset: 0x00228770
		// (set) Token: 0x0600426B RID: 17003 RVA: 0x00229788 File Offset: 0x00228788
		public bool HideWindowUI
		{
			get
			{
				return this.e;
			}
			set
			{
				this.b = true;
				this.e = value;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x0600426C RID: 17004 RVA: 0x0022979C File Offset: 0x0022879C
		// (set) Token: 0x0600426D RID: 17005 RVA: 0x002297B4 File Offset: 0x002287B4
		public bool FitWindow
		{
			get
			{
				return this.f;
			}
			set
			{
				this.b = true;
				this.f = value;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x0600426E RID: 17006 RVA: 0x002297C8 File Offset: 0x002287C8
		// (set) Token: 0x0600426F RID: 17007 RVA: 0x002297E0 File Offset: 0x002287E0
		public bool CenterWindow
		{
			get
			{
				return this.g;
			}
			set
			{
				this.b = true;
				this.g = value;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06004270 RID: 17008 RVA: 0x002297F4 File Offset: 0x002287F4
		// (set) Token: 0x06004271 RID: 17009 RVA: 0x0022980C File Offset: 0x0022880C
		public bool DisplayDocTitle
		{
			get
			{
				return this.h;
			}
			set
			{
				this.b = true;
				this.h = value;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06004272 RID: 17010 RVA: 0x00229820 File Offset: 0x00228820
		// (set) Token: 0x06004273 RID: 17011 RVA: 0x00229838 File Offset: 0x00228838
		public NonFullScreenPageMode NonFullScreenPageMode
		{
			get
			{
				return this.i;
			}
			set
			{
				this.b = true;
				this.i = value;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06004274 RID: 17012 RVA: 0x0022984C File Offset: 0x0022884C
		// (set) Token: 0x06004275 RID: 17013 RVA: 0x00229864 File Offset: 0x00228864
		public bool RightToLeft
		{
			get
			{
				return this.j;
			}
			set
			{
				this.b = true;
				this.j = value;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06004276 RID: 17014 RVA: 0x00229878 File Offset: 0x00228878
		// (set) Token: 0x06004277 RID: 17015 RVA: 0x00229890 File Offset: 0x00228890
		public PageBoundary ViewArea
		{
			get
			{
				return this.k;
			}
			set
			{
				this.b = true;
				this.k = value;
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06004278 RID: 17016 RVA: 0x002298A4 File Offset: 0x002288A4
		// (set) Token: 0x06004279 RID: 17017 RVA: 0x002298BC File Offset: 0x002288BC
		public PageBoundary ViewClip
		{
			get
			{
				return this.l;
			}
			set
			{
				this.b = true;
				this.l = value;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x0600427A RID: 17018 RVA: 0x002298D0 File Offset: 0x002288D0
		// (set) Token: 0x0600427B RID: 17019 RVA: 0x002298E8 File Offset: 0x002288E8
		public PageBoundary PrintArea
		{
			get
			{
				return this.m;
			}
			set
			{
				this.b = true;
				this.m = value;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x0600427C RID: 17020 RVA: 0x002298FC File Offset: 0x002288FC
		// (set) Token: 0x0600427D RID: 17021 RVA: 0x00229914 File Offset: 0x00228914
		public PageBoundary PrintClip
		{
			get
			{
				return this.n;
			}
			set
			{
				this.b = true;
				this.n = value;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x0600427E RID: 17022 RVA: 0x00229928 File Offset: 0x00228928
		// (set) Token: 0x0600427F RID: 17023 RVA: 0x00229940 File Offset: 0x00228940
		public bool NoPrintScaling
		{
			get
			{
				return this.o;
			}
			set
			{
				this.b = true;
				this.o = value;
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06004280 RID: 17024 RVA: 0x00229954 File Offset: 0x00228954
		// (set) Token: 0x06004281 RID: 17025 RVA: 0x0022996C File Offset: 0x0022896C
		public Duplex Duplex
		{
			get
			{
				return this.p;
			}
			set
			{
				this.b = true;
				this.p = value;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06004282 RID: 17026 RVA: 0x00229980 File Offset: 0x00228980
		// (set) Token: 0x06004283 RID: 17027 RVA: 0x00229998 File Offset: 0x00228998
		public int[] PrintPageRange
		{
			get
			{
				return this.s;
			}
			set
			{
				this.b = true;
				this.s = value;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06004284 RID: 17028 RVA: 0x002299AC File Offset: 0x002289AC
		// (set) Token: 0x06004285 RID: 17029 RVA: 0x002299C4 File Offset: 0x002289C4
		public PickTrayByPdfSize PickTrayByPdfSize
		{
			get
			{
				return this.q;
			}
			set
			{
				this.b = true;
				this.q = value;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06004286 RID: 17030 RVA: 0x002299D8 File Offset: 0x002289D8
		// (set) Token: 0x06004287 RID: 17031 RVA: 0x002299F0 File Offset: 0x002289F0
		public int NumberOfCopies
		{
			get
			{
				return this.r;
			}
			set
			{
				this.b = true;
				this.r = value;
			}
		}

		// Token: 0x040024D3 RID: 9427
		private abj a = null;

		// Token: 0x040024D4 RID: 9428
		private bool b = false;

		// Token: 0x040024D5 RID: 9429
		private bool c = false;

		// Token: 0x040024D6 RID: 9430
		private bool d = false;

		// Token: 0x040024D7 RID: 9431
		private bool e = false;

		// Token: 0x040024D8 RID: 9432
		private bool f = false;

		// Token: 0x040024D9 RID: 9433
		private bool g = false;

		// Token: 0x040024DA RID: 9434
		private bool h = false;

		// Token: 0x040024DB RID: 9435
		private NonFullScreenPageMode i = NonFullScreenPageMode.ShowNone;

		// Token: 0x040024DC RID: 9436
		private bool j = false;

		// Token: 0x040024DD RID: 9437
		private PageBoundary k = PageBoundary.CropBox;

		// Token: 0x040024DE RID: 9438
		private PageBoundary l = PageBoundary.CropBox;

		// Token: 0x040024DF RID: 9439
		private PageBoundary m = PageBoundary.CropBox;

		// Token: 0x040024E0 RID: 9440
		private PageBoundary n = PageBoundary.CropBox;

		// Token: 0x040024E1 RID: 9441
		private bool o = false;

		// Token: 0x040024E2 RID: 9442
		private Duplex p = Duplex.None;

		// Token: 0x040024E3 RID: 9443
		private PickTrayByPdfSize q = PickTrayByPdfSize.ViewerDefault;

		// Token: 0x040024E4 RID: 9444
		private int r = 1;

		// Token: 0x040024E5 RID: 9445
		private int[] s = null;

		// Token: 0x040024E6 RID: 9446
		private static byte[] t = new byte[]
		{
			86,
			105,
			101,
			119,
			101,
			114,
			80,
			114,
			101,
			102,
			101,
			114,
			101,
			110,
			99,
			101,
			115
		};

		// Token: 0x040024E7 RID: 9447
		private static byte[] u = new byte[]
		{
			72,
			105,
			100,
			101,
			84,
			111,
			111,
			108,
			98,
			97,
			114
		};

		// Token: 0x040024E8 RID: 9448
		private static byte[] v = new byte[]
		{
			72,
			105,
			100,
			101,
			77,
			101,
			110,
			117,
			98,
			97,
			114
		};

		// Token: 0x040024E9 RID: 9449
		private static byte[] w = new byte[]
		{
			72,
			105,
			100,
			101,
			87,
			105,
			110,
			100,
			111,
			119,
			85,
			73
		};

		// Token: 0x040024EA RID: 9450
		private static byte[] x = new byte[]
		{
			70,
			105,
			116,
			87,
			105,
			110,
			100,
			111,
			119
		};

		// Token: 0x040024EB RID: 9451
		private static byte[] y = new byte[]
		{
			67,
			101,
			110,
			116,
			101,
			114,
			87,
			105,
			110,
			100,
			111,
			119
		};

		// Token: 0x040024EC RID: 9452
		private static byte[] z = new byte[]
		{
			68,
			105,
			115,
			112,
			108,
			97,
			121,
			68,
			111,
			99,
			84,
			105,
			116,
			108,
			101
		};

		// Token: 0x040024ED RID: 9453
		private static byte[] aa = new byte[]
		{
			78,
			111,
			110,
			70,
			117,
			108,
			108,
			83,
			99,
			114,
			101,
			101,
			110,
			80,
			97,
			103,
			101,
			77,
			111,
			100,
			101
		};

		// Token: 0x040024EE RID: 9454
		private static byte[] ab = new byte[]
		{
			85,
			115,
			101,
			78,
			111,
			110,
			101
		};

		// Token: 0x040024EF RID: 9455
		private static byte[] ac = new byte[]
		{
			85,
			115,
			101,
			79,
			117,
			116,
			108,
			105,
			110,
			101,
			115
		};

		// Token: 0x040024F0 RID: 9456
		private static byte[] ad = new byte[]
		{
			85,
			115,
			101,
			84,
			104,
			117,
			109,
			98,
			115
		};

		// Token: 0x040024F1 RID: 9457
		private static byte[] ae = new byte[]
		{
			85,
			115,
			101,
			79,
			67
		};

		// Token: 0x040024F2 RID: 9458
		private static byte[] af = new byte[]
		{
			68,
			105,
			114,
			101,
			99,
			116,
			105,
			111,
			110
		};

		// Token: 0x040024F3 RID: 9459
		private static byte[] ag = new byte[]
		{
			82,
			50,
			76
		};

		// Token: 0x040024F4 RID: 9460
		private static byte[] ah = new byte[]
		{
			86,
			105,
			101,
			119,
			65,
			114,
			101,
			97
		};

		// Token: 0x040024F5 RID: 9461
		private static byte[] ai = new byte[]
		{
			86,
			105,
			101,
			119,
			67,
			108,
			105,
			112
		};

		// Token: 0x040024F6 RID: 9462
		private static byte[] aj = new byte[]
		{
			80,
			114,
			105,
			110,
			116,
			65,
			114,
			101,
			97
		};

		// Token: 0x040024F7 RID: 9463
		private static byte[] ak = new byte[]
		{
			80,
			114,
			105,
			110,
			116,
			67,
			108,
			105,
			112
		};

		// Token: 0x040024F8 RID: 9464
		private static byte[] al = new byte[]
		{
			80,
			114,
			105,
			110,
			116,
			83,
			99,
			97,
			108,
			105,
			110,
			103
		};

		// Token: 0x040024F9 RID: 9465
		private static byte[] am = new byte[]
		{
			77,
			101,
			100,
			105,
			97,
			66,
			111,
			120
		};

		// Token: 0x040024FA RID: 9466
		private static byte[] an = new byte[]
		{
			66,
			108,
			101,
			101,
			100,
			66,
			111,
			120
		};

		// Token: 0x040024FB RID: 9467
		private static byte[] ao = new byte[]
		{
			84,
			114,
			105,
			109,
			66,
			111,
			120
		};

		// Token: 0x040024FC RID: 9468
		private static byte[] ap = new byte[]
		{
			65,
			114,
			116,
			66,
			111,
			120
		};

		// Token: 0x040024FD RID: 9469
		private static byte[] aq = new byte[]
		{
			78,
			111,
			110,
			101
		};

		// Token: 0x040024FE RID: 9470
		private static byte[] ar = new byte[]
		{
			68,
			117,
			112,
			108,
			101,
			120
		};

		// Token: 0x040024FF RID: 9471
		private static byte[] @as = new byte[]
		{
			83,
			105,
			109,
			112,
			108,
			101,
			120
		};

		// Token: 0x04002500 RID: 9472
		private static byte[] at = new byte[]
		{
			68,
			117,
			112,
			108,
			101,
			120,
			70,
			108,
			105,
			112,
			83,
			104,
			111,
			114,
			116,
			69,
			100,
			103,
			101
		};

		// Token: 0x04002501 RID: 9473
		private static byte[] au = new byte[]
		{
			68,
			117,
			112,
			108,
			101,
			120,
			70,
			108,
			105,
			112,
			76,
			111,
			110,
			103,
			69,
			100,
			103,
			101
		};

		// Token: 0x04002502 RID: 9474
		private static byte[] av = new byte[]
		{
			80,
			105,
			99,
			107,
			84,
			114,
			97,
			121,
			66,
			121,
			80,
			68,
			70,
			83,
			105,
			122,
			101
		};

		// Token: 0x04002503 RID: 9475
		private static byte[] aw = new byte[]
		{
			80,
			114,
			105,
			110,
			116,
			80,
			97,
			103,
			101,
			82,
			97,
			110,
			103,
			101
		};

		// Token: 0x04002504 RID: 9476
		private static byte[] ax = new byte[]
		{
			78,
			117,
			109,
			67,
			111,
			112,
			105,
			101,
			115
		};
	}
}
