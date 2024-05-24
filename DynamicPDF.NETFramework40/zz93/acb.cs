using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200043D RID: 1085
	internal class acb : abp
	{
		// Token: 0x06002CD7 RID: 11479 RVA: 0x00198860 File Offset: 0x00197860
		internal acb(acc A_0, int A_1, abj A_2, PdfPage A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.g = A_3;
			for (abk abk = A_2.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 404)
				{
					if (num != 16)
					{
						switch (num)
						{
						case 403:
							this.k = true;
							break;
						case 404:
							this.j = true;
							break;
						}
					}
					else
					{
						this.d = true;
						abk.a(false);
					}
				}
				else if (num != 277293402)
				{
					if (num == 663829106)
					{
						this.e = true;
						this.f = ((abw)abk.c()).kd();
						abk.a(false);
					}
				}
				else
				{
					this.i = true;
				}
			}
		}

		// Token: 0x06002CD8 RID: 11480 RVA: 0x00198990 File Offset: 0x00197990
		int abp.a()
		{
			return this.m;
		}

		// Token: 0x06002CD9 RID: 11481 RVA: 0x001989A8 File Offset: 0x001979A8
		internal void a(int A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x001989B4 File Offset: 0x001979B4
		internal c5 b()
		{
			return this.l;
		}

		// Token: 0x06002CDB RID: 11483 RVA: 0x001989CC File Offset: 0x001979CC
		internal void a(c5 A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06002CDC RID: 11484 RVA: 0x001989D8 File Offset: 0x001979D8
		internal int c()
		{
			return this.f;
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x001989F0 File Offset: 0x001979F0
		internal bool d()
		{
			return this.j;
		}

		// Token: 0x06002CDE RID: 11486 RVA: 0x00198A08 File Offset: 0x00197A08
		internal bool e()
		{
			return this.k;
		}

		// Token: 0x06002CDF RID: 11487 RVA: 0x00198A20 File Offset: 0x00197A20
		Resource abp.a(Document A_0, FormFieldList A_1, bool A_2, bool A_3, int A_4, bool A_5)
		{
			if (A_3)
			{
				this.h = new aas(this);
				if (this.e && A_5)
				{
					this.h.a(true);
				}
			}
			return this.h;
		}

		// Token: 0x06002CE0 RID: 11488 RVA: 0x00198A74 File Offset: 0x00197A74
		internal void a(DocumentWriter A_0)
		{
			if (this.l != null && A_0.Document.j() != null)
			{
				this.h.a(this.l);
				this.l.bp(this.h, this.g.e());
				A_0.Document.j().e(this.l);
			}
			A_0.WriteDictionaryOpen();
			A_0.a(this.a);
			A_0.d(this.b);
			this.c.b(A_0);
			A_0.a(null);
			if (this.d)
			{
				A_0.WriteName(80);
				A_0.WriteReferenceShallow(this.g.s());
			}
			if (A_0.Document.j() != null && this.h.b() != -1 && this.h.a() != null)
			{
				this.h.a().a(A_0, this.h.b());
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002CE1 RID: 11489 RVA: 0x00198B9F File Offset: 0x00197B9F
		internal void b(DocumentWriter A_0)
		{
			A_0.WriteReferenceShallow(A_0.GetObjectNumber(this.b - A_0.r()));
		}

		// Token: 0x06002CE2 RID: 11490 RVA: 0x00198BBC File Offset: 0x00197BBC
		internal void c(DocumentWriter A_0)
		{
			foreach (object obj in ((IEnumerable)A_0.Resources.c()))
			{
				if ((long)((DictionaryEntry)obj).Key == this.h.Uid)
				{
					IEnumerator enumerator;
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					int objectNumber = (int)dictionaryEntry.Value;
					A_0.WriteReferenceShallow(objectNumber);
					return;
				}
			}
			A_0.WriteNull();
		}

		// Token: 0x06002CE3 RID: 11491 RVA: 0x00198C40 File Offset: 0x00197C40
		internal abj f()
		{
			return this.c;
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x00198C58 File Offset: 0x00197C58
		internal bool g()
		{
			return this.i;
		}

		// Token: 0x04001512 RID: 5394
		private acc a;

		// Token: 0x04001513 RID: 5395
		private int b;

		// Token: 0x04001514 RID: 5396
		private abj c;

		// Token: 0x04001515 RID: 5397
		private bool d = false;

		// Token: 0x04001516 RID: 5398
		private bool e = false;

		// Token: 0x04001517 RID: 5399
		private int f = -1;

		// Token: 0x04001518 RID: 5400
		private PdfPage g = null;

		// Token: 0x04001519 RID: 5401
		private aas h = null;

		// Token: 0x0400151A RID: 5402
		private bool i = false;

		// Token: 0x0400151B RID: 5403
		private bool j = false;

		// Token: 0x0400151C RID: 5404
		private bool k = false;

		// Token: 0x0400151D RID: 5405
		private c5 l = null;

		// Token: 0x0400151E RID: 5406
		private int m = -1;
	}
}
