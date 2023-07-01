using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Framework;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;


public class Test : MonoBehaviour
{

    [SerializeField]
    ImageLoader image;

    // Start is called before the first frame update
    void Start()
    {
        Managers.Data.UserData.DataSet("mittan", 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Managers.Data.UserData.UserName);
            var name = "Sprites/testImage";
            //Debug.Log(Resources.LoadAll("Sprites"));
            //image.Image.sprite = Resources.Load(name, typeof(Sprite)) as Sprite;
            image.LoadLoaclAsync(name).Forget();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene("Main2");
        }
    }
}
