using System.IO;
using UnityEngine;

using Utility.IO;

namespace Test
{
    public class TestMeshIO : MonoBehaviour
    {
        // Member
        private static string _saveFileName = "mesh.stl";
        private static string _loadFleName = "Dragon.stl";
        private static string _directory = "E:\\WORKSPACE\\UnityProjects\\MyTest\\AppData\\Mesh\\Work";
        private static string _saveObjName = "Cube";
        private static string _loadObjName = "Dragon";

        // Public Method
        public static void Save()
        {
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }

            string path = Path.Combine(_directory, _saveFileName);
            Mesh mesh = GameObject.Find(_saveObjName).GetComponent<MeshFilter>().sharedMesh;

            MeshIO.Save(mesh, path);
        }

        public static void Load()
        {
            string path = Path.Combine(_directory, _loadFleName);
            Mesh mesh = MeshIO.Load(path);
            mesh.name = _loadObjName;

            GameObject.Find(_loadObjName).GetComponent<MeshFilter>().sharedMesh = mesh;
        }
    }
}
