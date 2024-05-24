using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000358 RID: 856
	[DataContract]
	public class CanEmulateResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x060018B6 RID: 6326 RVA: 0x0001D277 File Offset: 0x0001B477
		// (set) Token: 0x060018B7 RID: 6327 RVA: 0x0001D27F File Offset: 0x0001B47F
		[DataMember]
		internal bool result { get; set; }

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x060018B8 RID: 6328 RVA: 0x0001D288 File Offset: 0x0001B488
		public bool Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
