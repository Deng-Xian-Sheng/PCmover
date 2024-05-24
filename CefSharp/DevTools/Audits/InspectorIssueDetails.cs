using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200042D RID: 1069
	[DataContract]
	public class InspectorIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B50 RID: 2896
		// (get) Token: 0x06001EF9 RID: 7929 RVA: 0x00023206 File Offset: 0x00021406
		// (set) Token: 0x06001EFA RID: 7930 RVA: 0x0002320E File Offset: 0x0002140E
		[DataMember(Name = "sameSiteCookieIssueDetails", IsRequired = false)]
		public SameSiteCookieIssueDetails SameSiteCookieIssueDetails { get; set; }

		// Token: 0x17000B51 RID: 2897
		// (get) Token: 0x06001EFB RID: 7931 RVA: 0x00023217 File Offset: 0x00021417
		// (set) Token: 0x06001EFC RID: 7932 RVA: 0x0002321F File Offset: 0x0002141F
		[DataMember(Name = "mixedContentIssueDetails", IsRequired = false)]
		public MixedContentIssueDetails MixedContentIssueDetails { get; set; }

		// Token: 0x17000B52 RID: 2898
		// (get) Token: 0x06001EFD RID: 7933 RVA: 0x00023228 File Offset: 0x00021428
		// (set) Token: 0x06001EFE RID: 7934 RVA: 0x00023230 File Offset: 0x00021430
		[DataMember(Name = "blockedByResponseIssueDetails", IsRequired = false)]
		public BlockedByResponseIssueDetails BlockedByResponseIssueDetails { get; set; }

		// Token: 0x17000B53 RID: 2899
		// (get) Token: 0x06001EFF RID: 7935 RVA: 0x00023239 File Offset: 0x00021439
		// (set) Token: 0x06001F00 RID: 7936 RVA: 0x00023241 File Offset: 0x00021441
		[DataMember(Name = "heavyAdIssueDetails", IsRequired = false)]
		public HeavyAdIssueDetails HeavyAdIssueDetails { get; set; }

		// Token: 0x17000B54 RID: 2900
		// (get) Token: 0x06001F01 RID: 7937 RVA: 0x0002324A File Offset: 0x0002144A
		// (set) Token: 0x06001F02 RID: 7938 RVA: 0x00023252 File Offset: 0x00021452
		[DataMember(Name = "contentSecurityPolicyIssueDetails", IsRequired = false)]
		public ContentSecurityPolicyIssueDetails ContentSecurityPolicyIssueDetails { get; set; }

		// Token: 0x17000B55 RID: 2901
		// (get) Token: 0x06001F03 RID: 7939 RVA: 0x0002325B File Offset: 0x0002145B
		// (set) Token: 0x06001F04 RID: 7940 RVA: 0x00023263 File Offset: 0x00021463
		[DataMember(Name = "sharedArrayBufferIssueDetails", IsRequired = false)]
		public SharedArrayBufferIssueDetails SharedArrayBufferIssueDetails { get; set; }

		// Token: 0x17000B56 RID: 2902
		// (get) Token: 0x06001F05 RID: 7941 RVA: 0x0002326C File Offset: 0x0002146C
		// (set) Token: 0x06001F06 RID: 7942 RVA: 0x00023274 File Offset: 0x00021474
		[DataMember(Name = "twaQualityEnforcementDetails", IsRequired = false)]
		public TrustedWebActivityIssueDetails TwaQualityEnforcementDetails { get; set; }

		// Token: 0x17000B57 RID: 2903
		// (get) Token: 0x06001F07 RID: 7943 RVA: 0x0002327D File Offset: 0x0002147D
		// (set) Token: 0x06001F08 RID: 7944 RVA: 0x00023285 File Offset: 0x00021485
		[DataMember(Name = "lowTextContrastIssueDetails", IsRequired = false)]
		public LowTextContrastIssueDetails LowTextContrastIssueDetails { get; set; }

		// Token: 0x17000B58 RID: 2904
		// (get) Token: 0x06001F09 RID: 7945 RVA: 0x0002328E File Offset: 0x0002148E
		// (set) Token: 0x06001F0A RID: 7946 RVA: 0x00023296 File Offset: 0x00021496
		[DataMember(Name = "corsIssueDetails", IsRequired = false)]
		public CorsIssueDetails CorsIssueDetails { get; set; }

		// Token: 0x17000B59 RID: 2905
		// (get) Token: 0x06001F0B RID: 7947 RVA: 0x0002329F File Offset: 0x0002149F
		// (set) Token: 0x06001F0C RID: 7948 RVA: 0x000232A7 File Offset: 0x000214A7
		[DataMember(Name = "attributionReportingIssueDetails", IsRequired = false)]
		public AttributionReportingIssueDetails AttributionReportingIssueDetails { get; set; }

		// Token: 0x17000B5A RID: 2906
		// (get) Token: 0x06001F0D RID: 7949 RVA: 0x000232B0 File Offset: 0x000214B0
		// (set) Token: 0x06001F0E RID: 7950 RVA: 0x000232B8 File Offset: 0x000214B8
		[DataMember(Name = "quirksModeIssueDetails", IsRequired = false)]
		public QuirksModeIssueDetails QuirksModeIssueDetails { get; set; }

		// Token: 0x17000B5B RID: 2907
		// (get) Token: 0x06001F0F RID: 7951 RVA: 0x000232C1 File Offset: 0x000214C1
		// (set) Token: 0x06001F10 RID: 7952 RVA: 0x000232C9 File Offset: 0x000214C9
		[DataMember(Name = "navigatorUserAgentIssueDetails", IsRequired = false)]
		public NavigatorUserAgentIssueDetails NavigatorUserAgentIssueDetails { get; set; }

		// Token: 0x17000B5C RID: 2908
		// (get) Token: 0x06001F11 RID: 7953 RVA: 0x000232D2 File Offset: 0x000214D2
		// (set) Token: 0x06001F12 RID: 7954 RVA: 0x000232DA File Offset: 0x000214DA
		[DataMember(Name = "genericIssueDetails", IsRequired = false)]
		public GenericIssueDetails GenericIssueDetails { get; set; }

		// Token: 0x17000B5D RID: 2909
		// (get) Token: 0x06001F13 RID: 7955 RVA: 0x000232E3 File Offset: 0x000214E3
		// (set) Token: 0x06001F14 RID: 7956 RVA: 0x000232EB File Offset: 0x000214EB
		[DataMember(Name = "deprecationIssueDetails", IsRequired = false)]
		public DeprecationIssueDetails DeprecationIssueDetails { get; set; }

		// Token: 0x17000B5E RID: 2910
		// (get) Token: 0x06001F15 RID: 7957 RVA: 0x000232F4 File Offset: 0x000214F4
		// (set) Token: 0x06001F16 RID: 7958 RVA: 0x000232FC File Offset: 0x000214FC
		[DataMember(Name = "clientHintIssueDetails", IsRequired = false)]
		public ClientHintIssueDetails ClientHintIssueDetails { get; set; }

		// Token: 0x17000B5F RID: 2911
		// (get) Token: 0x06001F17 RID: 7959 RVA: 0x00023305 File Offset: 0x00021505
		// (set) Token: 0x06001F18 RID: 7960 RVA: 0x0002330D File Offset: 0x0002150D
		[DataMember(Name = "federatedAuthRequestIssueDetails", IsRequired = false)]
		public FederatedAuthRequestIssueDetails FederatedAuthRequestIssueDetails { get; set; }
	}
}
