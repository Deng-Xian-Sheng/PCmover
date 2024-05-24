using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007F3 RID: 2035
	public class SubmitAction : OutlineAnnotationAction
	{
		// Token: 0x0600529D RID: 21149 RVA: 0x0028E691 File Offset: 0x0028D691
		public SubmitAction(string url)
		{
			this.a = url;
		}

		// Token: 0x0600529E RID: 21150 RVA: 0x0028E6AA File Offset: 0x0028D6AA
		public SubmitAction(string url, FormExportFormat exportFormat)
		{
			this.a = url;
			this.ExportFormat = exportFormat;
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x0600529F RID: 21151 RVA: 0x0028E6CC File Offset: 0x0028D6CC
		// (set) Token: 0x060052A0 RID: 21152 RVA: 0x0028E6E4 File Offset: 0x0028D6E4
		public string Url
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

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x060052A1 RID: 21153 RVA: 0x0028E6F0 File Offset: 0x0028D6F0
		// (set) Token: 0x060052A2 RID: 21154 RVA: 0x0028E708 File Offset: 0x0028D708
		public FormExportFormat ExportFormat
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
				switch (value)
				{
				case FormExportFormat.HtmlGet:
					this.c = (acn)12;
					break;
				case FormExportFormat.FDF:
					this.c = (acn)0;
					break;
				case FormExportFormat.XML:
					this.c = acn.c;
					break;
				case FormExportFormat.PDF:
					this.c = acn.d;
					break;
				default:
					this.c = acn.a;
					break;
				}
			}
		}

		// Token: 0x060052A3 RID: 21155 RVA: 0x0028E76C File Offset: 0x0028D76C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteDictionaryOpen();
			writer.WriteName(70);
			writer.WriteDictionaryOpen();
			writer.WriteName(70);
			writer.WriteText(this.a);
			writer.WriteName(SubmitAction.e);
			writer.WriteName(SubmitAction.f);
			writer.WriteDictionaryClose();
			if (this.c > (acn)0)
			{
				writer.WriteName(SubmitAction.g);
				writer.WriteNumber((int)this.c);
			}
			writer.WriteName(Action.c);
			writer.WriteName(SubmitAction.d);
			if (base.NextAction != null)
			{
				writer.WriteName(Action.d);
				base.NextAction.Draw(writer);
			}
			writer.WriteDictionaryClose();
		}

		// Token: 0x04002C24 RID: 11300
		private new string a;

		// Token: 0x04002C25 RID: 11301
		private new FormExportFormat b;

		// Token: 0x04002C26 RID: 11302
		private new acn c = acn.a;

		// Token: 0x04002C27 RID: 11303
		private new static byte[] d = new byte[]
		{
			83,
			117,
			98,
			109,
			105,
			116,
			70,
			111,
			114,
			109
		};

		// Token: 0x04002C28 RID: 11304
		private static byte[] e = new byte[]
		{
			70,
			83
		};

		// Token: 0x04002C29 RID: 11305
		private static byte[] f = new byte[]
		{
			85,
			82,
			76
		};

		// Token: 0x04002C2A RID: 11306
		private static byte[] g = new byte[]
		{
			70,
			108,
			97,
			103,
			115
		};
	}
}
