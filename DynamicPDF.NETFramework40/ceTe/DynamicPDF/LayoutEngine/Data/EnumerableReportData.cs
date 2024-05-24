using System;
using System.Collections;
using System.Collections.Generic;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000945 RID: 2373
	public class EnumerableReportData : ReportData
	{
		// Token: 0x0600604C RID: 24652 RVA: 0x0036057C File Offset: 0x0035F57C
		public EnumerableReportData(IEnumerable enumerable)
		{
			this.a = enumerable.GetEnumerator();
			this.d = this.a.MoveNext();
			if (this.d)
			{
				if (this.a.Current == null)
				{
					this.c = null;
				}
				else
				{
					this.c = new akl(this.a.Current.GetType());
					this.b.Add(this.c.b(), this.c);
				}
			}
			else
			{
				this.c = null;
			}
		}

		// Token: 0x17000A4C RID: 2636
		public override object this[string dataName]
		{
			get
			{
				object result;
				if (this.c == null)
				{
					result = null;
				}
				else
				{
					result = this.c.a(dataName, this.a.Current);
				}
				return result;
			}
		}

		// Token: 0x0600604E RID: 24654 RVA: 0x0036067C File Offset: 0x0035F67C
		internal override bool mq(string A_0)
		{
			return this.c != null && this.c.b(A_0, this.a.Current);
		}

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x0600604F RID: 24655 RVA: 0x003606BC File Offset: 0x0035F6BC
		public override bool HasData
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x06006050 RID: 24656 RVA: 0x003606D4 File Offset: 0x0035F6D4
		internal override bool mp(LayoutWriter A_0)
		{
			bool result;
			if (this.f > this.e)
			{
				this.f--;
				result = this.d;
			}
			else
			{
				if (base.a().a())
				{
					base.a().b().a(A_0);
				}
				Type right;
				if (this.c == null)
				{
					right = null;
				}
				else
				{
					right = this.c.b();
				}
				this.d = this.a.MoveNext();
				if (this.d)
				{
					if (this.a.Current == null)
					{
						this.c = null;
					}
					else
					{
						Type type = this.a.Current.GetType();
						if (type != right)
						{
							if (!this.b.TryGetValue(type, out this.c))
							{
								this.c = new akl(type);
								this.b.Add(this.c.b(), this.c);
							}
						}
					}
					result = true;
				}
				else
				{
					this.c = null;
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06006051 RID: 24657 RVA: 0x00360812 File Offset: 0x0035F812
		internal override void mn()
		{
			this.e++;
			this.f++;
		}

		// Token: 0x06006052 RID: 24658 RVA: 0x00360831 File Offset: 0x0035F831
		internal override void mo()
		{
			this.e--;
		}

		// Token: 0x06006053 RID: 24659 RVA: 0x00360842 File Offset: 0x0035F842
		internal override void mr()
		{
			this.a = null;
		}

		// Token: 0x0400318F RID: 12687
		private new IEnumerator a;

		// Token: 0x04003190 RID: 12688
		private Dictionary<Type, akl> b = new Dictionary<Type, akl>();

		// Token: 0x04003191 RID: 12689
		private akl c;

		// Token: 0x04003192 RID: 12690
		private bool d;

		// Token: 0x04003193 RID: 12691
		private int e = 0;

		// Token: 0x04003194 RID: 12692
		private int f = 0;
	}
}
