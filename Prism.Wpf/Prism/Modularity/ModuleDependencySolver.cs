using System;
using System.Collections.Generic;
using System.Globalization;
using Prism.Common;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000060 RID: 96
	public class ModuleDependencySolver
	{
		// Token: 0x060002BE RID: 702 RVA: 0x00007801 File Offset: 0x00005A01
		public void AddModule(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeNullOrEmpty, new object[]
				{
					"name"
				}));
			}
			this.AddToDependencyMatrix(name);
			this.AddToKnownModules(name);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000783C File Offset: 0x00005A3C
		public void AddDependency(string dependingModule, string dependentModule)
		{
			if (string.IsNullOrEmpty(dependingModule))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeNullOrEmpty, new object[]
				{
					"dependingModule"
				}));
			}
			if (string.IsNullOrEmpty(dependentModule))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeNullOrEmpty, new object[]
				{
					"dependentModule"
				}));
			}
			if (!this.knownModules.Contains(dependingModule))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.DependencyForUnknownModule, new object[]
				{
					dependingModule
				}));
			}
			this.AddToDependencyMatrix(dependentModule);
			this.dependencyMatrix.Add(dependentModule, dependingModule);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000078E0 File Offset: 0x00005AE0
		private void AddToDependencyMatrix(string module)
		{
			if (!this.dependencyMatrix.ContainsKey(module))
			{
				this.dependencyMatrix.Add(module);
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000078FC File Offset: 0x00005AFC
		private void AddToKnownModules(string module)
		{
			if (!this.knownModules.Contains(module))
			{
				this.knownModules.Add(module);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00007918 File Offset: 0x00005B18
		public string[] Solve()
		{
			List<string> list = new List<string>();
			while (list.Count < this.dependencyMatrix.Count)
			{
				List<string> list2 = this.FindLeaves(list);
				if (list2.Count == 0 && list.Count < this.dependencyMatrix.Count)
				{
					throw new CyclicDependencyFoundException(Resources.CyclicDependencyFound);
				}
				list.AddRange(list2);
			}
			list.Reverse();
			if (list.Count > this.knownModules.Count)
			{
				string text = this.FindMissingModules(list);
				throw new ModularityException(text, string.Format(CultureInfo.CurrentCulture, Resources.DependencyOnMissingModule, new object[]
				{
					text
				}));
			}
			return list.ToArray();
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000079BC File Offset: 0x00005BBC
		private string FindMissingModules(List<string> skip)
		{
			string text = "";
			foreach (string text2 in skip)
			{
				if (!this.knownModules.Contains(text2))
				{
					text += ", ";
					text += text2;
				}
			}
			return text.Substring(2);
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00007A34 File Offset: 0x00005C34
		public int ModuleCount
		{
			get
			{
				return this.dependencyMatrix.Count;
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00007A44 File Offset: 0x00005C44
		private List<string> FindLeaves(List<string> skip)
		{
			List<string> list = new List<string>();
			foreach (string text in this.dependencyMatrix.Keys)
			{
				if (!skip.Contains(text))
				{
					int num = 0;
					foreach (string item in this.dependencyMatrix[text])
					{
						if (!skip.Contains(item))
						{
							num++;
						}
					}
					if (num == 0)
					{
						list.Add(text);
					}
				}
			}
			return list;
		}

		// Token: 0x0400007A RID: 122
		private readonly ListDictionary<string, string> dependencyMatrix = new ListDictionary<string, string>();

		// Token: 0x0400007B RID: 123
		private readonly List<string> knownModules = new List<string>();
	}
}
