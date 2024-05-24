using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200023D RID: 573
	[DataContract]
	public class Frame : DevToolsDomainEntityBase
	{
		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x0600104E RID: 4174 RVA: 0x000151BF File Offset: 0x000133BF
		// (set) Token: 0x0600104F RID: 4175 RVA: 0x000151C7 File Offset: 0x000133C7
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; set; }

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06001050 RID: 4176 RVA: 0x000151D0 File Offset: 0x000133D0
		// (set) Token: 0x06001051 RID: 4177 RVA: 0x000151D8 File Offset: 0x000133D8
		[DataMember(Name = "parentId", IsRequired = false)]
		public string ParentId { get; set; }

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x000151E1 File Offset: 0x000133E1
		// (set) Token: 0x06001053 RID: 4179 RVA: 0x000151E9 File Offset: 0x000133E9
		[DataMember(Name = "loaderId", IsRequired = true)]
		public string LoaderId { get; set; }

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06001054 RID: 4180 RVA: 0x000151F2 File Offset: 0x000133F2
		// (set) Token: 0x06001055 RID: 4181 RVA: 0x000151FA File Offset: 0x000133FA
		[DataMember(Name = "name", IsRequired = false)]
		public string Name { get; set; }

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06001056 RID: 4182 RVA: 0x00015203 File Offset: 0x00013403
		// (set) Token: 0x06001057 RID: 4183 RVA: 0x0001520B File Offset: 0x0001340B
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06001058 RID: 4184 RVA: 0x00015214 File Offset: 0x00013414
		// (set) Token: 0x06001059 RID: 4185 RVA: 0x0001521C File Offset: 0x0001341C
		[DataMember(Name = "urlFragment", IsRequired = false)]
		public string UrlFragment { get; set; }

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x0600105A RID: 4186 RVA: 0x00015225 File Offset: 0x00013425
		// (set) Token: 0x0600105B RID: 4187 RVA: 0x0001522D File Offset: 0x0001342D
		[DataMember(Name = "domainAndRegistry", IsRequired = true)]
		public string DomainAndRegistry { get; set; }

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x0600105C RID: 4188 RVA: 0x00015236 File Offset: 0x00013436
		// (set) Token: 0x0600105D RID: 4189 RVA: 0x0001523E File Offset: 0x0001343E
		[DataMember(Name = "securityOrigin", IsRequired = true)]
		public string SecurityOrigin { get; set; }

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x0600105E RID: 4190 RVA: 0x00015247 File Offset: 0x00013447
		// (set) Token: 0x0600105F RID: 4191 RVA: 0x0001524F File Offset: 0x0001344F
		[DataMember(Name = "mimeType", IsRequired = true)]
		public string MimeType { get; set; }

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06001060 RID: 4192 RVA: 0x00015258 File Offset: 0x00013458
		// (set) Token: 0x06001061 RID: 4193 RVA: 0x00015260 File Offset: 0x00013460
		[DataMember(Name = "unreachableUrl", IsRequired = false)]
		public string UnreachableUrl { get; set; }

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06001062 RID: 4194 RVA: 0x00015269 File Offset: 0x00013469
		// (set) Token: 0x06001063 RID: 4195 RVA: 0x00015271 File Offset: 0x00013471
		[DataMember(Name = "adFrameStatus", IsRequired = false)]
		public AdFrameStatus AdFrameStatus { get; set; }

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06001064 RID: 4196 RVA: 0x0001527A File Offset: 0x0001347A
		// (set) Token: 0x06001065 RID: 4197 RVA: 0x00015296 File Offset: 0x00013496
		public SecureContextType SecureContextType
		{
			get
			{
				return (SecureContextType)DevToolsDomainEntityBase.StringToEnum(typeof(SecureContextType), this.secureContextType);
			}
			set
			{
				this.secureContextType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06001066 RID: 4198 RVA: 0x000152A9 File Offset: 0x000134A9
		// (set) Token: 0x06001067 RID: 4199 RVA: 0x000152B1 File Offset: 0x000134B1
		[DataMember(Name = "secureContextType", IsRequired = true)]
		internal string secureContextType { get; set; }

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06001068 RID: 4200 RVA: 0x000152BA File Offset: 0x000134BA
		// (set) Token: 0x06001069 RID: 4201 RVA: 0x000152D6 File Offset: 0x000134D6
		public CrossOriginIsolatedContextType CrossOriginIsolatedContextType
		{
			get
			{
				return (CrossOriginIsolatedContextType)DevToolsDomainEntityBase.StringToEnum(typeof(CrossOriginIsolatedContextType), this.crossOriginIsolatedContextType);
			}
			set
			{
				this.crossOriginIsolatedContextType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x0600106A RID: 4202 RVA: 0x000152E9 File Offset: 0x000134E9
		// (set) Token: 0x0600106B RID: 4203 RVA: 0x000152F1 File Offset: 0x000134F1
		[DataMember(Name = "crossOriginIsolatedContextType", IsRequired = true)]
		internal string crossOriginIsolatedContextType { get; set; }

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x0600106C RID: 4204 RVA: 0x000152FA File Offset: 0x000134FA
		// (set) Token: 0x0600106D RID: 4205 RVA: 0x00015316 File Offset: 0x00013516
		public GatedAPIFeatures[] GatedAPIFeatures
		{
			get
			{
				return (GatedAPIFeatures[])DevToolsDomainEntityBase.StringToEnum(typeof(GatedAPIFeatures[]), this.gatedAPIFeatures);
			}
			set
			{
				this.gatedAPIFeatures = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x0600106E RID: 4206 RVA: 0x00015324 File Offset: 0x00013524
		// (set) Token: 0x0600106F RID: 4207 RVA: 0x0001532C File Offset: 0x0001352C
		[DataMember(Name = "gatedAPIFeatures", IsRequired = true)]
		internal string gatedAPIFeatures { get; set; }
	}
}
