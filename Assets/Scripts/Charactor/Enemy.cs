using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject smokePrefab;
    public int Power = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDamage(int value)
    {
        Power -= value;
        return Power > 0 ? Power : 0;
    }

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
