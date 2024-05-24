using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	// Token: 0x02000392 RID: 914
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class NeutralResourcesLanguageAttribute : Attribute
	{
		// Token: 0x06002D08 RID: 11528 RVA: 0x000AA1A6 File Offset: 0x000A83A6
		[__DynamicallyInvokable]
		public NeutralResourcesLanguageAttribute(string cultureName)
		{
			if (cultureName == null)
			{
				throw new ArgumentNullException("cultureName");
			}
			this._culture = cultureName;
			this._fallbackLoc = UltimateResourceFallbackLocation.MainAssembly;
		}

		// Token: 0x06002D09 RID: 11529 RVA: 0x000AA1CC File Offset: 0x000A83CC
		public NeutralResourcesLanguageAttribute(string cultureName, UltimateResourceFallbackLocation location)
		{
			if (cultureName == null)
			{
				throw new ArgumentNullException("cultureName");
			}
			if (!Enum.IsDefined(typeof(UltimateResourceFallbackLocation), location))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_InvalidNeutralResourcesLanguage_FallbackLoc", new object[]
				{
					location
				}));
			}
			this._culture = cultureName;
			this._fallbackLoc = location;
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06002D0A RID: 11530 RVA: 0x000AA231 File Offset: 0x000A8431
		[__DynamicallyInvokable]
		public string CultureName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._culture;
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06002D0B RID: 11531 RVA: 0x000AA239 File Offset: 0x000A8439
		public UltimateResourceFallbackLocation Location
		{
			get
			{
				return this._fallbackLoc;
			}
		}

		// Token: 0x04001227 RID: 4647
		private string _culture;

		// Token: 0x04001228 RID: 4648
		private UltimateResourceFallbackLocation _fallbackLoc;
	}
}
