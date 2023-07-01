using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace HyperCasualLab
{
	public class HCLBuildProcessor : IPreprocessBuildWithReport
	{
		public int callbackOrder => 0;

		public void OnPreprocessBuild(BuildReport report)
		{
			var settings = HCLSettings.Load();
			if (settings == null || !settings.IsValid)
			{
				throw new BuildFailedException("Adjust App Token が正しく設定されていません");
			}
		}
	}
}
