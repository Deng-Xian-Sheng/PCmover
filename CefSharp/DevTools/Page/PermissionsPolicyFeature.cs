using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000233 RID: 563
	public enum PermissionsPolicyFeature
	{
		// Token: 0x04000842 RID: 2114
		[EnumMember(Value = "accelerometer")]
		Accelerometer,
		// Token: 0x04000843 RID: 2115
		[EnumMember(Value = "ambient-light-sensor")]
		AmbientLightSensor,
		// Token: 0x04000844 RID: 2116
		[EnumMember(Value = "attribution-reporting")]
		AttributionReporting,
		// Token: 0x04000845 RID: 2117
		[EnumMember(Value = "autoplay")]
		Autoplay,
		// Token: 0x04000846 RID: 2118
		[EnumMember(Value = "camera")]
		Camera,
		// Token: 0x04000847 RID: 2119
		[EnumMember(Value = "ch-dpr")]
		ChDpr,
		// Token: 0x04000848 RID: 2120
		[EnumMember(Value = "ch-device-memory")]
		ChDeviceMemory,
		// Token: 0x04000849 RID: 2121
		[EnumMember(Value = "ch-downlink")]
		ChDownlink,
		// Token: 0x0400084A RID: 2122
		[EnumMember(Value = "ch-ect")]
		ChEct,
		// Token: 0x0400084B RID: 2123
		[EnumMember(Value = "ch-prefers-color-scheme")]
		ChPrefersColorScheme,
		// Token: 0x0400084C RID: 2124
		[EnumMember(Value = "ch-rtt")]
		ChRtt,
		// Token: 0x0400084D RID: 2125
		[EnumMember(Value = "ch-ua")]
		ChUa,
		// Token: 0x0400084E RID: 2126
		[EnumMember(Value = "ch-ua-arch")]
		ChUaArch,
		// Token: 0x0400084F RID: 2127
		[EnumMember(Value = "ch-ua-bitness")]
		ChUaBitness,
		// Token: 0x04000850 RID: 2128
		[EnumMember(Value = "ch-ua-platform")]
		ChUaPlatform,
		// Token: 0x04000851 RID: 2129
		[EnumMember(Value = "ch-ua-model")]
		ChUaModel,
		// Token: 0x04000852 RID: 2130
		[EnumMember(Value = "ch-ua-mobile")]
		ChUaMobile,
		// Token: 0x04000853 RID: 2131
		[EnumMember(Value = "ch-ua-full")]
		ChUaFull,
		// Token: 0x04000854 RID: 2132
		[EnumMember(Value = "ch-ua-full-version")]
		ChUaFullVersion,
		// Token: 0x04000855 RID: 2133
		[EnumMember(Value = "ch-ua-full-version-list")]
		ChUaFullVersionList,
		// Token: 0x04000856 RID: 2134
		[EnumMember(Value = "ch-ua-platform-version")]
		ChUaPlatformVersion,
		// Token: 0x04000857 RID: 2135
		[EnumMember(Value = "ch-ua-reduced")]
		ChUaReduced,
		// Token: 0x04000858 RID: 2136
		[EnumMember(Value = "ch-ua-wow64")]
		ChUaWow64,
		// Token: 0x04000859 RID: 2137
		[EnumMember(Value = "ch-viewport-height")]
		ChViewportHeight,
		// Token: 0x0400085A RID: 2138
		[EnumMember(Value = "ch-viewport-width")]
		ChViewportWidth,
		// Token: 0x0400085B RID: 2139
		[EnumMember(Value = "ch-width")]
		ChWidth,
		// Token: 0x0400085C RID: 2140
		[EnumMember(Value = "ch-partitioned-cookies")]
		ChPartitionedCookies,
		// Token: 0x0400085D RID: 2141
		[EnumMember(Value = "clipboard-read")]
		ClipboardRead,
		// Token: 0x0400085E RID: 2142
		[EnumMember(Value = "clipboard-write")]
		ClipboardWrite,
		// Token: 0x0400085F RID: 2143
		[EnumMember(Value = "cross-origin-isolated")]
		CrossOriginIsolated,
		// Token: 0x04000860 RID: 2144
		[EnumMember(Value = "direct-sockets")]
		DirectSockets,
		// Token: 0x04000861 RID: 2145
		[EnumMember(Value = "display-capture")]
		DisplayCapture,
		// Token: 0x04000862 RID: 2146
		[EnumMember(Value = "document-domain")]
		DocumentDomain,
		// Token: 0x04000863 RID: 2147
		[EnumMember(Value = "encrypted-media")]
		EncryptedMedia,
		// Token: 0x04000864 RID: 2148
		[EnumMember(Value = "execution-while-out-of-viewport")]
		ExecutionWhileOutOfViewport,
		// Token: 0x04000865 RID: 2149
		[EnumMember(Value = "execution-while-not-rendered")]
		ExecutionWhileNotRendered,
		// Token: 0x04000866 RID: 2150
		[EnumMember(Value = "focus-without-user-activation")]
		FocusWithoutUserActivation,
		// Token: 0x04000867 RID: 2151
		[EnumMember(Value = "fullscreen")]
		Fullscreen,
		// Token: 0x04000868 RID: 2152
		[EnumMember(Value = "frobulate")]
		Frobulate,
		// Token: 0x04000869 RID: 2153
		[EnumMember(Value = "gamepad")]
		Gamepad,
		// Token: 0x0400086A RID: 2154
		[EnumMember(Value = "geolocation")]
		Geolocation,
		// Token: 0x0400086B RID: 2155
		[EnumMember(Value = "gyroscope")]
		Gyroscope,
		// Token: 0x0400086C RID: 2156
		[EnumMember(Value = "hid")]
		Hid,
		// Token: 0x0400086D RID: 2157
		[EnumMember(Value = "idle-detection")]
		IdleDetection,
		// Token: 0x0400086E RID: 2158
		[EnumMember(Value = "join-ad-interest-group")]
		JoinAdInterestGroup,
		// Token: 0x0400086F RID: 2159
		[EnumMember(Value = "keyboard-map")]
		KeyboardMap,
		// Token: 0x04000870 RID: 2160
		[EnumMember(Value = "magnetometer")]
		Magnetometer,
		// Token: 0x04000871 RID: 2161
		[EnumMember(Value = "microphone")]
		Microphone,
		// Token: 0x04000872 RID: 2162
		[EnumMember(Value = "midi")]
		Midi,
		// Token: 0x04000873 RID: 2163
		[EnumMember(Value = "otp-credentials")]
		OtpCredentials,
		// Token: 0x04000874 RID: 2164
		[EnumMember(Value = "payment")]
		Payment,
		// Token: 0x04000875 RID: 2165
		[EnumMember(Value = "picture-in-picture")]
		PictureInPicture,
		// Token: 0x04000876 RID: 2166
		[EnumMember(Value = "publickey-credentials-get")]
		PublickeyCredentialsGet,
		// Token: 0x04000877 RID: 2167
		[EnumMember(Value = "run-ad-auction")]
		RunAdAuction,
		// Token: 0x04000878 RID: 2168
		[EnumMember(Value = "screen-wake-lock")]
		ScreenWakeLock,
		// Token: 0x04000879 RID: 2169
		[EnumMember(Value = "serial")]
		Serial,
		// Token: 0x0400087A RID: 2170
		[EnumMember(Value = "shared-autofill")]
		SharedAutofill,
		// Token: 0x0400087B RID: 2171
		[EnumMember(Value = "storage-access-api")]
		StorageAccessApi,
		// Token: 0x0400087C RID: 2172
		[EnumMember(Value = "sync-xhr")]
		SyncXhr,
		// Token: 0x0400087D RID: 2173
		[EnumMember(Value = "trust-token-redemption")]
		TrustTokenRedemption,
		// Token: 0x0400087E RID: 2174
		[EnumMember(Value = "usb")]
		Usb,
		// Token: 0x0400087F RID: 2175
		[EnumMember(Value = "vertical-scroll")]
		VerticalScroll,
		// Token: 0x04000880 RID: 2176
		[EnumMember(Value = "web-share")]
		WebShare,
		// Token: 0x04000881 RID: 2177
		[EnumMember(Value = "window-placement")]
		WindowPlacement,
		// Token: 0x04000882 RID: 2178
		[EnumMember(Value = "xr-spatial-tracking")]
		XrSpatialTracking
	}
}
