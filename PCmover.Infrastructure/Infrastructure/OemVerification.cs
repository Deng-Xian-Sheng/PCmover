using System;
using System.Diagnostics;
using System.Management;
using Laplink.Pcmover.Contracts;
using PcmBrandUI.Properties;

namespace PCmover.Infrastructure
{
	// Token: 0x0200002E RID: 46
	public class OemVerification
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000761D File Offset: 0x0000581D
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00007625 File Offset: 0x00005825
		public bool Verified { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000762E File Offset: 0x0000582E
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00007636 File Offset: 0x00005836
		public string Message { get; set; }

		// Token: 0x060002A4 RID: 676 RVA: 0x00007640 File Offset: 0x00005840
		public static OemVerification VerifyStartupOemRestrictions(Process process, IPCmoverEngine engine)
		{
			OemVerification oemVerification = new OemVerification
			{
				Verified = false
			};
			PolicyData policy = engine.Policy;
			EnginePolicyData enginePolicyData = (policy != null) ? policy.Engine : null;
			if (enginePolicyData != null && enginePolicyData.OemId == 69U && enginePolicyData.VerifyOemOnNew && enginePolicyData.VerifyOemOnOld)
			{
				string text = OemVerification.GetParentProcessName(process).ToLower();
				if (text == "ettoolbox" || text == "ettb_prem" || text == "a0001_etdashboard" || text == "winpe_ettb" || text == "sts_prem")
				{
					oemVerification.Verified = true;
				}
				else
				{
					engine.Ts.TraceWarning("Oem startup verification failed (" + text + ")");
					oemVerification.Message = Resources.HardwareOemMessage;
				}
			}
			else
			{
				oemVerification.Verified = true;
			}
			return oemVerification;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000771C File Offset: 0x0000591C
		private static string GetParentProcessName(Process p)
		{
			string result;
			try
			{
				ManagementObject managementObject = new ManagementObject(string.Format("win32_process.handle='{0}'", p.Id));
				managementObject.Get();
				result = Process.GetProcessById(Convert.ToInt32(managementObject["ParentProcessId"])).ProcessName;
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
