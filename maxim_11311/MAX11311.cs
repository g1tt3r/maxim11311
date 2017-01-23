using System;

using System.IO.Ports;


namespace maxim_11311
{



	public partial class MAXIM11311
	{
		


		private SerialPort mxSerial;

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
			}
			catch ( Exception msg )
			{
				Exception : ;
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

		public bool ReadPortConfig( int portnr, ref TPortConfig portcfg  ) {

			int addr = 0;
			int portreg = 0;
			switch( portnr ) {
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					addr = MAX11311_PORT_CFG_00 + portnr;
					break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					addr = MAX11311_PORT_CFG_06 + portnr;
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
		}

		public bool WritePortConfig( int portnr, TPortConfig portcfg  ) {

			int addr = 0;
			switch( portnr ) {
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				addr = MAX11311_PORT_CFG_00 + portnr;
				break;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
				addr = MAX11311_PORT_CFG_06 + portnr;
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

			if( WriteRegister( addr, portreg ) >= 0 )
				return true;
			
			
			return false;
		}




	}
}

