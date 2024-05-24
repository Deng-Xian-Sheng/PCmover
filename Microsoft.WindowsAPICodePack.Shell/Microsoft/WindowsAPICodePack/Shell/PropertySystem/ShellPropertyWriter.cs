using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000E7 RID: 231
	public class ShellPropertyWriter : IDisposable
	{
		// Token: 0x060008CB RID: 2251 RVA: 0x00025C48 File Offset: 0x00023E48
		internal ShellPropertyWriter(ShellObject parent)
		{
			this.ParentShellObject = parent;
			Guid guid = new Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99");
			try
			{
				int propertyStore = this.ParentShellObject.NativeShellItem2.GetPropertyStore(ShellNativeMethods.GetPropertyStoreOptions.ReadWrite, ref guid, out this.writablePropStore);
				if (!CoreErrorHelper.Succeeded(propertyStore))
				{
					throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty, Marshal.GetExceptionForHR(propertyStore));
				}
				if (this.ParentShellObject.NativePropertyStore == null)
				{
					this.ParentShellObject.NativePropertyStore = this.writablePropStore;
				}
			}
			catch (InvalidComObjectException innerException)
			{
				throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty, innerException);
			}
			catch (InvalidCastException)
			{
				throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty);
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x00025D14 File Offset: 0x00023F14
		// (set) Token: 0x060008CD RID: 2253 RVA: 0x00025D2C File Offset: 0x00023F2C
		private protected ShellObject ParentShellObject
		{
			protected get
			{
				return this.parentShellObject;
			}
			private set
			{
				this.parentShellObject = value;
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00025D36 File Offset: 0x00023F36
		public void WriteProperty(PropertyKey key, object value)
		{
			this.WriteProperty(key, value, true);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00025D44 File Offset: 0x00023F44
		public void WriteProperty(PropertyKey key, object value, bool allowTruncatedValue)
		{
			if (this.writablePropStore == null)
			{
				throw new InvalidOperationException("Writeable store has been closed.");
			}
			using (PropVariant propVariant = PropVariant.FromObject(value))
			{
				HResult hresult = this.writablePropStore.SetValue(ref key, propVariant);
				if (!allowTruncatedValue && hresult == (HResult)262560)
				{
					Marshal.ReleaseComObject(this.writablePropStore);
					this.writablePropStore = null;
					throw new ArgumentOutOfRangeException("value", LocalizedMessages.ShellPropertyValueTruncated);
				}
				if (!CoreErrorHelper.Succeeded(hresult))
				{
					throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)hresult));
				}
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00025E00 File Offset: 0x00024000
		public void WriteProperty(string canonicalName, object value)
		{
			this.WriteProperty(canonicalName, value, true);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00025E10 File Offset: 0x00024010
		public void WriteProperty(string canonicalName, object value, bool allowTruncatedValue)
		{
			PropertyKey key;
			int num = PropertySystemNativeMethods.PSGetPropertyKeyFromName(canonicalName, out key);
			if (!CoreErrorHelper.Succeeded(num))
			{
				throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, Marshal.GetExceptionForHR(num));
			}
			this.WriteProperty(key, value, allowTruncatedValue);
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00025E4D File Offset: 0x0002404D
		public void WriteProperty(IShellProperty shellProperty, object value)
		{
			this.WriteProperty(shellProperty, value, true);
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00025E5C File Offset: 0x0002405C
		public void WriteProperty(IShellProperty shellProperty, object value, bool allowTruncatedValue)
		{
			if (shellProperty == null)
			{
				throw new ArgumentNullException("shellProperty");
			}
			this.WriteProperty(shellProperty.PropertyKey, value, allowTruncatedValue);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00025E90 File Offset: 0x00024090
		public void WriteProperty<T>(ShellProperty<T> shellProperty, T value)
		{
			this.WriteProperty<T>(shellProperty, value, true);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00025EA0 File Offset: 0x000240A0
		public void WriteProperty<T>(ShellProperty<T> shellProperty, T value, bool allowTruncatedValue)
		{
			if (shellProperty == null)
			{
				throw new ArgumentNullException("shellProperty");
			}
			this.WriteProperty(shellProperty.PropertyKey, value, allowTruncatedValue);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00025ED9 File Offset: 0x000240D9
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00025EEC File Offset: 0x000240EC
		~ShellPropertyWriter()
		{
			this.Dispose(false);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00025F20 File Offset: 0x00024120
		protected virtual void Dispose(bool disposing)
		{
			this.Close();
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00025F2C File Offset: 0x0002412C
		public void Close()
		{
			if (this.writablePropStore != null)
			{
				this.writablePropStore.Commit();
				Marshal.ReleaseComObject(this.writablePropStore);
				this.writablePropStore = null;
			}
			this.ParentShellObject.NativePropertyStore = null;
		}

		// Token: 0x0400043A RID: 1082
		private ShellObject parentShellObject;

		// Token: 0x0400043B RID: 1083
		internal IPropertyStore writablePropStore;
	}
}
