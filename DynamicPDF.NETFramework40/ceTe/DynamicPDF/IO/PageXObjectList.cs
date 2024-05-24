using System;
using System.Collections;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006E1 RID: 1761
	public class PageXObjectList
	{
		// Token: 0x0600442D RID: 17453 RVA: 0x00232F01 File Offset: 0x00231F01
		internal PageXObjectList()
		{
		}

		// Token: 0x0600442E RID: 17454 RVA: 0x00232F21 File Offset: 0x00231F21
		public void SetStartingNameNumber(int startingNameNumber)
		{
			this.c = startingNameNumber;
		}

		// Token: 0x0600442F RID: 17455 RVA: 0x00232F2C File Offset: 0x00231F2C
		public void Add(Resource resource, OperatorWriter writer)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			writer.Write(PageXObjectList.d);
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

		// Token: 0x06004430 RID: 17456 RVA: 0x00232FEC File Offset: 0x00231FEC
		internal int a(Resource A_0)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.b = new Hashtable();
			}
			int result;
			if (this.b.ContainsKey(A_0.Uid))
			{
				result = (int)this.b[A_0.Uid];
			}
			else
			{
				int num = this.a.Add(A_0) + this.c;
				this.b.Add(A_0.Uid, num);
				result = num;
			}
			return result;
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06004431 RID: 17457 RVA: 0x00233098 File Offset: 0x00232098
		public int Count
		{
			get
			{
				return (this.a == null) ? 0 : this.a.Count;
			}
		}

		// Token: 0x06004432 RID: 17458 RVA: 0x002330C4 File Offset: 0x002320C4
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PageXObjectList.e);
				A_0.WriteDictionaryOpen();
				this.DrawEntries(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06004433 RID: 17459 RVA: 0x00233104 File Offset: 0x00232104
		public void DrawEntries(DocumentWriter writer)
		{
			int num = this.c;
			foreach (object obj in this.a)
			{
				Resource resource = (Resource)obj;
				writer.WriteName(88, num++);
				writer.WriteReference(resource);
			}
		}

		// Token: 0x040025F9 RID: 9721
		private ArrayList a = null;

		// Token: 0x040025FA RID: 9722
		private Hashtable b = null;

		// Token: 0x040025FB RID: 9723
		private int c = 0;

		// Token: 0x040025FC RID: 9724
		private static byte[] d = new byte[]
		{
			47,
			88
		};

		// Token: 0x040025FD RID: 9725
		private static byte[] e = new byte[]
		{
			88,
			79,
			98,
			106,
			101,
			99,
			116
		};
	}
}
