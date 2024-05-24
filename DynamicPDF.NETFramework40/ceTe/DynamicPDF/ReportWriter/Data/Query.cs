using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000800 RID: 2048
	public abstract class Query
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06005325 RID: 21285 RVA: 0x00291004 File Offset: 0x00290004
		// (remove) Token: 0x06005326 RID: 21286 RVA: 0x00291040 File Offset: 0x00290040
		public event OpeningRecordSetEventHandler OpeningRecordSet
		{
			add
			{
				OpeningRecordSetEventHandler openingRecordSetEventHandler = this.c;
				OpeningRecordSetEventHandler openingRecordSetEventHandler2;
				do
				{
					openingRecordSetEventHandler2 = openingRecordSetEventHandler;
					OpeningRecordSetEventHandler value2 = (OpeningRecordSetEventHandler)Delegate.Combine(openingRecordSetEventHandler2, value);
					openingRecordSetEventHandler = Interlocked.CompareExchange<OpeningRecordSetEventHandler>(ref this.c, value2, openingRecordSetEventHandler2);
				}
				while (openingRecordSetEventHandler != openingRecordSetEventHandler2);
			}
			remove
			{
				OpeningRecordSetEventHandler openingRecordSetEventHandler = this.c;
				OpeningRecordSetEventHandler openingRecordSetEventHandler2;
				do
				{
					openingRecordSetEventHandler2 = openingRecordSetEventHandler;
					OpeningRecordSetEventHandler value2 = (OpeningRecordSetEventHandler)Delegate.Remove(openingRecordSetEventHandler2, value);
					openingRecordSetEventHandler = Interlocked.CompareExchange<OpeningRecordSetEventHandler>(ref this.c, value2, openingRecordSetEventHandler2);
				}
				while (openingRecordSetEventHandler != openingRecordSetEventHandler2);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06005327 RID: 21287 RVA: 0x0029107C File Offset: 0x0029007C
		// (remove) Token: 0x06005328 RID: 21288 RVA: 0x002910B8 File Offset: 0x002900B8
		public event ClosingRecordSetEventHandler ClosingRecordSet
		{
			add
			{
				ClosingRecordSetEventHandler closingRecordSetEventHandler = this.d;
				ClosingRecordSetEventHandler closingRecordSetEventHandler2;
				do
				{
					closingRecordSetEventHandler2 = closingRecordSetEventHandler;
					ClosingRecordSetEventHandler value2 = (ClosingRecordSetEventHandler)Delegate.Combine(closingRecordSetEventHandler2, value);
					closingRecordSetEventHandler = Interlocked.CompareExchange<ClosingRecordSetEventHandler>(ref this.d, value2, closingRecordSetEventHandler2);
				}
				while (closingRecordSetEventHandler != closingRecordSetEventHandler2);
			}
			remove
			{
				ClosingRecordSetEventHandler closingRecordSetEventHandler = this.d;
				ClosingRecordSetEventHandler closingRecordSetEventHandler2;
				do
				{
					closingRecordSetEventHandler2 = closingRecordSetEventHandler;
					ClosingRecordSetEventHandler value2 = (ClosingRecordSetEventHandler)Delegate.Remove(closingRecordSetEventHandler2, value);
					closingRecordSetEventHandler = Interlocked.CompareExchange<ClosingRecordSetEventHandler>(ref this.d, value2, closingRecordSetEventHandler2);
				}
				while (closingRecordSetEventHandler != closingRecordSetEventHandler2);
			}
		}

		// Token: 0x06005329 RID: 21289 RVA: 0x002910F4 File Offset: 0x002900F4
		internal Query(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600532A RID: 21290 RVA: 0x00291110 File Offset: 0x00290110
		internal bool d()
		{
			return this.b != null && this.b.b() >= 1;
		}

		// Token: 0x0600532B RID: 21291 RVA: 0x00291140 File Offset: 0x00290140
		internal sz e()
		{
			if (this.b == null)
			{
				this.b = new sz();
			}
			return this.b;
		}

		// Token: 0x0600532C RID: 21292 RVA: 0x00291175 File Offset: 0x00290175
		internal void a(sz A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600532D RID: 21293 RVA: 0x00291180 File Offset: 0x00290180
		internal RecordSet e(LayoutWriter A_0)
		{
			if (this.c != null)
			{
				OpeningRecordSetEventArgs openingRecordSetEventArgs = new OpeningRecordSetEventArgs(A_0);
				this.c(this, openingRecordSetEventArgs);
				if (openingRecordSetEventArgs.RecordSet != null)
				{
					openingRecordSetEventArgs.RecordSet.a(this);
					return openingRecordSetEventArgs.RecordSet;
				}
			}
			return this.GetRecordSet(A_0);
		}

		// Token: 0x0600532E RID: 21294 RVA: 0x002911E4 File Offset: 0x002901E4
		internal void a(LayoutWriter A_0, RecordSet A_1)
		{
			if (this.d != null)
			{
				ClosingRecordSetEventArgs closingRecordSetEventArgs = new ClosingRecordSetEventArgs(A_1, A_0);
				this.d(this, closingRecordSetEventArgs);
				if (!closingRecordSetEventArgs.Closed)
				{
					A_1.eb();
				}
			}
			else
			{
				A_1.eb();
			}
		}

		// Token: 0x0600532F RID: 21295
		protected abstract RecordSet GetRecordSet(LayoutWriter writer);

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06005330 RID: 21296 RVA: 0x00291234 File Offset: 0x00290234
		public string Id
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x04002C66 RID: 11366
		private string a;

		// Token: 0x04002C67 RID: 11367
		private sz b = null;

		// Token: 0x04002C68 RID: 11368
		private OpeningRecordSetEventHandler c;

		// Token: 0x04002C69 RID: 11369
		private ClosingRecordSetEventHandler d;
	}
}
