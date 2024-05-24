using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D1 RID: 721
	[DataContract]
	public class SignedExchangeError : DevToolsDomainEntityBase
	{
		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x060014EB RID: 5355 RVA: 0x0001920F File Offset: 0x0001740F
		// (set) Token: 0x060014EC RID: 5356 RVA: 0x00019217 File Offset: 0x00017417
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; set; }

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x060014ED RID: 5357 RVA: 0x00019220 File Offset: 0x00017420
		// (set) Token: 0x060014EE RID: 5358 RVA: 0x00019228 File Offset: 0x00017428
		[DataMember(Name = "signatureIndex", IsRequired = false)]
		public int? SignatureIndex { get; set; }

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x060014EF RID: 5359 RVA: 0x00019231 File Offset: 0x00017431
		// (set) Token: 0x060014F0 RID: 5360 RVA: 0x0001924D File Offset: 0x0001744D
		public SignedExchangeErrorField? ErrorField
		{
			get
			{
				return (SignedExchangeErrorField?)DevToolsDomainEntityBase.StringToEnum(typeof(SignedExchangeErrorField?), this.errorField);
			}
			set
			{
				this.errorField = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x060014F1 RID: 5361 RVA: 0x00019260 File Offset: 0x00017460
		// (set) Token: 0x060014F2 RID: 5362 RVA: 0x00019268 File Offset: 0x00017468
		[DataMember(Name = "errorField", IsRequired = false)]
		internal string errorField { get; set; }
	}
}
