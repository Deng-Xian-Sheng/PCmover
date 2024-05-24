using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200084D RID: 2125
	[ComVisible(true)]
	public class SinkProviderData
	{
		// Token: 0x06005A2F RID: 23087 RVA: 0x0013D69F File Offset: 0x0013B89F
		public SinkProviderData(string name)
		{
			this._name = name;
		}

		// Token: 0x17000F01 RID: 3841
		// (get) Token: 0x06005A30 RID: 23088 RVA: 0x0013D6C9 File Offset: 0x0013B8C9
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000F02 RID: 3842
		// (get) Token: 0x06005A31 RID: 23089 RVA: 0x0013D6D1 File Offset: 0x0013B8D1
		public IDictionary Properties
		{
			get
			{
				return this._properties;
			}
		}

		// Token: 0x17000F03 RID: 3843
		// (get) Token: 0x06005A32 RID: 23090 RVA: 0x0013D6D9 File Offset: 0x0013B8D9
		public IList Children
		{
			get
			{
				return this._children;
			}
		}

		// Token: 0x040028F7 RID: 10487
		private string _name;

		// Token: 0x040028F8 RID: 10488
		private Hashtable _properties = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

		// Token: 0x040028F9 RID: 10489
		private ArrayList _children = new ArrayList();
	}
}
