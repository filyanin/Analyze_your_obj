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

            CountOfDeletingCiclesBox.KeyPress += textBoxInt_KeyPress;
            HorizontalAccuracyAddingBox.KeyPress += textBox_KeyPress;
            VerticalAccuracyAddingBox.KeyPress += textBox_KeyPress;
            HorizontalSearchAccuracyBox.KeyPress += textBox_KeyPress;
            VerticalSearchAccuracyBox.KeyPress += textBox_KeyPress;
            IgnoreNumberBox.KeyPress += textBoxInt_KeyPress;
            CountOfHorizontalAddingCiclesBox.KeyPress += textBoxInt_KeyPress;
            CountVerticalAddingBox.KeyPress += textBoxInt_KeyPress;


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
            if ((HorizontalSearchAccuracyBox.Text != "") && (VerticalSearchAccuracyBox.Text != ""))
            {
                double horizontalAccuracy = Convert.ToDouble(HorizontalSearchAccuracyBox.Text);
                double verticalAccuracy = Convert.ToDouble(VerticalSearchAccuracyBox.Text);
                if ((horizontalAccuracy < 1) && (verticalAccuracy < 1))
                {
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


                    StartAddingButton.Enabled = true;
                    StartDeletingButton.Enabled = true;
                    //SearchAndSaveObjectButton.Enabled = true;
                    SearchAndSaveSurfacesButton.Enabled = true;
                    //MarkingAndSaveButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Значение должно быть меньше 1!");
                }
            }
            else
            {
                MessageBox.Show("Одно ил оба поля точности пусты, введите значения и повторите");
            }
            open_file.Enabled = true;
            StartSearchHorizontalAndVerticalButton.Enabled = true;

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


            if (IgnoreNumberBox.Text != "")
            {
                int number = Convert.ToInt32(IgnoreNumberBox.Text);
                if (number < (faces.Count / 4))
                {
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
                        DirectoryInfo directoryInfo;
                        if (!Directory.Exists(path + "/faces"))
                        {
                            directoryInfo = new DirectoryInfo(path + "/faces");
                            directoryInfo.Create();

                        }
                        else
                        {
                            int tmpNumber = 1;
                            while (Directory.Exists(path + "/faces" + tmpNumber))
                            {
                                tmpNumber++;
                            }
                            directoryInfo = new DirectoryInfo(path + "/faces" + tmpNumber);
                            directoryInfo.Create();
                        }
                        directoryInfo.CreateSubdirectory("common");
                        directoryInfo.CreateSubdirectory("vertical");
                        directoryInfo.CreateSubdirectory("horizontal");
                        directoryInfo.CreateSubdirectory("other");

                        MyCollector.WriteToObjFile(faces, vertices, vertexNormal, horizontalMap, directoryInfo.FullName + "/common/horizontal.obj");
                        MyCollector.WriteToObjFile(faces, vertices, vertexNormal, verticalMap, directoryInfo.FullName + "/common/vertical.obj");
                        MyCollector.WriteToObjFile(faces, vertices, vertexNormal, directoryInfo.FullName + "/common/other.obj");
                        ProcessTextBox.Text += "Общие файлы были созданы" + "\r\n";
                        ProcessTextBox.Text += "Начало поиска и записи отдельных поверхностей. Точность: " + number + " " + "\r\n";
                        MyCollector.WriteAllPartOfSurface(faces, horizontalMap, vertices, vertexNormal, listOfTrianglesUsingPoint, number, directoryInfo.FullName + "/horizontal/horizontal");
                        ProcessTextBox.Text += "Созданы файлы горизонтальных поверхностей" + "\r\n";
                        MyCollector.WriteAllPartOfSurface(faces, verticalMap, vertices, vertexNormal, listOfTrianglesUsingPoint, number, directoryInfo.FullName + "/vertical/vertical");
                        ProcessTextBox.Text += "Созданы файлы вертикальных поверхностей" + "\r\n";
                        MyCollector.WriteAllPartOfSurface(faces, otherMap, vertices, vertexNormal, listOfTrianglesUsingPoint, number, directoryInfo.FullName + "/other/other");
                        ProcessTextBox.Text += "Созданы файлы других поверхностей" + "\r\n";
                        ProcessTextBox.Text += "Запись полностью завершена" + "\r\n";

                        MessageBox.Show("Сохранение произведено успешно!");
                        

                    }
                    else
                    {
                        ProcessTextBox.Text += "Ошибка, путь не указан" + "\r\n";
                    }
                }
                else
                    MessageBox.Show("Значение отсечения не должно превышать 25% от числа треугольников");
            }
            else
                MessageBox.Show("Не указан уровень отсечения!");

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
            if (CountOfDeletingCiclesBox.Text != "")
            {
                int number = Convert.ToInt32(CountOfDeletingCiclesBox.Text);
                ProcessTextBox.Text += "Начато удаление одинокостоящих поверхностей" + "\r\n";
                if (LiteDeletingRadioButton.Checked)
                {
                    ProcessTextBox.Text += "Удалено из горизонтального массива: " + MyFaceAnaLizer.LiteDeleteLonelyTriangle(vertices, faces, horizontalMap) + "\r\n";
                    ProcessTextBox.Text += "Удалено из вертикального массива: " + MyFaceAnaLizer.LiteDeleteLonelyTriangle(vertices, faces, verticalMap) + "\r\n";
                }
                if (DeepDeletingRadioButton.Checked)
                {
                    ProcessTextBox.Text += "Удалено из горизонтального массива: " + MyFaceAnaLizer.DeepDeleteLonelyTriangle(vertices, faces, horizontalMap, number) + "\r\n";
                    ProcessTextBox.Text += "Удалено из вертикального массива: " + MyFaceAnaLizer.DeepDeleteLonelyTriangle(vertices, faces, verticalMap, number) + "\r\n";
                }
                if (ExtremeDeletingRadioButton.Checked)
                {
                    ProcessTextBox.Text += "Удалено из горизонтального массива: " + MyFaceAnaLizer.ExtremeDeleteLonelyTriangle(vertices, faces, horizontalMap, number) + "\r\n";
                    ProcessTextBox.Text += "Удалено из вертикального массива: " + MyFaceAnaLizer.ExtremeDeleteLonelyTriangle(vertices, faces, verticalMap, number) + "\r\n";
                }
                ProcessTextBox.Text += "Завершено удаление одинокостоящих поверхностей" + "\r\n";
            }
            else
                MessageBox.Show("Не указано количество циклов!");

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

            if ((HorizontalAccuracyAddingBox.Text != "") && (CountOfHorizontalAddingCiclesBox.Text != "") && (VerticalAccuracyAddingBox.Text != "") && (CountVerticalAddingBox.Text != ""))
            {
                MyFaceAnaLizer.SearchLostPoint(listOfTrianglesUsingPoint, vertices, faces,horizontalMap,MyNormal.IsHorizontal, Convert.ToInt32(CountOfHorizontalAddingCiclesBox.Text), Convert.ToDouble(HorizontalAccuracyAddingBox.Text));
                MyFaceAnaLizer.SearchLostPoint(listOfTrianglesUsingPoint, vertices, faces, verticalMap, MyNormal.IsVertical, Convert.ToInt32(CountVerticalAddingBox.Text), Convert.ToDouble(VerticalAccuracyAddingBox.Text));


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
            open_file.Enabled = true;
            StartSearchHorizontalAndVerticalButton.Enabled = true;
            StartAddingButton.Enabled = true;
            StartDeletingButton.Enabled = true;
            //SearchAndSaveObjectButton.Enabled = true;
            SearchAndSaveSurfacesButton.Enabled = true;
            //MarkingAndSaveButton.Enabled = true;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public int DS_Count(string s)
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            e.Handled = !(Char.IsDigit(e.KeyChar) || ((e.KeyChar == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && (DS_Count(((TextBox)sender).Text) < 1)) || (Char.IsControl(e.KeyChar)));
        }

        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(Char.IsDigit(e.KeyChar) || (Char.IsControl(e.KeyChar)));
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
