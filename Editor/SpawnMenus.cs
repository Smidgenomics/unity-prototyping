// smidgens @ github

namespace Smidgenomics.Unity.Prototyping.Editor
{
	using UnityEditor;
	using MI = UnityEditor.MenuItem;

	/// <summary>
	/// Menu items to instantiate misc prefabs
	/// </summary>
	internal static class SpawnMenus
	{
		private const string _PFX = "GameObject/Prototyping/";
		private const int _PR = -201;
		private const int _PR_PRIM = _PR + 4;

		// PRIMITIVES

		[MI(_PFX + "Disc", false, _PR_PRIM)]
		private static void Spawn_Disc(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "2266fc13f19d63e49811eb9e707ed055", false);

		[MI(_PFX + "Plane (1x1)", false, _PR_PRIM)]
		private static void Spawn_Plane(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "c3cd0cd2037f7db409b0c5213ebd270d", false);

		[MI(_PFX + "Dome", false, _PR_PRIM)]
		private static void Spawn_Dome(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "14cdc1c85a8fb514984875bffc762b65", false);
		
		[MI(_PFX + "Torus", false, _PR_PRIM)]
		private static void Spawn_Torus(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "25b27fbed6a3cb4449d53d2a561a329b", false);
		
		[MI(_PFX + "Cone", false, _PR_PRIM)]
		private static void Spawn_Cone(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "b28e73e9c1860b940a329447cf933e1d", false);

		[MI(_PFX + "Misc/Cog", false, _PR)]
		private static void Spawn_Cog(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "a989a8f3c6726e046bb0098a7cb47578", false);
		
		[MI(_PFX + "Misc/Arrow (Flat)", false, _PR)]
		private static void Spawn_Arrow_Flat(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "6d1cfa72123cf114897d526614ff3d1d", false);
		
		[MI(_PFX + "Misc/Arrow (Tube)", false, _PR)]
		private static void Spawn_Arrow_Tube(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "abbcd7878d0bc764cbb86d72a623ba8a", false);
		
		// Ico
		[MI(_PFX + "Polyhedron/Octagon", false, _PR)]
		private static void Spawn_Octagon(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "5b1f7ee4359f1ba4786f6b714f816398");

		[MI(_PFX + "Polyhedron/Octahedron", false, _PR)]
		private static void Spawn_Octahedron(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "b41ffa37f29dbf748859798f358cb17b");
		
		[MI(_PFX + "Polyhedron/Hexahedron", false, _PR)]
		private static void Spawn_Hexahedron(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "178394d100f2d5746aa984bf05a395dd");

		// FLIPPED PRIMITIVES

		[MI(_PFX + "Flipped/Cube", false, _PR)]
		private static void Spawn_Cube_Flipped(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "94565b0791434fb4da39f6f37d79a16f", false);
		
		[MI(_PFX + "Flipped/Cone", false, _PR)]
		private static void Spawn_Cone_Flipped(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "7b142f6436775af48b240a8efe790661", false);

		[MI(_PFX + "Flipped/Sphere", false, _PR)]
		private static void Spawn_Sphere_Flipped(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "2bc88a857191ae44ab1246a4dea90bb3", false);

		[MI(_PFX + "Flipped/Cylinder", false, _PR)]
		private static void Spawn_Cylinder_Flipped(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "25afab996c61c7b41a75cfe07e8945be", false);

		[MI(_PFX + "Flipped/Capsule", false, _PR)]
		private static void Spawn_Capsule_Flipped(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "99c5bb4cd304a1841b1a56e969444bb3", false);

		[MI(_PFX + "Flipped/Dome", false, _PR)]
		private static void Spawn_Dome_Flipped(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "17276d210c18cc447be625e3c8cc9954", false);

		// RAMPS / STEPS

		[MI(_PFX + "Steps/Straight", false, _PR)]
		private static void Spawn_Steps(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "b12cc6bdb1dd5dd449ba56e83acd0748");

		[MI(_PFX + "Steps/Corner", false, _PR)]
		private static void Spawn_Steps_Corner(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "e487dc65d42dcc248812b9c468c03418");

		[MI(_PFX + "Steps/Elbow", false, _PR)]
		private static void Spawn_Steps_Elbow(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "cd4ac31cfdd8c9a4b9ba0e57ebdfe1ed");

		[MI(_PFX + "Ramp/Straight", false, _PR)]
		private static void Spawn_Ramp(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "c36e155574e51d3458341e670bdf3d75");

		[MI(_PFX + "Ramp/Corner", false, _PR)]
		private static void Spawn_Ramp_Corner(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "294bc1f95f4bdbf44baf718c6c3dde35");

		[MI(_PFX + "Ramp/Elbow", false, _PR)]
		private static void Spawn_Ramp_Elbow(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "3f7da8fb79b96954d824086d640177f8");
		
		// LEVEL
		
		[MI(_PFX + "Level/Door", false, _PR)]
		private static void Spawn_Extras_Door(MenuCommand cmd) => PTUtils.SpawnPrefab(cmd, "1c25354981554a2458adff7548c53e2a");
		
		[MI(_PFX + "Wall/2x3 (Door Hole)", false, _PR)]
		private static void Spawn_Wall2x3_Door(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "306b94c4e5a1bb44a94d9870aaeb45fd", false);
		
		[MI(_PFX + "Wall/2x3", false, _PR)]
		private static void Spawn_Wall2x3(MenuCommand cmd) => PTUtils.SpawnPrefab(cmd, "bd99379aa9c433f43b9e5a1a5d37dbd7");

		[MI(_PFX + "Wall/1x3 (Corner)", false, _PR)]
		private static void Spawn_Wall1x3_Corner(MenuCommand cmd) => PTUtils.SpawnMeshPrefab(cmd, "590a68332f1514e41b9d5f9bb4299305", false);


		
	}
}