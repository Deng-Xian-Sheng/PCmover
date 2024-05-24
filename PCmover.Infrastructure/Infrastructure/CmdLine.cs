using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PCmover.Infrastructure
{
	// Token: 0x02000008 RID: 8
	public class CmdLine
	{
		// Token: 0x06000037 RID: 55 RVA: 0x0000248B File Offset: 0x0000068B
		public CmdLine()
		{
			this.Parameters = new List<Parameter>();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000249E File Offset: 0x0000069E
		public CmdLine(StartupEventArgs e)
		{
			this.Parameters = new List<Parameter>();
			this.SplitLine(e);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000024BC File Offset: 0x000006BC
		public int SplitLine(StartupEventArgs e)
		{
			Parameter parameter = null;
			for (int i = 0; i < e.Args.Length; i++)
			{
				if (this.IsSwitch(e.Args[i]))
				{
					Parameter parameter2;
					if (e.Args[i].Contains("="))
					{
						string parameterName = e.Args[i].Substring(1, e.Args[i].IndexOf("=") - 1).Trim();
						string item = e.Args[i].Substring(e.Args[i].IndexOf("=") + 1).Trim();
						parameter2 = new Parameter(parameterName);
						parameter2.Arguments.Add(item);
						parameter2.ParameterName = parameterName;
					}
					else
					{
						parameter2 = new Parameter(e.Args[i].Substring(1, e.Args[i].Length - 1));
					}
					parameter = parameter2;
					string text = "";
					if (i + 1 < e.Args.Length)
					{
						if (!this.IsSwitch(e.Args[i + 1]))
						{
							text = e.Args[i + 1];
							i++;
						}
						else
						{
							text = "";
						}
					}
					if (text != "")
					{
						parameter2.Arguments.Add(text);
					}
					this.Parameters.Add(parameter2);
				}
				else if (parameter != null)
				{
					parameter.Arguments.Add(e.Args[i]);
				}
			}
			return this.Parameters.Count<Parameter>();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002624 File Offset: 0x00000824
		private bool IsSwitch(string pParam)
		{
			return !string.IsNullOrEmpty(pParam) && pParam.Length > 1 && (pParam[0] == '-' || pParam[0] == '/') && !char.IsDigit(pParam[1]);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002664 File Offset: 0x00000864
		public bool HasSwitch(string parameterName)
		{
			using (List<Parameter>.Enumerator enumerator = this.Parameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (string.Equals(enumerator.Current.ParameterName, parameterName, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000026C4 File Offset: 0x000008C4
		public string GetSafeArgument(string pSwitch, int iIdx, string pDefault)
		{
			string text = "";
			try
			{
				text = this.GetArgument(pSwitch, iIdx);
			}
			catch (Exception)
			{
			}
			if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(pDefault))
			{
				text = pDefault;
			}
			return text;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002708 File Offset: 0x00000908
		public string GetArgument(string parameterName, int iIdx)
		{
			if (this.HasSwitch(parameterName))
			{
				foreach (Parameter parameter in this.Parameters)
				{
					if (string.Equals(parameter.ParameterName, parameterName, StringComparison.OrdinalIgnoreCase) && parameter.Arguments.Count > iIdx)
					{
						return parameter.Arguments[iIdx];
					}
				}
			}
			return "";
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002790 File Offset: 0x00000990
		public int GetArgumentCount(string parameterName)
		{
			int result = -1;
			if (this.HasSwitch(parameterName))
			{
				foreach (Parameter parameter in this.Parameters)
				{
					if (string.Equals(parameter.ParameterName, parameterName, StringComparison.OrdinalIgnoreCase))
					{
						return parameter.Arguments.Count;
					}
				}
				return result;
			}
			return result;
		}

		// Token: 0x04000018 RID: 24
		private readonly List<Parameter> Parameters;
	}
}
