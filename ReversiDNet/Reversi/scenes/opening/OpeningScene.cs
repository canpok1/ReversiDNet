using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Update;
using System.Drawing;
using GLibDNet.Util;
using GLibDNet.Drawing.Elements;
using GLibDNet.Key;

namespace Reversi.scenes.opening
{
	/// <summary>
	/// オープニング画面を表すクラスです。
	/// </summary>
	class OpeningScene : Scene
	{
		/// <summary>
		/// ロガー
		/// </summary>
		private Logger logger;

		/// <summary>
		/// 背景色
		/// </summary>
		private Color backColor;

		/// <summary>
		/// テキスト領域
		/// </summary>
		private TextViewer text;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="param"></param>
		public OpeningScene( SceneParameter param ) : base( param )
		{
			this.logger = LoggerGetter.getInstance().getLogger(
							System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
			this.backColor = Color.White;
			this.text = new TextViewer( 20, 20, "オープニング" );
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
		}

		/// <summary>
		/// 同期更新
		/// </summary>
		/// <returns>更新後の振る舞い</returns>
		public override UpdatedStateEnum syncronousUpdate()
		{
			UpdatedStateEnum result = UpdatedStateEnum.Continue;

			if( InputManager.getInstance().isOneTimeModeKeyPressed( InputManager.KeyCodeEnum.ML )
				== true )
			{
				ReversiParameters param = new ReversiParameters( 1, 1 );
				SceneSwitcher.swtichScene( ReversiSceneFactory.GAME, param );
				result = UpdatedStateEnum.Remove;
			}

			return result;
		}

		/// <summary>
		/// オープニング画面の準備
		/// </summary>
		/// <returns>true:準備終了 false:準備中</returns>
		public override Boolean setup()
		{
			return true;
		}

		/// <summary>
		/// オープニング画面の描画
		/// </summary>
		/// <param name="g"></param>
		public override DrawResultEnum drawMyself( Graphics g )
		{
			g.Clear( this.backColor );
			this.text.drawMyself( g );

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
