using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Frontend
{
    public class UIView : MonoBehaviour
    {
        [SerializeField]
        TMP_Text aText;

        [SerializeField]
        TMP_Text bText;

        public void SetALife(int life)
        {
            aText.SetText("A Unit: " + life);
        }

        public void SetBLife(int life)
        {
            bText.SetText("B Unit: " + life);
        }

        public void OnRestartButton()
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex);
        }
    }
}