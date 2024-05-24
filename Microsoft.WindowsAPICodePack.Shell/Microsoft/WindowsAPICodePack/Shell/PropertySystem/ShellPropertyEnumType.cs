using System;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000DE RID: 222
	public class ShellPropertyEnumType
	{
		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x00024A18 File Offset: 0x00022C18
		// (set) Token: 0x06000880 RID: 2176 RVA: 0x00024A0C File Offset: 0x00022C0C
		private IPropertyEnumType NativePropertyEnumType { get; set; }

		// Token: 0x06000882 RID: 2178 RVA: 0x00024A2F File Offset: 0x00022C2F
		internal ShellPropertyEnumType(IPropertyEnumType nativePropertyEnumType)
		{
			this.NativePropertyEnumType = nativePropertyEnumType;
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x00024A44 File Offset: 0x00022C44
		public string DisplayText
		{
			get
			{
				if (this.displayText == null)
				{
					this.NativePropertyEnumType.GetDisplayText(out this.displayText);
				}
				return this.displayText;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x00024A80 File Offset: 0x00022C80
		public PropEnumType EnumType
		{
			get
			{
				if (this.enumType == null)
				{
					PropEnumType value;
					this.NativePropertyEnumType.GetEnumType(out value);
					this.enumType = new PropEnumType?(value);
				}
				return this.enumType.Value;
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x00024AC8 File Offset: 0x00022CC8
		public object RangeMinValue
		{
			get
			{
				if (this.minValue == null)
				{
					using (PropVariant propVariant = new PropVariant())
					{
						this.NativePropertyEnumType.GetRangeMinValue(propVariant);
						this.minValue = propVariant.Value;
					}
				}
				return this.minValue;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x00024B38 File Offset: 0x00022D38
		public object RangeSetValue
		{
			get
			{
				if (this.setValue == null)
				{
					using (PropVariant propVariant = new PropVariant())
					{
						this.NativePropertyEnumType.GetRangeSetValue(propVariant);
						this.setValue = propVariant.Value;
					}
				}
				return this.setValue;
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x00024BA8 File Offset: 0x00022DA8
		public object RangeValue
		{
			get
			{
				if (this.enumerationValue == null)
				{
					using (PropVariant propVariant = new PropVariant())
					{
						this.NativePropertyEnumType.GetValue(propVariant);
						this.enumerationValue = propVariant.Value;
					}
				}
				return this.enumerationValue;
			}
		}

		// Token: 0x04000423 RID: 1059
		private string displayText;

		// Token: 0x04000424 RID: 1060
		private PropEnumType? enumType;

		// Token: 0x04000425 RID: 1061
		private object minValue;

		// Token: 0x04000426 RID: 1062
		private object setValue;

		// Token: 0x04000427 RID: 1063
		private object enumerationValue;
	}
}
