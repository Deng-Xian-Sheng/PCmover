using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000008 RID: 8
	public abstract class ShellObject : IDisposable, IEquatable<ShellObject>
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000024F0 File Offset: 0x000006F0
		public static ShellObject FromParsingName(string parsingName)
		{
			return ShellObjectFactory.Create(parsingName);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002508 File Offset: 0x00000708
		public static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnVista;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000251F File Offset: 0x0000071F
		internal ShellObject()
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002535 File Offset: 0x00000735
		internal ShellObject(IShellItem2 shellItem)
		{
			this.nativeShellItem = shellItem;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002554 File Offset: 0x00000754
		internal virtual IShellItem2 NativeShellItem2
		{
			get
			{
				if (this.nativeShellItem == null && this.ParsingName != null)
				{
					Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
					int num = ShellNativeMethods.SHCreateItemFromParsingName(this.ParsingName, IntPtr.Zero, ref guid, out this.nativeShellItem);
					if (this.nativeShellItem == null || !CoreErrorHelper.Succeeded(num))
					{
						throw new ShellException(LocalizedMessages.ShellObjectCreationFailed, Marshal.GetExceptionForHR(num));
					}
				}
				return this.nativeShellItem;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000025DC File Offset: 0x000007DC
		internal virtual IShellItem NativeShellItem
		{
			get
			{
				return this.NativeShellItem2;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000025F4 File Offset: 0x000007F4
		// (set) Token: 0x06000032 RID: 50 RVA: 0x0000260B File Offset: 0x0000080B
		internal IPropertyStore NativePropertyStore { get; set; }

		// Token: 0x06000033 RID: 51 RVA: 0x00002614 File Offset: 0x00000814
		public void Update(IBindCtx bindContext)
		{
			HResult result = HResult.Ok;
			if (this.NativeShellItem2 != null)
			{
				result = this.NativeShellItem2.Update(bindContext);
			}
			if (CoreErrorHelper.Failed(result))
			{
				throw new ShellException(result);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002658 File Offset: 0x00000858
		public ShellProperties Properties
		{
			get
			{
				if (this.properties == null)
				{
					this.properties = new ShellProperties(this);
				}
				return this.properties;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002690 File Offset: 0x00000890
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000026DD File Offset: 0x000008DD
		public virtual string ParsingName
		{
			get
			{
				if (this._internalParsingName == null && this.nativeShellItem != null)
				{
					this._internalParsingName = ShellHelper.GetParsingName(this.nativeShellItem);
				}
				return this._internalParsingName ?? string.Empty;
			}
			protected set
			{
				this._internalParsingName = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000026E8 File Offset: 0x000008E8
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000275E File Offset: 0x0000095E
		public virtual string Name
		{
			get
			{
				if (this._internalName == null && this.NativeShellItem != null)
				{
					IntPtr zero = IntPtr.Zero;
					if (this.NativeShellItem.GetDisplayName(ShellNativeMethods.ShellItemDesignNameOptions.Normal, out zero) == HResult.Ok && zero != IntPtr.Zero)
					{
						this._internalName = Marshal.PtrToStringAuto(zero);
						Marshal.FreeCoTaskMem(zero);
					}
				}
				return this._internalName;
			}
			protected set
			{
				this._internalName = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002768 File Offset: 0x00000968
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000027B6 File Offset: 0x000009B6
		internal virtual IntPtr PIDL
		{
			get
			{
				if (this._internalPIDL == IntPtr.Zero && this.NativeShellItem != null)
				{
					this._internalPIDL = ShellHelper.PidlFromShellItem(this.NativeShellItem);
				}
				return this._internalPIDL;
			}
			set
			{
				this._internalPIDL = value;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000027C0 File Offset: 0x000009C0
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000027D8 File Offset: 0x000009D8
		public virtual string GetDisplayName(DisplayNameType displayNameType)
		{
			string result = null;
			HResult hresult = HResult.Ok;
			if (this.NativeShellItem2 != null)
			{
				hresult = this.NativeShellItem2.GetDisplayName((ShellNativeMethods.ShellItemDesignNameOptions)displayNameType, out result);
			}
			if (hresult != HResult.Ok)
			{
				throw new ShellException(LocalizedMessages.ShellObjectCannotGetDisplayName, hresult);
			}
			return result;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002824 File Offset: 0x00000A24
		public bool IsLink
		{
			get
			{
				bool result;
				try
				{
					ShellNativeMethods.ShellFileGetAttributesOptions shellFileGetAttributesOptions;
					this.NativeShellItem.GetAttributes(ShellNativeMethods.ShellFileGetAttributesOptions.Link, out shellFileGetAttributesOptions);
					result = ((shellFileGetAttributesOptions & ShellNativeMethods.ShellFileGetAttributesOptions.Link) != (ShellNativeMethods.ShellFileGetAttributesOptions)0);
				}
				catch (FileNotFoundException)
				{
					result = false;
				}
				catch (NullReferenceException)
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002880 File Offset: 0x00000A80
		public bool IsFileSystemObject
		{
			get
			{
				bool result;
				try
				{
					ShellNativeMethods.ShellFileGetAttributesOptions shellFileGetAttributesOptions;
					this.NativeShellItem.GetAttributes(ShellNativeMethods.ShellFileGetAttributesOptions.FileSystem, out shellFileGetAttributesOptions);
					result = ((shellFileGetAttributesOptions & ShellNativeMethods.ShellFileGetAttributesOptions.FileSystem) != (ShellNativeMethods.ShellFileGetAttributesOptions)0);
				}
				catch (FileNotFoundException)
				{
					result = false;
				}
				catch (NullReferenceException)
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000028DC File Offset: 0x00000ADC
		public ShellThumbnail Thumbnail
		{
			get
			{
				if (this.thumbnail == null)
				{
					this.thumbnail = new ShellThumbnail(this);
				}
				return this.thumbnail;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002914 File Offset: 0x00000B14
		public ShellObject Parent
		{
			get
			{
				if (this.parentShellObject == null && this.NativeShellItem2 != null)
				{
					IShellItem shellItem;
					HResult parent = this.NativeShellItem2.GetParent(out shellItem);
					if (parent == HResult.Ok && shellItem != null)
					{
						this.parentShellObject = ShellObjectFactory.Create(shellItem);
					}
					else
					{
						if (parent == HResult.NoObject)
						{
							return null;
						}
						throw new ShellException(parent);
					}
				}
				return this.parentShellObject;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002998 File Offset: 0x00000B98
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._internalName = null;
				this._internalParsingName = null;
				this.properties = null;
				this.thumbnail = null;
				this.parentShellObject = null;
			}
			if (this.properties != null)
			{
				this.properties.Dispose();
			}
			if (this._internalPIDL != IntPtr.Zero)
			{
				ShellNativeMethods.ILFree(this._internalPIDL);
				this._internalPIDL = IntPtr.Zero;
			}
			if (this.nativeShellItem != null)
			{
				Marshal.ReleaseComObject(this.nativeShellItem);
				this.nativeShellItem = null;
			}
			if (this.NativePropertyStore != null)
			{
				Marshal.ReleaseComObject(this.NativePropertyStore);
				this.NativePropertyStore = null;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002A63 File Offset: 0x00000C63
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002A78 File Offset: 0x00000C78
		~ShellObject()
		{
			this.Dispose(false);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002AAC File Offset: 0x00000CAC
		public override int GetHashCode()
		{
			if (this.hashValue == null)
			{
				uint num = ShellNativeMethods.ILGetSize(this.PIDL);
				if (num != 0U)
				{
					byte[] array = new byte[num];
					Marshal.Copy(this.PIDL, array, 0, (int)num);
					byte[] value = ShellObject.hashProvider.ComputeHash(array);
					this.hashValue = new int?(BitConverter.ToInt32(value, 0));
				}
				else
				{
					this.hashValue = new int?(0);
				}
			}
			return this.hashValue.Value;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002B3C File Offset: 0x00000D3C
		public bool Equals(ShellObject other)
		{
			bool result = false;
			if (other != null)
			{
				IShellItem shellItem = this.NativeShellItem;
				IShellItem shellItem2 = other.NativeShellItem;
				if (shellItem != null && shellItem2 != null)
				{
					int num = 0;
					result = (shellItem.Compare(shellItem2, SICHINTF.SICHINT_ALLFIELDS, out num) == HResult.Ok && num == 0);
				}
			}
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public override bool Equals(object obj)
		{
			return this.Equals(obj as ShellObject);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public static bool operator ==(ShellObject leftShellObject, ShellObject rightShellObject)
		{
			bool result;
			if (leftShellObject == null)
			{
				result = (rightShellObject == null);
			}
			else
			{
				result = leftShellObject.Equals(rightShellObject);
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002BF4 File Offset: 0x00000DF4
		public static bool operator !=(ShellObject leftShellObject, ShellObject rightShellObject)
		{
			return !(leftShellObject == rightShellObject);
		}

		// Token: 0x04000009 RID: 9
		internal IShellItem2 nativeShellItem;

		// Token: 0x0400000A RID: 10
		private string _internalParsingName;

		// Token: 0x0400000B RID: 11
		private string _internalName;

		// Token: 0x0400000C RID: 12
		private IntPtr _internalPIDL = IntPtr.Zero;

		// Token: 0x0400000D RID: 13
		private ShellProperties properties;

		// Token: 0x0400000E RID: 14
		private ShellThumbnail thumbnail;

		// Token: 0x0400000F RID: 15
		private ShellObject parentShellObject;

		// Token: 0x04000010 RID: 16
		private static MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();

		// Token: 0x04000011 RID: 17
		private int? hashValue;
	}
}
