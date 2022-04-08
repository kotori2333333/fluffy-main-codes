using System.Collections;
using System.Linq;
using UnityEngine;

namespace Febucci.UI.Examples
{
    [AddComponentMenu("")]
    public class InitTutorialManager : MonoBehaviour

    { 
        public TextAnimatorPlayer textAnimatorPlayer;
        public string[] lines;
        public static int TTindex;
        public int[] autos = new int[] {0,1,2,3,5,7,9,11,13};
        public static bool stampReached;
        public static bool stampOnHand;
        public static bool stampStart;
        public static bool stampEnough;
        public static bool petted;
        public static bool petEnough;
        public static bool flySpawn;
        public static bool petMaxed;

        public float camClose = 2.4f;
        public float test;

        public Transform holder;
        public Transform cam;
        public GameObject table;
        public GameObject monster;
        public float monsterSpeed = 0.1f;
        public float tableSpeed = 0.1f;
        private bool tableMove = false;

        private void Awake()
        {
            UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
        }

        private void Start()
        {
     
   
            startTutorial();
        }

        private void Update()
        {
            Debug.Log(stampEnough);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (autos.Contains(TTindex))
                {
                    nextLine();
                }
            }

            if (holder.rotation.y<0.15 && holder.rotation.y>-0.15)
            {
                if(TTindex == 4)
                {
                    nextLine();
                }
            }

            if (cam.localPosition.z<camClose)
            {
                if (TTindex == 6)
                {
                    nextLine();
                }
            }

            if (stampReached)
            {
                if(TTindex == 8)
                {
                    nextLine();
                }
            }

            if (stampOnHand)
            {
                if (TTindex == 10)
                {
                    nextLine();
                }
            }

            if (stampStart)
            {
                if(TTindex == 12)
                {
                    nextLine();
                }
            }


            if (stampEnough)
            {
                if (TTindex == 13)
                {
                    nextLine();
                }
            }

            if(TTindex == 15)
            {
                StartCoroutine(TableWait());
                if (tableMove)
                {
                    table.transform.position += new Vector3(0, tableSpeed, 0);

                }
            }

            if(TTindex == 16)
            {
                Destroy(table);
            }

            if(TTindex == 19)
            {
                monster.transform.position = new Vector3(-9, 1.7f, 4.8f);
            }

            if(TTindex == 20 || TTindex == 21)
            {
                monster.transform.position = Vector3.MoveTowards(monster.transform.position, new Vector3(-0.27f, 1.5f, 5.12f), monsterSpeed);
            }

            if(TTindex == 26)
            {
                if (petted)
                {
                    nextLine();
                }
            }


            if (TTindex == 27)
            {
                if (petEnough)
                {
                    nextLine();
                }
            }

            if(TTindex == 28)
            {
                flySpawn = true;
            }

            if(TTindex == 30)
            {
                if (petMaxed)
                {
                    nextLine();
                }
            }
        }

        IEnumerator TableWait()
        {
            yield return new WaitForSeconds(1);
            tableMove = true;
        }

        void startTutorial()
        {
            TTindex = 0;
            TypeLine();
        }

        void TypeLine()
        {
            textAnimatorPlayer.ShowText(lines[TTindex]);
        }

        void nextLine()
        {
            if (TTindex < lines.Length-1)
            {
                TTindex++;
                TypeLine();
            }
        }
  


    }
}