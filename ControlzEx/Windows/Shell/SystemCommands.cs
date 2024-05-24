using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using ControlzEx.Standard;

namespace ControlzEx.Windows.Shell
{
	// Token: 0x0200000F RID: 15
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public static class SystemCommands
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000364F File Offset: 0x0000184F
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00003656 File Offset: 0x00001856
		public static RoutedCommand CloseWindowCommand { get; private set; } = new RoutedCommand("CloseWindow", typeof(SystemCommands));

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000365E File Offset: 0x0000185E
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00003665 File Offset: 0x00001865
		public static RoutedCommand MaximizeWindowCommand { get; private set; } = new RoutedCommand("MaximizeWindow", typeof(SystemCommands));

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000366D File Offset: 0x0000186D
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00003674 File Offset: 0x00001874
		public static RoutedCommand MinimizeWindowCommand { get; private set; } = new RoutedCommand("MinimizeWindow", typeof(SystemCommands));

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000367C File Offset: 0x0000187C
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00003683 File Offset: 0x00001883
		public static RoutedCommand RestoreWindowCommand { get; private set; } = new RoutedCommand("RestoreWindow", typeof(SystemCommands));

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000368B File Offset: 0x0000188B
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00003692 File Offset: 0x00001892
		public static RoutedCommand ShowSystemMenuCommand { get; private set; } = new RoutedCommand("ShowSystemMenu", typeof(SystemCommands));

		// Token: 0x06000080 RID: 128 RVA: 0x00003728 File Offset: 0x00001928
		private static void _PostSystemCommand(Window window, SC command)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (handle == IntPtr.Zero || !NativeMethods.IsWindow(handle))
			{
				return;
			}
			NativeMethods.PostMessage(handle, WM.SYSCOMMAND, new IntPtr((int)command), IntPtr.Zero);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000376D File Offset: 0x0000196D
		public static void CloseWindow(Window window)
		{
			Verify.IsNotNull<Window>(window, "window");
			SystemCommands._PostSystemCommand(window, SC.CLOSE);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003785 File Offset: 0x00001985
		public static void MaximizeWindow(Window window)
		{
			Verify.IsNotNull<Window>(window, "window");
			SystemCommands._PostSystemCommand(window, SC.MAXIMIZE);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000379D File Offset: 0x0000199D
		public static void MinimizeWindow(Window window)
		{
			Verify.IsNotNull<Window>(window, "window");
			SystemCommands._PostSystemCommand(window, SC.MINIMIZE);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000037B5 File Offset: 0x000019B5
		public static void RestoreWindow(Window window)
		{
			Verify.IsNotNull<Window>(window, "window");
			SystemCommands._PostSystemCommand(window, SC.RESTORE);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000037D0 File Offset: 0x000019D0
		public static void ShowSystemMenu(Window window, MouseButtonEventArgs e)
		{
			Point position = e.GetPosition(window);
			Point screenLocation = window.PointToScreen(position);
			SystemCommands.ShowSystemMenu(window, screenLocation);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000037F4 File Offset: 0x000019F4
		public static void ShowSystemMenu(Window window, Point screenLocation)
		{
			Verify.IsNotNull<Window>(window, "window");
			SystemCommands.ShowSystemMenuPhysicalCoordinates(window, DpiHelper.LogicalPixelsToDevice(screenLocation, 1.0, 1.0));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003820 File Offset: 0x00001A20
		internal static void ShowSystemMenuPhysicalCoordinates(Window window, Point physicalScreenLocation)
		{
			Verify.IsNotNull<Window>(window, "window");
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (handle == IntPtr.Zero || !NativeMethods.IsWindow(handle))
			{
				return;
			}
			uint num = NativeMethods.TrackPopupMenuEx(NativeMethods.GetSystemMenu(handle, false), 256U, (int)physicalScreenLocation.X, (int)physicalScreenLocation.Y, handle, IntPtr.Zero);
			if (num != 0U)
			{
				NativeMethods.PostMessage(handle, WM.SYSCOMMAND, new IntPtr((long)((ulong)num)), IntPtr.Zero);
			}
		}
	}
}
