using System;
using Gtk;



namespace maxim_11311
{
	public partial class MainWindow: Gtk.Window
	{
		private MAXIM11311 mxm = null;
		//TPortConfig PortCfg;

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
				if (mxm != null) {
					mxm.Close ();
					mxm = null;
				}
				mxm = new MAXIM11311 ("/dev/ttyACM0", 115200);
				string ss = mxm.SendCommandWithAnswer ("?max 0");
				LogLine ("connected: " + ss);

			} 
			else 
			{
				if( mxm != null )
					mxm.Close ();
				LogLine ("disconnected");
			}

		}

		protected void OnTbnQuitClicked (object sender, EventArgs e)
		{
			if( mxm != null )
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

		protected void OnBtnPortConfApplyClicked (object sender, EventArgs e)
		{
			if( mxm == null ) 
				return;
			int portnr = cmbPortNumber.Active;
			MAXIM11311.TPortConfig portcfg = new MAXIM11311.TPortConfig( cmbPortMode.Active );
			portcfg.PortMode   = cmbPortMode.Active;
			portcfg.NumSamples = cmbPortConfNSamples.Active;
			portcfg.PortAssoc  = cmbPortConfAssoc.Active;
			portcfg.Invert_AVR = cbxPortConfInvert.Active ? 1 : 0;
			portcfg.RangeMode  = cmbPortRange.Active;


			if (mxm.WritePortConfig (portnr, portcfg)) { 
				cmbPortMode.Active = portcfg.PortMode;
				cmbPortConfNSamples.Active = portcfg.NumSamples;
				cmbPortConfAssoc.Active = portcfg.PortAssoc;
				cbxPortConfInvert.Active = portcfg.Invert_AVR != 0;
				cmbPortRange.Active = portcfg.RangeMode;
			}

		}

		protected void OnCmbPortModeChanged (object sender, EventArgs e)
		{
			//throw new NotImplementedException ();
			int portmode = cmbPortMode.Active;
			switch (portmode) 
			{
				case MAXIM11311.PINMODE_0_HIGHZ :
				case MAXIM11311.PINMODE_1_GPI :
			    case MAXIM11311.PINMODE_2_LVTR :
				case MAXIM11311.PINMODE_3_GPO :
				case MAXIM11311.PINMODE_12_AIAO:
					cmbPortRange.Sensitive = false;
					cbxPortConfInvert.Sensitive = false;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = false;
					break;
					
				case MAXIM11311.PINMODE_4_UNILVTR:
					cmbPortRange.Sensitive = false;
					cbxPortConfInvert.Sensitive = true;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = true;
					break;

			    case MAXIM11311.PINMODE_5_DAC:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = false;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = false;
					break;

		     	case MAXIM11311.PINMODE_6_DACwADC:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = true;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = false;
					break;

			    case MAXIM11311.PINMODE_7_ADC:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = false;
					cbxPortConfInvert.Active = false;
					cmbPortConfNSamples.Sensitive = true;
					cmbPortConfAssoc.Sensitive = false;
					break;

			    case MAXIM11311.PINMODE_8_DIFFADCP:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = false;
					cbxPortConfInvert.Active = false;
					cmbPortConfNSamples.Sensitive = true;
					cmbPortConfAssoc.Sensitive = true;
					break;

		    	case MAXIM11311.PINMODE_9_DIFFADCN:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = false;
					cbxPortConfInvert.Active = false;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = false;
					break;

			 	case MAXIM11311.PINMODE_10_DACNAIN:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = false;
					cbxPortConfInvert.Active = false;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = true;
					break;

			    case MAXIM11311.PINMODE_11_ANSW:
					cmbPortRange.Sensitive = true;
					cbxPortConfInvert.Sensitive = true;
					cmbPortConfNSamples.Sensitive = false;
					cmbPortConfAssoc.Sensitive = true;
					break;	
			}
		}

		protected void OnCmbPortNumberChanged (object sender, EventArgs e)
		{
			//throw new NotImplementedException ();
			if( mxm == null ) 
				return;
			int portnr = cmbPortNumber.Active;
			MAXIM11311.TPortConfig portcfg = new MAXIM11311.TPortConfig( 0 );

			if (mxm.ReadPortConfig (portnr, ref portcfg)) { 
				cmbPortMode.Active = portcfg.PortMode;
				cmbPortConfNSamples.Active = portcfg.NumSamples;
				cmbPortConfAssoc.Active = portcfg.PortAssoc;
				cbxPortConfInvert.Active = portcfg.Invert_AVR != 0;
				cmbPortRange.Active = portcfg.RangeMode;
			}
			//new MAXIM11311 ("/dev/ttyACM0", 115200);

		}
	}
}
