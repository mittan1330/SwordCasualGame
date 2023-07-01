using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace HyperCasualLab
{
	public class HCLMenu
	{
		private const string screenshotsDirectoryPath = "Screenshots";

		[MenuItem("HyperCasualLab/Setting")]
		public static void SelectSettingsAsset()
		{
			Selection.objects = new[] { HCLSettings.Load() };
		}

		[MenuItem("HyperCasualLab/Screenshot")]
		public static void Screenshot()
		{
			Directory.CreateDirectory(screenshotsDirectoryPath);

			string timeString = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
			string outputPath = $"{screenshotsDirectoryPath}/{timeString}.png";
			ScreenCapture.CaptureScreenshot(outputPath);
		}

		[MenuItem("HyperCasualLab/Open Screenshots Folder")]
		public static void OpenScreenshotsFolder()
		{
			EditorUtility.RevealInFinder(screenshotsDirectoryPath);
		}
	}
}
