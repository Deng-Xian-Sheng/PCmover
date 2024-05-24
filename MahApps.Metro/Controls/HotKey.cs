using System;
using System.Text;
using System.Windows.Input;
using ControlzEx.Native;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000059 RID: 89
	public class HotKey : IEquatable<HotKey>
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x0000F9BE File Offset: 0x0000DBBE
		public HotKey(Key key, ModifierKeys modifierKeys = ModifierKeys.None)
		{
			this._key = key;
			this._modifierKeys = modifierKeys;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000F9D4 File Offset: 0x0000DBD4
		public Key Key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000F9DC File Offset: 0x0000DBDC
		public ModifierKeys ModifierKeys
		{
			get
			{
				return this._modifierKeys;
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000F9E4 File Offset: 0x0000DBE4
		public override bool Equals(object obj)
		{
			return obj is HotKey && this.Equals((HotKey)obj);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000F9FC File Offset: 0x0000DBFC
		public override int GetHashCode()
		{
			return (int)(this._key * (Key)397 ^ (Key)this._modifierKeys);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000FA11 File Offset: 0x0000DC11
		public bool Equals(HotKey other)
		{
			return this._key == other._key && this._modifierKeys == other._modifierKeys;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000FA34 File Offset: 0x0000DC34
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if ((this._modifierKeys & ModifierKeys.Alt) == ModifierKeys.Alt)
			{
				stringBuilder.Append(HotKey.GetLocalizedKeyStringUnsafe(18));
				stringBuilder.Append("+");
			}
			if ((this._modifierKeys & ModifierKeys.Control) == ModifierKeys.Control)
			{
				stringBuilder.Append(HotKey.GetLocalizedKeyStringUnsafe(17));
				stringBuilder.Append("+");
			}
			if ((this._modifierKeys & ModifierKeys.Shift) == ModifierKeys.Shift)
			{
				stringBuilder.Append(HotKey.GetLocalizedKeyStringUnsafe(16));
				stringBuilder.Append("+");
			}
			if ((this._modifierKeys & ModifierKeys.Windows) == ModifierKeys.Windows)
			{
				stringBuilder.Append("Windows+");
			}
			stringBuilder.Append(HotKey.GetLocalizedKeyString(this._key));
			return stringBuilder.ToString();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000FAE5 File Offset: 0x0000DCE5
		private static string GetLocalizedKeyString(Key key)
		{
			if (key >= Key.BrowserBack && key <= Key.LaunchApplication2)
			{
				return key.ToString();
			}
			return HotKey.GetLocalizedKeyStringUnsafe(KeyInterop.VirtualKeyFromKey(key)) ?? key.ToString();
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000FB20 File Offset: 0x0000DD20
		private static string GetLocalizedKeyStringUnsafe(int key)
		{
			long num = (long)(key & 65535);
			StringBuilder stringBuilder = new StringBuilder(256);
			long num2 = (long)((ulong)NativeMethods.MapVirtualKey((uint)num, NativeMethods.MapType.MAPVK_VK_TO_VSC));
			num2 <<= 16;
			if (num == 45L || num == 46L || num == 144L || (33L <= num && num <= 40L))
			{
				num2 |= 16777216L;
			}
			if (UnsafeNativeMethods.GetKeyNameText((int)num2, stringBuilder, 256) <= 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000186 RID: 390
		private readonly Key _key;

		// Token: 0x04000187 RID: 391
		private readonly ModifierKeys _modifierKeys;
	}
}
