using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Update;
using System.Drawing;
using GLibDNet.Drawing.Elements;
using GLibDNet.Util;

namespace Reversi.scenes
{
	/// <summary>
	/// ロード中の画面を表すクラスです。
	/// </summary>
	public class ReversiLoadingScene : LoadingScene
	{
		/// <summary>
		/// ロガー
		/// </summary>
		private Logger logger;

		/// <summary>
		/// テキスト領域
		/// </summary>
		private TextViewer textViewer;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="nextScene"></param>
		/// <param name="param"></param>
		public ReversiLoadingScene( Scene nextScene, SceneParameter param )
			: base( nextScene, param )
		{
			this.logger = LoggerGetter.getInstance().getLogger(
							System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
			this.textViewer = new TextViewer( 20, 20, "ロード中" );
		}

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="g"></param>
		/// <returns></returns>
		public override DrawResultEnum drawMyself( Graphics g )
		{
			g.Clear( Color.Black );
			this.textViewer.drawMyself( g );

			return DrawResultEnum.ONCE;
		}

		/// <summary>
		/// 画面の準備
		/// </summary>
		/// <returns></returns>
		public override Boolean setup()
		{
			this.logger.info( "ロード画面の準備中" );
			return true;
		}

		/// <summary>
		/// リソース開放
		/// </summary>
		public override void cleanup()
		{
			this.logger.info( "ロード画面の開放" );
		}
	}
}
