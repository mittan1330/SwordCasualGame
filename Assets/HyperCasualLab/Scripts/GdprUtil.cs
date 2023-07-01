using System.Linq;
using UnityEngine;

namespace HyperCasualLab
{
	public static class GdprUtil
	{
		private static string[] _gdprTimeZones = new[] {
			"Europe/Dublin", // アイルランド
			"Europe/Rome", // イタリア
			"Europe/Tallinn", // エストニア
			"Europe/Vienna", // オーストリア
			"Europe/Amsterdam", // オランダ
			"Asia/Famagusta", // キプロス
			"Asia/Nicosia", // キプロス
			"Europe/Nicosia", // キプロス
			"Europe/Athens", // ギリシャ
			"Europe/Zagreb", // クロアチア
			"Europe/Stockholm", // スウェーデン
			"Europe/Madrid", // スペイン
			"Africa/Ceuta", // スペイン
			"Atlantic/Canary", // スペイン
			"Europe/Bratislava", // スロバキア
			"Europe/Ljubljana", // スロベニア
			"Europe/Prague", // チェコ
			"Europe/Copenhagen", // デンマーク
			"Europe/Berlin", // ドイツ
			"Europe/Busingen", // ドイツ
			"Europe/Budapest", // ハンガリー
			"Europe/Helsinki", // フィンランド
			"Europe/Paris", // フランス
			"Europe/Sofia", // ブルガリア
			"Europe/Brussels", // ベルギー
			"Europe/Warsaw", // ポーランド
			"Poland", // ポーランド
			"Atlantic/Azores", // ポルトガル
			"Atlantic/Madeira", // ポルトガル
			"Europe/Lisbon", // ポルトガル
			"Portugal", // ポルトガル
			"Europe/Malta", // マルタ
			"Europe/Riga", // ラトビア
			"Europe/Vilnius", // リトアニア
			"Europe/Bucharest", // ルーマニア
			"Europe/Luxembourg", // ルクセンブルク
			"Atlantic/Reykjavik", // アイスランド
			"Iceland", // アイスランド
			"Europe/Vaduz", // リヒテンシュタイン
			"Europe/Oslo", // ノルウェー
			"Europe/London", // イギリス
			"GB", // イギリス
			"GB-Eire", // イギリス
			"Europe/Belfast", // イギリス
			"Asia/Calcutta", // インド
			"Asia/Kolkata", // インド
			"America/Araguaina", // ブラジル
			"America/Bahia", // ブラジル
			"America/Belem", // ブラジル
			"America/Boa_Vista", // ブラジル
			"America/Campo_Grande", // ブラジル
			"America/Cuiaba", // ブラジル
			"America/Eirunepe", // ブラジル
			"America/Fortaleza", // ブラジル
			"America/Maceio", // ブラジル
			"America/Manaus", // ブラジル
			"America/Noronha", // ブラジル
			"America/Porto_Acre", // ブラジル
			"America/Porto_Velho", // ブラジル
			"America/Recife", // ブラジル
			"America/Rio_Branco", // ブラジル
			"America/Santarem", // ブラジル
			"America/Sao_Paulo", // ブラジル
			"Brazil/Acre", // ブラジル
			"Brazil/DeNoronha", // ブラジル
			"Brazil/East", // ブラジル
			"Brazil/West", // ブラジル
			"WET", // 西ヨーロッパ
			"CET", // 中央ヨーロッパ
			"MET", // 中央ヨーロッパ
			"EET", // 東ヨーロッパ
		};

		public static bool IsGdprTimeZone()
		{
			return IsGdprTimeZone(GetCurrentTimeZoneName());
		}

		public static bool IsGdprTimeZone(string timeZoneName)
		{
			return _gdprTimeZones.Contains(timeZoneName);
		}

		public static string GetCurrentTimeZoneName()
		{
			string timeZoneName = null;

			#if UNITY_ANDROID
			if (Application.platform == RuntimePlatform.Android)
			{
				using (var timeZoneClass = new AndroidJavaClass("java.util.TimeZone"))
				using (var timeZoneInstance = timeZoneClass.CallStatic<AndroidJavaObject>("getDefault"))
				{
					timeZoneName = timeZoneInstance.Call<string>("getID");
				}
			}
			#endif

			return timeZoneName;
		}
	}
}
