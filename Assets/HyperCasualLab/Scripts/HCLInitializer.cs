using com.adjust.sdk;
using UnityEngine;

namespace HyperCasualLab
{
	public static class HCLInitializer
	{
		[RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			var settings = HCLSettings.Load();
			if (settings == null || !settings.IsValid)
			{
				Debug.LogWarning("Failed to initialize Adjust.");
				return;
			}

			if (Application.isEditor || GdprUtil.IsGdprTimeZone()) return;

			Debug.Log("Initialize Adjust");

			new GameObject(nameof(Adjust), typeof(Adjust));

			AdjustConfig config = new AdjustConfig(settings.AdjustAppToken, AdjustEnvironment.Production);
			Adjust.start(config);
		}
	}
}
