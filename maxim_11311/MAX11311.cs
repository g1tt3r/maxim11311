using System;

using System.IO.Ports;


namespace maxim_11311
{



	public partial class MAXIM11311
	{
		


		private SerialPort mxSerial;

		private TPortConfig[] mxPortConfig;

		public MAXIM11311 (string port, int baudrate)
		{
			try
			{
				if (mxSerial != null)
				if (mxSerial.IsOpen)
					mxSerial.Close();
				mxSerial = new SerialPort( port, baudrate );
				mxSerial.Open();
				mxSerial.ReadTimeout = 40000;

				// Download configuration
				mxPortConfig = new TPortConfig[12];

				if (mxSerial != null)
				if (mxSerial.IsOpen)
				{
					for( int ii= 1; ii <13; ii++ )
					{
						ReadPortConfig( ii, ref mxPortConfig[ii-1] );
					}
				}

			}
			catch ( Exception msg )
			{
				// Exception : ;
				Utilities.MsgBox( msg.ToString() );
			}
		}

		~MAXIM11311()  
		{  
			try  
			{  
				if (mxSerial != null)
				if (mxSerial.IsOpen)
					mxSerial.Close();
			}  
			finally  
			{  
				// base.Finalize();  
			}  
		}

		public int ADCMode
		{
			get {
				return GetADCMode ();
			}
			set {
				SetADCMode (value);
			}
		}

		public int ADCSpeed
		{
			get {
				return GetADCSpeed ();
			}
			set {
				SetADCSpeed (value);
			}
		}

		/*
		public double AnalogIn[ int indx ]
		{
			get {
				return GetAnalogIn[ indx ];
			}
		}*/

		public int DACMode
		{
			get {
				return GetDACMode ();
			}
			set {
				SetDACMode (value);
			}
		}

		public int DACReference
		{
			get {
				return GetDACReference ();
			}
			set {
				SetDACReference (value);
			}
		}



		public void Close() {
			if (mxSerial != null)
			if (mxSerial.IsOpen)
				mxSerial.Close();
			mxSerial = null;
		}

		private string ReadSerialData()
		{
			byte tmpByte;
			string rxString = "";

			tmpByte = (byte) mxSerial.ReadByte();

			while (tmpByte != 10) {
				rxString += ((char) tmpByte);
				tmpByte = (byte) mxSerial.ReadByte();
			}
			//rxString += "#";
			tmpByte = 0;
			return rxString;
		}

		private bool SendSerialData(string Data)
		{
			mxSerial.Write(Data);
			return true;
		}

		private	int AssociateToPortNum( int assoc )
		{
			int[] Ports = new int[]{ -1, -1, 0, 1, 2, 3, 4, 5, -1, -1, -1, 6, 7, 8, 9, 10, 11 };
			if (assoc < 0) 
				return -1;
			if (assoc > 0x10)
				return -1;
			return Ports [assoc];
		}

		private	int PortNumToAssociate( int pnum )
		{
			int[] Assocs = new int[] { 2, 3, 4, 5, 6, 7, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10 };
			if (pnum < 0) 
				return -1;
			if (pnum > 11)
				return -1;
			return Assocs [pnum];
		}

		public string PortCfgToString( int portcfg )
		{
			switch (portcfg) {
			case PINMODE_0_HIGHZ:
				return "0 - HIGHZ";
			case PINMODE_1_GPI:
				return "1 - GPI";
			case PINMODE_2_LVTR:
				return "2 - LVTR";
			case PINMODE_3_GPO:
				return "3 - GPO";
			case PINMODE_4_UNILVTR:
				return "4 - UNILVTR";
			case PINMODE_5_DAC:
				return "5 - DAC";
			case PINMODE_6_DACwADC:
				return "6 - DACwADC";
			case PINMODE_7_ADC:
				return "7 - ADC";
			case PINMODE_8_DIFFADCP:
				return "8 - DIFF ADC P";
			case PINMODE_9_DIFFADCN:
				return "9 - DIFF ADC N";
			case PINMODE_10_DACNAIN:
				return "10 - DAC NAIN";
			case PINMODE_11_ANSW:
				return "11 - ANSW";
			case PINMODE_12_AIAO:
				return "12 - AIAO";
			default :
				return "XX - INVALID";
			}
		}




		public string SendCommandWithAnswer( string cmd) {
			if (SendSerialData (cmd + "\n\r")) 
			{
				return ReadSerialData ();
			} 
			else 
			{
				return "ERRSEND";
			}
		}

		public int ReadRegister( int addr ) {

			if (SendSerialData ("?max " + addr.ToString () + "\n\r")) {
				string ret = ReadSerialData ();
				if (ret.Contains ("ERR")) {
					return ERRCMD_ERR;
				}
				if (ret.Length < 2) {
					return ERRCMD_LEN;
				}
				char[] delimiters = new char[] { '\r', '\n', ' ', ',' };
				string[] parts = ret.Split(delimiters,
					StringSplitOptions.RemoveEmptyEntries);
				int rv = 0;
				ret = parts [2];

				if (!Int32.TryParse (ret, out rv)) {
					return ERRCMD_CONVERT;
				} 
				else
					return rv;
			}
			else return ERRCMD_SEND; 

		}

		public double ReadRegValue ( int addr ) {
			int aval = ReadRegister (addr);
			double fval = aval;

			switch (addr) {
			case MAX11300_DEV_ID:
				break;                  
			case MAX11300_INTERRUPT:
				break;
			case MAX11300_ADC_STATUS_15_TO_0:
				break;
			case MAX11300_ADC_STATUS_19_TO_16:
				break;
			case MAX11300_DAC_OI_STATUS_15_to_0:
				break;
			case MAX11300_DAC_OI_STATUS_19_to_16:
				break;
			case MAX11300_GPI_STATUS_15_to_0:
				break;
			case MAX11300_GPI_STATUS_19_to_16:
				break;
			case MAX11300_TMP_INT_DATA:
			case MAX11300_TMP_EXT1_DATA:
			case MAX11300_TMP_EXT2_DATA: 
				fval = fval * 0.125;
				break;
			case MAX11300_GPI_DATA_15_TO_0:
				break;
			case MAX11300_GPI_DATA_19_TO_16:
				break;
			case MAX11300_GPO_DATA_15_TO_0:
				break;
			case MAX11300_GPO_DATA_19_TO_16:
				break;
			default :
				return aval;
			}
			return aval;
		}

		public int WriteRegister( int addr, int aval ) {

			if (SendSerialData (":max " + addr.ToString () + "," + aval.ToString() + "\n\r")) {
				string ret = ReadSerialData ();
				if (ret.Contains ("ERR")) {
					return ERRCMD_ERR;
				}
				if (ret.Length < 2) {
					return ERRCMD_LEN;
				}
				char[] delimiters = new char[] { '\r', '\n', ' ', ',' };
				string[] parts = ret.Split(delimiters,
					StringSplitOptions.RemoveEmptyEntries);
				int rv = 0;
				if( parts.Length < 3 ) {
					return ERRCMD_LEN;
				}
				ret = parts [2];

				if (!Int32.TryParse (ret, out rv)) {
					return ERRCMD_CONVERT;
				} 
				else
					return rv;
			}
			else return ERRCMD_SEND; 

		}

		public bool ReadPortConfig( int portnr1, ref TPortConfig portcfg  ) {

			int addr = 0;
			int portreg = 0;
			int portnr0 = portnr1 - 1;
			switch( portnr0 ) {
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					addr = MAX11311_PORT_CFG_00 + portnr0;
					break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					addr = MAX11311_PORT_CFG_06 + portnr0-6;
					break;
				default :
					return false;
			}

			portreg = ReadRegister (addr);
			int funcid = portreg >> 12;
			int funcprm = portreg & 0xfff;

			if (funcid < 0)
				return false;
			if (funcid > 12)
				return false;
			portcfg.PortMode = funcid;
			portcfg.Invert_AVR = 0;
			portcfg.RangeMode = 0;
			portcfg.NumSamples = 0;
			portcfg.PortAssoc = 0;

			switch (funcid) {
				case PINMODE_0_HIGHZ:
				case PINMODE_1_GPI:
				case PINMODE_2_LVTR:
				case PINMODE_3_GPO:
				case PINMODE_12_AIAO:
					return true;

				case PINMODE_4_UNILVTR:
				case PINMODE_11_ANSW:
					portcfg.Invert_AVR = (funcprm & 0x0800) >> 11;
					portcfg.PortAssoc = AssociateToPortNum( funcprm & 0x001f );
					return true;

				case PINMODE_5_DAC:
					portcfg.RangeMode = (funcprm & 0x0700) >> 8;
					return true;

				case PINMODE_6_DACwADC:
					portcfg.Invert_AVR = (funcprm & 0x0800) >> 11;
					portcfg.RangeMode = (funcprm & 0x0700) >> 8;
					return true;
						
				case PINMODE_7_ADC:
					portcfg.RangeMode = (funcprm & 0x0700) >> 8;
					portcfg.NumSamples = (funcprm & 0x00e0) >> 5;
					return true;

				case PINMODE_8_DIFFADCP:
					portcfg.RangeMode = (funcprm & 0x0700) >> 8;
					portcfg.NumSamples = (funcprm & 0x00e0) >> 5;
					portcfg.PortAssoc = AssociateToPortNum( funcprm & 0x001f );
					return true;

				case PINMODE_9_DIFFADCN:
					portcfg.RangeMode = (funcprm & 0x0700) >> 8;
					return true;
					
				case PINMODE_10_DACNAIN:
					portcfg.RangeMode = (funcprm & 0x0700) >> 8;
					return true;

				default :
					return false;
				
			}

			mxPortConfig[portnr0].PortMode   = portcfg.PortMode;
			mxPortConfig[portnr0].Invert_AVR = portcfg.Invert_AVR;
			mxPortConfig[portnr0].RangeMode  = portcfg.RangeMode;
			mxPortConfig[portnr0].NumSamples = portcfg.NumSamples;
			mxPortConfig[portnr0].PortAssoc  = portcfg.PortAssoc;
		}

		public bool WritePortConfig( int portnr1, TPortConfig portcfg  ) {

			int addr = 0;
			int portnr0 = portnr1 - 1;
			switch( portnr0 ) {
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				addr = MAX11311_PORT_CFG_00 + portnr0;
				break;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
				addr = MAX11311_PORT_CFG_06 + portnr0-6;
				break;
			default :
				return false;
			}

			//portreg = ReadRegister (addr);

			int portreg = (portcfg.PortMode << 12) 
				| ( portcfg.Invert_AVR << 11) 
				| ( portcfg.RangeMode << 8 )
				| ( portcfg.NumSamples << 5)
				| PortNumToAssociate( portcfg.PortAssoc );

			if (WriteRegister (addr, portreg) >= 0) {
				mxPortConfig[portnr0].PortMode   = portcfg.PortMode;
				mxPortConfig[portnr0].Invert_AVR = portcfg.Invert_AVR;
				mxPortConfig[portnr0].RangeMode  = portcfg.RangeMode;
				mxPortConfig[portnr0].NumSamples = portcfg.NumSamples;
				mxPortConfig[portnr0].PortAssoc  = portcfg.PortAssoc;
				return true;
			}
			
			
			return false;
		}


		public double ReadPortValue( int portnr1  ) {

			if (portnr1 < 1)
				return Double.NaN;
			if (portnr1 > 12)
				return Double.NaN;
			
			int addr = 0;
			int portreg = 0;
			int portnr0 = portnr1 - 1;
			double digval = 0.0;


			switch( mxPortConfig[portnr0].PortMode ) 
			{
			case PINMODE_1_GPI:
				if (portnr0 == 11) 
				{
					portreg = ReadRegister (MAX11300_GPI_STATUS_19_to_16);
					return portreg & 1;
				}
				else
				{
					portreg = ReadRegister (MAX11300_GPI_STATUS_15_to_0);
					switch (portnr0) {
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						portreg >>= portnr0 + 2;
						return portreg & 1;
					/*case 6:
					case 7:
					case 8:
					case 9:
					case 10:*/
					default:
						portreg >>= portnr0 + 5;
						return portreg & 1;
					}
				}
				//break;
			
			case PINMODE_7_ADC:
			case PINMODE_8_DIFFADCP:
			case PINMODE_9_DIFFADCN:	
				switch (portnr0) {
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					addr = MAX11311_ADC_DATA_PORT_00 + portnr0;
					break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					addr = MAX11311_ADC_DATA_PORT_06 + portnr0-6;
					break;
				}
				digval = ReadRegister (addr);

				switch (mxPortConfig [portnr0].RangeMode) {
				case RANGEMODE_NONE:
				case RANGEMODE_RESVD5:
				case RANGEMODE_RESVD7:
					break;
				case RANGEMODE_0_10V:
					digval = digval * 10 / 4095;
					break;
				case RANGEMODE_N5_5V:
					digval = digval * 10 / 4095 - 5;
					break;
				case RANGEMODE_N10_0V:
					digval = digval * 10 / 4095 - 10;
					break;
				case RANGEMODE_0_2V5: 
				case RANGEMODE_0_2V5P:
					digval = digval * 2.5 / 4095;
					break;
				}
				return digval;
				//break;
			}
			return Double.NaN;
		
		}// ReadPortValue

		public bool WritePortValue( int portnr1, double value  ) {
			

			int addr = 0;
			int mask = 0;
			int portreg = 0;
			int portnr0 = portnr1 - 1;
			int digits = 0;


			switch( mxPortConfig[portnr0].PortMode ) 
			{
			case PINMODE_3_GPO:
				if (portnr0 == 11) 
				{
					portreg = ReadRegister (MAX11300_GPO_DATA_19_TO_16) & 1;
					if (value > 0.5)
						portreg |= 1;
					WriteRegister( MAX11300_GPO_DATA_19_TO_16, portreg );
					return true;
				}
				else
				{
					portreg = ReadRegister (MAX11300_GPO_DATA_15_TO_0);
					switch (portnr0) {
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						mask = 1 << (portnr0 + 2);
						portreg &= ~mask;
						if( value > 0.5 ) 
							portreg |= mask;
						break;
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					default:
						mask = 1 << (portnr0 + 5);
						portreg &= ~mask;
						if( value > 0.5 ) 
							portreg |= mask;
						break;
					}
					WriteRegister( MAX11300_GPO_DATA_15_TO_0, portreg );
					return true;
				}
				break;

			case PINMODE_5_DAC:
			case PINMODE_6_DACwADC:
				switch (portnr0) {
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					addr = MAX11311_DAC_DATA_PORT_00 + portnr0;
					break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					addr = MAX11311_DAC_DATA_PORT_06 + portnr0 - 6;
					break;
				}

				switch (mxPortConfig [portnr0].RangeMode) {
				case RANGEMODE_NONE:
				case RANGEMODE_RESVD5:
				case RANGEMODE_RESVD7:
					break;
				case RANGEMODE_0_10V:
				case RANGEMODE_0_2V5P:
					digits = (int)(value * 4095 / 10);
					break;
				case RANGEMODE_N5_5V:
					digits = (int)((value + 5) * 4095 / 10);
					break;
				case RANGEMODE_N10_0V:
					digits = (int)((value + 10) * 4095 / 10);
					break;
				case RANGEMODE_0_2V5: 
					digits = (int)(value * 4095 / 2.5);
					break;
				}
				if (digits > 4095)
					digits = 4095;
				if (digits < 0)
					digits = 0;

				WriteRegister (addr, digits);
				return true;

			}
			return false;

		}// WritePortValue

		private void SetDACMode( int mode  ) {
			int reg = ReadRegister (MAX11300_DEVICE_CONTROL) & ~0x000C;
			//reg >>= 2;

			switch( mode ) {
			case 1: 
			case 2:
			case 3:
				reg |= mode << 2;
				break;
			default : 
				break;
			}
			WriteRegister (MAX11300_DEVICE_CONTROL, reg) ;
		}// SetDACMode

		private int GetDACMode( ) {
			return (ReadRegister (MAX11300_DEVICE_CONTROL) & 0x000C) >> 2;
		}// GetDAcMode

		private void SetDACReference( int mode  ) {
			int reg = ReadRegister (MAX11300_DEVICE_CONTROL) & ~0x0040;
			if (mode == 1)
				reg |= 0x0040;
			WriteRegister (MAX11300_DEVICE_CONTROL, reg) ;
		}// SetDACReference

		private int GetDACReference( ) {
			return (ReadRegister (MAX11300_DEVICE_CONTROL) & 0x0040) >> 6;
		}// GetDAcReference


		private void SetADCMode( int mode  ) {
			int reg = ReadRegister (MAX11300_DEVICE_CONTROL) & ~0x0003;

			switch( mode ) {
			case 1: 
			case 2:
			case 3:
				reg |= mode;
				break;
			default : 
				break;
			}
			WriteRegister (MAX11300_DEVICE_CONTROL, reg) ;
		}// SetAdcMode

		private int GetADCMode( ) {
			return ReadRegister (MAX11300_DEVICE_CONTROL) & 0x0003;
		}// GetAdcMode

		private void SetADCSpeed( int speed  ) {
			int res = ReadRegister (MAX11300_DEVICE_CONTROL) & ~0x0030;

			switch( speed ) {
			case 200:
				res |= 0 << 4;
				break;
			case 250:
				res |= 1 << 4;
				break;
			case 333:
				res |= 2 << 4;
				break;
			case 400:
				res |= 3 << 4;
				break;
			default : 
				return;
			}
			WriteRegister (MAX11300_DEVICE_CONTROL, res ) ;
		}// SetAdcMode

		private int GetADCSpeed( ) {
			int res = ReadRegister (MAX11300_DEVICE_CONTROL) & 0x0030;
			res >>= 4;
			switch (res) {
			case 0:
				return 200;
			case 1:
				return 250;
			case 2:
				return 333;
			case 3:
				return 400;
			}
			return 0;
		}// GetAdcSpeed

		private double GetAnalogIn( int indx ) {
			return indx * 1.1;
		}
	}
}

