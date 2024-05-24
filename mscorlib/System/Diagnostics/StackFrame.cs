using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System.Diagnostics
{
	// Token: 0x020003F8 RID: 1016
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	[Serializable]
	public class StackFrame
	{
		// Token: 0x06003379 RID: 13177 RVA: 0x000C5F7F File Offset: 0x000C417F
		internal void InitMembers()
		{
			this.method = null;
			this.offset = -1;
			this.ILOffset = -1;
			this.strFileName = null;
			this.iLineNumber = 0;
			this.iColumnNumber = 0;
			this.fIsLastFrameFromForeignExceptionStackTrace = false;
		}

		// Token: 0x0600337A RID: 13178 RVA: 0x000C5FB2 File Offset: 0x000C41B2
		public StackFrame()
		{
			this.InitMembers();
			this.BuildStackFrame(0, false);
		}

		// Token: 0x0600337B RID: 13179 RVA: 0x000C5FC8 File Offset: 0x000C41C8
		public StackFrame(bool fNeedFileInfo)
		{
			this.InitMembers();
			this.BuildStackFrame(0, fNeedFileInfo);
		}

		// Token: 0x0600337C RID: 13180 RVA: 0x000C5FDE File Offset: 0x000C41DE
		public StackFrame(int skipFrames)
		{
			this.InitMembers();
			this.BuildStackFrame(skipFrames, false);
		}

		// Token: 0x0600337D RID: 13181 RVA: 0x000C5FF4 File Offset: 0x000C41F4
		public StackFrame(int skipFrames, bool fNeedFileInfo)
		{
			this.InitMembers();
			this.BuildStackFrame(skipFrames, fNeedFileInfo);
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x000C600A File Offset: 0x000C420A
		internal StackFrame(bool DummyFlag1, bool DummyFlag2)
		{
			this.InitMembers();
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x000C6018 File Offset: 0x000C4218
		public StackFrame(string fileName, int lineNumber)
		{
			this.InitMembers();
			this.BuildStackFrame(0, false);
			this.strFileName = fileName;
			this.iLineNumber = lineNumber;
			this.iColumnNumber = 0;
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x000C6043 File Offset: 0x000C4243
		public StackFrame(string fileName, int lineNumber, int colNumber)
		{
			this.InitMembers();
			this.BuildStackFrame(0, false);
			this.strFileName = fileName;
			this.iLineNumber = lineNumber;
			this.iColumnNumber = colNumber;
		}

		// Token: 0x06003381 RID: 13185 RVA: 0x000C606E File Offset: 0x000C426E
		internal virtual void SetMethodBase(MethodBase mb)
		{
			this.method = mb;
		}

		// Token: 0x06003382 RID: 13186 RVA: 0x000C6077 File Offset: 0x000C4277
		internal virtual void SetOffset(int iOffset)
		{
			this.offset = iOffset;
		}

		// Token: 0x06003383 RID: 13187 RVA: 0x000C6080 File Offset: 0x000C4280
		internal virtual void SetILOffset(int iOffset)
		{
			this.ILOffset = iOffset;
		}

		// Token: 0x06003384 RID: 13188 RVA: 0x000C6089 File Offset: 0x000C4289
		internal virtual void SetFileName(string strFName)
		{
			this.strFileName = strFName;
		}

		// Token: 0x06003385 RID: 13189 RVA: 0x000C6092 File Offset: 0x000C4292
		internal virtual void SetLineNumber(int iLine)
		{
			this.iLineNumber = iLine;
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x000C609B File Offset: 0x000C429B
		internal virtual void SetColumnNumber(int iCol)
		{
			this.iColumnNumber = iCol;
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x000C60A4 File Offset: 0x000C42A4
		internal virtual void SetIsLastFrameFromForeignExceptionStackTrace(bool fIsLastFrame)
		{
			this.fIsLastFrameFromForeignExceptionStackTrace = fIsLastFrame;
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x000C60AD File Offset: 0x000C42AD
		internal virtual bool GetIsLastFrameFromForeignExceptionStackTrace()
		{
			return this.fIsLastFrameFromForeignExceptionStackTrace;
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x000C60B5 File Offset: 0x000C42B5
		public virtual MethodBase GetMethod()
		{
			return this.method;
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x000C60BD File Offset: 0x000C42BD
		public virtual int GetNativeOffset()
		{
			return this.offset;
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x000C60C5 File Offset: 0x000C42C5
		public virtual int GetILOffset()
		{
			return this.ILOffset;
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x000C60D0 File Offset: 0x000C42D0
		[SecuritySafeCritical]
		public virtual string GetFileName()
		{
			if (this.strFileName != null)
			{
				new FileIOPermission(PermissionState.None)
				{
					AllFiles = FileIOPermissionAccess.PathDiscovery
				}.Demand();
			}
			return this.strFileName;
		}

		// Token: 0x0600338D RID: 13197 RVA: 0x000C60FF File Offset: 0x000C42FF
		public virtual int GetFileLineNumber()
		{
			return this.iLineNumber;
		}

		// Token: 0x0600338E RID: 13198 RVA: 0x000C6107 File Offset: 0x000C4307
		public virtual int GetFileColumnNumber()
		{
			return this.iColumnNumber;
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x000C6110 File Offset: 0x000C4310
		[SecuritySafeCritical]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			if (this.method != null)
			{
				stringBuilder.Append(this.method.Name);
				if (this.method is MethodInfo && ((MethodInfo)this.method).IsGenericMethod)
				{
					Type[] genericArguments = ((MethodInfo)this.method).GetGenericArguments();
					stringBuilder.Append("<");
					int i = 0;
					bool flag = true;
					while (i < genericArguments.Length)
					{
						if (!flag)
						{
							stringBuilder.Append(",");
						}
						else
						{
							flag = false;
						}
						stringBuilder.Append(genericArguments[i].Name);
						i++;
					}
					stringBuilder.Append(">");
				}
				stringBuilder.Append(" at offset ");
				if (this.offset == -1)
				{
					stringBuilder.Append("<offset unknown>");
				}
				else
				{
					stringBuilder.Append(this.offset);
				}
				stringBuilder.Append(" in file:line:column ");
				bool flag2 = this.strFileName != null;
				if (flag2)
				{
					try
					{
						new FileIOPermission(PermissionState.None)
						{
							AllFiles = FileIOPermissionAccess.PathDiscovery
						}.Demand();
					}
					catch (SecurityException)
					{
						flag2 = false;
					}
				}
				if (!flag2)
				{
					stringBuilder.Append("<filename unknown>");
				}
				else
				{
					stringBuilder.Append(this.strFileName);
				}
				stringBuilder.Append(":");
				stringBuilder.Append(this.iLineNumber);
				stringBuilder.Append(":");
				stringBuilder.Append(this.iColumnNumber);
			}
			else
			{
				stringBuilder.Append("<null>");
			}
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x000C62B0 File Offset: 0x000C44B0
		private void BuildStackFrame(int skipFrames, bool fNeedFileInfo)
		{
			using (StackFrameHelper stackFrameHelper = new StackFrameHelper(null))
			{
				stackFrameHelper.InitializeSourceInfo(0, fNeedFileInfo, null);
				int numberOfFrames = stackFrameHelper.GetNumberOfFrames();
				skipFrames += StackTrace.CalculateFramesToSkip(stackFrameHelper, numberOfFrames);
				if (numberOfFrames - skipFrames > 0)
				{
					this.method = stackFrameHelper.GetMethodBase(skipFrames);
					this.offset = stackFrameHelper.GetOffset(skipFrames);
					this.ILOffset = stackFrameHelper.GetILOffset(skipFrames);
					if (fNeedFileInfo)
					{
						this.strFileName = stackFrameHelper.GetFilename(skipFrames);
						this.iLineNumber = stackFrameHelper.GetLineNumber(skipFrames);
						this.iColumnNumber = stackFrameHelper.GetColumnNumber(skipFrames);
					}
				}
			}
		}

		// Token: 0x040016DE RID: 5854
		private MethodBase method;

		// Token: 0x040016DF RID: 5855
		private int offset;

		// Token: 0x040016E0 RID: 5856
		private int ILOffset;

		// Token: 0x040016E1 RID: 5857
		private string strFileName;

		// Token: 0x040016E2 RID: 5858
		private int iLineNumber;

		// Token: 0x040016E3 RID: 5859
		private int iColumnNumber;

		// Token: 0x040016E4 RID: 5860
		[OptionalField]
		private bool fIsLastFrameFromForeignExceptionStackTrace;

		// Token: 0x040016E5 RID: 5861
		public const int OFFSET_UNKNOWN = -1;
	}
}
