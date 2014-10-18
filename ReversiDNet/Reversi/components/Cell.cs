using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLibDNet.Drawing.Shapes;
using GLibDNet.Drawing;
using Reversi.core;

namespace Reversi.components
{
	class Cell : Rectangle
	{
		/// <summary>
		/// 石
		/// </summary>
		private TurnEnum stone;

		/// <summary>
		/// 石の表示
		/// </summary>
		private Circle stoneView;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <param name="w">横幅</param>
		/// <param name="h">縦幅</param>
		public Cell( int x, int y, int w, int h )
			: base( x, y, w, h )
		{
			this.stoneView = new Circle( x, y, w, h );
			this.setStone( TurnEnum.NONE );
		}

		/// <summary>
		/// 石をセットします。
		/// </summary>
		/// <param name="stone">石</param>
		public void setStone( TurnEnum stone )
		{
			this.stone = stone;

			switch( stone )
			{
				case TurnEnum.FIRST :
					this.stoneView.brush = DrawUtil.GetBrush( DrawUtil.ColorType.BLACK );
					break;
				case TurnEnum.SECOND :
					this.stoneView.brush = DrawUtil.GetBrush( DrawUtil.ColorType.WHITE );
					break;
			}
		}

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="g">描画先</param>
		/// <returns>描画後の振る舞い</returns>
		public override GLibDNet.Update.DrawResultEnum drawMyself( System.Drawing.Graphics g )
		{
			base.drawMyself( g );

			if( this.stone != TurnEnum.NONE )
			{
				this.stoneView.drawMyself( g );
			}

			return GLibDNet.Update.DrawResultEnum.ONCE;
		}
	}
}
