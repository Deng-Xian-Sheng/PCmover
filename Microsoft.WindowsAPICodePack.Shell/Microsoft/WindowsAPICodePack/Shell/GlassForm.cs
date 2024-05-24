using System;
using System.Drawing;
using System.Windows.Forms;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000023 RID: 35
	public partial class GlassForm : Form
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000061E8 File Offset: 0x000043E8
		// (set) Token: 0x0600011F RID: 287 RVA: 0x000061D4 File Offset: 0x000043D4
		public static bool AeroGlassCompositionEnabled
		{
			get
			{
				return DesktopWindowManagerNativeMethods.DwmIsCompositionEnabled();
			}
			set
			{
				DesktopWindowManagerNativeMethods.DwmEnableComposition(value ? CompositionEnable.Enable : CompositionEnable.Disable);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000121 RID: 289 RVA: 0x00006200 File Offset: 0x00004400
		// (remove) Token: 0x06000122 RID: 290 RVA: 0x0000623C File Offset: 0x0000443C
		public event EventHandler<AeroGlassCompositionChangedEventArgs> AeroGlassCompositionChanged;

		// Token: 0x06000123 RID: 291 RVA: 0x00006278 File Offset: 0x00004478
		public void SetAeroGlassTransparency()
		{
			this.BackColor = Color.Transparent;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006288 File Offset: 0x00004488
		public void ExcludeControlFromAeroGlass(Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (GlassForm.AeroGlassCompositionEnabled)
			{
				Rectangle rectangle = base.RectangleToScreen(base.ClientRectangle);
				Rectangle rectangle2 = control.RectangleToScreen(control.ClientRectangle);
				Margins margins = default(Margins);
				margins.LeftWidth = rectangle2.Left - rectangle.Left;
				margins.RightWidth = rectangle.Right - rectangle2.Right;
				margins.TopHeight = rectangle2.Top - rectangle.Top;
				margins.BottomHeight = rectangle.Bottom - rectangle2.Bottom;
				DesktopWindowManagerNativeMethods.DwmExtendFrameIntoClientArea(base.Handle, ref margins);
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006348 File Offset: 0x00004548
		public void ResetAeroGlass()
		{
			if (base.Handle != IntPtr.Zero)
			{
				Margins margins = new Margins(true);
				DesktopWindowManagerNativeMethods.DwmExtendFrameIntoClientArea(base.Handle, ref margins);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000638C File Offset: 0x0000458C
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 798 || m.Msg == 799)
			{
				if (this.AeroGlassCompositionChanged != null)
				{
					this.AeroGlassCompositionChanged(this, new AeroGlassCompositionChangedEventArgs(GlassForm.AeroGlassCompositionEnabled));
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000063EF File Offset: 0x000045EF
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.ResetAeroGlass();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00006404 File Offset: 0x00004604
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (!base.DesignMode)
			{
				if (GlassForm.AeroGlassCompositionEnabled && e != null)
				{
					e.Graphics.FillRectangle(Brushes.Black, base.ClientRectangle);
				}
			}
		}
	}
}
