using System;
using System.Collections;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006DB RID: 1755
	public class PagePatternList
	{
		// Token: 0x060043AD RID: 17325 RVA: 0x00230BC2 File Offset: 0x0022FBC2
		internal PagePatternList()
		{
		}

		// Token: 0x060043AE RID: 17326 RVA: 0x00230BE2 File Offset: 0x0022FBE2
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x060043AF RID: 17327 RVA: 0x00230BEC File Offset: 0x0022FBEC
		public void Add(Resource resource, PageWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PagePatternList.d);
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

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060043B0 RID: 17328 RVA: 0x00230CAC File Offset: 0x0022FCAC
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x060043B1 RID: 17329 RVA: 0x00230CD8 File Offset: 0x0022FCD8
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PagePatternList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060043B2 RID: 17330 RVA: 0x00230D18 File Offset: 0x0022FD18
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(80, num++);
				writer.WriteReference(resource);
			}
		}

		// Token: 0x040025BB RID: 9659
		private ArrayList a = null;

		// Token: 0x040025BC RID: 9660
		private Hashtable b = null;

		// Token: 0x040025BD RID: 9661
		private int c = 0;

		// Token: 0x040025BE RID: 9662
		private static byte[] d = new byte[]
		{
			47,
			80
		};

		// Token: 0x040025BF RID: 9663
		private static byte[] e = new byte[]
		{
			80,
			97,
			116,
			116,
			101,
			114,
			110
		};
	}
}
