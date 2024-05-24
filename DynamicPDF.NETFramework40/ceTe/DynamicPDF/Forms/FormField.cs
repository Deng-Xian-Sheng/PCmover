using System;
using System.Collections;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020003FA RID: 1018
	public class FormField : Resource
	{
		// Token: 0x06002A70 RID: 10864 RVA: 0x0018A9C0 File Offset: 0x001899C0
		internal FormField(string A_0) : this(A_0, FormFieldFlags.None, null)
		{
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0018A9D0 File Offset: 0x001899D0
		internal FormField(string A_0, FormFieldFlags A_1, AnnotationReaderEvents A_2)
		{
			this.e = A_0;
			this.aq = A_2;
			this.h = (int)A_1;
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06002A72 RID: 10866 RVA: 0x0018AA78 File Offset: 0x00189A78
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06002A73 RID: 10867 RVA: 0x0018AA8C File Offset: 0x00189A8C
		// (set) Token: 0x06002A74 RID: 10868 RVA: 0x0018AAA4 File Offset: 0x00189AA4
		protected bool IsAnnotation
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06002A75 RID: 10869 RVA: 0x0018AAB0 File Offset: 0x00189AB0
		public virtual bool HasValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06002A76 RID: 10870 RVA: 0x0018AAC4 File Offset: 0x00189AC4
		// (set) Token: 0x06002A77 RID: 10871 RVA: 0x0018AADB File Offset: 0x00189ADB
		public virtual string Value
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06002A78 RID: 10872 RVA: 0x0018AAE0 File Offset: 0x00189AE0
		public bool InheritsName
		{
			get
			{
				return this.e.Length == 0;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06002A79 RID: 10873 RVA: 0x0018AB00 File Offset: 0x00189B00
		public bool InheritsValue
		{
			get
			{
				return this.HasValue && this.InheritsName;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06002A7A RID: 10874 RVA: 0x0018AB24 File Offset: 0x00189B24
		// (set) Token: 0x06002A7B RID: 10875 RVA: 0x0018AB44 File Offset: 0x00189B44
		public bool IsReadOnly
		{
			get
			{
				return (this.h & 1) == 1;
			}
			set
			{
				if (value)
				{
					this.b(1);
				}
				else
				{
					this.d(1);
				}
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06002A7C RID: 10876 RVA: 0x0018AB6C File Offset: 0x00189B6C
		public FormFieldList ChildFields
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06002A7D RID: 10877 RVA: 0x0018AB84 File Offset: 0x00189B84
		[Obsolete("This property is obsolete. Instead use relevant flag name properties present on the PdfFormField class.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FormFieldFlags Flags
		{
			get
			{
				return (FormFieldFlags)this.h;
			}
		}

		// Token: 0x06002A7E RID: 10878 RVA: 0x0018AB9C File Offset: 0x00189B9C
		internal new void b(int A_0)
		{
			this.h |= A_0;
		}

		// Token: 0x06002A7F RID: 10879 RVA: 0x0018ABAD File Offset: 0x00189BAD
		internal new void d(int A_0)
		{
			this.h &= ~A_0;
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06002A80 RID: 10880 RVA: 0x0018ABC0 File Offset: 0x00189BC0
		public bool HasChildFields
		{
			get
			{
				return this.d != null && this.d.Count > 0;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06002A81 RID: 10881 RVA: 0x0018ABEC File Offset: 0x00189BEC
		public virtual string FullName
		{
			get
			{
				string result;
				if (this.c == null)
				{
					result = this.e;
				}
				else if (this.InheritsName)
				{
					result = this.c.FullName;
				}
				else
				{
					result = this.c.FullName + '.' + this.e;
				}
				return result;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06002A82 RID: 10882 RVA: 0x0018AC50 File Offset: 0x00189C50
		// (set) Token: 0x06002A83 RID: 10883 RVA: 0x0018AC68 File Offset: 0x00189C68
		public virtual string Name
		{
			get
			{
				return this.e;
			}
			set
			{
				if (this.c != null)
				{
					this.c.ChildFields.a(this.e, value);
				}
				this.e = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06002A84 RID: 10884 RVA: 0x0018ACA4 File Offset: 0x00189CA4
		// (set) Token: 0x06002A85 RID: 10885 RVA: 0x0018ACBC File Offset: 0x00189CBC
		public virtual string AlternateName
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

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06002A86 RID: 10886 RVA: 0x0018ACC8 File Offset: 0x00189CC8
		// (set) Token: 0x06002A87 RID: 10887 RVA: 0x0018ACE0 File Offset: 0x00189CE0
		public virtual string MappingName
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06002A88 RID: 10888 RVA: 0x0018ACEC File Offset: 0x00189CEC
		public FormField Parent
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06002A89 RID: 10889 RVA: 0x0018AD04 File Offset: 0x00189D04
		public Form Form
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06002A8A RID: 10890 RVA: 0x0018AD1C File Offset: 0x00189D1C
		public virtual BorderStyle BorderStyle
		{
			get
			{
				return this.ak;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06002A8B RID: 10891 RVA: 0x0018AD34 File Offset: 0x00189D34
		public virtual DeviceColor BorderColor
		{
			get
			{
				return this.ai;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06002A8C RID: 10892 RVA: 0x0018AD4C File Offset: 0x00189D4C
		public virtual RgbColor BackgroundColor
		{
			get
			{
				return this.aj;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06002A8D RID: 10893 RVA: 0x0018AD64 File Offset: 0x00189D64
		public virtual DeviceColor TextColor
		{
			get
			{
				return this.al;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06002A8E RID: 10894 RVA: 0x0018AD7C File Offset: 0x00189D7C
		public virtual int Rotate
		{
			get
			{
				return this.am;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06002A8F RID: 10895 RVA: 0x0018AD94 File Offset: 0x00189D94
		// (set) Token: 0x06002A90 RID: 10896 RVA: 0x0018ADAC File Offset: 0x00189DAC
		public virtual Font Font
		{
			get
			{
				return this.an;
			}
			set
			{
				this.an = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06002A91 RID: 10897 RVA: 0x0018ADB8 File Offset: 0x00189DB8
		// (set) Token: 0x06002A92 RID: 10898 RVA: 0x0018ADD0 File Offset: 0x00189DD0
		public virtual float FontSize
		{
			get
			{
				return this.ao;
			}
			set
			{
				this.ao = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06002A93 RID: 10899 RVA: 0x0018ADDC File Offset: 0x00189DDC
		// (set) Token: 0x06002A94 RID: 10900 RVA: 0x0018ADF4 File Offset: 0x00189DF4
		public bool UseSubstituteFont
		{
			get
			{
				return this.ap;
			}
			set
			{
				this.ap = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06002A96 RID: 10902 RVA: 0x0018AE9C File Offset: 0x00189E9C
		// (set) Token: 0x06002A95 RID: 10901 RVA: 0x0018AE00 File Offset: 0x00189E00
		public FormFieldOutput Output
		{
			get
			{
				return base.ag();
			}
			set
			{
				base.a(value);
				if (this.b != null)
				{
					this.b.b(true);
				}
				if (this.HasChildFields)
				{
					foreach (object obj in this.d)
					{
						FormField formField = (FormField)obj;
						formField.Output = value;
					}
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06002A97 RID: 10903 RVA: 0x0018AEB4 File Offset: 0x00189EB4
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.Annotation;
			}
		}

		// Token: 0x06002A98 RID: 10904 RVA: 0x0018AEC8 File Offset: 0x00189EC8
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			this.DrawDictionary(writer);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002A99 RID: 10905 RVA: 0x0018AEF0 File Offset: 0x00189EF0
		internal new void d(DocumentWriter A_0)
		{
			if (this.aq != null)
			{
				A_0.WriteName(FormField.x);
				A_0.WriteDictionaryOpen();
				if (this.aq.MouseDown != null)
				{
					A_0.WriteName(FormField.ac);
					if (this.aq.MouseDown.c() == 750795497 || this.aq.MouseDown.c() == 514009796)
					{
						A_0.WriteDictionaryOpen();
					}
					this.aq.MouseDown.Draw(A_0);
					if (this.aq.MouseDown.c() == 750795497 || this.aq.MouseDown.c() == 514009796)
					{
						A_0.WriteDictionaryClose();
					}
				}
				if (this.aq.MouseEnter != null)
				{
					A_0.WriteName(FormField.@as);
					this.aq.MouseEnter.Draw(A_0);
				}
				if (this.aq.MouseExit != null)
				{
					A_0.WriteName(FormField.at);
					if (this.aq.MouseExit.c() == 750795497 || this.aq.MouseExit.c() == 514009796)
					{
						A_0.WriteDictionaryOpen();
					}
					this.aq.MouseExit.Draw(A_0);
					if (this.aq.MouseExit.c() == 750795497 || this.aq.MouseExit.c() == 514009796)
					{
						A_0.WriteDictionaryClose();
					}
				}
				if (this.aq.MouseUp != null)
				{
					A_0.WriteName(FormField.ar);
					if (this.aq.MouseUp.c() == 750795497 || this.aq.MouseUp.c() == 514009796)
					{
						A_0.WriteDictionaryOpen();
					}
					this.aq.MouseUp.Draw(A_0);
					if (this.aq.MouseUp.c() == 750795497 || this.aq.MouseUp.c() == 514009796)
					{
						A_0.WriteDictionaryClose();
					}
				}
				if (this.aq.OnBlur != null)
				{
					A_0.WriteName(FormField.av);
					if (this.aq.OnBlur.c() == 750795497 || this.aq.OnBlur.c() == 514009796)
					{
						A_0.WriteDictionaryOpen();
					}
					this.aq.OnBlur.Draw(A_0);
					if (this.aq.OnBlur.c() == 750795497 || this.aq.OnBlur.c() == 514009796)
					{
						A_0.WriteDictionaryClose();
					}
				}
				if (this.aq.OnFocus != null)
				{
					A_0.WriteName(FormField.au);
					if (this.aq.OnFocus.c() == 750795497 || this.aq.OnFocus.c() == 514009796)
					{
						A_0.WriteDictionaryOpen();
					}
					this.aq.OnFocus.Draw(A_0);
					if (this.aq.OnFocus.c() == 750795497 || this.aq.OnFocus.c() == 514009796)
					{
						A_0.WriteDictionaryClose();
					}
				}
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06002A9A RID: 10906 RVA: 0x0018B2E8 File Offset: 0x0018A2E8
		internal new AnnotationReaderEvents e()
		{
			return this.aq;
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x0018B300 File Offset: 0x0018A300
		internal virtual ArrayList hd(ArrayList A_0)
		{
			return A_0;
		}

		// Token: 0x06002A9C RID: 10908 RVA: 0x0018B313 File Offset: 0x0018A313
		internal virtual void cd(DocumentWriter A_0)
		{
		}

		// Token: 0x06002A9D RID: 10909 RVA: 0x0018B316 File Offset: 0x0018A316
		internal virtual void hc(PageWriter A_0, int A_1)
		{
		}

		// Token: 0x06002A9E RID: 10910 RVA: 0x0018B319 File Offset: 0x0018A319
		internal virtual void ce(PageWriter A_0)
		{
		}

		// Token: 0x06002A9F RID: 10911 RVA: 0x0018B31C File Offset: 0x0018A31C
		protected virtual void DrawDictionary(DocumentWriter writer)
		{
			if (this.c != null)
			{
				writer.WriteName(FormField.i);
				writer.WriteReferenceShallow(writer.Resources.Add(this.c));
			}
			if (this.d.Count > 0)
			{
				writer.WriteName(FormField.j);
				writer.WriteArrayOpen();
				this.d.DrawKidReferences(writer);
				writer.WriteArrayClose();
			}
			if (!this.InheritsName)
			{
				if (this.e.Length > 0)
				{
					writer.WriteName(84);
					writer.WriteText(this.e);
				}
				if (this.f.Length > 0)
				{
					writer.WriteName(FormField.k);
					writer.WriteText(this.f);
				}
				if (this.g.Length > 0)
				{
					writer.WriteName(FormField.l);
					writer.WriteText(this.g);
				}
				int num = this.h;
				if (this.HasValue)
				{
					if (writer.Document.d().IsReadOnly)
					{
						num |= 1;
					}
				}
				if (num != 0)
				{
					writer.WriteName(FormField.m);
					writer.WriteNumber(num);
				}
			}
		}

		// Token: 0x06002AA0 RID: 10912 RVA: 0x0018B488 File Offset: 0x0018A488
		internal virtual PdfFormField hb()
		{
			return null;
		}

		// Token: 0x06002AA1 RID: 10913 RVA: 0x0018B49C File Offset: 0x0018A49C
		internal virtual bool he()
		{
			return false;
		}

		// Token: 0x06002AA2 RID: 10914 RVA: 0x0018B4B0 File Offset: 0x0018A4B0
		internal virtual bj cc()
		{
			return bj.d;
		}

		// Token: 0x06002AA3 RID: 10915 RVA: 0x0018B4C4 File Offset: 0x0018A4C4
		internal new void a(Form A_0, FormField A_1)
		{
			if (this.b != null)
			{
				throw new GeneratorException("Form field has already been added to a form.");
			}
			this.b = A_0;
			this.c = A_1;
			this.d = new FormFieldList(A_0, this);
		}

		// Token: 0x06002AA4 RID: 10916 RVA: 0x0018B505 File Offset: 0x0018A505
		internal new void f()
		{
			this.b = null;
			this.c = null;
			this.d = null;
			this.e = "";
		}

		// Token: 0x06002AA5 RID: 10917 RVA: 0x0018B528 File Offset: 0x0018A528
		internal override int b()
		{
			return this.af;
		}

		// Token: 0x06002AA6 RID: 10918 RVA: 0x0018B540 File Offset: 0x0018A540
		internal override void c(int A_0)
		{
			this.af = A_0;
		}

		// Token: 0x06002AA7 RID: 10919 RVA: 0x0018B54C File Offset: 0x0018A54C
		internal override bool d()
		{
			return this.ah;
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x0018B564 File Offset: 0x0018A564
		internal new StructureElement i()
		{
			return this.ag;
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x0018B57C File Offset: 0x0018A57C
		internal new void a(StructureElement A_0)
		{
			this.ag = A_0;
		}

		// Token: 0x06002AAA RID: 10922 RVA: 0x0018B586 File Offset: 0x0018A586
		internal new void a(bool A_0)
		{
			this.ah = A_0;
		}

		// Token: 0x0400137F RID: 4991
		private new bool a = false;

		// Token: 0x04001380 RID: 4992
		private new Form b = null;

		// Token: 0x04001381 RID: 4993
		private new FormField c = null;

		// Token: 0x04001382 RID: 4994
		private new FormFieldList d = null;

		// Token: 0x04001383 RID: 4995
		private new string e;

		// Token: 0x04001384 RID: 4996
		private new string f = string.Empty;

		// Token: 0x04001385 RID: 4997
		private new string g = string.Empty;

		// Token: 0x04001386 RID: 4998
		private new int h;

		// Token: 0x04001387 RID: 4999
		private new static byte[] i = new byte[]
		{
			80,
			97,
			114,
			101,
			110,
			116
		};

		// Token: 0x04001388 RID: 5000
		private static byte[] j = new byte[]
		{
			75,
			105,
			100,
			115
		};

		// Token: 0x04001389 RID: 5001
		private static byte[] k = new byte[]
		{
			84,
			85
		};

		// Token: 0x0400138A RID: 5002
		private static byte[] l = new byte[]
		{
			84,
			77
		};

		// Token: 0x0400138B RID: 5003
		private static byte[] m = new byte[]
		{
			70,
			102
		};

		// Token: 0x0400138C RID: 5004
		internal static byte[] n = new byte[]
		{
			70,
			84
		};

		// Token: 0x0400138D RID: 5005
		internal static byte[] o = new byte[]
		{
			65,
			80
		};

		// Token: 0x0400138E RID: 5006
		internal static byte[] p = new byte[]
		{
			65,
			83
		};

		// Token: 0x0400138F RID: 5007
		internal static byte[] q = new byte[]
		{
			65,
			110,
			110,
			111,
			116
		};

		// Token: 0x04001390 RID: 5008
		internal static byte[] r = new byte[]
		{
			87,
			105,
			100,
			103,
			101,
			116
		};

		// Token: 0x04001391 RID: 5009
		internal static byte[] s = new byte[]
		{
			82,
			101,
			99,
			116
		};

		// Token: 0x04001392 RID: 5010
		internal static byte[] t = new byte[]
		{
			77,
			75
		};

		// Token: 0x04001393 RID: 5011
		internal static byte[] u = new byte[]
		{
			66,
			67
		};

		// Token: 0x04001394 RID: 5012
		internal static byte[] v = new byte[]
		{
			66,
			71
		};

		// Token: 0x04001395 RID: 5013
		internal static byte[] w = new byte[]
		{
			68,
			86
		};

		// Token: 0x04001396 RID: 5014
		internal static byte[] x = new byte[]
		{
			65,
			65
		};

		// Token: 0x04001397 RID: 5015
		internal static byte y = 70;

		// Token: 0x04001398 RID: 5016
		internal static byte z = 80;

		// Token: 0x04001399 RID: 5017
		internal static byte aa = 82;

		// Token: 0x0400139A RID: 5018
		internal static byte ab = 78;

		// Token: 0x0400139B RID: 5019
		internal static byte ac = 68;

		// Token: 0x0400139C RID: 5020
		internal static byte ad = 86;

		// Token: 0x0400139D RID: 5021
		internal static byte[] ae = new byte[]
		{
			66,
			83
		};

		// Token: 0x0400139E RID: 5022
		private int af = -1;

		// Token: 0x0400139F RID: 5023
		private StructureElement ag = null;

		// Token: 0x040013A0 RID: 5024
		private bool ah = true;

		// Token: 0x040013A1 RID: 5025
		private DeviceColor ai = null;

		// Token: 0x040013A2 RID: 5026
		private RgbColor aj = null;

		// Token: 0x040013A3 RID: 5027
		private BorderStyle ak = null;

		// Token: 0x040013A4 RID: 5028
		private DeviceColor al = null;

		// Token: 0x040013A5 RID: 5029
		private int am = 0;

		// Token: 0x040013A6 RID: 5030
		private Font an;

		// Token: 0x040013A7 RID: 5031
		private float ao = float.MinValue;

		// Token: 0x040013A8 RID: 5032
		private bool ap = true;

		// Token: 0x040013A9 RID: 5033
		private AnnotationReaderEvents aq;

		// Token: 0x040013AA RID: 5034
		private static byte[] ar = new byte[]
		{
			85
		};

		// Token: 0x040013AB RID: 5035
		private static byte[] @as = new byte[]
		{
			69
		};

		// Token: 0x040013AC RID: 5036
		private static byte[] at = new byte[]
		{
			88
		};

		// Token: 0x040013AD RID: 5037
		private static byte[] au = new byte[]
		{
			70,
			111
		};

		// Token: 0x040013AE RID: 5038
		private static byte[] av = new byte[]
		{
			66,
			108
		};
	}
}
