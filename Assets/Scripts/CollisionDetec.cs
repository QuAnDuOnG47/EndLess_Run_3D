using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetec : MonoBehaviour
{
   

    public float animationDuration = 3f; // Thoi gian hieu ung
    public float panelDisplayTime = 3f;  // Thoi gian hien thi Game Over Panel
    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            GetComponent<Collider>().enabled = false;
            
           
            StartCoroutine(CollisionFX(other.gameObject));
        }
    }

    IEnumerator CollisionFX(GameObject playerObject)
    {
        
        PlayerMovement movementScript = playerObject.GetComponent<PlayerMovement>();
        Animator playerAnimator = playerObject.GetComponentInChildren<Animator>(); // Hoặc GetComponentInChildren<Animator>() nếu Animator ở vật thể con

        
        AudioSource collisionEffect = GetComponent<AudioSource>();
        
        
        GameObject collisionCam = GameObject.FindWithTag("CollisionCam");
        GameObject canvasObject = GameObject.Find("Canvas"); // Giả sử Canvas tên là "Canvas"
        GameObject gameOverPanel = null;
        
        
       

        if (movementScript != null)
            movementScript.enabled = false;
        
        if (playerAnimator != null)
            playerAnimator.SetTrigger("Collision");
        
        if (collisionEffect != null)
            collisionEffect.Play();
        
        if (collisionCam != null)
            collisionCam.GetComponent<Animator>().Play("CollisonCam");


        yield return new WaitForSeconds(animationDuration);

        if (canvasObject != null)
    {
        
        Transform panelTransform = canvasObject.transform.Find("GameOverPanel");
        if (panelTransform != null)
        {
            gameOverPanel = panelTransform.gameObject;
        }
    }
        
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); 
        
        yield return new WaitForSeconds(panelDisplayTime);
        
        SceneManager.LoadScene(4);
    }
}
