using System;
using System.IO;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text.OpenTypeFontTables;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000866 RID: 2150
	public class OpenTypeFont : Font, IFontSubsettable, IDisposable
	{
		// Token: 0x06005713 RID: 22291 RVA: 0x002EBF7C File Offset: 0x002EAF7C
		public OpenTypeFont(string filePath) : this(filePath, false)
		{
		}

		// Token: 0x06005714 RID: 22292 RVA: 0x002EBF89 File Offset: 0x002EAF89
		public OpenTypeFont(string filePath, bool useCharacterShaping) : this(filePath, LineBreaker.Latin, useCharacterShaping)
		{
		}

		// Token: 0x06005715 RID: 22293 RVA: 0x002EBF9B File Offset: 0x002EAF9B
		public OpenTypeFont(string filePath, LineBreaker lineBreaker) : this(filePath, lineBreaker, false)
		{
		}

		// Token: 0x06005716 RID: 22294 RVA: 0x002EBFAC File Offset: 0x002EAFAC
		public OpenTypeFont(string filePath, LineBreaker lineBreaker, bool useCharacterShaping)
		{
			this.e = false;
			base..ctor(new r5());
			this.a = lineBreaker;
			this.b = (r5)base.Encoder;
			this.b.b(useCharacterShaping);
			if (File.Exists(filePath))
			{
				this.d = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
			}
			else
			{
				string path = Path.Combine(GlobalSettings.PathToFontsResourceDirectory, Path.GetFileName(filePath));
				if (File.Exists(path))
				{
					this.d = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
				}
			}
			if (this.d == null)
			{
				throw new GeneratorException("Opentype font file could not be found.");
			}
			this.a(useCharacterShaping);
			this.d.Close();
			if (useCharacterShaping)
			{
				this.b.a(this.c.ad());
			}
		}

		// Token: 0x06005717 RID: 22295 RVA: 0x002EC094 File Offset: 0x002EB094
		public OpenTypeFont(Stream reader, LineBreaker lineBreaker) : this(reader, lineBreaker, false)
		{
		}

		// Token: 0x06005718 RID: 22296 RVA: 0x002EC0A4 File Offset: 0x002EB0A4
		public OpenTypeFont(Stream reader, LineBreaker lineBreaker, bool useCharacterShaping)
		{
			this.e = false;
			base..ctor(new r5());
			this.a = lineBreaker;
			this.b = (r5)base.Encoder;
			this.b.b(useCharacterShaping);
			this.d = reader;
			this.a(useCharacterShaping);
			if (useCharacterShaping)
			{
				this.b.a(this.c.ad());
			}
		}

		// Token: 0x06005719 RID: 22297 RVA: 0x002EC11B File Offset: 0x002EB11B
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600571A RID: 22298 RVA: 0x002EC130 File Offset: 0x002EB130
		~OpenTypeFont()
		{
			this.Dispose(false);
		}

		// Token: 0x0600571B RID: 22299 RVA: 0x002EC164 File Offset: 0x002EB164
		protected virtual void Dispose(bool disposing)
		{
			if (!this.e)
			{
				if (this.b != null)
				{
					this.b.Dispose();
					this.b = null;
				}
				this.e = true;
			}
		}

		// Token: 0x0600571C RID: 22300 RVA: 0x002EC1A7 File Offset: 0x002EB1A7
		private new void a(bool A_0)
		{
			this.c = ad1.a(this.d, A_0);
			this.b.a(this.c);
		}

		// Token: 0x0600571D RID: 22301 RVA: 0x002EC1CE File Offset: 0x002EB1CE
		public override void Draw(DocumentWriter writer)
		{
			this.c.jq(writer, this);
		}

		// Token: 0x0600571E RID: 22302 RVA: 0x002EC1E0 File Offset: 0x002EB1E0
		public override short GetGlyphWidth(char glyph)
		{
			return this.c.x().a()[(int)this.c.w().b()[(int)glyph]];
		}

		// Token: 0x0600571F RID: 22303 RVA: 0x002EC218 File Offset: 0x002EB218
		internal override short jf(agc A_0)
		{
			return this.c.x().a()[A_0.a()];
		}

		// Token: 0x06005720 RID: 22304 RVA: 0x002EC244 File Offset: 0x002EB244
		public FontSubsetter GetFontSubsetter()
		{
			return new FontSubsetter(this.c.aa().a());
		}

		// Token: 0x06005721 RID: 22305 RVA: 0x002EC26C File Offset: 0x002EB26C
		public override bool HasKerning()
		{
			return this.c.ab() != null && this.c.ab().a() != null && this.c.ab().a().Length > 0;
		}

		// Token: 0x06005722 RID: 22306 RVA: 0x002EC2C4 File Offset: 0x002EB2C4
		public override float GetKernValue(char left, char right)
		{
			return this.c.a(left, right);
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06005723 RID: 22307 RVA: 0x002EC2E4 File Offset: 0x002EB2E4
		public override LineBreaker LineBreaker
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06005724 RID: 22308 RVA: 0x002EC2FC File Offset: 0x002EB2FC
		public override string Name
		{
			get
			{
				return this.c.u().a();
			}
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06005725 RID: 22309 RVA: 0x002EC320 File Offset: 0x002EB320
		public override int RequiredPdfObjects
		{
			get
			{
				return this.c.c() ? 9 : 5;
			}
		}

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06005726 RID: 22310 RVA: 0x002EC348 File Offset: 0x002EB348
		public override ResourceType ResourceType
		{
			get
			{
				return base.ResourceType;
			}
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06005727 RID: 22311 RVA: 0x002EC360 File Offset: 0x002EB360
		public override short LineGap
		{
			get
			{
				return this.c.t();
			}
		}

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x06005728 RID: 22312 RVA: 0x002EC380 File Offset: 0x002EB380
		public override short Ascender
		{
			get
			{
				return this.c.f();
			}
		}

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x06005729 RID: 22313 RVA: 0x002EC3A0 File Offset: 0x002EB3A0
		public override short Descender
		{
			get
			{
				return this.c.g();
			}
		}

		// Token: 0x0600572A RID: 22314 RVA: 0x002EC3C0 File Offset: 0x002EB3C0
		internal override short jg()
		{
			return this.c.j();
		}

		// Token: 0x0600572B RID: 22315 RVA: 0x002EC3E0 File Offset: 0x002EB3E0
		internal override short jh()
		{
			return this.c.k();
		}

		// Token: 0x0600572C RID: 22316 RVA: 0x002EC400 File Offset: 0x002EB400
		internal override short ji()
		{
			return this.c.l();
		}

		// Token: 0x0600572D RID: 22317 RVA: 0x002EC420 File Offset: 0x002EB420
		internal override short jj()
		{
			return this.c.m();
		}

		// Token: 0x0600572E RID: 22318 RVA: 0x002EC440 File Offset: 0x002EB440
		internal override short jk()
		{
			return this.c.n();
		}

		// Token: 0x0600572F RID: 22319 RVA: 0x002EC460 File Offset: 0x002EB460
		internal override short jl()
		{
			return this.c.o();
		}

		// Token: 0x06005730 RID: 22320 RVA: 0x002EC480 File Offset: 0x002EB480
		internal override short jm()
		{
			return this.c.p();
		}

		// Token: 0x06005731 RID: 22321 RVA: 0x002EC4A0 File Offset: 0x002EB4A0
		internal override short jn()
		{
			return this.c.q();
		}

		// Token: 0x06005732 RID: 22322 RVA: 0x002EC4C0 File Offset: 0x002EB4C0
		internal override short bc()
		{
			return this.c.i();
		}

		// Token: 0x06005733 RID: 22323 RVA: 0x002EC4E0 File Offset: 0x002EB4E0
		internal override short bd()
		{
			return this.c.h();
		}

		// Token: 0x06005734 RID: 22324 RVA: 0x002EC500 File Offset: 0x002EB500
		internal override short be()
		{
			return this.c.r();
		}

		// Token: 0x06005735 RID: 22325 RVA: 0x002EC520 File Offset: 0x002EB520
		internal override short bf()
		{
			return this.c.s();
		}

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06005736 RID: 22326 RVA: 0x002EC540 File Offset: 0x002EB540
		// (set) Token: 0x06005737 RID: 22327 RVA: 0x002EC55D File Offset: 0x002EB55D
		public bool Embed
		{
			get
			{
				return this.c.c();
			}
			set
			{
				this.c.a(value);
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06005738 RID: 22328 RVA: 0x002EC570 File Offset: 0x002EB570
		// (set) Token: 0x06005739 RID: 22329 RVA: 0x002EC58D File Offset: 0x002EB58D
		public bool Subset
		{
			get
			{
				return this.c.d();
			}
			set
			{
				this.c.b(value);
			}
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x0600573A RID: 22330 RVA: 0x002EC5A0 File Offset: 0x002EB5A0
		public OutLineType OutLineType
		{
			get
			{
				return this.c.jr();
			}
		}

		// Token: 0x0600573B RID: 22331 RVA: 0x002EC5C0 File Offset: 0x002EB5C0
		internal new ad1 a()
		{
			return this.c;
		}

		// Token: 0x0600573C RID: 22332 RVA: 0x002EC5D8 File Offset: 0x002EB5D8
		internal override string bg()
		{
			return Encoding.ASCII.GetString(this.c.js()) + this.Name;
		}

		// Token: 0x0600573D RID: 22333 RVA: 0x002EC60C File Offset: 0x002EB60C
		internal override short bh()
		{
			return this.c.z().e();
		}

		// Token: 0x0600573E RID: 22334 RVA: 0x002EC630 File Offset: 0x002EB630
		internal override short bi()
		{
			return this.c.z().c();
		}

		// Token: 0x0600573F RID: 22335 RVA: 0x002EC654 File Offset: 0x002EB654
		internal override bool jo()
		{
			return true;
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x06005740 RID: 22336 RVA: 0x002EC668 File Offset: 0x002EB668
		public bool UseCharacterShaping
		{
			get
			{
				return this.b.a();
			}
		}

		// Token: 0x04002E5D RID: 11869
		private new LineBreaker a;

		// Token: 0x04002E5E RID: 11870
		private new r5 b;

		// Token: 0x04002E5F RID: 11871
		private new ad1 c;

		// Token: 0x04002E60 RID: 11872
		private new Stream d;

		// Token: 0x04002E61 RID: 11873
		private new bool e;
	}
}
