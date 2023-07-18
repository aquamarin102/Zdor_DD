using UnityEngine;

public class TriggerAbimatorControl : MonoBehaviour
{
    public string NameTrigger;
    private string Player = "Player";
    public GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Player)
        {
            obj.GetComponent<Animator>().SetTrigger(NameTrigger);
        }
    }
}
