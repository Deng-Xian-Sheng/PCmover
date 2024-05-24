using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000B2 RID: 178
	public class ProgressDialogController
	{
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x00025BB0 File Offset: 0x00023DB0
		private ProgressDialog WrappedDialog { get; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x00025BB8 File Offset: 0x00023DB8
		private Func<Task> CloseCallback { get; }

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060009B2 RID: 2482 RVA: 0x00025BC0 File Offset: 0x00023DC0
		// (remove) Token: 0x060009B3 RID: 2483 RVA: 0x00025BF8 File Offset: 0x00023DF8
		public event EventHandler Closed;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060009B4 RID: 2484 RVA: 0x00025C30 File Offset: 0x00023E30
		// (remove) Token: 0x060009B5 RID: 2485 RVA: 0x00025C68 File Offset: 0x00023E68
		public event EventHandler Canceled;

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x00025C9D File Offset: 0x00023E9D
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x00025CA5 File Offset: 0x00023EA5
		public bool IsCanceled { get; private set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x00025CAE File Offset: 0x00023EAE
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x00025CB6 File Offset: 0x00023EB6
		public bool IsOpen { get; private set; }

		// Token: 0x060009BA RID: 2490 RVA: 0x00025CC0 File Offset: 0x00023EC0
		internal ProgressDialogController(ProgressDialog dialog, Func<Task> closeCallBack)
		{
			this.WrappedDialog = dialog;
			this.CloseCallback = closeCallBack;
			this.IsOpen = dialog.IsVisible;
			this.WrappedDialog.Invoke(delegate()
			{
				this.WrappedDialog.PART_NegativeButton.Click += this.PART_NegativeButton_Click;
			});
			dialog.CancellationToken.Register(delegate()
			{
				this.PART_NegativeButton_Click(null, new RoutedEventArgs());
			});
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00025D20 File Offset: 0x00023F20
		private void PART_NegativeButton_Click(object sender, RoutedEventArgs e)
		{
			Action invokeAction = delegate()
			{
				this.IsCanceled = true;
				EventHandler canceled = this.Canceled;
				if (canceled != null)
				{
					canceled(this, EventArgs.Empty);
				}
				this.WrappedDialog.PART_NegativeButton.IsEnabled = false;
			};
			this.WrappedDialog.Invoke(invokeAction);
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00025D46 File Offset: 0x00023F46
		public void SetIndeterminate()
		{
			this.WrappedDialog.Invoke(delegate()
			{
				this.WrappedDialog.SetIndeterminate();
			});
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00025D60 File Offset: 0x00023F60
		public void SetCancelable(bool value)
		{
			this.WrappedDialog.Invoke(() => this.WrappedDialog.IsCancelable = value);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00025D9C File Offset: 0x00023F9C
		public void SetProgress(double value)
		{
			Action invokeAction = delegate()
			{
				if (value < this.WrappedDialog.Minimum || value > this.WrappedDialog.Maximum)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.WrappedDialog.ProgressValue = value;
			};
			this.WrappedDialog.Invoke(invokeAction);
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x00025DD4 File Offset: 0x00023FD4
		// (set) Token: 0x060009C0 RID: 2496 RVA: 0x00025DF0 File Offset: 0x00023FF0
		public double Minimum
		{
			get
			{
				return this.WrappedDialog.Invoke(() => this.WrappedDialog.Minimum);
			}
			set
			{
				this.WrappedDialog.Invoke(() => this.WrappedDialog.Minimum = value);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x00025E29 File Offset: 0x00024029
		// (set) Token: 0x060009C2 RID: 2498 RVA: 0x00025E44 File Offset: 0x00024044
		public double Maximum
		{
			get
			{
				return this.WrappedDialog.Invoke(() => this.WrappedDialog.Maximum);
			}
			set
			{
				this.WrappedDialog.Invoke(() => this.WrappedDialog.Maximum = value);
			}
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00025E80 File Offset: 0x00024080
		public void SetMessage(string message)
		{
			this.WrappedDialog.Invoke(() => this.WrappedDialog.Message = message);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00025EBC File Offset: 0x000240BC
		public void SetTitle(string title)
		{
			this.WrappedDialog.Invoke(() => this.WrappedDialog.Title = title);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00025EF8 File Offset: 0x000240F8
		public void SetProgressBarForegroundBrush(Brush brush)
		{
			this.WrappedDialog.Invoke(() => this.WrappedDialog.ProgressBarForeground = brush);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00025F34 File Offset: 0x00024134
		public Task CloseAsync()
		{
			Action invokeAction = delegate()
			{
				if (!this.WrappedDialog.IsVisible)
				{
					throw new InvalidOperationException("Dialog isn't visible to close");
				}
				this.WrappedDialog.Dispatcher.VerifyAccess();
				this.WrappedDialog.PART_NegativeButton.Click -= this.PART_NegativeButton_Click;
			};
			this.WrappedDialog.Invoke(invokeAction);
			return this.CloseCallback().ContinueWith(delegate(Task _)
			{
				this.WrappedDialog.Invoke(delegate()
				{
					this.IsOpen = false;
					EventHandler closed = this.Closed;
					if (closed == null)
					{
						return;
					}
					closed(this, EventArgs.Empty);
				});
			});
		}
	}
}
