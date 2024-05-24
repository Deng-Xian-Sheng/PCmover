using System;
using System.Collections.Generic;
using CefSharp.Enums;

namespace CefSharp
{
	// Token: 0x02000080 RID: 128
	public interface IValue : IDisposable
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600034A RID: 842
		CefSharp.Enums.ValueType Type { get; }

		// Token: 0x0600034B RID: 843
		bool GetBool();

		// Token: 0x0600034C RID: 844
		double GetDouble();

		// Token: 0x0600034D RID: 845
		int GetInt();

		// Token: 0x0600034E RID: 846
		string GetString();

		// Token: 0x0600034F RID: 847
		IDictionary<string, IValue> GetDictionary();

		// Token: 0x06000350 RID: 848
		IList<IValue> GetList();

		// Token: 0x06000351 RID: 849
		object GetObject();
	}
}
