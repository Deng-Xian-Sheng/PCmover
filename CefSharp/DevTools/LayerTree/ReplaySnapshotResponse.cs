using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x0200032A RID: 810
	[DataContract]
	public class ReplaySnapshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x0001BA2C File Offset: 0x00019C2C
		// (set) Token: 0x060017BD RID: 6077 RVA: 0x0001BA34 File Offset: 0x00019C34
		[DataMember]
		internal string dataURL { get; set; }

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x0001BA3D File Offset: 0x00019C3D
		public string DataURL
		{
			get
			{
				return this.dataURL;
			}
		}
	}
}
