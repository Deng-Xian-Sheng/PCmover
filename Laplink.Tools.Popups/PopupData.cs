using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using Prism.Mvvm;

namespace Laplink.Tools.Popups
{
	// Token: 0x0200000A RID: 10
	public class PopupData : BindableBase
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000029A3 File Offset: 0x00000BA3
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000029AB File Offset: 0x00000BAB
		public bool UseOverlay { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000029B4 File Offset: 0x00000BB4
		// (set) Token: 0x06000052 RID: 82 RVA: 0x000029BC File Offset: 0x00000BBC
		public UIElement Content
		{
			get
			{
				return this._content;
			}
			set
			{
				if (this.SetProperty<UIElement>(ref this._content, value, "Content"))
				{
					if (this.UseOverlay)
					{
						base.RaisePropertyChanged("OverlayContent");
						return;
					}
					base.RaisePropertyChanged("PopupContent");
				}
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000029F1 File Offset: 0x00000BF1
		public UIElement OverlayContent
		{
			get
			{
				if (!this.UseOverlay)
				{
					return null;
				}
				return this.Content;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002A03 File Offset: 0x00000C03
		public UIElement PopupContent
		{
			get
			{
				if (!this.UseOverlay)
				{
					return this.Content;
				}
				return null;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002A15 File Offset: 0x00000C15
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002A1D File Offset: 0x00000C1D
		public PlacementMode Placement
		{
			get
			{
				return this._placement;
			}
			set
			{
				this.SetProperty<PlacementMode>(ref this._placement, value, "Placement");
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002A32 File Offset: 0x00000C32
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002A3A File Offset: 0x00000C3A
		public UIElement PlacementTarget
		{
			get
			{
				return this._placementTarget;
			}
			set
			{
				this.SetProperty<UIElement>(ref this._placementTarget, value, "PlacementTarget");
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002A4F File Offset: 0x00000C4F
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002A57 File Offset: 0x00000C57
		public double Width
		{
			get
			{
				return this._width;
			}
			set
			{
				this.SetProperty<double>(ref this._width, value, "Width");
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002A6C File Offset: 0x00000C6C
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002A74 File Offset: 0x00000C74
		public PopupAnimation Animation
		{
			get
			{
				return this._animation;
			}
			set
			{
				this.SetProperty<PopupAnimation>(ref this._animation, value, "Animation");
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002A89 File Offset: 0x00000C89
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002A91 File Offset: 0x00000C91
		public bool AllowsTransparency
		{
			get
			{
				return this._allowsTransparency;
			}
			set
			{
				this.SetProperty<bool>(ref this._allowsTransparency, value, "AllowsTransparency");
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002AA6 File Offset: 0x00000CA6
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002AAE File Offset: 0x00000CAE
		public bool StaysOpen
		{
			get
			{
				return this._staysOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._staysOpen, value, "StaysOpen");
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002AC3 File Offset: 0x00000CC3
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002ACB File Offset: 0x00000CCB
		public int ZIndex
		{
			get
			{
				return this._zIndex;
			}
			set
			{
				this.SetProperty<int>(ref this._zIndex, value, "ZIndex");
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002AE0 File Offset: 0x00000CE0
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002AE8 File Offset: 0x00000CE8
		public double MinWidth
		{
			get
			{
				return this._minWidth;
			}
			set
			{
				this.SetProperty<double>(ref this._minWidth, value, "MinWidth");
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002AFD File Offset: 0x00000CFD
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002B08 File Offset: 0x00000D08
		public bool IsOpen
		{
			get
			{
				return this._isOpen;
			}
			set
			{
				if (this.SetProperty<bool>(ref this._isOpen, value, "IsOpen"))
				{
					this.IsBlackout = (this.IsOpen && this.BlackoutWhenOpen);
					if (this.UseOverlay)
					{
						base.RaisePropertyChanged("IsOverlayOpen");
						return;
					}
					base.RaisePropertyChanged("IsPopupOpen");
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002B5F File Offset: 0x00000D5F
		public bool IsPopupOpen
		{
			get
			{
				return this.IsOpen && !this.UseOverlay;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002B74 File Offset: 0x00000D74
		public bool IsOverlayOpen
		{
			get
			{
				return this.IsOpen && this.UseOverlay;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002B86 File Offset: 0x00000D86
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00002B8E File Offset: 0x00000D8E
		public bool BlackoutWhenOpen
		{
			get
			{
				return this._blackoutWhenOpen;
			}
			set
			{
				if (this.SetProperty<bool>(ref this._blackoutWhenOpen, value, "BlackoutWhenOpen"))
				{
					this.IsBlackout = (this.IsOpen && this.BlackoutWhenOpen);
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002BBB File Offset: 0x00000DBB
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00002BC3 File Offset: 0x00000DC3
		public bool IsBlackout
		{
			get
			{
				return this._isBlackout;
			}
			set
			{
				this.SetProperty<bool>(ref this._isBlackout, value, "IsBlackout");
			}
		}

		// Token: 0x04000013 RID: 19
		private UIElement _content;

		// Token: 0x04000014 RID: 20
		private PlacementMode _placement = PlacementMode.Center;

		// Token: 0x04000015 RID: 21
		private UIElement _placementTarget;

		// Token: 0x04000016 RID: 22
		private double _width = double.NaN;

		// Token: 0x04000017 RID: 23
		private PopupAnimation _animation = PopupAnimation.Slide;

		// Token: 0x04000018 RID: 24
		private bool _allowsTransparency = true;

		// Token: 0x04000019 RID: 25
		private bool _staysOpen = true;

		// Token: 0x0400001A RID: 26
		private int _zIndex;

		// Token: 0x0400001B RID: 27
		private double _minWidth;

		// Token: 0x0400001C RID: 28
		private bool _isOpen;

		// Token: 0x0400001D RID: 29
		private bool _blackoutWhenOpen = true;

		// Token: 0x0400001E RID: 30
		private bool _isBlackout;
	}
}
