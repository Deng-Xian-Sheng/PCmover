using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Input
{
	// Token: 0x0200033B RID: 827
	public class InputClient : DevToolsDomainBase
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x0001BF7B File Offset: 0x0001A17B
		public InputClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000093 RID: 147
		// (add) Token: 0x06001809 RID: 6153 RVA: 0x0001BF8A File Offset: 0x0001A18A
		// (remove) Token: 0x0600180A RID: 6154 RVA: 0x0001BF9D File Offset: 0x0001A19D
		public event EventHandler<DragInterceptedEventArgs> DragIntercepted
		{
			add
			{
				this._client.AddEventHandler<DragInterceptedEventArgs>("Input.dragIntercepted", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DragInterceptedEventArgs>("Input.dragIntercepted", value);
			}
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0001BFB4 File Offset: 0x0001A1B4
		public Task<DevToolsMethodResponse> DispatchDragEventAsync(DispatchDragEventType type, double x, double y, DragData data, int? modifiers = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("type", base.EnumToString(type));
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			dictionary.Add("data", data.ToDictionary());
			if (modifiers != null)
			{
				dictionary.Add("modifiers", modifiers.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.dispatchDragEvent", dictionary);
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x0001C044 File Offset: 0x0001A244
		public Task<DevToolsMethodResponse> DispatchKeyEventAsync(DispatchKeyEventType type, int? modifiers = null, double? timestamp = null, string text = null, string unmodifiedText = null, string keyIdentifier = null, string code = null, string key = null, int? windowsVirtualKeyCode = null, int? nativeVirtualKeyCode = null, bool? autoRepeat = null, bool? isKeypad = null, bool? isSystemKey = null, int? location = null, string[] commands = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("type", base.EnumToString(type));
			if (modifiers != null)
			{
				dictionary.Add("modifiers", modifiers.Value);
			}
			if (timestamp != null)
			{
				dictionary.Add("timestamp", timestamp.Value);
			}
			if (!string.IsNullOrEmpty(text))
			{
				dictionary.Add("text", text);
			}
			if (!string.IsNullOrEmpty(unmodifiedText))
			{
				dictionary.Add("unmodifiedText", unmodifiedText);
			}
			if (!string.IsNullOrEmpty(keyIdentifier))
			{
				dictionary.Add("keyIdentifier", keyIdentifier);
			}
			if (!string.IsNullOrEmpty(code))
			{
				dictionary.Add("code", code);
			}
			if (!string.IsNullOrEmpty(key))
			{
				dictionary.Add("key", key);
			}
			if (windowsVirtualKeyCode != null)
			{
				dictionary.Add("windowsVirtualKeyCode", windowsVirtualKeyCode.Value);
			}
			if (nativeVirtualKeyCode != null)
			{
				dictionary.Add("nativeVirtualKeyCode", nativeVirtualKeyCode.Value);
			}
			if (autoRepeat != null)
			{
				dictionary.Add("autoRepeat", autoRepeat.Value);
			}
			if (isKeypad != null)
			{
				dictionary.Add("isKeypad", isKeypad.Value);
			}
			if (isSystemKey != null)
			{
				dictionary.Add("isSystemKey", isSystemKey.Value);
			}
			if (location != null)
			{
				dictionary.Add("location", location.Value);
			}
			if (commands != null)
			{
				dictionary.Add("commands", commands);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.dispatchKeyEvent", dictionary);
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x0001C200 File Offset: 0x0001A400
		public Task<DevToolsMethodResponse> InsertTextAsync(string text)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("text", text);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.insertText", dictionary);
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x0001C230 File Offset: 0x0001A430
		public Task<DevToolsMethodResponse> ImeSetCompositionAsync(string text, int selectionStart, int selectionEnd, int? replacementStart = null, int? replacementEnd = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("text", text);
			dictionary.Add("selectionStart", selectionStart);
			dictionary.Add("selectionEnd", selectionEnd);
			if (replacementStart != null)
			{
				dictionary.Add("replacementStart", replacementStart.Value);
			}
			if (replacementEnd != null)
			{
				dictionary.Add("replacementEnd", replacementEnd.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.imeSetComposition", dictionary);
		}

		// Token: 0x0600180F RID: 6159 RVA: 0x0001C2C4 File Offset: 0x0001A4C4
		public Task<DevToolsMethodResponse> DispatchMouseEventAsync(DispatchMouseEventType type, double x, double y, int? modifiers = null, double? timestamp = null, MouseButton? button = null, int? buttons = null, int? clickCount = null, double? force = null, double? tangentialPressure = null, int? tiltX = null, int? tiltY = null, int? twist = null, double? deltaX = null, double? deltaY = null, DispatchMouseEventPointerType? pointerType = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("type", base.EnumToString(type));
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			if (modifiers != null)
			{
				dictionary.Add("modifiers", modifiers.Value);
			}
			if (timestamp != null)
			{
				dictionary.Add("timestamp", timestamp.Value);
			}
			if (button != null)
			{
				dictionary.Add("button", base.EnumToString(button));
			}
			if (buttons != null)
			{
				dictionary.Add("buttons", buttons.Value);
			}
			if (clickCount != null)
			{
				dictionary.Add("clickCount", clickCount.Value);
			}
			if (force != null)
			{
				dictionary.Add("force", force.Value);
			}
			if (tangentialPressure != null)
			{
				dictionary.Add("tangentialPressure", tangentialPressure.Value);
			}
			if (tiltX != null)
			{
				dictionary.Add("tiltX", tiltX.Value);
			}
			if (tiltY != null)
			{
				dictionary.Add("tiltY", tiltY.Value);
			}
			if (twist != null)
			{
				dictionary.Add("twist", twist.Value);
			}
			if (deltaX != null)
			{
				dictionary.Add("deltaX", deltaX.Value);
			}
			if (deltaY != null)
			{
				dictionary.Add("deltaY", deltaY.Value);
			}
			if (pointerType != null)
			{
				dictionary.Add("pointerType", base.EnumToString(pointerType));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.dispatchMouseEvent", dictionary);
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x0001C4C4 File Offset: 0x0001A6C4
		public Task<DevToolsMethodResponse> DispatchTouchEventAsync(DispatchTouchEventType type, IList<TouchPoint> touchPoints, int? modifiers = null, double? timestamp = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("type", base.EnumToString(type));
			dictionary.Add("touchPoints", from x in touchPoints
			select x.ToDictionary());
			if (modifiers != null)
			{
				dictionary.Add("modifiers", modifiers.Value);
			}
			if (timestamp != null)
			{
				dictionary.Add("timestamp", timestamp.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.dispatchTouchEvent", dictionary);
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x0001C570 File Offset: 0x0001A770
		public Task<DevToolsMethodResponse> EmulateTouchFromMouseEventAsync(EmulateTouchFromMouseEventType type, int x, int y, MouseButton button, double? timestamp = null, double? deltaX = null, double? deltaY = null, int? modifiers = null, int? clickCount = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("type", base.EnumToString(type));
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			dictionary.Add("button", base.EnumToString(button));
			if (timestamp != null)
			{
				dictionary.Add("timestamp", timestamp.Value);
			}
			if (deltaX != null)
			{
				dictionary.Add("deltaX", deltaX.Value);
			}
			if (deltaY != null)
			{
				dictionary.Add("deltaY", deltaY.Value);
			}
			if (modifiers != null)
			{
				dictionary.Add("modifiers", modifiers.Value);
			}
			if (clickCount != null)
			{
				dictionary.Add("clickCount", clickCount.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.emulateTouchFromMouseEvent", dictionary);
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x0001C688 File Offset: 0x0001A888
		public Task<DevToolsMethodResponse> SetIgnoreInputEventsAsync(bool ignore)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("ignore", ignore);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.setIgnoreInputEvents", dictionary);
		}

		// Token: 0x06001813 RID: 6163 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		public Task<DevToolsMethodResponse> SetInterceptDragsAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.setInterceptDrags", dictionary);
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x0001C6F8 File Offset: 0x0001A8F8
		public Task<DevToolsMethodResponse> SynthesizePinchGestureAsync(double x, double y, double scaleFactor, int? relativeSpeed = null, GestureSourceType? gestureSourceType = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			dictionary.Add("scaleFactor", scaleFactor);
			if (relativeSpeed != null)
			{
				dictionary.Add("relativeSpeed", relativeSpeed.Value);
			}
			if (gestureSourceType != null)
			{
				dictionary.Add("gestureSourceType", base.EnumToString(gestureSourceType));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.synthesizePinchGesture", dictionary);
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x0001C790 File Offset: 0x0001A990
		public Task<DevToolsMethodResponse> SynthesizeScrollGestureAsync(double x, double y, double? xDistance = null, double? yDistance = null, double? xOverscroll = null, double? yOverscroll = null, bool? preventFling = null, int? speed = null, GestureSourceType? gestureSourceType = null, int? repeatCount = null, int? repeatDelayMs = null, string interactionMarkerName = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			if (xDistance != null)
			{
				dictionary.Add("xDistance", xDistance.Value);
			}
			if (yDistance != null)
			{
				dictionary.Add("yDistance", yDistance.Value);
			}
			if (xOverscroll != null)
			{
				dictionary.Add("xOverscroll", xOverscroll.Value);
			}
			if (yOverscroll != null)
			{
				dictionary.Add("yOverscroll", yOverscroll.Value);
			}
			if (preventFling != null)
			{
				dictionary.Add("preventFling", preventFling.Value);
			}
			if (speed != null)
			{
				dictionary.Add("speed", speed.Value);
			}
			if (gestureSourceType != null)
			{
				dictionary.Add("gestureSourceType", base.EnumToString(gestureSourceType));
			}
			if (repeatCount != null)
			{
				dictionary.Add("repeatCount", repeatCount.Value);
			}
			if (repeatDelayMs != null)
			{
				dictionary.Add("repeatDelayMs", repeatDelayMs.Value);
			}
			if (!string.IsNullOrEmpty(interactionMarkerName))
			{
				dictionary.Add("interactionMarkerName", interactionMarkerName);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.synthesizeScrollGesture", dictionary);
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x0001C910 File Offset: 0x0001AB10
		public Task<DevToolsMethodResponse> SynthesizeTapGestureAsync(double x, double y, int? duration = null, int? tapCount = null, GestureSourceType? gestureSourceType = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			if (duration != null)
			{
				dictionary.Add("duration", duration.Value);
			}
			if (tapCount != null)
			{
				dictionary.Add("tapCount", tapCount.Value);
			}
			if (gestureSourceType != null)
			{
				dictionary.Add("gestureSourceType", base.EnumToString(gestureSourceType));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Input.synthesizeTapGesture", dictionary);
		}

		// Token: 0x04000D5F RID: 3423
		private IDevToolsClient _client;
	}
}
