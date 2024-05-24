using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x020007F9 RID: 2041
	public abstract class RecordSet
	{
		// Token: 0x060052EC RID: 21228 RVA: 0x0029041A File Offset: 0x0028F41A
		internal RecordSet()
		{
		}

		// Token: 0x060052ED RID: 21229 RVA: 0x00290425 File Offset: 0x0028F425
		internal RecordSet(Query A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060052EE RID: 21230
		internal abstract void d9();

		// Token: 0x060052EF RID: 21231
		internal abstract void ea();

		// Token: 0x060052F0 RID: 21232
		internal abstract bool d8(LayoutWriter A_0);

		// Token: 0x060052F1 RID: 21233 RVA: 0x00290438 File Offset: 0x0028F438
		internal void a(Query A_0)
		{
			if (this.a != null)
			{
				throw new ReportWriterException("Record set is already associated with a query.");
			}
			this.a = A_0;
		}

		// Token: 0x1700076E RID: 1902
		public abstract object this[string fieldName]
		{
			get;
		}

		// Token: 0x1700076F RID: 1903
		public abstract object this[int fieldIndex]
		{
			get;
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x060052F4 RID: 21236 RVA: 0x00290468 File Offset: 0x0028F468
		public string Id
		{
			get
			{
				return this.a.Id;
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x060052F5 RID: 21237 RVA: 0x00290488 File Offset: 0x0028F488
		public Query Query
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x060052F6 RID: 21238
		internal abstract void eb();

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x060052F7 RID: 21239
		public abstract bool HasData { get; }

		// Token: 0x04002C4B RID: 11339
		private Query a;
	}
}
