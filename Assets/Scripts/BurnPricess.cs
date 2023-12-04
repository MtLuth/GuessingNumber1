using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnPricess : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra xem đối tượng nào đã va chạm với đối tượng hiện tại
        if (collision.gameObject.tag == "Alchemy")
        {
            // Xử lý khi có va chạm với đối tượng có tag là "OtherObjectTag"
            Debug.Log("Collision with OtherObject detected!");
        }
    }
}
