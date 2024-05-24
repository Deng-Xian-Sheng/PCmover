using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020003B7 RID: 951
	public class OutputIntent
	{
		// Token: 0x0600283A RID: 10298 RVA: 0x0017550F File Offset: 0x0017450F
		internal OutputIntent()
		{
			this.i = null;
			this.j = null;
			this.k = null;
			this.l = null;
			this.m = null;
		}

		// Token: 0x0600283B RID: 10299 RVA: 0x0017554B File Offset: 0x0017454B
		public OutputIntent(string outputCondition, string outputConditionIdentifier, string registryName) : this(outputCondition, outputConditionIdentifier, registryName, string.Empty, null)
		{
		}

		// Token: 0x0600283C RID: 10300 RVA: 0x0017555F File Offset: 0x0017455F
		public OutputIntent(string outputCondition, string outputConditionIdentifier, string registryName, string info) : this(outputCondition, outputConditionIdentifier, registryName, info, null)
		{
		}

		// Token: 0x0600283D RID: 10301 RVA: 0x00175570 File Offset: 0x00174570
		public OutputIntent(string outputCondition, string outputConditionIdentifier, string registryName, string info, IccProfile iccProfile)
		{
			this.i = outputCondition;
			this.j = outputConditionIdentifier;
			this.k = registryName;
			this.l = info;
			this.m = iccProfile;
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600283E RID: 10302 RVA: 0x001755B0 File Offset: 0x001745B0
		public static OutputIntent USWebCoatedSwop
		{
			get
			{
				return new OutputIntent("SWOP (Publication) printing in USA (Printing process definition: ANSI CGATS.6).", "CGATS TR 001", "http://www.color.org", "U.S. Web Coated (SWOP) v2");
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600283F RID: 10303 RVA: 0x001755DC File Offset: 0x001745DC
		public static OutputIntent IsoWebCoated
		{
			get
			{
				return new OutputIntent("ISO/DIS 12647-2:2004, Offset commercial and specialty printing according to ISO 12647-2, positive plates, paper type 3 (coated web, 60 g/m2), screen frequency 60/cm.", "FOGRA28", "http://www.color.org", "ISO Web Coated");
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06002840 RID: 10304 RVA: 0x00175608 File Offset: 0x00174608
		public static OutputIntent IsoUncoated
		{
			get
			{
				return new OutputIntent("ISO/DIS 12647-2:2004, Offset commercial and specialty printing according to ISO 12647-2, positive plates, paper type 4 (uncoated white offset, 120 g/m2), screen frequency 60/cm.", "FOGRA29", "http://www.color.org", "ISO Uncoated");
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06002841 RID: 10305 RVA: 0x00175634 File Offset: 0x00174634
		public static OutputIntent IsoUncoatedYellowish
		{
			get
			{
				return new OutputIntent("ISO/DIS 12647-2:2004, Offset commercial and specialty printing according to ISO 12647-2, positive plates, paper type 5 (uncoated, slightly yellowish, offset, 115 g/m2), screen frequency 60/cm.", "FOGRA30", "http://www.color.org", "ISO Uncoated Yellowish");
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06002842 RID: 10306 RVA: 0x00175660 File Offset: 0x00174660
		public static OutputIntent IsoCoated
		{
			get
			{
				return new OutputIntent("ISO/DIS 12647-2:2004, Offset commercial and specialty printing according to ISO 12647-2, positive plates, paper type 1 or 2 (gloss or matte coated offset, 115 g/m2), screen frequency 60/cm.", "FOGRA27", "http://www.color.org", "ISO Coated");
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06002843 RID: 10307 RVA: 0x0017568C File Offset: 0x0017468C
		public static OutputIntent IfraNewsPrint28
		{
			get
			{
				return new OutputIntent("ISO 12647-3:1998+, Coldset offset printing, contact exposed negative acting plates (tone value increase of 28%), newsprint, screen ruling 40 lines per cm.", "IFRA28", "http://www.color.org", "Zeitung_QUIZ_28_02.03V2.icm");
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06002844 RID: 10308 RVA: 0x001756B8 File Offset: 0x001746B8
		public static OutputIntent IfraNewsPrint22
		{
			get
			{
				return new OutputIntent("ISO 12647-3:1998+, Coldset offset printing, computer to plate (tone value increase of 22%), newsprint, screen ruling 40 lines per cm.", "IFRA22", "http://www.color.org", "Zeitung_QUIZ_22_02.03V2.icm");
			}
		}

		// Token: 0x06002845 RID: 10309 RVA: 0x001756E4 File Offset: 0x001746E4
		internal virtual void g0(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(OutputIntent.a);
			A_0.WriteName(83);
			if (this.n == OutputIntentVersion.PDF_A)
			{
				A_0.WriteName(OutputIntent.h);
			}
			else
			{
				A_0.WriteName(OutputIntent.b);
			}
			if (this.l != null && this.l.Length > 0)
			{
				A_0.WriteName(OutputIntent.f);
				A_0.WriteText(this.l);
			}
			if (this.i != null && this.i.Length > 0)
			{
				A_0.WriteName(OutputIntent.c);
				A_0.WriteText(this.i);
			}
			A_0.WriteName(OutputIntent.d);
			A_0.WriteText(this.j);
			if (this.k.Length > 0)
			{
				A_0.WriteName(OutputIntent.e);
				A_0.WriteText(this.k);
			}
			this.a(A_0);
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002846 RID: 10310 RVA: 0x00175814 File Offset: 0x00174814
		internal void a(DocumentWriter A_0)
		{
			if (this.m != null)
			{
				A_0.WriteName(OutputIntent.g);
				A_0.WriteReference(this.m);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06002847 RID: 10311 RVA: 0x0017584C File Offset: 0x0017484C
		// (set) Token: 0x06002848 RID: 10312 RVA: 0x00175864 File Offset: 0x00174864
		public virtual string OutputCondition
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06002849 RID: 10313 RVA: 0x00175870 File Offset: 0x00174870
		// (set) Token: 0x0600284A RID: 10314 RVA: 0x00175888 File Offset: 0x00174888
		public virtual string OutputConditionIdentifier
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600284B RID: 10315 RVA: 0x00175894 File Offset: 0x00174894
		// (set) Token: 0x0600284C RID: 10316 RVA: 0x001758AC File Offset: 0x001748AC
		public virtual string RegistryName
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600284D RID: 10317 RVA: 0x001758B8 File Offset: 0x001748B8
		// (set) Token: 0x0600284E RID: 10318 RVA: 0x001758D0 File Offset: 0x001748D0
		public virtual string Info
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x0600284F RID: 10319 RVA: 0x001758DA File Offset: 0x001748DA
		public virtual void SetDestOutputProfile(IccProfile iccProfile)
		{
			this.m = iccProfile;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06002850 RID: 10320 RVA: 0x001758E4 File Offset: 0x001748E4
		// (set) Token: 0x06002851 RID: 10321 RVA: 0x001758FC File Offset: 0x001748FC
		public OutputIntentVersion Version
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x040011AF RID: 4527
		internal static byte[] a = new byte[]
		{
			79,
			117,
			116,
			112,
			117,
			116,
			73,
			110,
			116,
			101,
			110,
			116
		};

		// Token: 0x040011B0 RID: 4528
		internal static byte[] b = new byte[]
		{
			71,
			84,
			83,
			95,
			80,
			68,
			70,
			88
		};

		// Token: 0x040011B1 RID: 4529
		internal static byte[] c = new byte[]
		{
			79,
			117,
			116,
			112,
			117,
			116,
			67,
			111,
			110,
			100,
			105,
			116,
			105,
			111,
			110
		};

		// Token: 0x040011B2 RID: 4530
		internal static byte[] d = new byte[]
		{
			79,
			117,
			116,
			112,
			117,
			116,
			67,
			111,
			110,
			100,
			105,
			116,
			105,
			111,
			110,
			73,
			100,
			101,
			110,
			116,
			105,
			102,
			105,
			101,
			114
		};

		// Token: 0x040011B3 RID: 4531
		internal static byte[] e = new byte[]
		{
			82,
			101,
			103,
			105,
			115,
			116,
			114,
			121,
			78,
			97,
			109,
			101
		};

		// Token: 0x040011B4 RID: 4532
		internal static byte[] f = new byte[]
		{
			73,
			110,
			102,
			111
		};

		// Token: 0x040011B5 RID: 4533
		internal static byte[] g = new byte[]
		{
			68,
			101,
			115,
			116,
			79,
			117,
			116,
			112,
			117,
			116,
			80,
			114,
			111,
			102,
			105,
			108,
			101
		};

		// Token: 0x040011B6 RID: 4534
		internal static byte[] h = new byte[]
		{
			71,
			84,
			83,
			95,
			80,
			68,
			70,
			65,
			49
		};

		// Token: 0x040011B7 RID: 4535
		private string i;

		// Token: 0x040011B8 RID: 4536
		private string j;

		// Token: 0x040011B9 RID: 4537
		private string k;

		// Token: 0x040011BA RID: 4538
		private string l;

		// Token: 0x040011BB RID: 4539
		private IccProfile m = null;

		// Token: 0x040011BC RID: 4540
		private OutputIntentVersion n = OutputIntentVersion.PDF_X;
	}
}
