using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000254 RID: 596
	public enum BackForwardCacheNotRestoredReason
	{
		// Token: 0x04000928 RID: 2344
		[EnumMember(Value = "NotPrimaryMainFrame")]
		NotPrimaryMainFrame,
		// Token: 0x04000929 RID: 2345
		[EnumMember(Value = "BackForwardCacheDisabled")]
		BackForwardCacheDisabled,
		// Token: 0x0400092A RID: 2346
		[EnumMember(Value = "RelatedActiveContentsExist")]
		RelatedActiveContentsExist,
		// Token: 0x0400092B RID: 2347
		[EnumMember(Value = "HTTPStatusNotOK")]
		HTTPStatusNotOK,
		// Token: 0x0400092C RID: 2348
		[EnumMember(Value = "SchemeNotHTTPOrHTTPS")]
		SchemeNotHTTPOrHTTPS,
		// Token: 0x0400092D RID: 2349
		[EnumMember(Value = "Loading")]
		Loading,
		// Token: 0x0400092E RID: 2350
		[EnumMember(Value = "WasGrantedMediaAccess")]
		WasGrantedMediaAccess,
		// Token: 0x0400092F RID: 2351
		[EnumMember(Value = "DisableForRenderFrameHostCalled")]
		DisableForRenderFrameHostCalled,
		// Token: 0x04000930 RID: 2352
		[EnumMember(Value = "DomainNotAllowed")]
		DomainNotAllowed,
		// Token: 0x04000931 RID: 2353
		[EnumMember(Value = "HTTPMethodNotGET")]
		HTTPMethodNotGET,
		// Token: 0x04000932 RID: 2354
		[EnumMember(Value = "SubframeIsNavigating")]
		SubframeIsNavigating,
		// Token: 0x04000933 RID: 2355
		[EnumMember(Value = "Timeout")]
		Timeout,
		// Token: 0x04000934 RID: 2356
		[EnumMember(Value = "CacheLimit")]
		CacheLimit,
		// Token: 0x04000935 RID: 2357
		[EnumMember(Value = "JavaScriptExecution")]
		JavaScriptExecution,
		// Token: 0x04000936 RID: 2358
		[EnumMember(Value = "RendererProcessKilled")]
		RendererProcessKilled,
		// Token: 0x04000937 RID: 2359
		[EnumMember(Value = "RendererProcessCrashed")]
		RendererProcessCrashed,
		// Token: 0x04000938 RID: 2360
		[EnumMember(Value = "GrantedMediaStreamAccess")]
		GrantedMediaStreamAccess,
		// Token: 0x04000939 RID: 2361
		[EnumMember(Value = "SchedulerTrackedFeatureUsed")]
		SchedulerTrackedFeatureUsed,
		// Token: 0x0400093A RID: 2362
		[EnumMember(Value = "ConflictingBrowsingInstance")]
		ConflictingBrowsingInstance,
		// Token: 0x0400093B RID: 2363
		[EnumMember(Value = "CacheFlushed")]
		CacheFlushed,
		// Token: 0x0400093C RID: 2364
		[EnumMember(Value = "ServiceWorkerVersionActivation")]
		ServiceWorkerVersionActivation,
		// Token: 0x0400093D RID: 2365
		[EnumMember(Value = "SessionRestored")]
		SessionRestored,
		// Token: 0x0400093E RID: 2366
		[EnumMember(Value = "ServiceWorkerPostMessage")]
		ServiceWorkerPostMessage,
		// Token: 0x0400093F RID: 2367
		[EnumMember(Value = "EnteredBackForwardCacheBeforeServiceWorkerHostAdded")]
		EnteredBackForwardCacheBeforeServiceWorkerHostAdded,
		// Token: 0x04000940 RID: 2368
		[EnumMember(Value = "RenderFrameHostReused_SameSite")]
		RenderFrameHostReusedSameSite,
		// Token: 0x04000941 RID: 2369
		[EnumMember(Value = "RenderFrameHostReused_CrossSite")]
		RenderFrameHostReusedCrossSite,
		// Token: 0x04000942 RID: 2370
		[EnumMember(Value = "ServiceWorkerClaim")]
		ServiceWorkerClaim,
		// Token: 0x04000943 RID: 2371
		[EnumMember(Value = "IgnoreEventAndEvict")]
		IgnoreEventAndEvict,
		// Token: 0x04000944 RID: 2372
		[EnumMember(Value = "HaveInnerContents")]
		HaveInnerContents,
		// Token: 0x04000945 RID: 2373
		[EnumMember(Value = "TimeoutPuttingInCache")]
		TimeoutPuttingInCache,
		// Token: 0x04000946 RID: 2374
		[EnumMember(Value = "BackForwardCacheDisabledByLowMemory")]
		BackForwardCacheDisabledByLowMemory,
		// Token: 0x04000947 RID: 2375
		[EnumMember(Value = "BackForwardCacheDisabledByCommandLine")]
		BackForwardCacheDisabledByCommandLine,
		// Token: 0x04000948 RID: 2376
		[EnumMember(Value = "NetworkRequestDatapipeDrainedAsBytesConsumer")]
		NetworkRequestDatapipeDrainedAsBytesConsumer,
		// Token: 0x04000949 RID: 2377
		[EnumMember(Value = "NetworkRequestRedirected")]
		NetworkRequestRedirected,
		// Token: 0x0400094A RID: 2378
		[EnumMember(Value = "NetworkRequestTimeout")]
		NetworkRequestTimeout,
		// Token: 0x0400094B RID: 2379
		[EnumMember(Value = "NetworkExceedsBufferLimit")]
		NetworkExceedsBufferLimit,
		// Token: 0x0400094C RID: 2380
		[EnumMember(Value = "NavigationCancelledWhileRestoring")]
		NavigationCancelledWhileRestoring,
		// Token: 0x0400094D RID: 2381
		[EnumMember(Value = "NotMostRecentNavigationEntry")]
		NotMostRecentNavigationEntry,
		// Token: 0x0400094E RID: 2382
		[EnumMember(Value = "BackForwardCacheDisabledForPrerender")]
		BackForwardCacheDisabledForPrerender,
		// Token: 0x0400094F RID: 2383
		[EnumMember(Value = "UserAgentOverrideDiffers")]
		UserAgentOverrideDiffers,
		// Token: 0x04000950 RID: 2384
		[EnumMember(Value = "ForegroundCacheLimit")]
		ForegroundCacheLimit,
		// Token: 0x04000951 RID: 2385
		[EnumMember(Value = "BrowsingInstanceNotSwapped")]
		BrowsingInstanceNotSwapped,
		// Token: 0x04000952 RID: 2386
		[EnumMember(Value = "BackForwardCacheDisabledForDelegate")]
		BackForwardCacheDisabledForDelegate,
		// Token: 0x04000953 RID: 2387
		[EnumMember(Value = "OptInUnloadHeaderNotPresent")]
		OptInUnloadHeaderNotPresent,
		// Token: 0x04000954 RID: 2388
		[EnumMember(Value = "UnloadHandlerExistsInMainFrame")]
		UnloadHandlerExistsInMainFrame,
		// Token: 0x04000955 RID: 2389
		[EnumMember(Value = "UnloadHandlerExistsInSubFrame")]
		UnloadHandlerExistsInSubFrame,
		// Token: 0x04000956 RID: 2390
		[EnumMember(Value = "ServiceWorkerUnregistration")]
		ServiceWorkerUnregistration,
		// Token: 0x04000957 RID: 2391
		[EnumMember(Value = "CacheControlNoStore")]
		CacheControlNoStore,
		// Token: 0x04000958 RID: 2392
		[EnumMember(Value = "CacheControlNoStoreCookieModified")]
		CacheControlNoStoreCookieModified,
		// Token: 0x04000959 RID: 2393
		[EnumMember(Value = "CacheControlNoStoreHTTPOnlyCookieModified")]
		CacheControlNoStoreHTTPOnlyCookieModified,
		// Token: 0x0400095A RID: 2394
		[EnumMember(Value = "NoResponseHead")]
		NoResponseHead,
		// Token: 0x0400095B RID: 2395
		[EnumMember(Value = "Unknown")]
		Unknown,
		// Token: 0x0400095C RID: 2396
		[EnumMember(Value = "ActivationNavigationsDisallowedForBug1234857")]
		ActivationNavigationsDisallowedForBug1234857,
		// Token: 0x0400095D RID: 2397
		[EnumMember(Value = "WebSocket")]
		WebSocket,
		// Token: 0x0400095E RID: 2398
		[EnumMember(Value = "WebTransport")]
		WebTransport,
		// Token: 0x0400095F RID: 2399
		[EnumMember(Value = "WebRTC")]
		WebRTC,
		// Token: 0x04000960 RID: 2400
		[EnumMember(Value = "MainResourceHasCacheControlNoStore")]
		MainResourceHasCacheControlNoStore,
		// Token: 0x04000961 RID: 2401
		[EnumMember(Value = "MainResourceHasCacheControlNoCache")]
		MainResourceHasCacheControlNoCache,
		// Token: 0x04000962 RID: 2402
		[EnumMember(Value = "SubresourceHasCacheControlNoStore")]
		SubresourceHasCacheControlNoStore,
		// Token: 0x04000963 RID: 2403
		[EnumMember(Value = "SubresourceHasCacheControlNoCache")]
		SubresourceHasCacheControlNoCache,
		// Token: 0x04000964 RID: 2404
		[EnumMember(Value = "ContainsPlugins")]
		ContainsPlugins,
		// Token: 0x04000965 RID: 2405
		[EnumMember(Value = "DocumentLoaded")]
		DocumentLoaded,
		// Token: 0x04000966 RID: 2406
		[EnumMember(Value = "DedicatedWorkerOrWorklet")]
		DedicatedWorkerOrWorklet,
		// Token: 0x04000967 RID: 2407
		[EnumMember(Value = "OutstandingNetworkRequestOthers")]
		OutstandingNetworkRequestOthers,
		// Token: 0x04000968 RID: 2408
		[EnumMember(Value = "OutstandingIndexedDBTransaction")]
		OutstandingIndexedDBTransaction,
		// Token: 0x04000969 RID: 2409
		[EnumMember(Value = "RequestedNotificationsPermission")]
		RequestedNotificationsPermission,
		// Token: 0x0400096A RID: 2410
		[EnumMember(Value = "RequestedMIDIPermission")]
		RequestedMIDIPermission,
		// Token: 0x0400096B RID: 2411
		[EnumMember(Value = "RequestedAudioCapturePermission")]
		RequestedAudioCapturePermission,
		// Token: 0x0400096C RID: 2412
		[EnumMember(Value = "RequestedVideoCapturePermission")]
		RequestedVideoCapturePermission,
		// Token: 0x0400096D RID: 2413
		[EnumMember(Value = "RequestedBackForwardCacheBlockedSensors")]
		RequestedBackForwardCacheBlockedSensors,
		// Token: 0x0400096E RID: 2414
		[EnumMember(Value = "RequestedBackgroundWorkPermission")]
		RequestedBackgroundWorkPermission,
		// Token: 0x0400096F RID: 2415
		[EnumMember(Value = "BroadcastChannel")]
		BroadcastChannel,
		// Token: 0x04000970 RID: 2416
		[EnumMember(Value = "IndexedDBConnection")]
		IndexedDBConnection,
		// Token: 0x04000971 RID: 2417
		[EnumMember(Value = "WebXR")]
		WebXR,
		// Token: 0x04000972 RID: 2418
		[EnumMember(Value = "SharedWorker")]
		SharedWorker,
		// Token: 0x04000973 RID: 2419
		[EnumMember(Value = "WebLocks")]
		WebLocks,
		// Token: 0x04000974 RID: 2420
		[EnumMember(Value = "WebHID")]
		WebHID,
		// Token: 0x04000975 RID: 2421
		[EnumMember(Value = "WebShare")]
		WebShare,
		// Token: 0x04000976 RID: 2422
		[EnumMember(Value = "RequestedStorageAccessGrant")]
		RequestedStorageAccessGrant,
		// Token: 0x04000977 RID: 2423
		[EnumMember(Value = "WebNfc")]
		WebNfc,
		// Token: 0x04000978 RID: 2424
		[EnumMember(Value = "OutstandingNetworkRequestFetch")]
		OutstandingNetworkRequestFetch,
		// Token: 0x04000979 RID: 2425
		[EnumMember(Value = "OutstandingNetworkRequestXHR")]
		OutstandingNetworkRequestXHR,
		// Token: 0x0400097A RID: 2426
		[EnumMember(Value = "AppBanner")]
		AppBanner,
		// Token: 0x0400097B RID: 2427
		[EnumMember(Value = "Printing")]
		Printing,
		// Token: 0x0400097C RID: 2428
		[EnumMember(Value = "WebDatabase")]
		WebDatabase,
		// Token: 0x0400097D RID: 2429
		[EnumMember(Value = "PictureInPicture")]
		PictureInPicture,
		// Token: 0x0400097E RID: 2430
		[EnumMember(Value = "Portal")]
		Portal,
		// Token: 0x0400097F RID: 2431
		[EnumMember(Value = "SpeechRecognizer")]
		SpeechRecognizer,
		// Token: 0x04000980 RID: 2432
		[EnumMember(Value = "IdleManager")]
		IdleManager,
		// Token: 0x04000981 RID: 2433
		[EnumMember(Value = "PaymentManager")]
		PaymentManager,
		// Token: 0x04000982 RID: 2434
		[EnumMember(Value = "SpeechSynthesis")]
		SpeechSynthesis,
		// Token: 0x04000983 RID: 2435
		[EnumMember(Value = "KeyboardLock")]
		KeyboardLock,
		// Token: 0x04000984 RID: 2436
		[EnumMember(Value = "WebOTPService")]
		WebOTPService,
		// Token: 0x04000985 RID: 2437
		[EnumMember(Value = "OutstandingNetworkRequestDirectSocket")]
		OutstandingNetworkRequestDirectSocket,
		// Token: 0x04000986 RID: 2438
		[EnumMember(Value = "InjectedJavascript")]
		InjectedJavascript,
		// Token: 0x04000987 RID: 2439
		[EnumMember(Value = "InjectedStyleSheet")]
		InjectedStyleSheet,
		// Token: 0x04000988 RID: 2440
		[EnumMember(Value = "Dummy")]
		Dummy,
		// Token: 0x04000989 RID: 2441
		[EnumMember(Value = "ContentSecurityHandler")]
		ContentSecurityHandler,
		// Token: 0x0400098A RID: 2442
		[EnumMember(Value = "ContentWebAuthenticationAPI")]
		ContentWebAuthenticationAPI,
		// Token: 0x0400098B RID: 2443
		[EnumMember(Value = "ContentFileChooser")]
		ContentFileChooser,
		// Token: 0x0400098C RID: 2444
		[EnumMember(Value = "ContentSerial")]
		ContentSerial,
		// Token: 0x0400098D RID: 2445
		[EnumMember(Value = "ContentFileSystemAccess")]
		ContentFileSystemAccess,
		// Token: 0x0400098E RID: 2446
		[EnumMember(Value = "ContentMediaDevicesDispatcherHost")]
		ContentMediaDevicesDispatcherHost,
		// Token: 0x0400098F RID: 2447
		[EnumMember(Value = "ContentWebBluetooth")]
		ContentWebBluetooth,
		// Token: 0x04000990 RID: 2448
		[EnumMember(Value = "ContentWebUSB")]
		ContentWebUSB,
		// Token: 0x04000991 RID: 2449
		[EnumMember(Value = "ContentMediaSession")]
		ContentMediaSession,
		// Token: 0x04000992 RID: 2450
		[EnumMember(Value = "ContentMediaSessionService")]
		ContentMediaSessionService,
		// Token: 0x04000993 RID: 2451
		[EnumMember(Value = "ContentScreenReader")]
		ContentScreenReader,
		// Token: 0x04000994 RID: 2452
		[EnumMember(Value = "EmbedderPopupBlockerTabHelper")]
		EmbedderPopupBlockerTabHelper,
		// Token: 0x04000995 RID: 2453
		[EnumMember(Value = "EmbedderSafeBrowsingTriggeredPopupBlocker")]
		EmbedderSafeBrowsingTriggeredPopupBlocker,
		// Token: 0x04000996 RID: 2454
		[EnumMember(Value = "EmbedderSafeBrowsingThreatDetails")]
		EmbedderSafeBrowsingThreatDetails,
		// Token: 0x04000997 RID: 2455
		[EnumMember(Value = "EmbedderAppBannerManager")]
		EmbedderAppBannerManager,
		// Token: 0x04000998 RID: 2456
		[EnumMember(Value = "EmbedderDomDistillerViewerSource")]
		EmbedderDomDistillerViewerSource,
		// Token: 0x04000999 RID: 2457
		[EnumMember(Value = "EmbedderDomDistillerSelfDeletingRequestDelegate")]
		EmbedderDomDistillerSelfDeletingRequestDelegate,
		// Token: 0x0400099A RID: 2458
		[EnumMember(Value = "EmbedderOomInterventionTabHelper")]
		EmbedderOomInterventionTabHelper,
		// Token: 0x0400099B RID: 2459
		[EnumMember(Value = "EmbedderOfflinePage")]
		EmbedderOfflinePage,
		// Token: 0x0400099C RID: 2460
		[EnumMember(Value = "EmbedderChromePasswordManagerClientBindCredentialManager")]
		EmbedderChromePasswordManagerClientBindCredentialManager,
		// Token: 0x0400099D RID: 2461
		[EnumMember(Value = "EmbedderPermissionRequestManager")]
		EmbedderPermissionRequestManager,
		// Token: 0x0400099E RID: 2462
		[EnumMember(Value = "EmbedderModalDialog")]
		EmbedderModalDialog,
		// Token: 0x0400099F RID: 2463
		[EnumMember(Value = "EmbedderExtensions")]
		EmbedderExtensions,
		// Token: 0x040009A0 RID: 2464
		[EnumMember(Value = "EmbedderExtensionMessaging")]
		EmbedderExtensionMessaging,
		// Token: 0x040009A1 RID: 2465
		[EnumMember(Value = "EmbedderExtensionMessagingForOpenPort")]
		EmbedderExtensionMessagingForOpenPort,
		// Token: 0x040009A2 RID: 2466
		[EnumMember(Value = "EmbedderExtensionSentMessageToCachedFrame")]
		EmbedderExtensionSentMessageToCachedFrame
	}
}
