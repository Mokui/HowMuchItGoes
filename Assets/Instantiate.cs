using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Instantiate : DefaultTrackableEventHandler
{
    public int somme;

    private int[] billets = {500,200,100,50,20,10,5,1};
    public Transform[] prefabs = {};

    protected override  void OnTrackingFound()
    {
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
                Instantiate(prefabs[cpt], objectPosition, Quaternion.identity);
            }
            cpt++;
        } while (calc != 0);

        /*switch (6)
        {
            case 0:
                for(int i = 0; i<nombre; i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(piece1, objectPosition, Quaternion.identity);
                }
                break;
            case 1:
                for(int i = 0; i<(nombre/5); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet5, objectPosition, Quaternion.identity);
                }
                break;
            case 2:
                for(int i = 0; i<(nombre/10); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet10, objectPosition, Quaternion.identity);
                }
                break;
            case 3: 
                for(int i = 0; i<(nombre/20); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet20, objectPosition, Quaternion.identity);
                }
                break;
            case 4: 
                for(int i = 0; i<(nombre/50); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet50, objectPosition, Quaternion.identity);
                }
                break;
            case 5:
                for(int i = 0; i<(nombre/100); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet100, objectPosition, Quaternion.identity);
                }
                break;
            case 6:
                for(int i = 0; i<(nombre/200); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet200, objectPosition, Quaternion.identity);
                }
                break;
            case 7:
                for(int i = 0; i<(nombre/500); i++) {
                    Vector3 objectPosition = Vector3.Lerp(new Vector3(0,0,150), new Vector3(0,i/2,150), (float)i * (1f/nombre));
                    Instantiate(billet500, objectPosition, Quaternion.identity);
                }
                break;
        }*/
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost ();
    }
}
