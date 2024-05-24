using System;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000015 RID: 21
	internal class ShellItemArray : IShellItemArray
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000045A0 File Offset: 0x000027A0
		internal ShellItemArray(IShellItem[] shellItems)
		{
			this.shellItemsList.AddRange(shellItems);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000045C3 File Offset: 0x000027C3
		public HResult BindToHandler(IntPtr pbc, ref Guid rbhid, ref Guid riid, out IntPtr ppvOut)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000045CB File Offset: 0x000027CB
		public HResult GetPropertyStore(int Flags, ref Guid riid, out IntPtr ppv)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000045D3 File Offset: 0x000027D3
		public HResult GetPropertyDescriptionList(ref PropertyKey keyType, ref Guid riid, out IntPtr ppv)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000045DB File Offset: 0x000027DB
		public HResult GetAttributes(ShellNativeMethods.ShellItemAttributeOptions dwAttribFlags, ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000045E4 File Offset: 0x000027E4
		public HResult GetCount(out uint pdwNumItems)
		{
			pdwNumItems = (uint)this.shellItemsList.Count;
			return HResult.Ok;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004604 File Offset: 0x00002804
		public HResult GetItemAt(uint dwIndex, out IShellItem ppsi)
		{
			HResult result;
			if (dwIndex < (uint)this.shellItemsList.Count)
			{
				ppsi = this.shellItemsList[(int)dwIndex];
				result = HResult.Ok;
			}
			else
			{
				ppsi = null;
				result = HResult.Fail;
			}
			return result;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004649 File Offset: 0x00002849
		public HResult EnumItems(out IntPtr ppenumShellItems)
		{
			throw new NotSupportedException();
		}

		// Token: 0x04000028 RID: 40
		private List<IShellItem> shellItemsList = new List<IShellItem>();
	}
}
