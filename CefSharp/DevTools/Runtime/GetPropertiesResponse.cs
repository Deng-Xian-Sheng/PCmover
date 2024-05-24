using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200014F RID: 335
	[DataContract]
	public class GetPropertiesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0000E867 File Offset: 0x0000CA67
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0000E86F File Offset: 0x0000CA6F
		[DataMember]
		internal IList<PropertyDescriptor> result { get; set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x0000E878 File Offset: 0x0000CA78
		public IList<PropertyDescriptor> Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x0000E880 File Offset: 0x0000CA80
		// (set) Token: 0x060009AC RID: 2476 RVA: 0x0000E888 File Offset: 0x0000CA88
		[DataMember]
		internal IList<InternalPropertyDescriptor> internalProperties { get; set; }

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x0000E891 File Offset: 0x0000CA91
		public IList<InternalPropertyDescriptor> InternalProperties
		{
			get
			{
				return this.internalProperties;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x0000E899 File Offset: 0x0000CA99
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x0000E8A1 File Offset: 0x0000CAA1
		[DataMember]
		internal IList<PrivatePropertyDescriptor> privateProperties { get; set; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0000E8AA File Offset: 0x0000CAAA
		public IList<PrivatePropertyDescriptor> PrivateProperties
		{
			get
			{
				return this.privateProperties;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0000E8B2 File Offset: 0x0000CAB2
		// (set) Token: 0x060009B2 RID: 2482 RVA: 0x0000E8BA File Offset: 0x0000CABA
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x0000E8C3 File Offset: 0x0000CAC3
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
