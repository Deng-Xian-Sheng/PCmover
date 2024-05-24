using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x0200060F RID: 1551
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	public sealed class ObfuscationAttribute : Attribute
	{
		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x060047EE RID: 18414 RVA: 0x00105D1B File Offset: 0x00103F1B
		// (set) Token: 0x060047EF RID: 18415 RVA: 0x00105D23 File Offset: 0x00103F23
		public bool StripAfterObfuscation
		{
			get
			{
				return this.m_strip;
			}
			set
			{
				this.m_strip = value;
			}
		}

		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x060047F0 RID: 18416 RVA: 0x00105D2C File Offset: 0x00103F2C
		// (set) Token: 0x060047F1 RID: 18417 RVA: 0x00105D34 File Offset: 0x00103F34
		public bool Exclude
		{
			get
			{
				return this.m_exclude;
			}
			set
			{
				this.m_exclude = value;
			}
		}

		// Token: 0x17000B14 RID: 2836
		// (get) Token: 0x060047F2 RID: 18418 RVA: 0x00105D3D File Offset: 0x00103F3D
		// (set) Token: 0x060047F3 RID: 18419 RVA: 0x00105D45 File Offset: 0x00103F45
		public bool ApplyToMembers
		{
			get
			{
				return this.m_applyToMembers;
			}
			set
			{
				this.m_applyToMembers = value;
			}
		}

		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x060047F4 RID: 18420 RVA: 0x00105D4E File Offset: 0x00103F4E
		// (set) Token: 0x060047F5 RID: 18421 RVA: 0x00105D56 File Offset: 0x00103F56
		public string Feature
		{
			get
			{
				return this.m_feature;
			}
			set
			{
				this.m_feature = value;
			}
		}

		// Token: 0x04001DBE RID: 7614
		private bool m_strip = true;

		// Token: 0x04001DBF RID: 7615
		private bool m_exclude = true;

		// Token: 0x04001DC0 RID: 7616
		private bool m_applyToMembers = true;

		// Token: 0x04001DC1 RID: 7617
		private string m_feature = "all";
	}
}
