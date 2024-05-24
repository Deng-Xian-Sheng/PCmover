using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006A4 RID: 1700
	public class OutputIntentList
	{
		// Token: 0x0600408D RID: 16525 RVA: 0x0022233E File Offset: 0x0022133E
		internal OutputIntentList()
		{
		}

		// Token: 0x0600408E RID: 16526 RVA: 0x00222358 File Offset: 0x00221358
		internal OutputIntentList(abe A_0)
		{
			if (A_0.a() > 0)
			{
				this.b = new ArrayList();
				for (int i = 0; i < A_0.a(); i++)
				{
					this.b.Add(new yv((abj)A_0.a(i).h6()));
				}
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x0600408F RID: 16527 RVA: 0x002223D0 File Offset: 0x002213D0
		public int Count
		{
			get
			{
				int result;
				if (this.b == null)
				{
					result = 0;
				}
				else
				{
					result = this.b.Count;
				}
				return result;
			}
		}

		// Token: 0x17000273 RID: 627
		public OutputIntent this[int index]
		{
			get
			{
				return (OutputIntent)this.b[index];
			}
		}

		// Token: 0x06004091 RID: 16529 RVA: 0x00222428 File Offset: 0x00221428
		public void Add(OutputIntent outputIntent)
		{
			if (outputIntent.Version == OutputIntentVersion.PDF_A)
			{
				this.c = true;
			}
			if (this.b == null)
			{
				this.b = new ArrayList();
			}
			this.b.Add(outputIntent);
		}

		// Token: 0x06004092 RID: 16530 RVA: 0x00222478 File Offset: 0x00221478
		internal void a(DocumentWriter A_0)
		{
			if (this.b != null)
			{
				A_0.WriteName(OutputIntentList.a);
				A_0.WriteArrayOpen();
				for (int i = 0; i < this.b.Count; i++)
				{
					this[i].g0(A_0);
				}
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x06004093 RID: 16531 RVA: 0x002224DC File Offset: 0x002214DC
		internal int a()
		{
			int result;
			if (this.c)
			{
				result = 3;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x040023D0 RID: 9168
		private static byte[] a = new byte[]
		{
			79,
			117,
			116,
			112,
			117,
			116,
			73,
			110,
			116,
			101,
			110,
			116,
			115
		};

		// Token: 0x040023D1 RID: 9169
		private ArrayList b = null;

		// Token: 0x040023D2 RID: 9170
		private bool c = false;
	}
}
