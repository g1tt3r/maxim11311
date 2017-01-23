using System;
using Gtk;


namespace maxim_11311
{
	public partial class MainWindow: Gtk.Window
	{
		private MAXIM11311 mxm;

		public MainWindow () : base (Gtk.WindowType.Toplevel)
		{
			Build ();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		protected void OnTbnConnectToggled (object sender, EventArgs e)
		{
			//throw new NotImplementedException ();
			if ( tbnConnect.Active )
			{
				mxm = new MAXIM11311 ("/dev/ttyACM0", 115200);
				string ss = mxm.SendCommandWithAnswer ("?max 0");
				LogLine ("connected: " + ss);

			} 
			else 
			{
				mxm.Close ();
				LogLine ("disconnected");
			}

		}

		protected void OnTbnQuitClicked (object sender, EventArgs e)
		{
			mxm.Close ();
			Application.Quit ();
			//a.RetVal = true;
		}

		protected void LogLine( string msg ) {
			//txvLog.Buffer.Text = msg;
			msg+= "\n\r";
			TextIter mIter = txvLog.Buffer.EndIter;
			txvLog.Buffer.Insert(ref mIter, msg);
			txvLog.ScrollToIter(txvLog.Buffer.EndIter, 0, false, 0, 0);

		}

		protected void OnBtnReadAllClicked (object sender, EventArgs e)
		{
			//throw new NotImplementedException ();
			string ss = "";

			for (int ii = 0; ii < 63; ii++) {
				ss = mxm.SendCommandWithAnswer ("?max " + ii.ToString());
				LogLine ( ss );	
			}
				
		}

		protected void OnBtnClearClicked (object sender, EventArgs e)
		{
			txvLog.Buffer.Clear ();
		}

		protected void OnSpbReadRegValueChanged (object sender, EventArgs e)
		{
			int ii = mxm.ReadRegister( spbReadReg.ValueAsInt );
			lblReadRes.Text = ii.ToString ();

		}

		protected void OnBtnReadRegClicked (object sender, EventArgs e)
		{
			int ii = mxm.ReadRegister (spbReadReg.ValueAsInt );
			lblReadRes.Text = ii.ToString ();

		}

		protected void OnBtnWriteRegClicked (object sender, EventArgs e)
		{
			//throw new NotImplementedException ();
			mxm.WriteRegister( spbWriteReg.ValueAsInt, spbWriteVal.ValueAsInt );
		
		}

		protected void OnRbnAdcSpeedActivated (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}
	}
}
