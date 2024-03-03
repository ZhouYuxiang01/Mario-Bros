using System.Collections;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public GameManager gameManager;
    public float speed = 2f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveTo(flag, flag.position + Vector3.down*8));
            StartCoroutine(LevelCompleteSequence(other.transform));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        player.GetComponent<MarioController>().enabled = false;
        player.gameObject.SetActive(false);
        gameManager.GameWin();
        yield return new WaitForSeconds(2f);
        
    }

    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
        yield return null;
        subject.position = position;
    }

}
