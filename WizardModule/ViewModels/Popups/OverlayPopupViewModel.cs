using System;
using System.Windows.Media;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A8 RID: 168
	public class OverlayPopupViewModel : PopupViewModelBase
	{
		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x00027653 File Offset: 0x00025853
		// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x0002765B File Offset: 0x0002585B
		public Brush BorderBrush
		{
			get
			{
				return this._borderBrush;
			}
			set
			{
				this.SetProperty<Brush>(ref this._borderBrush, value, "BorderBrush");
			}
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x00027670 File Offset: 0x00025870
		// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x00027678 File Offset: 0x00025878
		public string MBIcon
		{
			get
			{
				return this._MBIcon;
			}
			private set
			{
				this.SetProperty<string>(ref this._MBIcon, value, "MBIcon");
			}
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0002768D File Offset: 0x0002588D
		// (set) Token: 0x06000EB8 RID: 3768 RVA: 0x00027695 File Offset: 0x00025895
		public object Content
		{
			get
			{
				return this._content;
			}
			private set
			{
				this.SetProperty<object>(ref this._content, value, "Content");
			}
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x000276AA File Offset: 0x000258AA
		public Events.OverlayPopupResolveArgs OverlayArgs { get; }

		// Token: 0x06000EBA RID: 3770 RVA: 0x000276B2 File Offset: 0x000258B2
		[Obsolete("For design only")]
		public OverlayPopupViewModel()
		{
			this.OverlayArgs = new Events.OverlayPopupResolveArgs();
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x000276DC File Offset: 0x000258DC
		public OverlayPopupViewModel(IUnityContainer container, Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.OverlayArgs = overlayArgs;
			base.PopupData.UseOverlay = overlayArgs.UseOverlay;
			this.OnCloseOverlay = new DelegateCommand(new Action(this.OnCloseOverlayPopup));
			overlayArgs.ClosePopupCallback = new Action(this.OnCloseOverlayPopup);
			this.Content = overlayArgs.GetResolveInfo(overlayArgs.Type).Resolve(container);
		}

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06000EBC RID: 3772 RVA: 0x0002775E File Offset: 0x0002595E
		// (set) Token: 0x06000EBD RID: 3773 RVA: 0x00027766 File Offset: 0x00025966
		public DelegateCommand OnCloseOverlay { get; set; }

		// Token: 0x06000EBE RID: 3774 RVA: 0x0002707C File Offset: 0x0002527C
		private void OnCloseOverlayPopup()
		{
			base.PopupData.IsOpen = false;
		}

		// Token: 0x040004FA RID: 1274
		private Brush _borderBrush = Brushes.Silver;

		// Token: 0x040004FB RID: 1275
		private string _MBIcon = "/WizardModule;component/Assets/NoneIcon.png";

		// Token: 0x040004FC RID: 1276
		private object _content;
	}
}
