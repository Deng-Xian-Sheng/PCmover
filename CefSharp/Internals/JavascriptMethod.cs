using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.Internals
{
	// Token: 0x020000D9 RID: 217
	[DataContract]
	public class JavascriptMethod
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x00009C74 File Offset: 0x00007E74
		// (set) Token: 0x0600064F RID: 1615 RVA: 0x00009C7C File Offset: 0x00007E7C
		public Func<object, object[], object> Function { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x00009C85 File Offset: 0x00007E85
		// (set) Token: 0x06000651 RID: 1617 RVA: 0x00009C8D File Offset: 0x00007E8D
		[DataMember]
		public long Id { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x00009C96 File Offset: 0x00007E96
		// (set) Token: 0x06000653 RID: 1619 RVA: 0x00009C9E File Offset: 0x00007E9E
		[DataMember]
		public string ManagedName { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x00009CA7 File Offset: 0x00007EA7
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x00009CAF File Offset: 0x00007EAF
		[DataMember]
		public string JavascriptName { get; set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x00009CB8 File Offset: 0x00007EB8
		// (set) Token: 0x06000657 RID: 1623 RVA: 0x00009CC0 File Offset: 0x00007EC0
		public List<MethodParameter> Parameters { get; set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x00009CC9 File Offset: 0x00007EC9
		// (set) Token: 0x06000659 RID: 1625 RVA: 0x00009CD1 File Offset: 0x00007ED1
		public bool HasParamArray { get; set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x00009CDA File Offset: 0x00007EDA
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x00009CE2 File Offset: 0x00007EE2
		public int ParameterCount { get; set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x00009CEB File Offset: 0x00007EEB
		// (set) Token: 0x0600065D RID: 1629 RVA: 0x00009CF3 File Offset: 0x00007EF3
		public Type ReturnType { get; set; }

		// Token: 0x0600065E RID: 1630 RVA: 0x00009CFC File Offset: 0x00007EFC
		public override string ToString()
		{
			return this.ManagedName ?? base.ToString();
		}
	}
}
