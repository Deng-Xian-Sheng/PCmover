using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000013 RID: 19
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class LogFont
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003164 File Offset: 0x00001364
		// (set) Token: 0x0600006A RID: 106 RVA: 0x0000317B File Offset: 0x0000137B
		public int Height { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00003184 File Offset: 0x00001384
		// (set) Token: 0x0600006C RID: 108 RVA: 0x0000319B File Offset: 0x0000139B
		public int Width { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000031A4 File Offset: 0x000013A4
		// (set) Token: 0x0600006E RID: 110 RVA: 0x000031BB File Offset: 0x000013BB
		public int Escapement { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000031C4 File Offset: 0x000013C4
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000031DB File Offset: 0x000013DB
		public int Orientation { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000031E4 File Offset: 0x000013E4
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000031FB File Offset: 0x000013FB
		public int Weight { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00003204 File Offset: 0x00001404
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000321B File Offset: 0x0000141B
		public byte Italic { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003224 File Offset: 0x00001424
		// (set) Token: 0x06000076 RID: 118 RVA: 0x0000323B File Offset: 0x0000143B
		public byte Underline { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00003244 File Offset: 0x00001444
		// (set) Token: 0x06000078 RID: 120 RVA: 0x0000325B File Offset: 0x0000145B
		public byte Strikeout { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003264 File Offset: 0x00001464
		// (set) Token: 0x0600007A RID: 122 RVA: 0x0000327B File Offset: 0x0000147B
		public byte CharacterSet { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003284 File Offset: 0x00001484
		// (set) Token: 0x0600007C RID: 124 RVA: 0x0000329B File Offset: 0x0000149B
		public byte OutPrecision { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000032A4 File Offset: 0x000014A4
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000032BB File Offset: 0x000014BB
		public byte ClipPrecision { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000032C4 File Offset: 0x000014C4
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000032DB File Offset: 0x000014DB
		public byte Quality { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000032E4 File Offset: 0x000014E4
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000032FB File Offset: 0x000014FB
		public byte PitchAndFamily { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00003304 File Offset: 0x00001504
		// (set) Token: 0x06000084 RID: 132 RVA: 0x0000331C File Offset: 0x0000151C
		public string FaceName
		{
			get
			{
				return this.faceName;
			}
			set
			{
				this.faceName = value;
			}
		}

		// Token: 0x04000014 RID: 20
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string faceName = string.Empty;
	}
}
