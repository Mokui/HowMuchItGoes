using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Instantiate : DefaultTrackableEventHandler
{
    public int somme;

    private List<int> billets = new List<int>();  //{500,200,100,50,20,10,5,1};
    public Transform[] prefabs = {};

    public Toggle b500; 
    public Toggle b200;
    public Toggle b100;
    public Toggle b50;
    public Toggle b20;
    public Toggle b10;
    public Toggle b5;
    public Toggle b1;
    private List<Toggle> selections;

    protected override  void OnTrackingFound()
    {
        Setup();

        int cpt = 0;
        int nbBillets = 0;
        int calc = somme;
        do
        {
            if(calc < billets[cpt]){
                nbBillets = 0;
            } else {
                nbBillets = calc / billets[cpt];
            }

            for(int i=0; i<nbBillets; i++) { 
                calc -= billets[cpt];

                Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/somme));
                Transform prefabToCreate = prefabs[0];
                for (int k = 0; k < prefabs.Length; k++)
                {
                    if(int.Parse(prefabs[k].name) == billets[cpt]){
                        prefabToCreate = prefabs[k];
                    }
                }
                Instantiate(prefabToCreate, objectPosition, Quaternion.identity);
            }
            cpt++;
        } while (calc != 0);

    }

    protected override void OnTrackingLost()
    {
        billets.Clear();
        selections.Clear();
        base.OnTrackingLost ();
    }

    private void Setup() {
        selections = new List<Toggle> {b500, b200, b100, b50, b20, b10, b5, b1};

        foreach (Toggle t in selections) {
            if (t.isOn == true) { 
                billets.Add(int.Parse(t.GetComponentInChildren<Text> ().text));
            }
        }
    }
}
