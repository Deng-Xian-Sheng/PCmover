using System;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000AA RID: 170
	public class LoginDialogSettings : MetroDialogSettings
	{
		// Token: 0x06000944 RID: 2372 RVA: 0x00024F14 File Offset: 0x00023114
		public LoginDialogSettings()
		{
			this.UsernameWatermark = "Username...";
			this.UsernameCharacterCasing = CharacterCasing.Normal;
			this.PasswordWatermark = "Password...";
			this.NegativeButtonVisibility = Visibility.Collapsed;
			this.ShouldHideUsername = false;
			base.AffirmativeButtonText = "Login";
			this.EnablePasswordPreview = false;
			this.RememberCheckBoxVisibility = Visibility.Collapsed;
			this.RememberCheckBoxText = "Remember";
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x00024F76 File Offset: 0x00023176
		// (set) Token: 0x06000946 RID: 2374 RVA: 0x00024F7E File Offset: 0x0002317E
		public string InitialUsername { get; set; }

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x00024F87 File Offset: 0x00023187
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x00024F8F File Offset: 0x0002318F
		public string InitialPassword { get; set; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x00024F98 File Offset: 0x00023198
		// (set) Token: 0x0600094A RID: 2378 RVA: 0x00024FA0 File Offset: 0x000231A0
		public string UsernameWatermark { get; set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x00024FA9 File Offset: 0x000231A9
		// (set) Token: 0x0600094C RID: 2380 RVA: 0x00024FB1 File Offset: 0x000231B1
		public CharacterCasing UsernameCharacterCasing { get; set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x00024FBA File Offset: 0x000231BA
		// (set) Token: 0x0600094E RID: 2382 RVA: 0x00024FC2 File Offset: 0x000231C2
		public bool ShouldHideUsername { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x00024FCB File Offset: 0x000231CB
		// (set) Token: 0x06000950 RID: 2384 RVA: 0x00024FD3 File Offset: 0x000231D3
		public string PasswordWatermark { get; set; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x00024FDC File Offset: 0x000231DC
		// (set) Token: 0x06000952 RID: 2386 RVA: 0x00024FE4 File Offset: 0x000231E4
		public Visibility NegativeButtonVisibility { get; set; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x00024FED File Offset: 0x000231ED
		// (set) Token: 0x06000954 RID: 2388 RVA: 0x00024FF5 File Offset: 0x000231F5
		public bool EnablePasswordPreview { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x00024FFE File Offset: 0x000231FE
		// (set) Token: 0x06000956 RID: 2390 RVA: 0x00025006 File Offset: 0x00023206
		public Visibility RememberCheckBoxVisibility { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x0002500F File Offset: 0x0002320F
		// (set) Token: 0x06000958 RID: 2392 RVA: 0x00025017 File Offset: 0x00023217
		public string RememberCheckBoxText { get; set; }

		// Token: 0x04000414 RID: 1044
		private const string DefaultUsernameWatermark = "Username...";

		// Token: 0x04000415 RID: 1045
		private const string DefaultPasswordWatermark = "Password...";

		// Token: 0x04000416 RID: 1046
		private const string DefaultRememberCheckBoxText = "Remember";
	}
}
