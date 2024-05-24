using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements.Html;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;
using zz93;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x02000060 RID: 96
	public abstract class DocumentWriter
	{
		// Token: 0x0600036C RID: 876 RVA: 0x00043978 File Offset: 0x00042978
		public DocumentWriter(Document document)
		{
			this.y = document;
			DiskBufferingOptions diskBufferingOptions = document.DiskBuffering;
			if (diskBufferingOptions == null)
			{
				diskBufferingOptions = DiskBufferingOptions.Current;
			}
			if (diskBufferingOptions.Enabled)
			{
				this.av = diskBufferingOptions.a();
			}
			this.ad = new zh(document.CompressionLevel, this.av);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600036D RID: 877
		public abstract DocumentResourceList Resources { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00043A7C File Offset: 0x00042A7C
		public Section CurrentSection
		{
			get
			{
				return this.ab;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600036F RID: 879 RVA: 0x00043A94 File Offset: 0x00042A94
		public Document Document
		{
			get
			{
				return this.y;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00043AAC File Offset: 0x00042AAC
		public FontSubsetter FontSubsetter
		{
			get
			{
				return this.z;
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00043AC4 File Offset: 0x00042AC4
		internal virtual void ap()
		{
		}

		// Token: 0x06000372 RID: 882
		public abstract void Draw();

		// Token: 0x06000373 RID: 883
		public abstract int GetObjectNumber();

		// Token: 0x06000374 RID: 884
		public abstract int GetObjectNumber(int offset);

		// Token: 0x06000375 RID: 885
		public abstract int GetPageObject(int pageNumber);

		// Token: 0x06000376 RID: 886
		public abstract void Write(byte[] data);

		// Token: 0x06000377 RID: 887
		public abstract void Write(byte[] data, int length);

		// Token: 0x06000378 RID: 888
		public abstract void Write(byte[] data, int start, int length);

		// Token: 0x06000379 RID: 889
		public abstract void WriteArrayOpen();

		// Token: 0x0600037A RID: 890
		public abstract void WriteArrayClose();

		// Token: 0x0600037B RID: 891
		public abstract int WriteBeginObject();

		// Token: 0x0600037C RID: 892
		public abstract void WriteBoolean(bool value);

		// Token: 0x0600037D RID: 893 RVA: 0x00043AC7 File Offset: 0x00042AC7
		internal virtual void ai(int A_0)
		{
		}

		// Token: 0x0600037E RID: 894
		public abstract void WriteDictionaryOpen();

		// Token: 0x0600037F RID: 895
		public abstract void WriteDictionaryClose();

		// Token: 0x06000380 RID: 896
		public abstract void WriteEndObject();

		// Token: 0x06000381 RID: 897
		public abstract void WriteName(string name);

		// Token: 0x06000382 RID: 898
		public abstract void WriteName(byte[] name);

		// Token: 0x06000383 RID: 899
		public abstract void WriteName(byte[] name, string nameSuffix);

		// Token: 0x06000384 RID: 900
		public abstract void WriteName(byte name);

		// Token: 0x06000385 RID: 901
		public abstract void WriteName(byte nameCharacter, int nameNumber);

		// Token: 0x06000386 RID: 902
		public abstract void WriteName(byte[] name, int start, int length);

		// Token: 0x06000387 RID: 903
		public abstract void WriteReference(int objectNumber);

		// Token: 0x06000388 RID: 904
		public abstract void WriteReferenceShallow(int objectNumber);

		// Token: 0x06000389 RID: 905
		public abstract void WriteNumber0();

		// Token: 0x0600038A RID: 906
		public abstract void WriteNumber1();

		// Token: 0x0600038B RID: 907
		public abstract void WriteNumberNeg1();

		// Token: 0x0600038C RID: 908
		public abstract void WriteNumber(int value);

		// Token: 0x0600038D RID: 909
		public abstract void WriteNumber(short value);

		// Token: 0x0600038E RID: 910
		public abstract void WriteNumber(byte[] data, int start, int length);

		// Token: 0x0600038F RID: 911
		public abstract void WriteNumber(float value);

		// Token: 0x06000390 RID: 912
		public abstract void WriteNumberColor(float value);

		// Token: 0x06000391 RID: 913
		public abstract void WriteNull();

		// Token: 0x06000392 RID: 914
		public abstract void WriteStream(byte[] data, int length);

		// Token: 0x06000393 RID: 915
		internal abstract void ab(agx A_0, int A_1);

		// Token: 0x06000394 RID: 916
		internal abstract void aa(agx A_0, int A_1);

		// Token: 0x06000395 RID: 917 RVA: 0x00043ACA File Offset: 0x00042ACA
		internal virtual void af(byte[] A_0, int A_1)
		{
		}

		// Token: 0x06000396 RID: 918
		public abstract void WriteStream(byte[] data, int start, int length);

		// Token: 0x06000397 RID: 919
		internal abstract void y(byte[] A_0, int A_1, int A_2, byte[] A_3);

		// Token: 0x06000398 RID: 920
		internal abstract void z(byte[] A_0, int A_1, int A_2, byte[] A_3);

		// Token: 0x06000399 RID: 921 RVA: 0x00043ACD File Offset: 0x00042ACD
		internal virtual void ag(byte[] A_0, int A_1, int A_2)
		{
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00043AD0 File Offset: 0x00042AD0
		internal virtual void ad(byte[] A_0, int A_1)
		{
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00043AD3 File Offset: 0x00042AD3
		internal virtual void ae(byte[] A_0, int A_1, int A_2)
		{
		}

		// Token: 0x0600039C RID: 924
		public abstract int WriteStreamWithCompression(byte[] data, int length);

		// Token: 0x0600039D RID: 925
		public abstract void WriteText(string text);

		// Token: 0x0600039E RID: 926
		internal abstract void ah(byte[] A_0, bool A_1);

		// Token: 0x0600039F RID: 927
		public abstract void WriteText(byte[] text);

		// Token: 0x060003A0 RID: 928
		public abstract void WriteTextRawWithoutEncryption(byte[] text, int startIndex, int count);

		// Token: 0x060003A1 RID: 929
		public abstract void WriteTextWithoutEncryption(byte[] text);

		// Token: 0x060003A2 RID: 930 RVA: 0x00043AD6 File Offset: 0x00042AD6
		public void ClearFontSubsetter()
		{
			this.z = null;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00043AE0 File Offset: 0x00042AE0
		public FontSubsetter SetFontSubsetter(IFontSubsettable subsettableFont)
		{
			if (this.aa == null)
			{
				this.aa = new Hashtable();
			}
			this.z = (FontSubsetter)this.aa[subsettableFont];
			if (this.z == null)
			{
				this.z = subsettableFont.GetFontSubsetter();
				this.aa[subsettableFont] = this.z;
			}
			return this.z;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00043B5B File Offset: 0x00042B5B
		public void WriteReference(Resource resource)
		{
			this.WriteReference(this.Resources.Add(resource));
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00043B71 File Offset: 0x00042B71
		public void WriteReferenceUnique(Resource resource)
		{
			this.WriteReference(this.Resources.AddUnique(resource));
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00043B87 File Offset: 0x00042B87
		public void WriteReferenceShallow(Resource resource)
		{
			this.WriteReferenceShallow(this.Resources.Add(resource));
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00043BA0 File Offset: 0x00042BA0
		public DateTime CreationDate
		{
			get
			{
				return this.an;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00043BB8 File Offset: 0x00042BB8
		public DateTime ModifiedDate
		{
			get
			{
				return this.an;
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00043BD0 File Offset: 0x00042BD0
		internal acc q()
		{
			return this.al;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00043BE8 File Offset: 0x00042BE8
		internal void a(acc A_0)
		{
			this.al = A_0;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00043BF4 File Offset: 0x00042BF4
		internal int r()
		{
			return this.am;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00043C0C File Offset: 0x00042C0C
		internal void d(int A_0)
		{
			this.am = A_0;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00043C18 File Offset: 0x00042C18
		internal bool s()
		{
			return this.ao;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00043C30 File Offset: 0x00042C30
		internal void a(bool A_0)
		{
			this.ao = A_0;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00043C3C File Offset: 0x00042C3C
		internal static DocumentWriter a(Stream A_0, Document A_1, PdfFormat A_2)
		{
			DocumentWriter result;
			if (A_2 == PdfFormat.Linearized)
			{
				if (A_1.Security is RC4128Security || A_1.Security is RC440Security)
				{
					result = new b4(A_0, A_1, b5.a);
				}
				else if (A_1.Security is Aes128Security || A_1.Security is Aes256Security)
				{
					if (A_1.Security.d())
					{
						result = new b3(A_0, A_1);
					}
					else
					{
						result = new b4(A_0, A_1, b5.b);
					}
				}
				else
				{
					result = new b3(A_0, A_1);
				}
			}
			else if (A_1.Security is RC4128Security || A_1.Security is RC440Security)
			{
				result = new b2(A_0, A_1, b5.a);
			}
			else if (A_1.Security is Aes128Security || A_1.Security is Aes256Security)
			{
				if (A_1.Security.d())
				{
					result = new b1(A_0, A_1);
				}
				else
				{
					result = new b2(A_0, A_1, b5.b);
				}
			}
			else
			{
				result = new b1(A_0, A_1);
			}
			return result;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00043D7C File Offset: 0x00042D7C
		internal agx a(agp A_0)
		{
			agx agx;
			agx result;
			if (this.ap == null)
			{
				this.ap = new Dictionary<agp, agx>();
				agx = A_0.d();
				this.ap.Add(A_0, agx);
				result = agx;
			}
			else if (this.ap.TryGetValue(A_0, out agx))
			{
				result = agx;
			}
			else
			{
				agx = A_0.d();
				this.ap.Add(A_0, agx);
				result = agx;
			}
			return result;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00043DF4 File Offset: 0x00042DF4
		internal void t()
		{
			if (this.ap != null)
			{
				foreach (agx agx in this.ap.Values)
				{
					agx.lr();
				}
			}
		}

		// Token: 0x060003B2 RID: 946
		internal abstract void ac(bp A_0);

		// Token: 0x060003B3 RID: 947 RVA: 0x00043E68 File Offset: 0x00042E68
		internal void a(Page A_0, int A_1)
		{
			if (this.ah == null)
			{
				this.ah = new Hashtable();
				this.ah.Add(A_0.fg(), A_1);
			}
			else if (!this.ah.Contains(A_0.fg()))
			{
				this.ah.Add(A_0.fg(), A_1);
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00043EDC File Offset: 0x00042EDC
		internal void a(PdfPage A_0)
		{
			if (this.ah == null)
			{
				this.WriteNull();
			}
			else
			{
				object obj = this.ah[A_0];
				if (obj != null)
				{
					this.WriteReferenceShallow((int)obj);
				}
				else
				{
					this.WriteNull();
				}
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00043F34 File Offset: 0x00042F34
		internal int b(PdfPage A_0)
		{
			object obj = this.ah[A_0];
			int result;
			if (obj != null)
			{
				result = (int)obj;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00043F68 File Offset: 0x00042F68
		internal zh u()
		{
			return this.ad;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00043F80 File Offset: 0x00042F80
		internal zh v()
		{
			if (this.at == null)
			{
				this.at = new zh(this.y.CompressionLevel, this.av);
			}
			return this.at;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00043FC4 File Offset: 0x00042FC4
		internal zh w()
		{
			if (this.ae == null)
			{
				this.ae = new zh(this.y.CompressionLevel, this.av);
			}
			return this.ae;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00044008 File Offset: 0x00043008
		internal zh x()
		{
			if (this.af == null)
			{
				this.af = new zh(this.y.CompressionLevel, this.av);
			}
			return this.af;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0004404C File Offset: 0x0004304C
		internal yx y()
		{
			if (this.ag == null)
			{
				if (this.av != null)
				{
					this.ag = new agi(this.av);
				}
				else
				{
					this.ag = new agl();
				}
			}
			return this.ag;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000440A8 File Offset: 0x000430A8
		internal int z()
		{
			int result;
			if (this.ab == null)
			{
				result = this.y.Pages.Count;
			}
			else if (this.ab.a() == -1)
			{
				result = this.y.Pages.Count - this.ab.PageIndex + this.ab.StartingPageNumber - 1;
			}
			else
			{
				result = this.ab.a() + this.ab.StartingPageNumber - 1;
			}
			return result;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00044138 File Offset: 0x00043138
		internal bool e(int A_0)
		{
			bool result;
			if (this.ab == null)
			{
				this.ab = this.y.Sections.a(0);
				result = true;
			}
			else if (this.ab.a() == -1)
			{
				result = false;
			}
			else if (this.y.Sections.a(this.ac).PageIndex <= A_0)
			{
				this.ab = this.y.Sections.a(this.ac++);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000441E0 File Offset: 0x000431E0
		internal virtual void aj()
		{
		}

		// Token: 0x060003BE RID: 958
		internal abstract void ak(byte A_0);

		// Token: 0x060003BF RID: 959 RVA: 0x000441E8 File Offset: 0x000431E8
		internal byte b(char A_0)
		{
			byte result;
			if (A_0 < '\u0018')
			{
				result = (byte)A_0;
			}
			else if (A_0 < ' ')
			{
				result = 0;
			}
			else if (A_0 < '\u00a0')
			{
				result = (byte)A_0;
			}
			else if (A_0 < '¡')
			{
				result = 0;
			}
			else if (A_0 < '­')
			{
				result = (byte)A_0;
			}
			else if (A_0 < '®')
			{
				result = 0;
			}
			else if (A_0 < 'Ā')
			{
				result = (byte)A_0;
			}
			else
			{
				result = this.a(A_0);
			}
			return result;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00044284 File Offset: 0x00043284
		private byte a(char A_0)
		{
			if (A_0 <= 'ˇ')
			{
				if (A_0 <= 'š')
				{
					if (A_0 <= 'ł')
					{
						if (A_0 == 'ı')
						{
							return 154;
						}
						switch (A_0)
						{
						case 'Ł':
							return 149;
						case 'ł':
							return 155;
						}
					}
					else
					{
						switch (A_0)
						{
						case 'Œ':
							return 150;
						case 'œ':
							return 156;
						default:
							switch (A_0)
							{
							case 'Š':
								return 151;
							case 'š':
								return 157;
							}
							break;
						}
					}
				}
				else if (A_0 <= 'ž')
				{
					if (A_0 == 'Ÿ')
					{
						return 152;
					}
					switch (A_0)
					{
					case 'Ž':
						return 153;
					case 'ž':
						return 158;
					}
				}
				else
				{
					if (A_0 == 'ƒ')
					{
						return 134;
					}
					switch (A_0)
					{
					case 'ˆ':
						return 26;
					case 'ˇ':
						return 25;
					}
				}
			}
			else if (A_0 <= '›')
			{
				if (A_0 <= '…')
				{
					switch (A_0)
					{
					case '˘':
						return 24;
					case '˙':
						return 27;
					case '˚':
						return 30;
					case '˛':
						return 29;
					case '˜':
						return 31;
					case '˝':
						return 28;
					default:
						switch (A_0)
						{
						case '–':
							return 133;
						case '—':
							return 132;
						case '‘':
							return 143;
						case '’':
							return 144;
						case '‚':
							return 145;
						case '“':
							return 141;
						case '”':
							return 142;
						case '„':
							return 140;
						case '†':
							return 129;
						case '‡':
							return 130;
						case '•':
							return 128;
						case '…':
							return 131;
						}
						break;
					}
				}
				else
				{
					if (A_0 == '‰')
					{
						return 139;
					}
					switch (A_0)
					{
					case '‹':
						return 136;
					case '›':
						return 137;
					}
				}
			}
			else if (A_0 <= '€')
			{
				if (A_0 == '⁄')
				{
					return 135;
				}
				if (A_0 == '€')
				{
					return 160;
				}
			}
			else
			{
				if (A_0 == '™')
				{
					return 146;
				}
				if (A_0 == '−')
				{
					return 138;
				}
				switch (A_0)
				{
				case 'ﬁ':
					return 147;
				case 'ﬂ':
					return 148;
				}
			}
			return 0;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000445D6 File Offset: 0x000435D6
		internal virtual void an(string A_0)
		{
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x000445D9 File Offset: 0x000435D9
		internal virtual void ao(byte[] A_0)
		{
		}

		// Token: 0x060003C3 RID: 963
		internal abstract int al();

		// Token: 0x060003C4 RID: 964
		internal abstract int am();

		// Token: 0x060003C5 RID: 965 RVA: 0x000445DC File Offset: 0x000435DC
		internal int aa()
		{
			return this.ak;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000445F4 File Offset: 0x000435F4
		internal void f(int A_0)
		{
			this.ak = A_0;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00044600 File Offset: 0x00043600
		internal int ab()
		{
			return this.ai;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00044618 File Offset: 0x00043618
		internal void g(int A_0)
		{
			this.ai = A_0;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00044624 File Offset: 0x00043624
		internal int ac()
		{
			return this.aj;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0004463C File Offset: 0x0004363C
		internal void h(int A_0)
		{
			this.aj = A_0;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00044648 File Offset: 0x00043648
		internal cr[] ad()
		{
			return this.aq;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00044660 File Offset: 0x00043660
		internal void a(cr[] A_0)
		{
			this.aq = A_0;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0004466C File Offset: 0x0004366C
		internal void a(DocumentResourceList A_0)
		{
			if (this.Document.Tag != null || this.Document.j() != null)
			{
				this.Document.j().l();
				PdfAStandard? pdfAStandard = this.Document.f();
				if (pdfAStandard != null && pdfAStandard == PdfAStandard.PDF_A_1a_2005)
				{
					this.Document.j().a(true);
				}
				if (this.Document.Tag != null || this.Document.j() != null)
				{
					A_0.b(this);
				}
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00044728 File Offset: 0x00043728
		internal int ae()
		{
			return this.ar;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00044740 File Offset: 0x00043740
		internal void i(int A_0)
		{
			this.ar = A_0;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0004474C File Offset: 0x0004374C
		internal StructureElement af()
		{
			return this.@as;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00044764 File Offset: 0x00043764
		internal void a(StructureElement A_0)
		{
			this.@as = A_0;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00044770 File Offset: 0x00043770
		internal Hashtable ag()
		{
			return this.au;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00044788 File Offset: 0x00043788
		internal void a(Hashtable A_0)
		{
			this.au = A_0;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00044794 File Offset: 0x00043794
		internal Dictionary<int, l2> ah()
		{
			if (this.aw == null)
			{
				this.aw = new Dictionary<int, l2>();
			}
			return this.aw;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000447CC File Offset: 0x000437CC
		internal void a(HtmlArea A_0, int A_1)
		{
			if (!this.au.Contains(A_0))
			{
				this.au.Add(A_0, A_1);
			}
		}

		// Token: 0x04000230 RID: 560
		internal static byte[] a = new byte[]
		{
			32,
			48,
			32,
			111,
			98,
			106,
			10
		};

		// Token: 0x04000231 RID: 561
		internal static byte[] b = new byte[]
		{
			32,
			48,
			32,
			82
		};

		// Token: 0x04000232 RID: 562
		internal static byte[] c = new byte[]
		{
			10,
			101,
			110,
			100,
			111,
			98,
			106,
			10
		};

		// Token: 0x04000233 RID: 563
		internal static byte[] d = new byte[]
		{
			115,
			116,
			114,
			101,
			97,
			109,
			10
		};

		// Token: 0x04000234 RID: 564
		internal static byte[] e = new byte[]
		{
			10,
			101,
			110,
			100,
			115,
			116,
			114,
			101,
			97,
			109
		};

		// Token: 0x04000235 RID: 565
		internal static byte[] f = new byte[]
		{
			37,
			80,
			68,
			70,
			45,
			49,
			46,
			51,
			10,
			37,
			226,
			227,
			207,
			211,
			10
		};

		// Token: 0x04000236 RID: 566
		internal static byte[] g = new byte[]
		{
			37,
			80,
			68,
			70,
			45,
			49,
			46,
			52,
			10,
			37,
			226,
			227,
			207,
			211,
			10
		};

		// Token: 0x04000237 RID: 567
		internal static byte[] h = new byte[]
		{
			37,
			80,
			68,
			70,
			45,
			49,
			46,
			53,
			10,
			37,
			226,
			227,
			207,
			211,
			10
		};

		// Token: 0x04000238 RID: 568
		internal static byte[] i = new byte[]
		{
			37,
			80,
			68,
			70,
			45,
			49,
			46,
			54,
			10,
			37,
			226,
			227,
			207,
			211,
			10
		};

		// Token: 0x04000239 RID: 569
		internal static byte[] j = new byte[]
		{
			37,
			80,
			68,
			70,
			45,
			49,
			46,
			55,
			10,
			37,
			226,
			227,
			207,
			211,
			10
		};

		// Token: 0x0400023A RID: 570
		internal static byte[] k = new byte[]
		{
			116,
			114,
			117,
			101
		};

		// Token: 0x0400023B RID: 571
		internal static byte[] l = new byte[]
		{
			102,
			97,
			108,
			115,
			101
		};

		// Token: 0x0400023C RID: 572
		internal static byte[] m = new byte[]
		{
			110,
			117,
			108,
			108
		};

		// Token: 0x0400023D RID: 573
		internal static byte[] n = new byte[]
		{
			116,
			114,
			97,
			105,
			108,
			101,
			114,
			10
		};

		// Token: 0x0400023E RID: 574
		internal static byte[] o = new byte[]
		{
			83,
			105,
			122,
			101
		};

		// Token: 0x0400023F RID: 575
		internal static byte[] p = new byte[]
		{
			82,
			111,
			111,
			116
		};

		// Token: 0x04000240 RID: 576
		internal static byte[] q = new byte[]
		{
			69,
			110,
			99,
			114,
			121,
			112,
			116
		};

		// Token: 0x04000241 RID: 577
		internal static byte[] r = new byte[]
		{
			73,
			68
		};

		// Token: 0x04000242 RID: 578
		internal static byte[] s = new byte[]
		{
			73,
			110,
			102,
			111
		};

		// Token: 0x04000243 RID: 579
		internal static byte[] t = new byte[]
		{
			10,
			115,
			116,
			97,
			114,
			116,
			120,
			114,
			101,
			102,
			10
		};

		// Token: 0x04000244 RID: 580
		internal static byte[] u = new byte[]
		{
			10,
			37,
			37,
			69,
			79,
			70,
			10
		};

		// Token: 0x04000245 RID: 581
		internal static byte[] v = new byte[]
		{
			120,
			114,
			101,
			102,
			10,
			48,
			32
		};

		// Token: 0x04000246 RID: 582
		internal static byte[] w = new byte[]
		{
			10,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			32,
			54,
			53,
			53,
			51,
			53,
			32,
			102,
			32,
			10
		};

		// Token: 0x04000247 RID: 583
		internal static byte[] x = new byte[]
		{
			32,
			48,
			48,
			48,
			48,
			48,
			32,
			110,
			32,
			10
		};

		// Token: 0x04000248 RID: 584
		private Document y;

		// Token: 0x04000249 RID: 585
		private FontSubsetter z = null;

		// Token: 0x0400024A RID: 586
		private Hashtable aa = null;

		// Token: 0x0400024B RID: 587
		private Section ab = null;

		// Token: 0x0400024C RID: 588
		private int ac = 1;

		// Token: 0x0400024D RID: 589
		private zh ad;

		// Token: 0x0400024E RID: 590
		private zh ae;

		// Token: 0x0400024F RID: 591
		private zh af;

		// Token: 0x04000250 RID: 592
		private yx ag = null;

		// Token: 0x04000251 RID: 593
		private Hashtable ah = null;

		// Token: 0x04000252 RID: 594
		private int ai = -1;

		// Token: 0x04000253 RID: 595
		private int aj = -1;

		// Token: 0x04000254 RID: 596
		private int ak = -1;

		// Token: 0x04000255 RID: 597
		private acc al = null;

		// Token: 0x04000256 RID: 598
		private int am = -1;

		// Token: 0x04000257 RID: 599
		private DateTime an = DateTime.Now;

		// Token: 0x04000258 RID: 600
		private bool ao = false;

		// Token: 0x04000259 RID: 601
		private Dictionary<agp, agx> ap = null;

		// Token: 0x0400025A RID: 602
		private cr[] aq = null;

		// Token: 0x0400025B RID: 603
		private int ar = 0;

		// Token: 0x0400025C RID: 604
		private StructureElement @as = null;

		// Token: 0x0400025D RID: 605
		private zh at = null;

		// Token: 0x0400025E RID: 606
		private Hashtable au = new Hashtable();

		// Token: 0x0400025F RID: 607
		private agk av = null;

		// Token: 0x04000260 RID: 608
		private Dictionary<int, l2> aw = null;
	}
}
