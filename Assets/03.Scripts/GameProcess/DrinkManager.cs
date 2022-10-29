using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    //for in 은 사용고려.
    public GameObject[] FruitList = new GameObject[3];
    public GameObject[] AlcoholList = new GameObject[4];
    //public GameObject[] SyrupList = new GameObject[2];

    //술에 담은 내용물 이걸 가지고 if문에서 판단.
    GameObject[] Element = new GameObject[2];

    /*
    public class RecipeA
    {
        public GameObject Fruit;
        public GameObject Drink;
        public SetRecipeA()
        {
            Fruit = 
        }
    }

    public class RecipeB
    {
        GameObject Fruit;
        GameObject Drink;
    }

    public class RecipeC
    {
        GameObject Fruit;
        GameObject Drink;
    }

    public class RecipeD
    {
        GameObject Fruit;
        GameObject Drink;
    }
    */

    //public List<GameObject> FruitList = new List<GameObject>();
    //public List<GameObject> AlcoholList = new List<GameObject>();
    //public List<GameObject> SyrupList = new List<GameObject>();

    /*
    class A
    {
        class B
        {

        }
    }
    */

    //재료 리스트를 생성 => 총 3개가 나와 많기 때문에 하나로 관리하기 위해서 클래스로 묶어둠.
    /*public class Ingrediant
    {
        public List<GameObject> InFruitList = FruitList;
    }*/
    //술 조합에 필요한 재료 클래스를 가진 변수를 생성(인게임에서 쓰일 유일한 Ingrediant 변수)
    //public Ingrediant ingrediant = new Ingrediant();
    //그랩 전에 트레이를 인식하고 오브젝트 생성에 편의를 주기 위해서 배열로 만들어놓음.
    //public GameObject[] IngrediantPrefabsList = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        
        //ingrediant.FruitList.Add("FruitA");
        //ingrediant.FruitList.Add("FruitB");
        //ingrediant.AlcoholList.Add("AlcoholA");
        //ingrediant.AlcoholList.Add("AlcoholB");
        //ingrediant.SyrupList.Add("SyrupA");
        //ingrediant.SyrupList.Add("SyrupB");

    }

    // Update is called once per frame
    void Update()
    {
        if(Element[0] == FruitList[0])
        {

        }
    }
}