using System;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService
{
	public partial class MyService : ServiceBase
	{
		private Timer _timer;

		public MyService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			_timer = new Timer();
			_timer.Interval = 1000;
			_timer.Elapsed += Handle_Timer_Elapsed;
			_timer.AutoReset = true;
			_timer.Enabled = true;
			_timer.Start();
		}

		private void Handle_Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			LogHelper.WriteLog(DateTime.Now.ToString());
		}

		protected override void OnStop()
		{
		}
	}
}
