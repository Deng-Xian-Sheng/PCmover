using System;
using System.Windows;
using System.Windows.Media.Effects;

namespace Laplink.Tools.Popups
{
	// Token: 0x02000005 RID: 5
	public class DefaultPopupRoot : IPopupRoot
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002228 File Offset: 0x00000428
		public DefaultPopupRoot(UIElement uiElement)
		{
			this._uiElement = uiElement;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002237 File Offset: 0x00000437
		public void DisablePopupRoot()
		{
			this._uiElement.Opacity = 0.5;
			this._uiElement.Effect = new BlurEffect();
			this._uiElement.IsEnabled = false;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002269 File Offset: 0x00000469
		public void EnablePopupRoot()
		{
			this._uiElement.Opacity = 1.0;
			this._uiElement.Effect = null;
			this._uiElement.IsEnabled = true;
		}

		// Token: 0x04000004 RID: 4
		private readonly UIElement _uiElement;
	}
}
