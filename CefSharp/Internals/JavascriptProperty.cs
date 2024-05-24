using System;
using System.Runtime.Serialization;

namespace CefSharp.Internals
{
	// Token: 0x020000DC RID: 220
	[DataContract]
	public class JavascriptProperty
	{
		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0000AE82 File Offset: 0x00009082
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x0000AE8A File Offset: 0x0000908A
		[DataMember]
		public JavascriptObject JsObject { get; set; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0000AE93 File Offset: 0x00009093
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x0000AE9B File Offset: 0x0000909B
		public Action<object, object> SetValue { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0000AEA4 File Offset: 0x000090A4
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0000AEAC File Offset: 0x000090AC
		public Func<object, object> GetValue { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0000AEB5 File Offset: 0x000090B5
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x0000AEBD File Offset: 0x000090BD
		[DataMember]
		public long Id { get; set; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x0000AEC6 File Offset: 0x000090C6
		// (set) Token: 0x060006A5 RID: 1701 RVA: 0x0000AECE File Offset: 0x000090CE
		[DataMember]
		public string ManagedName { get; set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x0000AED7 File Offset: 0x000090D7
		// (set) Token: 0x060006A7 RID: 1703 RVA: 0x0000AEDF File Offset: 0x000090DF
		[DataMember]
		public string JavascriptName { get; set; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x0000AEE8 File Offset: 0x000090E8
		// (set) Token: 0x060006A9 RID: 1705 RVA: 0x0000AEF0 File Offset: 0x000090F0
		[DataMember]
		public bool IsComplexType { get; set; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060006AA RID: 1706 RVA: 0x0000AEF9 File Offset: 0x000090F9
		// (set) Token: 0x060006AB RID: 1707 RVA: 0x0000AF01 File Offset: 0x00009101
		[DataMember]
		public bool IsReadOnly { get; set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060006AC RID: 1708 RVA: 0x0000AF0A File Offset: 0x0000910A
		// (set) Token: 0x060006AD RID: 1709 RVA: 0x0000AF12 File Offset: 0x00009112
		[DataMember]
		public object PropertyValue { get; set; }

		// Token: 0x060006AE RID: 1710 RVA: 0x0000AF1B File Offset: 0x0000911B
		public override string ToString()
		{
			return this.ManagedName ?? base.ToString();
		}
	}
}
