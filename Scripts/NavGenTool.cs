// using Godot;

// namespace Tools
// {
//     [Tool]
//     [GlobalClass]
//     public partial class NavGenTool : Node 
//     {
//         [Export] Vector2 GenerationSizePixels;
//         [Export] Vector2[] GeneratedPoly;
//         [Export] Polygon2D Visual;
        
//         bool generatePoly = false;
//         [Export] bool GeneratePoly {
//             get {
//                 return generatePoly;
//             }
//             set {
//                 generatePoly = !generatePoly;
//                 if (generatePoly) {
//                     GeneratedPoly = GeneratePolygon();
//                     Visual.Polygon = GeneratedPoly;
//                 } else {
//                     Visual.Polygon = null;
//                 }
//             }
//         }

//         public override void _Ready()
//         {
//             if (!Engine.IsEditorHint()) {
//                 Visual.Polygon = GeneratedPoly;
//             }
//         }

//         public Vector2[] GeneratePolygon() {
//             Vector2[] poly = new Vector2[4] {
//                 new(0,GenerationSizePixels.Y),
//                 GenerationSizePixels,
//                 new(GenerationSizePixels.X, 0),
//                 new(0,0),
//             };

//             var sceneChildrenCount = GetParent().GetChildCount();
//             for (int i = 0; i < sceneChildrenCount; i++) {
//                 if (GetParent().GetChild(i) is StaticBody2D sb) {
//                     var staticChildrenCount = sb.GetChildCount();
//                     for (int q = 0; q < staticChildrenCount; q++) {
//                         if (sb.GetChild(q) is CollisionShape2D cs) {
//                             if (cs.Shape is RectangleShape2D s) {
//                                 var origin = new Vector2(
//                                     cs.GlobalPosition.X - s.Size.X/2,
//                                     cs.GlobalPosition.Y + s.Size.Y/2
//                                 );
                                
//                                 Vector2[] rectPoly = new Vector2[4] {
//                                     origin,
//                                     origin + new Vector2(s.Size.X, 0),
//                                     origin + new Vector2(s.Size.X, -s.Size.Y),
//                                     origin - new Vector2(0, s.Size.Y)
//                                 };
 
//                                 poly = Geometry2D.ClipPolygons(poly, rectPoly)[0];
//                             }                        
//                         }
//                     }
//                 }
//             }

//             return poly;
//         }
//     }
// }