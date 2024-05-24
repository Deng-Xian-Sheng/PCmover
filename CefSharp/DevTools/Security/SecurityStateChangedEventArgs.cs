using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000220 RID: 544
	[DataContract]
	public class SecurityStateChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00014AAC File Offset: 0x00012CAC
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x00014AC8 File Offset: 0x00012CC8
		public SecurityState SecurityState
		{
			get
			{
				return (SecurityState)DevToolsDomainEventArgsBase.StringToEnum(typeof(SecurityState), this.securityState);
			}
			set
			{
				this.securityState = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x00014ADB File Offset: 0x00012CDB
		// (set) Token: 0x06000FBD RID: 4029 RVA: 0x00014AE3 File Offset: 0x00012CE3
		[DataMember(Name = "securityState", IsRequired = true)]
		internal string securityState { get; private set; }

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x00014AEC File Offset: 0x00012CEC
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x00014AF4 File Offset: 0x00012CF4
		[DataMember(Name = "schemeIsCryptographic", IsRequired = true)]
		public bool SchemeIsCryptographic { get; private set; }

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x00014AFD File Offset: 0x00012CFD
		// (set) Token: 0x06000FC1 RID: 4033 RVA: 0x00014B05 File Offset: 0x00012D05
		[DataMember(Name = "explanations", IsRequired = true)]
		public IList<SecurityStateExplanation> Explanations { get; private set; }

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x00014B0E File Offset: 0x00012D0E
		// (set) Token: 0x06000FC3 RID: 4035 RVA: 0x00014B16 File Offset: 0x00012D16
		[DataMember(Name = "insecureContentStatus", IsRequired = true)]
		public InsecureContentStatus InsecureContentStatus { get; private set; }

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00014B1F File Offset: 0x00012D1F
		// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x00014B27 File Offset: 0x00012D27
		[DataMember(Name = "summary", IsRequired = false)]
		public string Summary { get; private set; }
	}
}
