using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E5 RID: 2021
	public class Signature : FormElement
	{
		// Token: 0x060051F5 RID: 20981 RVA: 0x0028B980 File Offset: 0x0028A980
		internal Signature(string A_0) : base(A_0, 0f, 0f, 0f, 0f)
		{
			base.BackgroundColor = RgbColor.White;
			base.Visible = false;
		}

		// Token: 0x060051F6 RID: 20982 RVA: 0x0028BA14 File Offset: 0x0028AA14
		public Signature(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
			base.BackgroundColor = RgbColor.White;
			base.Visible = true;
		}

		// Token: 0x060051F7 RID: 20983 RVA: 0x0028BA98 File Offset: 0x0028AA98
		internal int a()
		{
			int result;
			if (base.ReadOnly)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x060051F8 RID: 20984 RVA: 0x0028BAC0 File Offset: 0x0028AAC0
		internal dx a(string A_0, PageWriter A_1)
		{
			float a_ = 0f;
			float a_2 = 0f;
			float a_3 = 0f;
			float a_4 = 0f;
			int pageNumber = A_1.PageNumber;
			float a_5 = base.Y;
			float a_6 = base.X;
			if (base.Visible)
			{
				a_5 = A_1.Page.Dimensions.GetPdfY(base.Y);
				a_6 = A_1.Page.Dimensions.GetPdfX(base.X);
				if (base.Rotate % 360 == 90 || base.Rotate % 360 == 270)
				{
					a_3 = A_1.Dimensions.aw(base.X + base.Height);
					a_4 = A_1.Dimensions.ax(base.Y + base.Width);
					a_ = base.Width * A_1.Dimensions.a0();
					a_2 = base.Height * A_1.Dimensions.az();
				}
				else
				{
					a_3 = A_1.Dimensions.aw(base.X + base.Width);
					a_4 = A_1.Dimensions.ax(base.Y + base.Height);
					a_ = base.Width * A_1.Dimensions.az();
					a_2 = base.Height * A_1.Dimensions.a0();
				}
			}
			return new dx(A_0, this, a_, a_2, a_5, a_6, a_3, a_4, pageNumber, A_1.DocumentWriter);
		}

		// Token: 0x060051F9 RID: 20985 RVA: 0x0028BC48 File Offset: 0x0028AC48
		public override void Draw(PageWriter writer)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			dx dx = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				throw new GeneratorException("Form Field with the same name already exist.");
			}
			if (base.Output == FormFieldOutput.Retain || (base.Output == FormFieldOutput.Inherit && writer.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain) || (writer.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && writer.Document.d().Output == FormOutput.Retain))
			{
				formFieldList.Add(dx);
			}
			dx.Output = base.Output;
			if (base.Output == FormFieldOutput.Retain || (base.Output == FormFieldOutput.Inherit && writer.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain) || (writer.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && writer.Document.d().Output == FormOutput.Retain))
			{
				writer.Annotations.Add(dx);
			}
			base.a(writer, dx);
			dx.a((StructureElement)this.Tag);
		}

		// Token: 0x060051FA RID: 20986 RVA: 0x0028BDB0 File Offset: 0x0028ADB0
		internal override void cf(PageWriter A_0)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			dx dx = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is dx))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten)
				{
					dx.ce(A_0);
				}
			}
			else if (base.Output == FormFieldOutput.Inherit && A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain)
			{
				formFieldList.Add(dx);
				A_0.Annotations.Add(dx);
				base.a(A_0, dx);
				dx.a((StructureElement)this.Tag);
			}
			else if (base.Output == FormFieldOutput.Flatten || A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten || (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && A_0.Document.d().Output == FormOutput.Flatten))
			{
				dx.ce(A_0);
			}
		}

		// Token: 0x060051FB RID: 20987 RVA: 0x0028BF1C File Offset: 0x0028AF1C
		internal override byte cb()
		{
			return 64;
		}

		// Token: 0x060051FC RID: 20988 RVA: 0x0028BF30 File Offset: 0x0028AF30
		public void HideAllText()
		{
			this.e.HideAllText();
			this.f.HideAllText();
			this.g.HideAllText();
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x060051FD RID: 20989 RVA: 0x0028BF58 File Offset: 0x0028AF58
		// (set) Token: 0x060051FE RID: 20990 RVA: 0x0028BF70 File Offset: 0x0028AF70
		public SignaturePanelLayout PanelLayout
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

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x060051FF RID: 20991 RVA: 0x0028BF7C File Offset: 0x0028AF7C
		public SignaturePanel LeftPanel
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06005200 RID: 20992 RVA: 0x0028BF94 File Offset: 0x0028AF94
		public SignaturePanel RightPanel
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06005201 RID: 20993 RVA: 0x0028BFAC File Offset: 0x0028AFAC
		public SignaturePanel FullPanel
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06005202 RID: 20994 RVA: 0x0028BFC4 File Offset: 0x0028AFC4
		// (set) Token: 0x06005203 RID: 20995 RVA: 0x0028BFDC File Offset: 0x0028AFDC
		public string Reason
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

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x06005204 RID: 20996 RVA: 0x0028BFE8 File Offset: 0x0028AFE8
		// (set) Token: 0x06005205 RID: 20997 RVA: 0x0028C000 File Offset: 0x0028B000
		public string Location
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

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06005206 RID: 20998 RVA: 0x0028C00C File Offset: 0x0028B00C
		// (set) Token: 0x06005207 RID: 20999 RVA: 0x0028C024 File Offset: 0x0028B024
		public Font Font
		{
			get
			{
				return this.a;
			}
			set
			{
				if (value != null)
				{
					this.a = value;
				}
			}
		}

		// Token: 0x04002BD4 RID: 11220
		private new Font a = Font.Helvetica;

		// Token: 0x04002BD5 RID: 11221
		private string b = null;

		// Token: 0x04002BD6 RID: 11222
		private string c = null;

		// Token: 0x04002BD7 RID: 11223
		private new SignaturePanelLayout d = SignaturePanelLayout.Auto;

		// Token: 0x04002BD8 RID: 11224
		private SignaturePanel e = new SignaturePanel(false, true, false, false, false, false);

		// Token: 0x04002BD9 RID: 11225
		private SignaturePanel f = new SignaturePanel(true, false, true, true, true, true);

		// Token: 0x04002BDA RID: 11226
		private SignaturePanel g = new SignaturePanel(false, false, false, false, false, false);
	}
}
