using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000801 RID: 2049
	public class EventDrivenQuery : Query
	{
		// Token: 0x06005331 RID: 21297 RVA: 0x0029124C File Offset: 0x0029024C
		internal EventDrivenQuery(vw A_0) : base(A_0.f())
		{
			this.a = A_0.a();
			this.b = A_0.b();
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06005332 RID: 21298 RVA: 0x00291284 File Offset: 0x00290284
		// (set) Token: 0x06005333 RID: 21299 RVA: 0x002912A1 File Offset: 0x002902A1
		public string Statement
		{
			get
			{
				return this.a.f();
			}
			set
			{
				this.a = new tu(value);
			}
		}

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06005334 RID: 21300 RVA: 0x002912B0 File Offset: 0x002902B0
		// (set) Token: 0x06005335 RID: 21301 RVA: 0x002912C8 File Offset: 0x002902C8
		public string ConnectionString
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06005336 RID: 21302 RVA: 0x002912D2 File Offset: 0x002902D2
		protected override RecordSet GetRecordSet(LayoutWriter writer)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x04002C6A RID: 11370
		private new tu a = null;

		// Token: 0x04002C6B RID: 11371
		private string b = null;
	}
}
