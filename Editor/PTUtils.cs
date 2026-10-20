// smidgens @ github

namespace Smidgenomics.Unity.Prototyping.Editor
{
	using UnityEditor;
	using UnityEditor.SceneManagement;
	using UnityEngine;

	internal static class PTUtils
	{
		// mirrors an internal enum that describes pref value:
		// UnityEditor.GOCreationCommands+PlacementMode
		internal enum EPlacementMode
		{
			// not supported here currently, relies on internal Unity APIs
			SceneIntersection,
			// 0,0,0
			WorldOrigin,
			// SceneView.pivot
			ScenePivot
		}

		public static Vector3 GetSceneSpawnOrigin()
		{
			var mode = GetScenePlacementModePref();
			
			if (mode == EPlacementMode.ScenePivot)
			{
				var sv = SceneView.lastActiveSceneView;
				if (sv)
				{
					return sv.pivot;
				}
			}
			return default;
		}
		
		public static void SpawnMeshPrefab(MenuCommand cmd, string guid, bool convex = true)
		{
			var go = InstantiateFromGUID(cmd, guid);
			var mf = go.GetComponent<MeshFilter>();
			var col = go.AddComponent<MeshCollider>();
			col.sharedMesh = mf.sharedMesh;
			col.convex = convex;
			// go.name = pf.name;
			Undo.RegisterCreatedObjectUndo(go, "Instantiated prefab");
			Selection.activeGameObject = go;
		}

		public static void SpawnPrefab(MenuCommand cmd, string guid)
		{
			var go = InstantiateFromGUID(cmd, guid);
			// go.name = pf.name;
			Undo.RegisterCreatedObjectUndo(go, "Instantiated prefab");
			Selection.activeGameObject = go;
		}

		private static GameObject InstantiateFromGUID(MenuCommand cmd, string guid)
		{
			var parent = cmd.context as GameObject;
			var pfStage = PrefabStageUtility.GetCurrentPrefabStage();
			if (pfStage && !parent)
			{
				parent = pfStage.prefabContentsRoot;
			}

			var pf = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid));
			var go = Object.Instantiate(pf, parent?.transform);
			ObjectNames.SetNameSmart(go, pf.name.Substring(3).Replace('_','/'));
			go.transform.localPosition = PTUtils.GetSceneSpawnOrigin();

			return go;
		}

		public static EPlacementMode GetScenePlacementModePref()
		{
			// https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/Commands/GOCreationCommands.cs
			// why must I do this, unity...
			var placementMode = EditorPrefs.GetInt("Create3DObject.PlacementMode", 0);
			return (EPlacementMode)placementMode;
		}
	}
}