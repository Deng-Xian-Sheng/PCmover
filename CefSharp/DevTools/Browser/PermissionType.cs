using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F2 RID: 1010
	public enum PermissionType
	{
		// Token: 0x04000FA0 RID: 4000
		[EnumMember(Value = "accessibilityEvents")]
		AccessibilityEvents,
		// Token: 0x04000FA1 RID: 4001
		[EnumMember(Value = "audioCapture")]
		AudioCapture,
		// Token: 0x04000FA2 RID: 4002
		[EnumMember(Value = "backgroundSync")]
		BackgroundSync,
		// Token: 0x04000FA3 RID: 4003
		[EnumMember(Value = "backgroundFetch")]
		BackgroundFetch,
		// Token: 0x04000FA4 RID: 4004
		[EnumMember(Value = "clipboardReadWrite")]
		ClipboardReadWrite,
		// Token: 0x04000FA5 RID: 4005
		[EnumMember(Value = "clipboardSanitizedWrite")]
		ClipboardSanitizedWrite,
		// Token: 0x04000FA6 RID: 4006
		[EnumMember(Value = "displayCapture")]
		DisplayCapture,
		// Token: 0x04000FA7 RID: 4007
		[EnumMember(Value = "durableStorage")]
		DurableStorage,
		// Token: 0x04000FA8 RID: 4008
		[EnumMember(Value = "flash")]
		Flash,
		// Token: 0x04000FA9 RID: 4009
		[EnumMember(Value = "geolocation")]
		Geolocation,
		// Token: 0x04000FAA RID: 4010
		[EnumMember(Value = "midi")]
		Midi,
		// Token: 0x04000FAB RID: 4011
		[EnumMember(Value = "midiSysex")]
		MidiSysex,
		// Token: 0x04000FAC RID: 4012
		[EnumMember(Value = "nfc")]
		Nfc,
		// Token: 0x04000FAD RID: 4013
		[EnumMember(Value = "notifications")]
		Notifications,
		// Token: 0x04000FAE RID: 4014
		[EnumMember(Value = "paymentHandler")]
		PaymentHandler,
		// Token: 0x04000FAF RID: 4015
		[EnumMember(Value = "periodicBackgroundSync")]
		PeriodicBackgroundSync,
		// Token: 0x04000FB0 RID: 4016
		[EnumMember(Value = "protectedMediaIdentifier")]
		ProtectedMediaIdentifier,
		// Token: 0x04000FB1 RID: 4017
		[EnumMember(Value = "sensors")]
		Sensors,
		// Token: 0x04000FB2 RID: 4018
		[EnumMember(Value = "videoCapture")]
		VideoCapture,
		// Token: 0x04000FB3 RID: 4019
		[EnumMember(Value = "videoCapturePanTiltZoom")]
		VideoCapturePanTiltZoom,
		// Token: 0x04000FB4 RID: 4020
		[EnumMember(Value = "idleDetection")]
		IdleDetection,
		// Token: 0x04000FB5 RID: 4021
		[EnumMember(Value = "wakeLockScreen")]
		WakeLockScreen,
		// Token: 0x04000FB6 RID: 4022
		[EnumMember(Value = "wakeLockSystem")]
		WakeLockSystem
	}
}
