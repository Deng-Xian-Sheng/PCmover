using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B6 RID: 694
	[DataContract]
	public class CorsErrorStatus : DevToolsDomainEntityBase
	{
		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x060013DE RID: 5086 RVA: 0x000186F9 File Offset: 0x000168F9
		// (set) Token: 0x060013DF RID: 5087 RVA: 0x00018715 File Offset: 0x00016915
		public CorsError CorsError
		{
			get
			{
				return (CorsError)DevToolsDomainEntityBase.StringToEnum(typeof(CorsError), this.corsError);
			}
			set
			{
				this.corsError = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x00018728 File Offset: 0x00016928
		// (set) Token: 0x060013E1 RID: 5089 RVA: 0x00018730 File Offset: 0x00016930
		[DataMember(Name = "corsError", IsRequired = true)]
		internal string corsError { get; set; }

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x060013E2 RID: 5090 RVA: 0x00018739 File Offset: 0x00016939
		// (set) Token: 0x060013E3 RID: 5091 RVA: 0x00018741 File Offset: 0x00016941
		[DataMember(Name = "failedParameter", IsRequired = true)]
		public string FailedParameter { get; set; }
	}
}
