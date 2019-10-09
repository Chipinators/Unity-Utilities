using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

namespace Chipinators
{
    /// <summary>
    /// Files are saved in Unity's Persistent Data Path.
    /// On PC / Editor you can view this at:  
    /// C:\Users\USERNAME\AppData\LocalLow\COMPANY_NAME\PRODUCT_NAME
    /// USERNAME = Your computer's account name
    /// COMPANY_NAME = The Company Name listed in the Unity Player Settings
    /// PRODUCT_NAME = The Product Name listed in the Unity Player Settings
    /// </summary>

    public class FileSaver
    {

        /// <summary>
        /// Save the given data into the given file. Overrides original file if it exists. 
        /// MUST INCLUDE FILE EXTENSION.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static void Save<T>(string fileName, T data) where T : new()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + fileName);
            bf.Serialize(file, data);
            file.Close();
        }

        /// <summary>
        /// Try to load the given file name and return the data of given type. Returns default object if file does not exist. 
        /// MUST INCLUDE FILE EXTENSION.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static T Load<T>(string fileName)
        {
            if (File.Exists(Application.persistentDataPath + "/" + fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
                T data = (T)bf.Deserialize(file);
                file.Close();
                return data;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Deletes the given file if it exists. 
        /// MUST INCLUDE FILE EXTENSION.
        /// </summary>
        /// <param name="fileName"></param>
        public static void Delete(string fileName)
        {
            if (File.Exists(Application.persistentDataPath + "/" + fileName))
            {
                File.Delete(Application.persistentDataPath + "/" + fileName);
            }
        }

        /// <summary>
        /// Deletes all files in Unity's Persistent Data Path. Useful for if you want to reset all of your save data at once.
        /// </summary>
        public static void DeleteAllFiles()
        {
            foreach (string filePath in Directory.GetFiles(Application.persistentDataPath + "/"))
            {
                Debug.Log("Deleting -- " + filePath);
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Returns true if the given file exists. 
        /// MUST INCLUDE FILE EXTENSION.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool FileExists(string fileName)
        {
            return File.Exists(Application.persistentDataPath + "/" + fileName);
        }
    }

}
