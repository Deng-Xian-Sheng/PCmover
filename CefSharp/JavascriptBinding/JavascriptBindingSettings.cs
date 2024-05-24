using System;
using CefSharp.Internals;

namespace CefSharp.JavascriptBinding
{
	// Token: 0x020000BF RID: 191
	public class JavascriptBindingSettings : FreezableBase
	{
		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x00009326 File Offset: 0x00007526
		// (set) Token: 0x060005BE RID: 1470 RVA: 0x0000932E File Offset: 0x0000752E
		public bool JavascriptBindingApiEnabled
		{
			get
			{
				return this.jsBindingApiEnabled;
			}
			set
			{
				base.ThrowIfFrozen("JavascriptBindingApiEnabled");
				this.jsBindingApiEnabled = value;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x00009342 File Offset: 0x00007542
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000934A File Offset: 0x0000754A
		public string JavascriptBindingApiGlobalObjectName
		{
			get
			{
				return this.jsBindingGlobalObjectName;
			}
			set
			{
				base.ThrowIfFrozen("JavascriptBindingApiGlobalObjectName");
				if (!StringCheck.IsLettersAndNumbers(value))
				{
					throw new Exception("invalid or illegal characters used for binding property names. Alphanumeric and underscores characters only.");
				}
				this.jsBindingGlobalObjectName = value;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x00009371 File Offset: 0x00007571
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x00009379 File Offset: 0x00007579
		public bool LegacyBindingEnabled
		{
			get
			{
				return this.legacyBindingEnabled;
			}
			set
			{
				base.ThrowIfFrozen("LegacyBindingEnabled");
				this.legacyBindingEnabled = value;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0000938D File Offset: 0x0000758D
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x00009395 File Offset: 0x00007595
		public bool AlwaysInterceptAsynchronously
		{
			get
			{
				return this.alwaysInterceptAsynchronously;
			}
			set
			{
				base.ThrowIfFrozen("AlwaysInterceptAsynchronously");
				this.alwaysInterceptAsynchronously = value;
			}
		}

		// Token: 0x04000329 RID: 809
		private bool alwaysInterceptAsynchronously;

		// Token: 0x0400032A RID: 810
		private bool legacyBindingEnabled;

		// Token: 0x0400032B RID: 811
		private string jsBindingGlobalObjectName;

		// Token: 0x0400032C RID: 812
		private bool jsBindingApiEnabled = true;
	}
}
