using System;
using System.Collections.Specialized;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000933 RID: 2355
	public class NameValueLayoutData : LayoutData
	{
		// Token: 0x17000A2E RID: 2606
		public override object this[string key]
		{
			get
			{
				return this.a[key];
			}
		}

		// Token: 0x06005FB7 RID: 24503 RVA: 0x0035E944 File Offset: 0x0035D944
		internal override bool mq(string A_0)
		{
			return this.a.Contains(A_0);
		}

		// Token: 0x06005FB8 RID: 24504 RVA: 0x0035E962 File Offset: 0x0035D962
		public new void Add(string key, object value)
		{
			this.a.Add(key, value);
		}

		// Token: 0x04003145 RID: 12613
		private HybridDictionary a = new HybridDictionary(true);
	}
}
