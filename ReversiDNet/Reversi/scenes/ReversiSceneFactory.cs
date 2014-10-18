using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Update;

namespace Reversi.scenes
{
	/// <summary>
	/// リバーシ用のシーンを生成するクラスです。
	/// </summary>
	public class ReversiSceneFactory : SceneFactory
	{
		public const int GAME = 0;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ReversiSceneFactory()
		{
		}

		/// <summary>
		/// シーンを生成します。
		/// </summary>
		/// <param name="sceneNo">生成するシーンの番号</param>
		/// <param name="param">パラメータ</param>
		/// <returns>生成したシーン</returns>
		public Scene create( int sceneNo, SceneParameter param )
		{
			switch( sceneNo )
			{
				case GAME :
					return new game.GameScene( param );
			}

			throw new ArgumentOutOfRangeException( "sceneNo", "対応するシーンがありません。" );
		}

		/// <summary>
		/// LoadingSceneを生成します。
		/// </summary>
		/// <param name="nextScene">次に準備をするシーン</param>
		/// <returns>生成したシーン</returns>
		public LoadingScene createLoadingScene( Scene nextScene )
		{
			return new ReversiLoadingScene( nextScene, null );
		}
	}
}
