using System;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace Laplink.Tools.Popups
{
	// Token: 0x0200000B RID: 11
	public class PopupEvents
	{
		// Token: 0x02000011 RID: 17
		public class ResolveInfo
		{
			// Token: 0x06000085 RID: 133 RVA: 0x000031AA File Offset: 0x000013AA
			public ResolveInfo(Type type, ParameterOverride paramOverride = null)
			{
				this.Type = type;
				this.ParamOverride = paramOverride;
			}

			// Token: 0x06000086 RID: 134 RVA: 0x000031C0 File Offset: 0x000013C0
			public object Resolve(IUnityContainer container)
			{
				if (this.ParamOverride == null)
				{
					return container.Resolve(this.Type, Array.Empty<ResolverOverride>());
				}
				return container.Resolve(this.Type, new ResolverOverride[]
				{
					this.ParamOverride
				});
			}

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x06000087 RID: 135 RVA: 0x000031F7 File Offset: 0x000013F7
			public Type Type { get; }

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x06000088 RID: 136 RVA: 0x000031FF File Offset: 0x000013FF
			public ParameterOverride ParamOverride { get; }
		}

		// Token: 0x02000012 RID: 18
		public class ShowPopup : PubSubEvent<PopupEvents.ResolveInfo>
		{
		}

		// Token: 0x02000013 RID: 19
		public enum MBICON
		{
			// Token: 0x0400003E RID: 62
			MB_NONE,
			// Token: 0x0400003F RID: 63
			MB_EXCLAMATION,
			// Token: 0x04000040 RID: 64
			MB_WARNING,
			// Token: 0x04000041 RID: 65
			MB_INFORMATION,
			// Token: 0x04000042 RID: 66
			MB_QUESTION,
			// Token: 0x04000043 RID: 67
			MB_STOP
		}

		// Token: 0x02000014 RID: 20
		public enum MBType
		{
			// Token: 0x04000045 RID: 69
			MB_OK,
			// Token: 0x04000046 RID: 70
			MB_OKCANCEL,
			// Token: 0x04000047 RID: 71
			MB_YESNOCANCEL = 3,
			// Token: 0x04000048 RID: 72
			MB_YESNO,
			// Token: 0x04000049 RID: 73
			MB_CANCELCONTINUE = 6
		}

		// Token: 0x02000015 RID: 21
		public class MessageBoxEventArgs : EventArgs
		{
			// Token: 0x1700003E RID: 62
			// (get) Token: 0x0600008A RID: 138 RVA: 0x0000320F File Offset: 0x0000140F
			// (set) Token: 0x0600008B RID: 139 RVA: 0x00003217 File Offset: 0x00001417
			public string Caption { get; set; }

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x0600008C RID: 140 RVA: 0x00003220 File Offset: 0x00001420
			// (set) Token: 0x0600008D RID: 141 RVA: 0x00003228 File Offset: 0x00001428
			public string Message1 { get; set; }

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x0600008E RID: 142 RVA: 0x00003231 File Offset: 0x00001431
			// (set) Token: 0x0600008F RID: 143 RVA: 0x00003239 File Offset: 0x00001439
			public string Message2 { get; set; }

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x06000090 RID: 144 RVA: 0x00003242 File Offset: 0x00001442
			// (set) Token: 0x06000091 RID: 145 RVA: 0x0000324A File Offset: 0x0000144A
			public string Message3 { get; set; }

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x06000092 RID: 146 RVA: 0x00003253 File Offset: 0x00001453
			// (set) Token: 0x06000093 RID: 147 RVA: 0x0000325B File Offset: 0x0000145B
			public string Message4 { get; set; }

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x06000094 RID: 148 RVA: 0x00003264 File Offset: 0x00001464
			// (set) Token: 0x06000095 RID: 149 RVA: 0x0000326C File Offset: 0x0000146C
			public string Message5 { get; set; }

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x06000096 RID: 150 RVA: 0x00003275 File Offset: 0x00001475
			// (set) Token: 0x06000097 RID: 151 RVA: 0x0000327D File Offset: 0x0000147D
			public string Message6 { get; set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x06000098 RID: 152 RVA: 0x00003286 File Offset: 0x00001486
			// (set) Token: 0x06000099 RID: 153 RVA: 0x0000328E File Offset: 0x0000148E
			public string Message7 { get; set; }

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x0600009A RID: 154 RVA: 0x00003297 File Offset: 0x00001497
			// (set) Token: 0x0600009B RID: 155 RVA: 0x0000329F File Offset: 0x0000149F
			public string Message8 { get; set; }

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x0600009C RID: 156 RVA: 0x000032A8 File Offset: 0x000014A8
			// (set) Token: 0x0600009D RID: 157 RVA: 0x000032B0 File Offset: 0x000014B0
			public string Message9 { get; set; }

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x0600009E RID: 158 RVA: 0x000032B9 File Offset: 0x000014B9
			// (set) Token: 0x0600009F RID: 159 RVA: 0x000032C1 File Offset: 0x000014C1
			public string Message10 { get; set; }

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x060000A0 RID: 160 RVA: 0x000032CA File Offset: 0x000014CA
			// (set) Token: 0x060000A1 RID: 161 RVA: 0x000032D2 File Offset: 0x000014D2
			public Action<int> Callback { get; set; }

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x060000A2 RID: 162 RVA: 0x000032DB File Offset: 0x000014DB
			// (set) Token: 0x060000A3 RID: 163 RVA: 0x000032E3 File Offset: 0x000014E3
			public bool IsModal { get; set; }

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x060000A4 RID: 164 RVA: 0x000032EC File Offset: 0x000014EC
			// (set) Token: 0x060000A5 RID: 165 RVA: 0x000032F4 File Offset: 0x000014F4
			public PopupEvents.MBType Type { get; set; }

			// Token: 0x1700004C RID: 76
			// (get) Token: 0x060000A6 RID: 166 RVA: 0x000032FD File Offset: 0x000014FD
			// (set) Token: 0x060000A7 RID: 167 RVA: 0x00003305 File Offset: 0x00001505
			public PopupEvents.MBICON Icon { get; set; }

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000330E File Offset: 0x0000150E
			// (set) Token: 0x060000A9 RID: 169 RVA: 0x00003316 File Offset: 0x00001516
			public bool WouldBlock { get; set; }
		}

		// Token: 0x02000016 RID: 22
		public class MessageBoxEvent : PubSubEvent<PopupEvents.MessageBoxEventArgs>
		{
		}
	}
}
