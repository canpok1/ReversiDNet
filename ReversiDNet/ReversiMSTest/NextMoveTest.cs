using Reversi.ai;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Reversi.core;

namespace ReversiTest
{
    
    
    /// <summary>
    ///NextMoveTest のテスト クラスです。すべての
    ///NextMoveTest 単体テストをここに含めます
    ///</summary>
	[TestClass()]
	public class NextMoveTest
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
		///NextMove コンストラクター のテスト
		///コンストラクタに与えた座標が正しくセットされていることをテスト
		///</summary>
		[TestMethod()]
		public void NextMoveConstructorTest1()
		{
			BoardPoint p = new BoardPoint( 1, 1 );
			NextMove target = new NextMove( p );
			Assert.IsTrue( target.getPoint().Equals( p ) );
		}

		/// <summary>
		///NextMove コンストラクター のテスト
		///nullをコンストラクタに与えた場合にnullがセットされることをテスト
		///</summary>
		[TestMethod()]
		public void NextMoveConstructorTest2()
		{
			NextMove target = new NextMove( null );
			Assert.IsNull( target.getPoint() );
		}

		/// <summary>
		///getPoint のテスト
		///コンストラクタで与えたオブジェクトと他のオブジェクトを返すことをテスト
		///</summary>
		[TestMethod()]
		public void getPointTest()
		{
			BoardPoint expect = new BoardPoint( 2, 2 );
			NextMove target = new NextMove( expect );
			BoardPoint actual = target.getPoint();
			Assert.AreNotSame( expect, actual );
		}
	}
}
