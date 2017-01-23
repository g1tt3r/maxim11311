using System;

namespace maxim_11311
{
	public partial class MAXIM11311
	{
		// Failure codes
		public const int ERRCMD_ERR = -1;
		public const int ERRCMD_LEN = -2;
		public const int ERRCMD_SEND = -3;
		public const int ERRCMD_CONVERT = -4;

		#region MAX11300 device driver (SPI interface)

		/// <summary>
		/// Below register access calls and register Name constants
		/// SPI-Driver for MAX11300
		/// </summary>
		/// 

		/* Register_Name                                        Direction       */    /*----------------------------------------------------------------------*/
		/* Device ID                                            R               */    public const byte MAX11300_DEV_ID                     = 0x00;
		/* Interrupt register                                   R               */    public const byte MAX11300_INTERRUPT                  = 0x01;
		/* ADC data received status for ports 0 to 15           R               */    public const byte MAX11300_ADC_STATUS_15_TO_0         = 0x02;
		/* ADC data received status for ports 16 to 31          R               */    public const byte MAX11300_ADC_STATUS_19_TO_16        = 0x03;
		/* Over-current status for DAC drivers 0 to 15          R               */    public const byte MAX11300_DAC_OI_STATUS_15_to_0      = 0x04;
		/* Over-current status for DAC drivers 16 to 19         R               */    public const byte MAX11300_DAC_OI_STATUS_19_to_16     = 0x05;
		/* GPI data received status for ports 0 to 15           R               */    public const byte MAX11300_GPI_STATUS_15_to_0         = 0x06;
		/* GPI data received status for ports 16 to 19          R               */    public const byte MAX11300_GPI_STATUS_19_to_16        = 0x07;
		/* Internal temperature data register                   R               */    public const byte MAX11300_TMP_INT_DATA               = 0x08;
		/* 1st external temperature data                        R               */    public const byte MAX11300_TMP_EXT1_DATA              = 0x09;
		/* 2nd external temperature data                        R               */    public const byte MAX11300_TMP_EXT2_DATA              = 0x0a;
		/* GPI data for PIXI ports 15 to 0                      R               */    public const byte MAX11300_GPI_DATA_15_TO_0           = 0x0b;
		/* GPI data for PIXI ports 19 to 16                     R               */    public const byte MAX11300_GPI_DATA_19_TO_16          = 0x0c;
		/* GPO data for PIXI ports 15 to 0                      R/W             */    public const byte MAX11300_GPO_DATA_15_TO_0           = 0x0d;
		/* GPO data for PIXI ports 19 to 16                     R/W             */    public const byte MAX11300_GPO_DATA_19_TO_16          = 0x0e;
		/*                                                                      */    //                                                   = 0x0f;
		/* Device main control register                         R/W             */    public const byte MAX11300_DEVICE_CONTROL             = 0x10;
		/* Interrupt mask register                              R/W             */    public const byte MAX11300_INTERRUPT_MASK             = 0x11;
		/* GPI port 0 to 7 mode register                        R/W             */    public const byte MAX11300_GPI_IRQMODE_7_TO_0         = 0x12;
		/* GPI port 8 to 15 mode register                       R/W             */    public const byte MAX11300_GPI_IRQMODE_15_TO_8        = 0x13;
		/* GPI port 16 to 19 mode register                      R/W             */    public const byte MAX11300_GPI_IRQMODE_19_TO_16       = 0x14;
		/*                                                                      */    //                                                   = 0x15;
		/* DAC preset data #1                                   R/W             */    public const byte MAX11300_DAC_PRESET_DATA_1          = 0x16;
		/* DAC preset data #2                                   R/W             */    public const byte MAX11300_DAC_PRESET_DATA_2          = 0x17;
		/* Temperature monitor configuration                    R/W             */    public const byte MAX11300_TMP_MON_CFG                = 0x18;
		/* internal temperature monitor high threshold          R/W             */    public const byte MAX11300_TMP_MON_INT_HI_THRESH      = 0x19;
		/* internal temperature monitor low threshold           R/W             */    public const byte MAX11300_TMP_MON_INT_LO_THRESH      = 0x1a;
		/* 1st external temperature monitor high threshold      R/W             */    public const byte MAX11300_TMP_MON_EXT1_HI_THRESH     = 0x1b;
		/* 1st external temperature monitor low threshold       R/W             */    public const byte MAX11300_TMP_MON_EXT1_LO_THRESH     = 0x1c;
		/* 2nd external temperature monitor high threshold      R/W             */    public const byte MAX11300_TMP_MON_EXT2_HI_THRESH     = 0x1d;
		/* 2nd external temperature monitor low threshold       R/W             */    public const byte MAX11300_TMP_MON_EXT2_LO_THRESH     = 0x1e;
		/*                                                                      */    //                                                   = 0x1f;
		/* Configuration register for PIXI port 0               R/W             */    public const byte MAX11300_PORT_CFG_00                = 0x20;
		/* Configuration register for PIXI port 1               R/W             */    public const byte MAX11300_PORT_CFG_01                = 0x21;
		/* Configuration register for PIXI port 2               R/W             */    public const byte MAX11300_PORT_CFG_02                = 0x22;
		/* Configuration register for PIXI port 3               R/W             */    public const byte MAX11300_PORT_CFG_03                = 0x23;
		/* Configuration register for PIXI port 4               R/W             */    public const byte MAX11300_PORT_CFG_04                = 0x24;
		/* Configuration register for PIXI port 5               R/W             */    public const byte MAX11300_PORT_CFG_05                = 0x25;
		/* Configuration register for PIXI port 6               R/W             */    public const byte MAX11300_PORT_CFG_06                = 0x26;
		/* Configuration register for PIXI port 7               R/W             */    public const byte MAX11300_PORT_CFG_07                = 0x27;
		/* Configuration register for PIXI port 8               R/W             */    public const byte MAX11300_PORT_CFG_08                = 0x28;
		/* Configuration register for PIXI port 9               R/W             */    public const byte MAX11300_PORT_CFG_09                = 0x29;
		/* Configuration register for PIXI port 10              R/W             */    public const byte MAX11300_PORT_CFG_10                = 0x2a;
		/* Configuration register for PIXI port 11              R/W             */    public const byte MAX11300_PORT_CFG_11                = 0x2b;
		/* Configuration register for PIXI port 12              R/W             */    public const byte MAX11300_PORT_CFG_12                = 0x2c;
		/* Configuration register for PIXI port 13              R/W             */    public const byte MAX11300_PORT_CFG_13                = 0x2d;
		/* Configuration register for PIXI port 14              R/W             */    public const byte MAX11300_PORT_CFG_14                = 0x2e;
		/* Configuration register for PIXI port 15              R/W             */    public const byte MAX11300_PORT_CFG_15                = 0x2f;
		/* Configuration register for PIXI port 16              R/W             */    public const byte MAX11300_PORT_CFG_16                = 0x30;
		/* Configuration register for PIXI port 17              R/W             */    public const byte MAX11300_PORT_CFG_17                = 0x31;
		/* Configuration register for PIXI port 18              R/W             */    public const byte MAX11300_PORT_CFG_18                = 0x32;
		/* Configuration register for PIXI port 19              R/W             */    public const byte MAX11300_PORT_CFG_19                = 0x33;
		/*                                                                      */    //                                                   = 0x34;
		/*                                                                      */    //                                                   = 0x35;
		/*                                                                      */    //                                                   = 0x36;
		/*                                                                      */    //                                                   = 0x37;
		/*                                                                      */    //                                                   = 0x38;
		/*                                                                      */    //                                                   = 0x39;
		/*                                                                      */    //                                                   = 0x3a;
		/*                                                                      */    //                                                   = 0x3b;
		/*                                                                      */    //                                                   = 0x3c;
		/*                                                                      */    //                                                   = 0x3d;
		/*                                                                      */    //                                                   = 0x3e;
		/*                                                                      */    //                                                   = 0x3f;
		/* ADC data register for PIXI port 0                    R               */    public const byte MAX11300_ADC_DATA_PORT_00           = 0x40;
		/* ADC data register for PIXI port 1                    R               */    public const byte MAX11300_ADC_DATA_PORT_01           = 0x41;
		/* ADC data register for PIXI port 2                    R               */    public const byte MAX11300_ADC_DATA_PORT_02           = 0x42;
		/* ADC data register for PIXI port 3                    R               */    public const byte MAX11300_ADC_DATA_PORT_03           = 0x43;
		/* ADC data register for PIXI port 4                    R               */    public const byte MAX11300_ADC_DATA_PORT_04           = 0x44;
		/* ADC data register for PIXI port 5                    R               */    public const byte MAX11300_ADC_DATA_PORT_05           = 0x45;
		/* ADC data register for PIXI port 6                    R               */    public const byte MAX11300_ADC_DATA_PORT_06           = 0x46;
		/* ADC data register for PIXI port 7                    R               */    public const byte MAX11300_ADC_DATA_PORT_07           = 0x47;
		/* ADC data register for PIXI port 8                    R               */    public const byte MAX11300_ADC_DATA_PORT_08           = 0x48;
		/* ADC data register for PIXI port 9                    R               */    public const byte MAX11300_ADC_DATA_PORT_09           = 0x49;
		/* ADC data register for PIXI port 10                   R               */    public const byte MAX11300_ADC_DATA_PORT_10           = 0x4a;
		/* ADC data register for PIXI port 11                   R               */    public const byte MAX11300_ADC_DATA_PORT_11           = 0x4b;
		/* ADC data register for PIXI port 12                   R               */    public const byte MAX11300_ADC_DATA_PORT_12           = 0x4c;
		/* ADC data register for PIXI port 13                   R               */    public const byte MAX11300_ADC_DATA_PORT_13           = 0x4d;
		/* ADC data register for PIXI port 14                   R               */    public const byte MAX11300_ADC_DATA_PORT_14           = 0x4e;
		/* ADC data register for PIXI port 15                   R               */    public const byte MAX11300_ADC_DATA_PORT_15           = 0x4f;
		/* ADC data register for PIXI port 16                   R               */    public const byte MAX11300_ADC_DATA_PORT_16           = 0x50;
		/* ADC data register for PIXI port 17                   R               */    public const byte MAX11300_ADC_DATA_PORT_17           = 0x51;
		/* ADC data register for PIXI port 18                   R               */    public const byte MAX11300_ADC_DATA_PORT_18           = 0x52;
		/* ADC data register for PIXI port 19                   R               */    public const byte MAX11300_ADC_DATA_PORT_19           = 0x53;
		/*                                                                      */    //                                                   = 0x54;
		/*                                                                      */    //                                                   = 0x55;
		/*                                                                      */    //                                                   = 0x56;
		/*                                                                      */    //                                                   = 0x57;
		/*                                                                      */    //                                                   = 0x58;
		/*                                                                      */    //                                                   = 0x59;
		/*                                                                      */    //                                                   = 0x5a;
		/*                                                                      */    //                                                   = 0x5b;
		/*                                                                      */    //                                                   = 0x5c;
		/*                                                                      */    //                                                   = 0x5d;
		/*                                                                      */    //                                                   = 0x5e;
		/*                                                                      */    //                                                   = 0x5f;
		/* DAC data register for PIXI port 0                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_00           = 0x60;
		/* DAC data register for PIXI port 1                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_01           = 0x61;
		/* DAC data register for PIXI port 2                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_02           = 0x62;
		/* DAC data register for PIXI port 3                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_03           = 0x63;
		/* DAC data register for PIXI port 4                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_04           = 0x64;
		/* DAC data register for PIXI port 5                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_05           = 0x65;
		/* DAC data register for PIXI port 6                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_06           = 0x66;
		/* DAC data register for PIXI port 7                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_07           = 0x67;
		/* DAC data register for PIXI port 8                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_08           = 0x68;
		/* DAC data register for PIXI port 9                    R/W             */    public const byte MAX11300_DAC_DATA_PORT_09           = 0x69;
		/* DAC data register for PIXI port 10                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_10           = 0x6a;
		/* DAC data register for PIXI port 11                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_11           = 0x6b;
		/* DAC data register for PIXI port 12                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_12           = 0x6c;
		/* DAC data register for PIXI port 13                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_13           = 0x6d;
		/* DAC data register for PIXI port 14                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_14           = 0x6e;
		/* DAC data register for PIXI port 15                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_15           = 0x6f;
		/* DAC data register for PIXI port 16                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_16           = 0x70;
		/* DAC data register for PIXI port 17                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_17           = 0x71;
		/* DAC data register for PIXI port 18                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_18           = 0x72;
		/* DAC data register for PIXI port 19                   R/W             */    public const byte MAX11300_DAC_DATA_PORT_19           = 0x73;
		/*                                                                      */    //                                                   = 0x74;
		/*                                                                      */    //                                                   = 0x75;
		/*                                                                      */    //                                                   = 0x76;
		/*                                                                      */    //                                                   = 0x77;
		/*                                                                      */    //                                                   = 0x78;
		/*                                                                      */    //                                                   = 0x79;
		/*                                                                      */    //                                                   = 0x7a;
		/*                                                                      */    //                                                   = 0x7b;
		/*                                                                      */    //                                                   = 0x7c;
		/*                                                                      */    //                                                   = 0x7d;
		/*                                                                      */    //                                                   = 0x7e;
		/*                                                                      */    //                                                   = 0x7f;

		#endregion
	}
}


