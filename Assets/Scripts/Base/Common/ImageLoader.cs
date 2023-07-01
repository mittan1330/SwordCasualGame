using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(Image))]
public class ImageLoader : MonoBehaviour
{

    [SerializeField]
    private Sprite _faitalLoadImage;

    public Image Image;


    private void Awake()
    {
        Image = GetComponent<Image>();
    }
    /// <summary>
    /// AssetBundleを用いてLoadができるようにする
    /// </summary>
    //public async UniTask LoadAsync(string assetBundleName, string assetName,CancellationToken ct = default)
    //{
    //    ct.ThrowIfCancellationRequested();
    //    var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct, this.GetCancellationTokenOnDestroy());

    //    try
    //    {

    //    }
    //    catch
    //    {
    //        Debug.LogError($"cannot load image:{assetBundleName}->{assetName}");
    //        Image.sprite = _faitalLoadImage;
    //    }
    //}

    public async UniTask LoadLoaclAsync(string assetName, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct, this.GetCancellationTokenOnDestroy());

        var loadObject = await Resources.LoadAsync(assetName, typeof(Sprite)).WithCancellation(cancellationTokenSource.Token) as Sprite;

        Image.sprite = loadObject != null ? loadObject as Sprite : _faitalLoadImage;
    }
}
