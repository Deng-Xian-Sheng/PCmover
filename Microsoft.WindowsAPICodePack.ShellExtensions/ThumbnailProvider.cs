using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Interop;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200001D RID: 29
	public abstract class ThumbnailProvider : IThumbnailProvider, ICustomQueryInterface, IDisposable, IInitializeWithStream, IInitializeWithItem, IInitializeWithFile
	{
		// Token: 0x060000AA RID: 170 RVA: 0x00003A08 File Offset: 0x00001C08
		private Bitmap GetBitmap(int sideLength)
		{
			IThumbnailFromStream thumbnailFromStream;
			Bitmap result;
			IThumbnailFromShellObject thumbnailFromShellObject;
			if (this._stream != null && (thumbnailFromStream = (this as IThumbnailFromStream)) != null)
			{
				result = thumbnailFromStream.ConstructBitmap(this._stream, sideLength);
			}
			else if (this._shellObject != null && (thumbnailFromShellObject = (this as IThumbnailFromShellObject)) != null)
			{
				result = thumbnailFromShellObject.ConstructBitmap(this._shellObject, sideLength);
			}
			else
			{
				IThumbnailFromFile thumbnailFromFile;
				if (this._info == null || (thumbnailFromFile = (this as IThumbnailFromFile)) == null)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.ThumbnailProviderInterfaceNotImplemented, new object[]
					{
						base.GetType().Name
					}));
				}
				result = thumbnailFromFile.ConstructBitmap(this._info, sideLength);
			}
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003AD8 File Offset: 0x00001CD8
		public virtual ThumbnailAlphaType GetThumbnailAlphaType()
		{
			return ThumbnailAlphaType.Unknown;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003AEC File Offset: 0x00001CEC
		void IThumbnailProvider.GetThumbnail(uint sideLength, out IntPtr hBitmap, out uint alphaType)
		{
			using (Bitmap bitmap = this.GetBitmap((int)sideLength))
			{
				hBitmap = bitmap.GetHbitmap();
			}
			alphaType = (uint)this.GetThumbnailAlphaType();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003B3C File Offset: 0x00001D3C
		CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
		{
			ppv = IntPtr.Zero;
			CustomQueryInterfaceResult result;
			if (iid == HandlerNativeMethods.IMarshalGuid)
			{
				result = CustomQueryInterfaceResult.Failed;
			}
			else if ((iid == HandlerNativeMethods.IInitializeWithStreamGuid && !(this is IThumbnailFromStream)) || (iid == HandlerNativeMethods.IInitializeWithItemGuid && !(this is IThumbnailFromShellObject)) || (iid == HandlerNativeMethods.IInitializeWithFileGuid && !(this is IThumbnailFromFile)))
			{
				result = CustomQueryInterfaceResult.Failed;
			}
			else
			{
				result = CustomQueryInterfaceResult.NotHandled;
			}
			return result;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003BD8 File Offset: 0x00001DD8
		[ComRegisterFunction]
		private static void Register(Type registerType)
		{
			if (registerType != null && registerType.IsSubclassOf(typeof(ThumbnailProvider)))
			{
				object[] customAttributes = registerType.GetCustomAttributes(typeof(ThumbnailProviderAttribute), true);
				if (customAttributes != null && customAttributes.Length == 1)
				{
					ThumbnailProviderAttribute attribute = customAttributes[0] as ThumbnailProviderAttribute;
					ThumbnailProvider.ThrowIfInvalid(registerType, attribute);
					ThumbnailProvider.RegisterThumbnailHandler(registerType.GUID.ToString("B"), attribute);
				}
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003C60 File Offset: 0x00001E60
		private static void RegisterThumbnailHandler(string guid, ThumbnailProviderAttribute attribute)
		{
			using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("CLSID"))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(guid, true))
				{
					registryKey2.SetValue("DisableProcessIsolation", attribute.DisableProcessIsolation ? 1 : 0, RegistryValueKind.DWord);
					using (RegistryKey registryKey3 = registryKey2.OpenSubKey("InprocServer32", true))
					{
						registryKey3.SetValue("ThreadingModel", "Apartment", RegistryValueKind.String);
					}
				}
			}
			using (RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true))
			{
				registryKey4.SetValue(guid, attribute.Name, RegistryValueKind.String);
			}
			string[] array = attribute.Extensions.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string subkey in array)
			{
				using (RegistryKey registryKey5 = Registry.ClassesRoot.CreateSubKey(subkey))
				{
					using (RegistryKey registryKey6 = registryKey5.CreateSubKey("shellex"))
					{
						using (RegistryKey registryKey7 = registryKey6.CreateSubKey(HandlerNativeMethods.IThumbnailProviderGuid.ToString("B")))
						{
							registryKey7.SetValue(null, guid, RegistryValueKind.String);
							if (attribute.ThumbnailCutoff == ThumbnailCutoffSize.Square20)
							{
								registryKey5.DeleteValue("ThumbnailCutoff", false);
							}
							else
							{
								registryKey5.SetValue("ThumbnailCutoff", (int)attribute.ThumbnailCutoff, RegistryValueKind.DWord);
							}
							if (attribute.TypeOverlay != null)
							{
								registryKey5.SetValue("TypeOverlay", attribute.TypeOverlay, RegistryValueKind.String);
							}
							if (attribute.ThumbnailAdornment == ThumbnailAdornment.Default)
							{
								registryKey5.DeleteValue("Treatment", false);
							}
							else
							{
								registryKey5.SetValue("Treatment", (int)attribute.ThumbnailAdornment, RegistryValueKind.DWord);
							}
						}
					}
				}
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003F64 File Offset: 0x00002164
		[ComUnregisterFunction]
		private static void Unregister(Type registerType)
		{
			if (registerType != null && registerType.IsSubclassOf(typeof(ThumbnailProvider)))
			{
				object[] customAttributes = registerType.GetCustomAttributes(typeof(ThumbnailProviderAttribute), true);
				if (customAttributes != null && customAttributes.Length == 1)
				{
					ThumbnailProviderAttribute attribute = customAttributes[0] as ThumbnailProviderAttribute;
					ThumbnailProvider.UnregisterThumbnailHandler(registerType.GUID.ToString("B"), attribute);
				}
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003FE4 File Offset: 0x000021E4
		private static void UnregisterThumbnailHandler(string guid, ThumbnailProviderAttribute attribute)
		{
			string[] array = attribute.Extensions.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string name in array)
			{
				using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(name, true))
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey("shellex", true))
					{
						registryKey2.DeleteSubKey(HandlerNativeMethods.IThumbnailProviderGuid.ToString("B"), false);
						registryKey.DeleteValue("ThumbnailCutoff", false);
						registryKey.DeleteValue("TypeOverlay", false);
						registryKey.DeleteValue("Treatment", false);
					}
				}
			}
			using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true))
			{
				registryKey3.DeleteValue(guid, false);
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000417C File Offset: 0x0000237C
		private static void ThrowIfInvalid(Type type, ThumbnailProviderAttribute attribute)
		{
			Type[] interfaces = type.GetInterfaces();
			bool flag = interfaces.Any((Type x) => x == typeof(IThumbnailFromStream));
			if (interfaces.Any((Type x) => x == typeof(IThumbnailFromShellObject) || x == typeof(IThumbnailFromFile)))
			{
				if (!flag && !attribute.DisableProcessIsolation)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.ThumbnailProviderDisabledProcessIsolation, new object[]
					{
						type.Name
					}));
				}
				flag = true;
			}
			if (!flag)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.ThumbnailProviderInterfaceNotImplemented, new object[]
				{
					type.Name
				}));
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000424B File Offset: 0x0000244B
		void IInitializeWithStream.Initialize(IStream stream, AccessModes fileMode)
		{
			this._stream = new StorageStream(stream, fileMode != AccessModes.ReadWrite);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004261 File Offset: 0x00002461
		void IInitializeWithItem.Initialize(IShellItem shellItem, AccessModes accessMode)
		{
			this._shellObject = ShellObjectFactory.Create(shellItem);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004270 File Offset: 0x00002470
		void IInitializeWithFile.Initialize(string filePath, AccessModes fileMode)
		{
			this._info = new FileInfo(filePath);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004280 File Offset: 0x00002480
		~ThumbnailProvider()
		{
			this.Dispose(false);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000042B4 File Offset: 0x000024B4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000042C8 File Offset: 0x000024C8
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && this._stream != null)
			{
				this._stream.Dispose();
			}
		}

		// Token: 0x04000042 RID: 66
		private StorageStream _stream = null;

		// Token: 0x04000043 RID: 67
		private FileInfo _info = null;

		// Token: 0x04000044 RID: 68
		private ShellObject _shellObject = null;
	}
}
