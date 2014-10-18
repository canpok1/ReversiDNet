using Reversi.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReversiTest
{
    
    
    /// <summary>
    ///BoardPointTest のテスト クラスです。すべての
    ///BoardPointTest 単体テストをここに含めます
    ///</summary>
	[TestClass()]
	public class BoardPointTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///現在のテストの実行についての情報および機能を
		///提供するテスト コンテキストを取得または設定します。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region 追加のテスト属性
		// 
		//テストを作成するときに、次の追加属性を使用することができます:
		//
		//クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//各テストを実行する前にコードを実行するには、TestInitialize を使用
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//各テストを実行した後にコードを実行するには、TestCleanup を使用
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///setY のテスト
		///Y座標を設定できることをテスト
		///</summary>
		[TestMethod()]
		public void setYTest1()
		{
			BoardPoint target = new BoardPoint( 0, 0 );
			int y = 0;	// 座標の最小値
			target.setY( y );
			Assert.IsTrue( y == target.getY() );
			y = Board.HEIGHT - 1;	// 座標の最大値
			target.setY( y );
			Assert.IsTrue( y == target.getY() );
		}

		/// <summary>
		/// setY のテスト
		/// Y座標の最大値より大きい座標をセットできないことをテスト
		/// </summary>
		[TestMethod()]
		[ExpectedException(typeof(System.ArgumentOutOfRangeException))]
		public void setYTest2()
		{
			BoardPoint target = new BoardPoint( 0, 0 );
			int y = Board.HEIGHT;
			target.setY( y );
		}

		/// <summary>
		/// setY のテスト
		/// Y座標の最小値より小さい座標をセットできないことをテスト
		/// </summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentOutOfRangeException ) )]
		public void setYTest3()
		{
			BoardPoint target = new BoardPoint( 0, 0 );
			int y = -1;
			target.setY( y );
		}

		/// <summary>
		///setX のテスト
		///X座標の値を設定できるかテスト
		///</summary>
		[TestMethod()]
		public void setXTest1()
		{
			BoardPoint target = new BoardPoint( 0, 0 );
			int x = 0; // X座標の最小値
			target.setX( x );
			Assert.IsTrue( x == target.getX() );
			x = Board.WIDTH - 1; // X座標の最大値
			target.setX( x );
			Assert.IsTrue( x == target.getX() );
		}

		/// <summary>
		///setX のテスト
		///X座標の最大値より大きい値を設定できないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentOutOfRangeException ) )]
		public void setXTest2()
		{
			BoardPoint target = new BoardPoint( 0, 0 );
			int x = Board.WIDTH; // X座標の最大値より大きい値
			target.setX( x );
		}

		/// <summary>
		///setX のテスト
		///X座標の最大値より小さい値を設定できないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentOutOfRangeException ) )]
		public void setXTest3()
		{
			BoardPoint target = new BoardPoint( 0, 0 );
			int x = -1; // X座標の最小値より小さい値
			target.setX( x );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタで与えた値が座標としてセットされていることをテスト
		///</summary>
		[TestMethod()]
		public void BoardPointConstructorTest1()
		{
			int x = 0;
			int y = 0;
			BoardPoint target = new BoardPoint( x, y );
			Assert.IsTrue( x == target.getX() );
			Assert.IsTrue( y == target.getY() );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタに与えたインスタンスと同じ座標のインスタンスができているかをテスト
		///</summary>
		[TestMethod()]
		public void BoardPointConstructorTest2()
		{
			BoardPoint original = new BoardPoint( 0, 0 );
			BoardPoint target = new BoardPoint( original );
			Assert.IsTrue( original.getX() == target.getX() );
			Assert.IsTrue( original.getY() == target.getY() );
			Assert.AreNotSame( original, target );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタにボード外のX座標を与えられないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(System.ArgumentOutOfRangeException))]
		public void BoardPointConstructorTest3()
		{
			BoardPoint original = new BoardPoint( -1, 0 );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタにボード外のX座標を与えられないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentOutOfRangeException ) )]
		public void BoardPointConstructorTest4()
		{
			BoardPoint original = new BoardPoint( Board.WIDTH, 0 );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタにボード外のY座標を与えられないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentOutOfRangeException ) )]
		public void BoardPointConstructorTest5()
		{
			BoardPoint original = new BoardPoint( 0, -1 );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタにボード外のY座標を与えられないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentOutOfRangeException ) )]
		public void BoardPointConstructorTest6()
		{
			BoardPoint original = new BoardPoint( 0, Board.HEIGHT );
		}

		/// <summary>
		///BoardPoint コンストラクター のテスト
		///コンストラクタにNULLを与えられないことをテスト
		///</summary>
		[TestMethod()]
		[ExpectedException( typeof( System.ArgumentNullException ) )]
		public void BoardPointConstructorTest7()
		{
			BoardPoint original = new BoardPoint( null );
		}

		/// <summary>
		/// Equals のテスト
		/// ２つのインスタンスが同じ値の時にtrueを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest1()
		{
			int x = 0;
			int y = 0;
			BoardPoint target1 = new BoardPoint( x, y );
			BoardPoint target2 = new BoardPoint( x, y );

			Assert.AreNotSame( target1, target2 );
			Assert.IsTrue( target1.Equals( target2 ) );
			Assert.IsTrue( target2.Equals( target1 ) );
		}

		/// <summary>
		/// Equals のテスト
		/// ２つのインスタンスが異なる値の時にfalseを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest2()
		{
			int x = 0;
			int y = 0;
			BoardPoint target1 = new BoardPoint( x, y );
			BoardPoint target2 = new BoardPoint( x + 1, y );

			Assert.AreNotEqual( target1, target2 );
			Assert.IsFalse( target1.Equals( target2 ) );
			Assert.IsFalse( target2.Equals( target1 ) );
		}

		/// <summary>
		/// Equals のテスト
		/// nullを与えた時にfalseを返すかをテスト
		/// </summary>
		[TestMethod()]
		public void EqualsTest3()
		{
			BoardPoint target1 = new BoardPoint( 0, 0 );
			Assert.IsFalse( target1.Equals( null ) );
		}
	}
}
