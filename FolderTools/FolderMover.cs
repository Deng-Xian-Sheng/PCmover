using System;
using System.IO;
using System.Security.AccessControl;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000005 RID: 5
	public class FolderMover
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000023 RID: 35 RVA: 0x0000257D File Offset: 0x0000077D
		public DirectoryInfo SourceDirectory { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002585 File Offset: 0x00000785
		public DirectoryInfo DestinationDirectory { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000258D File Offset: 0x0000078D
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002595 File Offset: 0x00000795
		public Exception LastException { get; private set; }

		// Token: 0x06000027 RID: 39 RVA: 0x0000259E File Offset: 0x0000079E
		public FolderMover(DirectoryInfo sourceDir, string destinationPath, LlTraceSource ts) : this(sourceDir, new DirectoryInfo(destinationPath), ts)
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000025AE File Offset: 0x000007AE
		public FolderMover(DirectoryInfo sourceDir, DirectoryInfo destDir, LlTraceSource ts)
		{
			this.SourceDirectory = sourceDir;
			this.DestinationDirectory = destDir;
			this._ts = ts;
			LlTraceSource ts2 = this._ts;
			if (ts2 == null)
			{
				return;
			}
			ts2.TraceInformation(string.Format("Setting up move from {0} to {1}", sourceDir, destDir));
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000025E8 File Offset: 0x000007E8
		public MoveResult Move()
		{
			this.LastException = null;
			MoveResult moveResult = MoveResult.Success;
			try
			{
				try
				{
					if (!this.Copy(this.SourceDirectory, this.DestinationDirectory))
					{
						LlTraceSource ts = this._ts;
						if (ts != null)
						{
							ts.TraceError("Error copying");
						}
						moveResult = MoveResult.ErrorCopying;
					}
				}
				catch (Exception ex)
				{
					LlTraceSource ts2 = this._ts;
					if (ts2 != null)
					{
						ts2.TraceException(ex, "Move");
					}
					this.LastException = ex;
					moveResult = MoveResult.ErrorCopying;
				}
				if (moveResult != MoveResult.Success)
				{
					LlTraceSource ts3 = this._ts;
					if (ts3 != null)
					{
						ts3.TraceCaller(moveResult.ToString(), "Move");
					}
					return moveResult;
				}
			}
			catch (Exception ex2)
			{
				LlTraceSource ts4 = this._ts;
				if (ts4 != null)
				{
					ts4.TraceException(ex2, "Move");
				}
				this.LastException = ex2;
				moveResult = MoveResult.UnexpectedException;
			}
			LlTraceSource ts5 = this._ts;
			if (ts5 != null)
			{
				ts5.TraceCaller(moveResult.ToString(), "Move");
			}
			return moveResult;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026E0 File Offset: 0x000008E0
		public bool DeleteSource()
		{
			return FolderMover.DeleteDirectory(this.SourceDirectory);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000026ED File Offset: 0x000008ED
		public bool DeleteDestination()
		{
			return FolderMover.DeleteDirectory(this.DestinationDirectory);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000026FA File Offset: 0x000008FA
		public static bool DeleteDirectory(DirectoryInfo dir)
		{
			return dir.Exists && FolderMover.DeleteIndividually(dir);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000270C File Offset: 0x0000090C
		public static bool DeleteIndividually(DirectoryInfo dir)
		{
			if (dir.Attributes.HasFlag(FileAttributes.ReparsePoint))
			{
				JunctionPoint.Delete(dir.FullName);
			}
			else
			{
				foreach (FileInfo fileInfo in dir.GetFiles())
				{
					fileInfo.Attributes = FileAttributes.Normal;
					fileInfo.Delete();
				}
				dir.Attributes = FileAttributes.Normal;
				dir.Delete(false);
			}
			return true;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002780 File Offset: 0x00000980
		private void SetAttributesNormal(DirectoryInfo dir)
		{
			if (dir == null || !dir.Exists)
			{
				return;
			}
			dir.Attributes = FileAttributes.Normal;
			foreach (DirectoryInfo attributesNormal in dir.GetDirectories())
			{
				this.SetAttributesNormal(attributesNormal);
			}
			FileInfo[] files = dir.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				files[i].Attributes = FileAttributes.Normal;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000027E8 File Offset: 0x000009E8
		private bool Copy(DirectoryInfo source, DirectoryInfo dest)
		{
			LlTraceSource ts = this._ts;
			if (ts != null)
			{
				ts.TraceInformation("Copy from " + source.FullName + " to " + dest.FullName);
			}
			if (!source.Exists)
			{
				LlTraceSource ts2 = this._ts;
				if (ts2 != null)
				{
					ts2.TraceInformation(source.FullName + " does not exist, so nothing to copy");
				}
				return false;
			}
			if (!dest.Exists)
			{
				dest.Create();
			}
			DirectorySecurity accessControl = source.GetAccessControl();
			accessControl.SetAccessRuleProtection(false, false);
			dest.SetAccessControl(accessControl);
			if (source.Attributes.HasFlag(FileAttributes.ReparsePoint))
			{
				LlTraceSource ts3 = this._ts;
				if (ts3 != null)
				{
					ts3.TraceInformation(string.Format("{0} has ReparsePoint set ({1}), so copying Junction Point", source.FullName, source.Attributes));
				}
				string target = JunctionPoint.GetTarget(source.FullName);
				if (string.IsNullOrWhiteSpace(target))
				{
					LlTraceSource ts4 = this._ts;
					if (ts4 != null)
					{
						ts4.TraceError("Not a valid junction point, so failing");
					}
					return false;
				}
				JunctionPoint.Create(dest.FullName, target, true);
			}
			else
			{
				foreach (FileInfo fileInfo in source.GetFiles())
				{
					string text = Path.Combine(dest.FullName, fileInfo.Name);
					LlTraceSource ts5 = this._ts;
					if (ts5 != null)
					{
						ts5.TraceVerbose("Copying file " + fileInfo.FullName + " to " + text);
					}
					FileInfo fileInfo2 = fileInfo.CopyTo(text, true);
					FileSecurity accessControl2 = fileInfo.GetAccessControl();
					accessControl2.SetAccessRuleProtection(false, false);
					fileInfo2.SetAccessControl(accessControl2);
				}
			}
			return true;
		}

		// Token: 0x04000016 RID: 22
		private readonly LlTraceSource _ts;
	}
}
