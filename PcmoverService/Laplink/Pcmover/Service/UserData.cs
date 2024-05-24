using System;
using System.Linq;
using System.Management;
using System.Text;
using System.Xml.Linq;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000032 RID: 50
	internal class UserData
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00010B3C File Offset: 0x0000ED3C
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00010B44 File Offset: 0x0000ED44
		public bool IncludeNetName { get; set; }

		// Token: 0x06000251 RID: 593 RVA: 0x00010B4D File Offset: 0x0000ED4D
		public UserData(PCmoverApp app, string serialNumber)
		{
			this._app = app;
			this._serialNumber = (serialNumber ?? string.Empty);
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00010B6C File Offset: 0x0000ED6C
		public byte[] UserDataUTF8
		{
			get
			{
				return this.GetUTF8(false, false);
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00010B78 File Offset: 0x0000ED78
		public byte[] GetUTF8(bool includeIsOld, bool isOld)
		{
			string text = "<UserData><age>" + UserData.ThisMachineAge.Age.Ticks.ToString() + "</age>";
			if (includeIsOld)
			{
				text = text + "<io>" + (isOld ? "1" : "0") + "</io>";
			}
			if (this.IncludeNetName)
			{
				string netName = this._app.ThisMachine.NetName;
				if (!string.IsNullOrEmpty(netName))
				{
					text = text + "<nn>" + UserData.createCDATA(netName) + "</nn>";
				}
			}
			string friendlyName = this._app.ThisMachine.FriendlyName;
			if (friendlyName != null && friendlyName.Length != 0)
			{
				text = text + "<fn>" + UserData.createCDATA(friendlyName) + "</fn>";
			}
			if (this._serialNumber.Length != 0)
			{
				text = text + "<sn>" + UserData.createCDATA(this._serialNumber) + "</sn>";
			}
			text = text + "<os>" + UserData.createCDATA(UserData.ThisMachineAge.WindowsVersion.ToString(3)) + "</os>";
			if (!string.IsNullOrEmpty(UserData.Processor))
			{
				text = text + "<wp>" + UserData.createCDATA(UserData.Processor) + "</wp>";
			}
			text = text + "<vn>" + UserData.createCDATA(this._app.ThisMachine.HasValidSerialNumber ? "1" : "0") + "</vn>";
			text = text + "<dn>" + UserData.createCDATA(this._app.CertificateName) + "</dn>";
			text = text + "<id>" + UserData.MyUniqueId + "</id>";
			text += "</UserData>";
			return UserData.encoding.GetBytes(text);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00010D38 File Offset: 0x0000EF38
		public static bool parse(byte[] UserDataUTF8, ConnectableMachine connectable)
		{
			if (UserDataUTF8 == null || UserDataUTF8.Length == 0)
			{
				return false;
			}
			string @string = UserData.encoding.GetString(UserDataUTF8);
			try
			{
				XElement xelement = XDocument.Parse(@string).Element("UserData");
				if (xelement != null)
				{
					try
					{
						XElement xelement2 = xelement.Element("nn");
						if (xelement2 != null && xelement2.Value != null)
						{
							connectable.NetName = UserData.unescapeCDATA(xelement2.Value);
						}
					}
					catch
					{
					}
					try
					{
						XElement xelement3 = xelement.Element("fn");
						if (xelement3 != null && xelement3.Value != null)
						{
							connectable.FriendlyName = UserData.unescapeCDATA(xelement3.Value);
						}
					}
					catch
					{
					}
					try
					{
						XElement xelement4 = xelement.Element("sn");
						if (xelement4 != null && xelement4.Value != null)
						{
							connectable.SerialNumber = UserData.unescapeCDATA(xelement4.Value);
						}
					}
					catch
					{
					}
					try
					{
						XElement xelement5 = xelement.Element("vn");
						if (xelement5 != null && xelement5.Value != null)
						{
							connectable.HasValidSerialNumber = (UserData.unescapeCDATA(xelement5.Value) != "0");
						}
					}
					catch
					{
					}
					connectable.Cpu = "";
					try
					{
						XElement xelement6 = xelement.Element("wp");
						if (xelement6 != null && xelement6.Value != null)
						{
							connectable.Cpu = UserData.unescapeCDATA(xelement6.Value);
						}
					}
					catch
					{
					}
					XElement xelement7 = xelement.Element("age");
					if (xelement7 != null && xelement7.Value != null)
					{
						connectable.CreationTime = new DateTime(long.Parse(xelement7.Value));
					}
					XElement xelement8 = xelement.Element("id");
					if (xelement8 != null && xelement8.Value != null)
					{
						connectable.UniqueId = xelement8.Value;
					}
					int osmajor = 0;
					int osminor = 0;
					int osbuild = 0;
					connectable.OperatingSystem = "";
					try
					{
						XElement xelement9 = xelement.Element("os");
						if (xelement9 != null && xelement9.Value != null)
						{
							connectable.OperatingSystem = UserData.unescapeCDATA(xelement9.Value);
							char[] separator = new char[]
							{
								'.',
								' '
							};
							string[] array = connectable.OperatingSystem.Split(separator);
							if (array.Length != 0)
							{
								osmajor = int.Parse(array[0]);
							}
							if (array.Length > 1)
							{
								osminor = int.Parse(array[1]);
							}
							if (array.Length > 2)
							{
								osbuild = int.Parse(array[2]);
							}
						}
					}
					catch
					{
					}
					connectable.OSmajor = osmajor;
					connectable.OSminor = osminor;
					connectable.OSbuild = osbuild;
					connectable.CertificateName = "";
					try
					{
						XElement xelement10 = xelement.Element("dn");
						if (xelement10 != null && xelement10.Value != null)
						{
							connectable.CertificateName = UserData.unescapeCDATA(xelement10.Value);
						}
					}
					catch
					{
					}
					connectable.XPVersion = (connectable.SerialNumber == "XP MACHINE");
					MachineAge machineAge = new MachineAge
					{
						Age = connectable.CreationTime,
						WindowsVersion = new Version(connectable.OSmajor, connectable.OSminor, connectable.OSbuild),
						IsXpVersionOfService = connectable.XPVersion
					};
					connectable.IsOld = machineAge.IsOlderThan(UserData.ThisMachineAge);
					try
					{
						XElement xelement11 = xelement.Element("io");
						if (xelement11 != null && xelement11.Value != null)
						{
							connectable.IsOld = (xelement11.Value == "1");
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00011178 File Offset: 0x0000F378
		public static string createCDATA(string data)
		{
			return "<![CDATA[" + data.Replace("\\", "\\\\").Replace("]", "\\]") + "]]>";
		}

		// Token: 0x06000256 RID: 598 RVA: 0x000111A8 File Offset: 0x0000F3A8
		public static string unescapeCDATA(string cdata)
		{
			return cdata.Replace("\\]", "]").Replace("\\\\", "\\");
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000257 RID: 599 RVA: 0x000111CC File Offset: 0x0000F3CC
		public static Version OSVersion
		{
			get
			{
				if (UserData._osVersion == null)
				{
					try
					{
						UserData._osVersion = new Version((string)new ManagementObjectSearcher("select Version from Win32_OperatingSystem").Get().Cast<ManagementObject>().First<ManagementObject>()["Version"]);
					}
					catch
					{
						UserData._osVersion = Environment.OSVersion.Version;
					}
				}
				return UserData._osVersion;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00011244 File Offset: 0x0000F444
		private static MachineAge ThisMachineAge
		{
			get
			{
				if (UserData._thisMachineAge == null)
				{
					UserData._thisMachineAge = new MachineAge
					{
						Age = MachineAge.GetMyCreationTime(),
						WindowsVersion = UserData.OSVersion
					};
				}
				return UserData._thisMachineAge;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00011274 File Offset: 0x0000F474
		private static string Processor
		{
			get
			{
				if (UserData._processor == null)
				{
					try
					{
						string processor = "0";
						if (((string)new ManagementObjectSearcher("select Manufacturer from Win32_Processor").Get().Cast<ManagementObject>().First<ManagementObject>()["Manufacturer"]).CompareTo("GenuineIntel") == 0)
						{
							processor = "1";
						}
						UserData._processor = processor;
					}
					catch
					{
						UserData._processor = "";
					}
				}
				return UserData._processor;
			}
		}

		// Token: 0x040000BC RID: 188
		public static string MyUniqueId = Guid.NewGuid().ToString();

		// Token: 0x040000BD RID: 189
		public const string XPSerialNumber = "XP MACHINE";

		// Token: 0x040000BE RID: 190
		private readonly PCmoverApp _app;

		// Token: 0x040000BF RID: 191
		private readonly string _serialNumber;

		// Token: 0x040000C1 RID: 193
		public static UTF8Encoding encoding = new UTF8Encoding();

		// Token: 0x040000C2 RID: 194
		private static Version _osVersion;

		// Token: 0x040000C3 RID: 195
		private static MachineAge _thisMachineAge;

		// Token: 0x040000C4 RID: 196
		private static string _processor;
	}
}
