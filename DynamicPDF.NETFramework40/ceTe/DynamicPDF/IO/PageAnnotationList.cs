using System;
using System.Collections;
using ceTe.DynamicPDF.Forms;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006D7 RID: 1751
	public class PageAnnotationList
	{
		// Token: 0x06004393 RID: 17299 RVA: 0x00230248 File Offset: 0x0022F248
		internal PageAnnotationList()
		{
		}

		// Token: 0x06004394 RID: 17300 RVA: 0x0023025C File Offset: 0x0022F25C
		public void Add(Resource annotation)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
			}
			this.a.Add(annotation);
		}

		// Token: 0x06004395 RID: 17301 RVA: 0x00230294 File Offset: 0x0022F294
		internal int a()
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

		// Token: 0x06004396 RID: 17302 RVA: 0x002302C8 File Offset: 0x0022F2C8
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null && this.a.Count > 0)
			{
				foreach (object obj in this.a)
				{
					Resource resource = (Resource)obj;
					if (resource is FormField)
					{
						if (resource.ag() == FormFieldOutput.Retain)
						{
							A_0.WriteReference(resource);
							((FormField)resource).cd(A_0);
						}
						else if (resource.ag() == FormFieldOutput.Inherit)
						{
							if (resource is SignatureField)
							{
								if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain)
								{
									A_0.WriteReference(resource);
									((FormField)resource).cd(A_0);
								}
								else if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit)
								{
									if (A_0.Document.d().Output == FormOutput.Retain)
									{
										A_0.WriteReference(resource);
										((FormField)resource).cd(A_0);
									}
								}
							}
							else if (A_0.Document.d().Output == FormOutput.Retain)
							{
								A_0.WriteReference(resource);
								((FormField)resource).cd(A_0);
							}
						}
					}
					else
					{
						A_0.WriteReference(resource);
					}
				}
			}
		}

		// Token: 0x040025AB RID: 9643
		private ArrayList a = null;
	}
}
