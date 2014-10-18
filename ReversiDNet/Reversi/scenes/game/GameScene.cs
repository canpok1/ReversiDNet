using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Update;
using GLibDNet.Util;
using System.Drawing;
using GLibDNet.Key;
using Reversi.core;
using Reversi.ai;
using Reversi.components;
using System.Threading.Tasks;

namespace Reversi.scenes.game
{
	/// <summary>
	/// ゲーム画面を表すクラスです。
	/// </summary>
	class GameScene : Scene
	{
		/// <summary>
		/// ゲームの途中経過を表示する時間(ms)
		/// </summary>
		private const int DISPLAY_TIME = 200;

		/// <summary>
		/// ロガー
		/// </summary>
		private Logger logger;

		/// <summary>
		/// 背景色
		/// </summary>
		private Color backColor;

		/// <summary>
		/// ゲームの表示領域
		/// </summary>
		private GameArea area;

		/// <summary>
		/// ゲームマネージャー
		/// </summary>
		private GameManager gameManager;

		/// <summary>
		/// ゲームループ用のタスク
		/// </summary>
		private Task gameTask;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="param">パラメータ</param>
		/// <exception cref="ArgumentNullException">引数がnullの場合</exception>
		/// <exception cref="ArgumentException">引数がReversiParametersでない場合</exception>
		public GameScene( SceneParameter param )
			: base( param )
		{
			this.logger = LoggerGetter.getInstance().getLogger(
							System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
			this.backColor = Color.Aqua;

			if( param == null )
			{
				throw new ArgumentNullException( "param", "Nullにはできません。" );
			}
			if( ( param is ReversiParameters ) == false )
			{
				throw new ArgumentException( "param", "引数はReversiParametersでなければなりません。" );
			}

			this.area = new GameArea( 10, 10, 489, 489 );
			this.gameManager = new GameManager();
			this.gameTask = null;
		}


		/// <summary>
		/// 更新カテゴリ
		/// </summary>
		/// <returns>更新カテゴリ</returns>
		public override Byte getCategory()
		{
			return 0;
		}

		/// <summary>
		/// 更新レベル
		/// </summary>
		/// <returns>更新レベル</returns>
		public override Byte getUpdateLevel()
		{
			return 0;
		}

		/// <summary>
		/// 並列更新
		/// </summary>
		public override void parallelUpdate()
		{
			this.area.setMouseCursor( InputManager.getInstance().getMousePoint() );
		}

		/// <summary>
		/// 同期更新
		/// </summary>
		/// <returns>更新後の振る舞い</returns>
		public override UpdatedStateEnum syncronousUpdate()
		{
			UpdatedStateEnum result = UpdatedStateEnum.Continue;

			if( InputManager.getInstance().isOneTimeModeKeyPressed( InputManager.KeyCodeEnum.ESC )
				== true )
			{
				result = UpdatedStateEnum.Remove;
			}

			return result;
		}

		/// <summary>
		/// ゲーム画面の準備
		/// </summary>
		/// <returns>true:準備終了 false:準備中</returns>
		public override bool setup()
		{
			ReversiParameters param = (ReversiParameters)getParam();

			Player p1, p2;

			if( param.getP1Level() == 0 )
			{
				p1 = PlayerFactory.create( this.area );
			}
			else
			{
				p1 = PlayerFactory.create( param.getP1Level() );
			}

			if( param.getP2Level() == 0 )
			{
				p2 = PlayerFactory.create( this.area );
			}
			else
			{
				p2 = PlayerFactory.create( param.getP2Level() );
			}

			Board board = new Board();
			board.setInitialPlacement();
			this.area.viewBoard( board );

			this.gameTask = Task.Factory.StartNew(
				() =>
				{
					this.gameManager.startGame( p1, p2, this.area, DISPLAY_TIME );
				} );

			return true;
		}

		/// <summary>
		/// ゲーム画面の描画
		/// </summary>
		/// <param name="g">描画先</param>
		/// <returns>描画後の振る舞い</returns>
		public override DrawResultEnum drawMyself( Graphics g )
		{
			g.Clear( this.backColor );
			this.area.drawMyself( g );
			return DrawResultEnum.ONCE;
		}

		/// <summary>
		/// シーンのリソースを開放
		/// </summary>
		public override void cleanup()
		{
		}
	}
}
