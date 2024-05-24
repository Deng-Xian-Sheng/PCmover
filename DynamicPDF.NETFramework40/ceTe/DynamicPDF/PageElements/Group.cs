using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000718 RID: 1816
	public class Group : PageElement, IEnumerable, IPageElementContainer
	{
		// Token: 0x06004828 RID: 18472 RVA: 0x002551EE File Offset: 0x002541EE
		public Group()
		{
			base.o();
		}

		// Token: 0x1700049A RID: 1178
		public PageElement this[string id]
		{
			get
			{
				this.a();
				return (PageElement)this.c[id];
			}
		}

		// Token: 0x1700049B RID: 1179
		public PageElement this[int index]
		{
			get
			{
				this.c();
				return (PageElement)this.a[index];
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x0600482B RID: 18475 RVA: 0x00255274 File Offset: 0x00254274
		public int Count
		{
			get
			{
				int result;
				if (this.a == null)
				{
					result = 0;
				}
				else
				{
					result = this.a.Count;
				}
				return result;
			}
		}

		// Token: 0x0600482C RID: 18476 RVA: 0x002552A8 File Offset: 0x002542A8
		public override void Draw(PageWriter writer)
		{
			if (this.a != null)
			{
				bool flag = false;
				if (writer.DocumentWriter.Document.d().Output != FormOutput.Retain)
				{
					flag = true;
				}
				else
				{
					foreach (object obj in this.a)
					{
						PageElement pageElement = (PageElement)obj;
						if (pageElement.n() == FormFieldOutput.Flatten || pageElement.n() == FormFieldOutput.Remove)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					List<FormElement> list = new List<FormElement>();
					bool flag2 = false;
					foreach (object obj2 in this.a)
					{
						PageElement pageElement = (PageElement)obj2;
						if (pageElement.cb() == 64)
						{
							list.Add((FormElement)pageElement);
						}
						else
						{
							if (!flag2)
							{
								writer.Write_q_(true);
								flag2 = true;
							}
							writer.RequireLicense(pageElement.RequiredLicenseLevel);
							pageElement.Draw(writer);
							writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
						}
					}
					if (flag2)
					{
						writer.Write_Q(true);
					}
					foreach (FormElement formElement in list)
					{
						switch (formElement.Output)
						{
						case FormFieldOutput.Flatten:
							writer.RequireLicense(formElement.RequiredLicenseLevel);
							formElement.cf(writer);
							writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
							break;
						case FormFieldOutput.Remove:
							writer.RequireLicense(formElement.RequiredLicenseLevel);
							break;
						case FormFieldOutput.Retain:
							writer.RequireLicense(formElement.RequiredLicenseLevel);
							formElement.Draw(writer);
							writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
							break;
						case FormFieldOutput.Inherit:
							if (formElement is Signature)
							{
								switch (writer.DocumentWriter.Document.d().SignatureFieldsOutput)
								{
								case FormFieldOutput.Flatten:
									writer.RequireLicense(formElement.RequiredLicenseLevel);
									formElement.cf(writer);
									writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
									break;
								case FormFieldOutput.Remove:
									writer.RequireLicense(formElement.RequiredLicenseLevel);
									break;
								case FormFieldOutput.Retain:
									writer.RequireLicense(formElement.RequiredLicenseLevel);
									formElement.Draw(writer);
									writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
									break;
								case FormFieldOutput.Inherit:
									switch (writer.DocumentWriter.Document.d().Output)
									{
									case FormOutput.Flatten:
										writer.RequireLicense(formElement.RequiredLicenseLevel);
										formElement.cf(writer);
										writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
										break;
									case FormOutput.Remove:
										writer.RequireLicense(formElement.RequiredLicenseLevel);
										break;
									case FormOutput.Retain:
										writer.RequireLicense(formElement.RequiredLicenseLevel);
										formElement.Draw(writer);
										writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
										break;
									}
									break;
								}
							}
							else
							{
								switch (writer.DocumentWriter.Document.d().Output)
								{
								case FormOutput.Flatten:
									writer.RequireLicense(formElement.RequiredLicenseLevel);
									formElement.cf(writer);
									writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
									break;
								case FormOutput.Remove:
									writer.RequireLicense(formElement.RequiredLicenseLevel);
									break;
								case FormOutput.Retain:
									writer.RequireLicense(formElement.RequiredLicenseLevel);
									formElement.Draw(writer);
									writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
									break;
								}
							}
							break;
						}
					}
				}
				else
				{
					foreach (object obj3 in this.a)
					{
						PageElement pageElement = (PageElement)obj3;
						if (this.d)
						{
							if (!(pageElement is Image) && !(pageElement is FormattedTextArea))
							{
								writer.RequireLicense(pageElement.RequiredLicenseLevel);
							}
						}
						else
						{
							writer.RequireLicense(pageElement.RequiredLicenseLevel);
						}
						pageElement.Draw(writer);
						writer.DocumentWriter.i(writer.DocumentWriter.ae() + 1);
					}
				}
			}
		}

		// Token: 0x0600482D RID: 18477 RVA: 0x00255858 File Offset: 0x00254858
		public void Insert(int index, PageElement pageElement)
		{
			this.c();
			this.a.Insert(index, pageElement);
			if (this.c != null && pageElement.ID != null && pageElement.ID.Length > 0)
			{
				this.c[pageElement.ID] = pageElement;
			}
			if (pageElement is IPageElementContainer)
			{
				this.b();
				this.b.Add((IPageElementContainer)pageElement);
			}
		}

		// Token: 0x0600482E RID: 18478 RVA: 0x002558E4 File Offset: 0x002548E4
		public void Add(PageElement pageElement)
		{
			this.c();
			this.a.Add(pageElement);
			if (this.c != null && pageElement.ID != null && pageElement.ID.Length > 0)
			{
				this.c[pageElement.ID] = pageElement;
			}
			if (pageElement is IPageElementContainer)
			{
				this.b();
				this.b.Add((IPageElementContainer)pageElement);
			}
		}

		// Token: 0x0600482F RID: 18479 RVA: 0x00255970 File Offset: 0x00254970
		public IEnumerator GetEnumerator()
		{
			this.c();
			return this.a.GetEnumerator();
		}

		// Token: 0x06004830 RID: 18480 RVA: 0x00255994 File Offset: 0x00254994
		public PageElement GetPageElementByID(string id)
		{
			PageElement result;
			if (this.a == null)
			{
				result = null;
			}
			else
			{
				this.a();
				PageElement pageElement = (PageElement)this.c[id];
				if (pageElement == null && this.b != null)
				{
					foreach (object obj in this.b)
					{
						IPageElementContainer pageElementContainer = (IPageElementContainer)obj;
						pageElement = pageElementContainer.GetPageElementByID(id);
						if (pageElement != null)
						{
							break;
						}
					}
				}
				result = pageElement;
			}
			return result;
		}

		// Token: 0x06004831 RID: 18481 RVA: 0x00255A58 File Offset: 0x00254A58
		protected bool HasPageElements()
		{
			return this.a != null && this.a.Count > 0;
		}

		// Token: 0x06004832 RID: 18482 RVA: 0x00255A8C File Offset: 0x00254A8C
		private void c()
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
			}
		}

		// Token: 0x06004833 RID: 18483 RVA: 0x00255AB4 File Offset: 0x00254AB4
		private void b()
		{
			if (this.b == null)
			{
				this.b = new ArrayList();
			}
		}

		// Token: 0x06004834 RID: 18484 RVA: 0x00255ADC File Offset: 0x00254ADC
		private void a()
		{
			if (this.c == null)
			{
				this.c = new Hashtable();
				foreach (object obj in this)
				{
					PageElement pageElement = (PageElement)obj;
					if (pageElement.ID != null && pageElement.ID.Length > 0)
					{
						this.c[pageElement.ID] = pageElement;
					}
				}
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06004835 RID: 18485 RVA: 0x00255B88 File Offset: 0x00254B88
		protected bool HasElements
		{
			get
			{
				return this.a != null && this.a.Count > 0;
			}
		}

		// Token: 0x06004836 RID: 18486 RVA: 0x00255BB4 File Offset: 0x00254BB4
		internal ArrayList d()
		{
			return this.a;
		}

		// Token: 0x06004837 RID: 18487 RVA: 0x00255BCC File Offset: 0x00254BCC
		internal override x5 b7()
		{
			throw new GeneratorException("Group does not support the Top property.");
		}

		// Token: 0x06004838 RID: 18488 RVA: 0x00255BD9 File Offset: 0x00254BD9
		internal override x5 b8()
		{
			throw new GeneratorException("Group does not support the Bottom property.");
		}

		// Token: 0x06004839 RID: 18489 RVA: 0x00255BE8 File Offset: 0x00254BE8
		internal bool e()
		{
			return this.d;
		}

		// Token: 0x0600483A RID: 18490 RVA: 0x00255C00 File Offset: 0x00254C00
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x04002785 RID: 10117
		private new ArrayList a = null;

		// Token: 0x04002786 RID: 10118
		private ArrayList b = null;

		// Token: 0x04002787 RID: 10119
		private Hashtable c = null;

		// Token: 0x04002788 RID: 10120
		private new bool d = false;
	}
}
