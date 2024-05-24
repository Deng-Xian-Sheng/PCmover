using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.ModelBinding;

namespace CefSharp.Internals
{
	// Token: 0x020000DA RID: 218
	[DataContract]
	public class JavascriptObject
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00009D16 File Offset: 0x00007F16
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x00009D1E File Offset: 0x00007F1E
		[DataMember]
		public long Id { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x00009D27 File Offset: 0x00007F27
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x00009D2F File Offset: 0x00007F2F
		[DataMember]
		public string Name { get; set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00009D38 File Offset: 0x00007F38
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00009D40 File Offset: 0x00007F40
		[DataMember]
		public string JavascriptName { get; set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00009D49 File Offset: 0x00007F49
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x00009D51 File Offset: 0x00007F51
		[DataMember]
		public bool IsAsync { get; set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00009D5A File Offset: 0x00007F5A
		// (set) Token: 0x06000669 RID: 1641 RVA: 0x00009D62 File Offset: 0x00007F62
		[DataMember]
		public List<JavascriptMethod> Methods { get; private set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00009D6B File Offset: 0x00007F6B
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x00009D73 File Offset: 0x00007F73
		[DataMember]
		public List<JavascriptProperty> Properties { get; private set; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x00009D7C File Offset: 0x00007F7C
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x00009D84 File Offset: 0x00007F84
		public bool RootObject { get; set; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00009D8D File Offset: 0x00007F8D
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x00009D95 File Offset: 0x00007F95
		public object Value { get; set; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00009D9E File Offset: 0x00007F9E
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x00009DA6 File Offset: 0x00007FA6
		public IBinder Binder { get; set; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x00009DAF File Offset: 0x00007FAF
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x00009DB7 File Offset: 0x00007FB7
		public IMethodInterceptor MethodInterceptor { get; set; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x00009DC0 File Offset: 0x00007FC0
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x00009DC8 File Offset: 0x00007FC8
		public IPropertyInterceptor PropertyInterceptor { get; set; }

		// Token: 0x06000676 RID: 1654 RVA: 0x00009DD1 File Offset: 0x00007FD1
		public JavascriptObject()
		{
			this.Methods = new List<JavascriptMethod>();
			this.Properties = new List<JavascriptProperty>();
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00009DEF File Offset: 0x00007FEF
		public override string ToString()
		{
			if (this.Value == null)
			{
				return base.ToString();
			}
			return this.Value.ToString();
		}
	}
}
