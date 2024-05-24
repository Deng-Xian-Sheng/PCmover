using System;
using System.Collections;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x02000059 RID: 89
	public class DocumentResourceList
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0003F890 File Offset: 0x0003E890
		internal DocumentResourceList(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0003F8B8 File Offset: 0x0003E8B8
		public virtual int Add(Resource resource)
		{
			int result;
			if (this.b.ContainsKey(resource.Uid))
			{
				result = (int)this.b[resource.Uid];
			}
			else
			{
				int num = this.c;
				this.a.Add(resource);
				this.b.Add(resource.Uid, num);
				this.c += resource.RequiredPdfObjects;
				result = num;
			}
			return result;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0003F94C File Offset: 0x0003E94C
		public int AddUnique(Resource resource)
		{
			int result = this.c;
			this.a.Add(resource);
			this.c += resource.RequiredPdfObjects;
			return result;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0003F988 File Offset: 0x0003E988
		public int CurrentObjectNumber
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0003F9A0 File Offset: 0x0003E9A0
		internal int b()
		{
			return this.a.Count;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0003F9C0 File Offset: 0x0003E9C0
		internal void a(DocumentWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				((Resource)this.a[i]).Draw(A_0);
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0003FA04 File Offset: 0x0003EA04
		internal void b(DocumentWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((Resource)this.a[i]).d())
				{
					((Resource)this.a[i]).c(A_0.Document.k());
					A_0.Document.a(A_0.Document.k() + 1);
				}
			}
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0003FA88 File Offset: 0x0003EA88
		internal Hashtable c()
		{
			return this.b;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0003FAA0 File Offset: 0x0003EAA0
		internal ArrayList d()
		{
			return this.a;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0003FAB8 File Offset: 0x0003EAB8
		internal Hashtable e()
		{
			return this.b;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0003FAD0 File Offset: 0x0003EAD0
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0003FADA File Offset: 0x0003EADA
		internal virtual void t()
		{
		}

		// Token: 0x04000206 RID: 518
		internal ArrayList a = new ArrayList();

		// Token: 0x04000207 RID: 519
		private Hashtable b = new Hashtable();

		// Token: 0x04000208 RID: 520
		private int c;
	}
}
