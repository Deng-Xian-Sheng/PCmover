using System;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007CF RID: 1999
	internal abstract class RemotingCachedData
	{
		// Token: 0x060056C4 RID: 22212 RVA: 0x001342B0 File Offset: 0x001324B0
		internal SoapAttribute GetSoapAttribute()
		{
			if (this._soapAttr == null)
			{
				lock (this)
				{
					if (this._soapAttr == null)
					{
						this._soapAttr = this.GetSoapAttributeNoLock();
					}
				}
			}
			return this._soapAttr;
		}

		// Token: 0x060056C5 RID: 22213
		internal abstract SoapAttribute GetSoapAttributeNoLock();

		// Token: 0x040027AE RID: 10158
		private SoapAttribute _soapAttr;
	}
}
