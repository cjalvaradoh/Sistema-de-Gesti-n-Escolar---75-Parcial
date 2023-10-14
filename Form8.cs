using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestión_Escolar___75__Parcial
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MeExit();
        }
        private void MeExit()
        {
            DialogResult iExit;
            iExit = MessageBox.Show("¿Deseas Salir?", "Guardar DataGridView", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeExit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtén los valores de los TextBox en el orden deseado
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string matricula = textBox3.Text;
            string asignatura = textBox4.Text;
            string modalidad = textBox5.Text;
            double nota1, nota2, nota3, nota4;

            if (double.TryParse(textBox6.Text, out nota1) &&
                double.TryParse(textBox7.Text, out nota2) &&
                double.TryParse(textBox8.Text, out nota3) &&
                double.TryParse(textBox9.Text, out nota4))
            {
                double promedio = (nota1 + nota2 + nota3 + nota4) / 4.0;
                string observaciones = textBox11.Text;

                // Agrega los valores al DataGridView en el orden deseado
                dataGridView1.Rows.Add(nombre, apellido, matricula, asignatura, modalidad, nota1, nota2, nota3, nota4, promedio, observaciones);
            }
            else
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en los campos de notas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iDelete()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            iDelete();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iDelete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iReset();
        }

        private void iReset()
        {
            // Limpiar todos los TextBox
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }

            int numRows = dataGridView1.Rows.Count;

            for (int i = 0; i < numRows; i++)
            {
                try
                {
                    int max = dataGridView1.Rows.Count - 1;
                    dataGridView1.Rows.Remove(dataGridView1.Rows[max]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se deben eliminar todas las filas: " + ex.Message, "Eliminar filas de DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iReset();
        }

        Bitmap bitmap;

        private void button3_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.ColumnHeadersHeight + (dataGridView1.RowCount * dataGridView1.RowTemplate.Height);
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[dataGridView1.CurrentRow.Index];
            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox2.Text;
            newdata.Cells[2].Value = textBox3.Text;
            newdata.Cells[3].Value = textBox4.Text;
            newdata.Cells[4].Value = textBox5.Text;
            newdata.Cells[5].Value = textBox6.Text;
            newdata.Cells[6].Value = textBox7.Text;
            newdata.Cells[7].Value = textBox8.Text;
            newdata.Cells[8].Value = textBox9.Text;
            newdata.Cells[9].Value = textBox10.Text;
            newdata.Cells[10].Value = textBox11.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            iSave();
        }

        private void iSave()
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    worksheet = workbook.Sheets["Sheet1"];
                }
                catch
                {
                    worksheet = workbook.Sheets.Add();
                }

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Exported from DataGridView";

                // Encabezados
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                // Datos
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                // Guardar el archivo Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo Excel|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    app.Quit();
                }

            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iSave();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.ColumnHeadersHeight + (dataGridView1.RowCount * dataGridView1.RowTemplate.Height);
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new System.IO.FileStream(openFileDialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0); // Suponiendo que deseas importar la primera hoja.

                    dataGridView1.Rows.Clear();

                    foreach (IRow row in sheet)
                    {
                        int rowIndex = dataGridView1.Rows.Add();
                        int cellIndex = 0;

                        foreach (ICell cell in row)
                        {
                            dataGridView1.Rows[rowIndex].Cells[cellIndex].Value = cell.ToString();
                            cellIndex++;
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Obtén las notas desde los TextBox
            double nota1, nota2, nota3, nota4;

            if (double.TryParse(textBox6.Text, out nota1) &&
                double.TryParse(textBox7.Text, out nota2) &&
                double.TryParse(textBox8.Text, out nota3) &&
                double.TryParse(textBox9.Text, out nota4))
            {
                // Calcula el promedio
                double promedio = (nota1 + nota2 + nota3 + nota4) / 4.0;

                // Agrega los datos al DataGridView
                int rowIndex = dataGridView1.Rows.Add(nota1, nota2, nota3, nota4, null, null, null, null, null, promedio);

                // Actualiza la celda correspondiente con el promedio
                dataGridView1[10, rowIndex].Value = promedio;
            }
            else
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en los campos de notas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Verifica si hay datos en el DataGridView
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar un reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Genera el contenido del reporte a partir de los datos en el DataGridView
            StringBuilder reportContent = new StringBuilder();
            reportContent.AppendLine("Reporte de Notas");
            reportContent.AppendLine("=============================================");
            reportContent.AppendLine("Nombre\tApellido\tMatrícula\tAsignatura\tModalidad\tNota1\tNota2\tNota3\tNota4\tPromedio");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string rowData = string.Join("\t", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value));
                reportContent.AppendLine(rowData);
            }

            // Puedes mostrar el reporte en un cuadro de diálogo o guardarlo en un archivo
            // En este ejemplo, lo mostraremos en un cuadro de diálogo
            string report = reportContent.ToString();
            MessageBox.Show(report, "Reporte de Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // También puedes agregar código para enviar el reporte por correo electrónico aquí
        }
    }
}
