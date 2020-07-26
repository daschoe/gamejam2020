using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDay : MonoBehaviour
{
  public Animator crossfade;
  public float transitionTime = 2f;
  public void NewDay ()
    {
      Debug.Log("Changing day");
      StartCoroutine(playAnimation());
    }
    IEnumerator playAnimation()
    {
      Debug.Log("playing animation");
      crossfade.SetTrigger("startCrossfade");
      yield return new WaitForSeconds(transitionTime);
      Debug.Log("New day");
      DaysCounter.instance.Add();
      gameObject.SetActive(false);

    }
}
