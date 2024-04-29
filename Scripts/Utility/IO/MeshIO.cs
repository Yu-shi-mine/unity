using System;
using System.IO;
using UnityEngine;

namespace Utility.IO
{
    public class MeshIO : MonoBehaviour
    {
        // Constant
        private const int SKIP_HEADER = 80;
        private const int SKIP_NORMAL = 12;
        private const int SKIP_UNUSED = 2;

        // Public Method
        public static void Save(Mesh mesh, string path)
        {
            using (var writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                // ���g�p�f�[�^
                byte[] unusedBytes = new byte[SKIP_UNUSED];

                // �C�ӂ̕��������������
                byte[] bytes = new byte[SKIP_HEADER];
                writer.Write(bytes);

                // �O�p�`�̖�������������
                var triangleNum = mesh.triangles.Length / 3;
                writer.Write((Int32)triangleNum);

                // �O�p�`�̖��������J��Ԃ�
                int triangleIndex = 0;
                for (int i = 0; i < triangleNum; i++)
                {
                    // �@���x�N�g������������
                    Vector3 normal = mesh.normals[mesh.triangles[triangleIndex]];
                    writer.Write((Single)normal.x);
                    writer.Write((Single)normal.z);
                    writer.Write((Single)normal.y);

                    // ���_���W����������
                    for (int j = 0; j < 3; j++)
                    {
                        Vector3 vert = mesh.vertices[mesh.triangles[triangleIndex++]];
                        writer.Write((Single)vert.x * 1000);
                        writer.Write((Single)vert.z * 1000);
                        writer.Write((Single)vert.y * 1000);
                    }

                    // ���g�p�f�[�^����������
                    writer.Write(unusedBytes);
                }
            }
        }

        public static Mesh Load(string path)
        {
            using (var stream = File.OpenRead(path))
            using (var reader = new BinaryReader(stream))
            {
                // "�C�ӂ̕�����"��ǂݔ�΂�
                stream.Position = SKIP_HEADER;

                // "�O�p�`�̖���"��ǂݍ���
                uint triangleNum = reader.ReadUInt32();

                Vector3[] vert = new Vector3[triangleNum * 3];
                int[] tri = new int[triangleNum * 3];

                int triangleIndex = 0;

                for (int i = 0; i < triangleNum; i++)
                {
                    // �@���x�N�g����ǂݔ�΂�
                    stream.Position += SKIP_NORMAL;

                    // ���_�f�[�^��3��
                    Vector3 a = new Vector3(reader.ReadSingle() / 1000, reader.ReadSingle() / 1000, reader.ReadSingle() / 1000);
                    Vector3 b = new Vector3(reader.ReadSingle() / 1000, reader.ReadSingle() / 1000, reader.ReadSingle() / 1000);
                    Vector3 c = new Vector3(reader.ReadSingle() / 1000, reader.ReadSingle() / 1000, reader.ReadSingle() / 1000);
                    vert[triangleIndex + 0] = ToLeftSpace(a);
                    vert[triangleIndex + 1] = ToLeftSpace(b);
                    vert[triangleIndex + 2] = ToLeftSpace(c);

                    tri[triangleIndex] = triangleIndex++;
                    tri[triangleIndex] = triangleIndex++;
                    tri[triangleIndex] = triangleIndex++;

                    // "���g�p�f�[�^"��ǂݔ�΂�
                    stream.Position += SKIP_UNUSED;
                }

                var mesh = new Mesh()
                {
                    indexFormat = UnityEngine.Rendering.IndexFormat.UInt32
                };
                mesh.vertices = vert;
                mesh.triangles = tri;
                mesh.RecalculateNormals();
                mesh.RecalculateBounds();
                return mesh;
            }
        }

        // Private Method
        private static Vector3 ToLeftSpace(Vector3 point)
        {
            return new Vector3(-point.y, point.z, point.x);
        }
    }
}
