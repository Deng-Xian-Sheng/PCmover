using System;
using System.Collections;
using zz93;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006D9 RID: 1753
	public class PageExtGStateList
	{
		// Token: 0x0600439E RID: 17310 RVA: 0x0023069F File Offset: 0x0022F69F
		internal PageExtGStateList()
		{
		}

		// Token: 0x0600439F RID: 17311 RVA: 0x002306BF File Offset: 0x0022F6BF
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x060043A0 RID: 17312 RVA: 0x002306CC File Offset: 0x0022F6CC
		public void Add(Resource resource, PageWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PageExtGStateList.d);
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

		// Token: 0x060043A1 RID: 17313 RVA: 0x0023078C File Offset: 0x0022F78C
		internal void a(Resource A_0, afs A_1)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			A_1.Write(PageExtGStateList.d);
			if (this.b.ContainsKey(A_0.Uid))
			{
				A_1.Write((int)this.b[A_0.Uid]);
			}
			else
			{
				int num = this.a.Add(A_0) + this.c;
				this.b.Add(A_0.Uid, num);
				A_1.Write(num);
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060043A2 RID: 17314 RVA: 0x0023084C File Offset: 0x0022F84C
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x060043A3 RID: 17315 RVA: 0x00230878 File Offset: 0x0022F878
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PageExtGStateList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060043A4 RID: 17316 RVA: 0x002308B8 File Offset: 0x0022F8B8
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(71, num++);
				writer.WriteReference(resource);
			}
		}

		// Token: 0x040025B1 RID: 9649
		private ArrayList a = null;

		// Token: 0x040025B2 RID: 9650
		private Hashtable b = null;

		// Token: 0x040025B3 RID: 9651
		private int c = 0;

		// Token: 0x040025B4 RID: 9652
		private static byte[] d = new byte[]
		{
			47,
			71
		};

		// Token: 0x040025B5 RID: 9653
		private static byte[] e = new byte[]
		{
			69,
			120,
			116,
			71,
			83,
			116,
			97,
			116,
			101
		};
	}
}
