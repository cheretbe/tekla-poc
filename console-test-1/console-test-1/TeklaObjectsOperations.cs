using TSM = Tekla.Structures.Model;
using TSG3d = Tekla.Structures.Geometry3d;
using Tekla.Structures.Analysis;

namespace TeklaObjectsOperations
{
    public class TestOperations
    {
        public static bool CreateBeam()
        {
            TSM.Model myModel = new TSM.Model();
            TSM.Beam myBeam = new TSM.Beam(new TSG3d.Point(1000, 1000, 1000),
                        new TSG3d.Point(6000, 6000, 1000));
            myBeam.Material.MaterialString = "Concrete_Undefined";
            myBeam.Profile.ProfileString = "800*400";
            bool creationResult = false;
            if (myBeam.Insert()) {
                creationResult = myModel.CommitChanges();
            }
            return creationResult;
        }
    }
}