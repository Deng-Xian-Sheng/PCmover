using System;
using System.Threading;
using System.Windows;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000B0 RID: 176
	public class MetroDialogSettings
	{
		// Token: 0x06000975 RID: 2421 RVA: 0x00025758 File Offset: 0x00023958
		public MetroDialogSettings()
		{
			this.OwnerCanCloseWithDialog = false;
			this.AffirmativeButtonText = "OK";
			this.NegativeButtonText = "Cancel";
			this.ColorScheme = MetroDialogColorScheme.Theme;
			this.AnimateShow = (this.AnimateHide = true);
			this.MaximumBodyHeight = double.NaN;
			this.DefaultText = "";
			this.DefaultButtonFocus = MessageDialogResult.Negative;
			this.CancellationToken = CancellationToken.None;
			this.DialogTitleFontSize = double.NaN;
			this.DialogMessageFontSize = double.NaN;
			this.DialogResultOnCancel = null;
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x000257F8 File Offset: 0x000239F8
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x00025800 File Offset: 0x00023A00
		public bool OwnerCanCloseWithDialog { get; set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x00025809 File Offset: 0x00023A09
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x00025811 File Offset: 0x00023A11
		public string AffirmativeButtonText { get; set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x0002581A File Offset: 0x00023A1A
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x00025822 File Offset: 0x00023A22
		public bool AnimateHide { get; set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0002582B File Offset: 0x00023A2B
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00025833 File Offset: 0x00023A33
		public bool AnimateShow { get; set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x0002583C File Offset: 0x00023A3C
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00025844 File Offset: 0x00023A44
		public CancellationToken CancellationToken { get; set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x0002584D File Offset: 0x00023A4D
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x00025855 File Offset: 0x00023A55
		public MetroDialogColorScheme ColorScheme { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0002585E File Offset: 0x00023A5E
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00025866 File Offset: 0x00023A66
		public ResourceDictionary CustomResourceDictionary { get; set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0002586F File Offset: 0x00023A6F
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x00025877 File Offset: 0x00023A77
		public MessageDialogResult DefaultButtonFocus { get; set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00025880 File Offset: 0x00023A80
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00025888 File Offset: 0x00023A88
		public string DefaultText { get; set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x00025891 File Offset: 0x00023A91
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00025899 File Offset: 0x00023A99
		public double DialogMessageFontSize { get; set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x000258A2 File Offset: 0x00023AA2
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x000258AA File Offset: 0x00023AAA
		public MessageDialogResult? DialogResultOnCancel { get; set; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x000258B3 File Offset: 0x00023AB3
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x000258BB File Offset: 0x00023ABB
		public double DialogTitleFontSize { get; set; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x000258C4 File Offset: 0x00023AC4
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x000258CC File Offset: 0x00023ACC
		public string FirstAuxiliaryButtonText { get; set; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x000258D5 File Offset: 0x00023AD5
		// (set) Token: 0x06000991 RID: 2449 RVA: 0x000258DD File Offset: 0x00023ADD
		public double MaximumBodyHeight { get; set; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x000258E6 File Offset: 0x00023AE6
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x000258EE File Offset: 0x00023AEE
		public string NegativeButtonText { get; set; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x000258F7 File Offset: 0x00023AF7
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x000258FF File Offset: 0x00023AFF
		public string SecondAuxiliaryButtonText { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x00025908 File Offset: 0x00023B08
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x00025910 File Offset: 0x00023B10
		[Obsolete("This property will be deleted in the next release.")]
		public bool SuppressDefaultResources { get; set; }
	}
}
