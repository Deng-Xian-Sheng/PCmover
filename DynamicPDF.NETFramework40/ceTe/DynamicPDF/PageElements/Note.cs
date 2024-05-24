using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000735 RID: 1845
	public class Note : TaggablePageElement, IAnnotation, IArea, ICoordinate
	{
		// Token: 0x06004A35 RID: 18997 RVA: 0x0025ED5D File Offset: 0x0025DD5D
		public Note(string text, float x, float y, float width, float height) : this(text, x, y, width, height, NoteType.Note, false)
		{
		}

		// Token: 0x06004A36 RID: 18998 RVA: 0x0025ED71 File Offset: 0x0025DD71
		public Note(string text, float x, float y, float width, float height, NoteType type) : this(text, x, y, width, height, type, false)
		{
		}

		// Token: 0x06004A37 RID: 18999 RVA: 0x0025ED86 File Offset: 0x0025DD86
		public Note(string text, float x, float y, float width, float height, bool isOpen) : this(text, x, y, width, height, NoteType.Note, isOpen)
		{
		}

		// Token: 0x06004A38 RID: 19000 RVA: 0x0025ED9C File Offset: 0x0025DD9C
		public Note(string text, float x, float y, float width, float height, NoteType type, bool isOpen)
		{
			this.a = text;
			this.b = type;
			this.c = x;
			this.d = x5.a(y);
			this.e = width;
			this.f = x5.a(height);
			this.g = isOpen;
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06004A39 RID: 19001 RVA: 0x0025EE04 File Offset: 0x0025DE04
		// (set) Token: 0x06004A3A RID: 19002 RVA: 0x0025EE1C File Offset: 0x0025DE1C
		public float X
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06004A3B RID: 19003 RVA: 0x0025EE28 File Offset: 0x0025DE28
		// (set) Token: 0x06004A3C RID: 19004 RVA: 0x0025EE46 File Offset: 0x0025DE46
		public float Y
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06004A3D RID: 19005 RVA: 0x0025EE58 File Offset: 0x0025DE58
		// (set) Token: 0x06004A3E RID: 19006 RVA: 0x0025EE70 File Offset: 0x0025DE70
		public float Width
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

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06004A3F RID: 19007 RVA: 0x0025EE7C File Offset: 0x0025DE7C
		// (set) Token: 0x06004A40 RID: 19008 RVA: 0x0025EE9A File Offset: 0x0025DE9A
		public float Height
		{
			get
			{
				return x5.b(this.f);
			}
			set
			{
				this.f = x5.a(value);
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06004A41 RID: 19009 RVA: 0x0025EEAC File Offset: 0x0025DEAC
		// (set) Token: 0x06004A42 RID: 19010 RVA: 0x0025EEC4 File Offset: 0x0025DEC4
		public NoteType NoteType
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06004A43 RID: 19011 RVA: 0x0025EED0 File Offset: 0x0025DED0
		// (set) Token: 0x06004A44 RID: 19012 RVA: 0x0025EEE8 File Offset: 0x0025DEE8
		public string Text
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

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06004A45 RID: 19013 RVA: 0x0025EEF4 File Offset: 0x0025DEF4
		// (set) Token: 0x06004A46 RID: 19014 RVA: 0x0025EF0C File Offset: 0x0025DF0C
		public bool IsOpen
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

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06004A47 RID: 19015 RVA: 0x0025EF18 File Offset: 0x0025DF18
		// (set) Token: 0x06004A48 RID: 19016 RVA: 0x0025EF30 File Offset: 0x0025DF30
		public RgbColor Color
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06004A49 RID: 19017 RVA: 0x0025EF3C File Offset: 0x0025DF3C
		// (set) Token: 0x06004A4A RID: 19018 RVA: 0x0025EF54 File Offset: 0x0025DF54
		public override Tag Tag
		{
			get
			{
				return base.Tag;
			}
			set
			{
				if (value != null && value.TagType == TagType.a())
				{
					throw new GeneratorException("Tag cannot be Artifact for note");
				}
				base.Tag = value;
			}
		}

		// Token: 0x06004A4B RID: 19019 RVA: 0x0025EF90 File Offset: 0x0025DF90
		public override void Draw(PageWriter writer)
		{
			base.Draw(writer);
			float left = writer.Dimensions.aw(this.c);
			float top = writer.Dimensions.ax(x5.b(x5.f(this.d, this.f)));
			float right = writer.Dimensions.aw(this.c + this.e);
			float bottom = writer.Dimensions.ax(x5.b(this.d));
			Annotation annotation = new Annotation(left, top, right, bottom, this);
			writer.Annotations.Add(annotation);
			if (writer.Document.Tag != null)
			{
				if (this.Tag == null)
				{
					this.Tag = new StructureElement(TagType.Note, true);
					((StructureElement)this.Tag).Order = this.TagOrder;
				}
				annotation.a(this.Tag);
				((StructureElement)this.Tag).a(writer, this, annotation);
			}
		}

		// Token: 0x06004A4C RID: 19020 RVA: 0x0025F09C File Offset: 0x0025E09C
		public void DrawAnnotation(DocumentWriter writer)
		{
			writer.WriteName(Note.i);
			writer.WriteName(Note.j);
			writer.WriteName(Note.k);
			writer.WriteText(this.a);
			switch (this.b)
			{
			case NoteType.Comment:
				writer.WriteName(Note.l);
				writer.WriteName(Note.m);
				break;
			case NoteType.Help:
				writer.WriteName(Note.l);
				writer.WriteName(Note.n);
				break;
			case NoteType.Insert:
				writer.WriteName(Note.l);
				writer.WriteName(Note.o);
				break;
			case NoteType.Key:
				writer.WriteName(Note.l);
				writer.WriteName(Note.p);
				break;
			case NoteType.NewParagraph:
				writer.WriteName(Note.l);
				writer.WriteName(Note.q);
				break;
			case NoteType.Paragraph:
				writer.WriteName(Note.l);
				writer.WriteName(Note.r);
				break;
			}
			writer.WriteName(Note.s);
			writer.WriteArrayOpen();
			writer.WriteNumber1();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteArrayClose();
			if (this.h != null)
			{
				writer.WriteName(67);
				this.h.gr(writer);
			}
			if (this.g)
			{
				writer.WriteName(Note.t);
				writer.WriteBoolean(true);
			}
			writer.WriteName(FormField.y);
			writer.WriteNumber(4);
		}

		// Token: 0x06004A4D RID: 19021 RVA: 0x0025F234 File Offset: 0x0025E234
		internal override x5 b7()
		{
			return this.d;
		}

		// Token: 0x06004A4E RID: 19022 RVA: 0x0025F24C File Offset: 0x0025E24C
		internal override x5 b8()
		{
			return x5.f(this.d, this.f);
		}

		// Token: 0x06004A4F RID: 19023 RVA: 0x0025F270 File Offset: 0x0025E270
		internal override byte cb()
		{
			return 52;
		}

		// Token: 0x0400283E RID: 10302
		private new string a;

		// Token: 0x0400283F RID: 10303
		private NoteType b;

		// Token: 0x04002840 RID: 10304
		private float c;

		// Token: 0x04002841 RID: 10305
		private new x5 d;

		// Token: 0x04002842 RID: 10306
		private float e;

		// Token: 0x04002843 RID: 10307
		private x5 f;

		// Token: 0x04002844 RID: 10308
		private bool g = false;

		// Token: 0x04002845 RID: 10309
		private RgbColor h = null;

		// Token: 0x04002846 RID: 10310
		private static byte[] i = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x04002847 RID: 10311
		private static byte[] j = new byte[]
		{
			84,
			101,
			120,
			116
		};

		// Token: 0x04002848 RID: 10312
		private static byte[] k = new byte[]
		{
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			115
		};

		// Token: 0x04002849 RID: 10313
		private static byte[] l = new byte[]
		{
			78,
			97,
			109,
			101
		};

		// Token: 0x0400284A RID: 10314
		private static byte[] m = new byte[]
		{
			67,
			111,
			109,
			109,
			101,
			110,
			116
		};

		// Token: 0x0400284B RID: 10315
		private static byte[] n = new byte[]
		{
			72,
			101,
			108,
			112
		};

		// Token: 0x0400284C RID: 10316
		private new static byte[] o = new byte[]
		{
			73,
			110,
			115,
			101,
			114,
			116
		};

		// Token: 0x0400284D RID: 10317
		private static byte[] p = new byte[]
		{
			75,
			101,
			121
		};

		// Token: 0x0400284E RID: 10318
		private static byte[] q = new byte[]
		{
			78,
			101,
			119,
			80,
			97,
			114,
			97,
			103,
			114,
			97,
			112,
			104
		};

		// Token: 0x0400284F RID: 10319
		private static byte[] r = new byte[]
		{
			80,
			97,
			114,
			97,
			103,
			114,
			97,
			112,
			104
		};

		// Token: 0x04002850 RID: 10320
		private static byte[] s = new byte[]
		{
			66,
			111,
			114,
			100,
			101,
			114
		};

		// Token: 0x04002851 RID: 10321
		private static byte[] t = new byte[]
		{
			79,
			112,
			101,
			110
		};
	}
}
