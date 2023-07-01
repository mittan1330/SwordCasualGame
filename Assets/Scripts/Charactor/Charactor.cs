using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charactor : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject smokePrefab;
    public Text powerText;

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(0.5f);
        var smoke = Instantiate(smokePrefab);
        smoke.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
}
