using System;
using System.Collections;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006D8 RID: 1752
	public class PageColorSpaceList
	{
		// Token: 0x06004397 RID: 17303 RVA: 0x0023048C File Offset: 0x0022F48C
		internal PageColorSpaceList()
		{
		}

		// Token: 0x06004398 RID: 17304 RVA: 0x002304AC File Offset: 0x0022F4AC
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x06004399 RID: 17305 RVA: 0x002304B8 File Offset: 0x0022F4B8
		public void Add(Resource resource, PageWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PageColorSpaceList.d);
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

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x0600439A RID: 17306 RVA: 0x00230578 File Offset: 0x0022F578
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x0600439B RID: 17307 RVA: 0x002305A4 File Offset: 0x0022F5A4
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PageColorSpaceList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x0600439C RID: 17308 RVA: 0x002305E4 File Offset: 0x0022F5E4
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(67, num++);
				writer.WriteReference(resource);
			}
		}

		// Token: 0x040025AC RID: 9644
		private ArrayList a = null;

		// Token: 0x040025AD RID: 9645
		private Hashtable b = null;

		// Token: 0x040025AE RID: 9646
		private int c = 0;

		// Token: 0x040025AF RID: 9647
		private static byte[] d = new byte[]
		{
			47,
			67
		};

		// Token: 0x040025B0 RID: 9648
		private static byte[] e = new byte[]
		{
			67,
			111,
			108,
			111,
			114,
			83,
			112,
			97,
			99,
			101
		};
	}
}
