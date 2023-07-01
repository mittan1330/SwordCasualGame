using UnityEngine;

namespace HyperCasualLab
{
	public class HCLSettings : ScriptableObject
	{
		[SerializeField] private string adjustAppToken;

		private const string loadPath = nameof(HCLSettings);
		private const string basePath = "Assets/HyperCasualLab/Resources";

		public string AdjustAppToken => adjustAppToken;

		public bool IsValid => adjustAppToken != null && adjustAppToken.Length == 12;

		public static HCLSettings Load()
		{
			return Resources.Load<HCLSettings>(loadPath);
		}

		#if UNITY_EDITOR
		[UnityEditor.InitializeOnLoadMethod]
		private static void CreateIfNeeded()
		{
			var instance = Load();
			if (instance != null) return;

			Debug.Log($"{nameof(HCLSettings)}のインスタンスを作成します");

			System.IO.Directory.CreateDirectory(basePath);
			instance = CreateInstance<HCLSettings>();
			var path = $"{basePath}/{loadPath}.asset";
			UnityEditor.AssetDatabase.CreateAsset(instance, path);
		}
		#endif
	}
}
