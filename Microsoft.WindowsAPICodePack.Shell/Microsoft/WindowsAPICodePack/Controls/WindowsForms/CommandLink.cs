using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsForms
{
	// Token: 0x0200001C RID: 28
	public class CommandLink : Button
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00005C9C File Offset: 0x00003E9C
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = CommandLink.AddCommandLinkStyle(createParams.Style);
				return createParams;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00005CC8 File Offset: 0x00003EC8
		public CommandLink()
		{
			CoreHelpers.ThrowIfNotVista();
			base.FlatStyle = FlatStyle.System;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00005CE4 File Offset: 0x00003EE4
		protected override Size DefaultSize
		{
			get
			{
				return new Size(180, 60);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00005D04 File Offset: 0x00003F04
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00005D1C File Offset: 0x00003F1C
		[DefaultValue("(Note Text)")]
		[Category("Appearance")]
		[Description("Specifies the supporting note text.")]
		[Browsable(true)]
		public string NoteText
		{
			get
			{
				return CommandLink.GetNote(this);
			}
			set
			{
				CommandLink.SetNote(this, value);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00005D28 File Offset: 0x00003F28
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00005D40 File Offset: 0x00003F40
		[Browsable(true)]
		[Category("Appearance")]
		[Description("Indicates whether the button should be decorated with the security shield icon (Windows Vista only).")]
		[DefaultValue(false)]
		public bool UseElevationIcon
		{
			get
			{
				return this.useElevationIcon;
			}
			set
			{
				this.useElevationIcon = value;
				CommandLink.SetShieldIcon(this, this.useElevationIcon);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005D58 File Offset: 0x00003F58
		private static int AddCommandLinkStyle(int style)
		{
			if (CoreHelpers.RunningOnVista)
			{
				style |= 14;
			}
			return style;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005D80 File Offset: 0x00003F80
		private static string GetNote(Button Button)
		{
			IntPtr value = CoreNativeMethods.SendMessage(Button.Handle, 5643U, IntPtr.Zero, IntPtr.Zero);
			int capacity = (int)value + 1;
			StringBuilder stringBuilder = new StringBuilder(capacity);
			value = CoreNativeMethods.SendMessage(Button.Handle, 5642U, ref capacity, stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005DD7 File Offset: 0x00003FD7
		private static void SetNote(Button button, string text)
		{
			CoreNativeMethods.SendMessage(button.Handle, 5641U, 0, text);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005DF0 File Offset: 0x00003FF0
		internal static void SetShieldIcon(Button Button, bool Show)
		{
			IntPtr lparam = new IntPtr(Show ? 1 : 0);
			CoreNativeMethods.SendMessage(Button.Handle, 5644U, IntPtr.Zero, lparam);
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00005E28 File Offset: 0x00004028
		public static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnVista;
			}
		}

		// Token: 0x0400003D RID: 61
		private bool useElevationIcon;
	}
}
