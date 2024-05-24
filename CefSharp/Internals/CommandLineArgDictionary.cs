using System;
using System.Collections.Generic;

namespace CefSharp.Internals
{
	// Token: 0x020000C5 RID: 197
	public class CommandLineArgDictionary : Dictionary<string, string>
	{
		// Token: 0x060005E0 RID: 1504 RVA: 0x00009757 File Offset: 0x00007957
		public void Add(string arg)
		{
			base.Add(arg, string.Empty);
		}
	}
}
