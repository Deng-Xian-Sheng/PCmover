using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000888 RID: 2184
	[ComVisible(true)]
	[Serializable]
	public class Header
	{
		// Token: 0x06005C9F RID: 23711 RVA: 0x00144EA7 File Offset: 0x001430A7
		public Header(string _Name, object _Value) : this(_Name, _Value, true)
		{
		}

		// Token: 0x06005CA0 RID: 23712 RVA: 0x00144EB2 File Offset: 0x001430B2
		public Header(string _Name, object _Value, bool _MustUnderstand)
		{
			this.Name = _Name;
			this.Value = _Value;
			this.MustUnderstand = _MustUnderstand;
		}

		// Token: 0x06005CA1 RID: 23713 RVA: 0x00144ECF File Offset: 0x001430CF
		public Header(string _Name, object _Value, bool _MustUnderstand, string _HeaderNamespace)
		{
			this.Name = _Name;
			this.Value = _Value;
			this.MustUnderstand = _MustUnderstand;
			this.HeaderNamespace = _HeaderNamespace;
		}

		// Token: 0x040029CC RID: 10700
		public string Name;

		// Token: 0x040029CD RID: 10701
		public object Value;

		// Token: 0x040029CE RID: 10702
		public bool MustUnderstand;

		// Token: 0x040029CF RID: 10703
		public string HeaderNamespace;
	}
}
