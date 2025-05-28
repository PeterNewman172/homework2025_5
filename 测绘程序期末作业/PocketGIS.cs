
using System.Text;
using System.Windows.Forms;
using PocketGIS;

namespace 测绘程序期末作业

{
    public partial class PocketGIS : Form
    {
        private OpenFileDialog openCsvDialog = new OpenFileDialog(); // CSV专用打开对话框
        private const string CSV_FILE_FILTER = "全站仪CSV数据|*.csv";
        private ToolStripMenuItem[] layerMenuItems;  // 用于存储图层菜单项
        private bool[] layerVisible = { true, true, true };
        private enum ToolType { Select, Point, Line }

        private ToolType currentTool = ToolType.Select;
        private List<Geometry> geometries = new List<Geometry>();
        private Geometry currentGeometry = null;
        private Point startPoint;
        private int currentLayer = 0;
        private List<string> layers = new List<string> { "Layer 1", "Layer 2", "Layer 3" };
        private Color[] layerColors = { Color.Black, Color.Red, Color.Blue };
        public PocketGIS()
        {
            InitializeComponent();
            InitializeUI();
        }
        private void InitializeUI()
        {
            // 初始化工具栏按钮
            tsbSelect.Tag = ToolType.Select;
            tsbPoint.Tag = ToolType.Point;
            tsbLine.Tag = ToolType.Line;

            // 初始化图层菜单项数组
            layerMenuItems = new ToolStripMenuItem[] {
        layer1ToolStripMenuItem,
        layer2ToolStripMenuItem,
        layer3ToolStripMenuItem
    };

            // 设置当前图层菜单项文本
            UpdateCurrentLayerText();
            UpdateStatus();
        }
        

        private void UpdateCurrentLayerText()
        {
            currentLayerToolStripMenuItem.Text = $"当前图层：Layer {currentLayer + 1}";
        }

        private void UpdateLayerVisibilityMenu()
        {
            layerVisible1.Checked = layerVisible[0];
            layerVisible2.Checked = layerVisible[1];
            layerVisible3.Checked = layerVisible[2];
        }

        private void SetLayerVisibility(int layerIndex, bool visible)
        {
            layerVisible[layerIndex] = visible;
            drawingPanel.Invalidate();
        }

        private void EnsureLayerVisible(int layerIndex)
        {
            if (!layerVisible[layerIndex])
            {
                layerVisible[layerIndex] = true;
                UpdateLayerVisibilityMenu();
                drawingPanel.Invalidate();
            }
        }
        private void UpdateStatus()
        {
            statusStrip1.Text = $"当前工具: {currentTool} | 当前图层: {layers[currentLayer]}";
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var layer in Enumerable.Range(0, 3))
            {
                if (!layerVisible[layer]) continue;

                foreach (var geometry in geometries.Where(g => g.Layer == layer))
                {
                    geometry.Draw(e.Graphics);
                }
            }
        }
        private GeometryLine activeLine = null;
        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {

            if (currentTool == ToolType.Select)
            {
                // 仅在激活图层中选择图形
                foreach (var geometry in geometries.Where(g => g.Layer == activeLayerIndex).Reverse())
                {
                    if (geometry.HitTest(e.Location))
                    {
                        currentGeometry = geometry;
                        startPoint = e.Location;
                        break;
                    }
                }
            }
            else if (currentTool == ToolType.Point)
            {
                var point = new GeometryPoint
                {
                    Location = e.Location,
                    Layer = currentLayer, 
                    Color = layerColors[currentLayer] 
                };
                geometries.Add(point);
                drawingPanel.Invalidate();
            }
            else if (currentTool == ToolType.Line)
            {
                if (activeLine == null)
                {
                    activeLine = new GeometryLine
                    {
                        Start = e.Location,
                        End = e.Location,
                        Layer = currentLayer, 
                        Color = layerColors[currentLayer], 
                        FirstPointSet = true
                    };
                    geometries.Add(activeLine);
                }
                else
                {
                    // 完成线段（设置终点）
                    activeLine.End = e.Location;
                    activeLine = null;
                }
                drawingPanel.Invalidate();
            }
        }
        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = $"坐标: ({e.X}, {e.Y})";

            if (e.Button == MouseButtons.Left && currentGeometry != null)
            {
                // 拖动图形（点或线）
                if (currentGeometry is GeometryPoint point)
                {
                    point.Location = e.Location;
                }
                else if (currentGeometry is GeometryLine line)
                {
                    int dx = e.X - startPoint.X;
                    int dy = e.Y - startPoint.Y;
                    line.Start = new Point(line.Start.X + dx, line.Start.Y + dy);
                    line.End = new Point(line.End.X + dx, line.End.Y + dy);
                    startPoint = e.Location;
                }
                drawingPanel.Invalidate();
            }
            else if (currentTool == ToolType.Line && activeLine != null && activeLine.FirstPointSet)
            {
                // 实时更新线段终点（鼠标移动时）
                activeLine.End = e.Location;
                drawingPanel.Invalidate();
            }
        }
        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            currentGeometry = null;
        }
        private void toolButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton button && button.Tag is ToolType type)
            {
                currentTool = type;
                UpdateStatus();
            }
        }

        // 图层选择变化事件
        
        private void menuNew_Click(object sender, EventArgs e)
        {
            geometries.Clear();
            drawingPanel.Invalidate();
        }
        private List<GeometryPoint> ParseCsvToGeometryPoints(string filePath)
        {
            var points = new List<GeometryPoint>();
            var lines = File.ReadAllLines(filePath);
            var headers = lines[0].Split(',', StringSplitOptions.TrimEntries); // 解析标题行

            for (int i = 1; i < lines.Length; i++) // 从第二行开始读取数据
            {
                var values = lines[i].Split(',', StringSplitOptions.TrimEntries);
                if (values.Length < 3) continue; // 至少需要点号、X、Y

                var point = new GeometryPoint
                {
                    PointID = values[0], // 点号（第一列）
                    Location = new PointF(
                        float.Parse(values[1]), // X坐标（第二列）
                        float.Parse(values[2])), // Y坐标（第三列）
                    Z = TryParseDouble(values, 3, 0), // Z坐标（第四列，可选）
                    Color = ParseColorFromCsv(values, 4), // 颜色Argb值（第五列，可选）
                    Layer = currentLayer, // 当前激活图层
                    CreationTime = DateTime.Now, // 导入时间
                    Description = values.Length > 5 ? values[5] : "", // 描述（第六列，可选）
                    SymbolSize = TryParseFloat(values, 6, 5f), // 符号大小（第七列，可选）
                    SymbolStyle = values.Length > 6 ? values[6] : "Circle", // 符号样式（第八列，可选）
                    IsSurveyPoint = true // 标记为实测点
                };
                points.Add(point);
            }
            return points;
        }

        // 辅助方法：安全解析double
        private double TryParseDouble(string[] values, int index, double defaultValue)
        {
            return values.Length > index && double.TryParse(values[index], out var val)
                ? val : defaultValue;
        }

        // 辅助方法：安全解析float
        private float TryParseFloat(string[] values, int index, float defaultValue)
        {
            return values.Length > index && float.TryParse(values[index], out var val)
                ? val : defaultValue;
        }

        // 辅助方法：解析颜色（支持Argb值或颜色名称）
        private Color ParseColorFromCsv(string[] values, int index)
        {
            if (values.Length > index)
            {
                if (int.TryParse(values[index], out int argb)) return Color.FromArgb(argb);
                if (Enum.TryParse(values[index], out KnownColor color)) return Color.FromKnownColor(color);
            }
            return layerColors[currentLayer]; // 无颜色时使用图层默认色
        }
        private void menuOpen_Click(object sender, EventArgs e)
        {
            // 配置CSV对话框
            openCsvDialog.Filter = CSV_FILE_FILTER;
            openCsvDialog.Title = "导入全站仪CSV数据";
            openCsvDialog.InitialDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);

            if (openCsvDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newPoints = ParseCsvToGeometryPoints(openCsvDialog.FileName);
                    geometries.AddRange(newPoints); // 追加而非清空
                    drawingPanel.Invalidate(); // 刷新绘图
                    ShowImportSuccessMessage(newPoints.Count);
                }
                catch (Exception ex)
                {
                    ShowImportError(ex.Message);
                }
            }
        }
        private void ShowImportSuccessMessage(int count)
        {
            statusStrip1.Text = $"成功导入 {count} 个点到图层{currentLayer + 1}";
            MessageBox.Show($"导入完成：{count} 个点", "成功",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowImportError(string message)
        {
            statusStrip1.Text = $"导入失败：{message}";
            MessageBox.Show($"错误：{message}", "失败",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV 文件|*.csv|几何文件|*.geo|所有文件|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    if (sfd.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        
                        sw.WriteLine("点号,X,Y,Z,ColorArgb,SymbolSize,SymbolStyle,描述");

                        foreach (var geometry in geometries)
                        {
                            if (geometry is GeometryPoint point)
                            {
                                sw.WriteLine(
                                    $"{EscapeCsvField(point.PointID)}," +  // 点号
                                    $"{point.Location.X}," +               // X
                                    $"{point.Location.Y}," +               // Y
                                    $"{point.Z}," +                        // Z
                                    $"{point.Color.ToArgb()}," +           // ColorArgb
                                    $"{point.SymbolSize}," +               // SymbolSize
                                    $"{EscapeCsvField(point.SymbolStyle)}," + // SymbolStyle
                                    $"{EscapeCsvField(point.Description)}"    // 描述
                                );
                            }
                            // 线（Line）不写入此 CSV 格式，因示例未包含
                        }
                    }
                    else
                    {
                        // 原有 GEO 格式保存逻辑（略）
                    }
                }
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 辅助方法：转义 CSV 字段中的特殊字符（逗号、引号）
        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field)) return "";
            return field.Contains(",") || field.Contains("\"")
                ? $"\"{field.Replace("\"", "\"\"")}\""
                : field;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private int activeLayerIndex = 0; // 当前激活图层索引（0=Layer1，1=Layer2，2=Layer3）
        private readonly List<string> layerNames = new List<string> { "Layer 1", "Layer 2", "Layer 3" };
        private void LayerMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is int layerIndex)
            {
                currentLayer = layerIndex;
                EnsureLayerVisible(currentLayer);
                UpdateCurrentLayerText();
                UpdateStatus();

                // 更新菜单项的选中状态
                foreach (var item in layerMenuItems)
                {
                    item.Checked = (int)item.Tag == currentLayer;
                }
            }
        }
        private void layerVisible1_Click(object sender, EventArgs e)
        {
            SetLayerVisibility(0, layerVisible1.Checked);
        }

        private void layerVisible2_Click(object sender, EventArgs e)
        {
            SetLayerVisibility(1, layerVisible2.Checked);
        }

        private void layerVisible3_Click(object sender, EventArgs e)
        {
            SetLayerVisibility(2, layerVisible3.Checked);
        }
        private void 可视性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
   
    }

