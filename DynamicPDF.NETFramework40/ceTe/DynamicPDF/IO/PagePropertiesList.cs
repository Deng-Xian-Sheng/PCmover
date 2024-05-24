using System;
using System.Collections;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006DC RID: 1756
	public class PagePropertiesList
	{
		// Token: 0x060043B4 RID: 17332 RVA: 0x00230DD2 File Offset: 0x0022FDD2
		internal PagePropertiesList()
		{
		}

		// Token: 0x060043B5 RID: 17333 RVA: 0x00230DF2 File Offset: 0x0022FDF2
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x060043B6 RID: 17334 RVA: 0x00230DFC File Offset: 0x0022FDFC
		public void Add(Resource resource, PageWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PagePropertiesList.d);
			if (this.b.ContainsKey(resource.Uid))
			{
				writer.Write((int)this.b[resource.Uid]);
			}
			else
			{
				int num = this.a.Add(resource) + this.c;
				this.b.Add(resource.Uid, num);
				writer.Write(num);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060043B7 RID: 17335 RVA: 0x00230EBC File Offset: 0x0022FEBC
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x060043B8 RID: 17336 RVA: 0x00230EE8 File Offset: 0x0022FEE8
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PagePropertiesList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060043B9 RID: 17337 RVA: 0x00230F28 File Offset: 0x0022FF28
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(77, num++);
				writer.WriteReference(resource);
			}
		}

		// Token: 0x040025C0 RID: 9664
		private ArrayList a = null;

		// Token: 0x040025C1 RID: 9665
		private Hashtable b = null;

		// Token: 0x040025C2 RID: 9666
		private int c = 0;

		// Token: 0x040025C3 RID: 9667
		private static byte[] d = new byte[]
		{
			47,
			77
		};

		// Token: 0x040025C4 RID: 9668
		private static byte[] e = new byte[]
		{
			80,
			114,
			111,
			112,
			101,
			114,
			116,
			105,
			101,
			115
		};
	}
}
