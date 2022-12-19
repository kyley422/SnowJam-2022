using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FallHP : EnemyHP
{
    public override IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, .3f);
        SceneManager.LoadScene("Winter");
        Destroy(gameObject);
    }
}

