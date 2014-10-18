using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLibDNet;
using Reversi.scenes;
using GLibDNet.Util;
using Reversi.ai;
using GLibDNet.Config;

namespace Reversi
{
	/// <summary>
	/// トップメニューのクラスです。
	/// </summary>
	public partial class TopMenu : Form
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TopMenu()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ゲームの初期設定
		/// ボタンを押した時に呼ばれます。
		/// </summary>
		/// <param name="p1">先手プレイヤーの番号</param>
		/// <param name="p2">後手プレイヤーの番号</param>
		private void GameSetup( int p1, int p2 )
		{
			try
			{
				GameProperties properties = new GameProperties(
												ConfigUtility.getByte( "UPDATE_RATE" ),
												ConfigUtility.getByte( "REFRESH_RATE" ),
												new ReversiSceneFactory(),
												new Size(
													ConfigUtility.getInteger( "W_WIDTH" ),
													ConfigUtility.getInteger( "W_HEIGHT" ) ) );

				ReversiParameters param = new ReversiParameters( p1, p2 );

				Form form = GLib.getInstance().getFrame( properties, param );

				this.Hide();
				form.ShowDialog();
				form.Dispose();
			}
			catch( Exception ex )
			{
				System.Console.WriteLine( ex );
			}
			finally
			{
				this.Show();
			}
		}

		/// <summary>
		/// ゲーム終了ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void END_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void p1_vs_lv1_Click( object sender, EventArgs e )
		{
			this.GameSetup( PlayerFactory.HUMAN,
							PlayerFactory.RANDOM );
		}

		private void lv1_vs_p1_Click( object sender, EventArgs e )
		{
			this.GameSetup( PlayerFactory.RANDOM,
							PlayerFactory.HUMAN );
		}
	}
}
