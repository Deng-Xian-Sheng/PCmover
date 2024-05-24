using System;
using CefSharp.Enums;

namespace CefSharp
{
	// Token: 0x0200006E RID: 110
	public interface IImage
	{
		// Token: 0x06000283 RID: 643
		byte[] GetAsBitmap(float scaleFactor, ColorType colorType, AlphaType alphaType, out int pixelWidth, out int pixelHeight);

		// Token: 0x06000284 RID: 644
		byte[] GetAsJPEG(float scaleFactor, int quality, out int pixelWidth, out int pixelHeight);

		// Token: 0x06000285 RID: 645
		byte[] GetAsPNG(float scaleFactor, bool withTransparency, out int pixelWidth, out int pixelHeight);

		// Token: 0x06000286 RID: 646
		bool GetRepresentationInfo(float scaleFactor, out float actualScaleFactor, out int pixelWidth, out int pixelHeight);

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000287 RID: 647
		int Height { get; }

		// Token: 0x06000288 RID: 648
		bool HasRepresentation(float scaleFactor);

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000289 RID: 649
		bool IsEmpty { get; }

		// Token: 0x0600028A RID: 650
		bool IsSame(IImage that);

		// Token: 0x0600028B RID: 651
		bool RemoveRepresentation(float scaleFactor);

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600028C RID: 652
		int Width { get; }
	}
}
