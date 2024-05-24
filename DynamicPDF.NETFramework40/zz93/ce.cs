using System;
using System.Collections;
using System.Reflection;
using ceTe.DynamicPDF.Forms;

namespace zz93
{
	// Token: 0x0200006D RID: 109
	[DefaultMember("Item")]
	internal class ce : IEnumerable
	{
		// Token: 0x06000478 RID: 1144 RVA: 0x0004AC35 File Offset: 0x00049C35
		internal ce(FormFieldList A_0)
		{
			this.a(A_0);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0004AC54 File Offset: 0x00049C54
		internal int a()
		{
			return this.a.Count;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0004AC74 File Offset: 0x00049C74
		public SignatureField a(int A_0)
		{
			SignatureField result;
			if (A_0 >= this.a())
			{
				result = null;
			}
			else
			{
				result = (SignatureField)this.a[A_0];
			}
			return result;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0004ACA8 File Offset: 0x00049CA8
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0004ACC8 File Offset: 0x00049CC8
		private void a(FormFieldList A_0)
		{
			for (int i = 0; i < A_0.Count; i++)
			{
				if (A_0[i] is SignatureField)
				{
					this.a.Add(A_0[i]);
				}
				if (A_0[i].HasChildFields)
				{
					this.a(A_0[i].ChildFields);
				}
			}
		}

		// Token: 0x040002A3 RID: 675
		private ArrayList a = new ArrayList();
	}
}
