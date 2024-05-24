using System;
using System.Collections.Generic;

namespace PCmover.Infrastructure
{
	// Token: 0x02000035 RID: 53
	public class Settings
	{
		// Token: 0x17000108 RID: 264
		public object this[string key]
		{
			get
			{
				if (this._Settings.ContainsKey(key))
				{
					return this._Settings[key];
				}
				return null;
			}
			set
			{
				if (this._Settings.ContainsKey(key))
				{
					this._Settings[key] = value;
					return;
				}
				this._Settings.Add(key, value);
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00007AA1 File Offset: 0x00005CA1
		public void Remove(string key)
		{
			if (this._Settings.ContainsKey(key))
			{
				this._Settings.Remove(key);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00007ABE File Offset: 0x00005CBE
		public bool ContainsKey(string key)
		{
			return this._Settings.ContainsKey(key);
		}

		// Token: 0x04000103 RID: 259
		private Dictionary<string, object> _Settings = new Dictionary<string, object>();
	}
}
