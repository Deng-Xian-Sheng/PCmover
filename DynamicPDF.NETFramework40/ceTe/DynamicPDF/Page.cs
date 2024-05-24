using System;
using System.Collections;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020002A5 RID: 677
	public class Page
	{
		// Token: 0x06001E1F RID: 7711 RVA: 0x00130EC7 File Offset: 0x0012FEC7
		public Page() : this(Page.a())
		{
		}

		// Token: 0x06001E20 RID: 7712 RVA: 0x00130ED7 File Offset: 0x0012FED7
		public Page(PageSize size) : this(Page.a(size))
		{
		}

		// Token: 0x06001E21 RID: 7713 RVA: 0x00130EE8 File Offset: 0x0012FEE8
		public Page(PageSize size, PageOrientation orientation) : this(Page.a(size, orientation))
		{
		}

		// Token: 0x06001E22 RID: 7714 RVA: 0x00130EFA File Offset: 0x0012FEFA
		public Page(PageSize size, float margins) : this(Page.a(size, margins))
		{
		}

		// Token: 0x06001E23 RID: 7715 RVA: 0x00130F0C File Offset: 0x0012FF0C
		public Page(PageSize size, PageOrientation orientation, float margins) : this(Page.a(size, orientation, margins))
		{
		}

		// Token: 0x06001E24 RID: 7716 RVA: 0x00130F1F File Offset: 0x0012FF1F
		public Page(float width, float height) : this(Page.a(width, height))
		{
		}

		// Token: 0x06001E25 RID: 7717 RVA: 0x00130F31 File Offset: 0x0012FF31
		public Page(float width, float height, float margins) : this(Page.a(width, height, margins))
		{
		}

		// Token: 0x06001E26 RID: 7718 RVA: 0x00130F44 File Offset: 0x0012FF44
		public Page(PageDimensions dimensions)
		{
			this.a = dimensions;
			this.b = new Group();
		}

		// Token: 0x06001E27 RID: 7719 RVA: 0x00130F80 File Offset: 0x0012FF80
		internal virtual bool g9(DocumentWriter A_0, int A_1)
		{
			bool result;
			if (this.b.Count > 0)
			{
				result = true;
			}
			else
			{
				if (this.d)
				{
					if (A_0.Document.Template != null && A_0.Document.Template.HasPageElements(A_1))
					{
						return true;
					}
					if (A_0.Document.StampTemplate != null && A_0.Document.StampTemplate.HasPageElements(A_1))
					{
						return true;
					}
				}
				if (this.e)
				{
					if (A_0.CurrentSection != null && A_0.CurrentSection.Template != null && A_0.CurrentSection.Template.HasPageElements(A_1))
					{
						return true;
					}
					if (A_0.CurrentSection != null && A_0.CurrentSection.StampTemplate != null && A_0.CurrentSection.StampTemplate.HasPageElements(A_1))
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06001E28 RID: 7720 RVA: 0x00131094 File Offset: 0x00130094
		public Group Elements
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06001E29 RID: 7721 RVA: 0x001310AC File Offset: 0x001300AC
		// (set) Token: 0x06001E2A RID: 7722 RVA: 0x001310C4 File Offset: 0x001300C4
		public PageDimensions Dimensions
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06001E2B RID: 7723 RVA: 0x001310D0 File Offset: 0x001300D0
		// (set) Token: 0x06001E2C RID: 7724 RVA: 0x001310E8 File Offset: 0x001300E8
		public int Rotate
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06001E2D RID: 7725 RVA: 0x001310F4 File Offset: 0x001300F4
		// (set) Token: 0x06001E2E RID: 7726 RVA: 0x0013110C File Offset: 0x0013010C
		public bool ApplyDocumentTemplate
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06001E2F RID: 7727 RVA: 0x00131118 File Offset: 0x00130118
		// (set) Token: 0x06001E30 RID: 7728 RVA: 0x00131130 File Offset: 0x00130130
		public bool ApplySectionTemplate
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

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06001E31 RID: 7729 RVA: 0x0013113C File Offset: 0x0013013C
		public PageReaderEvents ReaderEvents
		{
			get
			{
				PageReaderEvents result;
				if (this.p == null)
				{
					this.p = new PageReaderEvents();
					result = this.p;
				}
				else
				{
					result = this.p;
				}
				return result;
			}
		}

		// Token: 0x06001E32 RID: 7730 RVA: 0x0013117C File Offset: 0x0013017C
		internal void a(DocumentWriter A_0, int A_1, int A_2, int A_3)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Page.f);
			A_0.WriteName(Page.g);
			A_0.WriteName(Page.h);
			A_0.WriteReferenceShallow(A_1);
			this.a.Draw(A_0);
			if (this.p != null)
			{
				this.p.a(A_0);
			}
			if (this.c != 0)
			{
				if (this.c % 90 != 0)
				{
					throw new GeneratorException("Page rotation must be a multiple of 90.");
				}
				A_0.WriteName(Page.i);
				A_0.WriteNumber(this.c);
			}
			this.ff(A_0, A_2, A_3);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06001E33 RID: 7731 RVA: 0x0013124C File Offset: 0x0013024C
		internal virtual void ff(DocumentWriter A_0, int A_1, int A_2)
		{
			PageResources pageResources = new PageResources();
			PageWriter pageWriter = new PageWriter(this, pageResources, A_0, A_0.u(), A_1, A_2);
			if (A_0.Document.j() != null && A_0.Document.Tag != null)
			{
				A_0.Document.RequireLicense(3);
				this.o = A_0.Document.k();
				A_0.Document.j().a(this.o, A_0.GetObjectNumber());
			}
			this.e9(pageWriter);
			this.b(pageWriter);
			if (A_0.Document.Pages.Count == A_1 && A_0.Document.i() != null && A_0.Document.i().Count > 0)
			{
				this.c(pageWriter);
			}
			A_0.Document.RequireLicense(pageWriter.r());
			if (A_0.Document.g())
			{
				pageWriter.i();
				pageWriter.f();
			}
			else
			{
				pageWriter.w();
			}
			A_0.WriteName(Page.j);
			A_0.WriteReferenceUnique(pageWriter);
			if (pageWriter.Document.Tag != null)
			{
				A_0.WriteName(Page.l);
				A_0.WriteName(Page.n);
			}
			if (pageWriter.Annotations.a() > 0)
			{
				A_0.WriteName(Page.k);
				A_0.WriteArrayOpen();
				pageWriter.Annotations.a(A_0);
				A_0.WriteArrayClose();
			}
			pageResources.Draw(A_0);
			if (pageWriter.l() || A_0.Document.Tag != null)
			{
				A_0.Document.a(this.o + 1);
				A_0.WriteName(Page.m);
				A_0.WriteNumber(this.o);
			}
			if (pageWriter.m() != null)
			{
				pageWriter.m().a(A_0);
			}
		}

		// Token: 0x06001E34 RID: 7732 RVA: 0x00131458 File Offset: 0x00130458
		internal virtual PdfPage fg()
		{
			return null;
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x0013146C File Offset: 0x0013046C
		internal virtual void e9(PageWriter A_0)
		{
			if (this.d && A_0.Document.Template != null)
			{
				if (A_0.Document.Template.j2() == 703119003)
				{
					((HeaderFooterTemplate)A_0.Document.Template).a(this.a);
				}
				A_0.Document.Template.Draw(A_0);
			}
			if (this.e && A_0.DocumentWriter.CurrentSection != null && A_0.DocumentWriter.CurrentSection.Template != null)
			{
				A_0.DocumentWriter.CurrentSection.Template.Draw(A_0);
			}
		}

		// Token: 0x06001E36 RID: 7734 RVA: 0x00131530 File Offset: 0x00130530
		internal void b(PageWriter A_0)
		{
			this.b.Draw(A_0);
			if (this.d && A_0.Document.StampTemplate != null)
			{
				if (A_0.Document.StampTemplate.j2() == 703119003)
				{
					((HeaderFooterTemplate)A_0.Document.StampTemplate).a(this.a);
				}
				A_0.Document.StampTemplate.Draw(A_0);
			}
			if (this.e && A_0.DocumentWriter.CurrentSection != null && A_0.DocumentWriter.CurrentSection.StampTemplate != null)
			{
				A_0.DocumentWriter.CurrentSection.StampTemplate.Draw(A_0);
			}
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x00131600 File Offset: 0x00130600
		internal void c(PageWriter A_0)
		{
			object obj = null;
			string key = null;
			using (IDictionaryEnumerator enumerator = A_0.Document.i().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					if (A_0.Document.Form.Fields[(string)dictionaryEntry.Key] == null)
					{
						if ((string)dictionaryEntry.Key == string.Empty)
						{
							string text = "Invisible";
							if (A_0.Document.Form.Fields[text] != null)
							{
								int num = 2;
								while (A_0.Document.Form.Fields[text + num.ToString()] != null)
								{
									num++;
								}
								text += num.ToString();
							}
							obj = dictionaryEntry.Value;
							key = text;
						}
					}
				}
			}
			if (obj != null)
			{
				A_0.Document.i().Remove(string.Empty);
				A_0.Document.i().Add(key, obj);
			}
			foreach (object obj2 in A_0.Document.i())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj2;
				if (A_0.Document.Form.Fields[(string)dictionaryEntry.Key] == null)
				{
					Signature signature = new Signature((string)dictionaryEntry.Key);
					signature.Output = FormFieldOutput.Retain;
					dx dx = signature.a(signature.Name, A_0);
					A_0.Document.Form.Fields.Add(dx);
					dx.Output = FormFieldOutput.Retain;
					A_0.Annotations.Add(dx);
				}
			}
		}

		// Token: 0x06001E38 RID: 7736 RVA: 0x0013186C File Offset: 0x0013086C
		private static PageDimensions a()
		{
			return new PageDimensions(PageSize.Letter);
		}

		// Token: 0x06001E39 RID: 7737 RVA: 0x00131888 File Offset: 0x00130888
		private static PageDimensions a(PageSize A_0)
		{
			return new PageDimensions(A_0);
		}

		// Token: 0x06001E3A RID: 7738 RVA: 0x001318A0 File Offset: 0x001308A0
		private static PageDimensions a(PageSize A_0, PageOrientation A_1)
		{
			return new PageDimensions(A_0, A_1);
		}

		// Token: 0x06001E3B RID: 7739 RVA: 0x001318BC File Offset: 0x001308BC
		private static PageDimensions a(PageSize A_0, float A_1)
		{
			return new PageDimensions(A_0, A_1);
		}

		// Token: 0x06001E3C RID: 7740 RVA: 0x001318D8 File Offset: 0x001308D8
		private static PageDimensions a(PageSize A_0, PageOrientation A_1, float A_2)
		{
			return new PageDimensions(A_0, A_1, A_2);
		}

		// Token: 0x06001E3D RID: 7741 RVA: 0x001318F4 File Offset: 0x001308F4
		private static PageDimensions a(float A_0, float A_1)
		{
			return new PageDimensions(A_0, A_1);
		}

		// Token: 0x06001E3E RID: 7742 RVA: 0x00131910 File Offset: 0x00130910
		private static PageDimensions a(float A_0, float A_1, float A_2)
		{
			return new PageDimensions(A_0, A_1, A_2);
		}

		// Token: 0x06001E3F RID: 7743 RVA: 0x0013192C File Offset: 0x0013092C
		internal virtual int f()
		{
			return this.o;
		}

		// Token: 0x06001E40 RID: 7744 RVA: 0x00131944 File Offset: 0x00130944
		internal virtual void a(int A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06001E41 RID: 7745 RVA: 0x00131950 File Offset: 0x00130950
		internal virtual bool ha()
		{
			return true;
		}

		// Token: 0x06001E42 RID: 7746 RVA: 0x00131964 File Offset: 0x00130964
		internal void b(int A_0)
		{
			if (this.fg() != null)
			{
				this.fg().b(A_0);
			}
		}

		// Token: 0x04000D51 RID: 3409
		private PageDimensions a;

		// Token: 0x04000D52 RID: 3410
		private Group b;

		// Token: 0x04000D53 RID: 3411
		private int c = 0;

		// Token: 0x04000D54 RID: 3412
		private bool d = true;

		// Token: 0x04000D55 RID: 3413
		private bool e = true;

		// Token: 0x04000D56 RID: 3414
		private static byte[] f = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x04000D57 RID: 3415
		private static byte[] g = new byte[]
		{
			80,
			97,
			103,
			101
		};

		// Token: 0x04000D58 RID: 3416
		private static byte[] h = new byte[]
		{
			80,
			97,
			114,
			101,
			110,
			116
		};

		// Token: 0x04000D59 RID: 3417
		private static byte[] i = new byte[]
		{
			82,
			111,
			116,
			97,
			116,
			101
		};

		// Token: 0x04000D5A RID: 3418
		internal static byte[] j = new byte[]
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

		// Token: 0x04000D5B RID: 3419
		internal static byte[] k = new byte[]
		{
			65,
			110,
			110,
			111,
			116,
			115
		};

		// Token: 0x04000D5C RID: 3420
		internal static byte[] l = new byte[]
		{
			84,
			97,
			98,
			115
		};

		// Token: 0x04000D5D RID: 3421
		internal static byte[] m = new byte[]
		{
			83,
			116,
			114,
			117,
			99,
			116,
			80,
			97,
			114,
			101,
			110,
			116,
			115
		};

		// Token: 0x04000D5E RID: 3422
		internal static byte n = 83;

		// Token: 0x04000D5F RID: 3423
		private int o = -1;

		// Token: 0x04000D60 RID: 3424
		private PageReaderEvents p;
	}
}
