using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Analyse_your_obj
{
    public partial class OBJ_Analyser : Form
    {
        List<List<int>> listOfTrianglesUsingPoint;
        List<MyVertex> vertices = new List<MyVertex>();
        List<MyVertex> vertexNormal = new List<MyVertex>();
        List<MyFace> faces = new List<MyFace>();
        bool[] horizontalMap = null;
        bool[] verticalMap = null;

        
        public OBJ_Analyser()
        {
            InitializeComponent();

            open_file.Click += openFile_Click;
            openFileDialog.Filter = "(*.obj)|*.obj";

            StartAddingButton.Enabled = false;
            StartDeletingButton.Enabled = false;
            //SearchAndSaveObjectButton.Enabled = false;
            SearchAndSaveSurfacesButton.Enabled = false;
            //MarkingAndSaveButton.Enabled = false;
            StartSearchHorizontalAndVerticalButton.Enabled = false;

            StartSearchHorizontalAndVerticalButton.Click += searchFaces_Click;
            SearchAndSaveSurfacesButton.Click += searchAndSaveSurfacesButton_Click;
            StartDeletingButton.Click += startDeletingButton_Click;
            StartAddingButton.Click += startAddingButton_Click;

            NumberOfIgnoreSmallSurfaces.Text = Convert.ToString(IgnoreSmallFaces.Value);
            NumberOfHorizontalSearchAccuracy.Text = Convert.ToString(Convert.ToDouble(HorizontalAccuracySearch.Value) / 200);
            NumberOfVerticallSearchAccuracy.Text = Convert.ToString(Convert.ToDouble(VerticalAccuracySearch.Value) / 200);
            NumberOfHorizontalAddingAccuracy.Text = Convert.ToString(Convert.ToDouble(HorizontalAccuracyAdding.Value) / 200);
            NumberOfVerticalAddingAccuracy.Text = Convert.ToString(Convert.ToDouble(VerticalAccuracyAdding.Value) / 200);
            NumberOfHorizontalAddingCicles.Text = Convert.ToString(HorizontalCountOfAdding.Value);
            NumberOfVerticalAddingCicles.Text = Convert.ToString(VerticalCountOfAdding.Value);
            NumberOfDeletibgCicles.Text = Convert.ToString(CountOfDeepDeletingCicles.Value);


            IgnoreSmallFaces.Scroll += trackBar_Scroll;
            HorizontalAccuracySearch.Scroll += trackBar_Scroll;
            VerticalAccuracySearch.Scroll += trackBar_Scroll;
            VerticalAccuracyAdding.Scroll += trackBar_Scroll;
            HorizontalAccuracyAdding.Scroll += trackBar_Scroll;
            HorizontalCountOfAdding.Scroll += trackBar_Scroll;
            VerticalCountOfAdding.Scroll += trackBar_Scroll;
            CountOfDeepDeletingCicles.Scroll += trackBar_Scroll;



        }

        private void OBJ_Analyser_Load(object sender, EventArgs e)
        {

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            StartAddingButton.Enabled = false;
            StartDeletingButton.Enabled = false;
            //SearchAndSaveObjectButton.Enabled = false;
            SearchAndSaveSurfacesButton.Enabled = false;
            //MarkingAndSaveButton.Enabled = false;
            StartSearchHorizontalAndVerticalButton.Enabled = false;

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            ProcessTextBox.Text += filename + " успешно открыт" + "\r\n";
            StartSearchHorizontalAndVerticalButton.Enabled = true;
            
            string line = "";
            open_file.Enabled = false;
            using (StreamReader sr = new StreamReader(filename))
            {
                this.vertices = new List<MyVertex>();
                this.vertexNormal = new List<MyVertex>();
                this.faces = new List<MyFace>();

                int number = 0;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Replace("  ", " ").Replace(".", ",");
                    if (!MyParser.TryParseStringToVertex(line, this.vertices))
                        if (!MyParser.TryParseStringToVertexNormal(line, this.vertexNormal))
                            if (MyParser.TryParseToFace(line, this.faces, number))
                                number++;

                }

                foreach (var tmp in faces)
                {
                    tmp.CountNormalVector(vertices[tmp.IndexOfVertex1 - 1], vertices[tmp.IndexOfVertex2 - 1], vertices[tmp.IndexOfVertex3 - 1]);
                }

                listOfTrianglesUsingPoint = MyFaceAnaLizer.GetListOfTrianglesUsingPoint(vertices, faces);

                CountOfPointLabel.Text = "Количество точек: " + vertices.Count;
                CountOfTrianglesLabel.Text = "Количество треугольников: " + faces.Count;
                CountOfNormalLabel.Text = "Количество нормалей: " + vertexNormal.Count;

                CountOfHorizontalTrianglesLabel.Text = "Горизонтальных треугольников: ";
                CountOfVerticalTrianglesLabel.Text = "Вертикальных треугольников: ";
                CountOfOtherTrianglesLabels.Text = "Других треугольников: ";

                ProcessTextBox.Text += "Данные считаны" + "\r\n";
                ProcessTextBox.Text += "Установите точность и начните поиск" + "\r\n";
                open_file.Enabled = true;
            }
        }

        private void searchFaces_Click(object sender, EventArgs e)
        {
            open_file.Enabled = true;
            StartAddingButton.Enabled = false;
            StartDeletingButton.Enabled = false;
            //SearchAndSaveObjectButton.Enabled = false;
            SearchAndSaveSurfacesButton.Enabled = false;
            //MarkingAndSaveButton.Enabled = false;
            StartSearchHorizontalAndVerticalButton.Enabled = false;

            double horizontalAccuracy = Convert.ToDouble(HorizontalAccuracySearch.Value) / 200;
            double verticalAccuracy = Convert.ToDouble(VerticalAccuracySearch.Value) / 200;

            ProcessTextBox.Text += "Начало поиска поверхностей" + "\r\n";
            ProcessTextBox.Text += "Горизонтальная точность: " + horizontalAccuracy + " Вертикальная точность" + verticalAccuracy + " \r\n";

            horizontalMap = MyFaceAnaLizer.SearchHorizontalFaces(faces, horizontalAccuracy);
            verticalMap = MyFaceAnaLizer.SearchVerticalFaces(faces, verticalAccuracy);

            int hor = 0;
            int vert = 0;
            for (int i = 0; i < horizontalMap.Length; i++)
            {
                if (horizontalMap[i])
                    hor++;
                if (verticalMap[i])
                    vert++;
            }

            CountOfHorizontalTrianglesLabel.Text = "Горизонтальных треугольников: " + hor;
            CountOfVerticalTrianglesLabel.Text = "Вертикальных треугольников: " + vert;
            CountOfOtherTrianglesLabels.Text = "Других треугольников: " + (faces.Count - hor - vert);

            open_file.Enabled = true;
            StartSearchHorizontalAndVerticalButton.Enabled = true;
            StartAddingButton.Enabled = true;
            StartDeletingButton.Enabled = true;
            //SearchAndSaveObjectButton.Enabled = true;
            SearchAndSaveSurfacesButton.Enabled = true;
            //MarkingAndSaveButton.Enabled = true;

        }

        private void searchAndSaveSurfacesButton_Click(object sender, EventArgs e)
        {
            open_file.Enabled = true;
            StartAddingButton.Enabled = false;
            StartDeletingButton.Enabled = false;
            //SearchAndSaveObjectButton.Enabled = false;
            SearchAndSaveSurfacesButton.Enabled = false;
            //MarkingAndSaveButton.Enabled = false;
            StartSearchHorizontalAndVerticalButton.Enabled = false;
            


            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
            {
                string path = "";
                path = folderBrowserDialog.SelectedPath;
                ProcessTextBox.Text += "Начат поиск и запись поверхностей" + "\r\n";
                bool[] otherMap = new bool[horizontalMap.Length];
                for (int i = 0; i < otherMap.Length; i++)
                {
                    otherMap[i] = !(horizontalMap[i] || verticalMap[i]);
                }

                MyCollector.WriteToObjFile(faces, vertices, vertexNormal, horizontalMap, path + "/horizontal.obj");
                MyCollector.WriteToObjFile(faces, vertices, vertexNormal, verticalMap, path + "/vertical.obj");
                MyCollector.WriteToObjFile(faces, vertices, vertexNormal, otherMap, path + "/other.obj");
                ProcessTextBox.Text += "Общие файлы были созданы" + "\r\n";
                ProcessTextBox.Text += "Начало поиска и записи отдельных поверхностей. Точность: " + Convert.ToInt32(IgnoreSmallFaces.Value) + " " + "\r\n";
                MyCollector.WriteAllPartOfSurface(faces, horizontalMap, vertices, vertexNormal, listOfTrianglesUsingPoint, Convert.ToInt32(IgnoreSmallFaces.Value), path + "/horizontal");
                ProcessTextBox.Text += "Созданы файлы горизонтальных поверхностей" + "\r\n";
                MyCollector.WriteAllPartOfSurface(faces, verticalMap, vertices, vertexNormal, listOfTrianglesUsingPoint, Convert.ToInt32(IgnoreSmallFaces.Value), path + "/vertical");
                ProcessTextBox.Text += "Созданы файлы вертикальных поверхностей" + "\r\n";
                MyCollector.WriteAllPartOfSurface(faces, otherMap, vertices, vertexNormal, listOfTrianglesUsingPoint, Convert.ToInt32(IgnoreSmallFaces.Value), path + "/other");
                ProcessTextBox.Text += "Созданы файлы других поверхностей" + "\r\n";
                ProcessTextBox.Text += "Запись полностью завершена" + "\r\n";
            }
            else
            {
                ProcessTextBox.Text += "Ошибка, путь не указан" + "\r\n";
            }

            open_file.Enabled = true;
            StartSearchHorizontalAndVerticalButton.Enabled = true;
            StartAddingButton.Enabled = true;
            StartDeletingButton.Enabled = true;
            //SearchAndSaveObjectButton.Enabled = true;
            SearchAndSaveSurfacesButton.Enabled = true;
            //MarkingAndSaveButton.Enabled = true;
        }

        private void startDeletingButton_Click(object sender, EventArgs e)
        {
            open_file.Enabled = true;
            StartAddingButton.Enabled = false;
            StartDeletingButton.Enabled = false;
            //SearchAndSaveObjectButton.Enabled = false;
            SearchAndSaveSurfacesButton.Enabled = false;
            //MarkingAndSaveButton.Enabled = false;
            StartSearchHorizontalAndVerticalButton.Enabled = false;

            ProcessTextBox.Text += "Начато удаление одинокостоящих поверхностей" + "\r\n";
            if (LiteDeletingRadioButton.Checked)
            {
                ProcessTextBox.Text += "Удалено из горизонтального массива: " +  MyFaceAnaLizer.LiteDeleteLonelyTriangle(vertices, faces, horizontalMap) + "\r\n";
                ProcessTextBox.Text += "Удалено из вертикального массива: " + MyFaceAnaLizer.LiteDeleteLonelyTriangle(vertices, faces, verticalMap) + "\r\n";
            }
            if (DeepDeletingRadioButton.Checked)
            {
                ProcessTextBox.Text += "Удалено из горизонтального массива: " + MyFaceAnaLizer.DeepDeleteLonelyTriangle(vertices, faces, horizontalMap, CountOfDeepDeletingCicles.Value) + "\r\n";
                ProcessTextBox.Text += "Удалено из вертикального массива: " + MyFaceAnaLizer.DeepDeleteLonelyTriangle(vertices, faces, verticalMap, CountOfDeepDeletingCicles.Value) + "\r\n";
            }
            if (ExtremeDeletingRadioButton.Checked)
            {
                ProcessTextBox.Text += "Удалено из горизонтального массива: " + MyFaceAnaLizer.ExtremeDeleteLonelyTriangle(vertices, faces, horizontalMap, CountOfDeepDeletingCicles.Value) + "\r\n";
                ProcessTextBox.Text += "Удалено из вертикального массива: " + MyFaceAnaLizer.ExtremeDeleteLonelyTriangle(vertices, faces, verticalMap, CountOfDeepDeletingCicles.Value) + "\r\n";
            }
            ProcessTextBox.Text += "Завершено удаление одинокостоящих поверхностей" + "\r\n";

            open_file.Enabled = true;
            StartSearchHorizontalAndVerticalButton.Enabled = true;
            StartAddingButton.Enabled = true;
            StartDeletingButton.Enabled = true;
            //SearchAndSaveObjectButton.Enabled = true;
            SearchAndSaveSurfacesButton.Enabled = true;
            //MarkingAndSaveButton.Enabled = true;

            int hor = 0;
            int vert = 0;
            for (int i = 0; i < horizontalMap.Length; i++)
            {
                if (horizontalMap[i])
                    hor++;
                if (verticalMap[i])
                    vert++;
            }

            CountOfHorizontalTrianglesLabel.Text = "Горизонтальных треугольников: " + hor;
            CountOfVerticalTrianglesLabel.Text = "Вертикальных треугольников: " + vert;
            CountOfOtherTrianglesLabels.Text = "Других треугольников: " + (faces.Count - hor - vert);
        }

        private void startAddingButton_Click(object sender, EventArgs e)
        {
            ProcessTextBox.Text += "Начало поиска потеряных треугольников" + "\r\n";
            open_file.Enabled = true;
            StartAddingButton.Enabled = false;
            StartDeletingButton.Enabled = false;
            //SearchAndSaveObjectButton.Enabled = false;
            SearchAndSaveSurfacesButton.Enabled = false;
            //MarkingAndSaveButton.Enabled = false;
            StartSearchHorizontalAndVerticalButton.Enabled = false;

            MyFaceAnaLizer.SearchLostPoint(listOfTrianglesUsingPoint, vertices, faces,horizontalMap,MyNormal.IsHorizontal, HorizontalCountOfAdding.Value, Convert.ToDouble(HorizontalAccuracyAdding.Value)/200);
            MyFaceAnaLizer.SearchLostPoint(listOfTrianglesUsingPoint, vertices, faces, verticalMap, MyNormal.IsVertical, VerticalCountOfAdding.Value, Convert.ToDouble(VerticalAccuracyAdding.Value)/200);

            open_file.Enabled = true;
            StartSearchHorizontalAndVerticalButton.Enabled = true;
            StartAddingButton.Enabled = true;
            StartDeletingButton.Enabled = true;
            //SearchAndSaveObjectButton.Enabled = true;
            SearchAndSaveSurfacesButton.Enabled = true;
            //MarkingAndSaveButton.Enabled = true;

            int hor = 0;
            int vert = 0;
            for (int i = 0; i < horizontalMap.Length; i++)
            {
                if (horizontalMap[i])
                    hor++;
                if (verticalMap[i])
                    vert++;
            }

            CountOfHorizontalTrianglesLabel.Text = "Горизонтальных треугольников: " + hor;
            CountOfVerticalTrianglesLabel.Text = "Вертикальных треугольников: " + vert;
            CountOfOtherTrianglesLabels.Text = "Других треугольников: " + (faces.Count - hor - vert);

            ProcessTextBox.Text += "Поиск завершён" + "\r\n";
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void trackBar_Scroll(object sender, EventArgs e)
        {
            NumberOfIgnoreSmallSurfaces.Text = Convert.ToString(IgnoreSmallFaces.Value);
            NumberOfHorizontalSearchAccuracy.Text = Convert.ToString(Convert.ToDouble(HorizontalAccuracySearch.Value) / 200);
            NumberOfVerticallSearchAccuracy.Text = Convert.ToString(Convert.ToDouble(VerticalAccuracySearch.Value) / 200);
            NumberOfHorizontalAddingAccuracy.Text = Convert.ToString(Convert.ToDouble(HorizontalAccuracyAdding.Value) / 200);
            NumberOfVerticalAddingAccuracy.Text = Convert.ToString(Convert.ToDouble(VerticalAccuracyAdding.Value) / 200);
            NumberOfHorizontalAddingCicles.Text = Convert.ToString(HorizontalCountOfAdding.Value);
            NumberOfVerticalAddingCicles.Text = Convert.ToString(VerticalCountOfAdding.Value);
            NumberOfDeletibgCicles.Text = Convert.ToString(CountOfDeepDeletingCicles.Value);
        }

        private void HorizontalAccuracyAdding_Scroll(object sender, EventArgs e)
        {

        }

        private void HorizontalAccuracyAddingLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void VerticalAccuracyAddingLabel_Click(object sender, EventArgs e)
        {

        }

        private void LiteDeletingRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
