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
			int portnr = cmbPortNumber.Active + 1;
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

			// Label lbl = this.Child.Find ("lblPM1", true).FirstOrDefault () as Label;

			//Label lbl = Utilities.parse_widget_tree( this, "lblPM1") as Label;

			mxm.ADCMode = 3;
			if( (portnr > 0) && (portnr < 13))  
			{
				UpdatePort (portnr, portcfg.PortMode);
				/*
				lbl = Utilities.parse_widget( tblPortValues, "lblPM"+portnr.ToString()) as Label;
				if (lbl != null) lbl.LabelProp = "P"+portnr.ToString();
				lbl = Utilities.parse_widget( tblPortValues, "lblPF"+portnr.ToString()) as Label;
				if (lbl != null) lbl.LabelProp = mxm.PortCfgToString (portcfg.PortMode);

				dd = mxm.ReadPortValue (portnr);
				if (!Double.IsNaN (dd)) {
					spb = Utilities.parse_widget( tblPortValues, "spbPV"+portnr.ToString()) as SpinButton;
					if (spb != null)
						spb.Value = dd;
					
					
				}*/
			}
			else 
			{
				Utilities.MsgBox ("Failure at port number: " + portnr.ToString());
			}
		}


		protected void OnCmbPortModeChanged (object sender, EventArgs e)
		{
			
			if( mxm == null ) 
				return;
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
			int portnr = cmbPortNumber.Active + 1;
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

		protected void UpdatePort (int portnr, int portmode )
		{
			Label lbl = null;
			SpinButton spb = null;
			double dd = Double.NaN;

			lbl = Utilities.parse_widget( tblPortValues, "lblPM"+portnr.ToString()) as Label;
			if (lbl != null) lbl.LabelProp = "P"+portnr.ToString();
			lbl = Utilities.parse_widget( tblPortValues, "lblPF"+portnr.ToString()) as Label;
			if (lbl != null) lbl.LabelProp = mxm.PortCfgToString (portmode);

			dd = mxm.ReadPortValue (portnr);
			spb = Utilities.parse_widget( tblPortValues, "spbPV"+portnr.ToString()) as SpinButton;
			if (spb != null) {
				switch( portmode ) {
				case MAXIM11311.PINMODE_0_HIGHZ :
					spb.Value = 0;
					spb.Sensitive = false;
					break;
					
				case MAXIM11311.PINMODE_1_GPI:
					spb.Digits = 0;
					spb.Adjustment.Lower = 0;
					spb.Adjustment.Upper = 1;
					if (!Double.IsNaN (dd))
						spb.Value = dd;
					spb.Sensitive = false;
					break;

				case MAXIM11311.PINMODE_3_GPO:
					spb.Adjustment.Lower = 0;
					spb.Adjustment.Upper = 1;
					spb.Sensitive = true;
					break;

				case MAXIM11311.PINMODE_5_DAC :
				case MAXIM11311.PINMODE_6_DACwADC :
					spb.Adjustment.Lower = -11;
					spb.Adjustment.Upper = 11;
					spb.Sensitive = true;
					break;

				case MAXIM11311.PINMODE_7_ADC :
				case MAXIM11311.PINMODE_8_DIFFADCP :
				case MAXIM11311.PINMODE_9_DIFFADCN :
					spb.Digits = 3;
					spb.Adjustment.Lower = -11;
					spb.Adjustment.Upper =  11;
					if (!Double.IsNaN (dd)) 
						spb.Value = dd;
					spb.Sensitive = false;
					break;

				default:
					spb.Sensitive = false;
					break;
				}
			}
		}

		protected void OnBtnPortConfUpdateClicked (object sender, EventArgs e)
		{
			if( mxm == null ) 
				return;
			MAXIM11311.TPortConfig portcfg = new MAXIM11311.TPortConfig( 0 );

			for( int portnr = 1; portnr<13; portnr++) {
				if (mxm.ReadPortConfig (portnr, ref portcfg)) { 
					if( portnr-1 == cmbPortNumber.Active ) 
					{
						cmbPortMode.Active = portcfg.PortMode;
						cmbPortConfNSamples.Active = portcfg.NumSamples;
						cmbPortConfAssoc.Active = portcfg.PortAssoc;
						cbxPortConfInvert.Active = portcfg.Invert_AVR != 0;
						cmbPortRange.Active = portcfg.RangeMode;
					}

					UpdatePort (portnr, portcfg.PortMode );
				}
			}
		}

	

		protected void OnRbnAdcSpeed200GroupChanged (object sender, EventArgs e)
		{
			mxm.ADCSpeed = 200;
		}

		protected void OnRbnAdcSpeed250GroupChanged (object sender, EventArgs e)
		{
			mxm.ADCSpeed = 250;
		}

		protected void OnRbnAdcSpeed333GroupChanged (object sender, EventArgs e)
		{
			mxm.ADCSpeed = 333;
		}

		protected void OnRbnAdcSpeed400GroupChanged (object sender, EventArgs e)
		{
			mxm.ADCSpeed = 400;
		}


		protected void OnRbnDACRefExternalToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.DACReference = 0;
		}
		protected void OnRbnDACRefInternalToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
			   	mxm.DACReference = 1;
		}



		protected void OnRbnAdcIdleModeToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.ADCMode = 0;
		}
		protected void OnRbnAdcSingleSweepToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.ADCMode = 1;
		}
		protected void OnRbnAdcSingleConvToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.ADCMode = 2;
		}
		protected void OnRbnAdcContSweepToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.ADCMode = 3;
		}


		protected void OnRbnDACModeSeqToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.DACMode = 0;
		}
		protected void OnRbnDACModeImmedToggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.DACMode = 1;
		}
		protected void OnRbnDACModeDAT1Toggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.DACMode = 2;
		}

		protected void OnRbnDACModeDAT2Toggled (object sender, EventArgs e)
		{
			if( (sender as RadioButton).Active )
				mxm.DACMode = 3;
		}

		protected void OnSpbPV1ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 1, spbPV1.Value );
		}
	
		protected void OnSpbPV2ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 2, spbPV2.Value );
		}

		protected void OnSpbPV3ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 3, spbPV3.Value );
		}

		protected void OnSpbPV4ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 4, spbPV4.Value );
		}

		protected void OnSpbPV5ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 5, spbPV5.Value );
		}

		protected void OnSpbPV6ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 6, spbPV6.Value );
		}

		protected void OnSpbPV7ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 7, spbPV7.Value );
		}

		protected void OnSpbPV8ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 8, spbPV8.Value );
		}

		protected void OnSpbPV9ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 9, spbPV9.Value );
		}

		protected void OnSpbPV10ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 10, spbPV10.Value );
		}

		protected void OnSpbPV11ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue( 11, spbPV11.Value );
		}

		protected void OnSpbPV12ValueChanged (object sender, EventArgs e)
		{
			mxm.WritePortValue(12, spbPV12.Value );
		}
	}
}
