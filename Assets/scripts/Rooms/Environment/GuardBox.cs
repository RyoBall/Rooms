using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardBox : MonoBehaviour
{
    [SerializeField] private GameObject exp;
    [SerializeField] private float CorrectingFactor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        expdrop(Random.Range(45, 60));
        Player.instance.energy += 15;
        for (int i = 0; i < 3; i++)
        {
            int type = Random.Range(1, 4);
            gameManager.instance.GetChipButton(type, Random.Range(0, gameManager.instance.chipsDic[type].Count), i);
        }
        ChoosePanel.instance.Enter();
        Destroy(gameObject);
    }
    public void expdrop(int nums)
    {
        for (int i = 0; i < nums; i++)
        {
            exp dexp = Instantiate(exp, transform.position + new Vector3(Random.Range(-CorrectingFactor, CorrectingFactor), Random.Range(-CorrectingFactor, CorrectingFactor), 0), Quaternion.identity).GetComponent<exp>();
            dexp.active = true;
        }
    }
    private void OnMouseEnter()
    {
        NameTex.instance.TMP_Text.text = "禁闭盒";
        DescriptionTex.instance.TMP_Text.text = "给予大量经验，能源，模块";
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
