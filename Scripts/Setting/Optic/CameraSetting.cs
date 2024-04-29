
namespace Setting.Optic
{
    [System.Serializable]
    public class CameraSetting : SettingBase
    {
        // Inheritance
        public override string Type
        {
            get { return TYPE; }
        }


        // Constant
        public const string TYPE = "Camera";


        // Property
        public CMOSSetting CMOS;
        public LensSetting Lens;
        public float WorkDistance;


        // Constructor
        public CameraSetting(string path, CMOSSetting cmos, LensSetting lens, float workDistance) : base(path)
        {
            CMOS = cmos;
            Lens = lens;
            WorkDistance = workDistance;
        }
    }

    [System.Serializable]
    public class CMOSSetting : SettingBase
    {
        // Inheritance
        public override string Type
        {
            get { return TYPE; }
        }


        // Constant
        public const string TYPE = "CMOS";


        // Property
        public int Width;
        public int Height;
        public float PixWidth;
        public float PixHeight;


        // Constructor
        public CMOSSetting(string path, int width, int height, float pixWidth, float pixHeight) : base(path)
        {
            Width = width;
            Height = height;
            PixWidth = pixWidth;
            PixHeight = pixHeight;
        }
    }

    [System.Serializable]
    public class LensSetting : SettingBase
    {
        // Inheritance
        public override string Type
        {
            get { return TYPE; }
        }


        // Constant
        public const string TYPE = "Lens";


        // Property
        public float FocalLenght;


        // Constructor
        public LensSetting(string path, float focalLength) : base(path)
        {
            FocalLenght = focalLength;
        }
    }
}

