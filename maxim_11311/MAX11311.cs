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




	}
}

