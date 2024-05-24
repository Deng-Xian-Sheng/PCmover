using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000740 RID: 1856
	public class SubPathList : IEnumerable
	{
		// Token: 0x06004B16 RID: 19222 RVA: 0x00263244 File Offset: 0x00262244
		internal SubPathList()
		{
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06004B17 RID: 19223 RVA: 0x0026325C File Offset: 0x0026225C
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x17000581 RID: 1409
		public SubPath this[int index]
		{
			get
			{
				return (SubPath)this.a[index];
			}
			set
			{
				this.a[index] = value;
			}
		}

		// Token: 0x06004B1A RID: 19226 RVA: 0x002632B0 File Offset: 0x002622B0
		public int Add(SubPath subPath)
		{
			return this.a.Add(subPath);
		}

		// Token: 0x06004B1B RID: 19227 RVA: 0x002632D0 File Offset: 0x002622D0
		internal void a(PageWriter A_0)
		{
			foreach (object obj in this.a)
			{
				SubPath subPath = (SubPath)obj;
				subPath.Draw(A_0);
			}
		}

		// Token: 0x06004B1C RID: 19228 RVA: 0x00263338 File Offset: 0x00262338
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x040028B0 RID: 10416
		private ArrayList a = new ArrayList();
	}
}
