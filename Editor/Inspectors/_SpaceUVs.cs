// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Prototyping.Editor
{
	using UnityEditor;
	using UnityEngine;

	// Used for options enum in shaders (be careful about renaming or moving this
	internal enum ERenderSpace { Object, World, }

	/// <summary>
	/// Custom GUI for following shaders:
	/// </summary>
	internal sealed class _SpaceUVs : ShaderGUI
	{
		public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
		{
			var color = FindProperty("_Color", properties);
			var mainTex = FindProperty("_MainTex", properties);

			// draw albedo + main color
			DrawTextureLine(materialEditor, ref _lMain, mainTex, color);

			// draw normal map
			var normal = FindProperty("_BumpMap", properties);
			var normalStrength = FindProperty("_BumpScale", properties);
			DrawTextureLine(materialEditor, ref _lNormal, normal, normalStrength);

			// draw remaining props that aren't marked hidden
			foreach (var prop in properties)
			{
				if (prop.propertyFlags.HasFlag(UnityEngine.Rendering.ShaderPropertyFlags.HideInInspector)) { continue; }
				materialEditor.ShaderProperty(prop, prop.displayName);
			}
		}

		// cached label for texture property
		// TexturePropertySingleLine for some reason only supports GUIContent labels
		private static GUIContent
			_lNormal = null,
			_lMain = null;

		private static GUIContent GetCachedLabel(string l, ref GUIContent val)
		{
			return val ??= new GUIContent(l);
		}

		private static void DrawTextureLine
		(
			MaterialEditor me,
			ref GUIContent labelCache,
			MaterialProperty prop,
			MaterialProperty extra = null
		)
		{
			var label = GetCachedLabel(prop.displayName, ref labelCache);
			if (extra != null)
			{
				me.TexturePropertySingleLine(label, prop, extra);
			}
			else { me.TexturePropertySingleLine(label, prop); }
		}
	}
}

#endif