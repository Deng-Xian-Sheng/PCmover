using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x02000182 RID: 386
	public class ShellProperty<T> : IShellProperty
	{
		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x00033E1C File Offset: 0x0003201C
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x00033E33 File Offset: 0x00032033
		private ShellObject ParentShellObject { get; set; }

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x00033E3C File Offset: 0x0003203C
		// (set) Token: 0x06000EEA RID: 3818 RVA: 0x00033E53 File Offset: 0x00032053
		private IPropertyStore NativePropertyStore { get; set; }

		// Token: 0x06000EEB RID: 3819 RVA: 0x00033E5C File Offset: 0x0003205C
		private void GetImageReference()
		{
			IPropertyStore propertyStore = ShellPropertyCollection.CreateDefaultPropertyStore(this.ParentShellObject);
			using (PropVariant propVariant = new PropVariant())
			{
				propertyStore.GetValue(ref this.propertyKey, propVariant);
				Marshal.ReleaseComObject(propertyStore);
				string text;
				((IPropertyDescription2)this.Description.NativePropertyDescription).GetImageReferenceForValue(propVariant, out text);
				if (text != null)
				{
					int value = ShellNativeMethods.PathParseIconLocation(ref text);
					if (text != null)
					{
						this.imageReferencePath = text;
						this.imageReferenceIconIndex = new int?(value);
					}
				}
			}
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00033F0C File Offset: 0x0003210C
		private void StorePropVariantValue(PropVariant propVar)
		{
			Guid guid = new Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99");
			IPropertyStore propertyStore = null;
			try
			{
				int propertyStore2 = this.ParentShellObject.NativeShellItem2.GetPropertyStore(ShellNativeMethods.GetPropertyStoreOptions.ReadWrite, ref guid, out propertyStore);
				if (!CoreErrorHelper.Succeeded(propertyStore2))
				{
					throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty, Marshal.GetExceptionForHR(propertyStore2));
				}
				HResult hresult = propertyStore.SetValue(ref this.propertyKey, propVar);
				if (!this.AllowSetTruncatedValue && hresult == (HResult)262560)
				{
					throw new ArgumentOutOfRangeException("propVar", LocalizedMessages.ShellPropertyValueTruncated);
				}
				if (!CoreErrorHelper.Succeeded(hresult))
				{
					throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)hresult));
				}
				propertyStore.Commit();
			}
			catch (InvalidComObjectException innerException)
			{
				throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty, innerException);
			}
			catch (InvalidCastException)
			{
				throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty);
			}
			finally
			{
				if (propertyStore != null)
				{
					Marshal.ReleaseComObject(propertyStore);
					propertyStore = null;
				}
			}
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x00034028 File Offset: 0x00032228
		internal ShellProperty(PropertyKey propertyKey, ShellPropertyDescription description, ShellObject parent)
		{
			this.propertyKey = propertyKey;
			this.description = description;
			this.ParentShellObject = parent;
			this.AllowSetTruncatedValue = false;
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x0003405F File Offset: 0x0003225F
		internal ShellProperty(PropertyKey propertyKey, ShellPropertyDescription description, IPropertyStore propertyStore)
		{
			this.propertyKey = propertyKey;
			this.description = description;
			this.NativePropertyStore = propertyStore;
			this.AllowSetTruncatedValue = false;
		}

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x00034098 File Offset: 0x00032298
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x00034190 File Offset: 0x00032390
		public T Value
		{
			get
			{
				Debug.Assert(this.ValueType == ShellPropertyFactory.VarEnumToSystemType(this.Description.VarEnumType));
				T result;
				using (PropVariant propVariant = new PropVariant())
				{
					if (this.ParentShellObject.NativePropertyStore != null)
					{
						this.ParentShellObject.NativePropertyStore.GetValue(ref this.propertyKey, propVariant);
					}
					else if (this.ParentShellObject != null)
					{
						this.ParentShellObject.NativeShellItem2.GetProperty(ref this.propertyKey, propVariant);
					}
					else if (this.NativePropertyStore != null)
					{
						this.NativePropertyStore.GetValue(ref this.propertyKey, propVariant);
					}
					result = ((propVariant.Value != null) ? ((T)((object)propVariant.Value)) : default(T));
				}
				return result;
			}
			set
			{
				Debug.Assert(this.ValueType == ShellPropertyFactory.VarEnumToSystemType(this.Description.VarEnumType));
				if (typeof(T) != this.ValueType)
				{
					throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.ShellPropertyWrongType, new object[]
					{
						this.ValueType.Name
					}));
				}
				if (value is Nullable)
				{
					Type typeFromHandle = typeof(T);
					PropertyInfo property = typeFromHandle.GetProperty("HasValue");
					if (property != null)
					{
						if (!(bool)property.GetValue(value, null))
						{
							this.ClearValue();
							return;
						}
					}
				}
				else if (value == null)
				{
					this.ClearValue();
					return;
				}
				if (this.ParentShellObject != null)
				{
					using (ShellPropertyWriter propertyWriter = this.ParentShellObject.Properties.GetPropertyWriter())
					{
						propertyWriter.WriteProperty<T>(this, value, this.AllowSetTruncatedValue);
					}
				}
				else if (this.NativePropertyStore != null)
				{
					throw new InvalidOperationException(LocalizedMessages.ShellPropertyCannotSetProperty);
				}
			}
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x00034300 File Offset: 0x00032500
		public PropertyKey PropertyKey
		{
			get
			{
				return this.propertyKey;
			}
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x00034318 File Offset: 0x00032518
		public bool TryFormatForDisplay(PropertyDescriptionFormatOptions format, out string formattedString)
		{
			bool result;
			if (this.Description == null || this.Description.NativePropertyDescription == null)
			{
				formattedString = null;
				result = false;
			}
			else
			{
				IPropertyStore propertyStore = ShellPropertyCollection.CreateDefaultPropertyStore(this.ParentShellObject);
				using (PropVariant propVariant = new PropVariant())
				{
					propertyStore.GetValue(ref this.propertyKey, propVariant);
					Marshal.ReleaseComObject(propertyStore);
					HResult result2 = this.Description.NativePropertyDescription.FormatForDisplay(propVariant, ref format, out formattedString);
					if (!CoreErrorHelper.Succeeded(result2))
					{
						formattedString = null;
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x000343CC File Offset: 0x000325CC
		public string FormatForDisplay(PropertyDescriptionFormatOptions format)
		{
			string result;
			if (this.Description == null || this.Description.NativePropertyDescription == null)
			{
				result = null;
			}
			else
			{
				IPropertyStore propertyStore = ShellPropertyCollection.CreateDefaultPropertyStore(this.ParentShellObject);
				using (PropVariant propVariant = new PropVariant())
				{
					propertyStore.GetValue(ref this.propertyKey, propVariant);
					Marshal.ReleaseComObject(propertyStore);
					string text;
					HResult result2 = this.Description.NativePropertyDescription.FormatForDisplay(propVariant, ref format, out text);
					if (!CoreErrorHelper.Succeeded(result2))
					{
						throw new ShellException(result2);
					}
					result = text;
				}
			}
			return result;
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x00034480 File Offset: 0x00032680
		public ShellPropertyDescription Description
		{
			get
			{
				return this.description;
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x00034498 File Offset: 0x00032698
		public string CanonicalName
		{
			get
			{
				return this.Description.CanonicalName;
			}
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x000344B8 File Offset: 0x000326B8
		public void ClearValue()
		{
			using (PropVariant propVariant = new PropVariant())
			{
				this.StorePropVariantValue(propVariant);
			}
		}

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x000344FC File Offset: 0x000326FC
		public object ValueAsObject
		{
			get
			{
				object result;
				using (PropVariant propVariant = new PropVariant())
				{
					if (this.ParentShellObject != null)
					{
						IPropertyStore propertyStore = ShellPropertyCollection.CreateDefaultPropertyStore(this.ParentShellObject);
						propertyStore.GetValue(ref this.propertyKey, propVariant);
						Marshal.ReleaseComObject(propertyStore);
					}
					else if (this.NativePropertyStore != null)
					{
						this.NativePropertyStore.GetValue(ref this.propertyKey, propVariant);
					}
					result = ((propVariant != null) ? propVariant.Value : null);
				}
				return result;
			}
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x000345A0 File Offset: 0x000327A0
		public Type ValueType
		{
			get
			{
				Debug.Assert(this.Description.ValueType == typeof(T));
				return this.Description.ValueType;
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x000345DC File Offset: 0x000327DC
		public IconReference IconReference
		{
			get
			{
				if (!CoreHelpers.RunningOnWin7)
				{
					throw new PlatformNotSupportedException(LocalizedMessages.ShellPropertyWindows7);
				}
				this.GetImageReference();
				int resourceId = (this.imageReferenceIconIndex != null) ? this.imageReferenceIconIndex.Value : -1;
				return new IconReference(this.imageReferencePath, resourceId);
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06000EFA RID: 3834 RVA: 0x00034634 File Offset: 0x00032834
		// (set) Token: 0x06000EFB RID: 3835 RVA: 0x0003464B File Offset: 0x0003284B
		public bool AllowSetTruncatedValue { get; set; }

		// Token: 0x0400065C RID: 1628
		private PropertyKey propertyKey;

		// Token: 0x0400065D RID: 1629
		private string imageReferencePath = null;

		// Token: 0x0400065E RID: 1630
		private int? imageReferenceIconIndex;

		// Token: 0x0400065F RID: 1631
		private ShellPropertyDescription description = null;
	}
}
