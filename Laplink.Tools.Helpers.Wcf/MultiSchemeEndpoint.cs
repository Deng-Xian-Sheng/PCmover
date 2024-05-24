using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000005 RID: 5
	public class MultiSchemeEndpoint
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000287C File Offset: 0x00000A7C
		// (set) Token: 0x06000041 RID: 65 RVA: 0x0000290C File Offset: 0x00000B0C
		public EndpointAddress Endpoint
		{
			get
			{
				List<MultiSchemeEndpoint.SchemeEndpointPair> schemeEndpointPairs = this._schemeEndpointPairs;
				lock (schemeEndpointPairs)
				{
					foreach (MultiSchemeEndpoint.SchemeEndpointPair schemeEndpointPair in this._schemeEndpointPairs)
					{
						if (schemeEndpointPair.Endpoint != null)
						{
							return schemeEndpointPair.Endpoint;
						}
					}
				}
				return null;
			}
			set
			{
				this.SetEndpoint(value);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000292C File Offset: 0x00000B2C
		private MultiSchemeEndpoint.SchemeEndpointPair GetPair(string scheme)
		{
			List<MultiSchemeEndpoint.SchemeEndpointPair> schemeEndpointPairs = this._schemeEndpointPairs;
			lock (schemeEndpointPairs)
			{
				foreach (MultiSchemeEndpoint.SchemeEndpointPair schemeEndpointPair in this._schemeEndpointPairs)
				{
					if (schemeEndpointPair.SchemeMatches(scheme))
					{
						return schemeEndpointPair;
					}
				}
			}
			return null;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000029B4 File Offset: 0x00000BB4
		public EndpointAddress GetEndpoint(string scheme)
		{
			List<MultiSchemeEndpoint.SchemeEndpointPair> schemeEndpointPairs = this._schemeEndpointPairs;
			EndpointAddress result;
			lock (schemeEndpointPairs)
			{
				MultiSchemeEndpoint.SchemeEndpointPair pair = this.GetPair(scheme);
				result = ((pair != null) ? pair.Endpoint : null);
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002A04 File Offset: 0x00000C04
		public void AddScheme(string scheme)
		{
			List<MultiSchemeEndpoint.SchemeEndpointPair> schemeEndpointPairs = this._schemeEndpointPairs;
			lock (schemeEndpointPairs)
			{
				if (this.GetPair(scheme) == null)
				{
					this._schemeEndpointPairs.Add(new MultiSchemeEndpoint.SchemeEndpointPair(scheme));
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002A58 File Offset: 0x00000C58
		public bool SetEndpoint(EndpointAddress endpoint)
		{
			bool result = false;
			List<MultiSchemeEndpoint.SchemeEndpointPair> schemeEndpointPairs = this._schemeEndpointPairs;
			lock (schemeEndpointPairs)
			{
				if (endpoint == null)
				{
					using (List<MultiSchemeEndpoint.SchemeEndpointPair>.Enumerator enumerator = this._schemeEndpointPairs.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							MultiSchemeEndpoint.SchemeEndpointPair schemeEndpointPair = enumerator.Current;
							if (schemeEndpointPair.Endpoint != null)
							{
								schemeEndpointPair.Endpoint = null;
								result = true;
							}
						}
						return result;
					}
				}
				MultiSchemeEndpoint.SchemeEndpointPair pair = this.GetPair(endpoint.Uri.Scheme);
				if (pair != null && pair.Endpoint != endpoint)
				{
					pair.Endpoint = endpoint;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002B24 File Offset: 0x00000D24
		public bool RemoveEndpoint(EndpointAddress endpoint)
		{
			if (endpoint == null)
			{
				return false;
			}
			List<MultiSchemeEndpoint.SchemeEndpointPair> schemeEndpointPairs = this._schemeEndpointPairs;
			lock (schemeEndpointPairs)
			{
				foreach (MultiSchemeEndpoint.SchemeEndpointPair schemeEndpointPair in this._schemeEndpointPairs)
				{
					if (schemeEndpointPair.Endpoint == endpoint)
					{
						schemeEndpointPair.Endpoint = null;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04000019 RID: 25
		private List<MultiSchemeEndpoint.SchemeEndpointPair> _schemeEndpointPairs = new List<MultiSchemeEndpoint.SchemeEndpointPair>();

		// Token: 0x0200000C RID: 12
		private class SchemeEndpointPair
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600006C RID: 108 RVA: 0x0000305C File Offset: 0x0000125C
			internal string Scheme { get; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600006D RID: 109 RVA: 0x00003064 File Offset: 0x00001264
			// (set) Token: 0x0600006E RID: 110 RVA: 0x0000306C File Offset: 0x0000126C
			internal EndpointAddress Endpoint { get; set; }

			// Token: 0x0600006F RID: 111 RVA: 0x00003075 File Offset: 0x00001275
			internal SchemeEndpointPair(string scheme)
			{
				this.Scheme = scheme;
			}

			// Token: 0x06000070 RID: 112 RVA: 0x00003084 File Offset: 0x00001284
			internal bool SchemeMatches(string scheme)
			{
				return this.Scheme == scheme;
			}
		}
	}
}
