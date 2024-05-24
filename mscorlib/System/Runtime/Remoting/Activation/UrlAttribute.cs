using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x0200089E RID: 2206
	[SecurityCritical]
	[ComVisible(true)]
	[Serializable]
	public sealed class UrlAttribute : ContextAttribute
	{
		// Token: 0x06005D60 RID: 23904 RVA: 0x00148E84 File Offset: 0x00147084
		[SecurityCritical]
		public UrlAttribute(string callsiteURL) : base(UrlAttribute.propertyName)
		{
			if (callsiteURL == null)
			{
				throw new ArgumentNullException("callsiteURL");
			}
			this.url = callsiteURL;
		}

		// Token: 0x06005D61 RID: 23905 RVA: 0x00148EA6 File Offset: 0x001470A6
		[SecuritySafeCritical]
		public override bool Equals(object o)
		{
			return o is IContextProperty && o is UrlAttribute && ((UrlAttribute)o).UrlValue.Equals(this.url);
		}

		// Token: 0x06005D62 RID: 23906 RVA: 0x00148ED0 File Offset: 0x001470D0
		[SecuritySafeCritical]
		public override int GetHashCode()
		{
			return this.url.GetHashCode();
		}

		// Token: 0x06005D63 RID: 23907 RVA: 0x00148EDD File Offset: 0x001470DD
		[SecurityCritical]
		[ComVisible(true)]
		public override bool IsContextOK(Context ctx, IConstructionCallMessage msg)
		{
			return false;
		}

		// Token: 0x06005D64 RID: 23908 RVA: 0x00148EE0 File Offset: 0x001470E0
		[SecurityCritical]
		[ComVisible(true)]
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
		}

		// Token: 0x1700100D RID: 4109
		// (get) Token: 0x06005D65 RID: 23909 RVA: 0x00148EE2 File Offset: 0x001470E2
		public string UrlValue
		{
			[SecurityCritical]
			get
			{
				return this.url;
			}
		}

		// Token: 0x04002A03 RID: 10755
		private string url;

		// Token: 0x04002A04 RID: 10756
		private static string propertyName = "UrlAttribute";
	}
}
