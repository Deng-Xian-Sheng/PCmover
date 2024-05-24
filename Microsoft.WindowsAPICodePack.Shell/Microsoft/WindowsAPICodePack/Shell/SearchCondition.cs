using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200000D RID: 13
	public class SearchCondition : IDisposable
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00003174 File Offset: 0x00001374
		internal SearchCondition(ICondition nativeSearchCondition)
		{
			if (nativeSearchCondition == null)
			{
				throw new ArgumentNullException("nativeSearchCondition");
			}
			this.NativeSearchCondition = nativeSearchCondition;
			HResult comparisonInfo = this.NativeSearchCondition.GetConditionType(out this.conditionType);
			if (!CoreErrorHelper.Succeeded(comparisonInfo))
			{
				throw new ShellException(comparisonInfo);
			}
			if (this.ConditionType == SearchConditionType.Leaf)
			{
				using (PropVariant propVariant = new PropVariant())
				{
					comparisonInfo = this.NativeSearchCondition.GetComparisonInfo(out this.canonicalName, out this.conditionOperation, propVariant);
					if (!CoreErrorHelper.Succeeded(comparisonInfo))
					{
						throw new ShellException(comparisonInfo);
					}
					this.PropertyValue = propVariant.Value.ToString();
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00003264 File Offset: 0x00001464
		// (set) Token: 0x06000064 RID: 100 RVA: 0x0000327B File Offset: 0x0000147B
		internal ICondition NativeSearchCondition { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00003284 File Offset: 0x00001484
		public string PropertyCanonicalName
		{
			get
			{
				return this.canonicalName;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000066 RID: 102 RVA: 0x0000329C File Offset: 0x0000149C
		public PropertyKey PropertyKey
		{
			get
			{
				if (this.propertyKey == this.emptyPropertyKey)
				{
					int num = PropertySystemNativeMethods.PSGetPropertyKeyFromName(this.PropertyCanonicalName, out this.propertyKey);
					if (!CoreErrorHelper.Succeeded(num))
					{
						throw new ShellException(num);
					}
				}
				return this.propertyKey;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000032F4 File Offset: 0x000014F4
		// (set) Token: 0x06000068 RID: 104 RVA: 0x0000330B File Offset: 0x0000150B
		public string PropertyValue { get; internal set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003314 File Offset: 0x00001514
		public SearchConditionOperation ConditionOperation
		{
			get
			{
				return this.conditionOperation;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000332C File Offset: 0x0000152C
		public SearchConditionType ConditionType
		{
			get
			{
				return this.conditionType;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003344 File Offset: 0x00001544
		public IEnumerable<SearchCondition> GetSubConditions()
		{
			List<SearchCondition> list = new List<SearchCondition>();
			Guid guid = new Guid("00000100-0000-0000-C000-000000000046");
			object obj;
			HResult hresult = this.NativeSearchCondition.GetSubConditions(ref guid, out obj);
			if (!CoreErrorHelper.Succeeded(hresult))
			{
				throw new ShellException(hresult);
			}
			if (obj != null)
			{
				IEnumUnknown enumUnknown = obj as IEnumUnknown;
				IntPtr zero = IntPtr.Zero;
				uint num = 0U;
				while (hresult == HResult.Ok)
				{
					hresult = enumUnknown.Next(1U, ref zero, ref num);
					if (hresult == HResult.Ok && num == 1U)
					{
						list.Add(new SearchCondition((ICondition)Marshal.GetObjectForIUnknown(zero)));
					}
				}
			}
			return list;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000033FC File Offset: 0x000015FC
		~SearchCondition()
		{
			this.Dispose(false);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003430 File Offset: 0x00001630
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003444 File Offset: 0x00001644
		protected virtual void Dispose(bool disposing)
		{
			if (this.NativeSearchCondition != null)
			{
				Marshal.ReleaseComObject(this.NativeSearchCondition);
				this.NativeSearchCondition = null;
			}
		}

		// Token: 0x04000019 RID: 25
		private string canonicalName;

		// Token: 0x0400001A RID: 26
		private PropertyKey propertyKey;

		// Token: 0x0400001B RID: 27
		private PropertyKey emptyPropertyKey = default(PropertyKey);

		// Token: 0x0400001C RID: 28
		private SearchConditionOperation conditionOperation = SearchConditionOperation.Implicit;

		// Token: 0x0400001D RID: 29
		private SearchConditionType conditionType = SearchConditionType.Leaf;
	}
}
