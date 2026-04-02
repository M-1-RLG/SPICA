using SPICA.Formats.Common;
using SPICA.Formats.CtrH3D.Model.Mesh;
using SPICA.Serialization;
using SPICA.Serialization.Attributes;

namespace SPICA.Formats.CtrGfx.Model.Mesh
{
    [TypeChoice(0x01000000u, typeof(GfxMesh))]
    [TypeChoice(0x00000080u, typeof(GfxMesh))]
    public class GfxMesh : GfxObject
    {
        public override GfxObjRevisionsV5 Revision => GfxObjRevisionsV5.Mesh;

        [Ignore]
        [Newtonsoft.Json.JsonIgnore]
        public H3DMesh H3DMesh;

        public int ShapeIndex;
        public int MaterialIndex;

        [Newtonsoft.Json.JsonIgnore]
        public GfxModel Parent;

        private byte Visible;

        public bool IsVisible
        {
            get => Visible != 0;
            set => Visible = (byte)(value ? 1 : 0);
        }

        public byte RenderPriority;

        public short MeshNodeIndex;

        public int PrimitiveIndex;

        [Ignore] private uint[] AttrScaleCommands;

        [Ignore]
        private string _MeshNodeName = "";

        public string MeshNodeName
        {
            get => _MeshNodeName;
            set => _MeshNodeName = value ?? throw Exceptions.GetNullException("MeshNodeName");
        }

        public GfxMesh()
        {
            AttrScaleCommands = new uint[12];

            this.Header.MagicNumber = 0x4A424F53;
        }
    }
}
