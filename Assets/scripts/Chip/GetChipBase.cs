    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class GetChipBase : MonoBehaviour, IPointerClickHandler
    {
        public int type;
        public int order;
        public GetChipBase(int type, int order)
        {
            this.type = type;
            this.order = order;
        }
        // Start is called before the first frame update
        void Start()
        {
            List<ParticleSystem> partis = new List<ParticleSystem>();
            for (int i = 0; i < transform.childCount; i++)
            {
                ParticleSystem a = transform.GetChild(i).GetComponent<ParticleSystem>();
                if (a != null)
                {
                    partis.Add(a);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            ;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            gameManager.instance.GetChip(type, order);
            ChoosePanel.instance.Exit();
        }


    }
