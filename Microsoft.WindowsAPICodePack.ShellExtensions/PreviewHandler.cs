using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using Microsoft.WindowsAPICodePack.ShellExtensions.Interop;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200000C RID: 12
	public abstract class PreviewHandler : ICustomQueryInterface, IPreviewHandler, IPreviewHandlerVisuals, IOleWindow, IObjectWithSite, IInitializeWithStream, IInitializeWithItem, IInitializeWithFile
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002050 File Offset: 0x00000250
		public bool IsPreviewShowing
		{
			get
			{
				return this._isPreviewShowing;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002068 File Offset: 0x00000268
		protected virtual void Initialize()
		{
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000206B File Offset: 0x0000026B
		protected virtual void Uninitialize()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000018 RID: 24
		protected abstract IntPtr Handle { get; }

		// Token: 0x06000019 RID: 25
		protected abstract void UpdateBounds(NativeRect bounds);

		// Token: 0x0600001A RID: 26
		protected abstract void HandleInitializeException(Exception caughtException);

		// Token: 0x0600001B RID: 27
		protected abstract void SetFocus();

		// Token: 0x0600001C RID: 28
		protected abstract void SetBackground(int argb);

		// Token: 0x0600001D RID: 29
		protected abstract void SetForeground(int argb);

		// Token: 0x0600001E RID: 30
		protected abstract void SetFont(LogFont font);

		// Token: 0x0600001F RID: 31
		protected abstract void SetParentHandle(IntPtr handle);

		// Token: 0x06000020 RID: 32 RVA: 0x0000206E File Offset: 0x0000026E
		void IPreviewHandler.SetWindow(IntPtr hwnd, ref NativeRect rect)
		{
			this._parentHwnd = hwnd;
			this.UpdateBounds(rect);
			this.SetParentHandle(this._parentHwnd);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002092 File Offset: 0x00000292
		void IPreviewHandler.SetRect(ref NativeRect rect)
		{
			this.UpdateBounds(rect);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000020A4 File Offset: 0x000002A4
		void IPreviewHandler.DoPreview()
		{
			this._isPreviewShowing = true;
			try
			{
				this.Initialize();
			}
			catch (Exception caughtException)
			{
				this.HandleInitializeException(caughtException);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000020E4 File Offset: 0x000002E4
		void IPreviewHandler.Unload()
		{
			this.Uninitialize();
			this._isPreviewShowing = false;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000020F5 File Offset: 0x000002F5
		void IPreviewHandler.SetFocus()
		{
			this.SetFocus();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000020FF File Offset: 0x000002FF
		void IPreviewHandler.QueryFocus(out IntPtr phwnd)
		{
			phwnd = HandlerNativeMethods.GetFocus();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002110 File Offset: 0x00000310
		HResult IPreviewHandler.TranslateAccelerator(ref Message pmsg)
		{
			return (this._frame != null) ? this._frame.TranslateAccelerator(ref pmsg) : HResult.False;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000213A File Offset: 0x0000033A
		void IPreviewHandlerVisuals.SetBackgroundColor(NativeColorRef color)
		{
			this.SetBackground((int)color.Dword);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000214B File Offset: 0x0000034B
		void IPreviewHandlerVisuals.SetTextColor(NativeColorRef color)
		{
			this.SetForeground((int)color.Dword);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000215C File Offset: 0x0000035C
		void IPreviewHandlerVisuals.SetFont(ref LogFont plf)
		{
			this.SetFont(plf);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002168 File Offset: 0x00000368
		void IOleWindow.GetWindow(out IntPtr phwnd)
		{
			phwnd = this.Handle;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002177 File Offset: 0x00000377
		void IOleWindow.ContextSensitiveHelp(bool fEnterMode)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000217F File Offset: 0x0000037F
		void IObjectWithSite.SetSite(object pUnkSite)
		{
			this._frame = (pUnkSite as IPreviewHandlerFrame);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000218E File Offset: 0x0000038E
		void IObjectWithSite.GetSite(ref Guid riid, out object ppvSite)
		{
			ppvSite = this._frame;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000219C File Offset: 0x0000039C
		void IInitializeWithStream.Initialize(IStream stream, AccessModes fileMode)
		{
			IPreviewFromStream previewFromStream = this as IPreviewFromStream;
			if (previewFromStream == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.PreviewHandlerUnsupportedInterfaceCalled, new object[]
				{
					"IPreviewFromStream"
				}));
			}
			using (StorageStream storageStream = new StorageStream(stream, fileMode != AccessModes.ReadWrite))
			{
				previewFromStream.Load(storageStream);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002220 File Offset: 0x00000420
		void IInitializeWithItem.Initialize(IShellItem shellItem, AccessModes accessMode)
		{
			IPreviewFromShellObject previewFromShellObject = this as IPreviewFromShellObject;
			if (previewFromShellObject == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.PreviewHandlerUnsupportedInterfaceCalled, new object[]
				{
					"IPreviewFromShellObject"
				}));
			}
			using (ShellObject shellObject = ShellObjectFactory.Create(shellItem))
			{
				previewFromShellObject.Load(shellObject);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000229C File Offset: 0x0000049C
		void IInitializeWithFile.Initialize(string filePath, AccessModes fileMode)
		{
			IPreviewFromFile previewFromFile = this as IPreviewFromFile;
			if (previewFromFile == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.PreviewHandlerUnsupportedInterfaceCalled, new object[]
				{
					"IPreviewFromFile"
				}));
			}
			previewFromFile.Load(new FileInfo(filePath));
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000022F0 File Offset: 0x000004F0
		[ComRegisterFunction]
		private static void Register(Type registerType)
		{
			if (registerType != null && registerType.IsSubclassOf(typeof(PreviewHandler)))
			{
				object[] customAttributes = registerType.GetCustomAttributes(typeof(PreviewHandlerAttribute), true);
				if (customAttributes == null || customAttributes.Length != 1)
				{
					throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.PreviewHandlerInvalidAttributes, new object[]
					{
						registerType.Name
					}));
				}
				PreviewHandlerAttribute attribute = customAttributes[0] as PreviewHandlerAttribute;
				PreviewHandler.ThrowIfNotValid(registerType);
				PreviewHandler.RegisterPreviewHandler(registerType.GUID, attribute);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002394 File Offset: 0x00000594
		[ComUnregisterFunction]
		private static void Unregister(Type registerType)
		{
			if (registerType != null && registerType.IsSubclassOf(typeof(PreviewHandler)))
			{
				object[] customAttributes = registerType.GetCustomAttributes(typeof(PreviewHandlerAttribute), true);
				if (customAttributes != null && customAttributes.Length == 1)
				{
					PreviewHandlerAttribute attribute = customAttributes[0] as PreviewHandlerAttribute;
					PreviewHandler.UnregisterPreviewHandler(registerType.GUID, attribute);
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002408 File Offset: 0x00000608
		private static void RegisterPreviewHandler(Guid previewerGuid, PreviewHandlerAttribute attribute)
		{
			string text = previewerGuid.ToString("B");
			using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("AppID", true))
			{
				using (RegistryKey registryKey2 = registryKey.CreateSubKey(attribute.AppId))
				{
					registryKey2.SetValue("DllSurrogate", "%SystemRoot%\\system32\\prevhost.exe", RegistryValueKind.ExpandString);
				}
			}
			using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PreviewHandlers", true))
			{
				registryKey3.SetValue(text, attribute.Name, RegistryValueKind.String);
			}
			using (RegistryKey registryKey4 = Registry.ClassesRoot.OpenSubKey("CLSID"))
			{
				using (RegistryKey registryKey5 = registryKey4.OpenSubKey(text, true))
				{
					registryKey5.SetValue("DisplayName", attribute.Name, RegistryValueKind.String);
					registryKey5.SetValue("AppID", attribute.AppId, RegistryValueKind.String);
					registryKey5.SetValue("DisableLowILProcessIsolation", attribute.DisableLowILProcessIsolation ? 1 : 0, RegistryValueKind.DWord);
					using (RegistryKey registryKey6 = registryKey5.OpenSubKey("InprocServer32", true))
					{
						registryKey6.SetValue("ThreadingModel", "Apartment", RegistryValueKind.String);
					}
				}
			}
			foreach (string text2 in attribute.Extensions.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries))
			{
				Trace.WriteLine(string.Concat(new string[]
				{
					"Registering extension '",
					text2,
					"' with previewer '",
					text,
					"'"
				}));
				using (RegistryKey registryKey7 = Registry.ClassesRoot.CreateSubKey(text2))
				{
					using (RegistryKey registryKey8 = registryKey7.CreateSubKey("shellex"))
					{
						using (RegistryKey registryKey9 = registryKey8.CreateSubKey(HandlerNativeMethods.IPreviewHandlerGuid.ToString("B")))
						{
							registryKey9.SetValue(null, text, RegistryValueKind.String);
						}
					}
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002704 File Offset: 0x00000904
		private static void UnregisterPreviewHandler(Guid previewerGuid, PreviewHandlerAttribute attribute)
		{
			string text = previewerGuid.ToString("B");
			foreach (string text2 in attribute.Extensions.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries))
			{
				Trace.WriteLine(string.Concat(new string[]
				{
					"Unregistering extension '",
					text2,
					"' with previewer '",
					text,
					"'"
				}));
				using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(text2 + "\\shellex", true))
				{
					registryKey.DeleteSubKey(HandlerNativeMethods.IPreviewHandlerGuid.ToString(), false);
				}
			}
			using (RegistryKey registryKey2 = Registry.ClassesRoot.OpenSubKey("AppID", true))
			{
				registryKey2.DeleteSubKey(attribute.AppId, false);
			}
			using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PreviewHandlers", true))
			{
				registryKey3.DeleteValue(text, false);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000028C8 File Offset: 0x00000AC8
		private static void ThrowIfNotValid(Type type)
		{
			Type[] interfaces = type.GetInterfaces();
			if (!interfaces.Any((Type x) => x == typeof(IPreviewFromStream) || x == typeof(IPreviewFromShellObject) || x == typeof(IPreviewFromFile)))
			{
				throw new NotImplementedException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.PreviewHandlerInterfaceNotImplemented, new object[]
				{
					type.Name
				}));
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002930 File Offset: 0x00000B30
		CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
		{
			ppv = IntPtr.Zero;
			CustomQueryInterfaceResult result;
			if (iid == HandlerNativeMethods.IMarshalGuid)
			{
				result = CustomQueryInterfaceResult.Failed;
			}
			else if ((iid == HandlerNativeMethods.IInitializeWithStreamGuid && !(this is IPreviewFromStream)) || (iid == HandlerNativeMethods.IInitializeWithItemGuid && !(this is IPreviewFromShellObject)) || (iid == HandlerNativeMethods.IInitializeWithFileGuid && !(this is IPreviewFromFile)))
			{
				result = CustomQueryInterfaceResult.Failed;
			}
			else
			{
				result = CustomQueryInterfaceResult.NotHandled;
			}
			return result;
		}

		// Token: 0x04000001 RID: 1
		private bool _isPreviewShowing;

		// Token: 0x04000002 RID: 2
		private IntPtr _parentHwnd;

		// Token: 0x04000003 RID: 3
		private IPreviewHandlerFrame _frame;
	}
}
