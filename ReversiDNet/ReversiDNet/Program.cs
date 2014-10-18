using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reversi.ai;
using Reversi.core;
using Reversi.io;

namespace Reversi
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine( "プログラム開始" );

			BoardPointInputter inputter = new ConsoleInputter();
			Player p1 = PlayerFactory.create( PlayerFactory.RANDOM );
			Player p2 = PlayerFactory.create( PlayerFactory.RANDOM );

			GameManager manager = new GameManager();

			GameViewer viewer = new ConsoleViewer();

			try
			{
				manager.startGame( p1, p2, viewer, 200 );
			}
			catch( Exception e )
			{
				System.Console.WriteLine( "例外発生" );
				System.Console.WriteLine( e );
			}
			System.Console.WriteLine( "プログラム終了" );
		}
	}
}
