using System;
using System.Globalization;
using System.Text;
using System.Threading;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006CD RID: 1741
	public class Form : Resource
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600433D RID: 17213 RVA: 0x0022EEA0 File Offset: 0x0022DEA0
		// (remove) Token: 0x0600433E RID: 17214 RVA: 0x0022EEDC File Offset: 0x0022DEDC
		public event FormFieldsAddedEventHandler FormFieldsAdded
		{
			add
			{
				FormFieldsAddedEventHandler formFieldsAddedEventHandler = this.ad;
				FormFieldsAddedEventHandler formFieldsAddedEventHandler2;
				do
				{
					formFieldsAddedEventHandler2 = formFieldsAddedEventHandler;
					FormFieldsAddedEventHandler value2 = (FormFieldsAddedEventHandler)Delegate.Combine(formFieldsAddedEventHandler2, value);
					formFieldsAddedEventHandler = Interlocked.CompareExchange<FormFieldsAddedEventHandler>(ref this.ad, value2, formFieldsAddedEventHandler2);
				}
				while (formFieldsAddedEventHandler != formFieldsAddedEventHandler2);
			}
			remove
			{
				FormFieldsAddedEventHandler formFieldsAddedEventHandler = this.ad;
				FormFieldsAddedEventHandler formFieldsAddedEventHandler2;
				do
				{
					formFieldsAddedEventHandler2 = formFieldsAddedEventHandler;
					FormFieldsAddedEventHandler value2 = (FormFieldsAddedEventHandler)Delegate.Remove(formFieldsAddedEventHandler2, value);
					formFieldsAddedEventHandler = Interlocked.CompareExchange<FormFieldsAddedEventHandler>(ref this.ad, value2, formFieldsAddedEventHandler2);
				}
				while (formFieldsAddedEventHandler != formFieldsAddedEventHandler2);
			}
		}

		// Token: 0x0600433F RID: 17215 RVA: 0x0022EF18 File Offset: 0x0022DF18
		internal Form()
		{
			this.k = new FormFieldList(this, null);
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06004340 RID: 17216 RVA: 0x0022EFE4 File Offset: 0x0022DFE4
		// (set) Token: 0x06004341 RID: 17217 RVA: 0x0022EFFC File Offset: 0x0022DFFC
		public Resource DefaultResources
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06004342 RID: 17218 RVA: 0x0022F008 File Offset: 0x0022E008
		// (set) Token: 0x06004343 RID: 17219 RVA: 0x0022F020 File Offset: 0x0022E020
		public string DefaultAppearance
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06004344 RID: 17220 RVA: 0x0022F02C File Offset: 0x0022E02C
		public Font DefaultFont
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06004345 RID: 17221 RVA: 0x0022F044 File Offset: 0x0022E044
		public float DefaultFontSize
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06004346 RID: 17222 RVA: 0x0022F05C File Offset: 0x0022E05C
		public DeviceColor DefaultColor
		{
			get
			{
				return this.i;
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06004347 RID: 17223 RVA: 0x0022F074 File Offset: 0x0022E074
		// (set) Token: 0x06004348 RID: 17224 RVA: 0x0022F08C File Offset: 0x0022E08C
		public Align Align
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
				switch (this.j)
				{
				case Align.Left:
					this.n = FormFieldAlign.Left;
					break;
				case Align.Center:
					this.n = FormFieldAlign.Center;
					break;
				case Align.Right:
					this.n = FormFieldAlign.Right;
					break;
				}
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06004349 RID: 17225 RVA: 0x0022F0D8 File Offset: 0x0022E0D8
		public FormFieldList Fields
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x0600434A RID: 17226 RVA: 0x0022F0F0 File Offset: 0x0022E0F0
		// (set) Token: 0x0600434B RID: 17227 RVA: 0x0022F108 File Offset: 0x0022E108
		public bool IsReadOnly
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x0600434C RID: 17228 RVA: 0x0022F114 File Offset: 0x0022E114
		public FormCalculationOrder CalculationOrder
		{
			get
			{
				return this.o;
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x0600434D RID: 17229 RVA: 0x0022F12C File Offset: 0x0022E12C
		// (set) Token: 0x0600434E RID: 17230 RVA: 0x0022F144 File Offset: 0x0022E144
		public FormFieldAlign DefaultAlign
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

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x0600434F RID: 17231 RVA: 0x0022F150 File Offset: 0x0022E150
		// (set) Token: 0x06004350 RID: 17232 RVA: 0x0022F168 File Offset: 0x0022E168
		public SignatureFlags SignatureFlags
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

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06004351 RID: 17233 RVA: 0x0022F174 File Offset: 0x0022E174
		// (set) Token: 0x06004352 RID: 17234 RVA: 0x0022F18C File Offset: 0x0022E18C
		public bool NeedsAppearances
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06004353 RID: 17235 RVA: 0x0022F198 File Offset: 0x0022E198
		// (set) Token: 0x06004354 RID: 17236 RVA: 0x0022F1B0 File Offset: 0x0022E1B0
		public bool ExcludeXfaDataIfValuesChanged
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06004355 RID: 17237 RVA: 0x0022F1BC File Offset: 0x0022E1BC
		// (set) Token: 0x06004356 RID: 17238 RVA: 0x0022F1D4 File Offset: 0x0022E1D4
		public Font SubstituteFont
		{
			get
			{
				return this.z;
			}
			set
			{
				this.z = value;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06004357 RID: 17239 RVA: 0x0022F1E0 File Offset: 0x0022E1E0
		// (set) Token: 0x06004358 RID: 17240 RVA: 0x0022F1F8 File Offset: 0x0022E1F8
		public FormOutput Output
		{
			get
			{
				return this.aa;
			}
			set
			{
				this.aa = value;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06004359 RID: 17241 RVA: 0x0022F204 File Offset: 0x0022E204
		// (set) Token: 0x0600435A RID: 17242 RVA: 0x0022F21C File Offset: 0x0022E21C
		public FormFieldOutput SignatureFieldsOutput
		{
			get
			{
				return this.ab;
			}
			set
			{
				this.ab = value;
			}
		}

		// Token: 0x0600435B RID: 17243 RVA: 0x0022F228 File Offset: 0x0022E228
		internal new bool a()
		{
			return this.q;
		}

		// Token: 0x0600435C RID: 17244 RVA: 0x0022F240 File Offset: 0x0022E240
		internal new void a(bool A_0)
		{
			this.q = A_0;
		}

		// Token: 0x0600435D RID: 17245 RVA: 0x0022F24A File Offset: 0x0022E24A
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			this.DrawDictionary(writer);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x0600435E RID: 17246 RVA: 0x0022F274 File Offset: 0x0022E274
		public TextFieldList GetTextFields()
		{
			return new TextFieldList(this);
		}

		// Token: 0x0600435F RID: 17247 RVA: 0x0022F28C File Offset: 0x0022E28C
		public void RequireLicense(int requiredLicenseLevel)
		{
			this.r |= requiredLicenseLevel;
		}

		// Token: 0x06004360 RID: 17248 RVA: 0x0022F2A0 File Offset: 0x0022E2A0
		protected virtual void DrawDictionary(DocumentWriter writer)
		{
			if (this.p)
			{
				writer.WriteName(Form.s);
				writer.WriteBoolean(true);
			}
			writer.WriteName(Form.t);
			writer.WriteArrayOpen();
			this.k.DrawKidReferences(writer);
			writer.WriteArrayClose();
			if (this.n != FormFieldAlign.Left)
			{
				writer.WriteName(81);
				writer.WriteNumber((int)this.n);
			}
			if (this.l != SignatureFlags.None)
			{
				writer.WriteName(Form.u);
				writer.WriteNumber((int)this.l);
			}
			if (writer.Document.d().Output == FormOutput.Retain)
			{
				if (this.o.Count > 0)
				{
					this.o.a(writer);
				}
			}
			if (this.e != null)
			{
				writer.WriteName(Form.v);
				writer.WriteReference(this.e);
			}
			if (this.f != null)
			{
				writer.WriteName(Form.w);
				if (this.c)
				{
					writer.WriteText(this.f);
				}
				else
				{
					this.b.hz(writer);
				}
			}
			if (this.d != null && ((this.y && !this.q) || !this.y))
			{
				if (!this.q && !this.p)
				{
					writer.WriteName(Form.x);
					this.d.hz(writer);
				}
				else
				{
					writer.WriteName(Form.x);
					this.a(writer);
				}
			}
		}

		// Token: 0x06004361 RID: 17249 RVA: 0x0022F468 File Offset: 0x0022E468
		private new void a(DocumentWriter A_0)
		{
			if (this.f())
			{
				afo afo = null;
				if (this.d.hy() == ag9.e)
				{
					abe abe = (abe)this.d;
					ab6 a_ = null;
					A_0.WriteArrayOpen();
					for (int i = 0; i < abe.a(); i++)
					{
						abe.a(i).hz(A_0);
						if (abe.a(i).hy() == ag9.c)
						{
							string text = ((ab7)abe.a(i)).kf();
							if (text != null)
							{
								if (!(text == "datasets"))
								{
									if (text == "template")
									{
										if (abe.a(i + 1).hy() == ag9.j)
										{
											a_ = (ab6)abe.a(i + 1);
										}
									}
								}
								else if (abe.a(i + 1).hy() == ag9.j)
								{
									afo = new afo((ab6)abe.a(i + 1), this.Fields);
									A_0.WriteReference(afo);
									i++;
								}
							}
						}
					}
					A_0.WriteArrayClose();
					if (afo != null)
					{
						afo.a(a_);
					}
				}
				else if (this.d.hy() == ag9.j)
				{
					ab6 a_ = (ab6)this.d;
					afo = new afo(a_, this.Fields);
					A_0.WriteReference(afo);
				}
			}
		}

		// Token: 0x06004362 RID: 17250 RVA: 0x0022F614 File Offset: 0x0022E614
		internal new bool c()
		{
			return this.ac;
		}

		// Token: 0x06004363 RID: 17251 RVA: 0x0022F62C File Offset: 0x0022E62C
		internal new void b(bool A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x06004364 RID: 17252 RVA: 0x0022F638 File Offset: 0x0022E638
		internal new yb e()
		{
			if (this.a == null)
			{
				this.a = new yb();
			}
			return this.a;
		}

		// Token: 0x06004365 RID: 17253 RVA: 0x0022F66C File Offset: 0x0022E66C
		internal new bool f()
		{
			return this.d != null;
		}

		// Token: 0x06004366 RID: 17254 RVA: 0x0022F690 File Offset: 0x0022E690
		internal new void i()
		{
			if (this.ad != null)
			{
				this.ad(this, new FormEventArgs(this));
			}
		}

		// Token: 0x06004367 RID: 17255 RVA: 0x0022F6C0 File Offset: 0x0022E6C0
		internal new void a(DocumentWriter A_0, Resource A_1)
		{
			if (A_1 != null)
			{
				if (this.e == null)
				{
					this.e = A_1;
				}
				else if (this.e != A_1)
				{
					A_0.WriteName(Form.v);
					A_0.WriteReference(A_1);
				}
			}
		}

		// Token: 0x06004368 RID: 17256 RVA: 0x0022F715 File Offset: 0x0022E715
		internal new void b(DocumentWriter A_0)
		{
			this.a(A_0, this.e());
		}

		// Token: 0x06004369 RID: 17257 RVA: 0x0022F728 File Offset: 0x0022E728
		internal new void a(DocumentWriter A_0, Font A_1, float A_2, DeviceColor A_3)
		{
			if (this.f == null)
			{
				this.c = true;
				this.e().a(this.g);
				this.f = this.a(this.g, this.h, this.i);
			}
			if (!this.c || A_1 != this.g || A_2 != this.h || !this.i.Equals(A_3))
			{
				A_0.WriteName(Form.w);
				A_0.WriteText(this.a(A_1, A_2, A_3));
			}
		}

		// Token: 0x0600436A RID: 17258 RVA: 0x0022F7D0 File Offset: 0x0022E7D0
		internal new void a(DocumentWriter A_0, ab7 A_1)
		{
			if (this.f == null)
			{
				this.c = false;
				if (A_1 != null)
				{
					A_0.WriteName(Form.w);
					A_1.hz(A_0);
				}
			}
			else if (A_1 != null && !(A_1.kf().Trim() == this.f))
			{
				A_0.WriteName(Form.w);
				A_1.hz(A_0);
			}
		}

		// Token: 0x0600436B RID: 17259 RVA: 0x0022F850 File Offset: 0x0022E850
		internal new void a(abd A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600436C RID: 17260 RVA: 0x0022F85C File Offset: 0x0022E85C
		internal new void a(PdfForm A_0)
		{
			if (this.f == null && this.e == null)
			{
				if (A_0.e() != null)
				{
					this.f = A_0.e().kf().Trim();
					this.b = A_0.e();
				}
				this.e = A_0.d();
			}
		}

		// Token: 0x0600436D RID: 17261 RVA: 0x0022F8C4 File Offset: 0x0022E8C4
		private new string a(Font A_0, float A_1, DeviceColor A_2)
		{
			StringBuilder stringBuilder = new StringBuilder("/");
			if (A_0 == null)
			{
				stringBuilder.Append(this.g.FormFontName);
			}
			else
			{
				stringBuilder.Append(A_0.FormFontName);
			}
			stringBuilder.Append(" ");
			if (A_1 >= 0f)
			{
				stringBuilder.Append(A_1.ToString(CultureInfo.InvariantCulture));
			}
			else
			{
				stringBuilder.Append(this.h);
			}
			stringBuilder.Append(" Tf ");
			if (A_2 == null)
			{
				this.i.ToStringBuilder(stringBuilder);
			}
			else
			{
				A_2.ToStringBuilder(stringBuilder);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04002565 RID: 9573
		private new yb a = null;

		// Token: 0x04002566 RID: 9574
		private new ab7 b = null;

		// Token: 0x04002567 RID: 9575
		private new bool c = false;

		// Token: 0x04002568 RID: 9576
		private new abd d = null;

		// Token: 0x04002569 RID: 9577
		private new Resource e = null;

		// Token: 0x0400256A RID: 9578
		private new string f = null;

		// Token: 0x0400256B RID: 9579
		private new Font g = Font.Helvetica;

		// Token: 0x0400256C RID: 9580
		private new float h = 12f;

		// Token: 0x0400256D RID: 9581
		private new DeviceColor i = Grayscale.Black;

		// Token: 0x0400256E RID: 9582
		private Align j;

		// Token: 0x0400256F RID: 9583
		private FormFieldList k;

		// Token: 0x04002570 RID: 9584
		private SignatureFlags l = SignatureFlags.None;

		// Token: 0x04002571 RID: 9585
		private bool m = false;

		// Token: 0x04002572 RID: 9586
		private FormFieldAlign n = FormFieldAlign.Left;

		// Token: 0x04002573 RID: 9587
		private FormCalculationOrder o = new FormCalculationOrder();

		// Token: 0x04002574 RID: 9588
		private bool p = false;

		// Token: 0x04002575 RID: 9589
		private bool q = false;

		// Token: 0x04002576 RID: 9590
		private int r = 0;

		// Token: 0x04002577 RID: 9591
		private static byte[] s = new byte[]
		{
			78,
			101,
			101,
			100,
			65,
			112,
			112,
			101,
			97,
			114,
			97,
			110,
			99,
			101,
			115
		};

		// Token: 0x04002578 RID: 9592
		private static byte[] t = new byte[]
		{
			70,
			105,
			101,
			108,
			100,
			115
		};

		// Token: 0x04002579 RID: 9593
		private static byte[] u = new byte[]
		{
			83,
			105,
			103,
			70,
			108,
			97,
			103,
			115
		};

		// Token: 0x0400257A RID: 9594
		internal static byte[] v = new byte[]
		{
			68,
			82
		};

		// Token: 0x0400257B RID: 9595
		internal static byte[] w = new byte[]
		{
			68,
			65
		};

		// Token: 0x0400257C RID: 9596
		internal static byte[] x = new byte[]
		{
			88,
			70,
			65
		};

		// Token: 0x0400257D RID: 9597
		private bool y = false;

		// Token: 0x0400257E RID: 9598
		private Font z = Font.Helvetica;

		// Token: 0x0400257F RID: 9599
		private FormOutput aa = FormOutput.Retain;

		// Token: 0x04002580 RID: 9600
		private FormFieldOutput ab = FormFieldOutput.Inherit;

		// Token: 0x04002581 RID: 9601
		private bool ac = false;

		// Token: 0x04002582 RID: 9602
		private FormFieldsAddedEventHandler ad;
	}
}
