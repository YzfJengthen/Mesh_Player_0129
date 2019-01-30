using Dummiesman;
using System;
using System.IO;
using UnityEngine;
public class ObjFromFile : MonoBehaviour
{
    public string Path = null;
    public string[] Files;
    public string[] Mtls;
    public OBJLoader loadedObj = new OBJLoader();
    public OBJLoader loadedObj1 = new OBJLoader();
    public int i=0;
    public GameObject temp;
    public GameObject temp1;
    public bool Flags = false;
    void Start()
    {
        temp = new GameObject();
        //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //sw.Start();
        //Path = @"C:\Users\vive_1\Desktop\zf\mesh";
        //Files = Directory.GetFiles(Path, "*.obj");
        //Mtls = Directory.GetFiles(Path, "*.mtl");
        //temp = loadedObj.Load(Files[0], Mtls[0]);
        //sw.Stop();
        //TimeSpan ts2 = sw.Elapsed;
        //Debug.Log(ts2.TotalSeconds);
        //temp.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }


    void Update()
    {
        if (!string.IsNullOrEmpty(FileControllor.Pathavgr))
        {
            Path = FileControllor.Pathavgr;
            Files = Directory.GetFiles(Path, "*.obj");
            Mtls = Directory.GetFiles(Path, "*.mtl");
            Flags = true;
        }

        if (Flags)
        {
            if (i < Files.Length && i > 0)
            {
                Destroy(temp);
                Resources.UnloadUnusedAssets();
                temp = null;
                temp = loadedObj.Load(Files[i], Mtls[i]);
                temp.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            }
            else if (i == 0)
            {
                temp = loadedObj.Load(Files[i], Mtls[i]);
                temp.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            }
            else if (i == Files.Length)
            {
                i = 0;
            }
            i++;
        }
    }
    
}
