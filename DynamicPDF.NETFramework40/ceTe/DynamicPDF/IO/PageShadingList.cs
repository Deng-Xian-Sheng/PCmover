using System;
using System.Collections;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006DE RID: 1758
	public class PageShadingList
	{
		// Token: 0x060043C6 RID: 17350 RVA: 0x002312E0 File Offset: 0x002302E0
		internal PageShadingList()
		{
		}

		// Token: 0x060043C7 RID: 17351 RVA: 0x00231300 File Offset: 0x00230300
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x060043C8 RID: 17352 RVA: 0x0023130C File Offset: 0x0023030C
		public void Add(Resource resource, PageWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PageShadingList.d);
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

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060043C9 RID: 17353 RVA: 0x002313CC File Offset: 0x002303CC
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x060043CA RID: 17354 RVA: 0x002313F8 File Offset: 0x002303F8
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PageShadingList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060043CB RID: 17355 RVA: 0x00231438 File Offset: 0x00230438
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(83, num++);
				writer.WriteReference(resource);
			}
		}

		// Token: 0x040025D3 RID: 9683
		private ArrayList a = null;

		// Token: 0x040025D4 RID: 9684
		private Hashtable b = null;

		// Token: 0x040025D5 RID: 9685
		private int c = 0;

		// Token: 0x040025D6 RID: 9686
		private static byte[] d = new byte[]
		{
			47,
			83
		};

		// Token: 0x040025D7 RID: 9687
		private static byte[] e = new byte[]
		{
			83,
			104,
			97,
			100,
			105,
			110,
			103
		};
	}
}
