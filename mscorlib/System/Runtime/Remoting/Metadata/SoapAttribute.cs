using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007DA RID: 2010
	[ComVisible(true)]
	public class SoapAttribute : Attribute
	{
		// Token: 0x0600570C RID: 22284 RVA: 0x00134BEB File Offset: 0x00132DEB
		internal void SetReflectInfo(object info)
		{
			this.ReflectInfo = info;
		}

		// Token: 0x17000E5D RID: 3677
		// (get) Token: 0x0600570D RID: 22285 RVA: 0x00134BF4 File Offset: 0x00132DF4
		// (set) Token: 0x0600570E RID: 22286 RVA: 0x00134BFC File Offset: 0x00132DFC
		public virtual string XmlNamespace
		{
			get
			{
				return this.ProtXmlNamespace;
			}
			set
			{
				this.ProtXmlNamespace = value;
			}
		}

		// Token: 0x17000E5E RID: 3678
		// (get) Token: 0x0600570F RID: 22287 RVA: 0x00134C05 File Offset: 0x00132E05
		// (set) Token: 0x06005710 RID: 22288 RVA: 0x00134C0D File Offset: 0x00132E0D
		public virtual bool UseAttribute
		{
			get
			{
				return this._bUseAttribute;
			}
			set
			{
				this._bUseAttribute = value;
			}
		}

		// Token: 0x17000E5F RID: 3679
		// (get) Token: 0x06005711 RID: 22289 RVA: 0x00134C16 File Offset: 0x00132E16
		// (set) Token: 0x06005712 RID: 22290 RVA: 0x00134C1E File Offset: 0x00132E1E
		public virtual bool Embedded
		{
			get
			{
				return this._bEmbedded;
			}
			set
			{
				this._bEmbedded = value;
			}
		}

		// Token: 0x040027DC RID: 10204
		protected string ProtXmlNamespace;

		// Token: 0x040027DD RID: 10205
		private bool _bUseAttribute;

		// Token: 0x040027DE RID: 10206
		private bool _bEmbedded;

		// Token: 0x040027DF RID: 10207
		protected object ReflectInfo;
	}
}
