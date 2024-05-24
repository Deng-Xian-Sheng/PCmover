using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E4 RID: 2020
	public abstract class FormElement : TaggablePageElement
	{
		// Token: 0x060051CB RID: 20939 RVA: 0x0028B424 File Offset: 0x0028A424
		protected FormElement(string name, float x, float y, float width, float height)
		{
			this.e = name;
			this.a = x;
			this.b = x5.a(y);
			this.c = width;
			this.d = x5.a(height);
			base.d(3);
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x060051CC RID: 20940 RVA: 0x0028B4CC File Offset: 0x0028A4CC
		// (set) Token: 0x060051CD RID: 20941 RVA: 0x0028B4E4 File Offset: 0x0028A4E4
		public float X
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

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x060051CE RID: 20942 RVA: 0x0028B4F0 File Offset: 0x0028A4F0
		// (set) Token: 0x060051CF RID: 20943 RVA: 0x0028B50E File Offset: 0x0028A50E
		public float Y
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x060051D0 RID: 20944 RVA: 0x0028B520 File Offset: 0x0028A520
		// (set) Token: 0x060051D1 RID: 20945 RVA: 0x0028B538 File Offset: 0x0028A538
		public float Width
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

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x060051D2 RID: 20946 RVA: 0x0028B544 File Offset: 0x0028A544
		// (set) Token: 0x060051D3 RID: 20947 RVA: 0x0028B562 File Offset: 0x0028A562
		public float Height
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

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x060051D4 RID: 20948 RVA: 0x0028B574 File Offset: 0x0028A574
		// (set) Token: 0x060051D5 RID: 20949 RVA: 0x0028B58C File Offset: 0x0028A58C
		public int Rotate
		{
			get
			{
				return this.p;
			}
			set
			{
				if (value % 90 != 0)
				{
					throw new GeneratorException("Invalid rotation angle, should be multiple of 90.");
				}
				this.p = value;
			}
		}

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x060051D6 RID: 20950 RVA: 0x0028B5B8 File Offset: 0x0028A5B8
		// (set) Token: 0x060051D7 RID: 20951 RVA: 0x0028B5D0 File Offset: 0x0028A5D0
		public string Name
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

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x060051D8 RID: 20952 RVA: 0x0028B5DC File Offset: 0x0028A5DC
		// (set) Token: 0x060051D9 RID: 20953 RVA: 0x0028B5F4 File Offset: 0x0028A5F4
		public string ToolTip
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

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x060051DA RID: 20954 RVA: 0x0028B600 File Offset: 0x0028A600
		// (set) Token: 0x060051DB RID: 20955 RVA: 0x0028B618 File Offset: 0x0028A618
		public string MappingName
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

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x060051DC RID: 20956 RVA: 0x0028B624 File Offset: 0x0028A624
		// (set) Token: 0x060051DD RID: 20957 RVA: 0x0028B63C File Offset: 0x0028A63C
		public DeviceColor TextColor
		{
			get
			{
				return this.k;
			}
			set
			{
				if (value != null)
				{
					this.k = value;
				}
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x060051DE RID: 20958 RVA: 0x0028B65C File Offset: 0x0028A65C
		// (set) Token: 0x060051DF RID: 20959 RVA: 0x0028B674 File Offset: 0x0028A674
		public bool ReadOnly
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

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x060051E0 RID: 20960 RVA: 0x0028B680 File Offset: 0x0028A680
		// (set) Token: 0x060051E1 RID: 20961 RVA: 0x0028B698 File Offset: 0x0028A698
		public BorderStyle BorderStyle
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
				if (this.l == null)
				{
					this.l = Grayscale.Black;
				}
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x060051E2 RID: 20962 RVA: 0x0028B6C8 File Offset: 0x0028A6C8
		// (set) Token: 0x060051E3 RID: 20963 RVA: 0x0028B6E0 File Offset: 0x0028A6E0
		public DeviceColor BorderColor
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
				if (this.n == null)
				{
					this.n = BorderStyle.Solid;
				}
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x060051E4 RID: 20964 RVA: 0x0028B710 File Offset: 0x0028A710
		// (set) Token: 0x060051E5 RID: 20965 RVA: 0x0028B728 File Offset: 0x0028A728
		public RgbColor BackgroundColor
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

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x060051E6 RID: 20966 RVA: 0x0028B734 File Offset: 0x0028A734
		// (set) Token: 0x060051E7 RID: 20967 RVA: 0x0028B74C File Offset: 0x0028A74C
		public bool Visible
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

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x060051E8 RID: 20968 RVA: 0x0028B758 File Offset: 0x0028A758
		// (set) Token: 0x060051E9 RID: 20969 RVA: 0x0028B770 File Offset: 0x0028A770
		public bool Printable
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

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x060051EA RID: 20970 RVA: 0x0028B77C File Offset: 0x0028A77C
		public AnnotationReaderEvents ReaderEvents
		{
			get
			{
				AnnotationReaderEvents result;
				if (this.q == null)
				{
					this.q = new AnnotationReaderEvents();
					result = this.q;
				}
				else
				{
					result = this.q;
				}
				return result;
			}
		}

		// Token: 0x060051EB RID: 20971 RVA: 0x0028B7BC File Offset: 0x0028A7BC
		internal aco d()
		{
			if (this.i)
			{
				if (this.j)
				{
					this.o = aco.d;
				}
				else
				{
					this.o = aco.a;
				}
			}
			else if (this.j)
			{
				this.o = (aco)36;
			}
			else
			{
				this.o = aco.c;
			}
			return this.o;
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x060051EC RID: 20972 RVA: 0x0028B824 File Offset: 0x0028A824
		// (set) Token: 0x060051ED RID: 20973 RVA: 0x0028B83C File Offset: 0x0028A83C
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
					throw new GeneratorException("Tag cannot be Artifact for form elements");
				}
				base.Tag = value;
				this.r = false;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x060051EE RID: 20974 RVA: 0x0028B880 File Offset: 0x0028A880
		// (set) Token: 0x060051EF RID: 20975 RVA: 0x0028B898 File Offset: 0x0028A898
		public FormFieldOutput Output
		{
			get
			{
				return base.n();
			}
			set
			{
				base.a(value);
			}
		}

		// Token: 0x060051F0 RID: 20976 RVA: 0x0028B8A4 File Offset: 0x0028A8A4
		internal override x5 b7()
		{
			return this.b;
		}

		// Token: 0x060051F1 RID: 20977 RVA: 0x0028B8BC File Offset: 0x0028A8BC
		internal override x5 b8()
		{
			return x5.f(this.b, this.d);
		}

		// Token: 0x060051F2 RID: 20978 RVA: 0x0028B8E0 File Offset: 0x0028A8E0
		internal override byte cb()
		{
			return 64;
		}

		// Token: 0x060051F3 RID: 20979 RVA: 0x0028B8F4 File Offset: 0x0028A8F4
		internal void a(PageWriter A_0, Resource A_1)
		{
			if (A_0.Document.Tag != null)
			{
				if (this.Tag == null && this.r)
				{
					base.Tag = new StructureElement(TagType.Form, true);
					((StructureElement)this.Tag).Order = this.TagOrder;
				}
				if (this.i)
				{
					((StructureElement)this.Tag).a(A_0, this, A_1);
				}
			}
		}

		// Token: 0x060051F4 RID: 20980 RVA: 0x0028B97B File Offset: 0x0028A97B
		internal virtual void cf(PageWriter A_0)
		{
		}

		// Token: 0x04002BC2 RID: 11202
		private new float a;

		// Token: 0x04002BC3 RID: 11203
		private x5 b;

		// Token: 0x04002BC4 RID: 11204
		private float c;

		// Token: 0x04002BC5 RID: 11205
		private new x5 d;

		// Token: 0x04002BC6 RID: 11206
		private string e;

		// Token: 0x04002BC7 RID: 11207
		private string f = null;

		// Token: 0x04002BC8 RID: 11208
		private string g = null;

		// Token: 0x04002BC9 RID: 11209
		private bool h = false;

		// Token: 0x04002BCA RID: 11210
		private bool i = true;

		// Token: 0x04002BCB RID: 11211
		private bool j = true;

		// Token: 0x04002BCC RID: 11212
		private DeviceColor k = Grayscale.Black;

		// Token: 0x04002BCD RID: 11213
		private DeviceColor l = null;

		// Token: 0x04002BCE RID: 11214
		private RgbColor m = null;

		// Token: 0x04002BCF RID: 11215
		private BorderStyle n = null;

		// Token: 0x04002BD0 RID: 11216
		private new aco o = aco.d;

		// Token: 0x04002BD1 RID: 11217
		private int p = 0;

		// Token: 0x04002BD2 RID: 11218
		private AnnotationReaderEvents q;

		// Token: 0x04002BD3 RID: 11219
		private bool r = true;
	}
}
