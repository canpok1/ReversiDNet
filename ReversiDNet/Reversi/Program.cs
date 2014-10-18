using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet;
using GLibDNet.Util;
using GLibDNet.Config;
using System.Drawing;
using Reversi.scenes;
using System.Windows.Forms;
using Reversi;

namespace ReversiGui
{
	class Program
	{
		static void Main( string[] args )
		{
			System.Console.WriteLine( "プログラム開始" );

			GLib engine = GLib.getInstance(
							new StandardLoggerFactory() );

			ConfigUtility.load( null );

			Application.Run( new TopMenu() );

			System.Console.WriteLine( "プログラム終了" );
		}
	}
}
