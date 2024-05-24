using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x0200036B RID: 875
	[DataContract]
	public class InlineTextBox : DevToolsDomainEntityBase
	{
		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x0600196D RID: 6509 RVA: 0x0001E1BF File Offset: 0x0001C3BF
		// (set) Token: 0x0600196E RID: 6510 RVA: 0x0001E1C7 File Offset: 0x0001C3C7
		[DataMember(Name = "boundingBox", IsRequired = true)]
		public Rect BoundingBox { get; set; }

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x0600196F RID: 6511 RVA: 0x0001E1D0 File Offset: 0x0001C3D0
		// (set) Token: 0x06001970 RID: 6512 RVA: 0x0001E1D8 File Offset: 0x0001C3D8
		[DataMember(Name = "startCharacterIndex", IsRequired = true)]
		public int StartCharacterIndex { get; set; }

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x06001971 RID: 6513 RVA: 0x0001E1E1 File Offset: 0x0001C3E1
		// (set) Token: 0x06001972 RID: 6514 RVA: 0x0001E1E9 File Offset: 0x0001C3E9
		[DataMember(Name = "numCharacters", IsRequired = true)]
		public int NumCharacters { get; set; }
	}
}
