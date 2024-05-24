using System;
using System.Collections.Specialized;
using System.Configuration;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000828 RID: 2088
	public class ParameterDictionary
	{
		// Token: 0x06005429 RID: 21545 RVA: 0x00293D18 File Offset: 0x00292D18
		internal ParameterDictionary(NameValueCollection A_0)
		{
			if (A_0.Count > 0)
			{
				this.a = new HybridDictionary(A_0.Count, true);
				for (int i = 0; i < A_0.Count; i++)
				{
					this.a.Add(A_0.Keys[i], A_0[i]);
				}
			}
			else
			{
				this.a = new HybridDictionary(true);
			}
		}

		// Token: 0x0600542A RID: 21546 RVA: 0x00293D98 File Offset: 0x00292D98
		internal ParameterDictionary(ConnectionStringSettingsCollection A_0)
		{
			if (A_0.Count > 0)
			{
				this.a = new HybridDictionary(A_0.Count, true);
				for (int i = 0; i < A_0.Count; i++)
				{
					this.a.Add(A_0[i].Name, A_0[i].ConnectionString);
				}
			}
			else
			{
				this.a = new HybridDictionary(true);
			}
		}

		// Token: 0x0600542B RID: 21547 RVA: 0x00293E1D File Offset: 0x00292E1D
		public ParameterDictionary()
		{
			this.a = new HybridDictionary(true);
		}

		// Token: 0x0600542C RID: 21548 RVA: 0x00293E34 File Offset: 0x00292E34
		public void Add(string key, object value)
		{
			this.a.Add(key, value);
		}

		// Token: 0x170007BB RID: 1979
		public object this[string key]
		{
			get
			{
				return this.a[key];
			}
			set
			{
				this.a[key] = value;
			}
		}

		// Token: 0x04002D10 RID: 11536
		private HybridDictionary a;
	}
}
