using System;
using UnityEngine;

public class FileControllor : MonoBehaviour
{
    static public String Pathavgr = null;
    public void OpenProject()
    {
        OpenDialogDir ofn2 = new OpenDialogDir();
        ofn2.pszDisplayName = new String(new char[2000]); ;     // 存放目录路径缓冲区  
        ofn2.lpszTitle = "Select Folder";// 标题  
        //ofn2.ulFlags = BIF_NEWDIALOGSTYLE | BIF_EDITBOX; // 新的样式,带编辑框  
        IntPtr pidlPtr = DllOpenFileDialog.SHBrowseForFolder(ofn2);

        char[] charArray = new char[2000];
        for (int i = 0; i < 2000; i++)
            charArray[i] = '\0';

        DllOpenFileDialog.SHGetPathFromIDList(pidlPtr, charArray);
        Pathavgr = new String(charArray);
        Pathavgr = Pathavgr.Substring(0, Pathavgr.IndexOf('\0'));

        Debug.Log(Pathavgr);//这个就是选择的目录路径
    }
    public void SaveProject()
    {
        
    }

}