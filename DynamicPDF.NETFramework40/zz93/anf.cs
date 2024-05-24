using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

namespace zz93
{
	// Token: 0x020005D9 RID: 1497
	[DefaultMember("Item")]
	internal class anf
	{
		// Token: 0x06003B54 RID: 15188 RVA: 0x001FC0EC File Offset: 0x001FB0EC
		internal anf(NameValueCollection A_0)
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

		// Token: 0x06003B55 RID: 15189 RVA: 0x001FC16C File Offset: 0x001FB16C
		internal anf(ConnectionStringSettingsCollection A_0)
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

		// Token: 0x06003B56 RID: 15190 RVA: 0x001FC1F1 File Offset: 0x001FB1F1
		public anf()
		{
			this.a = new HybridDictionary(true);
		}

		// Token: 0x06003B57 RID: 15191 RVA: 0x001FC208 File Offset: 0x001FB208
		public void a(string A_0, object A_1)
		{
			this.a.Add(A_0, A_1);
		}

		// Token: 0x06003B58 RID: 15192 RVA: 0x001FC21C File Offset: 0x001FB21C
		public object a(string A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x06003B59 RID: 15193 RVA: 0x001FC23A File Offset: 0x001FB23A
		public void b(string A_0, object A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x04001BEF RID: 7151
		private HybridDictionary a;
	}
}
