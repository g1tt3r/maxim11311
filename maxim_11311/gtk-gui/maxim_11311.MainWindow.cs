
// This file has been generated by the GUI designer. Do not modify.
namespace maxim_11311
{
	public partial class MainWindow
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.MenuBar menubar1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button tbnQuit;
		
		private global::Gtk.ToggleButton tbnConnect;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Notebook notebook2;
		
		private global::Gtk.Frame frame4;
		
		private global::Gtk.Alignment GtkAlignment3;
		
		private global::Gtk.VBox vbox8;
		
		private global::Gtk.VBox vbox9;
		
		private global::Gtk.HBox hbox5;
		
		private global::Gtk.Label lblP;
		
		private global::Gtk.ComboBox cmbPortMode;
		
		private global::Gtk.HBox hbox9;
		
		private global::Gtk.ComboBox cmbPortRange;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.Label lblP1;
		
		private global::Gtk.ComboBox cmbPortMode1;
		
		private global::Gtk.HBox hbox10;
		
		private global::Gtk.ComboBox cmbPortRange1;
		
		private global::Gtk.VBox vbox10;
		
		private global::Gtk.VBox vbox11;
		
		private global::Gtk.VBox vbox14;
		
		private global::Gtk.VBox vbox13;
		
		private global::Gtk.HBox hbox8;
		
		private global::Gtk.Label GtkLabel19;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Frame frame2;
		
		private global::Gtk.Alignment GtkAlignment1;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.RadioButton rbnAdcIdleMode;
		
		private global::Gtk.RadioButton rbnAdcSingleSweep;
		
		private global::Gtk.VBox vbox5;
		
		private global::Gtk.RadioButton rbnAdcSingleConv;
		
		private global::Gtk.RadioButton rbnAdcContSweep;
		
		private global::Gtk.Label lblADCConvMode;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.Frame frame3;
		
		private global::Gtk.Alignment GtkAlignment2;
		
		private global::Gtk.VBox vbox6;
		
		private global::Gtk.RadioButton rbnAdcSpeed200;
		
		private global::Gtk.RadioButton rbnAdcSpeed250;
		
		private global::Gtk.VBox vbox7;
		
		private global::Gtk.RadioButton rbnAdcSpeed333;
		
		private global::Gtk.RadioButton rbnAdcSpeed400;
		
		private global::Gtk.Label GtkLabel13;
		
		private global::Gtk.Label GtkLabel4;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.HBox hbox7;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.Button btnClear;
		
		private global::Gtk.Button btnReadAll;
		
		private global::Gtk.Button btnReadReg;
		
		private global::Gtk.Button btnWriteReg;
		
		private global::Gtk.Label lblReadRes;
		
		private global::Gtk.SpinButton spbReadReg;
		
		private global::Gtk.SpinButton spbWriteReg;
		
		private global::Gtk.SpinButton spbWriteVal;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TextView txvLog;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Statusbar statusbar1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget maxim_11311.MainWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "maxim_11311.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child maxim_11311.MainWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'/></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.vbox1.Add (this.menubar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.tbnQuit = new global::Gtk.Button ();
			this.tbnQuit.CanFocus = true;
			this.tbnQuit.Name = "tbnQuit";
			this.tbnQuit.UseUnderline = true;
			this.tbnQuit.Label = global::Mono.Unix.Catalog.GetString ("Quit");
			this.hbox1.Add (this.tbnQuit);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.tbnQuit]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.tbnConnect = new global::Gtk.ToggleButton ();
			this.tbnConnect.CanFocus = true;
			this.tbnConnect.Name = "tbnConnect";
			this.tbnConnect.UseUnderline = true;
			this.tbnConnect.Label = global::Mono.Unix.Catalog.GetString ("Connect");
			this.hbox1.Add (this.tbnConnect);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.tbnConnect]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.notebook2 = new global::Gtk.Notebook ();
			this.notebook2.CanFocus = true;
			this.notebook2.Name = "notebook2";
			this.notebook2.CurrentPage = 1;
			// Container child notebook2.Gtk.Notebook+NotebookChild
			this.frame4 = new global::Gtk.Frame ();
			this.frame4.Name = "frame4";
			this.frame4.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame4.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbox8 = new global::Gtk.VBox ();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.vbox9 = new global::Gtk.VBox ();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 6;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.lblP = new global::Gtk.Label ();
			this.lblP.Name = "lblP";
			this.lblP.LabelProp = global::Mono.Unix.Catalog.GetString ("Port 0");
			this.hbox5.Add (this.lblP);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.lblP]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.cmbPortMode = global::Gtk.ComboBox.NewText ();
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("High impedance"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Digital input, GPI"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Level translator"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Register output, GPO"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Path output, GPO"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("DAC output"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("DAC out, ADC-monitored"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Single ended ADC"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Differential ADC +"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Differential ADC -"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Pseudo differential"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Analog switch GPI"));
			this.cmbPortMode.AppendText (global::Mono.Unix.Catalog.GetString ("Analog switch Register"));
			this.cmbPortMode.AppendText ("");
			this.cmbPortMode.AppendText ("");
			this.cmbPortMode.AppendText ("");
			this.cmbPortMode.Name = "cmbPortMode";
			this.cmbPortMode.Active = 12;
			this.hbox5.Add (this.cmbPortMode);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.cmbPortMode]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.cmbPortRange = global::Gtk.ComboBox.NewText ();
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("none"));
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("0 .. +10 V"));
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("-5 .. +5 V"));
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("-10 .. 0 V"));
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("0 .. +2.5 V"));
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("res"));
			this.cmbPortRange.AppendText (global::Mono.Unix.Catalog.GetString ("0 .. +2.5 V"));
			this.cmbPortRange.Name = "cmbPortRange";
			this.cmbPortRange.Active = 0;
			this.hbox9.Add (this.cmbPortRange);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.cmbPortRange]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox5.Add (this.hbox9);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.hbox9]));
			w9.Position = 2;
			this.vbox9.Add (this.hbox5);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox9 [this.hbox5]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.lblP1 = new global::Gtk.Label ();
			this.lblP1.Name = "lblP1";
			this.lblP1.LabelProp = global::Mono.Unix.Catalog.GetString ("Port 1");
			this.hbox6.Add (this.lblP1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.lblP1]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.cmbPortMode1 = global::Gtk.ComboBox.NewText ();
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("High impedance"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Digital input, GPI"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Level translator"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Register output, GPO"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Path output, GPO"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("DAC output"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("DAC out, ADC-monitored"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Single ended ADC"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Differential ADC +"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Differential ADC -"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Pseudo differential"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Analog switch GPI"));
			this.cmbPortMode1.AppendText (global::Mono.Unix.Catalog.GetString ("Analog switch Register"));
			this.cmbPortMode1.AppendText ("");
			this.cmbPortMode1.AppendText ("");
			this.cmbPortMode1.AppendText ("");
			this.cmbPortMode1.Name = "cmbPortMode1";
			this.cmbPortMode1.Active = 12;
			this.hbox6.Add (this.cmbPortMode1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.cmbPortMode1]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox ();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.cmbPortRange1 = global::Gtk.ComboBox.NewText ();
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("none"));
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("0 .. +10 V"));
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("-5 .. +5 V"));
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("-10 .. 0 V"));
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("0 .. +2.5 V"));
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("res"));
			this.cmbPortRange1.AppendText (global::Mono.Unix.Catalog.GetString ("0 .. +2.5 V"));
			this.cmbPortRange1.Name = "cmbPortRange1";
			this.cmbPortRange1.Active = 0;
			this.hbox10.Add (this.cmbPortRange1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.cmbPortRange1]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			this.hbox6.Add (this.hbox10);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.hbox10]));
			w14.Position = 2;
			this.vbox9.Add (this.hbox6);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox9 [this.hbox6]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			this.vbox8.Add (this.vbox9);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.vbox9]));
			w16.Position = 0;
			// Container child vbox8.Gtk.Box+BoxChild
			this.vbox10 = new global::Gtk.VBox ();
			this.vbox10.Name = "vbox10";
			this.vbox10.Spacing = 6;
			this.vbox8.Add (this.vbox10);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.vbox10]));
			w17.Position = 1;
			// Container child vbox8.Gtk.Box+BoxChild
			this.vbox11 = new global::Gtk.VBox ();
			this.vbox11.Name = "vbox11";
			this.vbox11.Spacing = 6;
			// Container child vbox11.Gtk.Box+BoxChild
			this.vbox14 = new global::Gtk.VBox ();
			this.vbox14.Name = "vbox14";
			this.vbox14.Spacing = 6;
			this.vbox11.Add (this.vbox14);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox11 [this.vbox14]));
			w18.Position = 1;
			// Container child vbox11.Gtk.Box+BoxChild
			this.vbox13 = new global::Gtk.VBox ();
			this.vbox13.Name = "vbox13";
			this.vbox13.Spacing = 6;
			// Container child vbox13.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			this.vbox13.Add (this.hbox8);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox13 [this.hbox8]));
			w19.Position = 1;
			this.vbox11.Add (this.vbox13);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox11 [this.vbox13]));
			w20.Position = 2;
			this.vbox8.Add (this.vbox11);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.vbox11]));
			w21.Position = 2;
			this.GtkAlignment3.Add (this.vbox8);
			this.frame4.Add (this.GtkAlignment3);
			this.GtkLabel19 = new global::Gtk.Label ();
			this.GtkLabel19.Name = "GtkLabel19";
			this.GtkLabel19.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>GtkFrame</b>");
			this.GtkLabel19.UseMarkup = true;
			this.frame4.LabelWidget = this.GtkLabel19;
			this.notebook2.Add (this.frame4);
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("page3");
			this.notebook2.SetTabLabel (this.frame4, this.label2);
			this.label2.ShowAll ();
			// Container child notebook2.Gtk.Notebook+NotebookChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.rbnAdcIdleMode = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Idle mode"));
			this.rbnAdcIdleMode.CanFocus = true;
			this.rbnAdcIdleMode.Name = "rbnAdcIdleMode";
			this.rbnAdcIdleMode.DrawIndicator = true;
			this.rbnAdcIdleMode.UseUnderline = true;
			this.rbnAdcIdleMode.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.vbox4.Add (this.rbnAdcIdleMode);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.rbnAdcIdleMode]));
			w25.Position = 0;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.rbnAdcSingleSweep = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Single sweep"));
			this.rbnAdcSingleSweep.CanFocus = true;
			this.rbnAdcSingleSweep.Name = "rbnAdcSingleSweep";
			this.rbnAdcSingleSweep.DrawIndicator = true;
			this.rbnAdcSingleSweep.UseUnderline = true;
			this.rbnAdcSingleSweep.Group = this.rbnAdcIdleMode.Group;
			this.vbox4.Add (this.rbnAdcSingleSweep);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.rbnAdcSingleSweep]));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.rbnAdcSingleConv = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Single conversion"));
			this.rbnAdcSingleConv.CanFocus = true;
			this.rbnAdcSingleConv.Name = "rbnAdcSingleConv";
			this.rbnAdcSingleConv.DrawIndicator = true;
			this.rbnAdcSingleConv.UseUnderline = true;
			this.rbnAdcSingleConv.Group = this.rbnAdcIdleMode.Group;
			this.vbox5.Add (this.rbnAdcSingleConv);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.rbnAdcSingleConv]));
			w27.Position = 0;
			w27.Expand = false;
			w27.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.rbnAdcContSweep = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Continiuous sweep"));
			this.rbnAdcContSweep.CanFocus = true;
			this.rbnAdcContSweep.Name = "rbnAdcContSweep";
			this.rbnAdcContSweep.DrawIndicator = true;
			this.rbnAdcContSweep.UseUnderline = true;
			this.rbnAdcContSweep.Group = this.rbnAdcIdleMode.Group;
			this.vbox5.Add (this.rbnAdcContSweep);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.rbnAdcContSweep]));
			w28.Position = 1;
			w28.Expand = false;
			w28.Fill = false;
			this.vbox4.Add (this.vbox5);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.vbox5]));
			w29.Position = 2;
			w29.Expand = false;
			w29.Fill = false;
			this.GtkAlignment1.Add (this.vbox4);
			this.frame2.Add (this.GtkAlignment1);
			this.lblADCConvMode = new global::Gtk.Label ();
			this.lblADCConvMode.Name = "lblADCConvMode";
			this.lblADCConvMode.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>ADC Conversion mode</b>");
			this.lblADCConvMode.UseMarkup = true;
			this.frame2.LabelWidget = this.lblADCConvMode;
			this.hbox3.Add (this.frame2);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.frame2]));
			w32.Position = 0;
			w32.Expand = false;
			w32.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.rbnAdcSpeed200 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("200 ksps"));
			this.rbnAdcSpeed200.CanFocus = true;
			this.rbnAdcSpeed200.Name = "rbnAdcSpeed200";
			this.rbnAdcSpeed200.DrawIndicator = true;
			this.rbnAdcSpeed200.UseUnderline = true;
			this.rbnAdcSpeed200.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.vbox6.Add (this.rbnAdcSpeed200);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.rbnAdcSpeed200]));
			w33.Position = 0;
			w33.Expand = false;
			w33.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.rbnAdcSpeed250 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("250 ksps"));
			this.rbnAdcSpeed250.CanFocus = true;
			this.rbnAdcSpeed250.Name = "rbnAdcSpeed250";
			this.rbnAdcSpeed250.DrawIndicator = true;
			this.rbnAdcSpeed250.UseUnderline = true;
			this.rbnAdcSpeed250.Group = this.rbnAdcSpeed200.Group;
			this.vbox6.Add (this.rbnAdcSpeed250);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.rbnAdcSpeed250]));
			w34.Position = 1;
			w34.Expand = false;
			w34.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.rbnAdcSpeed333 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("333 ksps"));
			this.rbnAdcSpeed333.CanFocus = true;
			this.rbnAdcSpeed333.Name = "rbnAdcSpeed333";
			this.rbnAdcSpeed333.DrawIndicator = true;
			this.rbnAdcSpeed333.UseUnderline = true;
			this.rbnAdcSpeed333.Group = this.rbnAdcSpeed200.Group;
			this.vbox7.Add (this.rbnAdcSpeed333);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.rbnAdcSpeed333]));
			w35.Position = 0;
			w35.Expand = false;
			w35.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.rbnAdcSpeed400 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("400 ksps"));
			this.rbnAdcSpeed400.CanFocus = true;
			this.rbnAdcSpeed400.Name = "rbnAdcSpeed400";
			this.rbnAdcSpeed400.DrawIndicator = true;
			this.rbnAdcSpeed400.UseUnderline = true;
			this.rbnAdcSpeed400.Group = this.rbnAdcSpeed200.Group;
			this.vbox7.Add (this.rbnAdcSpeed400);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.rbnAdcSpeed400]));
			w36.Position = 1;
			w36.Expand = false;
			w36.Fill = false;
			this.vbox6.Add (this.vbox7);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.vbox7]));
			w37.Position = 2;
			w37.Expand = false;
			w37.Fill = false;
			this.GtkAlignment2.Add (this.vbox6);
			this.frame3.Add (this.GtkAlignment2);
			this.GtkLabel13 = new global::Gtk.Label ();
			this.GtkLabel13.Name = "GtkLabel13";
			this.GtkLabel13.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>ADC Conv. speed</b>");
			this.GtkLabel13.UseMarkup = true;
			this.frame3.LabelWidget = this.GtkLabel13;
			this.hbox4.Add (this.frame3);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.frame3]));
			w40.Position = 0;
			w40.Expand = false;
			w40.Fill = false;
			this.hbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.hbox4]));
			w41.Position = 1;
			this.GtkAlignment.Add (this.hbox3);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>ADC settings</b>");
			this.GtkLabel4.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel4;
			this.vbox3.Add (this.frame1);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame1]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			this.notebook2.Add (this.vbox3);
			global::Gtk.Notebook.NotebookChild w45 = ((global::Gtk.Notebook.NotebookChild)(this.notebook2 [this.vbox3]));
			w45.Position = 1;
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("ADC/DAC");
			this.notebook2.SetTabLabel (this.vbox3, this.label1);
			this.label1.ShowAll ();
			// Container child notebook2.Gtk.Notebook+NotebookChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(6)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.btnClear = new global::Gtk.Button ();
			this.btnClear.CanFocus = true;
			this.btnClear.Name = "btnClear";
			this.btnClear.UseUnderline = true;
			this.btnClear.Label = global::Mono.Unix.Catalog.GetString ("Clear log");
			this.table1.Add (this.btnClear);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.table1 [this.btnClear]));
			w46.LeftAttach = ((uint)(2));
			w46.RightAttach = ((uint)(3));
			w46.XOptions = ((global::Gtk.AttachOptions)(4));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.btnReadAll = new global::Gtk.Button ();
			this.btnReadAll.CanFocus = true;
			this.btnReadAll.Name = "btnReadAll";
			this.btnReadAll.UseUnderline = true;
			this.btnReadAll.Label = global::Mono.Unix.Catalog.GetString ("Read all");
			this.table1.Add (this.btnReadAll);
			global::Gtk.Table.TableChild w47 = ((global::Gtk.Table.TableChild)(this.table1 [this.btnReadAll]));
			w47.XOptions = ((global::Gtk.AttachOptions)(4));
			w47.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.btnReadReg = new global::Gtk.Button ();
			this.btnReadReg.CanFocus = true;
			this.btnReadReg.Name = "btnReadReg";
			this.btnReadReg.UseUnderline = true;
			this.btnReadReg.Label = global::Mono.Unix.Catalog.GetString ("Read register");
			this.table1.Add (this.btnReadReg);
			global::Gtk.Table.TableChild w48 = ((global::Gtk.Table.TableChild)(this.table1 [this.btnReadReg]));
			w48.TopAttach = ((uint)(1));
			w48.BottomAttach = ((uint)(2));
			w48.XOptions = ((global::Gtk.AttachOptions)(4));
			w48.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.btnWriteReg = new global::Gtk.Button ();
			this.btnWriteReg.CanFocus = true;
			this.btnWriteReg.Name = "btnWriteReg";
			this.btnWriteReg.UseUnderline = true;
			this.btnWriteReg.Label = global::Mono.Unix.Catalog.GetString ("Write register");
			this.table1.Add (this.btnWriteReg);
			global::Gtk.Table.TableChild w49 = ((global::Gtk.Table.TableChild)(this.table1 [this.btnWriteReg]));
			w49.TopAttach = ((uint)(2));
			w49.BottomAttach = ((uint)(3));
			w49.XOptions = ((global::Gtk.AttachOptions)(4));
			w49.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblReadRes = new global::Gtk.Label ();
			this.lblReadRes.Name = "lblReadRes";
			this.table1.Add (this.lblReadRes);
			global::Gtk.Table.TableChild w50 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblReadRes]));
			w50.TopAttach = ((uint)(1));
			w50.BottomAttach = ((uint)(2));
			w50.LeftAttach = ((uint)(2));
			w50.RightAttach = ((uint)(3));
			w50.XOptions = ((global::Gtk.AttachOptions)(4));
			w50.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.spbReadReg = new global::Gtk.SpinButton (0, 127, 1);
			this.spbReadReg.CanFocus = true;
			this.spbReadReg.Name = "spbReadReg";
			this.spbReadReg.Adjustment.PageIncrement = 10;
			this.spbReadReg.ClimbRate = 1;
			this.spbReadReg.Numeric = true;
			this.table1.Add (this.spbReadReg);
			global::Gtk.Table.TableChild w51 = ((global::Gtk.Table.TableChild)(this.table1 [this.spbReadReg]));
			w51.TopAttach = ((uint)(1));
			w51.BottomAttach = ((uint)(2));
			w51.LeftAttach = ((uint)(1));
			w51.RightAttach = ((uint)(2));
			w51.XOptions = ((global::Gtk.AttachOptions)(4));
			w51.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.spbWriteReg = new global::Gtk.SpinButton (0, 127, 1);
			this.spbWriteReg.CanFocus = true;
			this.spbWriteReg.Name = "spbWriteReg";
			this.spbWriteReg.Adjustment.PageIncrement = 10;
			this.spbWriteReg.ClimbRate = 1;
			this.spbWriteReg.Numeric = true;
			this.table1.Add (this.spbWriteReg);
			global::Gtk.Table.TableChild w52 = ((global::Gtk.Table.TableChild)(this.table1 [this.spbWriteReg]));
			w52.TopAttach = ((uint)(2));
			w52.BottomAttach = ((uint)(3));
			w52.LeftAttach = ((uint)(1));
			w52.RightAttach = ((uint)(2));
			w52.XOptions = ((global::Gtk.AttachOptions)(4));
			w52.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.spbWriteVal = new global::Gtk.SpinButton (0, 65535, 1);
			this.spbWriteVal.CanFocus = true;
			this.spbWriteVal.Name = "spbWriteVal";
			this.spbWriteVal.Adjustment.PageIncrement = 10;
			this.spbWriteVal.ClimbRate = 1;
			this.spbWriteVal.Numeric = true;
			this.table1.Add (this.spbWriteVal);
			global::Gtk.Table.TableChild w53 = ((global::Gtk.Table.TableChild)(this.table1 [this.spbWriteVal]));
			w53.TopAttach = ((uint)(2));
			w53.BottomAttach = ((uint)(3));
			w53.LeftAttach = ((uint)(2));
			w53.RightAttach = ((uint)(3));
			w53.XOptions = ((global::Gtk.AttachOptions)(4));
			w53.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox7.Add (this.table1);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.table1]));
			w54.Position = 0;
			w54.Expand = false;
			w54.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.txvLog = new global::Gtk.TextView ();
			this.txvLog.CanFocus = true;
			this.txvLog.Name = "txvLog";
			this.GtkScrolledWindow.Add (this.txvLog);
			this.hbox7.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.GtkScrolledWindow]));
			w56.Position = 1;
			this.notebook2.Add (this.hbox7);
			global::Gtk.Notebook.NotebookChild w57 = ((global::Gtk.Notebook.NotebookChild)(this.notebook2 [this.hbox7]));
			w57.Position = 2;
			// Notebook tab
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Test");
			this.notebook2.SetTabLabel (this.hbox7, this.label5);
			this.label5.ShowAll ();
			this.hbox2.Add (this.notebook2);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.notebook2]));
			w58.Position = 0;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w59.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("label2");
			this.vbox2.Add (this.label3);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label3]));
			w60.Position = 1;
			w60.Expand = false;
			w60.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.statusbar1 = new global::Gtk.Statusbar ();
			this.statusbar1.Name = "statusbar1";
			this.statusbar1.Spacing = 6;
			this.vbox2.Add (this.statusbar1);
			global::Gtk.Box.BoxChild w61 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.statusbar1]));
			w61.Position = 2;
			w61.Expand = false;
			w61.Fill = false;
			this.vbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w62 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox2]));
			w62.Position = 2;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 636;
			this.DefaultHeight = 594;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.tbnQuit.Clicked += new global::System.EventHandler (this.OnTbnQuitClicked);
			this.tbnConnect.Toggled += new global::System.EventHandler (this.OnTbnConnectToggled);
			this.spbReadReg.ValueChanged += new global::System.EventHandler (this.OnSpbReadRegValueChanged);
			this.btnWriteReg.Clicked += new global::System.EventHandler (this.OnBtnWriteRegClicked);
			this.btnReadReg.Clicked += new global::System.EventHandler (this.OnBtnReadRegClicked);
			this.btnReadAll.Clicked += new global::System.EventHandler (this.OnBtnReadAllClicked);
			this.btnClear.Clicked += new global::System.EventHandler (this.OnBtnClearClicked);
		}
	}
}
