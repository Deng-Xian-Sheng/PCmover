using System;
using System.IO;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x0200086E RID: 2158
	public class Type1Font : Font
	{
		// Token: 0x06005790 RID: 22416 RVA: 0x0032EF84 File Offset: 0x0032DF84
		public Type1Font(string metricsFile, string fontFile) : base(Encoder.Latin1)
		{
			if (metricsFile.ToLower().EndsWith(".pfm"))
			{
				this.c(metricsFile);
			}
			else
			{
				if (!metricsFile.ToLower().EndsWith(".afm"))
				{
					throw new GeneratorException("Invalid Type 1 metrics file. Must be a .pfm or .afm file.");
				}
				this.b(metricsFile);
			}
			this.a(fontFile);
			this.o = y0.a(this.o, 0, this.j + this.k);
		}

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06005791 RID: 22417 RVA: 0x0032F040 File Offset: 0x0032E040
		public override int RequiredPdfObjects
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x06005792 RID: 22418 RVA: 0x0032F054 File Offset: 0x0032E054
		private new void c(string A_0)
		{
			FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			byte[] array = new byte[fileStream.Length];
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();
			this.g = (int)array[95];
			int num = BitConverter.ToInt32(array, 119);
			int num2 = BitConverter.ToInt32(array, 123);
			for (int i = 32; i < 256; i++)
			{
				int num3 = (int)Type1Font.v[i];
				if (num3 != 0)
				{
					this.i[i] = BitConverter.ToInt16(array, num2 + (num3 - this.g) * 2);
				}
			}
			this.f = (int)BitConverter.ToUInt16(array, num + 14);
			this.l = (int)BitConverter.ToUInt16(array, 74);
			this.m = (int)(-(int)BitConverter.ToUInt16(array, num + 20));
			if (this.m < -32768)
			{
				this.m = -this.m - 65536;
			}
		}

		// Token: 0x06005793 RID: 22419 RVA: 0x0032F160 File Offset: 0x0032E160
		private new void b(string A_0)
		{
			FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			byte[] array = new byte[fileStream.Length];
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();
			this.g = 32;
			Type1Font.b b = new Type1Font.b(array, Type1Font.v);
			this.l = b.f();
			this.m = b.g();
			this.f = b.e();
			this.i = b.d();
		}

		// Token: 0x06005794 RID: 22420 RVA: 0x0032F1EC File Offset: 0x0032E1EC
		public override short GetGlyphWidth(char glyph)
		{
			return this.i[(int)Encoder.Latin1.Encode(glyph)];
		}

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x06005795 RID: 22421 RVA: 0x0032F210 File Offset: 0x0032E210
		public override LineBreaker LineBreaker
		{
			get
			{
				return LineBreaker.Latin;
			}
		}

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x06005796 RID: 22422 RVA: 0x0032F228 File Offset: 0x0032E228
		public override short Descender
		{
			get
			{
				return (short)this.m;
			}
		}

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x06005797 RID: 22423 RVA: 0x0032F244 File Offset: 0x0032E244
		public override short Ascender
		{
			get
			{
				return (short)this.l;
			}
		}

		// Token: 0x06005798 RID: 22424 RVA: 0x0032F260 File Offset: 0x0032E260
		internal override short bc()
		{
			return 102;
		}

		// Token: 0x06005799 RID: 22425 RVA: 0x0032F274 File Offset: 0x0032E274
		internal override short bd()
		{
			return 250;
		}

		// Token: 0x0600579A RID: 22426 RVA: 0x0032F28C File Offset: 0x0032E28C
		internal override short be()
		{
			return 0;
		}

		// Token: 0x0600579B RID: 22427 RVA: 0x0032F2A0 File Offset: 0x0032E2A0
		internal override short bf()
		{
			return 0;
		}

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x0600579C RID: 22428 RVA: 0x0032F2B4 File Offset: 0x0032E2B4
		public override short LineGap
		{
			get
			{
				return (short)this.n;
			}
		}

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x0600579D RID: 22429 RVA: 0x0032F2D0 File Offset: 0x0032E2D0
		public override string Name
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x0600579E RID: 22430 RVA: 0x0032F2E8 File Offset: 0x0032E2E8
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.a);
			writer.WriteName(Font.c);
			writer.WriteName(this.a);
			writer.WriteName(Font.g);
			writer.WriteName(Type1Font.q);
			writer.WriteName(Font.d);
			writer.WriteNumber(32);
			writer.WriteName(Font.e);
			writer.WriteNumber(255);
			writer.WriteName(Font.f);
			writer.WriteArrayOpen();
			for (int i = 32; i < 256; i++)
			{
				writer.WriteNumber(this.i[i]);
			}
			writer.WriteArrayClose();
			writer.WriteName(Font.n);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Font.n);
			writer.WriteName(Font.r);
			writer.WriteName(this.a);
			writer.WriteName(Font.y);
			writer.WriteNumber(32);
			writer.WriteName(Font.p);
			writer.WriteArrayOpen();
			writer.WriteNumber(this.b);
			writer.WriteNumber(this.e);
			writer.WriteNumber(this.c);
			writer.WriteNumber(this.d);
			writer.WriteArrayClose();
			writer.WriteName(Font.t);
			writer.WriteNumber0();
			writer.WriteName(Font.u);
			writer.WriteNumber(this.f);
			writer.WriteName(Font.v);
			writer.WriteNumber(this.l);
			writer.WriteName(Font.w);
			writer.WriteNumber(this.m);
			writer.WriteName(Font.x);
			writer.WriteNumber(this.h);
			writer.WriteName(Type1Font.r);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.e);
			writer.WriteNumber(this.o.Length);
			writer.WriteName(Resource.c);
			writer.WriteName(Resource.d);
			writer.WriteName(Type1Font.s);
			writer.WriteNumber(this.j);
			writer.WriteName(Type1Font.t);
			writer.WriteNumber(this.k);
			writer.WriteName(Type1Font.u);
			writer.WriteNumber0();
			writer.WriteDictionaryClose();
			writer.WriteStream(this.o, this.o.Length);
			writer.WriteEndObject();
		}

		// Token: 0x0600579F RID: 22431 RVA: 0x0032F5E4 File Offset: 0x0032E5E4
		private new void a(string A_0)
		{
			FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			this.o = new byte[fileStream.Length];
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Read(this.o, 0, (int)fileStream.Length);
			fileStream.Close();
			Type1Font.c c = new Type1Font.c(this.o);
			this.a = c.d();
			this.b = c.e();
			this.c = c.f();
			this.d = c.g();
			this.e = c.h();
			this.h = c.i();
			this.j = c.j();
			this.k = c.k();
		}

		// Token: 0x060057A0 RID: 22432 RVA: 0x0032F6A0 File Offset: 0x0032E6A0
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x060057A1 RID: 22433 RVA: 0x0032F6B8 File Offset: 0x0032E6B8
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x04002E7A RID: 11898
		private new string a;

		// Token: 0x04002E7B RID: 11899
		private new int b;

		// Token: 0x04002E7C RID: 11900
		private new int c;

		// Token: 0x04002E7D RID: 11901
		private new int d;

		// Token: 0x04002E7E RID: 11902
		private new int e;

		// Token: 0x04002E7F RID: 11903
		private new int f;

		// Token: 0x04002E80 RID: 11904
		private new int g;

		// Token: 0x04002E81 RID: 11905
		private new float h;

		// Token: 0x04002E82 RID: 11906
		private new short[] i = new short[256];

		// Token: 0x04002E83 RID: 11907
		private new int j = -1;

		// Token: 0x04002E84 RID: 11908
		private new int k = -1;

		// Token: 0x04002E85 RID: 11909
		private new int l;

		// Token: 0x04002E86 RID: 11910
		private new int m;

		// Token: 0x04002E87 RID: 11911
		private new int n = 0;

		// Token: 0x04002E88 RID: 11912
		private new byte[] o;

		// Token: 0x04002E89 RID: 11913
		private new static Encoding p = Encoding.ASCII;

		// Token: 0x04002E8A RID: 11914
		private new static byte[] q = new byte[]
		{
			87,
			105,
			110,
			65,
			110,
			115,
			105,
			69,
			110,
			99,
			111,
			100,
			105,
			110,
			103
		};

		// Token: 0x04002E8B RID: 11915
		private new static byte[] r = new byte[]
		{
			70,
			111,
			110,
			116,
			70,
			105,
			108,
			101
		};

		// Token: 0x04002E8C RID: 11916
		private new static byte[] s = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104,
			49
		};

		// Token: 0x04002E8D RID: 11917
		private new static byte[] t = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104,
			50
		};

		// Token: 0x04002E8E RID: 11918
		private new static byte[] u = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104,
			51
		};

		// Token: 0x04002E8F RID: 11919
		private new static byte[] v = new byte[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62,
			63,
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95,
			193,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			123,
			124,
			125,
			126,
			149,
			149,
			149,
			184,
			166,
			185,
			188,
			178,
			179,
			195,
			189,
			83,
			172,
			234,
			149,
			90,
			149,
			149,
			96,
			39,
			170,
			186,
			183,
			177,
			208,
			196,
			153,
			115,
			173,
			250,
			149,
			122,
			89,
			32,
			161,
			162,
			163,
			168,
			165,
			149,
			167,
			200,
			149,
			227,
			171,
			149,
			149,
			149,
			197,
			149,
			149,
			149,
			149,
			194,
			149,
			182,
			180,
			203,
			149,
			235,
			187,
			149,
			149,
			149,
			191,
			65,
			65,
			65,
			65,
			65,
			65,
			198,
			67,
			69,
			69,
			69,
			69,
			73,
			73,
			73,
			73,
			68,
			78,
			79,
			79,
			79,
			79,
			79,
			149,
			79,
			85,
			85,
			85,
			85,
			89,
			149,
			251,
			97,
			97,
			97,
			97,
			97,
			97,
			230,
			99,
			101,
			101,
			101,
			101,
			105,
			105,
			105,
			105,
			111,
			110,
			111,
			111,
			111,
			111,
			111,
			149,
			111,
			117,
			117,
			117,
			117,
			121,
			149,
			121
		};

		// Token: 0x0200086F RID: 2159
		internal new abstract class a
		{
			// Token: 0x060057A3 RID: 22435 RVA: 0x0032F770 File Offset: 0x0032E770
			internal a(byte[] A_0)
			{
				this.b = A_0;
			}

			// Token: 0x060057A4 RID: 22436 RVA: 0x0032F784 File Offset: 0x0032E784
			internal int m()
			{
				return this.a;
			}

			// Token: 0x060057A5 RID: 22437 RVA: 0x0032F79C File Offset: 0x0032E79C
			internal void b(int A_0)
			{
				this.a = A_0;
			}

			// Token: 0x060057A6 RID: 22438 RVA: 0x0032F7A8 File Offset: 0x0032E7A8
			internal byte[] n()
			{
				return this.b;
			}

			// Token: 0x060057A7 RID: 22439 RVA: 0x0032F7C0 File Offset: 0x0032E7C0
			internal bool o()
			{
				return this.a < this.b.Length;
			}

			// Token: 0x060057A8 RID: 22440 RVA: 0x0032F7E4 File Offset: 0x0032E7E4
			internal int p()
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				while (this.a <= this.b.Length && this.b[this.a] > 32 && this.b[this.a] != 40 && this.b[this.a] != 47 && this.b[this.a] != 60 && this.b[this.a] != 62 && this.b[this.a] != 91 && this.b[this.a] != 93 && this.b[this.a] != 123 && this.b[this.a] != 125)
				{
					num2 <<= 6;
					num2 |= (int)(this.b[this.a] % 64);
					if (num3 % 5 == 4)
					{
						num ^= num2;
						num2 = 0;
					}
					this.a++;
					num3++;
				}
				if (num3 % 5 != 0)
				{
					num ^= num2;
				}
				this.q();
				return num;
			}

			// Token: 0x060057A9 RID: 22441 RVA: 0x0032F91C File Offset: 0x0032E91C
			internal void q()
			{
				while (this.a <= this.b.Length && this.b[this.a] <= 32)
				{
					this.a++;
				}
			}

			// Token: 0x060057AA RID: 22442 RVA: 0x0032F968 File Offset: 0x0032E968
			internal float r()
			{
				bool flag = false;
				float num = 0f;
				switch (this.b[this.a])
				{
				case 43:
					break;
				case 44:
					goto IL_44;
				case 45:
					flag = true;
					break;
				default:
					goto IL_44;
				}
				this.a++;
				IL_44:
				while (this.a <= this.b.Length && this.b[this.a] == 48)
				{
					this.a++;
				}
				while (this.a <= this.b.Length && this.c(this.b[this.a]))
				{
					num = num * 10f + (float)this.b[this.a] - 48f;
					this.a++;
				}
				if (this.b[this.a] == 46)
				{
					this.a++;
					float num2 = 0.1f;
					while (this.a <= this.b.Length && this.c(this.b[this.a]))
					{
						num += num2 * (float)(this.b[this.a] - 48);
						num2 /= 10f;
						this.a++;
					}
				}
				this.q();
				float result;
				if (flag)
				{
					result = -num;
				}
				else
				{
					result = num;
				}
				return result;
			}

			// Token: 0x060057AB RID: 22443 RVA: 0x0032FAFC File Offset: 0x0032EAFC
			internal int s()
			{
				bool flag = false;
				int num = 0;
				if (this.b(this.b[this.a]))
				{
					switch (this.b[this.a++])
					{
					case 45:
						flag = true;
						break;
					case 46:
						while (this.a <= this.b.Length && this.a(this.b[this.a]))
						{
							this.a++;
						}
						return 0;
					}
				}
				while (this.a <= this.b.Length && this.b[this.a] == 48)
				{
					this.a++;
				}
				while (this.a <= this.b.Length && this.c(this.b[this.a]))
				{
					num = num * 10 + (int)this.b[this.a] - 48;
					this.a++;
				}
				while (this.a <= this.b.Length && this.a(this.b[this.a]))
				{
					this.a++;
				}
				this.q();
				int result;
				if (flag)
				{
					result = -num;
				}
				else
				{
					result = num;
				}
				return result;
			}

			// Token: 0x060057AC RID: 22444 RVA: 0x0032FC88 File Offset: 0x0032EC88
			private bool c(byte A_0)
			{
				return A_0 >= 48 && A_0 <= 57;
			}

			// Token: 0x060057AD RID: 22445 RVA: 0x0032FCAC File Offset: 0x0032ECAC
			private bool b(byte A_0)
			{
				return A_0 == 43 || A_0 == 45 || A_0 == 46;
			}

			// Token: 0x060057AE RID: 22446 RVA: 0x0032FCD4 File Offset: 0x0032ECD4
			private bool a(byte A_0)
			{
				return this.c(A_0) || this.b(A_0);
			}

			// Token: 0x060057AF RID: 22447 RVA: 0x0032FCFC File Offset: 0x0032ECFC
			internal byte t()
			{
				return this.b[this.a];
			}

			// Token: 0x04002E90 RID: 11920
			private int a;

			// Token: 0x04002E91 RID: 11921
			private byte[] b;
		}

		// Token: 0x02000870 RID: 2160
		internal new class b : Type1Font.a
		{
			// Token: 0x060057B0 RID: 22448 RVA: 0x0032FD1B File Offset: 0x0032ED1B
			internal b(byte[] A_0, byte[] A_1) : base(A_0)
			{
				this.c();
			}

			// Token: 0x060057B1 RID: 22449 RVA: 0x0032FD40 File Offset: 0x0032ED40
			private void c()
			{
				int num = base.p();
				while (base.o())
				{
					int num2 = num;
					if (num2 <= 52525073)
					{
						if (num2 != 30175260)
						{
							if (num2 != 52525073)
							{
								goto IL_72;
							}
							this.b = base.s();
						}
						else
						{
							this.c = base.s();
						}
					}
					else if (num2 != 70087063)
					{
						if (num2 != 899885673)
						{
							goto IL_72;
						}
						this.a(base.s());
						break;
					}
					else
					{
						this.d = base.s();
					}
					IL_7B:
					num = base.p();
					continue;
					IL_72:
					this.b();
					goto IL_7B;
				}
			}

			// Token: 0x060057B2 RID: 22450 RVA: 0x0032FDE0 File Offset: 0x0032EDE0
			private void a(int A_0)
			{
				int num = base.p();
				int num2 = 0;
				int num3 = -1;
				while (num != 616038767 && num2 < A_0)
				{
					int num4 = num;
					if (num4 != 3)
					{
						if (num4 == 1496)
						{
							if (num3 != -1)
							{
								this.a[num3] = (short)base.s();
							}
							num2++;
						}
					}
					else
					{
						num3 = base.s();
					}
					this.a();
					num = base.p();
				}
			}

			// Token: 0x060057B3 RID: 22451 RVA: 0x0032FE5C File Offset: 0x0032EE5C
			private void b()
			{
				while (base.o() && base.t() != 10 && base.t() != 13)
				{
					base.b(base.m() + 1);
				}
				base.q();
			}

			// Token: 0x060057B4 RID: 22452 RVA: 0x0032FEAC File Offset: 0x0032EEAC
			private void a()
			{
				while (base.t() != 59)
				{
					base.b(base.m() + 1);
				}
				if (base.t() == 59)
				{
					base.b(base.m() + 1);
				}
				while (base.t() < 33)
				{
					base.b(base.m() + 1);
				}
			}

			// Token: 0x060057B5 RID: 22453 RVA: 0x0032FF1C File Offset: 0x0032EF1C
			internal short[] d()
			{
				return this.a;
			}

			// Token: 0x060057B6 RID: 22454 RVA: 0x0032FF34 File Offset: 0x0032EF34
			internal int e()
			{
				return this.b;
			}

			// Token: 0x060057B7 RID: 22455 RVA: 0x0032FF4C File Offset: 0x0032EF4C
			internal int f()
			{
				return this.c;
			}

			// Token: 0x060057B8 RID: 22456 RVA: 0x0032FF64 File Offset: 0x0032EF64
			internal int g()
			{
				return this.d;
			}

			// Token: 0x04002E92 RID: 11922
			private short[] a = new short[256];

			// Token: 0x04002E93 RID: 11923
			private int b;

			// Token: 0x04002E94 RID: 11924
			private int c;

			// Token: 0x04002E95 RID: 11925
			private int d;
		}

		// Token: 0x02000871 RID: 2161
		internal new class c : Type1Font.a
		{
			// Token: 0x060057B9 RID: 22457 RVA: 0x0032FF7C File Offset: 0x0032EF7C
			internal c(byte[] A_0) : base(A_0)
			{
				this.c();
			}

			// Token: 0x060057BA RID: 22458 RVA: 0x0032FFA0 File Offset: 0x0032EFA0
			internal string d()
			{
				return this.a;
			}

			// Token: 0x060057BB RID: 22459 RVA: 0x0032FFB8 File Offset: 0x0032EFB8
			internal int e()
			{
				return this.b;
			}

			// Token: 0x060057BC RID: 22460 RVA: 0x0032FFD0 File Offset: 0x0032EFD0
			internal int f()
			{
				return this.c;
			}

			// Token: 0x060057BD RID: 22461 RVA: 0x0032FFE8 File Offset: 0x0032EFE8
			internal int g()
			{
				return this.d;
			}

			// Token: 0x060057BE RID: 22462 RVA: 0x00330000 File Offset: 0x0032F000
			internal int h()
			{
				return this.e;
			}

			// Token: 0x060057BF RID: 22463 RVA: 0x00330018 File Offset: 0x0032F018
			internal float i()
			{
				return this.f;
			}

			// Token: 0x060057C0 RID: 22464 RVA: 0x00330030 File Offset: 0x0032F030
			internal int j()
			{
				return this.g;
			}

			// Token: 0x060057C1 RID: 22465 RVA: 0x00330048 File Offset: 0x0032F048
			internal int k()
			{
				return this.h;
			}

			// Token: 0x060057C2 RID: 22466 RVA: 0x00330060 File Offset: 0x0032F060
			private void c()
			{
				while (base.o() && base.t() != 37)
				{
					base.b(base.m() + 1);
				}
				while (base.o() && this.g == -1)
				{
					byte b = base.t();
					if (b <= 40)
					{
						if (b != 37)
						{
							if (b != 40)
							{
								goto IL_27F;
							}
							this.a();
						}
						else
						{
							this.b();
						}
					}
					else if (b != 47)
					{
						if (b != 101)
						{
							goto IL_27F;
						}
						if (base.n()[base.m() + 1] != 101 || base.n()[base.m() + 2] != 120 || base.n()[base.m() + 3] != 101 || base.n()[base.m() + 4] != 99)
						{
							goto IL_27F;
						}
						base.b(base.m() + 5);
						if (base.t() == 13)
						{
							base.b(base.m() + 1);
						}
						if (base.t() == 10)
						{
							base.b(base.m() + 1);
						}
						this.g = base.m();
					}
					else
					{
						int num = this.l();
						int num2 = num;
						if (num2 != 113047147)
						{
							if (num2 != 113166074)
							{
								if (num2 == 718598880)
								{
									this.f = base.r();
								}
							}
							else
							{
								base.b(base.m() + 1);
								base.q();
								this.b = base.s();
								this.e = base.s();
								this.c = base.s();
								this.d = base.s();
								base.b(base.m() + 1);
							}
						}
						else
						{
							base.b(base.m() + 1);
							int num3 = base.m();
							while (base.o() && base.t() > 32 && base.t() != 40 && base.t() != 60 && base.t() != 91 && base.t() != 123 && base.t() != 47 && base.t() != 37)
							{
								base.b(base.m() + 1);
							}
							this.a = Type1Font.p.GetString(base.n(), num3, base.m() - num3);
							base.q();
						}
					}
					continue;
					IL_27F:
					base.b(base.m() + 1);
				}
				base.b(base.n().Length - 11);
				int num4 = 0;
				while (base.m() > base.n().Length - 1040)
				{
					if (base.t() == 48)
					{
						num4++;
					}
					if (num4 == 512)
					{
						this.h = base.m() - this.g;
						break;
					}
					base.b(base.m() - 1);
				}
			}

			// Token: 0x060057C3 RID: 22467 RVA: 0x00330398 File Offset: 0x0032F398
			private void b()
			{
				while (base.o() && base.t() != 10 && base.t() != 13)
				{
					base.b(base.m() + 1);
				}
				base.q();
			}

			// Token: 0x060057C4 RID: 22468 RVA: 0x003303E8 File Offset: 0x0032F3E8
			internal int l()
			{
				base.b(base.m() + 1);
				return base.p();
			}

			// Token: 0x060057C5 RID: 22469 RVA: 0x00330410 File Offset: 0x0032F410
			private void a()
			{
				if (base.t() == 40)
				{
					int num = 1;
					base.b(base.m() + 1);
					while (base.o() && num > 0)
					{
						if (base.t() == 40 && base.n()[base.m() - 1] != 92)
						{
							num++;
						}
						else if (base.t() == 41 && base.n()[base.m() - 1] != 92)
						{
							num--;
						}
						base.b(base.m() + 1);
					}
				}
				else
				{
					while (base.o() && base.t() != 62)
					{
						base.b(base.m() + 1);
					}
				}
				base.b(base.m() + 1);
				base.q();
			}

			// Token: 0x04002E96 RID: 11926
			private string a;

			// Token: 0x04002E97 RID: 11927
			private int b;

			// Token: 0x04002E98 RID: 11928
			private int c;

			// Token: 0x04002E99 RID: 11929
			private int d;

			// Token: 0x04002E9A RID: 11930
			private int e;

			// Token: 0x04002E9B RID: 11931
			private float f;

			// Token: 0x04002E9C RID: 11932
			private int g = -1;

			// Token: 0x04002E9D RID: 11933
			private int h = -1;
		}
	}
}
