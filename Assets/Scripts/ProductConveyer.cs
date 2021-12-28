using UnityEngine;

public class ProductConveyer : MonoBehaviour
{
    [SerializeField] float beltSpeed = 15f;
    [SerializeField] Transform conveyer;

    private void OnCollisionStay(Collision other)
    {
        print(other.gameObject.tag);
        if(other.gameObject.tag != "Product") return;
        other.transform.position += conveyer.transform.forward * beltSpeed * Time.deltaTime;    
    }
}
