using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006D2 RID: 1746
	public class FormFieldList : IEnumerable
	{
		// Token: 0x06004378 RID: 17272 RVA: 0x0022FB5C File Offset: 0x0022EB5C
		internal FormFieldList(Form A_0, FormField A_1)
		{
			this.d = A_0;
			this.c = A_1;
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06004379 RID: 17273 RVA: 0x0022FB8C File Offset: 0x0022EB8C
		public int Count
		{
			get
			{
				return this.b.Count;
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x0600437A RID: 17274 RVA: 0x0022FBAC File Offset: 0x0022EBAC
		public FormField Owner
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000380 RID: 896
		public FormField this[string name]
		{
			get
			{
				int num = name.IndexOf('.');
				FormField result;
				if (num < 0)
				{
					result = (FormField)this.a[name];
				}
				else
				{
					result = ((FormField)this.a[name.Substring(0, num)]).ChildFields[name.Substring(num + 1)];
				}
				return result;
			}
		}

		// Token: 0x17000381 RID: 897
		public FormField this[int index]
		{
			get
			{
				return (FormField)this.b[index];
			}
		}

		// Token: 0x0600437D RID: 17277 RVA: 0x0022FC50 File Offset: 0x0022EC50
		public int Add(FormField formField)
		{
			if (formField.Name != string.Empty)
			{
				if (this.a.ContainsKey(formField.Name))
				{
					int num = 2;
					while (this.a.ContainsKey(formField.Name + "(" + num.ToString() + ")"))
					{
						num++;
					}
					formField.Name = formField.Name + "(" + num.ToString() + ")";
				}
				this.a.Add(formField.Name, formField);
			}
			formField.a(this.d, this.c);
			return this.b.Add(formField);
		}

		// Token: 0x0600437E RID: 17278 RVA: 0x0022FD20 File Offset: 0x0022ED20
		public void Remove(FormField field)
		{
			this.a.Remove(field.Name);
			this.b.Remove(field);
		}

		// Token: 0x0600437F RID: 17279 RVA: 0x0022FD44 File Offset: 0x0022ED44
		public IEnumerator GetEnumerator()
		{
			return this.b.GetEnumerator();
		}

		// Token: 0x06004380 RID: 17280 RVA: 0x0022FD64 File Offset: 0x0022ED64
		public void DrawKidReferences(DocumentWriter writer)
		{
			if (this.c != null)
			{
				if (this.c.Flags == FormFieldFlags.None && this.c.cc() != bj.d)
				{
					FormField formField = (FormField)this.b[0];
					this.b = formField.hd(this.b);
				}
				else
				{
					this.b = this.c.hd(this.b);
				}
			}
			foreach (object obj in this.b)
			{
				Resource resource = (Resource)obj;
				if (resource != null)
				{
					if (resource.ag() == FormFieldOutput.Retain)
					{
						writer.WriteReference(resource);
					}
					else if (resource.ag() == FormFieldOutput.Inherit)
					{
						if (resource is SignatureField)
						{
							if (writer.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain)
							{
								writer.WriteReference(resource);
							}
							else if (writer.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
							{
								if (writer.Document.d().Output == FormOutput.Retain)
								{
									writer.WriteReference(resource);
								}
							}
						}
						else if (writer.Document.d().Output == FormOutput.Retain)
						{
							writer.WriteReference(resource);
						}
					}
				}
			}
		}

		// Token: 0x06004381 RID: 17281 RVA: 0x0022FF18 File Offset: 0x0022EF18
		public TextFieldList GetTextFields()
		{
			return new TextFieldList(this);
		}

		// Token: 0x06004382 RID: 17282 RVA: 0x0022FF30 File Offset: 0x0022EF30
		private ce a()
		{
			return new ce(this);
		}

		// Token: 0x06004383 RID: 17283 RVA: 0x0022FF48 File Offset: 0x0022EF48
		internal void a(DocumentWriter A_0)
		{
			ce ce = this.a();
			foreach (object obj in ce)
			{
				SignatureField signatureField = (SignatureField)obj;
				if (signatureField != null && signatureField.Output == FormFieldOutput.Retain)
				{
					A_0.WriteReference(signatureField);
				}
			}
		}

		// Token: 0x06004384 RID: 17284 RVA: 0x0022FFCC File Offset: 0x0022EFCC
		internal bool b(DocumentWriter A_0)
		{
			ce ce = this.a();
			if (ce.a() > 0)
			{
				for (int i = 0; i < ce.a(); i++)
				{
					if (ce.a(i).Output == FormFieldOutput.Retain)
					{
						return true;
					}
					if (ce.a(i).Output == FormFieldOutput.Inherit)
					{
						if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain)
						{
							return true;
						}
						if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
						{
							if (A_0.Document.d().Output == FormOutput.Retain)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06004385 RID: 17285 RVA: 0x002300A5 File Offset: 0x0022F0A5
		internal void a(string A_0, string A_1)
		{
			this.a[A_1] = this.a[A_0];
			this.a[A_0] = null;
		}

		// Token: 0x0400259F RID: 9631
		private Hashtable a = new Hashtable();

		// Token: 0x040025A0 RID: 9632
		private ArrayList b = new ArrayList();

		// Token: 0x040025A1 RID: 9633
		private FormField c;

		// Token: 0x040025A2 RID: 9634
		private Form d;
	}
}
