using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class InputActionEditor : EditorWindow
{

    //private Toggle 
    //[MenuItem("Tool/Dont Use- TEST-Input Action Editor")]
    public static void ShowWindow()
    {
        InputActionEditor window = GetWindow<InputActionEditor>();
        Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Editor/Images/settings.png");
        window.titleContent = new GUIContent("Input Action Editor", icon); //, icon
        window.minSize = new Vector2(600,300);
    }
    //public static void ShowExample()
    //{
    //    InputActionEditor wnd = GetWindow<InputActionEditor>();
    //    wnd.titleContent = new GUIContent("Input Action Editor");
    //}

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/InputActionEditor.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/InputActionEditor.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);
        root.styleSheets.Add(styleSheet);
    }
}