using System;
using Gtk;

namespace maxim_11311
{
	public class Utilities
	{
		private Gtk.Widget gtkw = null;

		public static void MsgBox(string Msg)
		{
			MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, Msg);
			md.Run ();
			md.Destroy();
		}


		public static Gtk.Widget parse_widget(Gtk.Container parent, string name)
		{

			foreach (Gtk.Widget child in parent.AllChildren)
			{
				if (child.Name.Equals( name ) )
				{
					return child;
				}
			}
			return null;
		}

		public static Gtk.Widget parse_widget_tree(Gtk.Container parent, string name)
		{
			
			foreach (Gtk.Widget child in parent.AllChildren)
			{
				if (child is Gtk.Container)
				{
					Gtk.Container container = child as Gtk.Container;
					if( parse_widget_tree(container, name) != null )
						return child;
				}
				else if (child.Name.Equals( name ) )
				{
					return child;
				}
			}
			return null;
		}

	}
}

