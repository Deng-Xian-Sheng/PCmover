using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.LayoutEngine.Data;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000926 RID: 2342
	public class LayoutData : DataProvider
	{
		// Token: 0x06005F65 RID: 24421 RVA: 0x0035D564 File Offset: 0x0035C564
		public LayoutData()
		{
		}

		// Token: 0x06005F66 RID: 24422 RVA: 0x0035D584 File Offset: 0x0035C584
		public LayoutData(object data)
		{
			this.c = data;
			this.b = new akl(data.GetType());
		}

		// Token: 0x17000A1F RID: 2591
		public override object this[string key]
		{
			get
			{
				object result;
				if (this.a != null && this.a.ContainsKey(key))
				{
					result = this.a[key];
				}
				else
				{
					if (this.c == null)
					{
						throw new LayoutEngineException("Layout data for " + key + " could not be retrieved because data by that name doesn't exist.");
					}
					result = this.b.a(key, this.c);
				}
				return result;
			}
		}

		// Token: 0x06005F68 RID: 24424 RVA: 0x0035D634 File Offset: 0x0035C634
		internal override bool mq(string A_0)
		{
			return (this.a != null && this.a.ContainsKey(A_0)) || (this.c != null && this.b.b(A_0, this.c));
		}

		// Token: 0x06005F69 RID: 24425 RVA: 0x0035D68C File Offset: 0x0035C68C
		public void Add(string key, object value)
		{
			if (this.a == null)
			{
				this.a = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
			}
			this.a.Add(key, value);
		}

		// Token: 0x04003118 RID: 12568
		private Dictionary<string, object> a = null;

		// Token: 0x04003119 RID: 12569
		private akl b = null;

		// Token: 0x0400311A RID: 12570
		private object c = null;
	}
}
