using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200013F RID: 319
	public class ShellPropertyDescription : IDisposable
	{
		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x0003342C File Offset: 0x0003162C
		public string CanonicalName
		{
			get
			{
				if (this.canonicalName == null)
				{
					PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref this.propertyKey, out this.canonicalName);
				}
				return this.canonicalName;
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00033468 File Offset: 0x00031668
		public PropertyKey PropertyKey
		{
			get
			{
				return this.propertyKey;
			}
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00033480 File Offset: 0x00031680
		public string DisplayName
		{
			get
			{
				if (this.NativePropertyDescription != null && this.displayName == null)
				{
					IntPtr zero = IntPtr.Zero;
					HResult result = this.NativePropertyDescription.GetDisplayName(out zero);
					if (CoreErrorHelper.Succeeded(result) && zero != IntPtr.Zero)
					{
						this.displayName = Marshal.PtrToStringUni(zero);
						Marshal.FreeCoTaskMem(zero);
					}
				}
				return this.displayName;
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00033500 File Offset: 0x00031700
		public string EditInvitation
		{
			get
			{
				if (this.NativePropertyDescription != null && this.editInvitation == null)
				{
					IntPtr zero = IntPtr.Zero;
					HResult result = this.NativePropertyDescription.GetEditInvitation(out zero);
					if (CoreErrorHelper.Succeeded(result) && zero != IntPtr.Zero)
					{
						this.editInvitation = Marshal.PtrToStringUni(zero);
						Marshal.FreeCoTaskMem(zero);
					}
				}
				return this.editInvitation;
			}
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00033580 File Offset: 0x00031780
		public VarEnum VarEnumType
		{
			get
			{
				if (this.NativePropertyDescription != null && this.varEnumType == null)
				{
					VarEnum value;
					HResult propertyType = this.NativePropertyDescription.GetPropertyType(out value);
					if (CoreErrorHelper.Succeeded(propertyType))
					{
						this.varEnumType = new VarEnum?(value);
					}
				}
				return (this.varEnumType != null) ? this.varEnumType.Value : VarEnum.VT_EMPTY;
			}
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x000335F4 File Offset: 0x000317F4
		public Type ValueType
		{
			get
			{
				if (this.valueType == null)
				{
					this.valueType = ShellPropertyFactory.VarEnumToSystemType(this.VarEnumType);
				}
				return this.valueType;
			}
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00033630 File Offset: 0x00031830
		public PropertyDisplayType DisplayType
		{
			get
			{
				if (this.NativePropertyDescription != null && this.displayType == null)
				{
					PropertyDisplayType value;
					HResult result = this.NativePropertyDescription.GetDisplayType(out value);
					if (CoreErrorHelper.Succeeded(result))
					{
						this.displayType = new PropertyDisplayType?(value);
					}
				}
				return (this.displayType != null) ? this.displayType.Value : PropertyDisplayType.String;
			}
		}

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x000336A4 File Offset: 0x000318A4
		public uint DefaultColumWidth
		{
			get
			{
				if (this.NativePropertyDescription != null && this.defaultColumWidth == null)
				{
					uint value;
					HResult defaultColumnWidth = this.NativePropertyDescription.GetDefaultColumnWidth(out value);
					if (CoreErrorHelper.Succeeded(defaultColumnWidth))
					{
						this.defaultColumWidth = new uint?(value);
					}
				}
				return (this.defaultColumWidth != null) ? this.defaultColumWidth.Value : 0U;
			}
		}

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00033718 File Offset: 0x00031918
		public PropertyAggregationType AggregationTypes
		{
			get
			{
				if (this.NativePropertyDescription != null && this.aggregationTypes == null)
				{
					PropertyAggregationType value;
					HResult aggregationType = this.NativePropertyDescription.GetAggregationType(out value);
					if (CoreErrorHelper.Succeeded(aggregationType))
					{
						this.aggregationTypes = new PropertyAggregationType?(value);
					}
				}
				return (this.aggregationTypes != null) ? this.aggregationTypes.Value : PropertyAggregationType.Default;
			}
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x0003378C File Offset: 0x0003198C
		public ReadOnlyCollection<ShellPropertyEnumType> PropertyEnumTypes
		{
			get
			{
				if (this.NativePropertyDescription != null && this.propertyEnumTypes == null)
				{
					List<ShellPropertyEnumType> list = new List<ShellPropertyEnumType>();
					Guid guid = new Guid("A99400F4-3D84-4557-94BA-1242FB2CC9A6");
					IPropertyEnumTypeList propertyEnumTypeList;
					HResult enumTypeList = this.NativePropertyDescription.GetEnumTypeList(ref guid, out propertyEnumTypeList);
					if (propertyEnumTypeList != null && CoreErrorHelper.Succeeded(enumTypeList))
					{
						uint num;
						propertyEnumTypeList.GetCount(out num);
						guid = new Guid("11E1FBF9-2D56-4A6B-8DB3-7CD193A471F2");
						for (uint num2 = 0U; num2 < num; num2 += 1U)
						{
							IPropertyEnumType nativePropertyEnumType;
							propertyEnumTypeList.GetAt(num2, ref guid, out nativePropertyEnumType);
							list.Add(new ShellPropertyEnumType(nativePropertyEnumType));
						}
					}
					this.propertyEnumTypes = new ReadOnlyCollection<ShellPropertyEnumType>(list);
				}
				return this.propertyEnumTypes;
			}
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06000DCE RID: 3534 RVA: 0x00033864 File Offset: 0x00031A64
		public PropertyColumnStateOptions ColumnState
		{
			get
			{
				if (this.NativePropertyDescription != null && this.columnState == null)
				{
					PropertyColumnStateOptions value;
					HResult result = this.NativePropertyDescription.GetColumnState(out value);
					if (CoreErrorHelper.Succeeded(result))
					{
						this.columnState = new PropertyColumnStateOptions?(value);
					}
				}
				return (this.columnState != null) ? this.columnState.Value : PropertyColumnStateOptions.None;
			}
		}

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x000338D8 File Offset: 0x00031AD8
		public PropertyConditionType ConditionType
		{
			get
			{
				if (this.NativePropertyDescription != null && this.conditionType == null)
				{
					PropertyConditionType value;
					PropertyConditionOperation value2;
					HResult result = this.NativePropertyDescription.GetConditionType(out value, out value2);
					if (CoreErrorHelper.Succeeded(result))
					{
						this.conditionOperation = new PropertyConditionOperation?(value2);
						this.conditionType = new PropertyConditionType?(value);
					}
				}
				return (this.conditionType != null) ? this.conditionType.Value : PropertyConditionType.None;
			}
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x00033960 File Offset: 0x00031B60
		public PropertyConditionOperation ConditionOperation
		{
			get
			{
				if (this.NativePropertyDescription != null && this.conditionOperation == null)
				{
					PropertyConditionType value;
					PropertyConditionOperation value2;
					HResult result = this.NativePropertyDescription.GetConditionType(out value, out value2);
					if (CoreErrorHelper.Succeeded(result))
					{
						this.conditionOperation = new PropertyConditionOperation?(value2);
						this.conditionType = new PropertyConditionType?(value);
					}
				}
				return (this.conditionOperation != null) ? this.conditionOperation.Value : PropertyConditionOperation.Implicit;
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x000339E8 File Offset: 0x00031BE8
		public PropertyGroupingRange GroupingRange
		{
			get
			{
				if (this.NativePropertyDescription != null && this.groupingRange == null)
				{
					PropertyGroupingRange value;
					HResult result = this.NativePropertyDescription.GetGroupingRange(out value);
					if (CoreErrorHelper.Succeeded(result))
					{
						this.groupingRange = new PropertyGroupingRange?(value);
					}
				}
				return (this.groupingRange != null) ? this.groupingRange.Value : PropertyGroupingRange.Discrete;
			}
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x00033A5C File Offset: 0x00031C5C
		public PropertySortDescription SortDescription
		{
			get
			{
				if (this.NativePropertyDescription != null && this.sortDescription == null)
				{
					PropertySortDescription value;
					HResult result = this.NativePropertyDescription.GetSortDescription(out value);
					if (CoreErrorHelper.Succeeded(result))
					{
						this.sortDescription = new PropertySortDescription?(value);
					}
				}
				return (this.sortDescription != null) ? this.sortDescription.Value : PropertySortDescription.General;
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00033AD0 File Offset: 0x00031CD0
		public string GetSortDescriptionLabel(bool descending)
		{
			IntPtr zero = IntPtr.Zero;
			string result = string.Empty;
			if (this.NativePropertyDescription != null)
			{
				HResult sortDescriptionLabel = this.NativePropertyDescription.GetSortDescriptionLabel(descending, out zero);
				if (CoreErrorHelper.Succeeded(sortDescriptionLabel) && zero != IntPtr.Zero)
				{
					result = Marshal.PtrToStringUni(zero);
					Marshal.FreeCoTaskMem(zero);
				}
			}
			return result;
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00033B40 File Offset: 0x00031D40
		public PropertyTypeOptions TypeFlags
		{
			get
			{
				if (this.NativePropertyDescription != null && this.propertyTypeFlags == null)
				{
					PropertyTypeOptions propertyTypeOptions;
					HResult typeFlags = this.NativePropertyDescription.GetTypeFlags(PropertyTypeOptions.MaskAll, out propertyTypeOptions);
					this.propertyTypeFlags = new PropertyTypeOptions?(CoreErrorHelper.Succeeded(typeFlags) ? propertyTypeOptions : PropertyTypeOptions.None);
				}
				return (this.propertyTypeFlags != null) ? this.propertyTypeFlags.Value : PropertyTypeOptions.None;
			}
		}

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00033BB8 File Offset: 0x00031DB8
		public PropertyViewOptions ViewFlags
		{
			get
			{
				if (this.NativePropertyDescription != null && this.propertyViewFlags == null)
				{
					PropertyViewOptions propertyViewOptions;
					HResult viewFlags = this.NativePropertyDescription.GetViewFlags(out propertyViewOptions);
					this.propertyViewFlags = new PropertyViewOptions?(CoreErrorHelper.Succeeded(viewFlags) ? propertyViewOptions : PropertyViewOptions.None);
				}
				return (this.propertyViewFlags != null) ? this.propertyViewFlags.Value : PropertyViewOptions.None;
			}
		}

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00033C2C File Offset: 0x00031E2C
		public bool HasSystemDescription
		{
			get
			{
				return this.NativePropertyDescription != null;
			}
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00033C4A File Offset: 0x00031E4A
		internal ShellPropertyDescription(PropertyKey key)
		{
			this.propertyKey = key;
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00033C68 File Offset: 0x00031E68
		internal IPropertyDescription NativePropertyDescription
		{
			get
			{
				if (this.nativePropertyDescription == null)
				{
					Guid guid = new Guid("6F79D558-3E96-4549-A1D1-7D75D2288814");
					PropertySystemNativeMethods.PSGetPropertyDescription(ref this.propertyKey, ref guid, out this.nativePropertyDescription);
				}
				return this.nativePropertyDescription;
			}
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00033CB8 File Offset: 0x00031EB8
		protected virtual void Dispose(bool disposing)
		{
			if (this.nativePropertyDescription != null)
			{
				Marshal.ReleaseComObject(this.nativePropertyDescription);
				this.nativePropertyDescription = null;
			}
			if (disposing)
			{
				this.canonicalName = null;
				this.displayName = null;
				this.editInvitation = null;
				this.defaultColumWidth = null;
				this.valueType = null;
				this.propertyEnumTypes = null;
			}
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00033D21 File Offset: 0x00031F21
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x00033D34 File Offset: 0x00031F34
		~ShellPropertyDescription()
		{
			this.Dispose(false);
		}

		// Token: 0x04000565 RID: 1381
		private IPropertyDescription nativePropertyDescription;

		// Token: 0x04000566 RID: 1382
		private string canonicalName;

		// Token: 0x04000567 RID: 1383
		private PropertyKey propertyKey;

		// Token: 0x04000568 RID: 1384
		private string displayName;

		// Token: 0x04000569 RID: 1385
		private string editInvitation;

		// Token: 0x0400056A RID: 1386
		private VarEnum? varEnumType = null;

		// Token: 0x0400056B RID: 1387
		private PropertyDisplayType? displayType;

		// Token: 0x0400056C RID: 1388
		private PropertyAggregationType? aggregationTypes;

		// Token: 0x0400056D RID: 1389
		private uint? defaultColumWidth;

		// Token: 0x0400056E RID: 1390
		private PropertyTypeOptions? propertyTypeFlags;

		// Token: 0x0400056F RID: 1391
		private PropertyViewOptions? propertyViewFlags;

		// Token: 0x04000570 RID: 1392
		private Type valueType;

		// Token: 0x04000571 RID: 1393
		private ReadOnlyCollection<ShellPropertyEnumType> propertyEnumTypes;

		// Token: 0x04000572 RID: 1394
		private PropertyColumnStateOptions? columnState;

		// Token: 0x04000573 RID: 1395
		private PropertyConditionType? conditionType;

		// Token: 0x04000574 RID: 1396
		private PropertyConditionOperation? conditionOperation;

		// Token: 0x04000575 RID: 1397
		private PropertyGroupingRange? groupingRange;

		// Token: 0x04000576 RID: 1398
		private PropertySortDescription? sortDescription;
	}
}
