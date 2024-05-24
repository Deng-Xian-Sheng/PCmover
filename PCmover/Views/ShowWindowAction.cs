using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;

namespace PCmover.Views
{
	// Token: 0x02000008 RID: 8
	public class ShowWindowAction : TriggerAction<FrameworkElement>
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00002BD8 File Offset: 0x00000DD8
		protected override void Invoke(object parameter)
		{
			string text = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "QuickSteps.dll");
			if (File.Exists(text))
			{
				Window window = this.GetWindow(text, "QuickSteps");
				if (window != null)
				{
					try
					{
						if ((bool)window.GetType().GetProperty("IsOpen").GetValue(window, null))
						{
							window.GetType().GetMethod("Collapse").Invoke(window, null);
						}
						else
						{
							window.GetType().GetMethod("OpenWindow").Invoke(window, null);
						}
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002C84 File Offset: 0x00000E84
		private Window GetWindow(string assemblyName, string typeName)
		{
			if (this._Windows.ContainsKey(typeName))
			{
				return this._Windows[typeName];
			}
			Window result;
			try
			{
				Assembly assembly = Assembly.LoadFrom(assemblyName);
				Type type = assembly.GetTypes().FirstOrDefault((Type x) => string.Equals(x.Name, typeName, StringComparison.OrdinalIgnoreCase));
				Window window = assembly.CreateInstance(type.FullName) as Window;
				if (window == null)
				{
					throw new Exception("Window not found");
				}
				this._Windows.Add(typeName, window);
				result = window;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0400000D RID: 13
		private Dictionary<string, Window> _Windows = new Dictionary<string, Window>();
	}
}
