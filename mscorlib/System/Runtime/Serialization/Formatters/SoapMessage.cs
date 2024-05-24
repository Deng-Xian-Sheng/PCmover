using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000764 RID: 1892
	[ComVisible(true)]
	[Serializable]
	public class SoapMessage : ISoapMessage
	{
		// Token: 0x17000DC0 RID: 3520
		// (get) Token: 0x0600530F RID: 21263 RVA: 0x00123C12 File Offset: 0x00121E12
		// (set) Token: 0x06005310 RID: 21264 RVA: 0x00123C1A File Offset: 0x00121E1A
		public string[] ParamNames
		{
			get
			{
				return this.paramNames;
			}
			set
			{
				this.paramNames = value;
			}
		}

		// Token: 0x17000DC1 RID: 3521
		// (get) Token: 0x06005311 RID: 21265 RVA: 0x00123C23 File Offset: 0x00121E23
		// (set) Token: 0x06005312 RID: 21266 RVA: 0x00123C2B File Offset: 0x00121E2B
		public object[] ParamValues
		{
			get
			{
				return this.paramValues;
			}
			set
			{
				this.paramValues = value;
			}
		}

		// Token: 0x17000DC2 RID: 3522
		// (get) Token: 0x06005313 RID: 21267 RVA: 0x00123C34 File Offset: 0x00121E34
		// (set) Token: 0x06005314 RID: 21268 RVA: 0x00123C3C File Offset: 0x00121E3C
		public Type[] ParamTypes
		{
			get
			{
				return this.paramTypes;
			}
			set
			{
				this.paramTypes = value;
			}
		}

		// Token: 0x17000DC3 RID: 3523
		// (get) Token: 0x06005315 RID: 21269 RVA: 0x00123C45 File Offset: 0x00121E45
		// (set) Token: 0x06005316 RID: 21270 RVA: 0x00123C4D File Offset: 0x00121E4D
		public string MethodName
		{
			get
			{
				return this.methodName;
			}
			set
			{
				this.methodName = value;
			}
		}

		// Token: 0x17000DC4 RID: 3524
		// (get) Token: 0x06005317 RID: 21271 RVA: 0x00123C56 File Offset: 0x00121E56
		// (set) Token: 0x06005318 RID: 21272 RVA: 0x00123C5E File Offset: 0x00121E5E
		public string XmlNameSpace
		{
			get
			{
				return this.xmlNameSpace;
			}
			set
			{
				this.xmlNameSpace = value;
			}
		}

		// Token: 0x17000DC5 RID: 3525
		// (get) Token: 0x06005319 RID: 21273 RVA: 0x00123C67 File Offset: 0x00121E67
		// (set) Token: 0x0600531A RID: 21274 RVA: 0x00123C6F File Offset: 0x00121E6F
		public Header[] Headers
		{
			get
			{
				return this.headers;
			}
			set
			{
				this.headers = value;
			}
		}

		// Token: 0x040024CF RID: 9423
		internal string[] paramNames;

		// Token: 0x040024D0 RID: 9424
		internal object[] paramValues;

		// Token: 0x040024D1 RID: 9425
		internal Type[] paramTypes;

		// Token: 0x040024D2 RID: 9426
		internal string methodName;

		// Token: 0x040024D3 RID: 9427
		internal string xmlNameSpace;

		// Token: 0x040024D4 RID: 9428
		internal Header[] headers;
	}
}
